using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using Microsoft.WindowsAPICodePack.Dialogs;
using TripleDES;
using System.Security.Principal;

namespace HyenaFTP
{
    public partial class HyenaFTP : Form
    {
        public HyenaFTP()
        {
            InitializeComponent();
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string DownloadPath = @"%USERPROFILE%\Downloads";
            string ExpandedDownloadPath = Environment.ExpandEnvironmentVariables(DownloadPath + @"\Hyena_FTP_Module_Setup.hmc");
            var folderPath = txtPath.Text;
            string filePath = txtSeletFile.Text;
            string ftpSetup = Ftp_Setup();
            string[] seperLine = ftpSetup.Split(' ');
            string Ftp_IP = "";
            string Ftp_ID = "";
            string Ftp_FWD = "";
            string hyenaEmail = "";

            if (seperLine.Length > 4)
            {
                hyenaEmail = seperLine[0];
                Ftp_IP = seperLine[1];
                Ftp_ID = TripleDES_Decryptor.Decrypt(seperLine[2]);
                Ftp_FWD = TripleDES_Decryptor.Decrypt(seperLine[3]);
            }

            using (var ftp = new FtpClient(Ftp_IP, Ftp_ID, Ftp_FWD)) // ftp 서버 아이피, 생성될 폴더명(계정명), ftp 비밀번호
            {
                //보안통신 설정
                ftp.EncryptionMode = FtpEncryptionMode.Explicit;
                ftp.ValidateAnyCertificate = true;    //

                ftp.Connect();

                Action<FtpProgress> pro = new Action<FtpProgress>(s =>
                {
                    // 취소처리 
                    if (!(backgroundWorker.CancellationPending))
                    {
                        backgroundWorker.ReportProgress((int)s.Progress, s.LocalPath);
                    }
                    else
                    {
                        backgroundWorker.ReportProgress((int)s.Progress, s.LocalPath);
                        e.Cancel = true;
                        ftp.Execute("ABOR"); // QUIT  // filezilla server에 ABOR 명령어 직접 전달 (파일전송 중단)
                    }
                }); // 전체 파일수를 카운트하여 하나의 파일이 전송 완료될때마다 1씩 증가하는 ProgressBar

                try
                {

                    if (folderPath == "")
                    {
                        //파일 전송 구간 

                        string fileName = System.IO.Path.GetFileName(filePath);
                        string dirName = System.IO.Path.GetDirectoryName(filePath);

                        ftp.CreateDirectory(hyenaEmail);

                        //ftp.UploadFile(filePath, hyenaEmail + @"\" + fileName, FtpRemoteExists.Overwrite, true, FtpVerify.None, pro);
                        ftp.UploadFile(filePath, hyenaEmail + @"\" + fileName, FtpRemoteExists.Overwrite, true, FtpVerify.None, pro);
                        // 취소처리 
                        if (!(backgroundWorker.CancellationPending))
                        {
                            FileInfo file = new FileInfo(filePath);
                            ftp.SetModifiedTime(@"\" + hyenaEmail + filePath, file.LastWriteTime); // 클라이언트 측의 경로를 서버 경로로 재 가공
                        }
                        else  //파일 취소시 파일 삭제 필요
                        {
                            throw new Exception();
                            MessageBox.Show("서버에 업로드된 파일 삭제완료", "업로드 파일 삭제");
                            return;
                        }
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(folderPath); // Directory 함수의 경우 시스템 권한을 가진 폴더를 전부 포함하여 전송간 에러발생되어 수정
                        FileInfo[] allfilelist = di.GetFiles("*", SearchOption.AllDirectories);
                        FileInfo[] filelist = di.GetFiles("*", SearchOption.TopDirectoryOnly);
                        DirectoryInfo[] folderlist = di.GetDirectories("*", SearchOption.AllDirectories);

                        // 가져온 정보를 전부 string값으로 변환 진행
                        string[] allfiles = allfilelist.Select(f => f.FullName).ToArray();
                        string[] files = filelist.Select(f => f.FullName).ToArray();
                        string[] folders = folderlist.Select(f => f.FullName).ToArray();

                        int FolderCount = folders.Length;
                        int FilesCount = allfiles.Length;
                        int i = 0;

                        foreach (string file in files)  //현재폴더 부터 전송하고, 디렉토리 순으로 진행하면 프로그래스바 표시 가능???
                        {
                            if (backgroundWorker.CancellationPending)
                                throw new Exception();

                            AllbackgroundWorker.ReportProgress(++i, FilesCount);
                            FileInfo fileInfo = new FileInfo(file);
                            ftp.UploadFile(file, hyenaEmail + @"\" + fileInfo.Name, FtpRemoteExists.Overwrite, true, FtpVerify.None, pro);
                            ftp.SetModifiedTime(hyenaEmail + Convert.ToString(file).Replace(folderPath, ""), fileInfo.LastWriteTime); // 클라이언트 측의 경로를 서버 경로로 재 가공
                        }

                        foreach (string folder in folders)
                        {
                            if (backgroundWorker.CancellationPending)
                                throw new Exception();
                            //폴더가 있다면 생성
                            string createfolder = Convert.ToString(folder).Replace(folderPath, "");
                            ftp.CreateDirectory(hyenaEmail + @"\" + createfolder);

                            //하위 폴더 내 파일 검색
                            string[] subfiles = Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly);


                            foreach (string file in subfiles)  //현재폴더 부터 전송하고, 디렉토리 순으로 진행하면 프로그래스바 표시 가능???
                            {
                                if (backgroundWorker.CancellationPending)
                                    throw new Exception();
                                AllbackgroundWorker.ReportProgress(++i, FilesCount);
                                FileInfo fileInfo = new FileInfo(file);
                                string uploadfile = Convert.ToString(fileInfo.FullName).Replace(folderPath, "");

                                ftp.UploadFile(file, hyenaEmail + @"\" + uploadfile, FtpRemoteExists.Overwrite, true, FtpVerify.None, pro);
                                ftp.SetModifiedTime(hyenaEmail + Convert.ToString(file).Replace(folderPath, ""), fileInfo.LastWriteTime); // 클라이언트 측의 경로를 서버 경로로 재 가공
                            }
                        }
                    }

                    if (!(backgroundWorker.CancellationPending))
                    {
                        string fileNameKey = System.IO.Path.GetFileName(ExpandedDownloadPath);
                        ftp.UploadFile(ExpandedDownloadPath, hyenaEmail + @"\" + fileNameKey, FtpRemoteExists.Overwrite, true, FtpVerify.None, null);
                    }

                }
                catch
                {
                    e.Cancel = true;
                    ftp.Connect();
                    //ftp.DeleteDirectory(hyenaEmail);   // 전송된 파일 삭제
                    int i = 0;
                    int uploadFileCount;
                    var ftpFiles = ftp.GetListing(@"\" + hyenaEmail, FtpListOption.AllFiles);

                    uploadFileCount = ftpFiles.Length;

                    foreach (var item in ftpFiles)
                    {
                        ftp.Execute("DELE " + item.FullName);
                        //lblStatus.Text = "파일삭제" + i++;
                        AllbackgroundWorker.ReportProgress(++i, uploadFileCount);


                    }
                    ftp.DeleteDirectory(@"\" + hyenaEmail);

                    ftp.Disconnect();
                    ftp.Dispose();   //ftp 통신 종료

                    //취소 후 처리 공간
                    MessageBox.Show("서버에 업로드된 파일" + FilesinPro.Text.Replace("진행", "파일") + " 삭제완료", "업로드 파일 삭제");
                    return;
                }
            }
        }


        private void AllbackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (!(backgroundWorker.CancellationPending))
                {
                    this.Invoke(new Action(delegate ()
                    {
                        FilesinPro.Text = String.Format("[총{0}개/{1}개 진행]", e.UserState, e.ProgressPercentage.ToString());
                        AllprogressBar.Maximum = ((int)e.UserState);
                        AllprogressBar.Value = e.ProgressPercentage;
                    }));
                }
                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        FilesinPro.Text = String.Format("[총{0}개/{1}개 삭제]", e.UserState, e.ProgressPercentage.ToString());
                        AllprogressBar.Maximum = ((int)e.UserState);
                        AllprogressBar.Value = e.ProgressPercentage;
                    }));
                }
            }
            catch
            {
                return;
            }
        }


        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(backgroundWorker.CancellationPending))
            {
                string fileName = System.IO.Path.GetFileName(e.UserState.ToString());
                string outText = String.Format("[진행률:{0}%]: {1}", e.ProgressPercentage.ToString(), fileName);
                if (!btnUpload.Text.Contains("업로드"))
                {
                    btnUpload.Text = "전송취소";
                    btnUpload.BackColor = Color.Maroon;
                    btnUpload.Enabled = true;
                }
                else if (!btnFileUpload.Text.Contains("업로드"))
                {
                    btnFileUpload.Text = "전송취소";
                    btnFileUpload.BackColor = Color.Maroon;
                    btnFileUpload.Enabled = true;
                }

                if (txtSeletFile.Text == "")
                {
                    lblStatus.Text = outText;
                    progressBar.Value = e.ProgressPercentage;
                }
                else
                {
                    lblFileStatus.Text = outText;
                    progressBarFile.Value = e.ProgressPercentage;
                }
            }
            else
            {
                progressBar.Value = 0;
                progressBarFile.Value = 0;
                AllprogressBar.Value = 0;
                return;
            }
        }


        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if (btnUpload.Text.Contains("삭제"))
                {
                    btnUpload.Enabled = false;
                }
                else if (btnFileUpload.Text.Contains("파일삭제"))
                {
                    btnFileUpload.Enabled = false;
                }
            }
            else if (e.Error == null)
            {
                this.FilesinPro.Text = this.FilesinPro.Text + "[업로드 성공]";
                this.lblStatus.Text = "";
                MessageBox.Show("파일업로드가 완료되었습니다. [업로드 파일 등록] 클릭", "업로드 성공");
            }
            else
            {
                MessageBox.Show(e.Error.Message, "실패");
            }
            btnUpload.Text = "폴더 업로드";
            btnFileUpload.Text = "파일 업로드";
            this.btnUpload.BackColor = Color.LightGray;
            this.btnFileUpload.BackColor = Color.LightGray;
            this.selectPath.Enabled = true;
            this.selectPath.BackColor = Color.Blue;
            this.txtPath.Text = "";
            this.btnUpload.Enabled = false;
            this.FilesinPro.Text = "";
            this.lblStatus.Text = "";
            this.progressBar.Value = 0;
            this.AllprogressBar.Value = 0;
            this.btnSeletFile.Enabled = true;
            this.btnSeletFile.BackColor = Color.Blue;
            this.txtSeletFile.Text = "";
            this.btnFileUpload.Enabled = false;
            this.lblFileStatus.Text = "";
            this.progressBarFile.Value = 0;
        }

        //폴더 업로드 0705
        private void selectPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = this.txtPath.Text;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.txtPath.Text = dialog.FileName;

                if (txtPath.Text != "")
                {
                    this.btnUpload.Enabled = true;
                    this.txtSeletFile.Text = "";
                    this.btnFileUpload.Enabled = false;
                    this.selectPath.BackColor = Color.Navy;
                    this.btnUpload.BackColor = Color.Maroon;
                }
                else
                {
                    this.selectPath.BackColor = Color.Blue;
                }
            }
        }

        //파일업로드 0705
        private void btnSeletFile_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = this.txtSeletFile.Text;
            dialog.IsFolderPicker = false;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.txtSeletFile.Text = dialog.FileName;

                if (txtSeletFile.Text != "")
                {
                    this.btnFileUpload.Enabled = true;
                    this.txtPath.Text = "";
                    this.btnUpload.Enabled = false;
                    this.btnSeletFile.BackColor = Color.Navy;
                    this.btnFileUpload.BackColor = Color.Maroon;
                }
                else
                {
                    this.btnSeletFile.BackColor = Color.Blue;
                }
            }
        }

        //폴더 전송
        private void btnUpload_Click(object sender, EventArgs e)
        {
            //유효성 검사, 암호화된 파일인가? 
            //타임이 10분 이내 인가? 아니면 삭제
            string result = "";
            if (!btnUpload.Text.Contains("취소"))
            {
                if (txtPath.Text == "")
                {
                    result = "대상폴더가 없습니다. 경로선택 필수";
                    MessageBox.Show(result, "경로선택 필요");
                    return;
                }

                string DownloadPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads");
                string ExpandedDownloadPath = DownloadPath + @"\Hyena_FTP_Module_Setup.hmc";
                string ftpSetup = Ftp_Setup();

                if (ftpSetup != "")
                {
                    string[] seperLine = ftpSetup.Split(' ');
                    long timeSec = 0;
                    DateTime OutDate = DateTime.UtcNow;
                    long setupData = LongByDateTime(OutDate);

                    if (seperLine.Length > 4)
                    {
                        timeSec = Int64.Parse(seperLine[4]);
                    }

                    if (timeSec <= setupData && (timeSec + 600000) >= setupData)  //10분이내 수행해야함
                    {
                        txtSeletFile.Text = "";
                        lblStatus.Text = "파일정보 확인중(파일에 따라 수분이 소요). 잠시만 기다려 주시기 바랍니다.";
                        btnUpload.Text = "전송 준비중";
                        backgroundWorker.RunWorkerAsync();
                        btnUpload.Enabled = false;
                        btnSeletFile.Enabled = false;
                        btnFileUpload.Enabled = false;
                        selectPath.Enabled = false;
                        this.selectPath.BackColor = Color.LightGray;
                        this.btnUpload.BackColor = Color.LightGray;
                        this.btnSeletFile.BackColor = Color.LightGray;
                        this.btnFileUpload.BackColor = Color.LightGray;
                    }
                    else
                    {
                        try
                        {
                            result = "설치파일이 유효하지 않습니다. [전용프로그램(설치/실행)] 재수행 요청";
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    result = "설치파일이 없습니다. [전용프로그램(설치/실행] 재수행 요청";
                }

                if (result != "")
                {
                    MessageBox.Show(result, "인증실패");
                    //불필요파일 삭제 수행
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(DownloadPath);
                        foreach (FileInfo fileName in di.GetFiles("Hyena_FTP_Module*.*", SearchOption.AllDirectories)) // 재귀함수로 각각의 폴더를 전부 들어가는것 보다 검색옵션으로 리스트만 추출하는게 속도가 더 빠름
                        {
                            fileName.Delete();
                        }
                    }
                    catch
                    {

                    }
                    this.Close();
                }
            }
            else   // 전송취소인 경우
            {
                this.backgroundWorker.CancelAsync();
                //this.AllbackgroundWorker.CancelAsync();
                AllprogressBar.Value = 0;

                btnUpload.Text = "파일삭제";
                this.btnUpload.BackColor = Color.LightGray;
                lblStatus.Text = "업로드된 파일 삭제중 입니다. 잠시만 기다려 주시기 바랍니다.";
                btnUpload.Enabled = false;
            }

            return;
        }

        //DateTime을 Millisecond 형식으로 변경
        public static long LongByDateTime(DateTime date)
        {
            long resultTime = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return resultTime;
        }

        //pmc 생성
        private string Ftp_Setup()
        {
            string DownloadPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads");
            string ExpandedDownloadPath = DownloadPath + @"\Hyena_FTP_Module_Setup.hmc";
            string encryptText;
            string decryptText;
            string result = "";

            try
            {
                encryptText = System.IO.File.ReadAllText(ExpandedDownloadPath);
                decryptText = TripleDES_Decryptor.Decrypt(encryptText);  //복호화//사용자 계정: eMail 서버주소 ftpid ftppwd time  
                result = decryptText;
            }
            catch
            { }

            return result;
        }

        private void HyenaFTP_Load(object sender, EventArgs e)
        {
            string DownloadPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads");
            string ExpandedDownloadPath = DownloadPath + @"\Hyena_FTP_Module_Setup.hmc";

            try
            {
                string encryptText = System.IO.File.ReadAllText(ExpandedDownloadPath);
            }
            catch
            {
                MessageBox.Show("설치파일이 없습니다. Hyena서버 [전용프로그램(설치/실행] 재수행 요청", "인증실패");
                this.Close();
            }
        }


        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            //유효성 검사, 암호화된 파일인가? 
            //타임이 10분 이내 인가? 아니면 삭제
            if (!btnFileUpload.Text.Contains("취소"))
            {
                string result = "";
                if (txtSeletFile.Text == "")
                {
                    result = "대상파일이 없습니다. 파일선택 필수";
                    MessageBox.Show(result, "파일선택 필요");
                    return;
                }

                string DownloadPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads");
                string ExpandedDownloadPath = DownloadPath + @"\Hyena_FTP_Module_Setup.hmc";
                string ftpSetup = Ftp_Setup();

                if (ftpSetup != "")
                {
                    string[] seperLine = ftpSetup.Split(' ');
                    long timeSec = 0;
                    DateTime OutDate = DateTime.UtcNow;
                    long setupData = LongByDateTime(OutDate);

                    if (seperLine.Length > 4)
                    {
                        timeSec = Int64.Parse(seperLine[4]);
                    }

                    if (timeSec <= setupData && (timeSec + 600000) >= setupData)  //10분이내 수행해야함
                    {
                        txtPath.Text = "";
                        lblFileStatus.Text = "업로드 파일정보를 확인하고있습니다. 잠시만 기다려주시기 바랍니다!!";
                        btnFileUpload.Text = "전송 준비중";
                        backgroundWorker.RunWorkerAsync();
                        btnUpload.Enabled = false;
                        btnSeletFile.Enabled = false;
                        btnFileUpload.Enabled = false;
                        selectPath.Enabled = false;
                        this.selectPath.BackColor = Color.LightGray;
                        this.btnUpload.BackColor = Color.LightGray;
                        this.btnSeletFile.BackColor = Color.LightGray;
                        this.btnFileUpload.BackColor = Color.LightGray;
                    }
                    else
                    {
                        try
                        {
                            result = "설치파일이 유효하지 않습니다. [폴더업로드] 재수행 요청";
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    result = "설치파일이 없습니다. [폴더업로드] 재수행 요청";
                }

                if (result != "")
                {
                    MessageBox.Show(result, "인증실패");
                    //불필요파일 삭제 수행
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(DownloadPath);
                        foreach (FileInfo fileName in di.GetFiles("Hyena_FTP_Module*.*", SearchOption.AllDirectories)) // 재귀함수로 각각의 폴더를 전부 들어가는것 보다 검색옵션으로 리스트만 추출하는게 속도가 더 빠름
                        {
                            fileName.Delete();
                        }
                    }
                    catch
                    {

                    }
                    this.Close();
                }
            }
            else   // 전송취소인 경우
            {

                this.backgroundWorker.CancelAsync();
                this.AllbackgroundWorker.CancelAsync();
                btnFileUpload.Text = "파일삭제";
                this.btnFileUpload.BackColor = Color.LightGray;
                lblFileStatus.Text = "업로드된 파일 삭제중 입니다. 잠시만 기다려 주시기 바랍니다.";
                btnFileUpload.Enabled = false;

            }
            return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hyena 파일등록 프로그램을 종료합니다.", "종료");
            try
            {
                string DownloadPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads");
                DirectoryInfo di = new DirectoryInfo(DownloadPath);
                foreach (FileInfo fileName in di.GetFiles("Hyena_FTP_Module*.*", SearchOption.AllDirectories)) // 재귀함수로 각각의 폴더를 전부 들어가는것 보다 검색옵션으로 리스트만 추출하는게 속도가 더 빠름
                {
                    fileName.Delete();
                }
                backgroundWorker.CancelAsync();
                AllbackgroundWorker.CancelAsync();
                backgroundWorker.Dispose();
                AllbackgroundWorker.Dispose();
                this.Dispose();
                this.Close();
            }
            catch
            {

            }
        }

    }
}

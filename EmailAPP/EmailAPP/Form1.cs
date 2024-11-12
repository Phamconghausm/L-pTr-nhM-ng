using MailKit.Net.Imap;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace EmailAPP
{
    public partial class Form1 : Form
    {
        private string email = "conghau0169@gmail.com";
        private string password = "kbkh sklp cckj cstk";
        private string smtpServer = "smtp.gmail.com";
        private string imapServer = "imap.gmail.com";
        private int smtpPort = 465;
        private int imapPort = 993;

        private List<IMessageSummary> emailList = new List<IMessageSummary>();
        private List<MimeMessage> draftEmails = new List<MimeMessage>(); // Thêm biến lưu trữ bản nháp
        private List<string> attachedFiles = new List<string>(); // Biến để đính kèm file

        public Form1()
        {
            InitializeComponent();
            lstEmails.SelectedIndexChanged += LstEmails_SelectedIndexChanged;
            LoadDrafts();
        }

        private async void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTo.Text) || string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin người nhận và tiêu đề.");
                return;
            }

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Duy Đan", email));
                message.To.Add(MailboxAddress.Parse(txtTo.Text));
                message.Subject = txtSubject.Text;
                message.Body = new TextPart("plain") { Text = rtbEmailContent.Text };

                // Tạo 1 message body để giữ nội dung và tệp đính kèm
                var bodyBuilder = new BodyBuilder { TextBody = rtbEmailContent.Text };

                // Add attachments Thêm tệp đính kèm
                foreach (var filePath in attachedFiles)
                {
                    bodyBuilder.Attachments.Add(filePath);
                }

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, true);
                    await client.AuthenticateAsync(email, password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                MessageBox.Show("Email đã được gửi thành công !");
            }
            catch (MailKit.Security.AuthenticationException)
            {
                MessageBox.Show("Lỗi xác thực: Kiểm tra thông tin đăng nhập.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}");
            }
        }

        private async void btnReadEmails_Click(object sender, EventArgs e)
        {
            lstEmails.Items.Clear();
            emailList.Clear();

            try
            {
                using (var client = new ImapClient())
                {
                    await client.ConnectAsync(imapServer, imapPort, true);
                    await client.AuthenticateAsync(email, password);

                    await client.Inbox.OpenAsync(FolderAccess.ReadOnly);
                    var summaries = await client.Inbox.FetchAsync(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.Envelope | MessageSummaryItems.Flags);

                    var reversedSummaries = summaries.Reverse();

                    foreach (var summary in reversedSummaries)
                    {
                        string readStatus = (summary.Flags.HasValue && summary.Flags.Value.HasFlag(MessageFlags.Seen)) ? "Đã Đọc" : "Chưa Đọc";
                        lstEmails.Items.Add($"From: {summary.Envelope.From} - Subject: {summary.Envelope.Subject} - {readStatus}");
                        emailList.Add(summary);
                    }

                    await client.DisconnectAsync(true);
                }
            }
            catch (MailKit.Security.AuthenticationException)
            {
                MessageBox.Show("Lỗi xác thực: Kiểm tra thông tin đăng nhập.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc email: {ex.Message}");
            }
        }

        private async void LstEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstEmails.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < emailList.Count)
            {
                var selectedEmailSummary = emailList[selectedIndex];
                var uid = selectedEmailSummary.UniqueId; // Lấy UniqueId của email

                try
                {
                    using (var client = new ImapClient())
                    {
                        await client.ConnectAsync(imapServer, imapPort, true);
                        await client.AuthenticateAsync(email, password);

                        // Mở hộp thư để đọc email
                        await client.Inbox.OpenAsync(FolderAccess.ReadOnly);

                        // Lấy email đầy đủ bằng UID
                        var message = await client.Inbox.GetMessageAsync(uid);

                        txtTo.Text = ((MailboxAddress)message.From.Mailboxes.First()).Address;
                        txtSubject.Text = message.Subject;
                        rtbEmailContent.Text = message.TextBody ?? "[Không có nội dung văn bản]"; // Hiển thị nội dung email

                        await client.DisconnectAsync(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải nội dung email: {ex.Message}");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSubject.Text = string.Empty;
            rtbEmailContent.Text = string.Empty;
        }

        private void btnSaveDraft_Click_3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTo.Text) || string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin người nhận và tiêu đề!");
                return;
            }

            SaveDraft(txtTo.Text, txtSubject.Text, rtbEmailContent.Text);
        }

        private void SaveDraft(string to, string subject, string body)
        {
            try
            {
                var draftMessage = new MimeMessage();
                draftMessage.To.Add(MailboxAddress.Parse(to));
                draftMessage.Subject = subject;
                draftMessage.Body = new TextPart("plain") { Text = body };
                draftEmails.Add(draftMessage);

                string filePath = @"D:\CODE\EmailAPP\drafts.txt";

                using (var writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{to}|||{subject}|||{body}"); // Dùng dấu phân cách "|||" để tránh lỗi do dấu phẩy
                }

                MessageBox.Show("Đã lưu bản nháp thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lưu bản nháp: {ex.Message}");
            }
        }


        private void LoadDrafts()
        {
            string filePath = @"D:\CODE\EmailAPP\drafts.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    var lines = File.ReadAllLines(filePath);
                    draftEmails.Clear();

                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        var parts = line.Split(new[] { "|||" }, StringSplitOptions.None); // Sử dụng dấu phân cách "|||"

                        if (parts.Length < 3)
                        {
                            MessageBox.Show($"Dòng không hợp lệ: {line}");
                            continue;
                        }

                        var draft = new MimeMessage
                        {
                            Subject = parts[1],
                            Body = new TextPart("plain") { Text = parts[2] }
                        };
                        draft.To.Add(new MailboxAddress("", parts[0]));
                        draftEmails.Add(draft);
                    }

                    MessageBox.Show("Các bản nháp đã được tải thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải bản nháp: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tệp bản nháp.");
            }
        }


        private void btnShowDraft_Click_3(object sender, EventArgs e)
        {
            if (draftEmails.Count > 0)
            {
                var draft = draftEmails.Last(); // Lấy bản nháp cuối cùng
                txtTo.Text = draft.To.Mailboxes.First().Address;
                txtSubject.Text = draft.Subject;
                rtbEmailContent.Text = draft.TextBody ?? "[Không có nội dung văn bản]";
            }
            else
            {
                MessageBox.Show("Không có bản nháp nào để hiển thị.");
            }
        }


        private async void btnDeleteEmail_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = lstEmails.SelectedIndex;

            if (selectedIndex != -1)
            {
                var emailToDelete = emailList[selectedIndex];
                var uid = emailToDelete.UniqueId;

                try
                {
                    using (var client = new ImapClient())
                    {
                        await client.ConnectAsync(imapServer, imapPort, true);
                        await client.AuthenticateAsync(email, password);

                        await client.Inbox.OpenAsync(FolderAccess.ReadWrite);

                        await client.Inbox.AddFlagsAsync(uid, MessageFlags.Deleted, true);
                        await client.Inbox.ExpungeAsync();

                        lstEmails.Items.RemoveAt(selectedIndex);
                        emailList.RemoveAt(selectedIndex);

                        MessageBox.Show("Email đã được xóa thành công!");
                        await client.DisconnectAsync(true);
                    }
                }
                catch (MailKit.Security.AuthenticationException)
                {
                    MessageBox.Show("Lỗi xác thực: Kiểm tra thông tin đăng nhập.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa email: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một email để xóa.");
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            lstEmails.Items.Clear();
            int foundCount = 0;

            foreach (var emailSummary in emailList)
            {
                string readStatus = (emailSummary.Flags.HasValue && emailSummary.Flags.Value.HasFlag(MessageFlags.Seen)) ? "Đã Đọc" : "Chưa Đọc";

                // Kiểm tra điều kiện tìm kiếm
                if (emailSummary.Envelope.Subject?.ToLower().Contains(searchText) == true ||
                    emailSummary.Envelope.From.ToString().ToLower().Contains(searchText) == true)
                {
                    lstEmails.Items.Add($"From: {emailSummary.Envelope.From} - Subject: {emailSummary.Envelope.Subject} - {readStatus}");
                    foundCount++;
                }
            }

            MessageBox.Show(foundCount > 0 ? $"Tìm thấy {foundCount} email." : "Không tìm thấy email nào.");
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void rtbEmailContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true; // Cho phép được chọn nhiều files
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        if (!attachedFiles.Contains(file)) // Kiểm tra file để tránh trùng lặp
                        {
                            attachedFiles.Add(file); // Thêm đường dẫn file vào list
                            lstAttachments.Items.Add(file); // Hiển thị tên file trong Listbox
                        }
                    }
                }
            }
        }

        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            // Kiểm tra tệp đã được chọn trong Listbox chưa
            if (lstAttachments.SelectedItem != null)
            {
                // Lấy đường dẫn file đã được chọn
                string selectedFile = lstAttachments.SelectedItem.ToString();

                // Xác nhận việc xóa file
                var result = MessageBox.Show($"Bạn chắc chắn muốn xóa file này?: {selectedFile}?",
                                             "Xác nhận xóa",
                                             MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Xóa file trong Listbox 
                    lstAttachments.Items.Remove(selectedFile);

                    // Xóa file trong danh sách tệp đính kèm
                    attachedFiles.Remove(selectedFile);

                    MessageBox.Show("Đã xóa file thành công.");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 file để xóa.");
            }
        }

        private async void btnReply_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có email nào được chọn trong Listbox chưa
            if (lstEmails.SelectedItem != null)
            {
                int selectedIndex = lstEmails.SelectedIndex;
                var selectedEmail = emailList[selectedIndex]; // Lấy email đã chọn
                var uid = selectedEmail.UniqueId; // Sử dụng UniqueId thay vì index để lấy chính xác email

                try
                {
                    using (var client = new ImapClient())
                    {
                        await client.ConnectAsync(imapServer, imapPort, true);
                        await client.AuthenticateAsync(email, password);
                        await client.Inbox.OpenAsync(FolderAccess.ReadOnly);

                        // Lấy nội dung đầy đủ của email để trả lời
                        var message = await client.Inbox.GetMessageAsync(uid);

                        // Điền thông tin trả lời vào các trường gửi email
                        txtTo.Text = message.From.Mailboxes.FirstOrDefault()?.Address;
                        txtSubject.Text = "Re: " + message.Subject;
                        rtbEmailContent.Text = "\n\n--- Tin nhắn gốc ---\n" + message.TextBody;

                        // Chuyển qua tab Gửi Email
                        tabControlEmail.SelectedTab = tabPage2;

                        await client.DisconnectAsync(true);
                    }
                }
                catch (MailKit.Security.AuthenticationException)
                {
                    MessageBox.Show("Lỗi xác thực: Kiểm tra thông tin đăng nhập.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy email trả lời: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy chọn một email để trả lời.");
            }
        }


        private async void btnForward_Click(object sender, EventArgs e)
        {
            // Kiểm tra email đã được chọn trong Listbox chưa
            if (lstEmails.SelectedItem != null)
            {
                int selectedIndex = lstEmails.SelectedIndex;

                try
                {
                    // Kết nối đến máy chủ để lấy email đã chọn
                    using (var client = new ImapClient())
                    {
                        await client.ConnectAsync(imapServer, imapPort, true);
                        await client.AuthenticateAsync(email, password);
                        await client.Inbox.OpenAsync(FolderAccess.ReadOnly);

                        var message = await client.Inbox.GetMessageAsync(emailList[selectedIndex].UniqueId);

                        // Điền thông tin vào phần chuyển tiếp email
                        txtTo.Text = ""; // Để trống người nhận để chuyển tiếp đến người khác
                        txtSubject.Text = "Fwd: " + message.Subject;
                        rtbEmailContent.Text = "\n\n--- Tin được chuyển tiếp ---\n" +
                                                $"From: {message.From}\n" +
                                                $"Date: {message.Date}\n" +
                                                $"Subject: {message.Subject}\n\n" +
                                                message.TextBody;

                        // Chuyển qua tab Gửi Email
                        tabControlEmail.SelectedTab = tabPage2;

                        await client.DisconnectAsync(true);
                    }
                }
                catch (MailKit.Security.AuthenticationException)
                {
                    MessageBox.Show("Lỗi xác thực: Kiểm tra thông tin đăng nhập.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chuyển tiếp email: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy chọn một email để chuyển tiếp.");
            }
        }

    }
}

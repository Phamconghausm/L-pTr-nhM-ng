using System;
using System.Runtime.InteropServices;

namespace EmailAPP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlEmail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteEmail = new System.Windows.Forms.Button();
            this.lstEmails = new System.Windows.Forms.ListBox();
            this.btnReadEmails = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnShowDraft = new System.Windows.Forms.Button();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbEmailContent = new System.Windows.Forms.RichTextBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.tabControlEmail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEmail
            // 
            this.tabControlEmail.Controls.Add(this.tabPage1);
            this.tabControlEmail.Controls.Add(this.tabPage2);
            this.tabControlEmail.Location = new System.Drawing.Point(4, 0);
            this.tabControlEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlEmail.Name = "tabControlEmail";
            this.tabControlEmail.SelectedIndex = 0;
            this.tabControlEmail.Size = new System.Drawing.Size(706, 358);
            this.tabControlEmail.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnForward);
            this.tabPage1.Controls.Add(this.btnReply);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.btnDeleteEmail);
            this.tabPage1.Controls.Add(this.lstEmails);
            this.tabPage1.Controls.Add(this.btnReadEmails);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(698, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Đọc Email";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(586, 186);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(105, 40);
            this.btnForward.TabIndex = 6;
            this.btnForward.Text = "Chuyển tiếp";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(586, 117);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(105, 38);
            this.btnReply.TabIndex = 5;
            this.btnReply.Text = "Trả lời";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(390, 90);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(156, 91);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // btnDeleteEmail
            // 
            this.btnDeleteEmail.Location = new System.Drawing.Point(586, 252);
            this.btnDeleteEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteEmail.Name = "btnDeleteEmail";
            this.btnDeleteEmail.Size = new System.Drawing.Size(105, 42);
            this.btnDeleteEmail.TabIndex = 2;
            this.btnDeleteEmail.Text = "Xóa";
            this.btnDeleteEmail.UseVisualStyleBackColor = true;
            this.btnDeleteEmail.Click += new System.EventHandler(this.btnDeleteEmail_Click_1);
            // 
            // lstEmails
            // 
            this.lstEmails.FormattingEnabled = true;
            this.lstEmails.ItemHeight = 16;
            this.lstEmails.Location = new System.Drawing.Point(55, 117);
            this.lstEmails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstEmails.Name = "lstEmails";
            this.lstEmails.Size = new System.Drawing.Size(518, 196);
            this.lstEmails.TabIndex = 1;
            // 
            // btnReadEmails
            // 
            this.btnReadEmails.Location = new System.Drawing.Point(5, 14);
            this.btnReadEmails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReadEmails.Name = "btnReadEmails";
            this.btnReadEmails.Size = new System.Drawing.Size(97, 46);
            this.btnReadEmails.TabIndex = 0;
            this.btnReadEmails.Text = "Đọc Email";
            this.btnReadEmails.UseVisualStyleBackColor = true;
            this.btnReadEmails.Click += new System.EventHandler(this.btnReadEmails_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRemoveAttachment);
            this.tabPage2.Controls.Add(this.lstAttachments);
            this.tabPage2.Controls.Add(this.btnAttach);
            this.tabPage2.Controls.Add(this.btnShowDraft);
            this.tabPage2.Controls.Add(this.btnSaveDraft);
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.rtbEmailContent);
            this.tabPage2.Controls.Add(this.btnSendEmail);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtSubject);
            this.tabPage2.Controls.Add(this.txtTo);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(698, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gửi Email";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Location = new System.Drawing.Point(594, 160);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(98, 49);
            this.btnRemoveAttachment.TabIndex = 9;
            this.btnRemoveAttachment.Text = "Xóa files đính kèm";
            this.btnRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 16;
            this.lstAttachments.Location = new System.Drawing.Point(456, 125);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(120, 84);
            this.lstAttachments.TabIndex = 8;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(594, 105);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(98, 49);
            this.btnAttach.TabIndex = 7;
            this.btnAttach.Text = "Đính kèm files";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnShowDraft
            // 
            this.btnShowDraft.Location = new System.Drawing.Point(456, 278);
            this.btnShowDraft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowDraft.Name = "btnShowDraft";
            this.btnShowDraft.Size = new System.Drawing.Size(91, 46);
            this.btnShowDraft.TabIndex = 6;
            this.btnShowDraft.Text = "Hiển thị bản nháp";
            this.btnShowDraft.UseVisualStyleBackColor = true;
            this.btnShowDraft.Click += new System.EventHandler(this.btnShowDraft_Click_3);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(456, 215);
            this.btnSaveDraft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(91, 49);
            this.btnSaveDraft.TabIndex = 5;
            this.btnSaveDraft.Text = "Lưu bản nháp";
            this.btnSaveDraft.UseVisualStyleBackColor = true;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click_3);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(594, 215);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 49);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Xóa hết nội dung";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbEmailContent
            // 
            this.rtbEmailContent.Location = new System.Drawing.Point(84, 125);
            this.rtbEmailContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbEmailContent.Name = "rtbEmailContent";
            this.rtbEmailContent.Size = new System.Drawing.Size(349, 179);
            this.rtbEmailContent.TabIndex = 3;
            this.rtbEmailContent.Text = "";
            this.rtbEmailContent.TextChanged += new System.EventHandler(this.rtbEmailContent_TextChanged);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(594, 278);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(98, 46);
            this.btnSendEmail.TabIndex = 2;
            this.btnSendEmail.Text = "Gửi Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nội dung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiêu đề";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Người nhận";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(84, 68);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(403, 22);
            this.txtSubject.TabIndex = 0;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(84, 30);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(403, 22);
            this.txtTo.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.tabControlEmail);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControlEmail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEmail;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstEmails;
        private System.Windows.Forms.Button btnReadEmails;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbEmailContent;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button btnShowDraft;
        private EventHandler btnShowDraft_Click_1;
        private EventHandler btnSaveDraft_Click_2;
        private System.Windows.Forms.Button btnDeleteEmail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private EventHandler txtSearch_TextChanged;
        private EventHandler btnSaveDraft_Click;
        private EventHandler btnShowDraft_Click;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Button btnRemoveAttachment;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnForward;
    }
}

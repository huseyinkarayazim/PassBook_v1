
namespace PassBook
{
    partial class PassBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassBook));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.app_name_textbox = new System.Windows.Forms.TextBox();
            this.app_link_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.mail_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.note_textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.open_view = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "UYGULAMA ADI :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "UYGULAMA ADRESİ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "KULLANICI ADI :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ŞİFRE :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "E MAIL :";
            // 
            // app_name_textbox
            // 
            this.app_name_textbox.Location = new System.Drawing.Point(169, 30);
            this.app_name_textbox.Name = "app_name_textbox";
            this.app_name_textbox.Size = new System.Drawing.Size(188, 20);
            this.app_name_textbox.TabIndex = 0;
            // 
            // app_link_textbox
            // 
            this.app_link_textbox.Location = new System.Drawing.Point(169, 83);
            this.app_link_textbox.Name = "app_link_textbox";
            this.app_link_textbox.Size = new System.Drawing.Size(188, 20);
            this.app_link_textbox.TabIndex = 1;
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(169, 134);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(188, 20);
            this.username_textbox.TabIndex = 2;
            // 
            // mail_textbox
            // 
            this.mail_textbox.Location = new System.Drawing.Point(169, 233);
            this.mail_textbox.Name = "mail_textbox";
            this.mail_textbox.Size = new System.Drawing.Size(188, 20);
            this.mail_textbox.TabIndex = 4;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(169, 183);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.PasswordChar = '*';
            this.password_textbox.Size = new System.Drawing.Size(188, 20);
            this.password_textbox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "NOT :";
            // 
            // note_textbox
            // 
            this.note_textbox.Location = new System.Drawing.Point(169, 282);
            this.note_textbox.Multiline = true;
            this.note_textbox.Name = "note_textbox";
            this.note_textbox.Size = new System.Drawing.Size(188, 92);
            this.note_textbox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // open_view
            // 
            this.open_view.Location = new System.Drawing.Point(298, 401);
            this.open_view.Name = "open_view";
            this.open_view.Size = new System.Drawing.Size(59, 23);
            this.open_view.TabIndex = 12;
            this.open_view.Text = "Göster";
            this.open_view.UseVisualStyleBackColor = true;
            this.open_view.Click += new System.EventHandler(this.open_view_Click);
            // 
            // PassBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.open_view);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.note_textbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.mail_textbox);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.app_link_textbox);
            this.Controls.Add(this.app_name_textbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PassBook";
            this.Text = "PassBook";
            this.Load += new System.EventHandler(this.PassBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox app_name_textbox;
        private System.Windows.Forms.TextBox app_link_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.TextBox mail_textbox;
        private System.Windows.Forms.MaskedTextBox password_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox note_textbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button open_view;
    }
}


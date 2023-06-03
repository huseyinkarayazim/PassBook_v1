
namespace PassBook
{
    partial class Verification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verification));
            this.label1 = new System.Windows.Forms.Label();
            this.verifcation_textbox = new System.Windows.Forms.TextBox();
            this.verify_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOĞRULAMA KODUNU GİRİNİZ";
            // 
            // verifcation_textbox
            // 
            this.verifcation_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.verifcation_textbox.Location = new System.Drawing.Point(47, 105);
            this.verifcation_textbox.Name = "verifcation_textbox";
            this.verifcation_textbox.Size = new System.Drawing.Size(570, 47);
            this.verifcation_textbox.TabIndex = 1;
            // 
            // verify_btn
            // 
            this.verify_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.verify_btn.Location = new System.Drawing.Point(47, 182);
            this.verify_btn.Name = "verify_btn";
            this.verify_btn.Size = new System.Drawing.Size(200, 44);
            this.verify_btn.TabIndex = 2;
            this.verify_btn.Text = "DOĞRULA";
            this.verify_btn.UseVisualStyleBackColor = true;
            this.verify_btn.Click += new System.EventHandler(this.verify_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(253, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(364, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "YENİDEN GÖNDER";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Verification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.verify_btn);
            this.Controls.Add(this.verifcation_textbox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Verification";
            this.Text = "Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox verifcation_textbox;
        private System.Windows.Forms.Button verify_btn;
        private System.Windows.Forms.Button button1;
    }
}
using System;
using System.Configuration;
using System.Windows.Forms;
using HK.Security;

namespace PassBook
{
    public partial class PassBook : Form
    {
        public PassBook()
        {
           
            
            InitializeComponent();
            DialogResult = DialogResult.OK;
            var dataprovider = new Data_Provider();
            dataprovider.dbCheck();
        }
        #region Load Action
        private void PassBook_Load(object sender, EventArgs e)
        {
            var dataprovider = new Data_Provider();
            bool hasAccount =dataprovider.HasAcount;
            if (hasAccount == true)
            {
                using (var passwordForm = new Password())
                {
                    if (passwordForm.ShowDialog() == DialogResult.OK)
                    {
                        string enteredUsername = passwordForm.entered_Username;
                        string enteredPassword = passwordForm.entered_Password;
                       
                        if (dataprovider.CheckCredentials(enteredUsername, enteredPassword) == true)
                        {                            
                            this.Show();
                        }
                        else
                        {
                            // Şifre yanlış, uygulamayı kapatın veya hata mesajı gösterin
                            MessageBox.Show("Girdiğiniz Bilgiler Yanlış ! Uygulama kapatılıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        // Şifre girişi iptal edildi, uygulamayı kapatın
                        Application.Exit();
                    }
                }
            }
            else
            {
                using (var signin = new SignIn())
                {
                    if (signin.ShowDialog() == DialogResult.OK)
                    { }
                    }
            }

        }
        #endregion
        private void savebtn_Click(object sender, EventArgs e)
        {
            var dataprovider = new Data_Provider();
            var save = new Save();
            if (app_name_textbox.Text == string.Empty)      { MessageBoxHelper.ShowMessageBoxWar("Uygulama Adı Boş Bırakılamaz.","DİKKAT"); }
            else if (app_link_textbox.Text == string.Empty) { MessageBoxHelper.ShowMessageBoxWar("Uygulama Linki Boş Bırakılamaz.", "DİKKAT"); }
            else if (username_textbox.Text == string.Empty) { MessageBoxHelper.ShowMessageBoxWar("Kullanıcı Adı Boş Bırakılamaz.", "DİKKAT"); }
            else if (password_textbox.Text == string.Empty) { MessageBoxHelper.ShowMessageBoxWar("Şifre  Boş Bırakılamaz.", "DİKKAT"); }
            else if (mail_textbox.Text == string.Empty)     { MessageBoxHelper.ShowMessageBoxWar("Email  Boş Bırakılamaz.", "DİKKAT"); }
            else {
                save.app_name = app_name_textbox.Text;
                save.app_link = app_link_textbox.Text;
                save.username =HK.Security.StringCipher.Encrypt(username_textbox.Text);
                save.pass = HK.Security.StringCipher.Encrypt(password_textbox.Text);
                save.email = mail_textbox.Text;
                save.note = note_textbox.Text;
                dataprovider.dbFiller(save);
                MessageBoxHelper.ShowMessageBoxInfo("Kayıt Başarılı!","Bilgi");
            }
           
            app_name_textbox.Clear();
            app_link_textbox.Clear();
            username_textbox.Clear();
            password_textbox.Clear();
            mail_textbox.Clear();
            note_textbox.Clear();
        }

        private void open_view_Click(object sender, EventArgs e)
        {
            
            using (var view = new ViewForm())
            {
                if (view.ShowDialog() == DialogResult.OK)
                {  }
            }

        }
    }
}

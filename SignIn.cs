
using System;
using System.Windows.Forms;
using MailSender;
namespace PassBook
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;
            
        }
        public string  _code;
        public void Verification()
        {
            var mail = new Mailsender();
            string code = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            Authorization authorization = new Authorization();
            var dataprovider = new Data_Provider();
            if (!string.IsNullOrEmpty(username_textBox.Text) || !string.IsNullOrEmpty(password_textbox.Text) || !string.IsNullOrEmpty(mail_textbox.Text))
            {
                if (dataprovider.CheckCredentials(username_textBox.Text, password_textbox.Text) == true)
                {
                    MessageBox.Show("Girdiğiniz Kullanıcı Adı Ve Şifre Zaten Mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    authorization.Username = username_textBox.Text;
                    authorization.Password = password_textbox.Text;
                    authorization.Mail = mail_textbox.Text;
                    authorization.Status = false;
                    authorization.TempKEY = code;
                    string mes = $"Merhaba :{username_textBox.Text } PASSBOOK uygulamasına üye olduğunuz için teşekkür ederiz.\nHesabınızı doğrulamak için aşağıdaki kodu kullanabilirsiniz.\nDOĞRULAMA KODU : {code}";

                    try
                    {
                        mail.Yandex(mail_textbox.Text, null, "PASSBOOK Doğrulama", mes, "smtp.yandex.com", 587, "notification.stockart@yandex.com", "yjimrsbgiguszcep");

                    }
                    catch (Exception ex)
                    {

                        MessageBoxHelper.ShowMessageBoxError(""+ex,"HATA"); ;
                    }
                    dataprovider.SingIn(authorization);
                    this.Visible = false;
                    while (true)
                    {
                        using (var ver = new Verification())
                        {
                            if (ver.ShowDialog() == DialogResult.OK)
                            { if (ver.isOkey==true) {
                                    using (var program = new PassBook())
                                    {
                                        MessageBoxHelper.ShowMessageBoxInfo("geldi","");
                                        if (program.ShowDialog() == DialogResult.OK) { ver.Close();this.Close(); }
                                    }
                                } }
                          
                        }
                    }

                }
               
            }           

        }

        private void signin_btn_Click(object sender, System.EventArgs e)
        {
            Verification();

        }
    }
}

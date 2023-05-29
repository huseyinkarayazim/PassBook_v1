
using System.Windows.Forms;

namespace PassBook
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;
            
        }

        public void Dub()
        {
            Authorization authorization = new Authorization();
            var dataprovider = new Data_Provider();
            if (dataprovider.CheckCredentials(username_textBox.Text, password_textbox.Text) == true)
            {
                MessageBox.Show("Girdiğiniz Kullanıcı Adı Ve Şifre Zaten Mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                authorization.Username = username_textBox.Text;
                authorization.Password = password_textbox.Text;
                authorization.Mail = mail_textbox.Text;
                dataprovider.SingIn(authorization);
                
                Close();
            }

        }

        private void signin_btn_Click(object sender, System.EventArgs e)
        {
            Dub();

        }
    }
}

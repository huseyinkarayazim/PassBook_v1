using System;
using System.Windows.Forms;


namespace PassBook
{
    public partial class Password : Form
    {
        public string entered_Username { get; private set; }
        public string entered_Password { get; private set; }
        

        public Password()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // TextBox'tan girilen şifreyi alın
            entered_Username = username_textbox.Text;
            entered_Password = password_textbox.Text;

            // Şifreyi kontrol etmek için DialogResult'u OK olarak ayarlayın
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

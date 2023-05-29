using System.Windows.Forms;

namespace PassBook
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
        }

        public void Writer()
        {
            var dataprovider = new Data_Provider();
            var documents=dataprovider.ReadData();
            foreach (var doc in documents) {
                string appName = doc["ApplicationName"].AsString;
                string app_link = doc["ApplicationLink"].AsString;
                string username = HK.Security.StringCipher.Encrypt(doc["Username"].AsString);
                string password = HK.Security.StringCipher.Encrypt(doc["Password"].AsString);
                string mail = doc["Email"].AsString;
                string note = doc["Note"].AsString;
            }
        }
    }
}

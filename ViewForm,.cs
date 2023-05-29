using System.Windows.Forms;

namespace PassBook
{
    public partial class ViewForm : Form
    {
       
        public ViewForm()
        {
            InitializeComponent();
            Writer();
        }

        public void Writer()
        {
           
            var dataprovider = new Data_Provider();
            var documents=dataprovider.ReadData();
            foreach (var doc in documents) {
                string appName = doc["ApplicationName"].AsString;
                string app_link = doc["ApplicationLink"].AsString;
                string username = HK.Security.StringCipher.Decrypt(doc["Username"].AsString);
                string password = HK.Security.StringCipher.Decrypt(doc["Password"].AsString);
                string mail = doc["Email"].AsString;
                string note = doc["Note"].AsString;                
                string[] data = new string[] { appName, username, password, mail, app_link, note };
                ListViewItem item = new ListViewItem(data);
                listView.Items.Add(item);



            }
        }
        private void view_btn_Click(object sender, System.EventArgs e)
        {
            
            if (listView.Items.Count > 0)
            {
                
            }
        }
        private void delete_btn_Click(object sender, System.EventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }
    }
}

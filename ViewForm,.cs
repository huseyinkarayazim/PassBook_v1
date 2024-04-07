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
                string username = Security.Decrypt(doc["Username"].AsString);
                string password = Security.Decrypt(doc["Password"].AsString);
                string mail = doc["Email"].AsString;
                string note = doc["Note"].AsString;                
                string[] data = new string[] { appName, username, password, mail, app_link, note };
                ListViewItem item = new ListViewItem(data);
                listView.Items.Add(item);
            }
        }
        
        private void delete_btn_Click(object sender, System.EventArgs e)
        {
            var dataprovider = new Data_Provider();
            string val;
            
            if (listView.Items.Count > 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    // ListViewItem'in değerlerine eriş
                    val = item.SubItems[0].Text; // İlk sütun değeri
                    dataprovider.delete(val);
                    listView.Items.Remove(listView.SelectedItems[0]);
                    return;
                }
                
            }
        }
    }
}

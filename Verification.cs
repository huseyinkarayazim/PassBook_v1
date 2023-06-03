
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassBook
{
    public partial class Verification : Form
    {
        public string entered_code { get; private set; }
        public bool isOkey = false;
        public Verification()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.MinimizeBox = false;
            DialogResult = DialogResult.OK;
        }
       
        public void VerificationCheck()         
       {
            var link = ConfigurationManager.AppSettings["Link"];
            entered_code = verifcation_textbox.Text;
            string verCode;
            var client = new MongoClient(link); // MongoDB bağlantı adresi
            var database = client.GetDatabase("PB");
            var collection = database.GetCollection<BsonDocument>("Authentication");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (var doc in documents)
            {
                verCode = doc["TempKEY"].ToString();
            
            if (verCode == verifcation_textbox.Text)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("TempKEY", verCode); // Yeni Mednes ID'si bulunuyor.
                var update = Builders<BsonDocument>.Update.Set("Status", true);
                var result = collection.UpdateOneAsync(filter, update);
                var filter2 = Builders<BsonDocument>.Filter.Eq("TempKEY", verCode); // Yeni Mednes ID'si bulunuyor.
                var update2 = Builders<BsonDocument>.Update.Set("TempKEY", BsonNull.Value);
                var result2 = collection.UpdateOneAsync(filter2, update2);
                 isOkey = true;
                }
            else if(verCode != verifcation_textbox.Text)
            {
                MessageBoxHelper.ShowMessageBoxWar("DOĞRULAMA BAŞARISIZ\nYENİDEN KOD ALMAYI DENEYİN", "DİKKAT");
                    isOkey = false;
                }
                else { MessageBoxHelper.ShowMessageBoxWar("BEKLENMEDİK BİR HATA OLUŞTU","DİKKAT"); isOkey = false; }
                
            }
        }
        private void verify_btn_Click(object sender, System.EventArgs e)
        {
            VerificationCheck();
        }
    }
}

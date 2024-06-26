﻿using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using static PassBook.Collections;


namespace PassBook
{
    class Data_Provider
    {
        public static IMongoDatabase  dbConnection()
        {
            var link = ConfigurationManager.AppSettings["Link"];
            var client = new MongoClient(link); // MongoDB bağlantı adresi
            var databaseName = client.GetDatabase("PB");
            if (databaseName != null)
            {
                return databaseName;
            }
            else { return null; }

        }
        public void dbCheck()
        {
            // var link=ConfigurationManager.AppSettings["Link"];
            // var client = new MongoClient(link); // MongoDB bağlantı adresi
            // var databaseName = "PB";
            // var databaseNames = client.ListDatabaseNames().ToList();
            //
            // var test = dbConnection();
            // 
            // foreach (var a in databaseNames)
            // {
            //     if (!a.Contains(databaseName))
            //     {
            //         client.GetDatabase(databaseName);
            //     }
            // }
            
            foreach (CollectionNames collectionName in System.Enum.GetValues(typeof(CollectionNames)))
            {
                var database = dbConnection();
                var collectionNameString = collectionName.ToString();
                var collectionExists = database.ListCollectionNames().ToList().Contains(collectionNameString);
            
                if (!collectionExists)
                {
                    database.CreateCollection(collectionNameString);
                }
            }
            
            
        }
        public void delete(string deleted) {
           // var link = ConfigurationManager.AppSettings["Link"];
           // var client = new MongoClient(link);
           // var database = client.GetDatabase("PB");
            var database = dbConnection();
            var collection = database.GetCollection<BsonDocument>("Data");
            var filter = Builders<BsonDocument>.Filter.Eq("ApplicationName",deleted);
            var result = collection.DeleteOne(filter);
            MessageBoxHelper.ShowMessageBoxInfo("Kayıt Veri Tabanından Silindi.","BİLGİ");        }
        public void dbFiller(Save save)
        {
            // var link = ConfigurationManager.AppSettings["Link"];
            // var client = new MongoClient(link);
            // var database = client.GetDatabase("PB");
            var database = dbConnection();
            var collection = database.GetCollection<BsonDocument>("Data");
            var document = new BsonDocument
            {
                    { "ApplicationName", save.app_name!= null ? save.app_name.ToString() : string.Empty },                   
                    { "Username",save.username != null ? save.username.ToString() : string.Empty },
                    { "Password", save.pass != null ? save.pass.ToString() : string.Empty },
                    { "Email",save.email != null ? save.email.ToString() : string.Empty },
                    { "ApplicationLink", save.app_link != null ? save.app_link.ToString() : string.Empty },
                    { "Note", save.note != null ? save.note.ToString() : string.Empty }
             };
           
            collection.InsertOne(document);

        }
        public List<BsonDocument> ReadData()
        {
            // var link = ConfigurationManager.AppSettings["Link"];
            // var client = new MongoClient(link);
            // var database = client.GetDatabase("PB");
            var database = dbConnection();
            var collection = database.GetCollection<BsonDocument>("Data");
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }
        public void SingIn(Authorization authorization) 
        {
            if (authorization.Username != null && authorization.Username.ToString() != string.Empty || authorization.Password != null && authorization.Password.ToString() != string.Empty || authorization.Mail != null && authorization.Mail.ToString() != string.Empty)
            {
                // var link = ConfigurationManager.AppSettings["Link"];  
                // var client = new MongoClient(link);
                // var database = client.GetDatabase("PB");
                var database = dbConnection();
                var collection = database.GetCollection<BsonDocument>("Authentication");
                var document = new BsonDocument
                {

                    { "Username",  Security.Encrypt(authorization.Username) },
                    { "Password", Security.Encrypt(authorization.Password) },
                    { "Email", authorization.Mail.ToString() },
                    { "Status",authorization.Status },
                    { "TempKEY",authorization.TempKEY  }

                };
                try
                {
                    collection.InsertOne(document);
                  
                }
                catch (System.Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError("" + ex, "Hata");
                }
               
            }
            else { MessageBoxHelper.ShowMessageBoxError("Hiçbir Alan Boş Bırakılamaz!", "Hata"); }
        }
        public void Login(Authorization Authorization)
        {
            // var link = ConfigurationManager.AppSettings["Link"];
            // var client = new MongoClient(link);
            // var database = client.GetDatabase("PB");
            var database = dbConnection();
            var collection = database.GetCollection<BsonDocument>("Authentication");
            var documents = collection.Find(new BsonDocument()).ToList();  
        }
        public bool HasAcount
        {
           
            get
            {
                //var link = ConfigurationManager.AppSettings["Link"];
                //var client = new MongoClient(link); // MongoDB bağlantı adresi
                //var database = client.GetDatabase("PB");
                var database = dbConnection();
                var collection = database.GetCollection<BsonDocument>("Authentication");
                var documents = collection.Find(new BsonDocument()).ToList();
                
                    foreach (var doc in documents)
                    {
                     var _user = doc["Username"].AsString;
                     var _pass = doc["Password"].AsString;
                     var _status = doc["Status"];
                   
                    if (_status==true||_user != string.Empty || _user != null && _pass != string.Empty || _pass != null) { return true; }
                    }
                
                 return false; 
            }
        }
        public bool CheckCredentials(string username, string password)
        {
            //var link = ConfigurationManager.AppSettings["Link"];           
            //var client = new MongoClient(link);
            //var database = client.GetDatabase("PB");
            var database = dbConnection();
            var collection = database.GetCollection<BsonDocument>("Authentication");           
            var filter = Builders<BsonDocument>.Filter.Eq("Username", Security.Encrypt(username)) & Builders<BsonDocument>.Filter.Eq("Password", Security.Encrypt(password));
            var count = collection.CountDocuments(filter);
            return count > 0;
        }
    }
}

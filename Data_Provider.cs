﻿using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using static PassBook.Collections;


namespace PassBook
{
    class Data_Provider
    {
        
        Authorization authorization;

        public void dbCheck()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // MongoDB bağlantı adresi
            var databaseName = "PB"; // Veritabanı adı
            var databaseNames = client.ListDatabaseNames().ToList();
            

            foreach (var a in databaseNames)
            {
                if (!a.Contains(databaseName))
                {
                    client.GetDatabase(databaseName);
                }
            }
            foreach (CollectionNames collectionName in System.Enum.GetValues(typeof(CollectionNames)))
            {
                var db = client.GetDatabase(databaseName); // Veritabanı adı
                var collectionNameString = collectionName.ToString();
                var collectionExists = db.ListCollectionNames().ToList().Contains(collectionNameString);
            
                if (!collectionExists)
                {
                    db.CreateCollection(collectionNameString);
                }
            }
            
            
        }

        public void dbFiller(Save save)
        {
           
            var client = new MongoClient("mongodb://localhost:27017"); // MongoDB bağlantı adresi            
            var database = client.GetDatabase("PB");
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
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("PB");
            var collection = database.GetCollection<BsonDocument>("Data");
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }
        public void SingIn(Authorization authorization) 
        {
            if (authorization.Username != null && authorization.Username.ToString() != string.Empty || authorization.Password != null && authorization.Password.ToString() != string.Empty || authorization.Mail != null && authorization.Mail.ToString() != string.Empty)
            {
                string crypted_user = HK.Security.StringCipher.Encrypt(authorization.Username);
                string crypted_pass = HK.Security.StringCipher.Encrypt(authorization.Username);
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("PB");
                var collection = database.GetCollection<BsonDocument>("Authentication");
                var document = new BsonDocument
                {

                    { "Username",  HK.Security.StringCipher.Encrypt(authorization.Username) },   
                    { "Password", HK.Security.StringCipher.Encrypt(authorization.Password) },
                    { "Email", authorization.Mail.ToString() }
                };
                try
                {
                    collection.InsertOne(document);
                    MessageBoxHelper.ShowMessageBoxInfo("KAYIT BAŞARILI","Bilgi");
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
            
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("PB");
            var collection = database.GetCollection<BsonDocument>("Authentication");
            var documents = collection.Find(new BsonDocument()).ToList();  
        }

        public bool HasAcount
        {
           
            get
            {
                var client = new MongoClient("mongodb://localhost:27017"); // MongoDB bağlantı adresi
                var database = client.GetDatabase("PB");
                var collection = database.GetCollection<BsonDocument>("Authentication");
                var documents = collection.Find(new BsonDocument()).ToList();
                
                    foreach (var doc in documents)
                    {
                     var _user = doc["Username"].AsString;
                     var _pass = doc["Password"].AsString;
                   
                    if (_user != string.Empty || _user != null && _pass != string.Empty || _pass != null) { return true; }
                    }
                
                 return false; 
            }
        }
        public bool CheckCredentials(string username, string password)
        {
            string crypted_user = HK.Security.StringCipher.Encrypt(username);
            string crypted_pass = HK.Security.StringCipher.Encrypt(password);
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("PB");
            var collection = database.GetCollection<BsonDocument>("Authentication");           
            var filter = Builders<BsonDocument>.Filter.Eq("Username", crypted_user) & Builders<BsonDocument>.Filter.Eq("Password", crypted_pass);
            var count = collection.CountDocuments(filter);
            return count > 0;
        }
    }
}

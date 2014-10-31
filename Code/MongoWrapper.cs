using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using xceedAssignment.Models;

namespace xceedAssignment.Code
{
    public class MongoWrapper
    {

        public const string MongoConnectionString = "mongodb://localhost";

        public MongoDatabase database;


        public MongoWrapper()
        {
            this.connect();
        }


        public void insertDocument(TweetStats stat)
        {
            var collection = database.GetCollection<TweetStats>("tweets");

            collection.Insert(stat);
        }


        public List<TweetStats> getAllDocuments()
        {
            try
            {
                var collection = database.GetCollection<TweetStats>("tweets");

               

                return collection.FindAll().ToList();

            }catch(Exception s)
            {
                Console.WriteLine(s.Message);
                return null;
            }
        }

        public void connect()
        {
            try
            {

                var mongo = new MongoClient(MongoConnectionString);

                var server = mongo.GetServer();

                //Access the database in MongoDB

                database = server.GetDatabase("xceed");

                

            }catch(Exception s)
            {
                Console.WriteLine(s.Message);

            }
        }
    }
}
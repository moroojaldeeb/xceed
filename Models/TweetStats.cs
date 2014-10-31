using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;

namespace xceedAssignment.Models
{
    public class TweetStats
    {

        public ObjectId _id { get; set; }

        public TweetStatus Status { get; set; }

        public int Retweet_Count { get; set; }

        public int Followers_Count { get; set; }

        public int Friends_Count { get; set; }


        public override string ToString()
        {
            return String.Format("RetweetCount : {0}", Retweet_Count);
        }


    }
}
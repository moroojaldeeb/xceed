using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TweetSharp;
using xceedAssignment.Code;
using xceedAssignment.Models;

namespace xceedAssignment.Controllers
{
    public class TweetsController : ApiController
    {
        // GET api/tweets
        public SearchResult Get()
        {
            try
            
            {

                
               
                var Mongo = new MongoWrapper();

                List<TweetStats> results = Mongo.getAllDocuments();

                //Get top Retweeted
                var topRetweeted = results.OrderByDescending(tweet => tweet.Retweet_Count).Take(5).Select(tweet=>tweet.Status);

                //Get top Followed
                var topFollowed = results.OrderByDescending(tweet => tweet.Followers_Count).Take(5).Select(tweet => tweet.Status);

                //Get Top Mentioned
                //var topMentioned = results.OrderByDescending(tweet => tweet.Friends_Count).Take(5).Select(tweet => tweet.Status);
                var topMentioned = TwitterWrapper.GetTopMentioned(results.ToList());
                topMentioned = topMentioned.OrderByDescending(top => top.Count).Take(5).ToList();


                return new SearchResult() {  NumberOfTweets = results.Count() , TopFollowed = topFollowed.ToList(),
                 TopRetweeted = topRetweeted.ToList() , TopMentioned = topMentioned};
                

               

            }catch(Exception s)
            {
                Console.WriteLine(s.Message);

                return null;
            }
        }




        // GET api/tweets/5
        [HttpGet]
        [Route("api/tweets/{keywords}")]
        public SearchResult GetTweets(string keywords)
        {
            String[] keywrds = keywords.Split();

            List<TweetStats> results = new List<TweetStats>();


            foreach(String word in keywrds)
            {
                results.AddRange(TwitterWrapper.getTweets(word));
            }


            //Top Retweeted 
            var topRetweeted = results.OrderByDescending(tweet => tweet.Retweet_Count).Take(5).Select(tweet=>tweet.Status);

            //Top Followed
            var topFollowed = results.OrderByDescending(tweet => tweet.Status.user.FollowersCount).Take(5).Select(tweet => tweet.Status);

            //Top Mentioned 
           // var topMentioned = results.OrderByDescending(tweet => tweet.Status.user.FriendsCount).Take(5).Select(tweet => tweet.Status);
            var topMentioned = TwitterWrapper.GetTopMentioned(results.ToList());
            topMentioned = topMentioned.OrderByDescending(top => top.Count).Take(5).ToList();

            return new SearchResult() { NumberOfTweets = results.Count() , TopFollowed = topFollowed.ToList(),
             TopMentioned = topMentioned, TopRetweeted = topRetweeted.ToList()};

        }

        
    }
}

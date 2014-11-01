using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;
using xceedAssignment.Code;

namespace xceedAssignment.Models
{
    public class SearchResult
    {

        public int NumberOfTweets { get; set; }
        public List<TweetStatus> TopRetweeted { get; set; }
        public List<TweetStatus> TopFollowed { get; set; }
        public List<TopMentioned> TopMentioned { get; set; }

    }
}
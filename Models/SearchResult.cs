using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;

namespace xceedAssignment.Models
{
    public class SearchResult
    {

        public int NumberOfTweets { get; set; }
        public List<TweetStatus> TopRetweeted { get; set; }
        public List<TweetStatus> TopFollowed { get; set; }
        public List<TweetStatus> TopMentioned { get; set; }

    }
}
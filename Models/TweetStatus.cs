using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xceedAssignment.Models
{
    public class TweetStatus
    {
       
        public virtual DateTime CreatedDate { get; set; }
        public virtual string IdStr { get; set; }
        public virtual string InReplyToScreenName { get; set; }
        public virtual long? InReplyToStatusId { get; set; }
        public virtual int? InReplyToUserId { get; set; }
        public virtual bool IsFavorited { get; set; }
        public virtual bool? IsPossiblySensitive { get; set; }

        public virtual string Source { get; set; }
        public virtual string Text { get; set; }
        public virtual string TextAsHtml { get; set; }
        public virtual string TextDecoded { get; set; }

        public int RetweetCount { get; set; }

        public TweetUser user { get; set; }

    }
}
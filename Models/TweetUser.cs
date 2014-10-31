using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xceedAssignment.Models
{
    public class TweetUser
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual string Description { get; set; }
        public virtual int FavouritesCount { get; set; }
        public virtual int FollowersCount { get; set; }
        public virtual bool? FollowRequestSent { get; set; }
        public virtual int FriendsCount { get; set; }
        public virtual string Language { get; set; }
        public virtual int ListedCount { get; set; }
        public virtual string Location { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProfileBackgroundColor { get; set; }
        public virtual string ProfileBackgroundImageUrl { get; set; }
        public virtual string ProfileBackgroundImageUrlHttps { get; set; }
        public virtual string ProfileImageUrl { get; set; }
        public virtual string ProfileImageUrlHttps { get; set; }
        public virtual string ProfileLinkColor { get; set; }
        public virtual string ProfileSidebarBorderColor { get; set; }
        public virtual string ProfileSidebarFillColor { get; set; }
        public virtual string ProfileTextColor { get; set; }
        public virtual string RawSource { get; set; }
        public virtual string ScreenName { get; set; }
        public virtual int StatusesCount { get; set; }
        public virtual string TimeZone { get; set; }
        public virtual string Url { get; set; }
        public virtual string UtcOffset { get; set; }
    }
}

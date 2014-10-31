using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;
using xceedAssignment.Models;
namespace xceedAssignment.Code
{
    public class TwitterWrapper
    {
        public const string ACCESS_TOKEN = "1315465526-bbgGsFE0PQoDY60dM8IsiJBH7TwfuNNynxNjI2G";
        public const string TOKEN_SECRET = "uUgIWiM1NSkpLd824UoCciF7TzP4ypCRJJjbNguIFodzN";
        public static List<TweetStats> getTweets(string keyword)
        {
            try
            {
                List<TweetStats> stats = new List<TweetStats>();

                
                var service = new TwitterService(TwitterCredentials.CONSUMER_KEY, TwitterCredentials.CONSUMER_SECRET);
                //OAuthAccessToken token = TwitterCredentials.Authenticate();

                //if (token == null) throw new Exception("There was a problem Authenticating with Twitter OAuth");

                service.AuthenticateWith(ACCESS_TOKEN, TOKEN_SECRET);

                var options = new SearchOptions();
                options.Q = keyword;
                options.Lang = "en";
                options.Resulttype = TwitterSearchResultType.Mixed;

                TwitterSearchResult result =  service.Search(options);


                //Save the tweets in mongo

                //Create a mongo Wrapper around mongo database driver
                var mongo = new MongoWrapper();

                foreach(TwitterStatus status in result.Statuses)
                {
                    //Prepare the tweet Statistics Object
                    var stat = new TweetStats()
                    {
                        Followers_Count = status.User.FollowersCount,
                        Friends_Count = status.User.FriendsCount,
                        Retweet_Count = status.RetweetCount,
                        Status = new TweetStatus()
                        {
                            CreatedDate = status.CreatedDate,
                            IdStr = status.IdStr,
                            InReplyToScreenName = status.InReplyToScreenName,
                            InReplyToStatusId = status.InReplyToStatusId,
                            InReplyToUserId = status.InReplyToUserId,
                            IsFavorited = status.IsFavorited,
                            IsPossiblySensitive = status.IsPossiblySensitive,
                            Source = status.Source,
                            Text = status.Text,
                            TextAsHtml = status.TextAsHtml,
                            TextDecoded = status.TextDecoded,
                            user = new TweetUser() { 
                             CreatedDate = status.User.CreatedDate,
                              Description = status.User.Description,
                               FavouritesCount = status.User.FavouritesCount,
                                FollowersCount = status.User.FollowersCount,
                                 FollowRequestSent= status.User.FollowRequestSent,
                                  FriendsCount = status.User.FriendsCount,
                                   Language = status.User.Language,
                                    ListedCount = status.User.ListedCount,
                                     Location = status.User.Location,
                                      Name = status.User.Name,
                                       ProfileBackgroundColor = status.User.ProfileBackgroundColor,
                                        ProfileBackgroundImageUrl = status.User.ProfileBackgroundImageUrl,
                                         ProfileBackgroundImageUrlHttps = status.User.ProfileBackgroundImageUrlHttps,
                                          ProfileImageUrl = status.User.ProfileImageUrl,
                                           ProfileImageUrlHttps = status.User.ProfileImageUrlHttps,
                                            ProfileLinkColor = status.User.ProfileLinkColor,
                                             ProfileSidebarBorderColor = status.User.ProfileSidebarBorderColor,
                                              ProfileSidebarFillColor = status.User.ProfileSidebarFillColor,
                                               ProfileTextColor = status.User.ProfileTextColor,
                                                RawSource = status.User.RawSource,
                                                 ScreenName = status.User.ScreenName,
                                                   StatusesCount = status.User.StatusesCount,
                                                    TimeZone = status.User.TimeZone,
                                                     Url = status.User.Url,
                                                      UtcOffset = status.User.UtcOffset
                            
                            }
                        }
                    };

                     //insert that document into mongo db
                    stats.Add(stat);
                     mongo.insertDocument(stat);
                }






                return stats;



                

            }catch(Exception s)
            {
                Console.WriteLine(s.Message);
                return null;
            }
        }
    }
}
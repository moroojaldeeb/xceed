using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace xceedAssignment.Code
{
    public static class StringExtensions
    {


        public const string TwitterUserNamesRegex = "(?<=^|(?<=[^a-zA-Z0-9-_\\.]))@([A-Za-z]+[A-Za-z0-9]+)";

        public static List<string> getTwitterUserNames(this string Text)
        {

            List<string> matches = new List<string>();

            MatchCollection collection = Regex.Matches(Text, TwitterUserNamesRegex);

            foreach(Match m in collection)
            {
                matches.Add(m.Value);
            }


            return matches;

        }
    }
}
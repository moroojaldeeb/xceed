using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xceedAssignment.Code
{
    public class TopMentioned
    {
        public string UserName { get; set; }

        public int Count { get; set; }


        public bool contains(string username)
        {
            if (this.UserName.ToLowerInvariant() == username.ToLowerInvariant())
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.UserName.GetHashCode();
        }

        public override string ToString()
        {
            return this.UserName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if(obj.GetType() == this.GetType())
            {
                return ((obj as TopMentioned).contains(this.UserName));
            }

            return false;

        }
    }
}

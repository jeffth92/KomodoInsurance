using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer
{   
    public class Developer
    {
        public string IndividualName { get; set; }
        public int UniqueID { get; set; }
        public bool PluralsightLiscence { get; set; }
        public Developer() { }

        public Developer(string individualName, int uniqueID, bool pluralsightLiscence)
        {
            IndividualName = individualName;
            UniqueID = uniqueID;
            PluralsightLiscence = pluralsightLiscence;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer
{
    public class DeveloperRepository
    {
        private List<Developer> _ListOfDeveloper = new List<Developer>();
        //create
        public void AddDeveloperToList(Developer dev)
        {
            _ListOfDeveloper.Add(dev);
        }
        //read
        public List<Developer> GetDeveloperList()
        {
            return _ListOfDeveloper;
        }
        //update
        public bool UpdateDeveloper(int originalID, Developer newDev)
        {
            //find dev
            Developer oldDev = GetDeveloperByID(originalID);
            //update dev
            if(oldDev != null)
            {
                oldDev.IndividualName = newDev.IndividualName;
                oldDev.UniqueID = newDev.UniqueID;
                oldDev.PluralsightLiscence = newDev.PluralsightLiscence;
                return true;
            }
            else
            {
                return false;
            }

        }
        //delete
        public bool RemoveDeveloperFromList(int uniqueID)
        {
            Developer dev = GetDeveloperByID(uniqueID);

            if (dev == null)
            {
                return false;
            }

            int initialCount = _ListOfDeveloper.Count;
            _ListOfDeveloper.Remove(dev);

            if(initialCount > _ListOfDeveloper.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //seeker
        public Developer GetDeveloperByID(int uniqueID)
        {
            foreach(Developer dev in _ListOfDeveloper)
            {
                if(dev.UniqueID == uniqueID)
                {
                    return dev;
                }
            }
            return null;
        }
    }
}

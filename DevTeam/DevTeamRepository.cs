using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DevTeamRepository
    {
        private List<DevTeam> _ListOfDevTeam = new List<DevTeam>();
        //create
        public void AddTeamToList(DevTeam team)
        {
            _ListOfDevTeam.Add(team);
        }
        //read
        public List<DevTeam> GetDevTeamList()
        {
            return _ListOfDevTeam;
        }
        //update
        public bool UpdateDevteam(int originalTeamID, DevTeam newTeam)
        {
            //find team
            DevTeam oldTeam = GetDevTeamByID(originalTeamID);
            //update team
            if (oldTeam != null)
            {
                oldTeam.Members = newTeam.Members;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamID = newTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool RemoveTeamFromList(int teamID)
        {
            DevTeam team = GetDevTeamByID(teamID);

            if (team == null)
            {
                return false;
            }

            int initialCount = _ListOfDevTeam.Count;
            _ListOfDevTeam.Remove(team);

            if (initialCount > _ListOfDevTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //seeker
        public DevTeam GetDevTeamByID(int teamID)
        {
            foreach (DevTeam team in _ListOfDevTeam)
            {
                if (team.TeamID == teamID)
                {
                    return team;
                }
            }
            return null;
        }
        public bool AddDevToTeam(int originalTeamID, Developer.Developer newTeam)
        {
            //find team
            DevTeam oldTeam = GetDevTeamByID(originalTeamID);
            //update team
            if (oldTeam != null)
            {
                oldTeam.Members.Add(newTeam);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

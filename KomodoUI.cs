using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoUserInterface
{
     class KomodoUI //comment only present to tecnically count as a change in file
     {
        private Developer.DeveloperRepository _DeveloperRepo = new Developer.DeveloperRepository();
        private DevTeam.DevTeamRepository _DevTeamRepo = new DevTeam.DevTeamRepository();
        public void Run()
        {
            Menu();
        }
        //Menu
        private void Menu()
        {
            int menutype = 1;
            bool Running = true;
            while (Running)
            {
                switch (menutype)
                {
                    case 1:
                        {
                            Console.WriteLine("---Select an option:\n" +
                          "1. Manage Individual Developers\n" +
                          "2. Manage Developer Teams\n" +
                          "3. Exit Application");
                            //input
                            string menuSelect = Console.ReadLine();
                            //eval/act
                            switch (menuSelect)
                            {
                                case "1":
                                    menutype = 2;
                                    break;
                                case "2":
                                    menutype = 3;
                                    break;
                                case "3":
                                    Console.WriteLine("Closing Software");
                                    Running = false;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid number.");
                                    break;
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("---Select an option:\n" +
                          "1. Enter New Developers\n" +
                          "2. List Current Developers\n" +
                          "3. ---Return to Main Menu");
                            //input
                            string devMenuSelect = Console.ReadLine();
                            //eval/act
                            switch (devMenuSelect)
                            {
                                case "1": CreateNewDeveloper();
                                    break;
                                case "2": DisplayAllDevelopers();
                                    break;
                                case "3":
                                    menutype = 1;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid number.");
                                    break;
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("---Select an option:\n" +
                              "1. Enter New DevTeams\n" +
                              "2. Add members to DevTeams\n" +
                              "3. List Current DevTeams\n" +
                              "4. -Return to Menu");
                            //input
                            string teamMenuSelect = Console.ReadLine();
                            //eval/act
                            switch (teamMenuSelect)
                            {
                                case "1": CreateNewDevteam();
                                    break;
                                case "2": AddTeamMembers();
                                    break;
                                case "3": DisplayAllDevTeams();
                                    break;
                                case "4":
                                    menutype = 1;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid number.");
                                    break;
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    default:
                        Console.WriteLine("please enter a valid number.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer.Developer newDeveloper = new Developer.Developer();
            Console.WriteLine("Enter developer's full name:");
            newDeveloper.IndividualName = Console.ReadLine();
            Console.WriteLine("Assigning Unique ID:");
            var rand = new Random();
            newDeveloper.UniqueID = rand.Next(0,100000);
            Console.WriteLine(newDeveloper.UniqueID.ToString("D8"));
            Console.WriteLine("Does new developer have a Pluralsight liscence? (y/n)");
            string letter = Console.ReadLine().ToLower(); 
            switch (letter)
            {
                case "y":
                        newDeveloper.PluralsightLiscence = true;
                    _DeveloperRepo.AddDeveloperToList(newDeveloper);
                    break;
                case "n":
                        newDeveloper.PluralsightLiscence = false;
                    _DeveloperRepo.AddDeveloperToList(newDeveloper);
                    break;
                default:
                    Console.WriteLine("Entry rejected. Please enter y or n.");
                    break;       
            }
        }
        private void DisplayAllDevelopers()
        {
            List<Developer.Developer> listOfDevelopers = _DeveloperRepo.GetDeveloperList();
            foreach (Developer.Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.IndividualName}, ID: {developer.UniqueID}, Has Pluralsight Liscence: {developer.PluralsightLiscence}");
            }
        }
        private void CreateNewDevteam()
        {
            Console.Clear();
            DevTeam.DevTeam newTeam = new DevTeam.DevTeam();
            Console.WriteLine("Enter new Team name:");
            newTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Assigning Team ID:");
            var rand = new Random();
            newTeam.TeamID = rand.Next(0, 10000);
            Console.WriteLine(newTeam.TeamID.ToString("D8"));
            Console.WriteLine("Team made, now add members.");
            _DevTeamRepo.AddTeamToList(newTeam);
        }
        private void AddTeamMembers()
        {
            if (_DevTeamRepo.GetDevTeamList().Count != 0)
            {
                Console.WriteLine("Select an existing team by typing the team ID:");
                DisplayAllDevTeamsSearch();
                string input = Console.ReadLine();
                List<DevTeam.DevTeam> listOfDevTeams = _DevTeamRepo.GetDevTeamList();
                string assignment = "";
                foreach (DevTeam.DevTeam devTeam in listOfDevTeams)
                {
                    if (Int32.Parse(input) == devTeam.TeamID)
                    {
                        Console.WriteLine($"Selected team {devTeam.TeamName}.");
                        assignment = input;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid ID.");
                    }
                }
                DisplayAllDevelopers();
                Console.WriteLine("Select an existing developer by typing the Unique ID:");
                string devnum = Console.ReadLine();
                List<Developer.Developer> listOfDeveloper = _DeveloperRepo.GetDeveloperList();
                foreach (Developer.Developer developer in listOfDeveloper)
                {
                    if (Int32.Parse(devnum) == developer.UniqueID)
                    {
                        Console.WriteLine($"Selected Developer {developer.IndividualName}.");
                        Developer.Developer dev = developer;
                        _DevTeamRepo.AddDevToTeam(Int32.Parse(assignment), dev);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Teams have been made yet");
            }
        }
        private void DisplayAllDevTeamsSearch()
        { 
            List<DevTeam.DevTeam> listOfDevTeams = _DevTeamRepo.GetDevTeamList();
            foreach (DevTeam.DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team: {devTeam.TeamName}, TeamID: {devTeam.TeamID}");
            }
        }
        private void DisplayAllDevTeams()
        {
            List<DevTeam.DevTeam> listOfDevTeams = _DevTeamRepo.GetDevTeamList();
            foreach (DevTeam.DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team: {devTeam.TeamName}, TeamID: {devTeam.TeamID} Members:");
                foreach(Developer.Developer teammate in devTeam.Members)
                {
                    Console.WriteLine($"---Name: {teammate.IndividualName} ID:{teammate.UniqueID} Pluralsight:{teammate.PluralsightLiscence}---");
                }
            }
        }
    }
}

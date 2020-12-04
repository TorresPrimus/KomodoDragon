using DeveloperRepo;
using DeveloperTeamRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    class ProgramUI
    {
        private DevRepo _contentRepo = new DevRepo();
        private DevTeamRepo _teamRepo = new DevTeamRepo();

        public void Run()
        {
            DefaultDevList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display Options to the User
                Console.WriteLine("Select Menu Option:\n" +
                    "1.  Add Developer\n" +
                    "2.  View all Developers\n" +
                    "3.  View Delevoper by ID\n" +
                    "4.  Update Developer Data\n" +
                    "5.  Remove Developer Data\n" +
                    "6.  Add New Developer Team\n" +
                    "7.  View all Developer Teams\n" +
                    "8.  View Developer Team by ID\n" +
                    "9.  Update Developer Team\n" +
                    "10. Remove Developer Team\n" +
                    "11. Exit\n" +
                    "12. Add Developer to a Team\n" +
                    "13. Remove Developer from Team\n" +
                    "14. List of Developers without Pluralsight");

                //Get the User input
                string input = Console.ReadLine();

                //Evaluate User Input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add Developer
                        AddNewDev();
                        break;
                    case "2":
                        //View all Developers
                        SeeAllDev();
                        break;
                    case "3":
                        //View Developer by ID
                        SeeDevByID();
                        break;
                    case "4":
                        //Update Dev Data
                        UpdateDev();
                        break;
                    case "5":
                        //Remove Dev Data
                        RemoveDev();
                        break;
                    case "6":
                        AddNewTeam();
                        break;
                    case "7":
                        GetDevTeamList();
                        break;
                    case "8":
                        GetDevTeamByID();
                        break;
                    case "9":
                        UpdateTeam();
                        break;
                    case "10":
                        RemoveDevTeam();
                        break;
                    case "11":
                        //Exit
                        Console.WriteLine("Have a wonderful day!");
                        keepRunning = false;
                        break;
                    case "12":
                        AddDevToTeam();
                        break;
                    case "13":
                        RemoveDevFromTeam();
                        break;
                    case "14":
                        GetListofDevNeedingPlural();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Add new DevContent
        private void AddNewDev()
        {
            bool addAnotherDev = true;
            while (addAnotherDev == true)
            {
                Console.Clear();
                DevContent newDev = new DevContent();

                Console.WriteLine("What is the First and Last name of the developer:");
                newDev.FullName = Console.ReadLine();

                Console.WriteLine("What is the developers Identification Number:");
                string identAsInt = Console.ReadLine();
                newDev.IdentificationNumber = int.Parse(identAsInt);

                Console.WriteLine("Does this developer have Pluralsight access: (yes/no)");
                string yesNo = Console.ReadLine().Trim().ToLower();
                if (yesNo == "yes")
                {
                    newDev.AccessPlural = true;
                }
                else if (yesNo == "no")
                {
                    newDev.AccessPlural = false;
                }
                else
                {
                    Console.WriteLine("Incorrect value entered, Pluralsight defaulted to NO. If this is incorrect then please update developer data.");
                    newDev.AccessPlural = false;
                }

                _contentRepo.AddDevToList(newDev);

                Console.WriteLine("\nWould you like to add another user? (yes/no)");
                string addMoreDev = Console.ReadLine().Trim().ToLower();
                if (addMoreDev == "yes")
                {
                    addAnotherDev = true;
                }
                else
                {
                    addAnotherDev = false;
                }
            }
        }
        private void AddNewTeam()
        {
            Console.Clear();
            DevTeamContent newDevTeam = new DevTeamContent();

            Console.WriteLine("What is the developer Team name:");
            newDevTeam.TeamName = Console.ReadLine();

            Console.WriteLine("What is the developer Teams Identification Number:");
            string teamIdentAsInt = Console.ReadLine();
            newDevTeam.TeamID = int.Parse(teamIdentAsInt);

            _teamRepo.AddNewTeam(newDevTeam);
        }
        private void AddDevToTeam()
        {
            SeeAllDev();

            Console.WriteLine("\nEnter ID of developer you would like to add to Team:");
            string identAsInt = Console.ReadLine();
            int devID = Convert.ToInt32(identAsInt);
            DevContent pulledID = _contentRepo.GetDevContentByID(devID);

            GetDevTeamList();

            Console.WriteLine("\nWhat is the ID of the team you would like to add to:");
            string teamIdentAsInt = Console.ReadLine();
            int devTeamID = Convert.ToInt32(teamIdentAsInt);
            DevTeamContent pulledTeamID = _teamRepo.GetDevTeamByID(devTeamID);

            //add pulledID to pulledTeamID??????

            pulledTeamID.ListOfDevs.Add(pulledID);

            //COME BACK LATER
            //bool wasAdded =  _teamRepo.RemoveFromTeam();
            //if (wasAdded)
            //{
            //    Console.WriteLine("Developer successfully added to Team.");
            //}
            //else
            //{
            //    Console.WriteLine("Error... Developer could not be added.");
            //}

        }

        private void RemoveDevFromTeam()
        {
            SeeAllDev();

            Console.WriteLine("\nEnter ID of developer you would like to add to Team:");
            string identAsInt = Console.ReadLine();
            int devID = Convert.ToInt32(identAsInt);
            DevContent pulledID = _contentRepo.GetDevContentByID(devID);

            GetDevTeamList();

            Console.WriteLine("\nWhat is the ID of the team you would like to remove from:");
            string teamIdentAsInt = Console.ReadLine();
            int devTeamID = Convert.ToInt32(teamIdentAsInt);
            DevTeamContent pulledTeamID = _teamRepo.GetDevTeamByID(devTeamID);

            pulledTeamID.ListOfDevs.Remove(pulledID);

        }


        //Get Dev List
        private void SeeAllDev()
        {
            Console.Clear();

            List<DevContent> listOfContent = _contentRepo.GetDevList();

            foreach (DevContent content in listOfContent)
            {
                Console.WriteLine($"Developer Name: {content.FullName}\n" +
                    $"Developer ID: {content.IdentificationNumber}");
            }
        }
        private void GetDevTeamList()
        {
            Console.Clear();

            List<DevTeamContent> listOfDevTeams = _teamRepo.GetDevTeamList();

            foreach (DevTeamContent content in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {content.TeamName}\n" +
                    $"Team ID: {content.TeamID}");
            }
        }

        //Get Dev by ID
        private void SeeDevByID()
        {
            Console.Clear();
            //Prompt for ID
            Console.WriteLine("Enter Developer ID number to view:");

            //Find Content by ID
            string value = Console.ReadLine();
            int employeeID = Convert.ToInt32(value);
            DevContent content = _contentRepo.GetDevContentByID(employeeID);

            //Display Content Found if it isn't null
            if (content != null)
            {
                Console.WriteLine($"Developer Name: {content.FullName}\n" +
                    $"Developer ID: {content.IdentificationNumber}\n" +
                    $"Pluralsight Access: {content.AccessPlural}");
            }
            else
            {
                Console.WriteLine("Developer does not exist, if this is an error add Developer.");
            }
        }
        private void GetDevTeamByID()
        {
            Console.Clear();
 
            Console.WriteLine("Enter the Team ID number to view:");

            string value = Console.ReadLine();
            int teamID = Convert.ToInt32(value);
            DevTeamContent team = _teamRepo.GetDevTeamByID(teamID);

            //Display Content Found if it isn't null
            if (team != null)
            {
                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                    $"Team ID: {team.TeamID}\n");
                foreach (var person in team.ListOfDevs)
                {
                    Console.WriteLine($"Members: {person.FullName}");
                }
            }
            else
            {
                Console.WriteLine("Team does not exist, if this is an error add Team.");
            }
        }
        private void GetListofDevNeedingPlural()
        {
            Console.Clear();

            List<DevContent> listOfContent = _contentRepo.GetDevList();

            foreach (DevContent content in listOfContent)
            {
                if (content.AccessPlural == false)
                {
                    Console.WriteLine($"Developer Name & Access: {content.FullName}, {content.AccessPlural}");
                }
            }
            Console.WriteLine("End of List.");
        }

        //Update Dev
        private void UpdateDev()
        {
            SeeAllDev();

            Console.WriteLine("\nEnter ID number of Developer you would like to update:");
            string value = Console.ReadLine();
            int oldDev = Convert.ToInt32(value);

            DevContent newDev = new DevContent();

            Console.WriteLine("What is the First and Last name of the developer:");
            newDev.FullName = Console.ReadLine();

            Console.WriteLine("What is the developers Identification Number:");
            string identAsInt = Console.ReadLine();
            newDev.IdentificationNumber = int.Parse(identAsInt);

            Console.WriteLine("Does this developer have Pluralsight access: (yes/no)");
            string yesNo = Console.ReadLine().Trim().ToLower();
            if (yesNo == "yes")
            {
                newDev.AccessPlural = true;
            }
            else if (yesNo == "no")
            {
                newDev.AccessPlural = false;
            }
            else
            {
                Console.WriteLine("Incorrect value entered, Pluralsight defaulted to NO. If this is incorrect then please update developer data.");
                newDev.AccessPlural = false;
            }

            bool wasUpdated = _contentRepo.UpdateDevContent(oldDev, newDev);
            if(wasUpdated)
            {
                Console.WriteLine("Developer successfuly updated.");
            }
            else
            {
                Console.WriteLine("Error... Could not update Developer.");
            }
        }
        private void UpdateTeam()
        {

        }


        //Remove Dev
        private void RemoveDev()
        {
            SeeAllDev();

            //Get ID they want to delete
            Console.WriteLine("\nEnter ID number of Developer you would like to remove:");
            string value = Console.ReadLine();
            int employeeID = Convert.ToInt32(value);

            //call delete method
            bool wasDeleted = _contentRepo.RemoveDevFromList(employeeID);

            //if content deleted confirm
            if(wasDeleted)
            {
                Console.WriteLine("Developer successfully deleted.");
            }
            else
            {
                Console.WriteLine("Error... Developer could not be deleted.");
            }

            //otherwise state failed
        }
        private void RemoveDevTeam()
        {

        }

        //Seed Method
        private void DefaultDevList()
        {
            DevContent devOne = new DevContent("Richard Torres", 1, false);
            DevContent devTwo = new DevContent("Brittany Beahan", 2, true);
            DevContent devThree = new DevContent("Andrew Owen", 3, false);
            DevContent devFour = new DevContent("Aimee Owen", 4, true);
            DevContent devFive = new DevContent("Lukas Rydberg", 5, false);
            DevContent devSix = new DevContent("Corrie Rydberg", 6, true);

            _contentRepo.AddDevToList(devOne);
            _contentRepo.AddDevToList(devTwo);
            _contentRepo.AddDevToList(devThree);
            _contentRepo.AddDevToList(devFour);
            _contentRepo.AddDevToList(devFive);
            _contentRepo.AddDevToList(devSix);

            List<DevContent> listOfTeamOne = new List<DevContent>();
            listOfTeamOne.Add(devOne);
            listOfTeamOne.Add(devTwo);

            List<DevContent> listOfTeamTwo = new List<DevContent>();
            listOfTeamTwo.Add(devThree);
            listOfTeamTwo.Add(devFour);

            List<DevContent> listOfTeamThree = new List<DevContent>();
            listOfTeamThree.Add(devFive);
            listOfTeamThree.Add(devSix);

            DevTeamContent teamOne = new DevTeamContent("Team Alpha", 1, listOfTeamOne);
            DevTeamContent teamTwo = new DevTeamContent("Team Bravo", 2, listOfTeamTwo);
            DevTeamContent teamThree = new DevTeamContent("Team Charlie", 3, listOfTeamThree);

            _teamRepo.AddNewTeam(teamOne);
            _teamRepo.AddNewTeam(teamTwo);
            _teamRepo.AddNewTeam(teamThree);
        }

    }
}

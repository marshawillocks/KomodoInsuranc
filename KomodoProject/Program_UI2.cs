using Komodo_POCO;
using Komodo_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject
{
    class Program_UI2
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        // Method that starts the application
        public void Run()
        {
            SeeContentList();
            Menu();
        }

        public void Developer()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                // Display options to user
                Console.WriteLine("Select a menu option\n" +
                "1. Add new developer\n" +
                "2. View all developers\n" +
                "3. Update developers\n" +
                "4. Delete developers\n" +
                "5. View developers without Access to Pluralsight\n" +
                "6. Exit");

                // Get user input
                string developerChoice = Console.ReadLine();

                // Evaluate user input
                switch (developerChoice)
                {
                    case "1":
                        // Add new developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // See all developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        // Update developers
                        UpdateExistingDeveloper();
                        break;
                    case "4":
                        //Delete developers
                        DeleteExistingDeveloper();

                        break;
                    case "5":
                        //View developers without Access to PluralSight
                        RequiresPluralsigtAccess();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void DevTeamChoice()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                // Display options to user
                Console.WriteLine("Select a menu option\n" +
                    "1. Add new Team Member\n" +
                    "2. See all Team Member\n" +
                    "3. Update Team Member\n" +
                    "4. Delete Team Member\n" +
                    "5. Exit");

                // Get user input
                string devTeamChoice = Console.ReadLine();

                // Evaluate user input
                switch (devTeamChoice)
                {
                    case "1":
                        CreateNewDevTeam();
                        break;
                    case "2":
                        DisplayAllTeamMembers();
                        break;
                    case "3":
                        UpdateExistingTeamMember();
                        break;
                    case "4":
                        DeletExistingTeamMember();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose which group you would like to work in\n" +
                "1. Developer\n" +
                "2. Developer Team");

            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    Developer();
                    break;

                case "2":
                    DevTeamChoice();
                    break;
            }
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            DeveloperPOCO newDeveloper = new DeveloperPOCO();

            // Name
            Console.WriteLine("Enter name for the developer");
            newDeveloper.Name = Console.ReadLine();

            // Id
            Console.WriteLine("Enter Id");
            newDeveloper.Id = int.Parse(Console.ReadLine());

            //Have PluralSight access
            Console.WriteLine("Does developer have access to Pluralsight? true/false");
            newDeveloper.HavePluralSightAccess = bool.Parse(Console.ReadLine());

            _developerRepo.AddDeveloper(newDeveloper);
        }

        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeamPOCO newDevTeam = new DevTeamPOCO();

            // member Name
            Console.WriteLine("Enter name for the team member");
            newDevTeam.TeamMemberName = Console.ReadLine();

            // team name
            Console.WriteLine("Enter team name");
            newDevTeam.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Enter team ID");
            newDevTeam.TeamId = int.Parse(Console.ReadLine());

            _devTeamRepo.AddDevTeam(newDevTeam);
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<DeveloperPOCO> listOfDevelopers = _developerRepo.GetContentList();

            foreach (DeveloperPOCO developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"ID: {developer.Id}\n" +
                    $"Pluralsight Access: {developer.HavePluralSightAccess}");
            }
        }

        private void DisplayAllTeamMembers()
        {
            List<DevTeamPOCO> listOfMembers = _devTeamRepo.GetDevTeamList();

            foreach (DevTeamPOCO member in listOfMembers)
            {
                Console.WriteLine($"Member Name: {member.TeamMemberName}\n" +
                    $"Team Name: {member.TeamName}\n" +
                    $"Team Id: {member.TeamId}");
            }
        }
        
        private void UpdateExistingDeveloper()
        {
            // Display all content
            DisplayAllDevelopers();

            // As for the Id to update
            Console.WriteLine("Enter ID of person you would like to update:");

            // Get ID
            int id = int.Parse(Console.ReadLine());


            // We will build a new object
            DeveloperPOCO newDeveloper = new DeveloperPOCO();

            // Name
            Console.WriteLine("Enter name for the developer");
            newDeveloper.Name = Console.ReadLine();

            // Id
            Console.WriteLine("Enter Id");
            newDeveloper.Id = int.Parse(Console.ReadLine());

            //Have PluralSight access
            Console.WriteLine("Does developer have access to Pluralsight? true/false");
            newDeveloper.HavePluralSightAccess = bool.Parse(Console.ReadLine());


            // Verify if the update was completed
            bool wasUpdated = _developerRepo.UpdateDeveloper(id, newDeveloper);

            if (wasUpdated == true)
            {
                Console.WriteLine("The developer was updated");
            }
            else
            {
                Console.WriteLine("Developer was not updated");
            }

        }

        private void UpdateExistingTeamMember()
        {
            // Display all content
            DisplayAllTeamMembers();

            // As for the Id to update
            Console.WriteLine("Enter ID of person you would like to update:");

            // Get ID
            int id = int.Parse(Console.ReadLine());


            // We will build a new object            
            DevTeamPOCO newDevTeam = new DevTeamPOCO();

            // member Name
            Console.WriteLine("Enter name for the team member");
            newDevTeam.TeamMemberName = Console.ReadLine();

            // team name
            Console.WriteLine("Enter team name");
            newDevTeam.TeamName = Console.ReadLine();

            //Team ID
            Console.WriteLine("Enter team ID");
            newDevTeam.TeamId = int.Parse(Console.ReadLine());


            // Verify if the update was completed
            bool wasUpdated = _devTeamRepo.UpdateMember(id, newDevTeam);

            if (wasUpdated == true)
            {
                Console.WriteLine("The member was updated");
            }
            else
            {
                Console.WriteLine("Member was not updated");

            }
        }
        private void DeleteExistingDeveloper()
        {
            DisplayAllDevelopers();

            // Get Id for deletion
            Console.WriteLine("Enter id of person you want to remove:");
            int id = int.Parse(Console.ReadLine());

            // Call the delete method
            bool wasDeleted = _developerRepo.RemoveDeveloper(id);

            // Display if deleted or not
            if (wasDeleted == true)
            {
                Console.WriteLine("Person was removed");
            }
            else
            {
                Console.WriteLine("Person was not removed");
            }
        }

        private void DeletExistingTeamMember()
        {
            DisplayAllTeamMembers();

            //Get Id for deletion
            Console.WriteLine("Enter id of Person you want to remove");
            int id = int.Parse(Console.ReadLine());

            // Call the delete method
            bool wasDeleted = _devTeamRepo.RemoveMember(id);

            //Display if deleted or not
            if(wasDeleted == true)
            {
                Console.WriteLine("Person was removed");
            }
            else
            {
                Console.WriteLine("Person was not removed");
            }
        }

        private void RequiresPluralsigtAccess()
        {
            Console.Clear();
            Console.WriteLine("List of people without Pluralsight access:");
            List<DeveloperPOCO> listOfDevelopers = _developerRepo.GetContentList();

            foreach (DeveloperPOCO developer in listOfDevelopers)
            {
                if (developer.HavePluralSightAccess is false)
                {
                    Console.WriteLine(developer.Name);
                }
            }
        }      

        private void SeeContentList()
        {
            DeveloperPOCO person1 = new DeveloperPOCO("Kenny Rogers", 1, false);
            DeveloperPOCO person2 = new DeveloperPOCO("Bob Marley", 2, true);
            DeveloperPOCO person3 = new DeveloperPOCO("Jennifer Hudson", 3, false);
            DeveloperPOCO person4 = new DeveloperPOCO("Kelly Clarkson", 4, true);
            DeveloperPOCO person5 = new DeveloperPOCO("Cat Woman", 5, false);

            _developerRepo.AddDeveloper(person1);
            _developerRepo.AddDeveloper(person2);
            _developerRepo.AddDeveloper(person3);
            _developerRepo.AddDeveloper(person4);
            _developerRepo.AddDeveloper(person5);
        }
    }
}


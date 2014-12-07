using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary;
using HomelandSecurity;

/*          
 *          Project
 * Name: Joao Pedro Santos de Moura
 * Class: CIS 345 - 81883
 * Class time: Monday, Wednesday 3:00 PM - 4:15PM
 * 
 */

namespace Charms
{
    class Charms
    {

        private Flight[] flightRoster;

        //Default constructor, there are no flights at prior
        public Charms()
        {
            flightRoster = null;
        }

        //This method clear the console and print the header with contains the name of the system
        public static void PrintHeader()
        {
            Console.Clear();
            Utilities.WriteCenteredLine("Chandler Air Reporting and Management System\n");
            Utilities.WriteCenteredLine("-- CHARMS --\n\n\n\n");

        }

        //This method print the main menu of th application
        public static void DisplayMenu()
        {
            PrintHeader();
            Utilities.WriteCenteredLine("Main Menu\n\n");
            Console.Write("1 - Display Flight List\n2 - Add New Flight\n3 - Select Flight\n4 - Search by Passenger\n5 - Exit\n\nOption selected: ");
        }

        //This method creates a list that contains all the flights in the 'flightRoster' and each one have a number wich references it for selection pourposes
        private int MakeFlightsList()
        {
            int i;
            if (flightRoster == null) // flightRoster equals 'null' means there are no flights save into 'flightRoster'
            {
                Console.WriteLine("There are no flights so far.");
                return -1;
            }

            else
            {
                Console.WriteLine("Option | Flight Number: Origin --> Destination\n");
                for (i = 0; i < flightRoster.Length; ++i)
                {
                    Console.WriteLine(i + "      | " + flightRoster[i].DisplayInformation());
                }
                return i; // Return the number of options available
            }
        }

        public void DisplayFlightListMenu()
        {
            PrintHeader();
            Utilities.WriteCenteredLine("Flight List\n\n");
            MakeFlightsList();
            Utilities.Pause();
        }

        public void DisplayAddNewFlightMenu()
        {
            int flightNumber;
            string flightOrigin, flightDestination;

            PrintHeader();
            Utilities.WriteCenteredLine("Add New Flight\n\n");
            flightNumber = Utilities.ReadInteger("Enter Flight Number: ");
            flightOrigin = Utilities.ReadString("Enter Flight Origin: ");
            flightDestination = Utilities.ReadString("Enter Flight Destination: ");

            Flight newFlight = new Flight(flightNumber, flightOrigin, flightDestination);
            AddFlight(newFlight);

            Console.Write("\nNew flight has been added.\n\n");
            Utilities.Pause();
        }

        //This method adds a new flight into the flight roster
        private void AddFlight(Flight newFlight)
        {
            if (flightRoster == null) // If does not exists any flight in the flight roster,
            {
                flightRoster = new Flight[1]; // It is created a new room for this flight
                flightRoster[0] = newFlight;
            }

            else
            {
                Flight[] temporaryFlightRoster = new Flight[flightRoster.Length + 1];
                flightRoster.CopyTo(temporaryFlightRoster, 0);
                temporaryFlightRoster[flightRoster.Length] = newFlight; // Adds in the last position of the temporary array
                flightRoster = temporaryFlightRoster; // Flight Roster assumes the temporary array reference
            }
        }

        public void DisplaySelectFlightMenu()
        {
            int i, option;
            PrintHeader();
            Utilities.WriteCenteredLine("Current Flights\n\n");
            i = MakeFlightsList();
            if (i > 0)
            {
                Console.Write("\n\nOption selected: ");
                option = Utilities.ReadInteger(0, i - 1);
                DisplaySelectFlightSubMenu(option);
            }
            else
            {
                Utilities.Pause();
            }
        }

        public void DisplaySelectFlightSubMenu(int flightPosition)
        {
            int option;
            bool repeatMenu = true;
            do
            {
                PrintHeader();
                Utilities.WriteCenteredLine("Flight Menu - Flight " + flightRoster[flightPosition].Number);
                Console.Write("\n\n");
                Utilities.WriteCenteredLine(flightRoster[flightPosition].DisplayInformation());
                Console.Write("\n\n1 - Display Passenger Manifest\n2 - Edit Flight Information\n3 - Add New Passenger to Manifest\n"
                + "4 - Run Passenger Security Check\n5 - Exit to CHARMS\n\nOption selected: ");
                option = Utilities.ReadInteger(1, 5);
                PrintHeader();
                switch (option)
                {
                    case 1:
                        Utilities.WriteCenteredLine("Manifest for Flight " + flightRoster[flightPosition].Number + "\n\n");
                        //get the passengers then print
                        if (flightRoster[flightPosition].Passengers == null)
                        {
                            Console.Write("The are no passengers in this flight.\n");
                        }
                        else
                        {
                            Console.Write("First name\tLast Name\tLoyalty Number\tSecurity Flag\n\n");
                            HomelandSecurity.Passenger[] manifest = flightRoster[flightPosition].Passengers;
                            for (int i = 0; i < manifest.Length; ++i)
                            {
                                Console.Write(PassengerInformation(ref manifest[i]) + "\n");
                            }
                        }
                        break;
                    case 2: // edit information, number, origin and destination
                        Utilities.WriteCenteredLine("Edit Flight Information - Flight " + flightRoster[flightPosition].Number + "\n\n");
                        int newFlightNumber;
                        string newFlightOrigin, newFlightDestination;

                        newFlightNumber = Utilities.ReadInteger("Set the new flight Number: ");
                        newFlightOrigin = Utilities.ReadString("Set the new Origin: ");
                        newFlightDestination = Utilities.ReadString("Set the new Destination: ");

                        flightRoster[flightPosition].Edit(newFlightNumber, newFlightOrigin, newFlightDestination);
                        break;
                    case 3:
                        // add a new passenger manually
                        Utilities.WriteCenteredLine("Add Passenger - Flight " + flightRoster[flightPosition].Number + "\n\n");
                        flightRoster[flightPosition].AddPassenger(true);
                        break;
                    case 4:
                        // run security check
                        Utilities.WriteCenteredLine("TSA Security Check - Flight " + flightRoster[flightPosition].Number + "\n\n");
                        HomelandSecurity.Passenger[] passengersManifest = flightRoster[flightPosition].Passengers;
                        HomelandSecurity.TSA myTsa = new HomelandSecurity.TSA();

                        if(passengersManifest != null) //If there are passengers
                        {
                            for (int j = 0; j < passengersManifest.Length; ++j) // Set the Security flag of all passengers to 'false' before run the security check
                            {
                                passengersManifest[j].SecurityFlag = false;
                            }

                            HomelandSecurity.FlaggedPassenger[] flaggedPassengers = myTsa.RunSecurityCheck(passengersManifest, passengersManifest.Length);

                            if (flaggedPassengers != null) // if there is flagged passengers, then it is necessary to update their information
                            {
                                for (int i = 0; i < flaggedPassengers.Length; ++i)
                                {
                                    for (int j = 0; j < passengersManifest.Length; ++j)
                                    {
                                        if (flaggedPassengers[i].FirstName.CompareTo(passengersManifest[j].FirstName) == 0 &&
                                            flaggedPassengers[i].LastName.CompareTo(passengersManifest[j].LastName) == 0)
                                        {
                                            passengersManifest[j].SecurityFlag = true;
                                        }
                                    }
                                }
                            }
                            Console.Write("Security check has been done!");
                        }
                        else
                        {
                            Console.Write("Impossible to run the security check. There are no passengers in this flight!");
                        }
                        
                        break;
                    case 5:
                        //exit to main menu by doing nothing
                        repeatMenu = false;
                        break;
                }
                Utilities.Pause();
            } while (repeatMenu);
        }

        public void SearchByPassengerMenu()
        {
            int i;// Index for "for" loops
            string passengerFirstName, passengerLastName;
            HomelandSecurity.Passenger passenger = null;

            PrintHeader();
            Utilities.WriteCenteredLine("Search By Passenger\n\n");


            //Search code
            if (flightRoster != null) //If there is a flight
            {
                passengerFirstName = Utilities.ReadString("Enter the passenger's First Name: ");
                passengerLastName = Utilities.ReadString("Enter the passenger's Last Name: ");

                for (i = 0; i < flightRoster.Length; ++i) // For each flight
                {
                    passenger = SearchPassengerByName(flightRoster[i].Passengers, passengerFirstName, passengerLastName); // Search passenger by the name
                    if (passenger != null) break; // If passenger is not null, it means that he/she was found so we do not need to keep searching
                }

                if (passenger != null)  // Passenger founded
                {

                    //Console.Write(PassengerInformation(ref passenger));
                    
                    Console.Write("\nPassenger First Name: {0}\nPassenger Last Name: {1}\nPassenger Loyalty Number: {2}\n", passenger.FirstName, passenger.LastName, passenger.LoyaltyNumber);
                    Console.Write("Passenger flight information: " + flightRoster[i].DisplayInformation() + "\nPassenger Security Flag: ");
                    //Console.Write(passenger.SecurityFlag);
                    
                    if(passenger.SecurityFlag == true) Console.Write("Flagged");
                    else Console.Write("Not Flagged");
                }

                else // Passenger not founded
                {
                    Console.Write("\n\nThe passenger {0} {1} was not found.\n\n", passengerFirstName, passengerLastName);
                }
            }
            else //There is no flights
            {
                Console.Write("\n\nIt is not possible to search for passenger because there is no flights at all.\n\n");
            }

            Utilities.Pause();
        }

        // This method looks for a specific passenger in one passenger manifest's flght
        private HomelandSecurity.Passenger SearchPassengerByName(HomelandSecurity.Passenger[] passengerManifest, string firstName, string lastName)
        {
            HomelandSecurity.Passenger passenger = null;

            for (int i = 0; i < passengerManifest.Length; ++i) // For each passenger in the flight
            {
                if (firstName.CompareTo(passengerManifest[i].FirstName) == 0 && lastName.CompareTo(passengerManifest[i].LastName) == 0) //If both fist name and last name matches
                {
                    passenger = passengerManifest[i]; // The passenger was found
                    break; //Breaks the 'for' loop
                }
            }

            return passenger;
        }

        private string PassengerInformation(ref HomelandSecurity.Passenger passenger)
        {
            string information = passenger.FirstName + Utilities.PrintBlankSpace(16 - passenger.FirstName.Length) + passenger.LastName + Utilities.PrintBlankSpace(22 - passenger.LastName.Length)
                                 + passenger.LoyaltyNumber + Utilities.PrintBlankSpace(15 - passenger.LoyaltyNumber.Length);
            if (passenger.SecurityFlag == true) information += "!!!";
            return information;
        }

        static void Main(string[] args)
        {
            Charms system = new Charms();
            bool showMenu = true;
            int option;

            system.BuildFakeFlights();

            do {
               DisplayMenu();
               option = Utilities.ReadInteger(1,5);
               switch (option)
               {
                   case 1:
                       system.DisplayFlightListMenu();
                       break;
                   case 2:
                       system.DisplayAddNewFlightMenu();
                       break;
                   case 3:
                       system.DisplaySelectFlightMenu();
                       break;
                   case 4:
                       system.SearchByPassengerMenu();
                       break;
                   case 5:
                       showMenu = false;
                       break;
               }

            } while(showMenu);

            Utilities.Exit();
        }

        private void BuildFakeFlights()
        {
            Random myRamdom = new Random(DateTime.Now.Second);
            this.flightRoster = new Flight[3];

            this.flightRoster[0] = new Flight(myRamdom.Next(1, 99999), CityGenerator.GetCity(), CityGenerator.GetCity());
            this.flightRoster[0].Passengers = BuildFakePassengers();

            this.flightRoster[1] = new Flight(myRamdom.Next(1, 99999), CityGenerator.GetCity(), CityGenerator.GetCity());
            this.flightRoster[1].Passengers = BuildFakePassengers();

            this.flightRoster[2] = new Flight(myRamdom.Next(1, 99999), CityGenerator.GetCity(), CityGenerator.GetCity());
            this.flightRoster[2].Passengers = BuildFakePassengers();
            
        }

        private HomelandSecurity.Passenger[] BuildFakePassengers()
        {
            NameGenerator fakeName = new NameGenerator();
            Random myRamdom = new Random(DateTime.Now.Second);
            HomelandSecurity.Passenger[] manifest = new HomelandSecurity.Passenger[10];

            for (int i = 0; i < manifest.Length; ++i)
            {
                manifest[i] = new HomelandSecurity.Passenger();
                manifest[i].FirstName = fakeName.RandomFisrtName();
                manifest[i].LastName = fakeName.Surname();
                manifest[i].LoyaltyNumber = myRamdom.Next(1000).ToString();
                manifest[i].SecurityFlag = false;
            }
            return manifest;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary;

/*          
 *          Project
 * Name: Joao Pedro Santos de Moura
 * Class: CIS 345 - 81883
 * Class time: Monday, Wednesday 3:00 PM - 4:15PM
 * 
 */

namespace Charms
{
    class Flight
    {
        private int number;
        private HomelandSecurity.Passenger[] passengerManifest;
        private string origin, destination;

        // Constructor
        public Flight(int flightNumber, string flightOrigin, string flightDestination)
        {
            this.number = flightNumber;
            this.passengerManifest = null;
            this.origin = flightOrigin;
            this.destination = flightDestination;
        }

        // Read-only propertie for 'number'.
        public int Number
        {
            get { return this.number;  }
        }

        // Write-Read propertie for 'passengers'
        public HomelandSecurity.Passenger[] Passengers
        {
            get { return this.passengerManifest; }
            set { this.passengerManifest = value; }
        }

        // Read-only propertie for 'origin'
        public string Origin
        {
            get { return this.origin; }
        }

        // Read-only propertie for 'destination'
        public string Destination
        {
            get { return this.destination; }
        }

        // Create a new Passenger instance
        private HomelandSecurity.Passenger CreatePassenger()
        {
            string firstName = Utilities.ReadString("Enter Passenger Fisrt Name: ");
            string lastName = Utilities.ReadString("Enter Passenger Last Name: ");
            string loyaltyNumber = Utilities.ReadString("Enter Passenger Loyalty Program Number: ");

            HomelandSecurity.Passenger newPassenger = new HomelandSecurity.Passenger(firstName, lastName, loyaltyNumber);

            return newPassenger;
        }

        // Add a passenger into a flight's roster
        public void AddPassenger(bool manual, HomelandSecurity.Passenger newPassenger = null)
        {
            HomelandSecurity.Passenger[] newRoster;

            if (manual == true)
            {
               newPassenger = CreatePassenger();
            }

            if (this.passengerManifest == null) //If ther is no passengers at all
            {
                newRoster = new HomelandSecurity.Passenger[1];
                newRoster[0] = newPassenger;
            }
            else
            {
                int passengerQuantity = passengerManifest.Length + 1; //Set the new Lenght for the passengers' Array
                newRoster = new HomelandSecurity.Passenger[passengerQuantity]; // Creates a new array with 1 more space for the new passenger
                passengerManifest.CopyTo(newRoster, 0); // Copy the passengers to the new array
                newRoster[passengerManifest.Length] = newPassenger; // Add the new passenger at last position
            }
        
            this.passengerManifest = newRoster;
            Console.Write("The passenger has been added!");
        }

        // Edit flight's information
        public void Edit(int newFlightNumber, string newFlightOrigin, string newFlightDestination)
        {
            this.number = newFlightNumber;
            this.origin = newFlightOrigin;
            this.destination = newFlightDestination;
            Console.Write("Information updated!");
        }

        // Display the flight's information in this format: "FlightNumber:    FlightOrigin    -->    FlightDestination"
        public string DisplayInformation()
        {
            string message = this.number + ". " + this.origin + "  -->  " + this.destination;
            return message;
        }
    }
}

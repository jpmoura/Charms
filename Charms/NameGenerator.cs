﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*          
 *          Project
 * Name: Joao Pedro Santos de Moura
 * Class: CIS 345 - 81883
 * Class time: Monday, Wednesday 3:00 PM - 4:15PM
 * 
 */

namespace Charms
{
    class NameGenerator
    {
        private Random myRandom;
        private string[] femaleNames;
        private string[] maleNames;
        private string[] surnames;

        public NameGenerator()
        {
            this.myRandom = new Random(DateTime.Now.Second);

            this.maleNames = new string[]{"Aiden", "Jackson", "Mason", "Liam", "Jacob", "Jayden", "Ethan", "Noah", "Lucas", "Logan", "Caleb", "Caden", "Jack", "Ryan",
            "Connor", "Michael", "Elijah", "Brayden", "Benjamin", "Nicholas", "Alexander", "William", "Matthew", "James", "Landon", "Nathan", "Dylan", "Evan", "Luke", 
            "Andrew", "Gabriel", "Gavin", "Joshua", "Owen", "Daniel", "Carter", "Tyler", "Cameron", "Christian", "Wyatt", "Henry", "Eli", "Joseph", "Max", "Isaac",
            "Samuel", "Anthony", "Grayson", "Zachary", "David", "Christopher", "John", "Isaiah", "Levi", "Jonathan", "Oliver", "Chase", "Cooper", "Tristan", "Colton",
            "Austin", "Colin", "Charlie", "Dominic", "Parker", "Hunter", "Thomas", "Alex", "Ian", "Jordan", "Cole", "Julian", "Aaron", "Carson", "Miles", "Blake",
            "Brody", "Adam", "Sebastian", "Adrian", "Nolan", "Sean", "Riley", "Bentley", "Xavier", "Hayden", "Jeremiah", "Jason", "Jake", "Asher", "Micah", "Jace", 
            "Brandon", "Josiah", "Hudson", "Nathaniel", "Bryson", "Ryder", "Justin", "Bryce", "Katherine", "Sienna", "Piper"};

            this.femaleNames = new string[]{"Sophia", "Emma", "Isabella", "Olivia", "Ava", "Lily", "Chloe", "Madison", "Emily", "Abigail", "Addison", "Mia", "Madelyn",
            "Ella", "Hailey", "Kaylee", "Avery", "Kaitlyn", "Riley", "Aubrey", "Brooklyn", "Peyton", "Layla", "Hannah", "Charlotte", "Bella", "Natalie", "Sarah", "Grace",
            "Amelia", "Kylie", "Arianna", "Anna", "Elizabeth", "Sophie", "Claire", "Lila", "Aaliyah", "Gabriella", "Elise", "Lillian", "Samantha", "Makayla", "Audrey",
            "Alyssa", "Ellie", "Alexis", "Isabelle", "Savannah", "Evelyn", "Leah", "Keira", "Allison", "Maya", "Lucy", "Sydney", "Taylor", "Molly", "Lauren", "Harper",
            "Scarlett", "Brianna", "Victoria", "Liliana", "Aria", "Kayla", "Annabelle", "Gianna", "Kennedy", "Stella", "Reagan", "Julia", "Bailey", "Alexandra", "Jordyn",
            "Nora", "Carolin", "Hayes", "Mackenzie", "Jasmine", "Jocelyn", "Kendall", "Morgan", "Nevaeh", "Maria", "Eva", "Juliana", "Abby", "Alexa", "Summer", "Brooke",
            "Penelope", "Violet", "Kate", "Hadley", "Ashlyn", "Sadie", "Paige", "Paige", };

            this.surnames = new string[] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", 
            "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen",
            "Young", "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", "Turner",
            "Phillips", "Campbell", "Parker", "Evans", "Edwards", "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey",
            "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray", "Ramirez", "James", "Watson", "Brooks", "Kelly", "Sanders", "Price",
            "Bennett", "Wood", "Barnes", "Ross", "Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington", "Butler",
            "Simmons", "Foster", "Gonzales", "Bryant", "Alexander", "Russell", "Griffin", "Diaz"};
        }

        public string MaleFirstName()
        {
            return maleNames[myRandom.Next(maleNames.Length)];
        }

        public string FemaleFirstName()
        {
            return femaleNames[myRandom.Next(femaleNames.Length)];
        }

        public string Surname()
        {
            return surnames[myRandom.Next(surnames.Length)];
        }

        public string Male()
        {
            string person;
            person = MaleFirstName() + " " + Surname();
            return person;
        }

        public string Female()
        {
            string person;
            person = FemaleFirstName() + " " + Surname();
            return person;
        }

        public string RandomFisrtName()
        {
            if ((myRandom.Next() % 13) > 6) return MaleFirstName();
            else return FemaleFirstName();
        }
    }
}

using System;
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
    public class CityGenerator
    {
        private static string[] cities = new string[] { "Montgomery", "Juneau", "Phoenix", "Little Rock", "Sacramento", "Denver", "Hartford", "Washington", "Tallahassee",
        "Atlanta", "Honolulu", "Boise", "Springfield", "Indianapolis", "Des Moines", "Topeka", "Frankfort", "Baton Rouge", "Augusta", "Annapolis", "Boston", "Lansing",
        "Saint Paul", "Jackson", "Jefferson City", "Helena", "Lincoln", "Carson City", "Concord", "Trenton", "Santa Fe", "Albany", "Raleigh", "Bismarck", "Columbus",
        "Oklahoma City", "Salem", "Harrisburg", "Providence", "Columbia", "Pierre", "Nashville", "Austin", "Salt Lake City", "Montpelier", "Richmond" ,"Olympia",
        "Charleston", "Madison", "Cheyenne"};
        private static Random myRandom = new Random(DateTime.Now.Second);

        public static string GetCity()
        {
            return cities[myRandom.Next(0, cities.Length)];
        }
    }
}

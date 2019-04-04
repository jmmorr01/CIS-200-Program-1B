// Grading ID C2937 
// Program 1B
// CIS 200-01
// Due: 10/4/2017

//Description: This program uses LINQ to sort a list of differnts types of parcels in different ways like by weight, cost, type, etc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 14356); // Test Address 4
            Address a5 = new Address("James May", "636 English Way", "Apt. 5",
                "Olympia", "WA", 86947); // Test Address 5
            Address a6 = new Address("John McClane", "293 Die Hard Road", "Apt. 2",
                "Dixie", "MA", 93048); // Test Address 6
            Address a7 = new Address("Michael Scott", "193 Office Court",
                "Scranton", "PA", 04573); // Test Address 7
            Address a8 = new Address("Henry Hill", "304 La Vel Lane",
                "New York City", "NY", 37594); // Test Address 8


            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            Letter letter2 = new global::Letter(a5, a6, 2.85M);
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a4, a8, 15, 19, 4, 14.5);
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a7, a5, 22, 12, 12, 90, 3.60M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8, a6, 40, 38, 27, 60, TwoDayAirPackage.Delivery.Early);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(letter2);
            parcels.Add(gp2);
            parcels.Add(ndap2);
            parcels.Add(tdap2);
            

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            // LINQ to sort parcels by the destination zip code
            var parcelDestZipOrder =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            // Foreach loop to output the LINQ results into the console
            Console.WriteLine("Sorted by Destination Zipcode Descending");
            foreach (var p in parcelDestZipOrder)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------------");          
            }
            Pause();

            //LINQ that sorts parcels based on cost and puts it into ascending order.
            var parcelCost =
                from p in parcels
                orderby p.CalcCost() ascending
                select p;

            // Foreach loop to output the LINQ results into the console
            Console.WriteLine("Sorted by Cost Ascending");
            foreach (var p in parcelCost)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------------");
            }
            Pause();

            // LINQ that sorts the parcels based on their type (letter, airpackage, etc.) ascending and then by cost descending.
            var parcelTypeAscenCostDesc =
                from p in parcels
                orderby p.GetType().ToString() ascending, p.CalcCost() descending
                select p;

            // Foreach loop to output the LINQ results into the console
            Console.WriteLine("Sorted by Type Ascending then Cost Descending");
            foreach (var p in parcelTypeAscenCostDesc)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------------");
            }
            Pause();

            // LINQ that sorts parcels that are air packages and are heavy by their weight.
            var parcelAirHeavyWeightDesc =
                from p in parcels.OfType<AirPackage>()
                where p.IsHeavy() 
                orderby p.Weight descending
                select p;

            // Foreach loop to output the LINQ results into the console
            Console.WriteLine("Sorted Heavy Airpackages by Weight");
            foreach (var p in parcelAirHeavyWeightDesc)
            {
                Console.WriteLine(p);
                Console.WriteLine("--------------------------");
            }
            Pause();

        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}

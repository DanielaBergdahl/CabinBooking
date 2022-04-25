using System;
using System.Collections.Generic;

namespace CabinBooking
{
    class Program
    {
        static List<Cabin> cabins = new List<Cabin>();
        static void Main(string[] args)
        {
                cabins.Add(new Cabin("Finstugan", "Frankrike", 6));
                cabins.Add(new Cabin("Lillstugan", "Lillsved", 2));
                cabins.Add(new Cabin("Spökstugan", "Spökkullen", 4));
                cabins.Add(new Cabin("Badstugan", "Flaten", 2));
                cabins[0].bookings.Add(new Booking("Bergdahl", "dcode@rdqt.se", 52));
                cabins[0].bookings.Add(new Booking("Nilsson", "nilsson@gmail.com", 50));
                cabins[1].bookings.Add(new Booking("Dahlström", "dahlstrom@gmail.com", 22));
                cabins[1].bookings.Add(new Booking("Hjort", "hjort@gmail.com", 23));
                cabins[2].bookings.Add(new Booking("Lundberg", "lundberg@gmail.com", 50));
                cabins[2].bookings.Add(new Booking("Hedin", "hedin@gmail.com", 51));
                cabins[3].bookings.Add(new Booking("Larsen", "cindy@gmail.com", 22));
                cabins[3].bookings.Add(new Booking("Pereira", "pereira@gmail.com", 23));
                

            MainMenu();
        }
        static void AddCabin()
        {
            Console.WriteLine("Här kan du lägga till en stuga för uthyrning\n");
            string cabinLocation = GetUserInputAsString("Vilken plats ligger stugan på?");

            string cabinName = GetUserInputAsString("Sätt ett namn på stugan");

            int cabinCapacity = GetUserInputAsInt("Hur många sängar har stugan?");

            cabins.Add(new Cabin(cabinName, cabinLocation, cabinCapacity));

            Console.WriteLine("Tryck valfri tangent för att fortsätta!"); 
            Console.ReadKey();
        }
        static void BookCabin()
        {
            PrintCabins();
            Cabin cabinToBook = SelectCabin();
            Console.WriteLine("Denna stuga är bokad följande veckor:");
            foreach (Booking booking in cabinToBook.bookings) // Vad händer här? Jag accessar ett fält som är en lista av typen Booking. Listan ligger i klassen Cabin.
            {                                                 // Dess egenskaper är bland annat week, det är för att den kommer från Booking som har week som property.  
                Console.WriteLine(booking.Week); 
            }
            Console.WriteLine("\nSkriv in kundens kontaktuppgifter!");
            string name = GetUserInputAsString("\nNamn: ");
            
            string email = GetUserInputAsString("Email: ");
            
            int week = GetUserInputAsInt("Skriv in ett veckonummer då du vill boka stugan: "); 

            cabinToBook.bookings.Add(new Booking(name, email, week));

            Console.WriteLine("\nDet här är bokningarna som finns just nu:");
            for (int i = 0; i < cabinToBook.bookings.Count; i++)
            {
                Console.WriteLine("Kundens namn: " + cabinToBook.bookings[i].CustomerName);
                Console.WriteLine("Kundens emailadress: " + cabinToBook.bookings[i].Email);
                Console.WriteLine("Bokad vecka: " + cabinToBook.bookings[i].Week);
            }
            Console.WriteLine("\nTryck valfri tangent för att fortsätta");
            Console.ReadKey();
        }
        static void CancelBooking()
        {
            PrintCabins();
            Cabin cabinToCancel = SelectCabin();
            if (cabinToCancel.bookings.Count == 0)
                {
                    Console.WriteLine("Det finns ingen bokning på den stugan.");
                    Console.WriteLine("Tryck på valfri tangent för att komma vidare till menyn");
                }
            else
                {
                    for (int i = 0; i < cabinToCancel.bookings.Count; i++)
                    {
                        Booking booking = cabinToCancel.bookings[i];
                        Console.WriteLine($"{i}: Vecka: {booking.Week}, namn: {booking.CustomerName}, email: {booking.Email}");
                    }
                    Console.WriteLine("Vilken rad vill du avboka?");
                    int weekToRemove = GetUserInputAsInt("Skriv in radnummret!");
                    cabinToCancel.bookings.RemoveAt(weekToRemove);
                }
            Console.WriteLine("Tryck på valfri tangent");
            Console.ReadKey();
        }
        static string GetUserInputAsString(string messageToUser)
        {
            string result = "";
            while (result == "")
            {
                Console.WriteLine(messageToUser);
                result = Console.ReadLine();
                if (result == "")
                    Console.WriteLine("Var vänlig skriv ett svar.");
                else if (CheckIfStringIsNotLetter(result))
                {
                    Console.WriteLine("Det måste vara bokstäver");
                    result = "";
                }
            }
            return result;
        }
        private static bool CheckIfStringIsNotLetter(string str)
        {
            bool onlyLetter = true;
            foreach (char character in str)
            {
                if (Char.IsLetter(character))
                {
                    onlyLetter = false;
                }
            }
            return onlyLetter;
        }
        private static int GetUserInputAsInt(string messageToUser)
        {
            int valueToReturn = -1;
            bool success = false;
            do
            {
                Console.WriteLine(messageToUser);
                string userInput = Console.ReadLine();
                success = Int32.TryParse(userInput, out valueToReturn);
                if (!success)
                    Console.WriteLine("Du måste skriva en siffra!");
            } while (!success);
            return valueToReturn;
        }
        static void MainMenu()
        {
            string menuOption;
            do
            {
                Console.Clear();
                Console.WriteLine("Välkommen till StugAppen!");
                Console.WriteLine("\nAlternativ 1. Lägg in en stuga för uthyrning");
                Console.WriteLine("Alternativ 2. Ta bort en stuga");
                Console.WriteLine("Alternativ 3. Boka en stuga");
                Console.WriteLine("Alternativ 4. Gör en avbokning");
                Console.WriteLine("Alternativ 5. Avsluta");
                Console.WriteLine("\nSkriv in 1-5 för att välja alternativ!\n"); 
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        AddCabin();
                        break;
                    case "2":
                        RemoveCabin();
                        break;
                    case "3":
                        BookCabin();
                        break;
                    case "4":
                        CancelBooking();
                        break;
                }
            } while (menuOption != "5");
        }
        static void PrintCabins()
        {
            for (int i = 0; i < cabins.Count; i++)
            {
                Console.WriteLine($"{i + 1} {cabins[i].CabinName}");
            }
        }
        static void RemoveCabin()
        {
            Console.Clear();
            if (cabins.Count == 0)
            {
                Console.WriteLine("Det finns inga stugor inlagda.");
            }
            else
            {
                PrintCabins();
                int cabinToRemove = GetUserInputAsInt("\nVilken stuga vill du ta bort?");
                cabins.RemoveAt(cabinToRemove - 1);
            }
            Console.WriteLine("Tryck på valfri tangent för att fortsätta!");
            Console.ReadKey();
        }
        static Cabin SelectCabin()
        {
            int cabinNumber = GetUserInputAsInt("Välj stuga!");
            Cabin result = cabins[cabinNumber - 1];
            Console.WriteLine($"Du har valt: {result.CabinName}");
            return result;
        }
    }
}

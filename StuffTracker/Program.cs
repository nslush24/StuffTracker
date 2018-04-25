using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffTracker
{
    enum HouseLocation
    {
        none,
        bedroom,
        kitchen,
        bathroom
    }

    class Program
    {
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }
        static List<Stuff> DisplayAddThing(List<Stuff> inventory)
        {
            Stuff userThing = new Stuff();


            DisplayHeader("Add Thing");

            Console.Write("Enter Name:");
            userThing.Name = Console.ReadLine();

            Console.Write("Enter Location:");
            HouseLocation houseLocation;
            Enum.TryParse<HouseLocation>(Console.ReadLine(), true, out houseLocation);
            userThing.Location = houseLocation;

            Console.Write("Enter true if it is alive and false if it is not:");
            userThing.IsLiving = bool.Parse(Console.ReadLine());

            Console.Write("Enter cost:");
            userThing.Cost = double.Parse(Console.ReadLine());

            inventory.Add(userThing);

            DisplayContinuePrompt();

            return inventory;

            
        }
        static List<Stuff> DisplayDeleteThing(List<Stuff> inventory)
        {
            string itemName;


            DisplayHeader("Delete Thing");

            Console.WriteLine("Current Inventory:");
            Console.WriteLine();
            foreach (Stuff item in inventory)
            {
                Console.WriteLine("\t" + item.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Enter the name of the item to remove:");
            itemName = Console.ReadLine();

            foreach (Stuff item in inventory)
            {
                if (item.Name == itemName)
                {
                    inventory.Remove(item);
                    break;
                }
            }

            //inventory.Remove(userThing);

            DisplayContinuePrompt();

            return inventory;


        }
        static List<Stuff> DisplayEditThing(List<Stuff> inventory)
        {
            {
                Stuff userThing = new Stuff();
                string itemName;


                DisplayHeader("Edit Thing");

                Console.WriteLine("Current Inventory:");
                Console.WriteLine();
                foreach (Stuff item in inventory)
                {
                    Console.WriteLine("\t" + item.Name);
                }

                Console.WriteLine();
                Console.WriteLine("Enter the name of the item to edit:");
                itemName = Console.ReadLine();

                foreach (Stuff item in inventory)
                {
                    if (item.Name == itemName)
                    {
                        inventory.Remove(item);
                        break;
                    }
                }

                Console.WriteLine();

                Console.Write("Edit Name:");
                userThing.Name = Console.ReadLine();

                Console.Write("Edit Location:");
                HouseLocation houseLocation;
                Enum.TryParse<HouseLocation>(Console.ReadLine(), true, out houseLocation);
                userThing.Location = houseLocation;

                Console.Write("Enter true if it is alive and false if it is not:");
                userThing.IsLiving = bool.Parse(Console.ReadLine());

                Console.Write("Edit cost:");
                userThing.Cost = double.Parse(Console.ReadLine());

                inventory.Add(userThing);

                //inventory.Remove(userThing);

                DisplayContinuePrompt();

                return inventory;


            }
        }
        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();

        }
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DisplayOpeningScreen()
        {
            Console.WriteLine("\t\t");
            Console.WriteLine();

            DisplayContinuePrompt();
        }
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tGood Bye");
            Console.WriteLine();

            Console.ReadKey();
        }

        static void DisplayInventory(List<Stuff> inventory)
        {
            DisplayHeader("Current Inventory");

            Console.WriteLine("Name".PadRight(15)  + "Cost".PadRight(15) + "Alive?".PadRight(15)+ "Location".PadRight(15));
            Console.WriteLine("-------".PadRight(15) + "--------".PadRight(15) + "--------".PadRight(15) + "--------".PadRight(15));

            foreach (Stuff thing in inventory)
            {
                Console.WriteLine();
                Console.Write(thing.Name.PadRight(15));
                //Console.Write(thing.Location.ToString().PadRight(15));
                Console.Write(thing.Cost.ToString("c").PadRight(15));
                Console.Write(thing.IsLiving.ToString().PadRight(15));
                if (thing.Location != HouseLocation.none)
                {
                    Console.WriteLine(thing.Location.ToString().PadRight(15));                   
                }
                
            }
            Console.WriteLine();
            DisplayContinuePrompt();
        }
        static void DisplayMainMenu()
        {
            string userResponse;
            bool loopRunning = true;
            List<Stuff> inventory;


            // initialize inventory
            inventory = InitializeInventory();

            while (loopRunning)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine();

                Console.WriteLine("\t1) Diplay Inventory ");
                Console.WriteLine("\t2) Add Thing ");
                Console.WriteLine("\t3) Delete Thing");
                Console.WriteLine("\t4) Edit Thing");
                Console.WriteLine("\te) Exit");
                Console.WriteLine();
                Console.Write("Enter Choice: ");
                userResponse = Console.ReadLine();

                switch (userResponse)
                {
                    case "1": DisplayInventory(inventory);
                        break;
                    case "2": inventory = DisplayAddThing(inventory);
                        
                        break;
                    case "3":
                        inventory = DisplayDeleteThing(inventory);
                        break;
                    case "4": inventory = DisplayEditThing(inventory);
                        break;
                    case "e":
                        loopRunning = false;
                        break;

                    default:
                        break;
                }

            }
        }



        static List<Stuff> InitializeInventory()
        {
            List<Stuff> inventory = new List<Stuff>();

            // creates objects
            Stuff camera = new Stuff();

            // add properties to object
            camera.Name = "Nikon 480";
            camera.Location = HouseLocation.bedroom;
            camera.IsLiving = false;
            camera.Cost = 699;

            // add object to list
            inventory.Add(camera);

            // creates objects
            Stuff dog = new Stuff();

            // add properties to object
            dog.Name = "Sage";
            dog.Location = HouseLocation.kitchen;
            dog.IsLiving = true;
            dog.Cost = 1000;

            // add object to list
            inventory.Add(dog);

            // creates objects
            Stuff bed = new Stuff();

            // add properties to object
            bed.Name = "Bed";
            bed.Location = HouseLocation.bedroom;
            bed.IsLiving = false;
            bed.Cost = 2000;

            // add object to list
            inventory.Add(bed);





            return inventory;
        }
    }

    class Stuff
    {
        private string _name;
        private HouseLocation _location;
        private bool _isLiving;
        private double _cost;





        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public HouseLocation Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public bool IsLiving
        {
            get { return _isLiving; }
            set { _isLiving = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public Stuff()
        {

        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bilbasen_Mini_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;

            //Here we enter the user interface
            while (exit == false)
            {
                //loading the text file
                var txt = @"C:\Users\nikol\Documents\Datamatiker\Programmering\cars.txt";

                //Creating a list for cars
                List<Car> carlist = new List<Car>();

                //Creating a list of strings for the lines of the text file
                List<string> lines = File.ReadAllLines(txt).ToList();

                //Variables to divide lines into

                int id;
                string model;
                string numberplate;
                int year;
                double price;

                //Creating a string array that separates of all lines into smaller strings with the divider being a comma (,)
                foreach (string line1 in lines)
                {
                    string[] data1 = line1.Split(',');

                    id = int.Parse(data1[0]);
                    model = data1[1];
                    numberplate = data1[2];
                    year = int.Parse(data1[3]);
                    price = double.Parse(data1[4]);


                    //Here we add a new car using a constructor and add it to our list of cars
                    Car newCar = new Car(id, model, numberplate, year, price);
                    carlist.Add(newCar);
                }

                if (carlist.Count > 1 || carlist.Count == 0)
                {
                    Console.WriteLine("Our database contains " + carlist.Count + " cars");
                }
                else
                {
                    Console.WriteLine("Our database contains " + carlist.Count + " car");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine("ID     Car name     ");
                Console.WriteLine("----------------------");

                foreach (Car car in carlist)
                {
                    Console.WriteLine("----------------------");
                    car.MenuInfo();
                }

                Console.WriteLine("----------------------");
                Console.WriteLine("Press '1' to select the car you want to view details on");
                Console.WriteLine("Press '2' to add a new car to the database");
                Console.WriteLine("Press '3' to remove a car from the database");
                Console.WriteLine("Press '0' to exit program");

                bool returnToMain = false;

                while (returnToMain == false)
                {
                    int choice1 = int.Parse(Console.ReadLine());
                    

                    switch (choice1)
                    {
                        case 1:

                            Console.WriteLine("Choose a car to see more details by entering the number assigned to it");
                            Console.WriteLine("Press '0' to return to main menu");
                            int choice2 = int.Parse(Console.ReadLine());

                            //User chooses car to view details on

                            if (carlist.Count >= choice2 && choice2 > 0)
                            {
                                Console.Clear();
                                carlist[choice2 - 1].ShowInfo();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to main menu");
                                Console.ReadKey();
                                Console.Clear();
                                returnToMain = true;
                            }
                            else
                            {
                                Console.Clear();
                                returnToMain = true;
                            }
                            break;

                        case 2:

                            //adding a car
                            Console.Clear();
                            int idEntry = carlist.Count + 1;

                            Console.WriteLine("Enter model name:");
                            string modelEntry = Console.ReadLine();

                            Console.WriteLine("Enter number plate:");
                            string numberplateEntry = Console.ReadLine();

                            int yearEntry = 0;
                            double priceEntry = 0;

                            bool yearContinue = false;
                            while (!yearContinue)
                            {
                                Console.WriteLine("Enter year of production:");
                                
                                bool successYear = int.TryParse(Console.ReadLine(), out yearEntry);
                                if (successYear == false)
                                {
                                    Console.WriteLine("Invalid input. Please try again");
                                }
                                else
                                {
                                    yearContinue = true;
                                }
                            }

                            bool priceContinue = false;
                            while (!priceContinue)
                            {
                                Console.WriteLine("Enter price: ");
                                
                                bool successPrice = double.TryParse(Console.ReadLine(), out priceEntry);
                                if (successPrice == false)
                                {
                                    Console.WriteLine("Invalid input. Please try again");
                                }
                                else
                                {
                                    priceContinue = true;
                                }
                            }
                            lines.Add(idEntry + "," + modelEntry + "," + numberplateEntry + "," + yearEntry + "," + priceEntry);
                            File.WriteAllLines(txt, lines);

                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to main menu");
                            Console.ReadKey();
                            Console.Clear();
                            returnToMain = true;
                            break;

                        case 3:
                            //Removing a car

                            Console.WriteLine("Choose a car you want to delete from the list by entering the number assigned to it");
                            Console.WriteLine("Press '0' to return to main menu");

                            //User chooses car to delete
                            try
                            {
                                int choice3 = int.Parse(Console.ReadLine());

                                carlist.RemoveAt(choice3 - 1);
                                lines.RemoveAt(choice3 - 1);

                                foreach (string line2 in lines)
                                {
                                    string[] data2 = line2.Split(',');

                                    id = int.Parse(data2[0]);
                                    model = data2[1];
                                    numberplate = data2[2];
                                    year = int.Parse(data2[3]);
                                    price = double.Parse(data2[4]);

                                    if (id > choice3)
                                    {
                                        line2.Replace(Convert.ToChar(data2[0]), Convert.ToChar(id - 1));
                                    }
                                }
                                File.WriteAllLines(txt, lines);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to main menu");
                                Console.ReadKey();
                                Console.Clear();

                                returnToMain = true;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message + " Please enter a valid number...");
                            }
                            break;

                        case 0:
                            //Exit
                            Console.WriteLine("Closing program...");
                            exit = true;
                            returnToMain = true;
                            break;

                        default:

                            //wrong input
                            Console.WriteLine("Invalid choice. Please try again...");
                            break;
                    }
                }
            }
        }
    }
}

namespace MiniFlightManagementSystem
{
    internal class Program
    {
        //System Data 

        List<string> passengerNames = new List<string>(){"Ali", "salwa", "khalfan", "Balqees"," Hussain" };
        List<string> ticketNumbers= new List<string>() {"TKT001", "TKT002", "TKT003", "TKT004"," TKT005" };
        string[] flightNumbers = new string[]
           { " OA101 ", "OA106 ", "OA103", "OA108", "OA109", " OA102"};


        List<DateTime> availableDates = new List<DateTime> {


            DateTime.Parse("10-6-2026"),
            DateTime.Parse("14-6-2026"),
            DateTime.Parse("21-6-2026"),
            DateTime.Parse("27-6-2026")
        };

        Dictionary<string, string> bookingRecord = new Dictionary<string,string>()
                {
                { "  TKT001 "  ,"OA101|12-Jan-2026"},
                { "  TKT002 " , "OA101|12-Jan-2026"},
                { "  TKT003  " , "OA101|12-Jan-2026"},


            };

        Queue<string> checkedInQueue = new Queue<string>(
            new string[]
            {" Ali", 
                "salwa",
                "khalfan"
            }

            );


        Stack<string> boardingStack = new Stack<string >(

              new string[]
            {   " Ali",
                "salwa",
                "khalfan"
            }

            );

        List<string> cancelledTickets = new List<string>();


        Dictionary<string,string> passengerSeatMap=new Dictionary<string,string>();


        Queue< string> waitlistQueue=new Queue< string>();












    static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {

                Console.WriteLine("------------------------------------");
                Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
                Console.WriteLine(" ___________________________________");
                Console.WriteLine("1.Register New Passenger  ");
                Console.WriteLine("2.View All Passengers ");
                Console.WriteLine("3.Book a Flight Ticket ");
                Console.WriteLine("4.View Booking Details ");
                Console.WriteLine("5.Update a Booking ");
                Console.WriteLine("6.Cancel a Ticket ");
                Console.WriteLine("7.Passenger Check-In");
                Console.WriteLine("8.Board Passengers (Boarding Stack) ");
                Console.WriteLine("9.Generate Flight Manifest ");
                Console.WriteLine("10.Manage Waitlist & Seat Assignment ");
                Console.WriteLine("0.Exit");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:



                        break;

                    case 2:


                        break;

                    case 3:


                        break;

                    case 4:



                        break;

                    case 5:


                        break;

                    case 6:



                        break;

                    case 7:




                        break;
                    case 8:

                        break;

                    case 9:

                        break;

                    case 10:

                        break;


                    case 0:
                        exit = true;

                        break;


                    default:

                        break;

                }//switch


                Console.WriteLine("Enter any key");

                Console.ReadKey();
                Console.Clear();


            }//while















        }
    }
}

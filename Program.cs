using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.Arm;
namespace MiniFlightManagementSystem
{
    internal class Program

    {
        //System Data 

        static List<string> passengerNames = new List<string>() { "Ali", "salwa", "khalfan", "Balqees", " Hussain" };
        static List<string> ticketNumbers = new List<string>() { "TKT001", "TKT002", "TKT003", "TKT004", "TKT005" };
        static string[] flightNumbers = { " OA101 ", "OA106 ", "OA103", "OA108", "OA109", " OA102"};


        static List<DateTime> availableDates = new List<DateTime> {


            DateTime.Parse("10-6-2026"),
            DateTime.Parse("14-6-2026"),
            DateTime.Parse("21-6-2026"),
            DateTime.Parse("27-6-2026")
        };

        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>() { 
            
            { "TKT001" ,"OA101|10-Jan-2026"},
            { "TKT002" ,"OA106|14-Jan-2026"},
            { "TKT003" ,"OA103|21-Jan-2026"},
            { "TKT004" ,"OA108|27-Jan-2026"},

              };

    static Queue<string> checkedInQueue = new Queue<string>(
                new string[]
                {" Ali",
                "salwa",
                "khalfan"
                }

                );


        static Stack<string> boardingStack = new Stack<string>(

              new string[]
            {   " Ali",
                "salwa",
                "khalfan"
            }

            );

        static List<string> cancelledTickets = new List<string>() { "TKT002" };



        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>();


        static Queue<string> waitlistQueue = new Queue<string>();

        static String passengerfile = "passengers.txt";


        static string tickeID = "";

        public static void SAVEDATA()
        {
            List< string > list = new List<string>();
            for (int i = 0; i < passengerNames.Count; i++)
            {

                string SAVE = passengerNames[i] + "|" + ticketNumbers[i];
                list.Add(SAVE);
            }
            File.WriteAllLines(passengerfile, list);

        }

        public static void loadFile()

        {
            if (File.Exists(passengerfile))
    
            {
              string  line = File.ReadAllLines(passengerfile);

                string[] part = line.Split["|"];
    
            foreach (int x in line)
                {
                    line.Add(part[0]);
                    line.Add(part[1]);

                       }



            }
        }
       


        //public static void savepassenger()//save function
        //{
        //    File.WriteAllLines(
        //      passengerfile,
        //      passengerNames

        //        );

        //    Console.WriteLine(Path.GetFullPath(passengerfile));
        //}



        //public static void Loadpassenger()// load function
        //{
        //    if ( File.Exists( passengerfile ))
        //    {
        //        passengerNames=File.ReadAllLines( passengerfile ).ToList();
        //    }

        //}




        /// Case 01 Register New Passenger
        public static void RegisterNewPassenger()
        {
            Console.WriteLine("Enter your full name");
            string Name = Console.ReadLine().ToLower();

            if (Name == "")
            {
                Console.WriteLine("CAN NOT BE EMPTY");
                return;
            }

            for (int i = 0; i < passengerNames.Count; i++)
            {
                if (passengerNames[i].ToLower() == Name.ToLower())
                {
                    Console.WriteLine(" Name alrady exit");
                    return;
                }
            }

            //if (passengerNames.Any(p  => p == Name))
            //{
            //    Console.WriteLine("Name already exists");
            //    return;
            //}



            passengerNames.Add(Name);



            int nextNumber = ticketNumbers.Count + 1;//to  Auto-generate the ticket ID

            tickeID = " TKT" + nextNumber.ToString("D3");



            ticketNumbers.Add(tickeID);

            SAVEDATA();
            //savepassenger();
            Console.WriteLine("Passenger Register Succssfuly ");
            Console.WriteLine(" Passenger Name" + ":" + Name);
            Console.WriteLine(" Passenger tickID" + ":" + tickeID);
        }


        //Case 02 View All Passengers
        public static void ViewAllPassengers() {
            // Check if passengerNames is empty
            if (passengerNames.Count == 0) 
            {
                Console.WriteLine(" No passengers registered yet ");
               return;
            }

            // Display a formatted table header
            Console.WriteLine("| Passenger Name    |     Ticket ID    | Status ");



            //cancelledTickets.Add("TKT001");
            //cancelledTickets.Add("TKT002");

            // Iterate over passengerNames using a for loop

            for (int i = 0; i < passengerNames.Count; i++)
            {
                if (cancelledTickets.Contains(ticketNumbers[i]))
                
                {
                    Console.WriteLine((i+ 1)+ " |" + passengerNames[i] +"|"+ ticketNumbers[i]+"| "+ "cancelled");
                }
                else
                {
                       Console.WriteLine((i+ 1)+ " |" + passengerNames[i] +"|"+ ticketNumbers[i]+"| "+ "active");
                }

          
            }

            //Display the total passenger count 
            Console.WriteLine(passengerNames.Count);
            }




        //case 3 : Book a Flight Ticket

        public static void BookFlightTicket()
        {
            // Validate it exists in ticketNumbers and is not in cancelledTickets

            Console.WriteLine("Enter ticket Id:  ");
            tickeID = Console.ReadLine();

            if (!ticketNumbers.Contains(tickeID))
            {
                Console.WriteLine(" invalid ticket id ");
                return;
            }

            if (cancelledTickets.Contains(tickeID))
            {
                Console.WriteLine("ticket is cancelled");
                return;
            }


            //Check if the ticket is already in bookingRecord

            if (bookingRecord.ContainsKey(tickeID))
            {
                Console.WriteLine(" This ticket already has a booking");
                return;
            }

            //Display all available flight numbers from the flightNumbers 
            Console.WriteLine(" Available flights");


            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine((i + 1) + " :" + flightNumbers[i]);
            }





            //  Prompt the user to select a flight by entering its index number & Validate the input is within range.

            Console.WriteLine(" Enter flight number");
            int flightindxe = int.Parse(Console.ReadLine());

            if (flightindxe < 1 || flightindxe > flightNumbers.Length)//Validate input
            {
                Console.WriteLine(" index out of range");
                return;
            }
            
            string selectFlight = flightNumbers[flightindxe - 1];/////




            // Display all available dates from availableDates with index labels & Prompt the user to select a date by index & Validate input.

            for (int i = 0;i <availableDates.Count;i++) 
            {

                Console.WriteLine(i+1 +  " :"   +availableDates[i]);
            }

            Console.WriteLine(" Enter  date flight");//Prompt the user to select a date
            int datetindxe = int.Parse(Console.ReadLine());


            if (datetindxe < 1 || datetindxe> availableDates.Count)//Validate input
            {
                Console.WriteLine(" invalied date");
            }

            DateTime selectDate= availableDates[datetindxe - 1  ];





            //int indexname = ticketNumbers.IndexOf(tickeID); //located value(tickeid) inside the  list
            string Name = passengerNames[ticketNumbers.IndexOf(tickeID)];

            // Display a booking confirmation showing ticket ID, passenger name, flight, and date

            Console.WriteLine(" booking confirmation  ");
            Console.WriteLine("  ticket ID" + " : " + tickeID);            
            Console.WriteLine("Passenger Name: " + Name);
            Console.WriteLine("  flight number " + " :" + selectFlight);
            Console.WriteLine(" date of travel " +  " :" + selectDate);
        }


        // case 4: View Booking Details

        public static void ViewBookingDetails()
        {

            // Prompt for a ticket ID.Validate it exists in ticketNumbers.Display an error and return if not found.
            Console.WriteLine(" Enter ticket id");
            string ticketId = Console.ReadLine();

            if (!ticketNumbers.Contains(ticketId))

            {
                Console.WriteLine("ticket not found ");

                return;
            }

            // Retrieve the passenger name from passengerNames using the matching index from ticketNumbers.

            //int index = ticketNumbers.IndexOf(ticketId);//located value(tickeid) inside the  list
            //string passengerName = passengerNames[index];

            //// Check if the ticket is in cancelledTickets.If so, display 'This ticket has been cancelled.' and return
            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("This ticket has been cancelled ");
                return;
            }


            //Use the Dictionary to retrieve the booking value. If the key does not exist, display 'No booking found for this ticket.' and return



            if (!bookingRecord.ContainsKey(ticketId))
            {

                {
                    Console.WriteLine("No booking found for this ticket");
                    return;
                }
            }

            string bookingIfo = bookingRecord[ticketId];
            Console.WriteLine(bookingIfo);




            // Split the retrieved value on '|' to separate the flight number and date

            string bookingValue = bookingRecord[ticketId];

            string[]  bookingDate=bookingValue.Split('|');
            string flightNumber=bookingDate[0];
            string flightDate = bookingDate[1];

            // Display a full booking summary card showing all details.
            Console.WriteLine(" ticket id" + ticketId);
            Console.WriteLine(" flight number " +flightNumber);
            Console.WriteLine(" Booking summary"+ flightDate);
            
        }
        //case 5:
        public static void updateBooking()
        {
            
            Console.Write("Enter Ticket ID: ");
            string ticketId = Console.ReadLine();

            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found");
                return;
            }

            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("Ticket is cancelled");
                return;
            }

            if (!bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine("No booking found");
                return;
            
            }
            //  display current booking
            string booking = bookingRecord[ticketId];

            string[] parts = booking.Split('|');

            string currentFlight = parts[0];
            string currentDate = parts[1];

            Console.WriteLine("Current Flight: " + currentFlight);
            Console.WriteLine("Current Date: " + currentDate);

            //
            Console.WriteLine("1. Change Flight");
            Console.WriteLine("2. Change Date");
            Console.WriteLine("3. Change Both");
            Console.WriteLine("0. Cancel");

            int choice = Convert.ToInt32(Console.ReadLine());

            string newFlight = currentFlight;
            string newDate = currentDate;

            if (choice == 1)
            {
                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                }

                int flightChoice =
                    Convert.ToInt32(Console.ReadLine());

                newFlight =
                    flightNumbers[flightChoice - 1];
            }
            else if (choice == 2)
            {
                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + availableDates[i]);
                }

                int dateChoice = Convert.ToInt32(Console.ReadLine());

                newDate = availableDates[dateChoice - 1].ToString();
            }

            else if (choice == 3)
            {
                Console.WriteLine("Flights:");

                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                }

                int flightChoice =
                    Convert.ToInt32(Console.ReadLine());

                newFlight =
                    flightNumbers[flightChoice - 1];

                Console.WriteLine("Dates:");

                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + availableDates[i]);
                }

                int dateChoice =
                    Convert.ToInt32(Console.ReadLine());

                newDate =
                    availableDates[dateChoice - 1].ToString();
            }
            else if (choice == 0)
            {
                return;
            }
            // update dictionary & new value
            string updatedBooking =newFlight + "|" + newDate;

            bookingRecord[ticketId] =
                updatedBooking;
            //display old and new
            Console.WriteLine("Old Booking");
            Console.WriteLine("Flight: " + currentFlight);
            Console.WriteLine("Date: " + currentDate);

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("New Booking");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Flight: " + newFlight);
            Console.WriteLine("Date: " + newDate);
            Console.WriteLine("Booking updated successfully");

        }

        //case 6: cancel tikcet

        public static void CancelTicket()

        {
            Console.Write("Enter Ticket ID: ");
            string ticketId = Console.ReadLine();

            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found");
                return;
            }

            int index = ticketNumbers.IndexOf(ticketId);

            string passengerName = passengerNames[index];
            //deleted booking from dictioary
            if (bookingRecord.ContainsKey(ticketId))
            {
                string booking = bookingRecord[ticketId];

                Console.WriteLine("Removed Booking: " + booking);

                bookingRecord.Remove(ticketId);
            }
            //add to cancllticket
            cancelledTickets.Add(ticketId);

            //to remove passenger from queqe

            Queue<string> tempQueue = new Queue<string>();

            while (checkedInQueue.Count > 0)
            {
                string passenger =
                    checkedInQueue.Dequeue();

                if (passenger != passengerName)
                {
                    tempQueue.Enqueue(passenger);
                }
            }


            while (tempQueue.Count > 0)
            {
                checkedInQueue.Enqueue(
                    tempQueue.Dequeue());
            }

            //remove passenger from stack
            Stack<string> tempStack =
             new Stack<string>();

            while (boardingStack.Count > 0)
            {
                string passenger =
                    boardingStack.Pop();

                if (passenger != passengerName)
                {
                    tempStack.Push(passenger);
                }
            }

            // back orginal stack

            while (tempStack.Count > 0)
            {
                boardingStack.Push(
                    tempStack.Pop());
            }

            Console.WriteLine();
            Console.WriteLine("Cancellation Completed");
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Passenger: " + passengerName);


        }

        //case 7: Passenger Check-In

        public static void passengerCheck_In()

            {

            Console.WriteLine("1. Check In Passenger");
            Console.WriteLine("2. View Check-In Queue");
            Console.WriteLine("3. Process Next Passenger");
            Console.WriteLine("0. Back");

            string choice = Console.ReadLine();


            string ticketId = Console.ReadLine();

            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found");
                return;
            }

            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("Ticket cancelled");
                return;
            }

            if (!bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine("No booking found");
                return;
            }

            string bookingInfo = bookingRecord[ticketId];

            string[] data = bookingInfo.Split('|');

            string passengerName = data[2];


            if (checkedInQueue.Contains(passengerName))
            {
                Console.WriteLine("Passenger already checked in");
                return;
            }

            if (checkedInQueue.Count < 10)
            {
                checkedInQueue.Enqueue(passengerName);

                Console.WriteLine("Passenger checked in successfully");
            }

            
            else
            {
                waitlistQueue.Enqueue(passengerName);

                Console.WriteLine("Added to waitlist");
            }


            int position = 1;

            foreach (string passenger in checkedInQueue)
            {
                Console.WriteLine($"{position}. {passenger}");
                position++;
            }

            Console.WriteLine("Waitlist Count: " + waitlistQueue.Count);


        }



        //case :8  BoardPassengers
        public static void BoardPassengers()
        {
            Console.WriteLine(" 1-Load boarding stack from check-in queue");
            Console.WriteLine("2-Board next passenger");
            Console.WriteLine("3-View boarding stack  ");
            Console.WriteLine("4-View boarding log ");
            Console.WriteLine("0.Back");




        }
        static void Main(string[] args)
        {
            //Loadpassenger();
                        
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

                        RegisterNewPassenger();


                        break;

                    case 2:

                        ViewAllPassengers();

                        break;

                    case 3:

                        BookFlightTicket();
                        break;

                    case 4:

                        ViewBookingDetails();

                        break;

                    case 5:
                        updateBooking();

                        break;

                    case 6:

                     CancelTicket();

                        break;

                    case 7:

                        passengerCheck_In();


                        break;
                    case 8:

                        BoardPassengers();

                        break;

                    case 9:

                        break;

                    case 10:

                        break;


                    case 0:
                        exit = true;

                        break;

                    default:
                        Console.WriteLine("thank you");
                        break;

                }//switch


                Console.WriteLine("Enter any key");

                Console.ReadKey();
                Console.Clear();


            }//while











            



        }
    }
}

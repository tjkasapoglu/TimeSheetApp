using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using static ConsoleApplication1.WorkWeek;

namespace ConsoleApplication1
{
    public class Driver

    {

        public static List<Users> AllUsers = new List<Users>();
        public static List<WorkWeek> WorkList = new List<WorkWeek>();

        /// <param name="args"></param>
        internal static void Main
            (string[] args)
        {
            int userSelection = 99;
            Console.WriteLine(value: "Timesheets");
            while (userSelection != 0)
            {
                Console.WriteLine(value: "1. Add new user");
                if (AllUsers.Count > 0)
                {
                    Console.WriteLine(value: "2. Select user to add hours");
                    Console.WriteLine(value: "3. Select user to edit hours");
                    Console.WriteLine(value: "4. Select user to Calculate Pay");
                }
                Console.WriteLine(value: "0. Exit the application");
                Console.WriteLine(value: "Please make a selection");
                try
                {
                    userSelection = Convert.ToInt32(value: Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(value: "Please input a number");
                    userSelection = 99;
                }
                switch (userSelection)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        SelectUsers(true);
                        break;
                    case 3:
                        SelectUsers(false);
                        break;
                    case 4:
                        SelectUsers(false);
                        break;
                    case 0: //do nothing
                        break;
                    default:
                        Console.WriteLine(value: "Input not recognized. Try again.");
                        break;
                }
            }

        }


        /// 
        private static void SelectUsers(bool option)
        {
            for (int i = 0; i < AllUsers.Count; i++)
            {
                int selectionNum = i + 1;
                Console.WriteLine(value: selectionNum + ". : " + AllUsers[index: i].FirstName + " " + AllUsers[index: i].LastName);
            }
            Console.WriteLine(value: "Select user via number.");
            try
            {
                var userSelection = Convert.ToInt32(value: Console.ReadLine());
                while (userSelection < 1 || userSelection > AllUsers.Count)
                {
                    Console.WriteLine(value: "Input incorrect. Please select a user by number");
                    userSelection = Convert.ToInt32(value: Console.ReadLine());
                }
                if (option)
                {
                    AddHours(currentUser: AllUsers[index: userSelection - 1], allUsers: AllUsers[index: userSelection - 1]);
                    decimal  totalPay = WorkWeek.CalculatePay(AllUsers[index: userSelection - 1]);
                   Console.WriteLine("Weekly pay is " + totalPay);
                    
                }
                else
                {
                    EditHours(currentUser: AllUsers[index: userSelection - 1]);
                    decimal totalPay = WorkWeek.CalculatePay(AllUsers[index: userSelection - 1]);
                    Console.WriteLine("Weekly pay is " + totalPay);
                }
            }
            catch (FormatException e)
            {
                SelectUsers(option);
            }
        }


        

        /// <summary>
        /// Allows the user to select an emlpoyee and edit the hours they have previously entered
        /// </summary>
        private static void EditHours(Users currentUser)
        {
            if (currentUser != null)
                if (WorkList.Count <= 0)
                {
                    Console.WriteLine(value: "Work hours empty. Entering add hours mode.");
                    
                }
                else
                {
                    Console.WriteLine(value: "Select week to change.");
                    for (int i = 0; i < currentUser.Hours; i++)
                    {
                        int selectionNum = i + 1;
                        Console.WriteLine(value: selectionNum + ".: " + currentUser[index: i]);
                    }

                    try
                    {
                        int selection = Convert.ToInt32(value: Console.ReadLine()) - 1;

                        
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(value: "Input incorrect.");
                        EditHours(currentUser: currentUser);
                    }
                }
        }


        public static void CreateUser()
        {
            bool loop = true;

            Console.WriteLine(value: "Please input user's First Name");
            string fName = Console.ReadLine();
            Console.WriteLine(value: "Please input user's Last Name");
            string lName = Console.ReadLine();
            Console.WriteLine(value: "Please input user's title");
            string title = Console.ReadLine();

            Users addedUser = new Users(fName: fName, lName: lName, title: title);
            AllUsers.Add(item: addedUser);
            
            Console.WriteLine(value: "User:" + addedUser.FirstName + " added.");

            Console.WriteLine("Please input Pay Rate");
            while (loop)
            {
                try
                {
                    int payinput = Convert.ToInt32(Console.ReadLine());
                    if (payinput <= 50)
                    {
                        addedUser.UserRate = payinput;
                        Console.WriteLine("Pay Rate Added");
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Please input value less than 50");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("please input numerals");
                    throw;
                    
                }

            }
        }


              
              


      

       

        public int PayRate
        {
            get
            {
                Console.WriteLine("Please input Pay Rate");
                int payinput = Convert.ToInt32(Console.ReadLine());
                if (payinput <= 50)
                    try
                    {

                        PayRate = payinput;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please input a value equal or less to 50");
                        throw;
                    }


                return 0;
            }
            set { PayRate = value; }

        }



        public static void AddHours(Users currentUser, Users allUsers)
        {
            Console.WriteLine(value: "Please input hour's worked for Monday");
            string mondayHours = Console.ReadLine();
            Console.WriteLine(value: "Please input hour's worked for Tuesday");
            string tuesdayHours = Console.ReadLine();
            Console.WriteLine(value: "Please input hour's worked for Wednesday");
            string wednesdayHours = Console.ReadLine();
            Console.WriteLine(value: "Please input hour's worked for Thursday");
            string thursdayHours = Console.ReadLine();
            Console.WriteLine(value: "Please input hour's worked for Friday");
            string fridayHours = Console.ReadLine();
            Console.WriteLine(value: "Please input hour's worked for Saturday");
            string saturdayHours = Console.ReadLine();
            Console.WriteLine(value: "Please input hour's worked for Sunday");
            string sundayHours = Console.ReadLine();
            int rate = allUsers.UserRate;

            WorkWeek workweek = new WorkWeek(monday: mondayHours, tuesday: tuesdayHours, wednesday: wednesdayHours, thursday: thursdayHours, friday: fridayHours, saturday: saturdayHours, sunday: sundayHours, payrate: rate);
            WorkList.Add(item: workweek);
            
            Console.WriteLine(value: "Hours added.");


        }

    }

    public class Users

    {
 

        public Users(string fName, string lName, string title)
        {
            FirstName = fName;
            LastName = lName;
            Title = title;
          
        }


        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Title { set; get; }
        public int Hours { get; set; }

       
        public int UserRate { set; get; }


        public object this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

        




        





    
}

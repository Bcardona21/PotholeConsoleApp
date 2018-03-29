using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pothole
{
    class RunPot
    {

        private string firstName;
        private string lastName;
        private string emailAddress;
        private string mainStreetName;
        private string intersectStreet;
        private string comments;



        static void Main(string[] args)
        {
            MainMenu();
        }



        public static void MainMenu()
        {
            RunPot rp = new RunPot();
            Pot pot = new Pot();

            Console.WriteLine("              __________________________________________________________________________");
            Console.WriteLine("             |                                                                          |");
            Console.WriteLine("             |                        Pot Fillers Community Registration                |");
            Console.WriteLine("             |                                                                          |");
            Console.WriteLine("             |                'Filling the voids in your daily commuting life'          |");
            Console.WriteLine("             |--------------------------------------------------------------------------|");
            Console.WriteLine("             |                                                                          |");
            Console.WriteLine("             |                                                                          |");
            Console.WriteLine("             |                    1) Register a new pothole                             |");
            Console.WriteLine("             |                    2) Check the status of a past request                 |");
            Console.WriteLine("             |                    3) About the program                                  |");
            Console.WriteLine("             |                    4) Exit                                               |");
            Console.WriteLine("             |__________________________________________________________________________|");
            Console.WriteLine("             |                                                                          |");
            Console.WriteLine("             |               In association with the community outreach program         |");
            Console.WriteLine("             |              of Sonic City counties and municipalities (est. 2018)       |");
            Console.WriteLine("             |__________________________________________________________________________|");

            Console.WriteLine("");

            Console.WriteLine("                  *If this is your first time using the Pothole Registration System*\n                            *please read the" +
                " 'About the program' section* \n");


            Console.WriteLine("Please enter a choice:  ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");

            switch(menuChoice)
            {
                case 1: //Register a new Pothole

                      rp.NewPot();

                    break;

                case 2: //Check Status of previous request

                    rp.PotStatus();

                    break;

                case 3: //About the program 
                    
                    pot.ProgramInfo();
                    MainMenu();

                    break;

                case 4: //Exit the console

                    Environment.Exit(0);

                    break;
            }
               


        } //END MAINMENU METHOD


        public void NewPot()
        {

            Pot potter = new Pot();

            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();

            Console.WriteLine("");


            Console.WriteLine("Enter your email address: ");
            emailAddress = Console.ReadLine();

            //checks to make sure the email address contains '@' and '.' characters
             while (!emailAddress.Contains('@') || !emailAddress.Contains('.') )
            {
                Console.WriteLine("");
                Console.WriteLine("The address you've entered is invalid. Please enter a valid email: \n");

                emailAddress = Console.ReadLine();
            }

            Console.WriteLine("");


            Console.WriteLine("What street is the pothole on?");
            mainStreetName = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("What is the closest intersecting street?");
            intersectStreet = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Got a comment?");
            comments = Console.ReadLine();


            //Save the info to a file
            string[] potInfo = { emailAddress, lastName, firstName, mainStreetName, intersectStreet, comments, "" };
            System.IO.File.WriteAllLines(@" (path here) \RegistrantInfo.txt",potInfo);

            Console.WriteLine("Thank you! Your request has been saved." +
                              " \nSonic City  thanks you for your contribution to the community outreach program!");

             Console.WriteLine("You will receive a confirmation email shortly! \n");

            potter.SendEmail(emailAddress);



            MainMenu();

        } // END NEWPOT METHOD


        public void PotStatus()
        {
            
            Console.WriteLine("Please enter the email address you used for your filling request,\nor type 'quit'" +
                              "and press enter to go back to the main menu: \n ");

            emailAddress = Console.ReadLine();
            Console.WriteLine("");

            //Reads the RegistrantInfo.txt file and puts each line into the readerArray string
                                                               //**the path must be designated***
                string[] readerArray= System.IO.File.ReadAllLines(@" (path here) \RegistrantInfo.txt ");

                if (emailAddress == "quit")
                {
                MainMenu();
                }


            if (emailAddress == readerArray[0])
            {
                Console.WriteLine("Here's the information we have on file: \n");
                Console.WriteLine("First name: {0}", readerArray[2]);
                Console.WriteLine("Last name: {0}", readerArray[1]);
                Console.WriteLine("Relative pothole location: {0} and {1} ", readerArray[3], readerArray[4]);
                Console.WriteLine("Comments: {0}", readerArray[5]);

                Console.WriteLine("");
                Console.WriteLine("");



                //Gives the user a random response to their status inquiry
                Random randy = new Random();
                int status = randy.Next(1, 3);

                
                switch (status)
                {
                    case 1:
                        Console.WriteLine("Sonic City's Department of Transportation has filled the pothole via your request!" +
                                          " Thank you for your submission! \n");

                        Console.WriteLine("Please press <enter> to continue \n");
                        var input = Console.ReadKey();

                        Console.Clear();

                        MainMenu();
                        break;


                    case 2:
                        Console.WriteLine("Sonic City's Department of Transportation is currently verifying your request." +
                                          " Check back soon for an updated status. \n");

                        Console.WriteLine("Please press <enter> to continue \n");
                        input = Console.ReadKey();

                        Console.Clear();

                        MainMenu();
                        break;

                    case 3:
                        Console.WriteLine("Sonic City's Department of Transportation has validated the pothole and will be repairing it shortly." +
                                          " Check back for updates! \n");

                        Console.WriteLine("Please press <enter> to continue \n");
                        input = Console.ReadKey();

                        Console.Clear();

                        MainMenu();
                        break;
                }


            }
            else
            {
                Console.WriteLine(" We could not find your filling request via the email you've entered. Did you mean to quit out? \n ");

                PotStatus();
            }


        } // END POTSTATUS METHOD


    } //END CLASS
}

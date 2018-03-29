using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace Pothole
{
    class Pot
    {


        public void SendEmail(string email)
        {
            //Using Google's SMTP service

            //In the state this method is currently in, it will immediately throw an exception
            //unless valid google account credentials are entered

            //It will also throw an exception if the user did not enter an already existing email address
            //The program only checks to make sure the user's email address contains the '@' and '.' characters 
            //Refer to the NewPot method in the RunPot class

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                                    //**Must be a valid gmail account**
                mail.From = new MailAddress("_________@gmail.com");
                mail.To.Add(email);

                mail.Subject = "Filling Request Received!";
                mail.Body = "Sonic City Department of Transportation thanks you for your contribution to the improvement of your community!";


                SmtpServer.Port = 587;
                                                                      //**Must be valid Google Account credentials**
                SmtpServer.Credentials = new System.Net.NetworkCredential("_________@gmail.com", "password here");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);


                Console.WriteLine("Email Sent! \n");
                Console.WriteLine("Please press <enter> to continue: \n");

                var input = Console.ReadKey();

                Console.Clear();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        } //END SEND EMAIL METHOD


        public void ProgramInfo()
        {
            Console.Clear();

            Console.WriteLine("");


            Console.WriteLine("Sonic City Department of Transportation instituted this program\nto increase road safety and improve driving conditions. \n\n" +
                "SC DoT holds the right to consider which filling requests to respond to. \n\nAll false requests will be investigated and Sonic City may issue " +
                "fines to offenders. \n\n" +
                "SC DoT has full discretion to respond to certain requests over others \ndepending on the hazard level determined by the Department of Transportation. \n ");

            Console.WriteLine("Please press <enter> to return to the main menu: \n");

            var input = Console.ReadKey();

            Console.Clear();

        } // END PROGRAM INFO METHOD



    } //END POT CLASS
}

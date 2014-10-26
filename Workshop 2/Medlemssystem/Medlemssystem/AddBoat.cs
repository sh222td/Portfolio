using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Medlemssystem
{
    class AddBoat
    {
        public static void AddBoatToMember()
        {
            AddInformation addInfo = new AddInformation();
            Presentation.EditUsers();

            Console.WriteLine("Vill du lägga till båt? J/N");
            string userInput = Console.ReadLine();
            if (userInput == "J" || userInput == "j")
	        {
                ShowUser.ShowUsers();

                Console.WriteLine("Hos vem?");
                int userChoice = int.Parse(Console.ReadLine());

                Console.WriteLine("Hur lång är båten ");
                string boatLength = Console.ReadLine();

                Console.WriteLine("Vad vill du lägga till för båt?");
                Console.WriteLine("1.Segelbåt 2.Motorseglare 3.Motorbåt 4.Kajak/Kanot 5.Övrigt");
                string boatType = Console.ReadLine();


                string addUserQuery = "INSERT INTO boat (memberID, boattypeID, boatlength) VALUES ( " + "'"+userChoice+"'" + ","  + "'" + boatType + "'" + "," + "'" + boatLength + "'" + ")";

                SQLconnection.addBoatconn(addUserQuery);
                Console.WriteLine("Båten tillagd");
                Console.ReadLine();

                //Skriv in "WHERE USER = userChoice för att lägga till eller ersätta en båt.


                }               
            }
        }
    }
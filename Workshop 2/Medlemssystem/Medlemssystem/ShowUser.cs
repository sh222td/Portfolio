using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Medlemssystem
{

    class ShowUser
    {

        public static void ShowUsers()
        {
            string displayAllUsers = "CALL `miniMemList`();";
            SQLconnection.showCompressedList(displayAllUsers);
            Console.ReadLine();
        }

        public static void ShowCompleteUser()
        {
            AddInformation addInfo = new AddInformation();
            string callProcedure = "CALL `memberlist`();";
            SQLconnection.Procedure(callProcedure);
        }
       
        public static void SpecificUserInfo()
        {
            AddInformation addInfo = new AddInformation();

            Console.Write("Vill du visa ytterligare information om användarna? j / n: ");
            string userChoice = (Console.ReadLine());

            if (userChoice == "j" || userChoice == "J")
            {
                int specificUser = Program.Index("Välj vem du vill visa mer information om: ");
                //int SelectedUser = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------");
                Console.WriteLine("Användare");
                Console.WriteLine("------------------");
                Console.WriteLine("Förnamn: {0}",  addInfo.FirstNameList[specificUser]);
                Console.WriteLine("Efteramn: {0}", addInfo.LastNameList[specificUser]);
                Console.WriteLine("Personnummer: {0}", addInfo.SocialSecurityNumber[specificUser]);
                Console.WriteLine("Medlemsnummer: {0}", addInfo.IDNumber[specificUser]);
                Console.WriteLine("Båttyp: {0}", addInfo.BoatTypeList[specificUser]);
                Console.WriteLine("Båtlängd: {0}", addInfo.BoatLengthList[specificUser]);
                Program.ContinueOnKeyPressed();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Program.Menu();
            }
        }
    }
}
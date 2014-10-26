using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Medlemssystem
{
    class Program
    {
        Presentation wt = new Presentation();
        AddInformation addInfo = new AddInformation();
        DeleteBoat del = new DeleteBoat();
        EditBoat edit = new EditBoat();
        
        

        //Menu
        public static void Menu()
        {
            SQLconnection conn = new SQLconnection();
            bool exit = false;
            do
            {
                switch (GetMenuChoice())
                {
                    case 0: { return; }
                    case 1: { addUser(); exit = true; break; }
                    case 2: { AddBoatToUser(); break; }
                    case 3: { ShowUsers(); break;}
                    case 4: { ShowCompleteUser(); break; }
                    case 5: { EditUsers(); break; }
                    case 6: { EditBoats(); break; }
                    case 7: { DeleteUsers(); break; }
                    case 8: { DeleteBoats(); break; }

                }
            } while (!exit);
        }

        //Anropar metoden Menu.
        static void Main(string[] args)
        {
            Menu();
        }

        public static void ContinueOnKeyPressed()
        {
            Console.ReadKey();
        }

        public static void addUser()
        {
            AddUser.addUser();
        }

        public static void EditBoats()
        {
            EditBoat.EditBoats();
        }

        public static void ShowCompleteUser()
        {
            ShowUser.ShowCompleteUser();
        }
        public static void DeleteBoats()
        {
            DeleteBoat.DeleteBoats();
        }

        public static void AddBoatToUser()
        {
            AddBoat.AddBoatToMember();
        }
        

        public static void EditUsers()
        {
            EditUser.EditUserInfo();
        }

        public static void ShowUsers()
        {
            ShowUser.ShowUsers();
        }

        //Metod som används för att kontrollera att avändaren inte skriver in fel saker i programmet vid val
        public static int Index(string str)
        {
            AddInformation addInfo = new AddInformation();

            int index;
            do
            {
              Console.Write(str);
            } while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index > addInfo.FirstNameList.Count - 1);
            return index;
        }
        public static int Index2(string str)
        {
            int index2;
            do
            {
                Console.Write(str);
            } while (!int.TryParse(Console.ReadLine(), out index2) || index2 < 0);
            return index2;
        }

        public static void SpecificUserInfo()
        {
            ShowUser.SpecificUserInfo();
        }

        public static void DeleteUsers()
        {
            Delete.DeleteUsers();
        }

        static int GetMenuChoice()
        {
            Presentation.GetMenu();

            do
            {
                int menuChoice;

                //Läser av värdet i menyn och "outar" det valet till menyChoice, valet måste va inom 0-4 annars felmed.
                if (int.TryParse(Console.ReadLine(), out menuChoice) && (menuChoice >= 0 && menuChoice <= 11))
                {
                    Console.Clear();
                    return menuChoice;
                }
                else
                {
                    Menu();
                }
            } while (true);
        }
    }
}
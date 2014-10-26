using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemssystem
{
    class AddInformation
    {
        //Listor där vi adderar vår information
        private static List<string> fNameList = new List<string>();
        private static List<string> lNameList = new List<string>();
        private static List<double> pnumber = new List<double>();

        private static List<string> boatType = new List<string>();
        private static List<string> boatLength = new List<string>();
        
        private static List<int> amoutOfBoats = new List<int>();
        private static List<int> idNumber = new List<int>();
        private string[] boatTypes = new string[] { "Segelbåt", "Motorseglare", "Motorbåt", "Kajak/Kanot", "Övrigt" };

        public List<string> FirstNameList
        {
            get
            {
                return fNameList;
            }
        }

        public List<string> LastNameList
        {
            get
            {
                return lNameList;
            }
        }

        public List<double> SocialSecurityNumber
        {
            get
            {
                return pnumber;
            }
        }

        public List<string> BoatTypeList
        {
            get
            {
                return boatType;
            }
        }

        public List<string> BoatLengthList
        {
            get
            {
                return boatLength;
            }
        }

        public List<int> AmountOfBoats
        {
            get
            {
                return amoutOfBoats;
            }
        }

        public List<int> IDNumber
        {
            get
            {
                return idNumber;
            }
        }
    }
}

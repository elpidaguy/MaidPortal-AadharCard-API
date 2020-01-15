using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class AadharManager
    {
        public static List<Aadhar> GetAadhars()
        {
            return AadharDAL.GetAll();
        }
        public static Aadhar GetAadhar(int aadharNumber)
        {
            return AadharDAL.GetAadhar(aadharNumber);
        }
        public static bool GetByContactNo(int contactNo)
        {
            return AadharDAL.GetByContactNo(contactNo);
        }
        public static Aadhar GetAadharByContactNo(int contactNo)
        {
            return AadharDAL.GetAadharByContactNo(contactNo);
        }
    }
}

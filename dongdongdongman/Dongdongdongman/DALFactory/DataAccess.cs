using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Models;
using IDAL;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
         }
        public static IUP CreateUP()
        {
            string className = AssemblyName + "." + db + "UP";
            return (IUP)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUP_detail CreateUP_detail()
        {
            string className = AssemblyName + "." + db + "UP_detail";
            return (IUP_detail)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}

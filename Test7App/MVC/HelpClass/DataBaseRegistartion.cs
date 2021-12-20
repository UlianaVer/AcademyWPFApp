using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test7App.AppData;

namespace Test7App.MVC.HelpClass
{
    class DataBaseRegistartion
    {
        public static string GetLogin(string getLogin) {
            User1 user = DataFrame.entOdb.User1.FirstOrDefault(x => x.Login == ClientInfo.LoginClient);
            while (true) {
                if (user != null && user.Login == getLogin)
                {
                    return "Такой пользователь есть!";
                }
                else {
                    return "Такой пользователь отсутствует!";
                }
            }
        }
    }
}

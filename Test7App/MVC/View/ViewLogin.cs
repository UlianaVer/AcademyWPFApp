using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test7App.MVC.HelpClass;

namespace Test7App.MVC.View
{
    class ViewLogin
    {
        public string GetLogin(string loginCheck) {
            return DataBaseRegistartion.GetLogin(loginCheck);
        }
    }
}

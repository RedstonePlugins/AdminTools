using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedstonePlugins.AdminTools.Configuration
{
    public class Config
    {
        /* Please use a structure to the config.
         * 
         * DONT STORE INFO INTO CONFIGURATION
         * 
         * 
         * 
         * KEEP EVERYTHING IN THEIR CATEGORY.
         */

        public Modules Modules = new Modules();

        


    }


    public class Modules
    {
        public JoinLeaveOptions JoinLeave = new JoinLeaveOptions();
    }

    public class JoinLeaveOptions
    {

        public bool logIp = false;

        public bool showMessages = true;

        public bool logCountry = true;

    }
}

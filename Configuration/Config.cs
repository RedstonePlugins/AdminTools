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

        public JoinLeaveOptions joinleave = new JoinLeaveOptions
        {
            logIp = false,

            showMessages = true,

            logCountry = true,
        };

        


    }

    public class JoinLeaveOptions
    {

        public bool logIp;

        public bool showMessages;

        public bool logCountry;

    }
}

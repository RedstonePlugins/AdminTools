using System;
using System.Collections.Generic;
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
            ipLogging = true,

            showMessages = true,
        };

        


    }

    public class JoinLeaveOptions
    {
        public bool ipLogging;

        public bool showMessages;

        public bool showCountry;

    }
}

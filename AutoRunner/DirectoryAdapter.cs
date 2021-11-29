using System.Collections.Generic;
using System.IO;

namespace AutoRunner
{
    public class DirectoryAdapter
    {
        public static string Separator
        {
            get
            {
                return Path.DirectorySeparatorChar.ToString();
            }
        }

        public static string CurrentDirectory
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }

        public static string ApplicationsDirectory
        {
            get
            {
                return CurrentDirectory + Separator + "App" + Separator;
            }
        }
        public static string ConfigDirectory
        {
            get
            {
                return CurrentDirectory + Separator + "Config" + Separator;
            }
        }
        
        public static string[] GetApplications()
        {
            return Directory.GetFiles( ApplicationsDirectory );
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace AutoRunner
{
    public class ApplicationsAdapter
    {
        private static string[] ignoreList =
        {
            "AutoRunner.exe", "AutoRunner.pdb"
        };

        private static JObject appConfig;

        public static void ShowCandidateToInstall()
        {
            string[] applications = DirectoryAdapter.GetApplications();
            
            foreach (var app in applications)
            {
                if (ignoreList.Any(app.Contains))
                {
                    continue;
                }

                string appName = app.Replace(DirectoryAdapter.ApplicationsDirectory, string.Empty);

                Console.WriteLine($"App => {appName}");

            }
        }

        public static void GetInstallParameters()
        {
            string jsonFile = DirectoryAdapter.ConfigDirectory + "AppInstallParameters.json";
             
            appConfig = JObject.Parse(File.ReadAllText( jsonFile ));

            if (appConfig["app"].HasValues == true)
            {
                Console.WriteLine( "\n--- The installation will use the installation options ---");
            }
            else
            {
                Console.WriteLine( "\nWarning! Installation options are not applied to the list of programs!");
            }
        }

        public static void RunInstallProccess()
        {
            string[] applications = DirectoryAdapter.GetApplications();
            
            GetInstallParameters();

            foreach (var app in applications)
            {
                if (ignoreList.Any(app.Contains))
                {
                    continue;
                }

                string appName = app.Replace(DirectoryAdapter.ApplicationsDirectory, string.Empty);

                Console.WriteLine($"\n\n*** Install .. {appName}" );
                
                var currentAppInstall  = Process.Start(app , appConfig["app"][appName].ToString() );

                currentAppInstall.WaitForExit();

                Console.WriteLine( $"Install {appName} is completed");
                
            }
        }
    }
}
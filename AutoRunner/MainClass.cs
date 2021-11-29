using System;
using System.Diagnostics;

namespace AutoRunner
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            if ( args.Length != 0 )
            {
                Console.WriteLine( "*** AutoRunner will install current applications: ***");
                
                ApplicationsAdapter.RunInstallProccess();

                Console.WriteLine( "\nAll applications is installed");
                
                Console.ReadLine();
                
                Process.GetCurrentProcess().Kill();
            }


            Console.WriteLine( "*** AutoRunner will install current applications: ***");

            ApplicationsAdapter.ShowCandidateToInstall();

            Console.WriteLine("\n\nIf you want to continue auto installation of programs, send 'Yes'[Y]");

            string key = Console.ReadLine().ToLower();

            if (key == "yes" || key == "y")
            {
                ApplicationsAdapter.RunInstallProccess();

                Console.WriteLine( "\nAll applications is installed");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("You answered incorrectly. The program will be completed");
                Console.ReadLine();
            }
        }
    }
}
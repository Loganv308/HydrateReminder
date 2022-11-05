/**
Author: Logan Velier
Date: 11/5/2022
Repo: 
**/
using System;
using Topshelf;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HydrationReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x => // Topshelf specific code to setup the service. "Wires stuff up"
            {
                x.Service<Reminder>(s => // Creates the service.
                {
                    s.ConstructUsing(reminder => new Reminder()); // Calls constructor for Reminder service
                    s.WhenStarted(reminder => reminder.Start()); // When called, start the service
                    s.WhenStopped(reminder => reminder.Start()); // When called, stop the service
                });

                x.RunAsLocalSystem(); // Gives permission to run as service on local system.

                x.SetServiceName("HydrationReminder");
                x.SetDisplayName("Hydration Reminder");
                x.SetDescription("This app will notify you every hour to take a swig of water, therefore maintaining ideal hydration.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode()); // Casting to an Int and converting the exit code
            Environment.ExitCode = exitCodeValue; // Passing and assigning as an Int
        }
    }
}

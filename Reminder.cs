using System;
using System.Timers;
using System.IO;
using Microsoft.Toolkit.Uwp.Notifications;

namespace HydrationReminder
{
    public class Reminder
    {
        private readonly Timer _timer;
        public Reminder()
        {
            _timer = new Timer(60 * 60 * 1000) { AutoReset = true }; // Timer for an hour. 60 * 60 * 1000 is 3_600_000, that's how many MS are in an hour.
            _timer.Elapsed += TimerElapsed;
            _timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            _timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\burni\source\repos\HydrationReminder\Logs.txt", lines);
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Time to drink water!")
                .AddText("Grab your nearest water bottle and chug for atleast 5 seconds nerd")
                .AddInlineImage(new Uri("https://www.zehnders.com/zchefs/wp-content/uploads/2020/05/aquafina-bottle.jpg"))
                .Show();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}

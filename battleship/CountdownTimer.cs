using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public class CountdownTimer : Statistics
    {
        private Timer timer;
        private Label label;

        public CountdownTimer(Label label)
        {
            this.label = label;
            timer = new Timer();
            timer.Interval = 120000; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            string timeString = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            label.Text = timeString;
        }
    }
}

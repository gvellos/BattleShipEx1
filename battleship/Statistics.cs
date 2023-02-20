using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace battleship
{
    [Serializable]
    public class Statistics
    {
        public int WinUser { get; set; }
        public int WinBot { get; set; }
        public int Time { get; set; }
        public int TimesUntiliWin { get; set; }

    }

}

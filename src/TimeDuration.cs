using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendar
{
    public struct TimeDuration
    {
        // Public fields
        int hours;
        int minutes;


        #region Accessors and mutators
        // Hours property
        public int Hours
        {
            set
            {
                hours = value;
            }
            get
            {
                return hours;
            }
        }

        // Minutes property
        public int Minutes
        {
            set
            {
                minutes = value;
                if (Minutes / 60 == 1)
                {
                    this.Hours++;
                    Minutes = 0;
                }

            }
            get
            {
                return minutes;
            }
        }
        #endregion


        // Override method 
        // Converting time details into string combined line
        public override string ToString()
        {
            return hours + " Hours " + " : " + minutes + " Minutes";
        }
    }
}

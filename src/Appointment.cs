using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendar
{
    public class Appointment : IAppointment
    {
        // Data members
        // start & length from IAppointment
        DateTime start;
        int length;
        string subject;
        string location;

        // Default
        // modyfing and sync the system's time 
        public Appointment()
            : this(System.DateTime.Now, 0, "", "")
        {
        }

        // Appointment constructor
        // Initializing data members
        public Appointment(DateTime start, int length, string subject, string location)
        {
            this.start = start;
            this.length = length;
            this.subject = subject;
            this.location = location;
        }


        #region Accessors and mutators

        // Location property
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }


        // Subject property
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }


        // Start property
        public DateTime Start
        {
            get
            {
                return start;
            }
        }


        // Length property
        public int Length
        {
            get
            {
                return length;
            }
        }


        // DisplayableDescription Property
        public string DisplayableDescription
        {
            get
            {
                return "Subject : " + subject + "\n" + "Location: " + location;
            }
        }
        #endregion


        // Validity check of bool recurrenceFrequency
        // responsible for date confilcts in adding appointments
        public bool OccursOnDate(DateTime date)
        {
            return start.Date == date.Date;
        }


        // Method for catching the time conflicts in the r_appointment system
        // i.e (booking an r_appointment for an hour that had passed)
        public bool ConflictExceptionHandler(DateTime startDate, int length)
        {
            DateTime end = start.AddMinutes((double)this.length);
            DateTime endDate = startDate.AddMinutes((double)length);
            if (startDate.TimeOfDay < start.TimeOfDay && endDate.TimeOfDay <= start.TimeOfDay)
            {
                return false;
            }
            if (endDate.TimeOfDay > end.TimeOfDay && startDate.TimeOfDay >= end.TimeOfDay)
            {
                return false;
            }
            return true;
        }

        internal bool TimeConflict(DateTime dateTime, int p)
        {
            throw new NotImplementedException();
        }
    }
}

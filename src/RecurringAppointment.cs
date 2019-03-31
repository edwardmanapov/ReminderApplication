using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendar
{
    public class RecurringAppointment : IAppointment
    {
        // Data member
        RecurrenceFrequency recurrenceFrequency;
        int recurrenceNumber;
        DateTime start;
        int length;
        string subject;
        string location;


        // Constructor
        public RecurringAppointment(int recurrenceNumber, RecurrenceFrequency type, DateTime start, int length, string subject, string location)
        {
            this.recurrenceNumber = recurrenceNumber;
            this.RecurrenceFrequency = type;
            this.start = start;
            this.length = length;
            this.subject = subject;
            this.location = location;
        }


        // Default
        // initializes a new instance of the class.
        public RecurringAppointment() : this(0, RecurrenceFrequency.Daily, System.DateTime.Now, 0, "", "")
        {
        }

        #region Accessors and mutators
        // DisplayableDescription property
        public string DisplayableDescription
        {
            get
            {
                return "Subject : " + subject + " at " + location + "\n Occuring: " + recurrenceNumber + " times " + RecurrenceFrequency.ToString();
            }
        }

        // NumberOfRecurrence property
        public int NumberOfRecurrence
        {
            set
            {
                recurrenceNumber = value;
            }
            get
            {
                return recurrenceNumber;
            }
        }

        // RecurrenceFrequency property
        public RecurrenceFrequency RecurrenceFrequency
        {
            get
            {
                return recurrenceFrequency;
            }
            set
            {
                recurrenceFrequency = value;
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
        
        // Subject property
        public string Subject
        {
            set
            {
                subject = value;
            }
            get
            {
                return subject;
            }
        }

        // Location property
        public string Location
        {
            set
            {
                location = value;
            }
            get
            {
                return location;
            }
        }
        #endregion


        // Returns a value of true if the appointment occurs on the specified date, false otherwise.
        public  bool OccursOnDate(DateTime date)
        {
            int i = recurrenceNumber;
            DateTime tempdate = start;
            while (i > 0)
            {
                if (RecurrenceFrequency == RecurrenceFrequency.Daily)
                {
                    if (tempdate.Date == date.Date)
                        return true;
                    tempdate = tempdate.AddDays(1.0);
                }
                if (RecurrenceFrequency == RecurrenceFrequency.Weekly)
                {
                    if (tempdate.Date == date.Date)
                        return true;
                    tempdate = tempdate.AddDays(7.0);
                }
                if (RecurrenceFrequency == RecurrenceFrequency.Monthly)
                {
                    if (tempdate.Date == date.Date)
                        return true;
                    tempdate = tempdate.AddMonths(1);
                }
                if (RecurrenceFrequency == RecurrenceFrequency.Yearly)
                {
                    if (tempdate.Date == date.Date)
                        return true;
                    tempdate = tempdate.AddYears(1);
                }
                i--;
            }
            return false;
        }


        // Returns a value of true if the appointment occurs on the specified date, false otherwise.
        public bool OccursOnTime(DateTime startTime, int length)
        {
            DateTime end = start.AddMinutes((double)this.length);
            DateTime endDate = startTime.AddMinutes((double)length);
            if (startTime.TimeOfDay < start.TimeOfDay && endDate.TimeOfDay <= start.TimeOfDay)
            {
                return false;
            }
            if (endDate.TimeOfDay > end.TimeOfDay && startTime.TimeOfDay >= end.TimeOfDay)
            {
                return false;
            }
            return true;
        }
    }
}

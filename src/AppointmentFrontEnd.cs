using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calendar
{
    public partial class AppointmentFrontEnd : Form
    {
        // Data members
        Appointment appointment;
        DateTime day;

        // Constructor
        public AppointmentFrontEnd(DateTime day)
        {
            this.day = day;
            InitializeComponent();
            appointment = null;
        }

        // Constuctor
        // Initiliazing role
        public AppointmentFrontEnd(DateTime day, Appointment appointment)
        {
            this.day = day;
            InitializeComponent();
            this.appointment = appointment;
            subjectTextBox.Text = appointment.Subject;
            locationTextBox.Text = appointment.Location;
        }


        #region Accessors and mutators
        // Appointment property 
        // responsible for the appointment details display in an opened form
        public Appointment Appointment
        {
            set
            {
                appointment = value;
            }
            get
            {
                return appointment;
            }
        }
        #endregion


        // Method responsible for startTimeComboBox view
        // using pre defined members for the frequency of time view
        private void LoadTimes()
        {
            DateTime thisDay = day;
            DateTime nextday = day.AddDays(1.0);
            while (thisDay != nextday)
            {
                startTimeComboBox.Items.Add(thisDay.TimeOfDay);
                thisDay = thisDay.AddMinutes(30.0);
            }
        }


        // Method responsible for lengthComboBox
        // creates an new instance of timeDuration
        // initialising components, modyfing the time view in dropdrown list by 30 minutes
        private void LoadDurations()
        {
            TimeDuration time = new TimeDuration();
            time.Minutes = 30;
            time.Hours = 0;
            while (time.Hours <= 24)
            {
                lengthComboBox.Items.Add(time);
                if (time.Hours == 24)
                    return;
                time.Minutes = time.Minutes + 30;
            }
        }


        // Main r_appointment form loader on screen
        // initialising all the private fields
        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            dateLabel.Text = day.Date.ToLongDateString();
            LoadTimes();
            LoadDurations();
            startTimeComboBox.SelectedIndex = 0;
            lengthComboBox.SelectedIndex = 0;
            startTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            lengthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        // Handles the Click event of the saveButton control
        // The instance containing the event data
        private void saveButton_Click(object sender, EventArgs e)
        {
            TimeDuration duration = (TimeDuration)lengthComboBox.Items[lengthComboBox.SelectedIndex];
            int length = (duration.Hours * 60) + duration.Minutes;
            TimeSpan timespan = (TimeSpan)startTimeComboBox.Items[startTimeComboBox.SelectedIndex];
            day = day.AddHours(timespan.TotalHours);
            appointment = new Appointment(day, length, subjectTextBox.Text, locationTextBox.Text);
            this.Close();
        }


        // cancelButton on click event listener
        // handled by a system form close event
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

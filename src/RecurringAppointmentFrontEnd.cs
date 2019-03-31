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
    public partial class RecurringAppointmentFrontEnd : Form
    {
        /// <summary>
        /// The recurring appointment 
        /// Private fields
        /// </summary>
        RecurringAppointment recurringAppointment;
        DateTime day;


        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringAppointmentFrontEnd"/> class.
        /// Constructor
        /// </summary>
        /// <param name="day">The day.</param>
        public RecurringAppointmentFrontEnd(DateTime day)
        {
            InitializeComponent();
            this.day = day;
            recurringAppointment = null;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringAppointmentFrontEnd"/> class.
        /// Constructor with parameters
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="recurringAppointment">The recurring appointment.</param>
        public RecurringAppointmentFrontEnd(DateTime day, RecurringAppointment recurringAppointment)
        {
            InitializeComponent();
            this.day = day;
            this.recurringAppointment = recurringAppointment;
            subjectTextBox.Text = recurringAppointment.Subject;
            locationTextBox.Text = recurringAppointment.Location;
            occurenceTextBox.Text = recurringAppointment.NumberOfRecurrence.ToString();
        }


        /// <summary>
        /// Gets or sets the recurring appointment.
        /// Accessors and mutatorss
        /// </summary>
        /// <value>
        /// The recurring appointment.
        /// </value>
        public RecurringAppointment RecurringAppointment
        {
            get
            {
                return recurringAppointment;
            }
            set
            {
                recurringAppointment = value;
            }
        }


        /// <summary>
        /// Handles the Click event of the cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Handles the Click event of the saveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            int numberOfOccurence = 0;
            if (occurenceTextBox.Text.Trim() != "")
            {
                try
                {
                    // Check for occurence
                    // Cant be 1 and more than a specific high number
                    numberOfOccurence = int.Parse(occurenceTextBox.Text);
                    if (numberOfOccurence > 999 || numberOfOccurence < 2)
                    {
                        MessageBox.Show("Please select a number between 2 and 999", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        occurenceTextBox.Text = "";
                        return;
                    }

                }
                catch
                {
                    // Cathing exception of error handling
                    MessageBox.Show("Please select a number between 2 and 999", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    occurenceTextBox.Text = "";
                }
            }
            TimeDuration duration = (TimeDuration)lengthComboBox.Items[lengthComboBox.SelectedIndex];
            int length = (duration.Hours * 60) + duration.Minutes;
            TimeSpan timespan = (TimeSpan)startTimeComboBox.Items[startTimeComboBox.SelectedIndex];
            day = day.AddHours(timespan.TotalHours);
            RecurrenceFrequency type = (RecurrenceFrequency)frequencyComboBox.Items[frequencyComboBox.SelectedIndex];
            if (numberOfOccurence == 0)
            {
                return;
            }
            recurringAppointment = new RecurringAppointment(numberOfOccurence, type, day, length, subjectTextBox.Text, locationTextBox.Text);
            this.Close();
        }


        /// <summary>
        /// Loads the times.
        /// And time in multiple of 30 minutes.
        /// </summary>
        private void LoadTimes()
        {
            DateTime tempday = day;
            DateTime nextday = day.AddDays(1.0);
            while (tempday != nextday)
            {
                startTimeComboBox.Items.Add(tempday.TimeOfDay);
                tempday = tempday.AddMinutes(30.0);
            }
        }


        /// <summary>
        /// Loads the durations.
        /// In multiple of 30 minutes.
        /// </summary>
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


        /// <summary>
        /// Loads the recurrence types.
        /// From RecurrenceFrequency interface.
        /// </summary>
        private void LoadRecurrenceFrequency()
        {
            frequencyComboBox.Items.Add(RecurrenceFrequency.Daily);
            frequencyComboBox.Items.Add(RecurrenceFrequency.Weekly);
            frequencyComboBox.Items.Add(RecurrenceFrequency.Monthly);
            frequencyComboBox.Items.Add(RecurrenceFrequency.Yearly);
        }


        /// <summary>
        /// Handles the Load event of the RecurringAppointmentForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RecurringAppointmentFrontEnd_Load(object sender, EventArgs e)
        {
            dateLabel.Text = day.ToLongDateString();
            LoadDurations();
            LoadTimes();
            LoadRecurrenceFrequency();
            startTimeComboBox.SelectedIndex = 0;
            lengthComboBox.SelectedIndex = 0;
            frequencyComboBox.SelectedIndex = 0;
            frequencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            lengthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            startTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void startTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

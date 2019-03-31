using System;
using System.Collections.Generic;
using System.IO;

namespace Calendar
{
	public class Appointments : IAppointments
	{
		// Refference calls
		// Intance creation
		IList<IAppointment> list;
		StreamReader load;
		StreamWriter save;


		// modyfing the new list from the interface
		public Appointments()
			: this(new List<IAppointment>())
		{
		}


		// Constructor
		// Initializing members and list
		public Appointments(IList<IAppointment> list)
		{
			this.list = list;
			load = null;
			save = null;
		}


		#region Interface implementation
		// Returns an enumerator that iterates through the collection
		// that can be used to iterate through the collection.
		public IEnumerator<IAppointment> GetEnumerator()
		{
			return list.GetEnumerator();
		}


		IEnumerator<IAppointment> IEnumerable<IAppointment>.GetEnumerator()
		{
			return GetEnumerator();
		}


		// Returns an enumerator that iterates through a collection.
		// An object that can be used to iterate through the collection.
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}
		#endregion


		// Method responsible for adding an r_appointment
		// to the list as itemList
		public void Add(IAppointment itemList)
		{
			list.Add(itemList);
		}


		// Initilizing list
		public void Clear()
		{
			list.Clear();
		}


		// bool recurrenceFrequency check for the validity of adding an itemList 
		// of recurrenceFrequency r_appointment in the list
		public bool Contains(IAppointment item)
		{
			return list.Contains(item);
		}


		// Copy the itemList to an 2D array 
		public void CopyTo(IAppointment[] array, int arrayIndex)
		{

			list.CopyTo(array, arrayIndex);
		}


		// Bool recurrenceFrequency method 
		// for checking the rights of the list
		public bool ReadOnly
		{
			get
			{
				return list.IsReadOnly;
			}
		}


		// Property for getting the number of items in list
		public int Count
		{
			get
			{
				return list.Count;
			}
		}


		/// <summary>
		/// Indexes the of.
		/// </summary>
		/// <param name="itemList">The item list.</param>
		/// <returns></returns>
		public int IndexOf(IAppointment itemList)
		{
			return list.IndexOf(itemList);
		}


		/// <summary>
		/// Inserts the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="itemList">The item list.</param>
		public void Insert(int index, IAppointment itemList)
		{
			list.Insert(index, itemList);
		}


		/// <summary>
		/// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}


		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public IAppointment this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				list[index] = value;
			}
		}


		/// <summary>
		/// Gets the appointments on date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns></returns>
		public IEnumerable<IAppointment> GetAppointmentsOnDate(DateTime date)
		{
			foreach (IAppointment item in list)
			{
				if (item.OccursOnDate(date))
				{
					yield return item;
				}
			}
		}


		/// <summary>
		/// Saves this instance.
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			bool isSaved = false;
			string info = "";
			save = new StreamWriter("appointments.txt");
			while (!isSaved)
			{
				foreach (IAppointment app in list)
				{
					if (app is Appointment)
					{
						Appointment s_appointment = app as Appointment;
						info = "Appointment\t" + s_appointment.Start.ToLongDateString() + "\t" + s_appointment.Start.ToLongTimeString() + "\t" + s_appointment.Length + "\t" + s_appointment.Subject + "\t" + s_appointment.Location;
						try
						{
							save.WriteLine(info);
							isSaved = true;
						}
						catch
						{
							save.Close();
							save = null;
							isSaved = false;
						}
					}
					if (app is RecurringAppointment)
					{
						RecurringAppointment r_appointment = app as RecurringAppointment;
						info = "RecurringAppointment\t" + r_appointment.Start.ToLongDateString() + "\t" + r_appointment.Start.ToLongTimeString() + "\t" + r_appointment.Length + "\t" + r_appointment.Subject + "\t" + r_appointment.Location + "\t" + r_appointment.NumberOfRecurrence + "\t" + r_appointment.RecurrenceFrequency.ToString();
						try
						{
							save.WriteLine(info);
							isSaved = true;
						}
						catch
						{
							save.Close();
							save = null;
							isSaved = false;
						}
					}
				}
			}
			save.Close();
			save = null;
			return isSaved;
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		/// <returns></returns>
		public bool Load()
		{
			load = new StreamReader("appointments.txt");
			string line = load.ReadLine();
			try
			{
				while (line != null)
				{
					string[] info = line.Split('\t');
					if (info[0] == "Appointment")
					{
						string date = info[1];
						string timeofday = info[2]; 
						int length = int.Parse(info[3]);
						string subject = info[4];
						string location = info[5];
						DateTime start = DateTime.Parse(date);
						start = start.Date;
						DateTime time = DateTime.Parse(timeofday);
						start = start.AddHours(time.Hour);
						start = start.AddMinutes(time.Minute);
						list.Add(new Appointment(start, length, subject, location));
					}
					if (info[0] == "RecurringAppointment")
					{
						string date = info[1];
						string timeofday = info[2];
						int length = int.Parse(info[3]);
						string subject = info[4];
						string location = info[5];
						DateTime start = DateTime.Parse(date);
						start = start.Date;
						DateTime time = DateTime.Parse(timeofday);
						start = start.AddHours(time.Hour);
						start = start.AddMinutes(time.Minute);
						int numberOfOccurence = int.Parse(info[6]);
						RecurrenceFrequency type;
						switch (info[7])
						{
							case "Daily":
								type = RecurrenceFrequency.Daily;
								break;
							case "Weekly":
								type = RecurrenceFrequency.Weekly;
								break;
							case "Monthly":
								type = RecurrenceFrequency.Monthly;
								break;
							case "Yearly":
								type = RecurrenceFrequency.Yearly;
								break;
							default:
								type = RecurrenceFrequency.Daily;
								break;
						}
						list.Add(new RecurringAppointment(numberOfOccurence, type, start, length, subject, location));
					}
					line = load.ReadLine();
				}
			}
			catch
			{
				load.Close();
				load = null;
				return false;
			}
			load.Close();
			load = null;

			return true;
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
		/// </summary>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
		/// <returns>
		/// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
		/// </returns>
		public bool Remove(IAppointment item)
		{
			load = new StreamReader("appointments.txt");
			string info = "";
			try
			{
				string line = load.ReadLine();
				while (line != null)
				{
					if (item is Appointment)
					{
						Appointment s_appointment = item as Appointment;
						info = "Appointment\t" + s_appointment.Start.ToLongDateString() + "\t" + s_appointment.Start.ToLongTimeString() + "\t" + s_appointment.Length + "\t" + s_appointment.Subject + "\t" + s_appointment.Location;
						if (info.CompareTo(line) == 0)
						{
							load.Close();
							load = null;
							save = new StreamWriter("appointments.txt");
							line = "";
							save.WriteLine(line);
							save.Close();
							save = null;
							load = new StreamReader("appointments.txt");
						}
					}
					if (item is RecurringAppointment)
					{
						RecurringAppointment r_appointment = item as RecurringAppointment;
						info = "RecurringAppointment\t" + r_appointment.Start.ToLongDateString() + "\t" + r_appointment.Start.ToLongTimeString() + "\t" + r_appointment.Length + "\t" + r_appointment.Subject + "\t" + r_appointment.Location + "\t" + r_appointment.NumberOfRecurrence + "\t" + r_appointment.RecurrenceFrequency.ToString();
						if (info.CompareTo(line) == 0)
						{
							load.Close();
							load = null;
							save = new StreamWriter("appointments.txt");
							line = "";
							save.WriteLine(line);
							save.Close();
							save = null;
							load = new StreamReader("appointments.txt");
						}
					}
					line = load.ReadLine();
				}
			}
			catch
			{
				load.Close();
				load = null;
			}
			load.Close();
			load = null;
			return list.Remove(item);
		}


		/// <summary>
		/// Gets a value indicating whether [read only].
		/// </summary>
		/// <value>
		///   <c>true</c> if [read only]; otherwise, <c>false</c>.
		/// </value>
		/// <exception cref="NotImplementedException"></exception>
		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}
	}
}

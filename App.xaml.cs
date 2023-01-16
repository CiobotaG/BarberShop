using BarberShop.Data;
using System.IO;
using System;


namespace BarberShop;

public partial class App : Application
{
    static AppointmentDatabase database;
    public static AppointmentDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               AppointmentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Appointment.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

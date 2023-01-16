using BarberShop.Models;

namespace BarberShop;

public partial class AppointmentPageEntry : ContentPage
{
	public AppointmentPageEntry()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetShopListsAsync();
    }
    async void OnAppointmentAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppointmentPage
        {
            BindingContext = new Appointment()
        });
    }
    async void OnAppointmentViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AppointmentPage
            {
                BindingContext = e.SelectedItem as Appointment
            });
        }
    }
}
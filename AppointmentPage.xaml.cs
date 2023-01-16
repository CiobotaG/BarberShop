using BarberShop.Models;

namespace BarberShop;

public partial class AppointmentPage : ContentPage
{
	public AppointmentPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var alist = (Appointment)BindingContext;
        alist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(alist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var alist = (Appointment)BindingContext;
        await App.Database.DeleteShopListAsync(alist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HaircutPage((Appointment)
       this.BindingContext)
        {
            BindingContext = new Haircuts()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var app = (Appointment)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(app.ID);
    }

}
using BarberShop.Models;

namespace BarberShop;

public partial class HaircutPage : ContentPage
{
    Appointment app;
    public HaircutPage(Appointment ap)
    {
        InitializeComponent();
        app = ap;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var haircut = (Haircuts)BindingContext;
        await App.Database.SaveProductAsync(haircut);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var haircut = (Haircuts)BindingContext;
        await App.Database.DeleteProductAsync(haircut);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Haircuts h;
        if (listView.SelectedItem != null)
        {
            h = listView.SelectedItem as Haircuts;
            var lh = new ListHaircut()
            {
                AppointmentID = app.ID,
                HaircutID = h.ID
            };
            await App.Database.SaveListProductAsync(lh);
            h.ListHaircuts = new List<ListHaircut> { lh };
            await Navigation.PopAsync();
        }

    }
}
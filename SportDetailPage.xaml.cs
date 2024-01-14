namespace SalaMobile;
using SalaMobile.Models;

public partial class SportDetailPage : ContentPage
{
    private Sport currentSport;

    public SportDetailPage(Sport sport)
    {
        InitializeComponent();
        currentSport = sport;
        BindingContext = currentSport;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SportEntryPage(currentSport));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sterge Sport", "Esti sigur ca vrei sa stergi acest sport?", "Da", "Nu");

        // if (isUserConfirmed)
        {
            await App.Database.DeleteSportAsync(currentSport);
            await Navigation.PopAsync();
        }
    }
}
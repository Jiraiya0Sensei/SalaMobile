namespace SalaMobile;
using SalaMobile.Models;

public partial class SportEntryPage : ContentPage
{
    private Sport currentSport;

    public SportEntryPage()
    {
        InitializeComponent();
        currentSport = new Sport();
    }

    public SportEntryPage(Sport sport)
    {
        InitializeComponent();
        currentSport = sport;
        LoadSportDetails();
    }

    private void LoadSportDetails()
    {
        denumireEntry.Text = currentSport.Denumire;
        
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentSport.Denumire = denumireEntry.Text;
        

        await App.Database.SaveSportAsync(currentSport);
        await DisplayAlert("Success", "Sport saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}
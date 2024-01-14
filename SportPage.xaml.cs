namespace SalaMobile;
using SalaMobile.Models;

public partial class SportPage : ContentPage
{
    public SportPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadSporturi();
    }

    private async void LoadSporturi()
    {
        try
        {
            List<Sport> sporturi = await App.Database.GetSportAsync();
            sportListView.ItemsSource = sporturi;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la încărcarea clienților: {ex.Message}");
        }
    }

    private async void OnAddSportClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SportEntryPage());
    }

    private async void OnSportSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Sport selectedSport)
        {
            await Navigation.PushAsync(new SportDetailPage(selectedSport));
            sportListView.SelectedItem = null;
        }
    }
}
namespace SalaMobile;
using SalaMobile.Models;

public partial class AntrenorPage : ContentPage
{
    public AntrenorPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadAntrenorii();
    }

    private async void LoadAntrenorii()
    {
        try
        {
            List<Antrenor> antrenorii = await App.Database.GetAntrenorAsync();
            AntrenorListView.ItemsSource = antrenorii;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la încărcarea clienților: {ex.Message}");
        }
    }

    private async void OnAddAntrenorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AntrenorEntryPage());
    }

    private async void OnAntrenorSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Antrenor selectedAntrenor)
        {
            await Navigation.PushAsync(new AntrenorDetailPage(selectedAntrenor));
            AntrenorListView.SelectedItem = null;
        }
    }
}
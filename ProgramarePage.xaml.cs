namespace SalaMobile;
using SalaMobile.Models;
using SalaMobile.Data;
using Microsoft.Maui.Controls;


public partial class ProgramarePage : ContentPage
{
    public ProgramarePage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProgramari();
    }

    private async void LoadProgramari()
    {
        List<Programare> programari = await App.Database.GetProgramareAsync();
        programareListView.ItemsSource = programari;
    }

    private async void OnAddProgramareClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramareEntryPage());
    }

    private async void OnProgramareSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Programare selectedProgramare)
        {
            await Navigation.PushAsync(new ProgramareDetailPage(selectedProgramare));
            programareListView.SelectedItem = null;
        }
    }
}
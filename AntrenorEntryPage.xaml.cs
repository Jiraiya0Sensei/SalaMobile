namespace SalaMobile;
using SalaMobile.Models;

public partial class AntrenorEntryPage : ContentPage
{
    private Antrenor currentAntrenor;

    public AntrenorEntryPage()
    {
        InitializeComponent();
        currentAntrenor = new Antrenor();
    }

    public AntrenorEntryPage(Antrenor antrenor)
    {
        InitializeComponent();
        currentAntrenor = antrenor;
        LoadAntrenorDetails();
    }

    private void LoadAntrenorDetails()
    {
        numeEntry.Text = currentAntrenor.Nume;
        emailEntry.Text = currentAntrenor.Email;
        telefonEntry.Text = currentAntrenor.Telefon;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentAntrenor.Nume = numeEntry.Text;
        currentAntrenor.Email = emailEntry.Text;
        currentAntrenor.Telefon = telefonEntry.Text;

        await App.Database.SaveAntrenorAsync(currentAntrenor);
        await DisplayAlert("Success", "Antrenor saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}
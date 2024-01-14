namespace SalaMobile;
using SalaMobile.Models;

public partial class ClientEntryPage : ContentPage
{
    public Client currentClient;

    public ClientEntryPage()
    {
        InitializeComponent();
        currentClient = new Client();
    }

    public ClientEntryPage(Client client)
    {
        InitializeComponent();
        currentClient = client;
        LoadClientDetails();
    }

    private void LoadClientDetails()
    {
        if (currentClient != null)
        {
            numeEntry.Text = currentClient.Nume;
            prenumeEntry.Text = currentClient.Prenume;
            emailEntry.Text = currentClient.Email;
            telefonEntry.Text = currentClient.Telefon;
        }

    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentClient.Nume = numeEntry.Text;
        currentClient.Prenume = prenumeEntry.Text;
        currentClient.Email = emailEntry.Text;
        currentClient.Telefon = telefonEntry.Text;

        await App.Database.SaveClientAsync(currentClient);
        await DisplayAlert("Success", "Client saved successfully!", "OK");
        await Navigation.PopAsync();
    }


}
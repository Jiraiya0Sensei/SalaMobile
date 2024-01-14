namespace SalaMobile;
using SalaMobile.Models;
using SalaMobile.Data;

public partial class AntrenorDetailPage : ContentPage
{
    private Antrenor currentAntrenor;

    public AntrenorDetailPage(Antrenor antrenor)
    {
        InitializeComponent();

        currentAntrenor = antrenor;
        BindingContext = currentAntrenor;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AntrenorEntryPage(currentAntrenor));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sterge Antrenor", "Esti sigur ca vrei sa stergi acest antrenor?", "Da", "Nu");
        await App.Database.DeleteAntrenorAsync(currentAntrenor);
        await Navigation.PopAsync();

    }
}
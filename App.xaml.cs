namespace SalaMobile;
using System;
using SalaMobile.Data;
using System.IO;

public partial class App : Application
{
    static Programari database;
    public static Programari Database
    {
        get
        {
            if (database == null)
            {
                try
                {
                    database = new Programari(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programari.db3"));
                }
                catch (Exception ex)
                {
                    // Afisează mesajul de eroare în consolă sau într-un fișier de log
                    Console.WriteLine($"Error initializing database: {ex.Message}");
                    throw; // Relansează excepția pentru a anunța codul apelant despre problemă
                }
            }
            return database;
        }
    }
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}

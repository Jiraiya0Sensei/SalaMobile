using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaMobile.Models;

namespace SalaMobile.Data
{
    public class Programari
    {
        readonly SQLiteAsyncConnection _database;
        public Programari(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Client>().Wait();
                _database.CreateTableAsync<Programare>().Wait();
                _database.CreateTableAsync<Sport>().Wait();
                _database.CreateTableAsync<Antrenor>().Wait();
            }
            catch (Exception ex)
            {
                // Gestionarea excepțiilor aici
                Console.WriteLine($"Error initializing database: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Programare>> GetProgramareAsync()
        {
            try
            {
                return await _database.Table<Programare>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Afisează mesajul de eroare în consolă sau într-un fișier de log
                Console.WriteLine($"Error getting programari: {ex.Message}");
                throw; // Relansează excepția pentru a anunța codul apelant despre problemă
            }
        }

        public Task<Programare> GetProgramareAsync(int id)
        {
            return _database.Table<Programare>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Client>> GetClientAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<List<Antrenor>> GetAntrenorAsync()
        {
            return _database.Table<Antrenor>().ToListAsync();
        }


        public Task<int> SaveProgramareAsync(Programare programare)
        {
            if (programare.ID != 0)
            {
                return _database.UpdateAsync(programare);
            }
            else
            {
                return _database.InsertAsync(programare);
            }
        }

        public Task<int> DeleteProgramareAsync(Programare programare)
        {
            return _database.DeleteAsync(programare);
        }

        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientAsync(int id)
        {
            return _database.Table<Client>()
                            .Where(i => i.ClientID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ClientID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }

        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }



       

        public Task<Antrenor> GetAntrenorAsync(int id)
        {
            return _database.Table<Antrenor>()
                            .Where(i => i.AntrenorID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAntrenorAsync(Antrenor antrenor)
        {
            if (antrenor.AntrenorID != 0)
            {
                return _database.UpdateAsync(antrenor);
            }
            else
            {
                return _database.InsertAsync(antrenor);
            }
        }

        public Task<int> DeleteAntrenorAsync(Antrenor antrenor)
        {
            return _database.DeleteAsync(antrenor);
        }


        public Task<List<Sport>> GetSportAsync()
        {
            return _database.Table<Sport>().ToListAsync();
        }

        public Task<List<Sport>> GetSportsAsync()
        {
            return _database.Table<Sport>().ToListAsync();
        }

        public Task<Sport> GetSportAsync(int id)
        {
            return _database.Table<Sport>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSportAsync(Sport sport)
        {
            if (sport.ID != 0)
            {
                return _database.UpdateAsync(sport);
            }
            else
            {
                return _database.InsertAsync(sport);
            }
        }

        public Task<int> DeleteSportAsync(Sport sport)
        {
            return _database.DeleteAsync(sport);
        }

    }
}




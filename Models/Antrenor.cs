using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace SalaMobile.Models
{
    public class Antrenor
    {
        [PrimaryKey, AutoIncrement]
        public int AntrenorID { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ICollection<Programare> Programari { get; set; }
    }
}

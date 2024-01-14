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
    [Table("Client")]
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ClientID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula.")]
        public string Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        public string Prenume { get; set; }

        [Display(Name = "Nume Client")]
        public string NumeClient => $"{Nume} {Prenume}";

        public string Email { get; set; }

        [RegularExpression(@"^0[0-9]{2}[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie să înceapă cu 0 și să fie de forma '072-123-123' sau '072.123.123' sau '072 123 123'")]
        public string Telefon { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ICollection<Programare> Programari { get; set; }
    }
}

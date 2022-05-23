using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;

namespace LogisticHelper.Models
{
    public class Uzytkownik
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NAZWISKO { get; set; }
        [Required]
        public string IMIE { get; set; }
        [Required]
        public DateTime DATA_URODZENIA { get; set; }
        [Required]
        public string MAIL { get; set; }

        public string TELEFON { get; set; }

    }
}

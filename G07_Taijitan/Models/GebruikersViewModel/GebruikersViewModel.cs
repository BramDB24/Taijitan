using G07_Taijitan.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.GebruikersViewModel
{
    /* change at 2402 added email  */
    public class GebruikersViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Naam mag niet langer dan 50 tekens zijn")]
        [Display(Name = "Geef de nieuwe naam in")]
        public string Naam { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Voornaam mag niet langer dan 50 tekens zijn")]
        [Display(Name = "Geef de niewe voornaam in")]
        public string Voornaam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geef de nieuwe geboortedatum in")]
        public DateTime GeboorteDatum { get; set; }

        [Required]
        [Display(Name = "Geef het nieuwe adres in")]
        public string Adres { get; set; }

        [Required]
        [Display(Name = "Geef het nieuwe telefoonnummer in")]
        [RegularExpression("[0,4|5]{2}[0-9]{7,8}", ErrorMessage ="Telefoonnumer is niet correct")]
        public string Telefoonnummer { get; set; }

        [Required]
        [Display(Name = "Geef je nieuwe e-mail in")]
        [DataType(DataType.EmailAddress)]
        [StringLength(150,ErrorMessage = "E-mail mag niet langer dan 150 tekens zijn")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$", ErrorMessage ="Email is niet correct")]
        public string Email { get; set; }

        public GebruikersViewModel(Gebruiker gebruiker)
        {
            Naam = gebruiker.Naam;
            Voornaam = gebruiker.Voornaam;
            GeboorteDatum = gebruiker.Geboortedatum;
            Adres = gebruiker.Adres;
            Telefoonnummer = gebruiker.Telefoonnummer;
            Email = gebruiker.Email;
        }

        public GebruikersViewModel() {

        }

    }
}

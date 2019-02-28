﻿using G07_Taijitan.Models.Domain;
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
        [Required(ErrorMessage ="De achternaam mag niet leeg gelaten worden")]
        [StringLength(50, ErrorMessage = "De achternaam mag niet langer dan 50 karakters zijn")]
        [Display(Name = "Achternaam")]
        public string Naam { get; set; }

        [Required(ErrorMessage ="De voornaam mag niet leeg gelaten worden")]
        [StringLength(50, ErrorMessage = "Voornaam mag niet langer dan 50 tekens zijn")]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage ="De geboortedatum mag niet leeg gelaten worden")]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime GeboorteDatum { get; set; }

        [Required(ErrorMessage ="Het adres mag niet leeg gelaten worden")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage ="Het telefoonnummer mag niet leeg gelaten worden")]
        [Display(Name = "Telefoonnummer")]
        [RegularExpression("[0,4|5]{2}[0-9]{7,8}", ErrorMessage ="Telefoonnumer is niet correct")]
        public string Telefoonnummer { get; set; }

        [Required(ErrorMessage = "Het e-mailadres mag niet leeg gelaten worden")]
        [Display(Name = "E-mail")]
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

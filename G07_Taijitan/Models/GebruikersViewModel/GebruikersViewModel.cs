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
        [Required]
        [Display(Name = "Geef indien u van naam wilt veranderen de nieuwe naam in")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Geef indien u van voornaam wilt veranderen de niewe voornaam in")]
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
        //verdere checks nodig?
        [RegularExpression(@"[0-9]{9,10}", ErrorMessage ="Telefoonnumer is niet correct")]
        public string Telefoonnummer { get; set; }

        [Required]
        [Display(Name = "Geef je nieuwe e-mail in")]
        [DataType(DataType.EmailAddress)]
        //nodig?
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$", ErrorMessage ="Email is niet correct")]
        //@"[A-Za-z0-9]*@[A-Za-z]*.[A-Za-z]{2,4}"
        public string Email { get; set; }

        public GebruikersViewModel(Gebruiker gebruiker)
        {
            Naam = gebruiker.Naam;
            Voornaam = gebruiker.Voornaam;
            GeboorteDatum = gebruiker.Geboortedatum;
            Adres = gebruiker.Adres;
            Telefoonnummer = gebruiker.Telefoonnummer;
            //geen email adres nodig om te registreren?
            //just mockupdata atm - to be replaced
            Email = gebruiker.Email;
        }

        public GebruikersViewModel() {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using G07_Taijitan.Controllers;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Tests.Data;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using G07_Taijitan.Models.GebruikersViewModel;

namespace G07_Taijitan.Tests.Controllers
{
    public class GebruikerControllerTest
    {
        private readonly GebruikerController _controller;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IGebruikerRepository> _gebruikersRepository;


        public GebruikerControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _gebruikersRepository = new Mock<IGebruikerRepository>();
            _controller = new GebruikerController(_gebruikersRepository.Object);

        }

        #region Index
        [Fact]
        public void Index_GebruikersAanwezig_GeeftGeordendeLijstVanGebruikersDoorViaViewModel()
        {
            _gebruikersRepository.Setup(v => v.GetAllGebruikers()).Returns(_dummyContext.Gebruikers);
            ViewResult actionresult = _controller.Index() as ViewResult;
            var gebruikers = actionresult?.Model as IEnumerable<Gebruiker>;
            Assert.Equal(2, gebruikers.Count());
        }
        #endregion

        #region Edit
        [Theory]
        [InlineData("Scheirlinckx", "Scheirlinckx", "Lowie", "Adres 123", "054999999", "Lowiescheirlinckx@hotmail.com", "26/09/1998", 2)]
        public void Edit_GebruikerAanwezig_NaamIsAangepast(string naamVoorWijziging, string naam, string voornaam, string adres, string telefoonnummer, string email, string geboorteDatum , int graad)
        {
            Gebruiker aangepasteUser = new Gebruiker
            {
                Gebruikersnaam = naam,
                Naam = voornaam,
                Adres = adres,
                Email = email,
                Telefoonnummer = telefoonnummer,
                Geboortedatum = DateTime.Parse(geboorteDatum),
                Graad = graad
            };

            
            _gebruikersRepository.Setup(v => v.GetByGebruikernaam(naam)).Returns(_dummyContext.Gebruikers.FirstOrDefault(t => t.Gebruikersnaam.Equals(naam)));

            GebruikersViewModel gvm = new GebruikersViewModel(aangepasteUser);
            _controller.Edit(naamVoorWijziging, gvm);
            Assert.Equal(_gebruikersRepository.Object.GetByGebruikernaam(naam),aangepasteUser);
        }

        #endregion




    }
}

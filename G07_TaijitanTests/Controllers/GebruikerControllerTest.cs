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
            _gebruikersRepository.Setup(v => v.GetAllGebruikers()).Returns(_dummyContext.Gebruikers);
            _gebruikersRepository.Setup(t => t.GetByGebruikernaam("gebruikersnaam")).Returns(_dummyContext._gebruiker1);

            _controller = new GebruikerController(_gebruikersRepository.Object);
            
        }

        #region Index
        [Fact]
        public void Index_GebruikersAanwezig_GeeftGeordendeLijstVanGebruikersDoorViaViewModel()
        {
            //_gebruikersRepository.Setup(v => v.GetAllGebruikers()).Returns(_dummyContext.Gebruikers);
            ViewResult actionresult = _controller.Index() as ViewResult;
            var gebruikers = actionresult?.Model as IEnumerable<Gebruiker>;
            Assert.Equal(2, gebruikers.Count());
        }
        #endregion

        #region Edit
        [Fact]
        public void Edit_Gebruiker_GebruikerNaamIsAangepast()
        {
            //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker2);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
            {
                Naam = "De Bleecker Edit"
            };
            _controller.Edit("gebruikersnaam", gebruikerEvm);
            Gebruiker bram = _dummyContext._gebruiker1;
            Assert.Equal("De Bleecker Edit", bram.Naam);
            _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Once());
        }

        [Fact]
        public void Edit_Gebruiker_GebruikerAdresIsAangepast()
        {
            //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker2);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
            {
                Adres = "Adres Edit 154"
            };
            _controller.Edit("gebruikersnaam", gebruikerEvm);
            Gebruiker bram = _dummyContext._gebruiker1;
            Assert.Equal("Adres Edit 154", bram.Adres);
            _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Once());
        }

        //[Theory]
        //[InlineData("string")] //woord, mist @ gedeelte
        //[InlineData("12345")] //getal, mist @ gedeelte
        //[InlineData("string@string")] //geen .be ofzo
        //[InlineData("@string@string.be")] //meerdere @ in emailadres
        //[InlineData("string@string.stringstringstring")] //te lange string achter punt
        //public void EditHttpPost_Gebruiker_GebruikerEmailIsFout(string email)
        //{
        //    //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("gebruikersnaam")).Returns(_dummyContext._gebruiker3);
        //    GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
        //    {
        //        Email = email
        //    };
        //    _controller.Edit("gebruikersnaam", gebruikerEvm);
        //    Gebruiker johanna = _dummyContext._gebruiker1;
        //    // Assert.Throws<ArgumentException>( () => );
        //    Assert.Equal("jonah.desmet@hotmail.com", johanna.Email);
        //    _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Never());
        //}

        [Fact] //magnietwerken
        public void Edit_InvalidEdit_ReturnActionMethode()
        {
            //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker2);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
            {
                Telefoonnummer = "047"
            };
            RedirectToActionResult action = _controller.Edit("gebruikersnaam", gebruikerEvm) as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
        }
        #endregion
        #region Edit --get
        [Fact] 
        public void Edit_NonExistingUser_ReturnNotFound()
        {
            //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns((Gebruiker)null);
            IActionResult action = _controller.Edit("onbestaandeuser");
            Assert.IsType<NotFoundResult>(action);
        }
        #endregion


    }
}



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
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
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
            _gebruikersRepository.Setup(t => t.GetByGebruikernaam("jonah.desmet")).Returns(_dummyContext._gebruiker1);
            _controller = new GebruikerController(_gebruikersRepository.Object);

        }

        #region Index
        [Fact]
        public void Index_GebruikersAanwezig_GeeftGeordendeLijstVanGebruikersDoorViaViewModel()
        {
            //_gebruikersRepository.Setup(v => v.GetAllGebruikers()).Returns(_dummyContext.Gebruikers);
            ViewResult actionresult = _controller.Index() as ViewResult;
            var gebruikers = actionresult?.Model as IEnumerable<Gebruiker>;
            Assert.Equal(2,gebruikers.Count());
        }
        #endregion


        #region Edit - HttpPost
        [Fact]
        public void Edit_Gebruiker_GebruikerNaamIsAangepast()
        {
            //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker2);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
            {
                Naam = "De Bleecker Edit"
            };
            _controller.Edit(_dummyContext._gebruiker1, gebruikerEvm);
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
            _controller.Edit(_dummyContext._gebruiker1, gebruikerEvm);
            Gebruiker bram = _dummyContext._gebruiker1;
            Assert.Equal("Adres Edit 154", bram.Adres);
            _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Once());
        }

        [Fact]
        public void Edit_InvalidEdit_DataWordtNietGeupdate()
        {
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
            {
                Telefoonnummer = ""
            };
            Gebruiker jonah = _dummyContext._gebruiker1;
            Assert.Equal("0478001144", jonah.Telefoonnummer);
        }

        [Fact]
        public void Edit_InvalidEditModelStateError_DataWordtNietGeupdate()
        {
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker1)
            {
                Voornaam = ""
            };
            _controller.ModelState.AddModelError("", "Error message");
            ViewResult result = _controller.Edit(_dummyContext._gebruiker1, gebruikerEvm) as ViewResult;
            Assert.Equal("Jonah", _dummyContext._gebruiker1.Voornaam);

        }
        #endregion

        #region Edit --get

        [Fact]
        public void Edit_GeeftGebruikerMeeAanViewModel()
        {
            IActionResult action = _controller.Edit(_dummyContext._gebruiker1);
            GebruikersViewModel vm = (action as ViewResult)?.Model as GebruikersViewModel;
            Assert.Equal("Jonah", vm?.Voornaam);
        }

        [Fact]
        public void Edit_NonExistingUser_ReturnNotFound()
        {
            //_gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns((Gebruiker)null);
            var action = _controller.Edit(null);
            Assert.IsType<NotFoundResult>(action);
        }
        #endregion


    }
}



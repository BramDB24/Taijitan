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
        [Fact]
        public void Edit_Gebruiker_GebruikerNaamIsAangepast()
        {
            _gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker2);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker2)
            {
                Naam = "De Bleecker Edit"
            };
            _controller.Edit("string", gebruikerEvm);
            Gebruiker bram = _dummyContext._gebruiker2;
            Assert.Equal("De Bleecker Edit", bram.Naam);
            _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Once());
        }

        [Fact]
        public void Edit_Gebruiker_GebruikerAdresIsAangepast()
        {
            _gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker2);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker2)
            {
                Adres = "Adres Edit 154"
            };
            _controller.Edit("string", gebruikerEvm);
            Gebruiker bram = _dummyContext._gebruiker2;
            Assert.Equal("Adres Edit 154", bram.Adres);
            _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Once());
        }

        [Theory]
        [InlineData("string")] //woord, mist @ gedeelte
        [InlineData("12345")] //getal, mist @ gedeelte
        [InlineData("string@string")] //geen .be ofzo
        [InlineData("@string@string.be")] //meerdere @ in emailadres
        [InlineData("string@string.stringstringstring")] //te lange string achter punt
        public void Edit_Gebruiker_GebruikerEmailIsFout(string email)
        {
            _gebruikersRepository.Setup(t => t.GetByGebruikernaam("string")).Returns(_dummyContext._gebruiker3);
            GebruikersViewModel gebruikerEvm = new GebruikersViewModel(_dummyContext._gebruiker3)
            {
                Email = email
            };
            _controller.Edit("string", gebruikerEvm);
            Gebruiker johanna = _dummyContext._gebruiker3;
            Assert.Throws<ArgumentException>( () => );
            _gebruikersRepository.Verify(t => t.SaveChanges(), Times.Never());
        }
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using G07_Taijitan.Controllers;
using G07_Taijitan.Models.Domain;
using Moq;
using Xunit;

namespace G07_Taijitan.Tests.Controllers
{
    public class GebruikerControllerTest
    {
        private readonly GebruikerController _controller;
        private readonly Mock<IGebruikerRepository> _gebruikersRepository;


        public GebruikerControllerTest()
        {
            _gebruikersRepository = new Mock<IGebruikerRepository>();
        }

        #region Index
        [Fact]
        public void Index_GebruikersAantalIsNotNull()
        {
            _gebruikersRepository.Setup(v => v.GetGetAllGebruikers()).Returns();
        }
        #endregion
    }
}

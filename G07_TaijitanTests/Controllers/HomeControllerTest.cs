using G07_Taijitan.Controllers;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using G07_Taijitan.Models.Domain.RepoInterface;
using Xunit;
using G07_Taijitan.Models.Domain.Gebruiker;

namespace G07_Taijitan.Tests.Controllers
{
    public class HomeControllerTest
    {
        private readonly HomeController _controller;
        private readonly DummyApplicationDbContext _dummyContext;

        public HomeControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _controller = new HomeController();
        }
        #region KeuzeScherm
        [Fact]
        public void KeuzeScherm_LesgeverIsAangemeld_EenSchermWordtGetoondVoorDeLesgever()
        {
            Gebruiker user = _dummyContext._gebruiker2;
            var result = _controller.KeuzeScherm(user);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void KeuzeScherm_LidIsAangemeld_ErWordtGeenSpeciaalSchermGetoond()
        {
            Gebruiker user = _dummyContext._gebruiker1;
            var result = _controller.KeuzeScherm(user);
            Assert.IsType<RedirectToActionResult>(result);
        }
        #endregion


    }
}

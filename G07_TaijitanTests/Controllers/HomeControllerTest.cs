using G07_Taijitan.Controllers;
using G07_Taijitan.Models.Domain;
using G07_Taijitan.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace G07_Taijitan.Tests.Controllers
{
    public class HomeControllerTest
    {
        private readonly HomeController _controller;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IOefeningRepository> _oefeningRepository;
        private readonly Mock<IGebruikerRepository> _gebruikerRepository;

        public HomeControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _oefeningRepository = new Mock<IOefeningRepository>();
            _gebruikerRepository = new Mock<IGebruikerRepository>();
            _controller = new HomeController(_gebruikerRepository.Object, _oefeningRepository.Object);
        }
        #region Index
        [Fact]
        public void Index_GebruikerZijnGraad_ViewDataIsNietNull()
        {
            var result = _controller.Index() as ViewResult;
            ViewDataDictionary viewData = result.ViewData;
            Assert.True(viewData["Graad"] != null);
        }
        #endregion

        #region Oefening -HttpGet
        [Fact]
        public void Oefening_CorrecteOefening_DeCorrecteOefeningIsIngeladenInDeView()
        {
            var oefening = _oefeningRepository.Setup(t => t.GetByGraad(1)).Returns(_dummyContext.Oefeningen);
            var result = _controller.Oefeningen(1) as ViewResult;
            

        }
        #endregion

    }
}

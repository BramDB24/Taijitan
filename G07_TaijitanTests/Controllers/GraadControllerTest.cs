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
    public class GraadControllerTest
    {
        private readonly GraadController _controller;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IOefeningRepository> _oefeningRepository;
        private readonly Mock<IGebruikerRepository> _gebruikerRepository;
        
        public GraadControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _oefeningRepository = new Mock<IOefeningRepository>();
            _gebruikerRepository = new Mock<IGebruikerRepository>();
            _controller = new GraadController(_oefeningRepository.Object);            
        }

        #region Index
        [Fact]
        public void Index_GebruikerZijnGraad_ViewDataIsNietNull()
        {
            Gebruiker gebruiker = _dummyContext._gebruiker1;
            var result = _controller.Index(gebruiker) as ViewResult;
            ViewDataDictionary viewData = result.ViewData;
            Assert.True(viewData["HuidigeGraad"] != null);
        }
        #endregion

        #region Oefening -HttpGet
        [Fact]
        public void Oefening_CorrecteOefening_DeCorrecteOefeningIsIngeladenInDeView()
        {
            var oefening = _oefeningRepository.Setup(t => t.GetByGraadAndType(1, 1)).Returns(_dummyContext.Oefeningen);
            var result = _controller.Oefening(1, 1) as ViewResult;
            

        }
        #endregion

    }
}

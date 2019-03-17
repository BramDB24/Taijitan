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
using System.Linq;

namespace G07_Taijitan.Tests.Controllers
{
    public class GraadControllerTest
    {
        private readonly GraadController _controller;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IOefeningRepository> _mockOefeningRepository;
        //private readonly Mock<IGebruikerRepository> _gebruikerRepository;
        private readonly Gebruiker _gebruiker;
        private readonly Oefening _oefening;
        private readonly OefeningType _type;
        private readonly Graad _graad;
        private readonly int _ongeldigeGraad;
        
        
        public GraadControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _mockOefeningRepository = new Mock<IOefeningRepository>();
            //_gebruikerRepository = new Mock<IGebruikerRepository>();
            _controller = new GraadController(_mockOefeningRepository.Object);
            _gebruiker = _dummyContext._gebruiker1;
            _oefening = _dummyContext._oefening1;
            _type = _oefening.OefeningType;
            _graad = _oefening.Graad;
            _ongeldigeGraad = (int)_graad + 1;
            _mockOefeningRepository.Setup(p => p.GetByGraadAndType((int)_graad, (int)_type)).Returns(_dummyContext.Oefeningen);
            _mockOefeningRepository.Setup(p => p.GetBy(_oefening.OefeningId)).Returns(_dummyContext._oefening1);
        }

        #region Index
        [Fact]
        public void Index_GebruikerZijnGraad_ViewDataIsHuidigeGraad()
        {   
            var result = _controller.Index(_gebruiker) as ViewResult;
            ViewDataDictionary viewData = result.ViewData;
            Assert.True((Graad)viewData["HuidigeGraad"] == _gebruiker.Graad);
        }


        [Fact]
        public void Index_ToontBeschikbareGraden() {
            var result = _controller.Index(_gebruiker) as ViewResult;
            List<Graad> graden = (result?.Model as IEnumerable<Graad>)?.ToList();
            Assert.Equal(2, graden.Count);
            Assert.Equal(Graad.Kyu6, graden[0]);
            Assert.Equal(Graad.Kyu5, graden[1]);            
        }
        #endregion

        #region OefeningType HttpGet

        [Fact]
        public void OefeningType_ToontBeschikbareOefeningTypes() {
            var result = _controller.OefeningType((int)_graad) as ViewResult;
            List<OefeningType> oefeningTypes = (result?.Model as IEnumerable<OefeningType>)?.ToList();
            List<OefeningType> enumvalues = Enum.GetValues(typeof(OefeningType)).Cast<OefeningType>().ToList();
            Assert.Equal(enumvalues, oefeningTypes);
        }

        #endregion


        #region Oefening HttpGet
        [Fact]
        public void Oefening_CorrecteOefening_DeCorrecteOefeningIsIngeladenInDeView()
        {   
            var result = _controller.Oefening(_gebruiker, (int)_graad, (int)_type) as ViewResult;
            List<Oefening> oefeningen = (result?.Model as IEnumerable<Oefening>)?.ToList();
            Assert.Equal(2, oefeningen.Count);
            Assert.Equal("Vallen", oefeningen[0].Naam);
            Assert.Equal("Slaan", oefeningen[1].Naam);
            Assert.Equal(Graad.Kyu4, oefeningen[0].Graad);
            Assert.Equal(Graad.Kyu4, oefeningen[1].Graad);
        }

        [Fact]
        public void Oefening_OngeldigeGraad_ReturnsNotFound() {
            var result = _controller.Oefening(_gebruiker, _ongeldigeGraad, (int)_type);
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion


        //structuur nog niet helemaal duidelijk
        #region Lesmateriaal HttpGet
        [Fact]
        public void Lesmateriaal_GeldigOefeningId_ToontCorrecteVideomateriaal() {
            //wip
        }

        [Fact]
        public void LesMateriaal_OngeldigOefeningId_Toont404Page() {
            //wip
        }

        [Fact]
        public void LesMateriaal_OefeningNietBeschikbaarVoorGebruikerZijnGraad_Toont404Page() {
            //wip
        }
        #endregion

    }
}

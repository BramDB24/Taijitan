using G07_Taijitan.Controllers;
using G07_Taijitan.Models.AanwezigheidslijstViewModel;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.RepoInterface;
using G07_Taijitan.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace G07_Taijitan.Tests.Controllers {
    public class AanwezigheidslijstControllerTest {
        private readonly AanwezigheidslijstController _aanwezigheidslijstController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly DateTime _vandaag = DateTime.Now.Date;

        public AanwezigheidslijstControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _aanwezigheidslijstController = new AanwezigheidslijstController(_mockSessieRepository.Object);
            _mockSessieRepository.Setup(s => s.getByDay(_vandaag)).Returns(_dummyContext._sessie1);
        }

        [Fact]
        public void Index_Default_GeeftSessieVanVandaag() {
            var result = _aanwezigheidslijstController.Index() as ViewResult;
            var sessieVm = result?.Model as SessieViewModel;
            Assert.Equal(DateTime.Now.Date, sessieVm.SessieDatum.Date);
            Assert.Single(sessieVm.Leden);
        }
    }
}

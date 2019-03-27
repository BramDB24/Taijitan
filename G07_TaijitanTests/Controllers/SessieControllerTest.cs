using G07_Taijitan.Controllers;
using G07_Taijitan.Models.Domain.RepoInterface;
using G07_Taijitan.Tests.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace G07_Taijitan.Tests.Controllers
{
    class SessieControllerTest
    {
        private readonly SessieController _controller;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<ISessieRepository> _sessieRepository;

        public SessieControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _sessieRepository = new Mock<ISessieRepository>();

        }
    }
}

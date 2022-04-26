using EFCoreCodeFirstSampleWEBAPI.BLL.Interfaces;
using EFCoreCodeFirstSampleWEBAPI.BLL.Services.SQLServices;
using EFCoreCodeFirstSampleWEBAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using EFCoreCodeFirstSampleWEBAPI.DAL.UnitOfWork;

namespace EFCoreCodeFirstSampleWEBAPI.UnitTests
{
    public class FilmsControllerTest
    {
        private readonly FilmsController _controller;
        private readonly IServiceManager _service;

        public FilmsControllerTest()
        {
            _service = new ServiceManagerFake();            
            _controller = new FilmsController(_service);
        }

        [Fact]
        public void GetAll_DataExist_ReturnsOkResult()
        {
            var Result = _controller.GetAll();

            Assert.IsType<OkObjectResult>(Result);
        }
    }
}

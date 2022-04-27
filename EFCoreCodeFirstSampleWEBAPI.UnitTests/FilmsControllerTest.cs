using EFCoreCodeFirstSampleWEBAPI.BLL.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.BLL.Interfaces;
using EFCoreCodeFirstSampleWEBAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace EFCoreCodeFirstSampleWEBAPI.UnitTests
{
    public class FilmsControllerTest
    {
        private readonly IServiceManager _service;
        private readonly FilmsController _controller;

        public FilmsControllerTest()
        {
            _service = new ServiceManagerFake();            
            _controller = new FilmsController(_service);
        }

        [Fact]
        public void GetAll_DataExist_ReturnsOkResult()
        {
            var Result = _controller.GetAll();

            Assert.IsType<OkObjectResult>(Result.Result as OkObjectResult);
        }

        [Fact]
        public void GetAll_DataExist_ReturnsAllItems()
        {
            var Result = _controller.GetAll().Result as OkObjectResult;

            var items = Assert.IsType<List<FilmsDTO>>(Result.Value);
            Assert.Equal(2, items.Count);
        }
    }
}

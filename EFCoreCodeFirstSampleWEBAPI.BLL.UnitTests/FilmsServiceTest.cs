using AutoMapper;
using EFCoreCodeFirstSampleWEBAPI.BLL.Services.SQLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstSampleWEBAPI.BLL.UnitTests.Mocks;
using EFCoreCodeFirstSampleWEBAPI.DAL.UnitOfWork;
using Moq;
using Xunit;
using EFCoreCodeFirstSampleWEBAPI.BLL.DataTransferObjects;
using EFCoreCodeFirstSampleWEBAPI.DAL.Models;
using EFCoreCodeFirstSampleWEBAPI.BLL.Exceptions;

namespace EFCoreCodeFirstSampleWEBAPI.BLL.UnitTests
{
    public class FilmsServiceTest
    {
        private readonly Mapper _mapper;
        private readonly FakeRepositoryWrapper _repoWraper;
        public FilmsServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.AddProfile<MappingProfile>()
                );
            _mapper = new Mapper(config);
            _repoWraper = new FakeRepositoryWrapper();
        }

        [Fact]
        public void GetById_ValidIdPassed_ReturnsTaskFilmsDTO()
        {
            //Arrange
            _repoWraper._films.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                          .Returns(Task.FromResult(new Films()));

            var service = new FilmsService(_repoWraper, _mapper);

            //Act
            var Result = service.GetById(1);

            //Assert
            Assert.IsType<Task<FilmsDTO>>(Result);
        }

        [Fact]
        public async Task GetById_InvalidIdPassed_ReturnsFilmsNotFoundException()
        {
            //Arrange
            Films film = null;
            _repoWraper._films.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                          .Returns(Task.FromResult(film));

            var service = new FilmsService(_repoWraper, _mapper);

            //Act + Assert            
            await Assert.ThrowsAsync<FilmsNotFoundException>(() => service.GetById(1));
        }
    }
}

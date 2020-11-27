using ChallengeTechAndSolve.Application.Contracts.IServices;
using ChallengeTechAndSolve.Application.Services;
using ChallengeTechAndSolve.Application.Unit.Tests.MockRepository;
using ChallengeTechAndSolve.Application.Unit.Tests.Stubs;
using ChallengeTechAndSolve.Business.Mappers;
using ChallengeTechAndSolve.Business.Models;
using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ChallengeTechAndSolve.Application.Unit.Tests
{
    [TestClass]
    public class RaceabilityServiceTests
    {
        ITraceabilityService _traceabilityService;
        [TestInitialize]
        public void Setup()
        {
            Mock<ITraceabilityRepository> traceabilityRepositoryMock = new RaceabilityRepositoryMock()._traceabilityRepository;
            _traceabilityService = new TraceabilityService(traceabilityRepositoryMock.Object);
        }
        [TestMethod]
        public async Task Get_receability_by_document()
        {
            var result = await _traceabilityService.GetByIdAsync("prueba");
            result.TraceabilityId.Should().Be(new Guid("57d11393-c5af-4d53-82f9-13797e13b5c4"));
        } 
        [TestMethod]
        public async Task Get_receability_by_document_two()
        {
            var result = await _traceabilityService.GetByIdAsync("1234567");
            result.TraceabilityId.Should().Be(new Guid("803cdeae-95ff-4540-8508-cdbacbb9138f"));
        }
        [TestMethod]
        public async Task AddInformation_raceability()
        {
            var result = await _traceabilityService.AddAsync(StubData.traceability_one.Map());
            result.Should().Be(0);
        }
        //[TestMethod]
        //public async Task AddRaceability()
        //{
        //    TraceabilityDto traceabilityDto = new TraceabilityDto()
        //    {
        //        TraceabilityId = Guid.NewGuid(),
        //        CreationDate = DateTime.Now,
        //        Document = "1017162355"
        //    };
        //    int operationResult = AddAsync(traceabilityDto, false).GetAwaiter().GetResult();
        //    Assert.AreEqual(1, operationResult);
        //}
        ///// <summary>
        ///// Prueba unitaria de controlar un error al insertar un registro
        ///// </summary>
        //[TestMethod]
        //public void ExceptionAdd()
        //{
        //    TraceabilityDto traceabilityDto = new TraceabilityDto();
        //    int operationResult = AddAsync(traceabilityDto, true).GetAwaiter().GetResult();
        //    Assert.AreEqual(operationResult, ((int)HttpStatusCode.InternalServerError).ToString());
        //}

        ///// <summary>
        ///// Ejecuta el llamado al metodo AddAsync
        ///// </summary>
        ///// <param name="traceabilityDto">Informacion del registro</param>
        ///// <param name="testError">Determina si la operacion del repositorio debe generar error</param>
        ///// <returns></returns>
        //private static async Task<int> AddAsync(TraceabilityDto traceabilityDto, bool testError)
        //{
        //    Mock<ITraceabilityRepository> mockTraceabilityService = new Mock<ITraceabilityRepository>();
        //    if (testError)
        //        mockTraceabilityService.Setup(p => p.AddAsync(It.IsAny<TraceabilityEntity>()))
        //            .ThrowsAsync(new Exception("Error"));

        //    ITraceabilityService traceabilityService = new TraceabilityService(mockTraceabilityService.Object);
        //    var result = await traceabilityService.AddAsync(traceabilityDto);
        //    return result;
        //}
    }
}
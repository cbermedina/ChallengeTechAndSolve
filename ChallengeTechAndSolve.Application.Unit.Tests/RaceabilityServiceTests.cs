using ChallengeTechAndSolve.Application.Contracts.IServices;
using ChallengeTechAndSolve.Application.Services;
using ChallengeTechAndSolve.Business.Models;
using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
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
        [TestMethod]
        public async Task AddRaceability()
        {
            TraceabilityDto traceabilityDto = new TraceabilityDto()
            {
                TraceabilityId = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Document = "1017162355"
            };
            int operationResult = AddAsync(traceabilityDto, false).GetAwaiter().GetResult();
            Assert.AreEqual(1, operationResult);
        }
        /// <summary>
        /// Prueba unitaria de controlar un error al insertar un registro
        /// </summary>
        [TestMethod]
        public void ExceptionAdd()
        {
            TraceabilityDto traceabilityDto = new TraceabilityDto();
            int operationResult = AddAsync(traceabilityDto, true).GetAwaiter().GetResult();
            Assert.AreEqual(operationResult, ((int)HttpStatusCode.InternalServerError).ToString());
        }

        /// <summary>
        /// Ejecuta el llamado al metodo AddAsync
        /// </summary>
        /// <param name="traceabilityDto">Informacion del registro</param>
        /// <param name="testError">Determina si la operacion del repositorio debe generar error</param>
        /// <returns></returns>
        private static async Task<int> AddAsync(TraceabilityDto traceabilityDto, bool testError)
        {
            Mock<ITraceabilityRepository> mockTraceabilityService = new Mock<ITraceabilityRepository>();
            if (testError)
                mockTraceabilityService.Setup(p => p.AddAsync(It.IsAny<TraceabilityEntity>()))
                    .ThrowsAsync(new Exception("Error"));

            ITraceabilityService traceabilityService = new TraceabilityService(mockTraceabilityService.Object);
            var result = await traceabilityService.AddAsync(traceabilityDto);
            return result;
        }
    }
}
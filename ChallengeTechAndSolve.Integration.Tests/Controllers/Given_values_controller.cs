using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChallengeTechAndSolve.Integration.Tests
{
    [TestClass]
    public class Given_values_controller
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _httpClient;
        public Given_values_controller()
        {
            _testServer = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
            _httpClient = _testServer.CreateClient();
        }
        [TestMethod]
        public async Task Giver_Participant_Identification_Should_not_null()
        {
            //Arrange
            var response = await _httpClient.GetAsync("/api/Participant/GetParticipant");
            //Assert
            Assert.IsTrue(/*(int)response.StatusCode*/200 == 200);

            //With FluentAssertions
            //response.StatusCode.Should().Be(HttpStatusCode.OK);



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using TeamService;
using TeamService.Models;
using Xunit;

namespace Bos.TeamService.Tests.Integration {
    public class SimpleIntegrationTests {
        private readonly TestServer testServer;
        private readonly HttpClient testClient;

        private readonly Team testTeam;

        public SimpleIntegrationTests()
        {
            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            testClient = testServer.CreateClient();

            testTeam = new Team()
            {
                ID = Guid.NewGuid(),
                Name = "Test Team"
            };
        }

        [Fact]
        public async void TestTeamPostAndGet()
        {
            StringContent stringContent = new StringContent(
                JsonConvert.SerializeObject(testTeam),
                UnicodeEncoding.UTF8,
                "application/json");

            // Act
            HttpResponseMessage postResponse = await testClient.PostAsync(
                "/teams",
                stringContent);
            postResponse.EnsureSuccessStatusCode();

            var getResponse = await testClient.GetAsync("/teams");
            getResponse.EnsureSuccessStatusCode();

            string raw = await getResponse.Content.ReadAsStringAsync();
            var teams = JsonConvert.DeserializeObject<List<Team>>(raw);
            Assert.Single(teams);
            Assert.Equal("Test Team", teams[0].Name);
            Assert.Equal(testTeam.ID, teams[0].ID);
        }
    }
}
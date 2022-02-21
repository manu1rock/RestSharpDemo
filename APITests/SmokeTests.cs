using System;
using System.Net;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;

namespace APITests
{
    [TestClass]
    public class SmokeTests
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        private const string BASE_URL = "https://reqres.in/";

        [ClassInitialize]
        public static void SetUpReport(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetUpReport(dir, "SmokeTest", "Smoke test result");
        }

        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }

        [TestMethod]
        public async Task GetListOfUsers()
        {
            var api = new Demo();
            var response = await api.GetUsers(BASE_URL);
            //Assert.AreEqual(2, response.page);
        }

        [DeploymentItem("Test Data")]
        [TestMethod]
        public async Task CreateNewUserTest()
        {
            var payload = HandleContent.ParseJson<CreateUserReq>("CreateUser.json");

            var api = new Demo();
            var response = await api.CreateNewUser(BASE_URL, payload);
            statusCode = response.get_StatusCode();
            var code = (int)statusCode;
            Assert.AreEqual(201, code);
            Reporter.LogToReport(Status.Pass, "201 response code is received");

            var userContent = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(payload.name, userContent.name);
        }
    }
}

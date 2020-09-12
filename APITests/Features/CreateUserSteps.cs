using ApiTesting;
using ApiTesting.Models;
using ApiTesting.Models.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using RestSharp;
using RestSharp.Extensions;
using System;
using TechTalk.SpecFlow;

namespace SmokeTests.Features
{
    [Binding]
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserModel createUserModel;
        private IRestResponse response;

        public CreateUserSteps(CreateUserModel createUserModel)
        {
            this.createUserModel = createUserModel;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            createUserModel.Name = name;
        }
        
        [Given(@"I input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            createUserModel.Job = role;
        }
        
        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var api = new Api<CreateUser>();
            response = api.createUser(BASE_URL, "api/users", createUserModel);
        }
        
        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.getContent<CreateUser>(response);
            Assert.AreEqual(createUserModel.Name, content.Name);
            Assert.AreEqual(createUserModel.Job, content.Job);
        }
    }
}

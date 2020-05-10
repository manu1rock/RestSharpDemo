using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public class Demo<T>
    {
        public ListOfUsersDTO GetUsers(string endpoint)
        {
            var user = new APIHelper<ListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOfUsersDTO content = user.GetContent<ListOfUsersDTO>(response);
            return content;
        }

        public CreateUserDTO CreateUser(string endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateUserDTO>();
            var url = user.SetUrl(endpoint);
            var jsonReq = user.Serialize(payload);
            var request = user.CreatePostRequest(jsonReq);
            var response = user.GetResponse(url, request);
            CreateUserDTO content = user.GetContent<CreateUserDTO>(response);
            return content;
        }
    }
}

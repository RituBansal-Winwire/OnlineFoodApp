using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineFoodApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace OnlineFoodApp.Services
{
    public class ServiceData
    {
        private const string URL = "https://xamfoodiesapi.azurewebsites.net/";
        private HttpClient _client = new HttpClient();
       

        public async Task<string> ValidateLogin(string uname, string pwd)
        {
            try { 
            string content = JsonConvert.SerializeObject(new { username = uname, password = pwd });
            HttpContent contentPost = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(URL + "Login", contentPost);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else {
                return null;
             }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<int> PostUserData(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
               var response = await _client.PostAsync(URL + "Login", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<User>>(content1);
                    return _ = result[0].id;
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetRestaurants(Action<IEnumerable<Restaurant>> action)
        {
            try
            {
                var response = await _client.GetAsync(URL + "/api/Restaurants");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Restaurant>>(content);
                    var list = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(await response.Content.ReadAsStringAsync());
                    action(list);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }


        public async Task<int> PostRestaurants(Restaurant restData, string type, int id=0)
        {
            var json = JsonConvert.SerializeObject(restData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = (dynamic)null;
            if (type == "POST")
            {
               response = await _client.PostAsync(URL + "/api/Restaurants", content);
               if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content1 = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Restaurant>>(content1);
                    return _ = result[0].id;
                }
            }
            else if (type == "PUT") {
                response = await _client.PutAsync(URL + "/api/Restaurants", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   return restData.id;
                }
            }
            else if (type == "DELETE")
            {
                response = await _client.DeleteAsync(URL + "/api/Restaurants/" + id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return id;
                }
            }
            
             return 0; 
           
        }

       
    }
}

using Day1APIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day1APIClient
{
    class Program
    {
        public static HttpClient client = new HttpClient();

        private static void SetUpClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://swapi.co/api/");
        }

        static People GetPeople(string id)
        {
            var response = client.GetAsync($"people/{id}").Result;
            return response.Content.ReadAsAsync<People>().Result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Star Wars");
            SetUpClient();
            // var luke = response.Content.ReadAsStringAsync().Result;
            var luke = GetPeople("3");
            Planet lukesPlanet = luke.HomeworldDetail(client);

            var allPeopleResponse = client.GetAsync("people").Result;
            PeopleCollection allPeople = allPeopleResponse.Content.ReadAsAsync<PeopleCollection>().Result;
            allPeople.GetPrevious(client); // instance
            allPeople.GetNext(client); // instance
        }
    }
}

using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Scott's Pizza",
                    Location = "Maryland",
                    Cuisine = CuisineType.Indian
                },
                 new Restaurant
                {
                    Id = 2,
                    Name = "Warehouse",
                    Location = "Constantia",
                    Cuisine = CuisineType.Mexican
                },
                  new Restaurant
                {
                    Id = 3,
                    Name = "Panarotis Pizza",
                    Location = "Claremont",
                    Cuisine = CuisineType.Mexican
                },
                   new Restaurant
                {
                    Id = 4,
                    Name = "FLM",
                    Location = "Cape Town",
                    Cuisine = CuisineType.Italian
                }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name= null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }
    }
}

using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;

namespace NancyTests
{
    public class CarModule: NancyModule
    {
        public CarModule()
        {
            //Adding a simple route
            //http://localhost:64281/status
            Get["/status"] = _ => "Hello World";

            //Simple get returning status and its parameters passed
            //http://localhost:64281/car/40
            Get["/car/{id}"] = parameters =>
            {
                int id = parameters.id;

                if (id == 32)
                    throw new CarNotFoundException();

                return Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                .WithModel(id);
            };

            //Get returning JSON
            //http://localhost:64281/ford/fiesta
            Get["/{make}/{model}"] = parameters =>
            {
                var carQuery = this.Bind<CarQuery>();

                var listOfCars = new List<Car>
                {
                    new Car
                    {
                        Id = 1,
                        Make = carQuery.Make,
                        Model = carQuery.Model
                    },
                    new Car
                    {
                        Id = 2,
                        Make = carQuery.Make,
                        Model = carQuery.Model
                    },
                    new Car
                    {
                        Id = 3,
                        Make = carQuery.Make,
                        Model = carQuery.Model
                    }
                };

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(listOfCars);
            };
        }       
    }

    public class Car {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    public class CarQuery
    {
        public string Make { get; set; }
        public string Model { get; set; }
    }

    public class CarNotFoundException : Exception
    {
        
    }
}

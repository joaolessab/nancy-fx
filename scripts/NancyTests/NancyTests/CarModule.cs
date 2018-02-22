using Nancy;

namespace NancyTests
{
    public class CarModule: NancyModule
    {
        public CarModule()
        {
            //Adding a simple route
            Get["/status"] = _ => "Hello World";

            //Simple get returning status and its parameters passed
            Get["/car/{id}"] = parameters =>
                                    {
                                        int id = parameters.id;

                                        return Negotiate
                                            .WithStatusCode(HttpStatusCode.OK)
                                            .WithModel(id);
                                    };

        }
    }
}

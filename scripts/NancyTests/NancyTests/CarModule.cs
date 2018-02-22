using Nancy;

namespace NancyTests
{
    public class CarModule: NancyModule
    {
        public CarModule()
        {
            //Adding a simple route
            Get["/status"] = _ => "Hello World";
        }
    }
}

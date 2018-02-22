using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.Text;
using Nancy.Bootstrappers.StructureMap;
using StructureMap;

namespace NancyTests
{
    public class NancyBootstrapper : StructureMapNancyBootstrapper
    {
        protected override void ApplicationStartup(IContainer container, IPipelines pipelines)
        {
            pipelines.OnError += (context, exception) =>
            {
                if (exception is CarNotFoundException)
                    //Building the response body
                    return new Response()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ContentType = "text/html",
                        Contents = (stream) =>
                        {
                            var errorMessage = Encoding.UTF8.GetBytes(exception.Message);
                            //Stream throws the content of the response
                            stream.Write(errorMessage, 0, errorMessage.Length);
                        }
                    };
                return HttpStatusCode.InternalServerError;
            };
        }
    }
}

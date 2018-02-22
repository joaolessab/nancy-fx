<p align="center">
  <img src="https://github.com/jvlessa/NancyFx--Case-Study/blob/master/images/logo.jpg" width="350">
</p>

<p align="center">This repository was created to explore the Nancy .Net framework that was created based on the Sinatra Framework for Ruby to build HTTP based services.</b></p>

## Guides
* Read their official [introduction](https://github.com/NancyFx/Nancy/blob/master/README.md);
* To see Nancy's documentation, click [here](https://github.com/NancyFx/Nancy/wiki/Documentation);
* This [Video Tutorial](https://www.youtube.com/watch?v=SJm7chCfaDs) was used to create the initial scripts for this repository;

## Installation
1 - Create a new project;

2 - Choose a blank Web application;

3 - Click on *Manage Nuget Packages*;

4 - Search for *Nancy* and click to install the package: **Nancy.Hosting.Aspnet** (it will also install **Nancy** automatically because it's a dependency);

5 - Install the **Nancy.BootStrappers.StructureMap** too;

6 - Start coding;

## Code Sample
The code below reproduces a simple GET using Nancy Framework:

```csharp
using Nancy;

namespace NancyTests
{
    public class CarModule: NancyModule
    {
        public CarModule()
        {
            //Adding a simple route
            Get["/status"] = _ => "Hello World!";
        }
    }
}
```

To return the string Hello World, open the **localhost:port/your-route** (http://localhost:64281/status)

## Working with parameters
```csharp
using Nancy;

namespace NancyTests
{
    public class CarModule: NancyModule
    {
        public CarModule()
        {
            Get["/car/{id}"] = parameters =>
            {
                int id = parameters.id;

                if (id == 32)
                    throw new CarNotFoundException();

                return Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                .WithModel(id);
            };
        }
    }
}
```

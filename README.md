# Electron_Angular_Core
Getting Started
1. Create Folders
		+-- assets - icons, images, etc.
	+-- dist - distributable files
	+-- src 
	|   +-- api - .Net Core console application
	|   +-- app - Electron + Angular
	
2. api - .Net Core console application
	Run following command inside api folder dotnet new console.
	
3. Install following package in .net core.
	Microsoft.NETCore.App
	Microsoft.AspNetCore.Mvc
	Microsoft.AspNetCore.Routing
	Microsoft.AspNetCore.Server.Kestrel
	
4.Replacing program.cs content with code bellow	


{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.DependencyInjection;

namespace api
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(options =>
               {
                   //return json format with Camel Case
                   options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
}
5. Add a ContactsController.cs file inside a folder called Controllers.

6. We need to do is to specify which runtimes we are supporting by adding the following line to the api.csproj
	<RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
	
7.  The next step, we run the restore command followed by the publish command.
		// publish for windows
		dotnet publish -r win10-x64 --output bin/dist/win
		// publish for macos
		dotnet publish -r osx.10.11-x64 --output bin/dist/osx
		
		
		
		
		
8. create angular app inside src.

9. run npm i -D electron@latest.
10. Create main.js file in angular root folder.
11. Set output path in angular.json.
		"options": {
      "outputPath": "dist",
12.  add in package.json "main": "main.js",	  
	  
11. Add in package.json
	"scripts": {
		"electron": "ng build --base-href ./ && electron .",
	
12. Run npm run electron.

---------------------------------------
#Distribution.
1.run  npm install electron-builder --save-dev
2. Add following code in package.json.
		
		 "build": {
    "appId": "cross-platform-desktop",
    "directories": {
      "buildResources": "../../assets",
      "output": "../../dist"
    },
    "extraResources": {
      "from": "../api/bin/dist/",
      "to": "api/bin/dist/",
      "filter": [
        "**/*"
      ]
    },
    "mac": {
      "category": "cross-platform-desktop"
    },
    "win": {
      "target": [
        "nsis"
      ]
    }
  }
  3. Add following line package.json  inside script
	  "dist": "electron-builder"
	  
4. Run npm run dist to create exe.

------------------------------------------
Run Application
	1. dotnet restore inside api folder using cmd opowershell.
	2. dotnet publish -r win10-x64 --output bin/dist/win inside api folder using cmd opowershell.
	3. "npm i" in angular project.
	4. "npm run electron" in angular project.
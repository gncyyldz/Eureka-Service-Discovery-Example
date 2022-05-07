using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Client;

ConfigurationManager configurationManager = new();
configurationManager.AddJsonFile("./appsettings.json");

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddConfigurationDiscoveryClient(configurationManager);
serviceCollection.AddSingleton<IConfiguration>(configurationManager);
serviceCollection.AddDiscoveryClient(configurationManager);

ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

IDiscoveryClient discoveryClient = serviceProvider.GetService<IDiscoveryClient>();
DiscoveryHttpClientHandler discoveryHttpClientHandler = new(discoveryClient);
using HttpClient httpClient = new(discoveryHttpClientHandler, false);
Console.WriteLine(await httpClient.GetStringAsync("https://BService/api/service"));

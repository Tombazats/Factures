using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Factures.Shared;

namespace Factures.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            Facture facture1 = new Facture("BAZATS", "00001", new DateTime(2020, 06, 04), new DateTime(2020, 07, 19), 104850000, 45632);
            Facture facture2 = new Facture("DURAND", "00002", new DateTime(2019, 03, 30), new DateTime(2019, 05, 15), 154650, 42132);

            BusinessData Factures = new BusinessData();

            Factures.addFacture(facture1);
            Factures.addFacture(facture2);

            builder.Services.AddSingleton<IBusinessData>(sp => new BusinessData());
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
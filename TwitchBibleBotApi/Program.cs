using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/randomverse", async () =>
{
    using var http = new HttpClient();
    var response = await http.GetStringAsync("https://bible-api.com/?random");
    var json = JObject.Parse(response);

    var reference = json["reference"]?.ToString();
    var text = json["verses"]?[0]?["text"]?.ToString();

    return $"{reference} - {text}";
});

app.Run();

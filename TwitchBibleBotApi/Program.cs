using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/randomverse", async () =>
{
    using var http = new HttpClient();
    var response = await http.GetStringAsync("https://bible-api.com/data/web/random");
    var json = JObject.Parse(response);

    var verseObj = json["random_verse"];
    var book = verseObj["book"]?.ToString();
    var chapter = verseObj["chapter"]?.ToString();
    var verse = verseObj["verse"]?.ToString();
    var text = verseObj["text"]?.ToString();

    return $"{book} {chapter}:{verse} - {text}";
});

app.Run();
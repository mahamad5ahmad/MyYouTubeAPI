using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

public class YouTubeService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = ""; // Replace with your API Key
    private readonly string _apiBaseUrl = "https://www.googleapis.com/youtube/v3/";

    public YouTubeService(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }

    public async Task<string> FetchYouTubeData(string id, string type)
    {
        string endpoint = type switch
        {
            "playlist" => "playlists",
            _ => "videos"
        };

        string url = $"{_apiBaseUrl}{endpoint}?part=snippet,statistics&id={id}&key={_apiKey}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();
        Console.WriteLine("YouTube API Response: " + json);
        return json;
        //return JObject.Parse(json);
    }
}

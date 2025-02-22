using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/youtube")]
[ApiController]
public class YouTubeController : ControllerBase
{
    private readonly YouTubeService _youtubeService;

    public YouTubeController(YouTubeService youtubeService)
    {
        _youtubeService = youtubeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetYouTubeData([FromQuery] string id, [FromQuery] string type = "video")
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest(new { error = "Missing video/playlist ID" });

        var data = await _youtubeService.FetchYouTubeData(id, type);
        return Ok(data);
    }
}

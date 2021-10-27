using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;

namespace challenge.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    [HttpGet]
    public async Task<List<GitHubRepo>> Get()
    {
      IList<GitHubRepo> lista = await "https://api.github.com/users/takenet/repos?per_page=1000"
        .WithBasicAuth("alinecamardev", "${{ secrets.TOKENAPIGITHUB }}")
        .WithHeader("Accept", "application/vnd.github.v3+json")
        .WithHeaders(new { User_Agent = "product/1" })
        .GetJsonAsync<List<GitHubRepo>>();

      return lista.Where(c => c.language == "C#").OrderBy(c => c.created_at).Take(5).ToList();
    }

  }
}

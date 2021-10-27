using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
  public class GitHubRepo
  {
    public string language { get; set; }
    public string full_name { get; set; }
    public string description { get; set; }
    public DateTime created_at { get; set; }
  }
}

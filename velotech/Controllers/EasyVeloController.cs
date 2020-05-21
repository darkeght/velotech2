using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using velotech.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace velotech.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EasyVeloController : ControllerBase
    {
        [HttpPost]
        public async Task<string> Post(Document value)
        {;

            using (var client = new HttpClient())
            {
                var stringContent = "{\"requests\":{\"image\":{\"content\": \"" + value.Content + "\"},\"features\":{\"type\":\"TEXT_DETECTION\"}}}";
                string baseURL = $"https://vision.googleapis.com/v1/images:annotate?key=AIzaSyCEW9nBHLV_C_auJE0Ez9TgcJVECpWfRkY";

                var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(baseURL, content);
                var contents = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<object>(contents).ToString();
            }
        }
    }
}

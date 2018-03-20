using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoDev.Core
{
    public class Util
    {
        public static async Task<string> GetDados(string url)
        {
            string responseString;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }

    }
}
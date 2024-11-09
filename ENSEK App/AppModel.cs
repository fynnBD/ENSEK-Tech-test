using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ENSEK_App
{

    public class AppModel
    {

        private HttpClient client;

        public void SetupAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7065/api/EnergyAccounts/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            CacheControlHeaderValue cacheControl = new CacheControlHeaderValue();
            cacheControl.NoCache = true;
            client.DefaultRequestHeaders.CacheControl = cacheControl;
        }

        public async Task<string> PostCSV(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath); //c://Temp/test.csv
            HttpContent fileContent = new ByteArrayContent(bytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");

            try
            {

                var response = client.PostAsync("meter-reading-uploads", new MultipartFormDataContent
                {
                    {fileContent, "\"file\"", "\"test.csv\""}
                });

                //response.Content = new ByteArrayContent(bytes);
                return await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

   
}

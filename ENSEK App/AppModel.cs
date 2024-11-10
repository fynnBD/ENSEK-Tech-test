using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENSEK_App
{

    public class AppModel
    {

        private HttpClient _client;
        private readonly string baseURI = "https://localhost:44330/api/EnergyAccounts/";

        public void SetupApi()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseURI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            CacheControlHeaderValue cacheControl = new CacheControlHeaderValue();
            cacheControl.NoCache = true;
            _client.DefaultRequestHeaders.CacheControl = cacheControl;
        }

        public async Task<string> PostCsv(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath); //c://Temp/test.csv
            HttpContent fileContent = new ByteArrayContent(bytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");

            try
            {

                var response = _client.PostAsync("meter-reading-uploads", new MultipartFormDataContent
                {
                    {fileContent, "\"file\"", "\"test.csv\""}
                });

                //response.Content = new ByteArrayContent(bytes);
                if(response != null)
                {
                    return await response.Result.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show(response.Result.ReasonPhrase, @"Error Occured",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error Occured",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

   
}

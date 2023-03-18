using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class UploadAccess
    {
        public static async Task<List<Upload>?> GetUpload()
        {

            List<Upload>? uploads = new List<Upload>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Uploads"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    uploads = JsonConvert.DeserializeObject<List<Upload>>(apiresponse);
                }
                return uploads;
            }
            catch
            {
                return uploads;
            }
        }
        //id
        public static async Task<List<Upload?>> GetUpload(int id)
        {
            List<Upload>? uploads = new List<Upload>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Uploads/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                uploads = JsonConvert.DeserializeObject<List<Upload>>(apiresponse);
            }
            return uploads;
        }
        public static async Task<Upload?> CreateDocument(Upload uploads)
        {
            Upload? uploadlist = new Upload();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(uploads), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Uploads", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return uploadlist;
        }
    }
}

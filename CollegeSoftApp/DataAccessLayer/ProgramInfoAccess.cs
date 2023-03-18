using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class ProgramInfoAccess
    {
        public static async Task<List<ProgramInfo>?> GetProgramInfo()
        {
            List<ProgramInfo>? programInfos = new List<ProgramInfo>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/ProgramInfoes"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    programInfos = JsonConvert.DeserializeObject<List<ProgramInfo>>(apiresponse);
                }
                return programInfos;
            }
            catch
            {
                return programInfos;
            }
        }
        //id
        public static async Task<List<PrograInfoView?>> GetProgramInfo(int id)
        {
            List<PrograInfoView>? prograInfoViews = new List<PrograInfoView>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/ProgramInfoes/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                prograInfoViews = JsonConvert.DeserializeObject<List<PrograInfoView>>(apiresponse);
            }
            return prograInfoViews;
        }
        public static async Task<PrograInfoView?> CreateProgramInfo(ProgramInfo program)
        {
            PrograInfoView? prograInfoViews = new PrograInfoView();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(program), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/ProgramInfoes", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return prograInfoViews;
        }
    }
}

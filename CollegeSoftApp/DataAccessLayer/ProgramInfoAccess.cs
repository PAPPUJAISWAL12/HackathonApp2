using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {
        public static async Task<List<PrograInfoView>?> GetProgramInfo()
        {
            List<PrograInfoView>? programInfos = new List<PrograInfoView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/ProgramInfoes"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    programInfos = JsonConvert.DeserializeObject<List<PrograInfoView>>(apiresponse);
                }
                return programInfos;
            }
            catch
            {
                return programInfos;
            }
        }
        //id
        public static async Task<PrograInfoView?> GetProgramInfoDetails(int id)
        {
            PrograInfoView? prograInfoViews = new PrograInfoView();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/ProgramInfoes/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                prograInfoViews = JsonConvert.DeserializeObject<PrograInfoView>(apiresponse);
            }
            return prograInfoViews;
        }
        public static async Task<ProgramInfoEdit?> CreateProgramInfo(ProgramInfoEdit program)
        {
            ProgramInfoEdit? programs = new ProgramInfoEdit();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(program), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/ProgramInfoes", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return programs;
        }
       /* public static async Task<ProgramInfoEdit> EditProgramInfo(int id)
        {
            ProgramInfoEdit programInfoEdit = new ProgramInfoEdit();
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:7027/api/ProgramInfoes/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"CancelledId\", \"value\": \"" +
                    ProgramInfoEdit.CancelledId + "\"},{ \"op\": \"replace\", \"path\": \"CancelledDate\", \"value\": \"" +
                    ProgramInfoEdit.CancelledDate + "\"},{ \"op\": \"replace\", \"path\": \"ReasonForCancel\", \"value\":" +
                    " \"" + programInfoEdit.ReasonForCancel + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return programInfoEdit;
        }*/


    }
}

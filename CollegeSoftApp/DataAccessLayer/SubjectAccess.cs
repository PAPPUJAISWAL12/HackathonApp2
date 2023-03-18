using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class SubjectAccess
    {
        public static async Task<List<SubjectsView>?> GetSubject()
        {

            List<SubjectsView>? subjects = new List<SubjectsView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Subjects"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    subjects = JsonConvert.DeserializeObject<List<SubjectsView>>(apiresponse);
                }
                return subjects;
            }
            catch
            {
                return subjects;
            }

        }
        //id
        public static async Task<List<SubjectsView?>> GetStudent(int id)
        {
            List<SubjectsView>? subjects = new List<SubjectsView>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Subjects/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                subjects = JsonConvert.DeserializeObject<List<SubjectsView>>(apiresponse);
            }
            return subjects;
        }
        public static async Task<SubjectsView?> CreateStudent(Subject subject)
        {
            SubjectsView? subjects = new SubjectsView();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(subject), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Subjects", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return subjects;
        }
    }
}

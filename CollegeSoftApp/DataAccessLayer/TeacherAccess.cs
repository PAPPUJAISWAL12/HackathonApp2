using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class TeacherAccess
    {
        public static async Task<List<TeacherView>?> GetTeacher()
        {

            List<TeacherView>? teachers = new List<TeacherView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Teachers"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    teachers = JsonConvert.DeserializeObject<List<TeacherView>>(apiresponse);
                }
                return teachers;
            }
            catch
            {
                return teachers;
            }

        }
        //id
        public static async Task<List<TeacherView?>> GetTeacher(int id)
        {
            List<TeacherView>? teachers = new List<TeacherView>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Teachers/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                teachers = JsonConvert.DeserializeObject<List<TeacherView>>(apiresponse);
            }
            return teachers;
        }
        public static async Task<TeacherView?> CreateTecaher(Teacher teacher)
        {
            TeacherView? teachers = new TeacherView();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Teachers", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return teachers;
        }
    }
}

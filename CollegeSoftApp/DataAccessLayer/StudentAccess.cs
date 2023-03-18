using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class StudentAccess
    {

        public static async Task<List<StudentView>?> GetStudent()
        {

            List<StudentView>? students = new List<StudentView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Students"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<StudentView>>(apiresponse);
                }
                return students;
            }
            catch
            {
                return students;
            }

        }
        //id
        public static async Task<List<StudentView?>> GetStudent(int id)
        {
            List<StudentView>? students = new List<StudentView>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Students/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<StudentView>>(apiresponse);
            }
            return students;
        }
        public static async Task<StudentView?> CreateStudent(Student student)
        {
            StudentView? students = new StudentView();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Students", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return students;
        }
    }
}

using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {

        public static async Task<List<StudentView>?> GetStudentList()
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
        public static async Task<StudentView?> GetStudentDetails(int id)
        {
            StudentView? students = new StudentView();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Students/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<StudentView>(apiresponse);
            }
            return students;
        }

        public static async Task<StudentEdit?> CreateStudent(StudentEdit student)
        {
            StudentEdit? std = new StudentEdit();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Students", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
				 std= JsonConvert.DeserializeObject<StudentEdit>(apiresponse);
			}
            return std;
        }
    }
}

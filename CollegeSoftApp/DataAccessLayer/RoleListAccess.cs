using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial  class RoleListAccess
    {
        public static async Task<List<RoleList>?> GetRoleLists()
        {

            List<RoleList>? roles = new List<RoleList>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/RoleLists"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    roles = JsonConvert.DeserializeObject<List<RoleList>>(apiresponse);
                }
                return roles;
            }
            catch
            {
                return roles;
            }

        }
        //id
        public static async Task<List<RoleList?>> GetRoleLists(int id)
        {
            List<RoleList>? roles = new List<RoleList>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/RoleLists/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                roles = JsonConvert.DeserializeObject<List<RoleList>>(apiresponse);
            }
            return roles;
        }
        public static async Task<RoleList?> CreateRoleList(RoleList role)
        {
            RoleList? roles = new RoleList();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/RoleList", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return roles;
        }
    }
}

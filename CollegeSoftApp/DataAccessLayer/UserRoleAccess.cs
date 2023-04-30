using CollegeSoftApp.Models;
using Newtonsoft.Json;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {
		public static async Task<List<UserRoleView>?> GetUserRoleList(int id)
		{
			List<UserRoleView>? userRoles = new List<UserRoleView>();
			try
			{
				HttpClient client = new HttpClient();
				using (var response = await client.GetAsync("https://localhost:7027/api/UserRoles/" + id.ToString()))
				{
					string apiresponse = await response.Content.ReadAsStringAsync();
					userRoles = JsonConvert.DeserializeObject<List<UserRoleView>>(apiresponse);
				}
				return userRoles;
			}
			catch
			{
				return userRoles;
			}
		}


		//RoleList 
		public static async Task<List<RoleList>?> GetRoleList()
		{
			List<RoleList>? userRoles = new List<RoleList>();
			try
			{
				HttpClient client = new HttpClient();
				using (var response = await client.GetAsync("https://localhost:7027/api/RoleLists"))
				{
					string apiresponse = await response.Content.ReadAsStringAsync();
					userRoles = JsonConvert.DeserializeObject<List<RoleList>>(apiresponse);
				}
				return userRoles;
			}
			catch
			{
				return userRoles;
			}
		}

	}
}

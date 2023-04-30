using CollegeSoftApp.Models;
using Newtonsoft.Json;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {
		public static async Task<List<User>?> GetUserList()
		{
			List<User>? users = new List<User>();
			try
			{
				HttpClient client = new HttpClient();
				using (var response = await client.GetAsync("https://localhost:7027/api/Users"))
				{
					string apiresponse = await response.Content.ReadAsStringAsync();
					users = JsonConvert.DeserializeObject<List<User>>(apiresponse);
				}
				return users;
			}
			catch
			{
				return users;
			}
		}
	}
}

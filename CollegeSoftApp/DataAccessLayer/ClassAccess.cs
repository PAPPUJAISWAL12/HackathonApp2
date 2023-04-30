using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
	public static partial class DataAccess
	{
		public static async Task<List<Class>?> GetClassList()
		{
			List<Class>? Fees = new List<Class>();
			try
			{
				HttpClient client = new HttpClient();
				using (var response = await client.GetAsync("https://localhost:7027/api/Classes"))
				{
					string apiresponse = await response.Content.ReadAsStringAsync();
					Fees = JsonConvert.DeserializeObject<List<Class>>(apiresponse);
				}
				return Fees;
			}
			catch
			{
				return Fees;
			}
		}
		public static async Task<List<Class>?> GetClassDetails(int id)
		{
			List<Class>? Fees = new List<Class>();
			try
			{
				HttpClient client = new HttpClient();
				using (var response = await client.GetAsync("https://localhost:7027/api/Classes/" + id.ToString()))
				{
					string apiresponse = await response.Content.ReadAsStringAsync();
					Fees = JsonConvert.DeserializeObject<List<Class>>(apiresponse);
				}
				return Fees;
			}
			catch
			{
				return Fees;
			}
		}

		public static async Task<Class?> CreateClass(Class feeEdit)
		{
			Class? feeEdits = new Class();
			HttpClient client = new HttpClient();
			StringContent content = new StringContent(JsonConvert.SerializeObject(feeEdit), Encoding.UTF8, "application/json");
			using (var response = await client.PostAsync("https://localhost:7027/api/Classes", content))
			{
				string apiresponse = await response.Content.ReadAsStringAsync();
				feeEdits = JsonConvert.DeserializeObject<Class>(apiresponse);
			}
			return feeEdits;
		}

	}
}

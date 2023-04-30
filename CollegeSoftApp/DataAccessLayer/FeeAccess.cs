using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {
        public static async Task<List<FeeDetailsView>?> GetFeeList()
        {
            List<FeeDetailsView>? Fees = new List<FeeDetailsView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Fees"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    Fees = JsonConvert.DeserializeObject<List<FeeDetailsView>>(apiresponse);
                }
                return Fees;
            }
            catch
            {
                return Fees;
            }
        }
        //id
        public static async Task<FeeDetailsView?> GetFeeDetails(int id)
        {
            FeeDetailsView? feeDetails = new FeeDetailsView();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Fees/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                feeDetails = JsonConvert.DeserializeObject<FeeDetailsView>(apiresponse);
            }
            return feeDetails;
        }

		public static async Task<FeeDetailsView?> GetFeeDetailsBystd(int id)
		{
			FeeDetailsView? feeDetails = new FeeDetailsView();
			HttpClient client = new HttpClient();
			using (var response = await client.GetAsync("https://localhost:7027/api/Classes/" + id.ToString()))
			{
				string apiresponse = await response.Content.ReadAsStringAsync();
				feeDetails = JsonConvert.DeserializeObject<FeeDetailsView>(apiresponse);
			}
			return feeDetails;
		}





		public static async Task<FeePrintView?> GetFeePrintDetails(int id)
		{
			FeePrintView? feeDetails = new FeePrintView();
			HttpClient client = new HttpClient();
			using (var response = await client.GetAsync("https://localhost:7027/api/FeePrints/" + id.ToString()))
			{
				string apiresponse = await response.Content.ReadAsStringAsync();
				feeDetails = JsonConvert.DeserializeObject<FeePrintView>(apiresponse);
			}
			return feeDetails;
		}


		public static async Task<FeePrintView?> CreateFee(FeeEdit feeEdit)
        {
            FeePrintView? feeEdits = new FeePrintView();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(feeEdit), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Fees", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
				feeEdits = JsonConvert.DeserializeObject<FeePrintView>(apiresponse);
			}
            return feeEdits;
        }

		public static async Task<FeeDetail> EditFeeStatus(int id)
		{
			FeeDetail detail = new FeeDetail();
			using (var httpClient = new HttpClient())
			{
				var request = new HttpRequestMessage
				{
					RequestUri = new Uri("https://localhost:7027/api/Details/" + id),
					Method = new HttpMethod("Patch"),
					Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"FeeStatus\", \"value\": \"" + detail.FeeStatus + "\"}]", Encoding.UTF8, "application/json")
				};

				var response = await httpClient.SendAsync(request);
			}
			return detail;
		}


		//FeeDetails Details
		public static async Task<List<FeeDetailsView>?> GetFeeDetailsList(int id)
		{
			List<FeeDetailsView>? Fees = new List<FeeDetailsView>();
			try
			{
				HttpClient client = new HttpClient();
				using (var response = await client.GetAsync("https://localhost:7027/api/FeeDetails/" + id.ToString()))
				{
					string apiresponse = await response.Content.ReadAsStringAsync();
					Fees = JsonConvert.DeserializeObject<List<FeeDetailsView>>(apiresponse);
				}
				return Fees;
			}
			catch
			{
				return Fees;
			}
		}








		//Create FeeDetails
		public static async Task<FeePrintView?> CreateFeeDetails(FeeDetailEdit feeEdit)
		{
			FeePrintView? feeEdits = new FeePrintView();
			
			HttpClient client = new HttpClient();
			StringContent content = new StringContent(JsonConvert.SerializeObject(feeEdit), Encoding.UTF8, "application/json");
			using (var response = await client.PostAsync("https://localhost:7027/api/FeeDetails", content))
			{
				string apiresponse = await response.Content.ReadAsStringAsync();
				feeEdits = JsonConvert.DeserializeObject<FeePrintView>(apiresponse);
			}
			return feeEdits;
		}

	}
}

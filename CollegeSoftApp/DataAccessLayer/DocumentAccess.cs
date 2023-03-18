using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class  DataAccess
    {
        public static async Task<List<DocumentView>?> GetDocument()
        {

            List<DocumentView>? Doclist = new List<DocumentView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Document"))
                {
                    string apiresponse =await response.Content.ReadAsStringAsync();
                    Doclist = JsonConvert.DeserializeObject<List<DocumentView>>(apiresponse);
                }
                return Doclist;
            }
            catch
            {
                return Doclist;
            }

        }
        //id
        public static async Task<List<DocumentView?>> GetDocuments(int id)
        {
            List<DocumentView>? Doclist = new List<DocumentView>();
            HttpClient client = new HttpClient();
            using(var response =await client.GetAsync("https://localhost:7027/api/Document/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                Doclist = JsonConvert.DeserializeObject<List<DocumentView>>(apiresponse);
            }
            return Doclist;
        }
        public static async Task<DocumentView?> CreateDocument(Document doc)
        {
            DocumentView? Doclist = new DocumentView();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(doc), Encoding.UTF8, "application/json");
        using (var response =await client.PostAsync("https://localhost:7027/api/Document",content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return Doclist;
        }
    }
}

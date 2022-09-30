using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace StudyVehicleWeb.Pages
{
    /// <summary>
    /// Bu sayfada veritabanından araç listesini çekmek ve ilgili aracı silmek için API kullanılmaktadır.
    /// </summary>
    public class ListVehicleModel : PageModel
    {
        public List<Vehicle> VehicleList = new List<Vehicle>(); // Frontend tarafında bu listeden verileri çekmektedir.
        private string apiurl = "http://localhost:5082/vehicle"; // global api url
        public ShowDesc Show = new ShowDesc(); // Frontend description

        public void OnGet()
        {
            try
            {
                //Silme işlemi için url den parametre bekleniyor.
                var url = new Uri(Request.GetDisplayUrl());
                var plate = HttpUtility.ParseQueryString(url.Query).Get("DeletePlate");
                if (!string.IsNullOrEmpty(plate))
                    if (DeleteVehicle(plate))
                        Show.desc = plate + " Plakalı araç silinmiştir.";
                    else
                        Show.desc = " Hata oluştu.";
            }
            catch (Exception e)
            {
            }

            // Liste dolduruluyor.
            VehicleList = GetList();
        }

        /// <summary>
        /// Get all vehicle from api
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetList()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            var client = new WebClient();
            var content = client.DownloadString(apiurl + "/ListVehicle"); // Araç listesini apiden get ile çekmekte.

            var serializer = new DataContractJsonSerializer(typeof(List<Vehicle>));
            byte[] bytes = Encoding.Default.GetBytes(content);
            var myString = Encoding.UTF8.GetString(bytes);

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(myString)))
            {
                var contributors = (List<Vehicle>) serializer.ReadObject(ms); // json string to vehicle class list
                foreach (var contributor in contributors)
                    vehicleList.Add(contributor);
            }

            return vehicleList;
        }

        /// <summary>
        /// Delete Post, Parameter Plate get on Url
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        private bool DeleteVehicle(string plate)
        {
            try
            {
                Uri uri = new Uri(apiurl + "/DeleteVehicle"); // Araç silme url
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/json";
                string json = "{\"Plate\": \"" + plate + "\"}"; // Body Paramater ex: {"Plate": "34TR001"}


                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse) request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd(); // api result
                    if (Convert.ToBoolean(result))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    public class ShowDesc
    {
        public string desc { get; set; } = string.Empty;
    }
}
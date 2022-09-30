using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyVehicleWeb.Pages
{
    public class AddVehicleModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Brand { get; set; }

        [BindProperty]
        [Required]
        public string Model { get; set; }
        [BindProperty]
        [Required]
        public int CapacityKG { get; set; }
        [BindProperty]
        [Required]
        public int CapacityM3 { get; set; }
        [BindProperty]
        [Required]
        public string Plate { get; set; }
        [BindProperty]
        [Required]
        public string Type { get; set; }
        [BindProperty]
        [Required]
        public int ModelYear { get; set; }
        [BindProperty]
        [Required]
        public string Color { get; set; }

        public ShowDesc Show = new ShowDesc(); // Frontend description
        private string apiurl = "http://localhost:5082/vehicle";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;

            Vehicle vehicle = new Vehicle();
            vehicle.brand = Request.Form["Brand"];
            vehicle.model = Request.Form["Model"];
            vehicle.capacityKg = Convert.ToInt32(Request.Form["CapacityKG"]);
            vehicle.capacityM3 = Convert.ToInt32(Request.Form["CapacityM3"]);
            vehicle.plate = Request.Form["Plate"];
            vehicle.type = Request.Form["Type"];
            vehicle.modelYear = Convert.ToInt32(Request.Form["ModelYear"]);
            vehicle.color = Request.Form["Color"];
            if (AddVehicle(vehicle))
                Show.desc = vehicle.plate + " Plakalı araç eklenmiştir.";
            else
                Show.desc = " Hata oluştu.";

        }


        public bool AddVehicle(Vehicle vehicle)
        {


            try
            {


                Uri uri = new Uri(apiurl + "/AddVehicle");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/json";
                string json = "{\"Brand\": \"" + vehicle.brand + "\"," +
                              "\"Model\": \"" + vehicle.model + "\"," +
                              "\"CapacityKg\": \"" + vehicle.capacityKg + "\"," +
                              "\"CapacityM3\": \"" + vehicle.capacityM3 + "\"," +
                              "\"Plate\": \"" + vehicle.plate + "\"," +
                              "\"Type\": \"" + vehicle.type + "\"," +
                              "\"ModelYear\": \"" + vehicle.modelYear + "\"," +
                              "\"Color\": \"" + vehicle.color + "\"}";


                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
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
}

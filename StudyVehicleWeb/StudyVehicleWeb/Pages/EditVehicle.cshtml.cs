using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyVehicleWeb.Pages
{
    public class EditVehicleModel : PageModel
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



        public Vehicle _vehicle = new Vehicle();
        private string apiurl = "http://localhost:5082/vehicle";
        
        public void OnGet()
        {
            var url =  new Uri(Request.GetDisplayUrl());
            var plate = HttpUtility.ParseQueryString(url.Query).Get("Plate");
            _vehicle = GetVehicle(plate);
        }

        public Vehicle GetVehicle(string plate)
        {
            if (string.IsNullOrEmpty(plate))
                return null;

            try
            {
                Vehicle vehicle = new Vehicle { };

                Uri uri = new Uri(apiurl + "/FindVehicle");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/json";
                string json = "{\"Plate\": \"" + plate + "\"}";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    vehicle = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Vehicle>>(result)[0];

                }


                return vehicle;
            }
            catch (Exception e)
            {
                return null;
            }
          
      

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


            var xx = UpdateVehicle(vehicle);




_vehicle = vehicle;

        }



        public bool UpdateVehicle(Vehicle vehicle)
        {
           

            try
            {
            

                Uri uri = new Uri(apiurl + "/EditVehicle");
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

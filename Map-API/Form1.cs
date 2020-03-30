using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;

namespace Map_API
{
    public partial class Map_form : Form
    {
        double lon = Convert.ToDouble(0);
        double lat = Convert.ToDouble(0);

        public Map_form()
        {
            InitializeComponent();

            try
            {
                System.Net.IPHostEntry e =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                gMapControl1.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.",
                      "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }

            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            gMapControl1.Position = new PointLatLng(0, 0);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
        }

        public void UpdatePos(double lat, double lon)
        {
            Console.WriteLine(lat + " " + lon);
            gMapControl1.Position = new PointLatLng(lat, lon);
            //gMapControl1.Position = new PointLatLng(54.6961334816182, 25.2985095977783);
        }

        private void Load_Location_Click(object sender, EventArgs e)
        {


            HttpClient clic = new HttpClient();
            clic.BaseAddress = new Uri("http://localhost:64195/");

            clic.BaseAddress = new Uri("https://best-way.herokuapp.com/api/weather/:cityname");

            // Add an Accept header for JSON format.
            clic.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
           
            HttpResponseMessage response = clic.GetAsync(Location_name.Text).Result; 
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string dataObjects = response.Content.ReadAsStringAsync().Result;  
                
                string[] words = dataObjects.Split(':', ',', '}');

                lon = double.Parse(words[5], System.Globalization.CultureInfo.InvariantCulture); 

                lat = double.Parse(words[7], System.Globalization.CultureInfo.InvariantCulture);

                Console.WriteLine(lat + " " + lon);

                
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            UpdatePos(lat, lon);

            clic.Dispose();
        }
    }
}

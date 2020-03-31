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
using GMap.NET.WindowsForms.Markers;
using GMap.NET;

namespace Map_API
{
    public partial class Map_form : Form
    {
        

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
            gMapControl1.Position = new PointLatLng(46.35, 15.13);
            gMapControl1.ShowCenter = false;
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
        }

        public void CreateMarker(double lat, double lon, string cty, double tmp, double wind)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.purple_pushpin);
            marker.ToolTipText = cty + ": " + "Temp: " + tmp.ToString() + "  Wind: " + wind.ToString();

            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
        }

        

        private void Load_Location_Click(object sender, EventArgs e)
        {


            HttpClient clic = new HttpClient();

            clic.BaseAddress = new Uri($"https://best-way.herokuapp.com/api/between/{StartLocation.Text}/{EndLocation.Text}");

            clic.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = clic.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            { 
                string dataObjects = response.Content.ReadAsStringAsync().Result;

                dynamic process = Newtonsoft.Json.JsonConvert.DeserializeObject(dataObjects);

                gMapControl1.Overlays.Clear();
                Display.Items.Clear();

                for (int x = 0; x < 5; x++)
                {
                    double lon = process.result[x].location.longitude;
                    double lat = process.result[x].location.latitude;
                    string cty = process.result[x].weather.city;
                    double tmp = process.result[x].weather.temp;
                    double wind = process.result[x].weather.wind;
                    Display.Items.Add("Mesto: " + cty + ", temp: " + tmp + ", veter: " + wind);
                    CreateMarker(lat, lon, cty, tmp, wind);
                    Console.WriteLine(lon + " " + lat);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


            clic.Dispose();
        }

        private void GMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gMapControl1.Overlays.Clear();
                Display.Items.Clear();
                var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lon = point.Lng;

                HttpClient clic = new HttpClient();

                clic.BaseAddress = new Uri($"https://best-way.herokuapp.com/api/weather/{lat}/{lon}");

                clic.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = clic.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    string dataObjects = response.Content.ReadAsStringAsync().Result;

                    dynamic process = Newtonsoft.Json.JsonConvert.DeserializeObject(dataObjects);

                    string cty = process.result.weather.city;
                    double tmp = process.result.weather.temp;
                    double wind = process.result.weather.wind;

                    CreateMarker(lat, lon, cty, tmp, wind);
                    Display.Items.Add("Mesto: " + cty + ", temp: " + tmp + ", veter: " + wind);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }


                clic.Dispose();

                
            }
        }
    }
}

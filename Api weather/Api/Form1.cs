using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Api
{
    public partial class Form1 : Form
    {
        const string token = "7809fe29ca8896d2e3bd371196cd4b76";
        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;

            var id = 498817;
            ShowWeather(id);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    id = 498817;
                    break;
                case 1:
                    id = 524894;
                    break;
                case 2:
                    id = 2017370;
                    break;
                case 3:
                    id = 2635167;
                    break;
                default:
                    id = 498817;
                    break;
            }
            ShowWeather(id);
        }

        public void ShowWeather(int id)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?id={id}&lang=ru&units=metric&appid={token}";

            var request = (HttpWebRequest)WebRequest.Create(url);

            var httpresponse = (HttpWebResponse)request.GetResponse();

            string response, icon = "";

            using (var reader = new StreamReader(httpresponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            label1.Text = $"В {weatherResponse.Name} {weatherResponse.Main.Temp}°C\n" +
                $"Ощущается {weatherResponse.Main.FeelsLike}°C\n" +
                $"Максималная {weatherResponse.Main.TempMax}°C и минимальная {weatherResponse.Main.TempMin}°C погода на сегодня\n" +
                $"Скорость ветра: {weatherResponse.Wind.Speed} метр/сек";

            foreach (Item item in weatherResponse.Weather)
            {
                label1.Text = label1.Text + $"\nСейчас {item.Description}";
                icon = item.Icon;
            }

            var urlIcon = $"http://openweathermap.org/img/wn/{icon}@2x.png";

            pictureBox1.Load(urlIcon);

        }

    }
}

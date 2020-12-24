using Newtonsoft.Json;
using System.IO;
using System.Net;


namespace ConsoleApp1.models.Class
{
    public class Weather
    {
        private const string token = "7809fe29ca8896d2e3bd371196cd4b76";
        public static string Show_Api(string town)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={town}&units=metric&appid={token}";

            var request = (HttpWebRequest)WebRequest.Create(url);

            var httpresponse = (HttpWebResponse)request.GetResponse();
            string response;
            using (var reader = new StreamReader(httpresponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            var weatherText = $"В {weatherResponse.Name} {weatherResponse.Main.Temp}°C\n" +
                $"Ощущается {weatherResponse.Main.FeelsLike}°C\n" +
                $"Максималная {weatherResponse.Main.TempMax}°C и минимальная {weatherResponse.Main.TempMin}°C погода на сегодня\n" +
                $"Скорость ветра: {weatherResponse.Wind.Speed} метр/сек";
            return weatherText;
        }
    }
}

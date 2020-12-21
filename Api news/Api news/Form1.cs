using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Api_news.models;

namespace Api_news
{
    public partial class Form1 : Form
    {
        private const string endpoint = "http://newsapi.org/v2/top-headlines?";
        private const string Api_Key = "cc4a9e12cf7e411b9569b578db7db781";
        private string lang = "";
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            Show_API(null);
        }

        public void Show_API(string categor)
        {
            textBox1.Text = "";
            var client = new HttpClient();
            var response = client.GetAsync(new Uri(
                   $"{endpoint}country={lang}&category={categor}&apiKey={Api_Key}")).GetAwaiter().GetResult();
            var jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var newsInfo = JsonConvert.DeserializeObject<NewsInfo>(jsonResult);
            var line = Environment.NewLine;
            foreach (Article article in newsInfo.Articles)
            {
                textBox1.Text += $"Источник: {article.Source.Name + line} Заголовок: {article.Title + line }Описание: {article.Description+line}" +
                    $"Ссылка на новость в источнике: {article.Url+line+line}";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    lang = "ru";
                    break;
                case 1:
                    lang = "us";
                    break;
                default:
                    lang = "ru";
                    break;
            }
            Show_API(null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line;
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    line = "business";
                    break;
                case 1:
                    line = "sport";
                    break;
                case 3:
                    line = "culture";
                    break;
                default:
                    line = "business";
                    break;
            }
            Show_API(line);
        }
    }
}

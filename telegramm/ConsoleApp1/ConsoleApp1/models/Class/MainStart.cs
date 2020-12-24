using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleApp1.models.Class
{
    public class MainStart
    {
        private static ITelegramBotClient botClient;
        public  static void Start()
        {

            botClient = new TelegramBotClient("1419427834:AAH45aX3gJECl3cUG4w917GCFk4dUKRhGFo") { Timeout = TimeSpan.FromSeconds(10) };
            var bot = botClient.GetMeAsync().Result;
            Console.WriteLine($"Бот в работе! \nBot:{bot.Id}");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.ReadKey();
            botClient.StopReceiving();
        }

        private async static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null)
                return;

            try
            {
                var weatherText = Weather.Show_Api(text);
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: $"Погода в {text}: \n{weatherText}\n\n" +
                          $"Введите другой город, если хотите узнать погоду в нем."
                    ).ConfigureAwait(false);
            }
            catch (Exception)
            {
                await botClient.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Напишите город в котором нужно узнать погоду"
            ).ConfigureAwait(false);
            }

        }
    }
}

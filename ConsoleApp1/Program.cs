using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Mother_bot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5924572285:AAFK9PZLgz_StB7m2hNWl_cqtmS0MmvCR5I");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async private static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                if (message.Text == "/start")
                {
                    ReplyKeyboardMarkup replyKeyboardMarkup1 = new ReplyKeyboardMarkup (new[]
                    {
                        new KeyboardButton[]{"Ответить"}
                    })
                    {
                        ResizeKeyboard = true
                    };
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Задай мне вопрос", replyMarkup: replyKeyboardMarkup1);
                }
                else
                {
                    string[] decision = { "Думаю, да", "Думаю, нет", "Э⁓, подумай ещё" };
                    string answer = decision[GetRandom()];
                    await botClient.SendTextMessageAsync(message.Chat.Id, answer);
                }
            }
        }

        static int GetRandom()
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //Получить случайное число 
            int value = rnd.Next(3);

            //Вернуть полученное значение
            return value;
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}

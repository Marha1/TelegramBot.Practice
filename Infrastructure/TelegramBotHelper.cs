using Domain.Models;
using Infrastructure.Dal;
using Telegram.Bot;

namespace Infrastructure
{
    internal class TelegramBotHelper
    {
        private readonly string _token;
        private readonly AplicationContext _dbContext;
        string _name;
        int _age;
        TelegramBotClient _client;
        public TelegramBotHelper(string token, AplicationContext dbContext)
        {
            this._token = token;
            this._dbContext = dbContext;
         }
        internal void GetUpdates()
        {
            _client = new TelegramBotClient(_token);
            var updates = _client.GetUpdatesAsync().Result;
            try
            {
                foreach (var user in updates)
                {
                    var existingUser = _dbContext.User.FirstOrDefault(x => x.ChatID == user.Message.Chat.Id);
                    if (existingUser == null)
                    {
                        
                        var newUser = new UsersId
                        {
                            ChatID = user.Message.Chat.Id,
                            Name = user.Message.Chat.Username
                                
                        };
                        _dbContext.User.Add(newUser);
                        _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        Console.WriteLine("Пользователь уже существует");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            var userId = _dbContext.User.ToList();
            foreach (var update in userId)
                try
                {
                    var imagePath = @"C:\Users\Hi-Tech\OneDrive\Desktop\проект\TelegramBot.Practice\Infrastructure\Arfitacts\1.png";
                    using (var stream = File.OpenRead(imagePath))
                        _client.SendPhotoAsync(update.ChatID, new Telegram.Bot.Types.InputFileStream(stream));
                    var text = $"С  днем рождения {_name}, Успехов радости веселия Вам исполнилось {_age}";
                    _client.SendTextMessageAsync(update.ChatID, text);
                    Console.WriteLine("Отправлено");
                }
                catch
                {
                    Console.WriteLine("Ошибка отправки сообщений");
                }
        }
        public void GetName(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
    }
}

using Domain.Models;
using Infrastructure.Dal;
using Infrastructure.Dal.Interfaces;
using Quartz;

namespace Infrastructure.Jobs
{
    public class Postcard : IJob
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private AplicationContext _dbContext { get; set; }

        public Postcard()
        {
           
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Извлекаем зависимости из JobData
            var employeeRepository = (IEmployeRepository<Employee>)context.JobDetail.JobDataMap["employeeRepository"];
            _dbContext = (AplicationContext)context.JobDetail.JobDataMap["DefaultConnection"];
            var telegramBotToken = (string)context.JobDetail.JobDataMap["TelegramBotToken"];
            var task = employeeRepository.GetAll();

            if (task != null)
            {
                DateTime d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 00);

                var employ = from items in task
                             where items.DateOfBirh.Month == d2.Month
                                && items.DateOfBirh.Day == d2.Day
                                && items.DateOfBirh.Hour == d2.Hour
                                && items.DateOfBirh.Minute == d2.Minute
                             select items;

                foreach (var item in employ)
                {
                    item.Age += 1;
                    var telegram = new TelegramBotHelper(telegramBotToken, _dbContext);
                    telegram.GetName(item.Name, item.Age);
                    telegram.GetUpdates();
                    employeeRepository.Save();
                    
                }
            }
        }
    }

}
    

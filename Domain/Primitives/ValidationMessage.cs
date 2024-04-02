namespace Domain.Validations;

public static class ValidationMessages
{
    public static string IsNullOrEmpty { get; set; } = "Сущность {0} не может быть NULL или пустой!";
    public static string IsValidString { get; set; } = "Значение {0} должно содержать только буквы!";
    public static string ValidAge { get; set; } = "Некорректный возраст!";
    public static string ValidDataBirth { get; set; } = "Некорректный дата рождения!";
    public static string ValidTelegram { get; set; } = "Некорректный ник Telegram!";

}
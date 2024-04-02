using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Bot.Types;

namespace Infrastructure.Dal.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UsersId>
{
    public void Configure(EntityTypeBuilder<UsersId> builder)
    {
        builder.ToTable("UsersIds"); // Указываем название таблицы

        // Устанавливаем Id как ключ
        builder.HasKey(x => x.Id);

        // Устанавливаем свойство ChatID как обязательное
        builder.Property(x => x.ChatID).IsRequired();

    }
}
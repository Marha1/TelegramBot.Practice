namespace Infrastructure.Dal.Interfaces;
/// <summary>
/// Расширяющий интерфейс базового класса
/// </summary>
/// <typeparam name="Employ"></typeparam>
public interface IEmployeRepository<Employ>:IBaseRepository<Employ>
{
    public void Save();
}
﻿using Domain.Models;
using Infrastructure.Dal.Interfaces;

namespace Infrastructure.Dal.Repository
{
    public class EmployeRepository : IBaseRepository<Employee>
    {
        private readonly AplicationContext _context;
        public EmployeRepository(AplicationContext context)
        {
                _context=context;
        }
        public void Add(Employee entity)
        {
            entity.Name = entity.Name==null?"Unknown":entity.Name;
            entity.Post = entity.Post == null ? "None" : entity.Post;
            entity.Age = GetAge(entity.DateOfBirh);
            _context.AddAsync(entity);
            _context.SaveChanges();
            
        }
        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }

        public void Delete(Guid Id)
        {

            _context.Employees.Remove(_context.Employees.SingleOrDefault(p => p.Id == Id));
           _context.SaveChanges();
            
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            var result = _context.Employees.FirstOrDefault(p => p.Id == entity.Id);

            if (result!=null)
            {
                try
                {
                    result.Name = entity.Name != null ? entity.Name : result.Name;
                    result.Age = entity.Age != 0 ? entity.Age : result.Age;
                    result.Post = entity.Post != null ? entity.Post : result.Post;
                    result.DateOfBirh = entity.DateOfBirh != null ? entity.DateOfBirh : result.DateOfBirh;
                    Console.WriteLine("ok");
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    Console.WriteLine("Not ok");
                  
                }
            }
        }

    }
}

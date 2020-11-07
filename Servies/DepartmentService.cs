using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Servies
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();

        public DepartmentService()
        {
            _departments.Add(new Department()
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "beijing"
            });
            _departments.Add(new Department()
            {
                Id = 2,
                Name = "RD",
                EmployeeCount = 52,
                Location = "shanhai"
            });
            _departments.Add(new Department()
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 200,
                Location = "china"
            });
        }

        public Task Add(Department department)
        {
            department.Id = _departments.Max(m => m.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _departments.FirstOrDefault(m => m.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
               {
                   return new CompanySummary()
                   {
                       EmplyeeCount = _departments.Sum(m => m.EmployeeCount),
                       AverageDepartmentEmployeeCount = (int)_departments.Average(m => m.EmployeeCount)
                   };
               });
        }
    }
}

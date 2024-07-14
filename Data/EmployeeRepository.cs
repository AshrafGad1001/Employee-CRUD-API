using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD_API.Data
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task AddEmployee(Employee employee)
        {
            await _applicationDbContext.Set<Employee>().AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _applicationDbContext.Employees.FindAsync(id);
        }
        public async Task UpdateEmployee(int id, Employee model)
        {
            var CurrentEmployee = await _applicationDbContext.Employees.FindAsync(id);
            if (CurrentEmployee == null)
            {
                throw new Exception("Employee Not Found");
            }
            CurrentEmployee.Name = model.Name;
            CurrentEmployee.Phone = model.Phone;
            CurrentEmployee.Age = model.Age;
            CurrentEmployee.Salary = model.Salary;

            await _applicationDbContext.SaveChangesAsync();

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var CurrentEmployee = await _applicationDbContext.Employees.FindAsync(id);
            if (CurrentEmployee == null)
            {
                throw new Exception("Employee Not Found");
            }
            _applicationDbContext.Employees.Remove(CurrentEmployee);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}

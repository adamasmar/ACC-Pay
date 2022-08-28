using ACC_Pay.Server.Context;
using ACC_Pay.Shared;
using ACC_Pay.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace ACC_Pay.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly AccPayDbContext _accPayDbContext;

        public EmployeesController(ILogger<EmployeesController> logger, AccPayDbContext accPayDbContext)
        {
            _logger = logger;
            _accPayDbContext = accPayDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _accPayDbContext.Employee.ToListAsync();
        }

        [HttpPost]
        public async Task<Employee> Post(Employee employee)
        {
            var result = await _accPayDbContext.Employee.AddAsync(employee);
            await _accPayDbContext.SaveChangesAsync();
            return result.Entity;
        }

        [HttpPut]
        public async Task<Employee> Put(Employee employee)
        {
            var foundEmployee = await _accPayDbContext.Employee.AsNoTracking().FirstOrDefaultAsync(emp => emp.EmployeeId == employee.EmployeeId);

            if (foundEmployee is null)
            {
                var result = await _accPayDbContext.Employee.AddAsync(employee);
                foundEmployee = result.Entity;
            }
            else
            {
                employee.EmployeeId = foundEmployee.EmployeeId;
                foundEmployee = employee;
                _accPayDbContext.Employee.Update(foundEmployee);
            }
            await _accPayDbContext.SaveChangesAsync();
            return foundEmployee;
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> Delete(Guid employeeId)
        {
            var foundEmployee = await _accPayDbContext.Employee.AsNoTracking().FirstOrDefaultAsync(emp => emp.EmployeeId == employeeId);
            if(foundEmployee is not null)
            {
                _accPayDbContext.Employee.Remove(foundEmployee);
                await _accPayDbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
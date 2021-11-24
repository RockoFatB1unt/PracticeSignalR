using DiApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiAndSignalRApp.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryCalculator _salaryCalculator;

        public SalaryController(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }

        public double GetSalary()
        {
            return _salaryCalculator.CalculateSalary(160, 500);
        }
    }
}

using DiApp.Interfaces;

namespace DiApp.Models
{
    public class SalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(int workingHours, int hourlyRate) => workingHours * hourlyRate;
    }
}

namespace Fulltime.Application.Employee.Commands.ComputeSalary
{
    public class EmployeeSalaryVm
    {
        public string Name { get; set; }
        public double LaborOld { get; set; }
        public double RateHour { get; set; }
        public double GrossSalary { get; set; }
        public double Discount { get; set; }
        public double NetSalary
        {
            get { return GrossSalary - Discount; }
        }

    }
}

public class Employee
{
    public string Name { get; set; }
    public int HRA { get; set; }
    public int BasicSalary { get; set; }
    public int WorkingDays { get; set; }
    public int CA { get; set; }
    public int MD { get; set; }
    public Employee(string name, int salary,int WorkingDay, int hra, int ca, int md)
    {
        Name = name;
        BasicSalary = salary;
        HRA = hra;
        WorkingDays = WorkingDay;
        CA = ca;
        MD = md;
    }
    public void CalculateEmployeeSalary()
    {
        /*float hraPercent =  (BasicSalary * HRA)/100;*/
        float Salary = (BasicSalary + ((BasicSalary*HRA)/100) + MD + CA) * 12;
        float ExemptionAmount = (((HRA*BasicSalary)/100) + MD + CA) *12;
        float TaxableIncome = Salary - ExemptionAmount;
        float Tax = 0;
        float TaxAmount = 0;
        if (TaxableIncome > 0 && TaxableIncome < 2.5*100000)
        {
            Tax = 0;
        }
        else if (TaxableIncome >= 2.5 * 100000 && TaxableIncome < 5 * 100000)
        {
            Tax = 5;
        }
        else if (TaxableIncome >= 5 * 100000 && TaxableIncome < 10 * 100000)
        {
            Tax = 20;
        }
        else
        {
            Tax = 30;
        }
        
        TaxAmount = Tax / 100 * TaxableIncome;
        float SalaryAfterExemption = Salary - TaxAmount;
        float SalaryPerMonth = (SalaryAfterExemption / 360) * WorkingDays;
        Console.WriteLine($"Employee Name: {Name}");
        Console.WriteLine($"Salary: {SalaryPerMonth}");
        Console.WriteLine($"Taxable Income: {TaxableIncome}");
        Console.WriteLine($"Tax Amount: {TaxAmount/12}");

    }

}

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Employee Name: ");
        string Name = Console.ReadLine();
        Console.WriteLine("Basic Salary: ");
        int Salary = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Number of days worked in a month: ");
        int WorkingDays = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("HRA Percentage: ");
        int HRA = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Conveyance Allowance Amount:: ");
        int CA = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Medical Allowance Amount: ");
        int MD = Convert.ToInt32(Console.ReadLine());
        Employee employee = new Employee(Name, Salary, WorkingDays, HRA, CA, MD);
        Console.WriteLine("--------------------Resut-------------------");
        employee.CalculateEmployeeSalary();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_PRINCIPLES.O
{
    /// <summary>
    /// OPEN CLOSE PRINCIPLE
    /// A class should be open for extension but must be closed for modifications
    /// or you can add features in a class but can't modify existing functionality
    /// This doesn't mean that you can't fix bugs in existing code :p
    /// </summary>

    #region PROBLEM

    public class SalaryCalculator
    {
        // It calculates salary for only one type of emp
        public decimal CalculateSalary()
        {
            return 10000;
        }
    } //end of class

    public class SalaryCalculatorSol1
    {
        // Now it calculates salary for many type of employees
        // But the problem is if in future we need to calculate
        // Salary for another employee who's type is "Temporary"
        // Then we will need to modify this class and 
        // Come here to add another condition
        // which is violation of Open Close Principle
        public decimal CalculateSalary(string empType)
        {
            return empType switch
            {
                "Permanent" => 10000,
                "Contract" => 5000,
                _ => 0
            };
        }
    } //end of class

    #endregion


    #region SOLUTION

    public interface ISalaryCalculator
    {
        decimal CalculateSalary();
    }

    public abstract class SalaryCalculatorAbstract : ISalaryCalculator
    {
        public abstract decimal CalculateSalary();
    }

    public class SalaryCalculatorPermanentEmp : SalaryCalculatorAbstract
    {
        public override decimal CalculateSalary()
        {
            return 1000;
        }
    } //end of class

    public class SalaryCalculatorContractEmp : SalaryCalculatorAbstract
    {
        public override decimal CalculateSalary()
        {
            return 700;
        }
    } //end of class

    public class SalaryCalculatorTempEmp : SalaryCalculatorAbstract
    {
        public override decimal CalculateSalary()
        {
            return 400;
        }
    } //end of class

    #endregion


    public class OpenClosePrinciple
    {
        private ISalaryCalculator _calculator;

        public OpenClosePrinciple(ISalaryCalculator calculator)
        {
            _calculator = calculator;
        }

        public void TestPrinciple()
        {
            _calculator = new SalaryCalculatorContractEmp();
            _calculator = new SalaryCalculatorPermanentEmp();
            _calculator = new SalaryCalculatorTempEmp();

            _calculator.CalculateSalary();
        }
    }
}
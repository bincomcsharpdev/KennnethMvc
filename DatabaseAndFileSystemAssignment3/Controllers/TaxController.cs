using Microsoft.AspNetCore.Mvc;

namespace DatabaseAndFileSystemAssignment3.Controllers
{
    public class TaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(decimal salary)
        {
            decimal taxFreeAllowance = (salary * 0.2M) + 200000M;
            decimal taxableIncome = salary - taxFreeAllowance;
            decimal taxAmount = CalculateTax(taxableIncome);

            ViewBag.TaxAmount = taxAmount;
            return View();
        }

        private decimal CalculateTax(decimal income)
        {
            decimal tax = 0;
            if (income <= 300000) tax = income * 0.07M;
            else if (income <= 600000) tax = (300000 * 0.07M) + ((income - 300000) * 0.11M);
            else if (income <= 1100000) tax = (300000 * 0.07M) + (300000 * 0.11M) + ((income - 600000) * 0.15M);
            else if (income <= 1600000) tax = (300000 * 0.07M) + (300000 * 0.11M) + (500000 * 0.15M) + ((income - 1100000) * 0.19M);
            else if (income <= 3200000) tax = (300000 * 0.07M) + (300000 * 0.11M) + (500000 * 0.15M) + (500000 * 0.19M) + ((income - 1600000) * 0.21M);
            else tax = (300000 * 0.07M) + (300000 * 0.11M) + (500000 * 0.15M) + (500000 * 0.19M) + (1600000 * 0.21M) + ((income - 3200000) * 0.24M);

            return tax;
        }
    }
}

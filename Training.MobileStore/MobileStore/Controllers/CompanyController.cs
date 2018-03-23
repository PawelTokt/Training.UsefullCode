using MobileStore.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.Controllers
{
    public class CompanyController : Controller
    {
        private readonly MobileContext _dbContext;

        public CompanyController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            _dbContext.Companies.Add(company);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
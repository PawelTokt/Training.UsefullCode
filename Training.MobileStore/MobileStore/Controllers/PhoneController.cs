using System.Linq;
using MobileStore.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MobileStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class PhoneController : Controller
    {
        private readonly MobileContext _dbContext;

        public PhoneController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var phone = await _dbContext.Phones.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id);
            if (phone == null) return NotFound();
            return View(phone);
        }

        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_dbContext.Companies.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            _dbContext.Phones.Add(phone);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var phone = await _dbContext.Phones.FirstOrDefaultAsync(x => x.Id == id);
            if (phone == null) return NotFound();

            ViewBag.Companies = new SelectList(_dbContext.Companies.ToList(), "Id", "Name", phone.CompanyId);

            return View(phone);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            _dbContext.Phones.Update(phone);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id == null) return NotFound();

            var phone = await _dbContext.Phones.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == id);
            if (phone == null) return NotFound();

            return View(phone);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var phone = new Phone { Id = id.Value };
            _dbContext.Entry(phone).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
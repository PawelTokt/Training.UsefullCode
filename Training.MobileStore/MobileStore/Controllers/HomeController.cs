using System;
using System.Linq;
using MobileStore.Models;
using System.Threading.Tasks;
using MobileStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MobileContext _dbContext;

        public HomeController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Index(int? company, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            var pageSize = 3;
            
            //Filter
            IQueryable<Phone> phones = _dbContext.Phones.Include(x => x.Company);

            if (company != null && company != 0)
            {
                phones = phones.Where(p => p.CompanyId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                phones = phones.Where(p => p.Name.Contains(name));
            }

            //Sort
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    phones = phones.OrderByDescending(x => x.Name);
                    break;
                case SortState.CompanyAsc:
                    phones = phones.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    phones = phones.OrderByDescending(x => x.Company.Name);
                    break;
                case SortState.PriceAsc:
                    phones = phones.OrderBy(x => x.Price);
                    break;
                case SortState.PriceDesc:
                    phones = phones.OrderByDescending(x => x.Price);
                    break;
                default:
                    phones = phones.OrderBy(x => x.Name);
                    break;
            }

            //Paging
            var count = await phones.CountAsync();
            var items = await phones.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            //Makes ViewModel
            var viewModel = new IndexViewModel
            {
                FilterViewModel = new FilterViewModel(_dbContext.Companies.ToList(), company, name),
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                Phones = items
            };

            return View(viewModel);
        }
    }
}

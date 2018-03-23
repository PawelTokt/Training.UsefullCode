using MobileStore.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MobileStore.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(IList<Company> companies, int? company, string name)
        {
            companies.Insert(0, new Company{Name = "All", Id = 0});
            Companies = new SelectList(companies, "Id", "Name", company);
            SelectedCompany = company;
            SelectedName = name;
        }

        public SelectList Companies { get;  }
        public int? SelectedCompany { get;  }
        public string SelectedName { get; }
    }
}
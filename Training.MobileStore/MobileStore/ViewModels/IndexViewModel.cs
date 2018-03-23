using MobileStore.Models;
using System.Collections.Generic;

namespace MobileStore.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
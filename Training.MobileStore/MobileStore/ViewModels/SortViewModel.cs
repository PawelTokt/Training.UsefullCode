using MobileStore.Models;

namespace MobileStore.ViewModels
{
    public class SortViewModel
    {
        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            CompanySort = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }

        public SortState NameSort { get; }
        public SortState CompanySort { get; }
        public SortState PriceSort { get; }
        public SortState Current { get; }
    }
}
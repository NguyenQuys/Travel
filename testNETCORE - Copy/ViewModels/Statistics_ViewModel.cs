

using testNETCORE.Models;

namespace testNETCORE.ViewModels
{
    public class Statistics_ViewModel
    {
        public List<InvoiceDetail> InvoiceList { get; set; }

        //public List<Invoice> TourListInvoice { get; internal set; }
        public List<NavigationBar> TGNavigationBar { get; internal set; }

        public decimal Count {  get; set; }
    }
       
}

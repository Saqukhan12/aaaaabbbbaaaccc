using DotNetCoreBoilerplate.Models;
using System.Collections.Generic;

namespace DotNetCoreBoilerplate.ViewModel.CustomerVM
{
    public class CustomerContactsViewModel
    {
        public Customer Customer {  get; set; }
        public List<CustomerContact>  CustomerContact { get; set; }
    }
}

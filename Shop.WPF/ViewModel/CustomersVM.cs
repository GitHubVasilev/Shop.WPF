using Shop.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WPF.ViewModel
{
    internal class CustomersVM : BaseViewModel
    {
        public string Test
        {
            get 
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                return directoryInfo.FullName;

            }   
        }
    }
}

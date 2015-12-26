using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    class Program
    {
        static void Main(string[] args)
        {
            InvoiceManager invoiceManager = new InvoiceManager();
            var amount = invoiceManager.Amount;
        }
    }

    public partial class InvoiceManager
    {
        public void SetInvoice()
        {
        }

        public void CancelInvoice()
        {            
        }
    }

    public partial class InvoiceManager
    {
        public double Amount { get; set; }
    }
}

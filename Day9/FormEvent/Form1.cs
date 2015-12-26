using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormEvent.Annotations;

namespace FormEvent
{
    public partial class Form1 : Form
    {
        private Customer _customer;

        public Form1()
        {
            InitializeComponent();

            _customer = new Customer()
            {
                Id = 0,
            };

            _customer.PropertyChanged += _customer_PropertyChanged;
            bindingSource1.DataSource = _customer;
        }

        void _customer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _customer.Id = 1;
            _customer.Name = "Ünal";
            _customer.LastName = "Kırıkcı";
        }
    }

    public class Customer : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id)
                {
                    return;
                }
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == _lastName)
                {
                    return;
                }
                _lastName = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

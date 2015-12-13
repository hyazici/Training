using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsRoverUI
{
    public partial class Form1 : Form
    {
        private readonly MarsCommandSender _marsCommandSender;

        public Form1()
        {
            InitializeComponent();

            _marsCommandSender = new MarsCommandSender();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = textBox1.Text;

            _marsCommandSender.ExecuteCommand(command);

            textBox2.Text = _marsCommandSender.Output();
        }
    }
}

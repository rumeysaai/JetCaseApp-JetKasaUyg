using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Sell;

namespace UI
{
    public partial class Action : Form
    {
        public Employee employee;
        public Action(Employee emp)
        {
            InitializeComponent();
            employee = emp;
        }
        AdminPanel ad = new AdminPanel();
        private void Action_Load(object sender, EventArgs e)
        {
            if (employee.IsManager)
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible=false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ad.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories(employee);
            ct.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //Log out button
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();

        }
    }
}

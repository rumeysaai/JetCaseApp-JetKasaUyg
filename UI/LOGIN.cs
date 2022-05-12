using BLL.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        EmployeeManager emp = new EmployeeManager();
        private void LOGIN_Load(object sender, EventArgs e)
        {
            emp.ListBll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var em = emp.ListBll().FirstOrDefault(w => w.UserName == textBox1.Text && w.Password == textBox2.Text);
            if (em != null)
            {
                Action act = new Action(em);
                act.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password !");
            }
        }
    }
}

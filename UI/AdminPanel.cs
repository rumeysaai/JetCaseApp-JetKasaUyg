using BLL.Concrete;
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

namespace UI
{
    public partial class AdminPanel : Form
    {
        Employee employee;
        public AdminPanel()
        {
            InitializeComponent();
        }
        CategoryManager ctm = new CategoryManager();
        ProductManager prd = new ProductManager();
        SupplierManager spl = new SupplierManager();
        EmployeeManager eml = new EmployeeManager();
        OrderManager ord = new OrderManager();
        public void ClearAll()
        {
            cmbMngrEmp.Items.Clear();
            cmbMngrEmp.Items.Add("Yes");
            cmbMngrEmp.Items.Add("No");
            cmbCatUpdt.Items.Clear();
            cmbCatDlt.Items.Clear();
            cmbProductCategoryAdd.Items.Clear();
            cmbProductNameUpdate.Items.Clear();
            cmbProductNameDelete.Items.Clear();
            cmbCompNameUpdt.Items.Clear();
            cmbCompNameDlt.Items.Clear();
            cmbDltEmpTc.Items.Clear();
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {

            ClearAll();
            #region EmployeeTable
            dataGridView2.DataSource = eml.ListBll();
            DataGridViewColumn cl1 = dataGridView2.Columns[0];
            cl1.Width = 150;
            DataGridViewColumn cl2 = dataGridView2.Columns[1];
            cl2.Width = 150;
            DataGridViewColumn cl3 = dataGridView2.Columns[2];
            cl3.Width = 150;
            DataGridViewColumn cl4 = dataGridView2.Columns[3];
            cl4.Width = 150;
            DataGridViewColumn cl5 = dataGridView2.Columns[4];
            cl5.Width = 150;
            DataGridViewColumn cl6 = dataGridView2.Columns[5];
            cl6.Width = 150;
            #endregion

            #region OrderTable
            dataGridView1.DataSource = ord.ListBll();
            DataGridViewColumn or1 = dataGridView1.Columns[0];
            or1.Width = 150;
            DataGridViewColumn or2 = dataGridView1.Columns[1];
            or2.Width = 150;
            DataGridViewColumn or3 = dataGridView1.Columns[2];
            or3.Width = 150;
            DataGridViewColumn or4 = dataGridView1.Columns[3];
            or4.Width = 150;
            DataGridViewColumn or5 = dataGridView1.Columns[4];
            or5.Width = 150;
            #endregion


            #region Combobox foreach
            foreach (var item in ctm.ListBll())
            {
                cmbCatUpdt.Items.Add(item.CategoryName.ToString());
                cmbCatDlt.Items.Add(item.CategoryName.ToString());
                cmbProductCategoryAdd.Items.Add(item.CategoryName.ToString());

            }
            foreach (var item in prd.ListBll())
            {
                cmbProductNameUpdate.Items.Add(item.ProductName);
                cmbProductNameDelete.Items.Add(item.ProductName);
            }
            foreach (var item in spl.ListBll())
            {
                cmbCompNameUpdt.Items.Add(item.CompanyName);
                cmbCompNameDlt.Items.Add(item.CompanyName);
            }
            foreach (var item in eml.ListBll())
            {
                cmbDltEmpTc.Items.Add(item.TC);
            }
            #endregion

        }
        #region Category Settings
        //Category Settings
        private void bttncategoryadd_Click(object sender, EventArgs e)
        {
            //txtCatAdd.Text.Substring(0, txtCatAdd.Text.Count()-1)==" "


            //String.IsNullOrEmpty(txtCatAdd.Text)
            if (String.IsNullOrWhiteSpace(txtCatAdd.Text))
            {
                MessageBox.Show("Category name cannot be empty !");
            }
            else if (ctm.ListBll().FirstOrDefault(w => w.CategoryName == txtCatAdd.Text) == null)
            {
                ctm.AddBll(new Category { CategoryName = txtCatAdd.Text.Trim() });
                MessageBox.Show("Category name added !");
                txtCatAdd.Clear();
            }
            else
            {
                MessageBox.Show("This category already exist ! ");
            }

            cmbCatUpdt.Items.Clear();
            AdminPanel_Load(this, null);
        }

        private void bttncategoryupdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCatUpdt.Text) && txtCatUpdt.Text == " ")
            {
                MessageBox.Show("Category name cannot be empty !");
            }
            else if (ctm.ListBll().FirstOrDefault(w => w.CategoryName == txtCatUpdt.Text) == null)
            {
                var obje = ctm.ListBll().FirstOrDefault(w => w.CategoryName == cmbCatUpdt.SelectedItem.ToString());
                if (obje != null)
                    obje.CategoryName = txtCatUpdt.Text;
                ctm.UpdateBll(obje.Id, obje);
                MessageBox.Show("Category name added !");
                txtCatAdd.Clear();
            }
            else
            {
                MessageBox.Show("This category already exist ! ");
            }
            

            AdminPanel_Load(this, null);
        }

        private void btncategorydelete_Click(object sender, EventArgs e)
        {
            var obje = ctm.ListBll().FirstOrDefault(w => w.CategoryName == cmbCatDlt.SelectedItem.ToString());
            if (obje != null)
                obje.CategoryName = cmbCatDlt.Text;
            ctm.DeleteBll(obje);
            AdminPanel_Load(this, null);
        }
        #endregion

        #region Product Settings
        //Product settings
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var obje = ctm.ListBll().FirstOrDefault(w => w.CategoryName == cmbProductCategoryAdd.SelectedItem.ToString());

            prd.AddBll(new Product { ProductName = txtProductNameAdd.Text, UnitPrice = int.Parse(txtProductPriceAdd.Text), UnitsInStock = int.Parse(txtProductStockAdd.Text), CategoryId = obje.Id });
            txtProductNameAdd.Clear();
            txtProductPriceAdd.Clear();
            txtProductStockAdd.Clear();
            AdminPanel_Load(this, null);
        }

        private void btnUpdtProduct_Click(object sender, EventArgs e)
        {
            var obje = prd.ListBll().FirstOrDefault(w => w.ProductName == cmbProductNameUpdate.SelectedItem.ToString());
            if (obje != null)
            {
                obje.ProductName = txtProductNameUpdate.Text;
                obje.UnitPrice = int.Parse(txtProductPriceUpdate.Text);
                obje.UnitsInStock = int.Parse(txtProductStockUpdate.Text);
            }

            prd.UpdateBll(obje.Id, obje);
            txtProductNameUpdate.Clear();
            txtProductPriceUpdate.Clear();

            AdminPanel_Load(this, null);
        }

        private void btnDltProduct_Click(object sender, EventArgs e)
        {
            var obje = prd.ListBll().FirstOrDefault(w => w.ProductName == cmbProductNameDelete.SelectedItem.ToString());
            if (obje != null)
            {
                obje.ProductName = cmbProductNameDelete.SelectedItem.ToString();
            }
            prd.DeleteBll(obje);

            AdminPanel_Load(this, null);
        }

        
        #endregion

        #region Supplier Info
        //Supplier Info
        private void btnSuppAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCompNameAdd.Text) && String.IsNullOrEmpty(txtContactNameAdd.Text) && String.IsNullOrEmpty(txtPhoneAdd.Text))
            {
                MessageBox.Show("Category name cannot be empty !");
            }
            else if (spl.ListBll().FirstOrDefault(w => w.CompanyName == txtCompNameAdd.Text && w.ContactName == txtContactNameAdd.Text && w.Phone == txtPhoneAdd.Text) == null)
            {
                spl.AddBll(new Supplier { CompanyName = txtCompNameAdd.Text.Trim(), ContactName = txtContactNameAdd.Text, Phone = txtPhoneAdd.Text.Trim() });
                MessageBox.Show("Supplier information added!");
                txtCatAdd.Clear();
            }
            else
            {
                MessageBox.Show("This Supplier already exist ! ");
            }
            txtCompNameAdd.Clear();
            txtContactNameAdd.Clear();
            txtPhoneAdd.Clear();
            AdminPanel_Load(this, null);

        }

        private void btbSuppUpdt_Click(object sender, EventArgs e)
        {
            var obje = spl.ListBll().FirstOrDefault(w => w.CompanyName == cmbCompNameUpdt.SelectedItem.ToString());
            if (obje != null)
            {
                obje.CompanyName = txtCompUpdtNameUpdt.Text;
                obje.ContactName = txtContactNameUpdt.Text;
                obje.Phone = txtPhoneUpdt.Text;
            }

            spl.UpdateBll(obje.Id, obje);
            txtCompUpdtNameUpdt.Clear();
            txtContactNameUpdt.Clear();
            txtPhoneUpdt.Clear();
            AdminPanel_Load(this, null);
        }

        private void btnSuppDlt_Click(object sender, EventArgs e)
        {
            var obje = spl.ListBll().FirstOrDefault(w => w.CompanyName == cmbCompNameDlt.SelectedItem.ToString());

            spl.DeleteBll(obje);
            AdminPanel_Load(this, null);
        }
        #endregion

        #region Employee

        //Employee İnfoo
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (cmbMngrEmp.Text == "Yes")
            {
                if (String.IsNullOrEmpty(txtFirstNameAddEmp.Text) && String.IsNullOrEmpty(txtLastNameAddEmp.Text) && String.IsNullOrEmpty(txtAddTcEmp.Text) && String.IsNullOrEmpty(txtUserNameEmp.Text) && String.IsNullOrEmpty(txtPswEmp.Text))
                {
                    MessageBox.Show("Employee name cannot be empty !");
                }
                else if (eml.ListBll().FirstOrDefault(w => w.FirstName == txtFirstNameAddEmp.Text && w.LastName == txtLastNameAddEmp.Text && w.TC == txtAddTcEmp.Text && w.UserName == txtUserNameEmp.Text && w.Password == txtPswEmp.Text) == null)
                {
                    eml.AddBll(new Employee { FirstName = txtFirstNameAddEmp.Text.Trim(), LastName = txtLastNameAddEmp.Text, TC = txtAddTcEmp.Text.Trim(), UserName = txtUserNameEmp.Text, Password = txtPswEmp.Text, IsManager = true });
                    MessageBox.Show("Employee information added!");
                    txtCatAdd.Clear();
                }
                else
                {
                    MessageBox.Show("This Employee already exist ! ");
                }

            }
            else
            {
                if (String.IsNullOrEmpty(txtFirstNameAddEmp.Text) && String.IsNullOrEmpty(txtLastNameAddEmp.Text) && String.IsNullOrEmpty(txtAddTcEmp.Text) && String.IsNullOrEmpty(txtUserNameEmp.Text) && String.IsNullOrEmpty(txtPswEmp.Text))
                {
                    MessageBox.Show("Employee name cannot be empty !");
                }
                else if (eml.ListBll().FirstOrDefault(w => w.FirstName == txtFirstNameAddEmp.Text && w.LastName == txtLastNameAddEmp.Text && w.TC == txtAddTcEmp.Text && w.UserName == txtUserNameEmp.Text && w.Password == txtPswEmp.Text) == null)
                {
                    eml.AddBll(new Employee { FirstName = txtFirstNameAddEmp.Text.Trim(), LastName = txtLastNameAddEmp.Text, TC = txtAddTcEmp.Text.Trim(), UserName = txtUserNameEmp.Text, Password = txtPswEmp.Text, IsManager = false });
                    MessageBox.Show("Employee information added!");
                    txtCatAdd.Clear();
                }
                else
                {
                    MessageBox.Show("This Employee already exist ! ");
                }


            }
            txtFirstNameAddEmp.Clear();
            txtLastNameAddEmp.Clear();
            txtAddTcEmp.Clear();
            txtUserNameEmp.Clear();
            txtPswEmp.Clear();
            AdminPanel_Load(this, null);
        }

        private void btnDltEmp_Click(object sender, EventArgs e)
        {
            var obje = eml.ListBll().FirstOrDefault(w => w.TC == cmbDltEmpTc.SelectedItem.ToString());

            eml.DeleteBll(obje);
            MessageBox.Show("Aferin koçuma");
            AdminPanel_Load(this, null);
        }
        #endregion

        #region AccountBook

        private void btnCalculateAccount_Click(object sender, EventArgs e)
        {
            double dtotal = 0;
            double mtotal = 0;
            List<Order> orders = new List<Order>();
            orders = ord.ListBll();
          
            DateTime date = new DateTime(monthCalendar1.SelectionRange.Start.Year, monthCalendar1.SelectionRange.Start.Month, monthCalendar1.SelectionRange.Start.Day);

            var dailyorders = orders.Where(o => o.OrderDate.Date == date).ToList();
            var monthlyorders = orders.Where(o=>o.OrderDate.Date.Month==date.Month).ToList();

            
            foreach (var o in dailyorders)
            {
                dtotal = dtotal + o.UnitPrice*o.Quantity;
            }
            label30.Text = dtotal.ToString();

            foreach (var m in monthlyorders)
            {
                mtotal += m.Quantity * m.UnitPrice;
            }
            label31.Text=mtotal.ToString();

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)// back button
        {
            var em = eml.ListBll().FirstOrDefault();
            Action act = new Action(em);
            act.Show();
            this.Hide();

        }

        #region TextControls
        private void txtCatAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
        private void txtCatUpdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtProductPriceAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtProductStockAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtProductPriceUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtProductStockUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhoneAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhoneUpdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAddTcEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtProductNameAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtProductNameUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtCompNameAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtContactNameAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtCompUpdtNameUpdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtContactNameUpdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtFirstNameAddEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtLastNameAddEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
        #endregion
    }
}

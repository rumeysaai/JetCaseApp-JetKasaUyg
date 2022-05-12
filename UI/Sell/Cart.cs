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

namespace UI.Sell
{
    public partial class Cart : Form
    {
        private List<Product> _order;

        Order or = new Order();
        Dictionary<Product, int> ord = new Dictionary<Product, int>();

        public Cart()
        {
            InitializeComponent();

        }
        public Cart(List<Product> order)
        {
            InitializeComponent();
            _order = order;
        }
        double total = 0;
        string pname = "";
        private void Cart_Load(object sender, EventArgs e)
        {
            foreach (Product product in _order)
            {
                total = total + product.UnitPrice;
                pname = product.ProductName;
                listBox1.Items.Add(pname + " : " + product.UnitPrice + "\n");
                lblTotalPrice.Text = total.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories(_order);
            ct.Show();
            this.Hide();

        }
        double total2 = 0;
        private void btnRemove_Click(object sender, EventArgs e)
        {

            int secim = listBox1.SelectedIndex;

            if (secim != -1)
            {

                string s = listBox1.Items[secim].ToString().Split(':')[0].Trim();
                Product pr = _order.FirstOrDefault(o => o.ProductName == s);
                listBox1.Items.RemoveAt(secim);

                _order.Remove(pr);

                total = 0;
                foreach (Product product in _order)
                    total = total + product.UnitPrice;

                lblTotalPrice.Text = total.ToString();

            }
            else
            {
                MessageBox.Show("Make a selection first !");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            lblTotalPrice.Text = "--";
            _order.Clear();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            OrderManager order = new OrderManager(); //Bll den gelip metotları kullanmamız için iş kuralı
            Order or = new Order();

            ProductManager pm = new ProductManager();
            #region mutlununçözümü
            //List<string> dizi = new List<string>(); //burda bir dizi tuttum.
            //or = new Order();
            //OrderManager order = new OrderManager();

            //for (int h = 0; h < listBox1.Items.Count; h++) //for dögüsü açtım (listbocıx kopyasını almış oldum.)
            //{
            //    dizi.Add(listBox1.Items[h].ToString());
            //}




            //foreach (var item in dizi.Distinct()) //kopyalanan dizi içerisinde geziyorum
            //{
            //    int toplamsayi = 0;
            //    string urunadi = item;
            //    foreach (var urun in listBox1.Items)
            //    {
            //        if (urun == urunadi)
            //        {
            //            toplamsayi++;
            //        }

            //    }
            //    or.Quantity = toplamsayi;
            //    or.ProductId = pm.ListBll().FirstOrDefault(p => p.ProductName == urunadi).Id;
            //    or.ProductName = pm.ListBll().FirstOrDefault(p => p.ProductName == urunadi).ProductName;
            //    or.OrderDate = DateTime.Now;
            //    order.AddBll(or);
            //}
            #endregion

            try
            {
                foreach (Product item in _order)
                {
                    if (ord.ContainsKey(item))
                    {
                        ord[item] = ord[item] + 1;  //dictionarynin value sı
                    }
                    else
                    {
                        ord[item] = 1;
                    }

                }

                foreach (var item in ord)
                {

                    Product k = item.Key;
                    int v = item.Value;
                    //string name = k.ProductName;
                    //or.ProductName = name;
                    or.ProductName = k.ProductName;
                    or.ProductId = pm.ListBll().FirstOrDefault(p => p.ProductName == k.ProductName).Id;
                    or.UnitPrice = pm.ListBll().FirstOrDefault(p => p.UnitPrice == k.UnitPrice).UnitPrice;
                    or.Quantity = v;
                    or.OrderDate = DateTime.Now;
                    order.AddBll(or);
                }
                listBox1.Items.Clear();
                lblTotalPrice.Text = "";
                MessageBox.Show("Payment successful !");
            }
            catch (Exception)
            {

                MessageBox.Show("Payment failed !");
            }
        }
    }
}

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
    public partial class Products : Form
    {
        int _catid;
        List<Product> listem;
        List<Product> order;
        public Products(int catid)
        {
            InitializeComponent();
            _catid = catid;
            order = new List<Product>();
            
        }
        public Products(int catid, List<Product> _order)
        {
            InitializeComponent();
            _catid = catid;
            order = new List<Product>();
            order = _order;
        }
        double total = 0;
        string pname = "";
        ProductManager pm = new ProductManager();
        Button BtnEkle, Btn;
        FlowLayoutPanel Flp;
        private void Products_Load(object sender, EventArgs e)
        {
            foreach (Product product in order)
            {
                total = total + product.UnitPrice;
                pname = product.ProductName;
                listBox1.Items.Add(pname + " : " + product.UnitPrice + "\n");
            }
            listem = pm.ListBll().Where(w => w.CategoryId == _catid).ToList();
            // burada where kullanarak bütün listeyi filtreledim. Bir Önceki Formdan category id yi alıp burada kullandım
            Flp = new FlowLayoutPanel();
            Flp.Width = 1150;
            Flp.Height = 800;
            //Flp.Dock = DockStyle.Top;
            Flp.Location = new Point(220, 100);
            Flp.BorderStyle = BorderStyle.FixedSingle;//Çerçeve
            //Flp.BackgroundImage = "C:\Users\rumey\Documents\Eğitimler\Yazılım Kursu\backend\wlp";
            Flp.AutoScroll = false;
            this.Controls.Add(Flp);
            Buton_Ekle();
        }
        public void Buton_Ekle()
        {
            Flp.Controls.Clear();
            foreach (Product item in listem)
            {
                Btn = new Button();
                Btn.Text = item.ProductName;
                Btn.Width = 220;
                Btn.Height = 160;
                Btn.Margin = new Padding(30, 30, 30, 30);
                Btn.Font = new Font("Arial", 20);
                Btn.FlatStyle = FlatStyle.Flat;
                Btn.FlatAppearance.BorderSize = 5;
                Btn.Click += Btn_Click;
                Flp.Controls.Add(Btn);
            }
        }

        private void button1_Click(object sender, EventArgs e) //back
        {
            Categories ct = new Categories(order);
            ct.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //cart button
        {
            Cart cart = new Cart(order);
            cart.Show();
            this.Close();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var product = listem.Where(r => r.ProductName == (sender as Button).Text).First();
            order.Add(product);
            listBox1.Items.Clear();
            Products_Load(this, null);
        }
    }
}

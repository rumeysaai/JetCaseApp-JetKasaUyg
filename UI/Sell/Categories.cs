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
    public partial class Categories : Form
    {
        List<Product> order;
        public Categories()
        {
            InitializeComponent();
            order = new List<Product>();
        }

        public Categories(List<Product> _order)
        {
            InitializeComponent();
            order = new List<Product>();
            order = _order;
        }

        CategoryManager ctm = new CategoryManager();
        Button BtnEkle, Btn;
        FlowLayoutPanel Flp;
        double total = 0;
        string pname = "";
        public void Buton_Ekle()
        {
            var categoryList = ctm.ListBll();

            Flp.Controls.Clear();

            //foreach (var item in ctm.ListBll())
            //{ 
            //    Btn = new Button();
            //    Btn.Text = item.CategoryName;
            //    Btn.Click += Btn_Click;
            //    Flp.Controls.Add(Btn);
            //}
           
            for (int i = 0; i < categoryList.Count; i++)
            {

                Btn = new Button();
                Btn.Text = categoryList[i].CategoryName;
                Btn.Width = 220;
                Btn.Height = 160;
                Btn.Margin = new Padding(30, 30, 30, 30);
                Btn.FlatStyle= FlatStyle.Flat;
                Btn.FlatAppearance.BorderSize = 5;
                Btn.FlatAppearance.MouseDownBackColor = Color.LightCyan;
                Btn.FlatAppearance.MouseOverBackColor = Color.LightCyan;
                Btn.Font = new Font("Arial", 20);
                Btn.Click += Btn_Click;
                Flp.Controls.Add(Btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
           
            Products vg = new Products(ctm.ListBll().FirstOrDefault(w => w.CategoryName == (sender as Button).Text.ToString()).Id, order);
            vg.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // back button
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //cart button
        {
            Cart cart = new Cart(order);
            cart.Show();
            this.Hide();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            foreach (Product product in order)
            {
                total = total + product.UnitPrice;
                pname = product.ProductName;
                listBox1.Items.Add(pname + " : " + product.UnitPrice + "\n");
            }

            Flp = new FlowLayoutPanel();
            Flp.Width = 1250;
            Flp.Height = 800;
            //Flp.Dock = DockStyle.Top;
            Flp.Location = new Point(220, 100);
            Flp.BorderStyle = BorderStyle.FixedSingle;//Çerçeve
            Flp.BackColor = Color.Gainsboro;
            Flp.AutoScroll = false;
            this.Controls.Add(Flp);

            Buton_Ekle();
            
        }

    }

}

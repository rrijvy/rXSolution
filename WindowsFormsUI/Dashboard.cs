using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class Dashboard : Form
    {
        static ShoppingCart cart = new ShoppingCart();

        public Dashboard()
        {
            InitializeComponent();
            PopulateCartWithDemoData();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new Product { Name = "Cereal", Price = 3.63M });
            cart.Items.Add(new Product { Name = "Milk", Price = 2.95M });
            cart.Items.Add(new Product { Name = "Strawberries", Price = 7.51M });
            cart.Items.Add(new Product { Name = "Blueberries", Price = 8.84M });
        }

        private void buttonMessageBoxDemo_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal(SubtotalAlert, CalculateLeveledDiscount, PrintOutDiscountAlert);
            MessageBox.Show($"The total is {total:C2}");
        }

        private void buttonTextBoxDemo_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal((subTotal) => textBoxSubtotal.Text = $"{subTotal:C2}",
                (List<Product> products, decimal subTotal) =>
                {
                    return subTotal - products.Count();
                },
                (message) => MessageBox.Show(message));

            textBoxtotal.Text = $"{total:C2}";
        }

        private void PrintOutDiscountAlert(string message)
        {
            MessageBox.Show(message);
        }

        private void SubtotalAlert(decimal subTotal)
        {
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }

        private decimal CalculateLeveledDiscount(List<Product> products, decimal subtotal)
        {
            return subtotal - products.Count();
        }
    }
}

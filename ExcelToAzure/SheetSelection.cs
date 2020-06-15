using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToAzure
{
    public partial class SheetSelection : Form
    {
        public EventHandler Selected;
        public SheetSelection()
        {
            InitializeComponent();
        }

        public static SheetSelection Open (List<string> sheets)
        {
            var x = new SheetSelection();
            sheets.ForEach(s => x.SheetList.Items.Add(s));
            x.TopLevel = true;
            return x;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (SheetList.SelectedIndex < 0)
                AcceptButton.Text = "SELECT SHEET!";
            else
            {
                Selected?.Invoke(SheetList.SelectedItem, new EventArgs());
                this.Close();
            }
        }
    }
}

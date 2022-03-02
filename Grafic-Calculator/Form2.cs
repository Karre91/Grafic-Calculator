using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafic_Calculator
{
    public partial class Form2 : Form
    {
        ReadAndWrite RW = new ReadAndWrite();
        List<string> historyList;
        public Form2()
        {
            InitializeComponent();
        }

        public void ReadList()
        {
            historyList = RW.ShowHistory();
            
            foreach (var l in historyList)
            {
                //ListViewItem listItem = new ListViewItem();
                //listItem.Text = l;
                listView_History.Items.Add(l);
            }
            listView_History.View = View.List;
        }
    }
}

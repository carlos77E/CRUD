using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            dsCRDTableAdapters.TablafinalTableAdapter ta = 
                new dsCRDTableAdapters.TablafinalTableAdapter();
            dsCRD.TablafinalDataTable dt = ta.GetData();
            dataGridView1.DataSource = dt;
        }

        private void refrescar_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar frm= new Agregar();  
            frm.ShowDialog();
            Refresh(); 
        }


        private int? GetId()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }
         private void button2_Click(object sender, EventArgs e)
        {
           int? id = GetId();
            if (id != null)
            {
                dsCRDTableAdapters.TablafinalTableAdapter ta = new
                    dsCRDTableAdapters.TablafinalTableAdapter();
                ta.Remove((int)id);
                Refresh();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Agregar frm = new Agregar(id);
                frm.ShowDialog();
                Refresh();
            }
        }
    }
}

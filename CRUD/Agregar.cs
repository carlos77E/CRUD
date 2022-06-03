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
    public partial class Agregar : Form
    {
        private int? Id;
        public Agregar(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsCRDTableAdapters.TablafinalTableAdapter ta=
                new dsCRDTableAdapters.TablafinalTableAdapter();
            if (Id == null)
            {


                ta.Add(txtNC.Text.Trim(), (int)txtNL.Value);
            }
            else
            {
                ta.Edit(txtNC.Text.Trim(), (int)txtNL.Value, (int)Id);
            }
            this.Close();   
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            if (Id != null) 
            {
                dsCRDTableAdapters.TablafinalTableAdapter ta =
                    new dsCRDTableAdapters.TablafinalTableAdapter();
              dsCRD.TablafinalDataTable dt=  ta.GetDataById((int)Id);
              dsCRD.TablafinalRow row = (dsCRD.TablafinalRow)dt.Rows[0];
                txtNC.Text = row.Nombre_Cancion;
                txtNL.Value = row.Fecha_lanzamiento;


            }
        }
    }
}

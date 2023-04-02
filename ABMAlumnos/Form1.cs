using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABMAlumnos
{
    public partial class frmAlumno : Form
    {
        AccesoDatos datos = new AccesoDatos(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\ABMAlumnos\DBF_ABM_alumno_personas.mdb");
        const int tam = 50;
        Alumno[] va = new Alumno[tam];
        int c = 0;

        public frmAlumno()
        {
            InitializeComponent();
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cargarCombo(cboTipoDoc, "tipo_documento");
            cargarCombo(cboCarrera, "carreras");
            cargarLista("alumnos");
        }
        private void cargarCombo(ComboBox combo,string nombreTabla)
        {
            DataTable dt = new DataTable();
            dt = datos.consultarTabla(nombreTabla);
            combo.DataSource = dt;
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
        }
        private void cargarLista(string nombreTabla)
        {
            c = 0;
            datos.leerTabla(nombreTabla);
            while (datos.pDr.Read())
            {
                Alumno a = new Alumno();
                if (!datos.pDr.IsDBNull(0))
                a.pApellido = datos.pDr.GetString(0);
                if (!datos.pDr.IsDBNull(1))
                    a.pNombre = datos.pDr.GetString(1);
                if (!datos.pDr.IsDBNull(2))
                    a.pFechaNacimiento = datos.pDr.GetDateTime(2);
                if (!datos.pDr.IsDBNull(3))
                    a.pSexo = datos.pDr.GetInt32(3);
                if (!datos.pDr.IsDBNull(4))
                    a.pTipoDocumento = datos.pDr.GetInt32(4);
                if (!datos.pDr.IsDBNull(5))
                    a.pDocumento = datos.pDr.GetInt32(5);
                if (!datos.pDr.IsDBNull(6))
                    a.pCalle = datos.pDr.GetString(6);
                if (!datos.pDr.IsDBNull(7))
                    a.pNumero = datos.pDr.GetInt32(7);
                if (!datos.pDr.IsDBNull(8))
                    a.pActividad = datos.pDr.GetBoolean(8);
                if (!datos.pDr.IsDBNull(9))
                    a.pCasado = datos.pDr.GetBoolean(9);
                if (!datos.pDr.IsDBNull(10))
                    a.pHijos = datos.pDr.GetBoolean(10);
                if (!datos.pDr.IsDBNull(11))
                    a.pCantidad = datos.pDr.GetInt32(11);
                if (!datos.pDr.IsDBNull(12))
                    a.pCarrera = datos.pDr.GetInt32(12);
                va[c] = a;
                c++;
                }
            datos.pDr.Close();
            datos.desconectar();

            lstAlumno.Items.Clear();
            for (int i = 0; i < c; i++)
                lstAlumno.Items.Add(va[i].toString());

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Alumno a = new Alumno();
            a.pApellido = txtApellido.Text;
            a.pNombre = txtNombre.Text;
            a.pFechaNacimiento = dtpFecNac.Value;
            if (rbtMasculino.Checked)
                a.pSexo = 1;
            else
                a.pSexo = 2;
            a.pTipoDocumento =Convert.ToInt32( cboTipoDoc.SelectedValue);
            a.pDocumento = int.Parse(txtDocumento.Text);
            a.pCalle = txtCalle.Text;
            a.pNumero = int.Parse(txtNumero.Text);
            a.pActividad = chkActividad.Checked;
            a.pCasado = chkCasado.Checked;
            a.pHijos = chkHijo.Checked;
            a.pCantidad = int.Parse(txtCantidad.Text);
            a.pCarrera = Convert.ToInt32(cboCarrera.SelectedValue);

            string sql = "INSERT INTO Alumnos values('" +
                        a.pApellido + "','" +
                        a.pNombre + "','" +
                        a.pFechaNacimiento.ToShortDateString() + "'," +
                        a.pSexo + "," +
                        a.pTipoDocumento + "," +
                        a.pDocumento + ",'" +
                        a.pCalle + "'," +
                        a.pNumero + "," +
                        a.pActividad + "," +
                        a.pCasado + "," +
                        a.pHijos + "," +
                        a.pCantidad + "," +
                        a.pCarrera + ")";

            //MessageBox.Show(sql);

            datos.actualizar(sql);
            cargarLista("alumnos");

        }

        private void chkHijo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHijo.Checked)
                txtCantidad.Enabled = true;
            else
                txtCantidad.Enabled = false;
        }
    }
}

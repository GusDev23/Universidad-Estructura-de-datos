using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassUniversidad;
namespace WinEstructurasUniversidad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pnlBody.BackColor = Color.FromArgb(211, 228, 205);
            pnlMenu.BackColor = Color.FromArgb(153, 167, 153);
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            gpbCarrera.Location = new Point(194, 100);
            gpbCarrera.Visible = true;
        }
        //DISEÑO FORMULARIO
        private void button2_Click(object sender, EventArgs e)
        {
            gpbCarrera.Location = new Point(194, 100);
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            gpbCarrera.Visible = true;
            gpbGrupos.Visible = false;
            gpbAlumnos.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gpbGrupos.Location = new Point(194, 100);
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 0;
            gpbGrupos.Visible = true;
            gpbCarrera.Visible = false;
            gpbAlumnos.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gpbAlumnos.Location = new Point(194, 100);
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 1;
            gpbAlumnos.Visible = true;
            gpbGrupos.Visible =false;
            gpbCarrera.Visible = false;
        }
        //FUNCIONES DEL FORMULARIO        
        ListaLigadaDobleAlumno refUni = new ListaLigadaDobleAlumno();
        private void btnInsertarInicioCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(refUni.refGrupo.ligaGrupo.InsertarInicio(txtCarrera.Text, Convert.ToInt16(txtAñoFundacion.Text)));
                LimpiarCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingresa correctamente los datos");
            }
           
        }

        private void btnInsertarFinalCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(refUni.refGrupo.ligaGrupo.InsertarFinal(txtCarrera.Text, Convert.ToInt16(txtAñoFundacion.Text)));
                LimpiarCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingresa correctamente los datos");
            }
            
        }

        private void btnMostrarCarreras_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] temp = refUni.refGrupo.ligaGrupo.MostrarArreglo();
            foreach (string datos in temp)
            {
                listBox1.Items.Add(datos);
            }
        }

        private void brnEliminarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                Carrera temp = refUni.refGrupo.ligaGrupo.EliminarCarrera(listBox1.SelectedIndex);
                if (temp != null)
                {
                    MessageBox.Show("Carrera eliminada: " + temp.Nombre);
                    btnMostrarCarreras_Click(sender, e);
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                }
                else
                    MessageBox.Show("La carrera no existe");
            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona la carrera para eliminar");
            }
            
        }

        private void btnInsertarInicioGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(refUni.refGrupo.InsertarGrupoInicio(Convert.ToInt16(txtGrado.Text)
                , txtLetra.Text[0], txtTurno.Text, txtEspecialidad.Text, listBox1.SelectedIndex));
                LimpiarCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("-Ingresa correctamente los datos\n" +
                    "-Selecciona una carrera");
            }
            
        }

        private void btnInsertarFinalGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(refUni.refGrupo.InsertarGrupoFinal(Convert.ToInt16(txtGrado.Text)
                , txtLetra.Text[0], txtTurno.Text, txtEspecialidad.Text, listBox1.SelectedIndex));
                LimpiarCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("-Ingresa correctamente los datos\n" +
                   "-Selecciona una carrera");
            }
        }

        private void btnMostrarGrupos_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex >= 0)
            {
                string[] temp = refUni.refGrupo.MostrarGrupos(listBox1.SelectedIndex);
                if (temp != null)
                {
                    foreach (string datos in temp)
                    {
                        listBox2.Items.Add(datos);
                    }
                }
            }
        }

        private void btnInsertarMedioGrupo_Click(object sender, EventArgs e)
        {
            try
            {               
                MessageBox.Show(refUni.refGrupo.InsertarMedio(Convert.ToInt16(txtGrado.Text)
                , txtLetra.Text[0], txtTurno.Text, txtEspecialidad.Text, listBox1.SelectedIndex, listBox2.SelectedIndex));
                LimpiarCajas();

            }
            catch (Exception)
            {
                MessageBox.Show("-Ingresa correctamente los datos\n" +
                    "-Selecciona la carrera y el grupo");
            }
            
        }

        private void btnEliminarGrupos_Click(object sender, EventArgs e)
        {
            try
            {
                Grupo temp = refUni.refGrupo.EliminarGrupo(listBox1.SelectedIndex, listBox2.SelectedIndex);
                if (temp != null)
                {
                    MessageBox.Show("Grupo eliminado: " + temp.Grado + "" + temp.Letra);
                    btnMostrarGrupos_Click(sender, e);
                    listBox3.Items.Clear();
                }
                else
                    MessageBox.Show("Lista vacia");
            }
            catch (Exception)
            {
                MessageBox.Show("-Selecciona el grupo a eliminar");
            }
            
        }

        private void btnInsertarInicioAñumno_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(refUni.InsertarAlumnoInicio(txtMatricula.Text, txtNombre.Text,
                    Convert.ToInt16(txtEdad.Text), listBox1.SelectedIndex, listBox2.SelectedIndex));
                LimpiarCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("-Ingresa correctamente los datos\n" +
                    "-Slecciona una carrera y un grupo");
            }
        }

        private void btnInsertarFinalAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(refUni.InsertarAlumnoFinal(txtMatricula.Text, txtNombre.Text,
                    Convert.ToInt16(txtEdad.Text), listBox1.SelectedIndex, listBox2.SelectedIndex));
                LimpiarCajas();
            }
            catch (Exception)
            {
                MessageBox.Show("-Ingresa correctamente los datos\n" +
                    "-Slecciona una carrera y un grupo");
            }
        }

        private void btnMostrarAlumnos_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (listBox2.SelectedIndex >= 0)
            {
                string[] temp = refUni.MostrarAlumnos(listBox1.SelectedIndex,listBox2.SelectedIndex);
                if (temp != null)
                {
                    foreach (string datos in temp)
                    {
                        listBox3.Items.Add(datos);
                    }
                }
            }
        }

        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {            
            try
            {
                Alumno temp = refUni.EliminarAlumno(listBox1.SelectedIndex, listBox2.SelectedIndex, listBox3.SelectedIndex);
                if (temp != null)
                {
                    MessageBox.Show("Alumno eliminado: " + temp.Nombre);
                    btnMostrarAlumnos_Click(sender, e);
                }
                else
                    MessageBox.Show("Lista vacia");
            }
            catch (Exception)
            {

                MessageBox.Show("Selecciona carrera y grupo\n" +
                    "Selecciona grupo a eliminar");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMostrarGrupos_Click(sender, e);
            btnMostrarAlumnos_Click(sender, e);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMostrarAlumnos_Click(sender, e);
        }
        private void LimpiarCajas()
        {
            txtAñoFundacion.Text = "";
            txtCarrera.Text = "";
            txtEdad.Text = "";
            txtEspecialidad.Text = "";
            txtGrado.Text = "";
            txtLetra.Text = "";
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtTurno.Text = "";
        }


    }
}

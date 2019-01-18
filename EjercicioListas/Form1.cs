using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioListas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void BotonMostrar_Click(object sender, EventArgs e)
        {
            BindingList<Personas> ListaPersonas = new BindingList<Personas>();

            ListaPersonas.Add(new Personas() { ID = 1, Nombre = "Pepe", Email = "xxx@email.com", Telefono = 65634 });
            ListaPersonas.Add(new Personas() { ID = 2, Nombre = "Luis", Email = "aaa@email.com", Telefono = 87791 });
            ListaPersonas.Add(new Personas() { ID = 3, Nombre = "María", Email = "hhh@email.com", Telefono = 78519 });
            ListaPersonas.Add(new Personas() { ID = 4, Nombre = "Helena", Email = "zzz@email.com", Telefono = 16728 });

            dataGridView1.DataSource = ListaPersonas;
        }

        private void BotonAñadir_Click(object sender, EventArgs e)
        {
            
        }
    }
}

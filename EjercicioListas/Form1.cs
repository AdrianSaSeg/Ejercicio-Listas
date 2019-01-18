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
        //Creamos la lista
        BindingList<Personas> ListaPersonas = new BindingList<Personas>();

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Llenamos la lista de elementos al cargar el form principal
            ListaPersonas.Add(new Personas() { ID = 1, Nombre = "Pepe", Email = "xxx@email.com", Telefono = "65634" });
            ListaPersonas.Add(new Personas() { ID = 2, Nombre = "Luis", Email = "aaa@email.com", Telefono = "87791" });
            ListaPersonas.Add(new Personas() { ID = 3, Nombre = "María", Email = "hhh@email.com", Telefono = "78519" });
            ListaPersonas.Add(new Personas() { ID = 4, Nombre = "Helena", Email = "zzz@email.com", Telefono = "16728" });
        }

        private void BotonMostrar_Click(object sender, EventArgs e)
        {
           //Llevamos al datagrid los elementos de la lista
           dataGridView1.DataSource = ListaPersonas;
        }

        private void BotonAñadir_Click(object sender, EventArgs e)
        {
            //Añadimos elementos al datagrid con los datos introducidos en los textbox
            ListaPersonas.Add(new Personas() {ID= Convert.ToInt32(textBoxID.Text), Nombre= textBoxNombre.Text, Email= textBoxEmail.Text, Telefono= textBoxTelefono.Text });
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            //Elimino un elemento de la lista utilizando su ID, se pone el -1 porque la funcion busca por el indice
            ListaPersonas.RemoveAt(Convert.ToInt32(textBoxID.Text) - 1);
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            ListaPersonas.ToList<Personas>().Find(x => x.ID == Convert.ToInt32(textBoxID.Text));
        }
    }
}

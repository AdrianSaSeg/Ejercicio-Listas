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

            //inhabilito el botón de eliminar, porque no tiene sentido, ya que no hay nada en el datagrid
            BotonEliminar.Enabled = false;
        }

        private void BotonMostrar_Click(object sender, EventArgs e)
        {
           //Llevamos al datagrid los elementos de la lista
           dataGridView1.DataSource = ListaPersonas;
            
           //Ahora que ya hay datos en el datagrid, vuelvo a habilitar el boton de eliminar
           BotonEliminar.Enabled = true;
        }

        private void BotonAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                //Añadimos elementos al datagrid con los datos introducidos en los textbox
                ListaPersonas.Add(new Personas()
                {
                    ID = Convert.ToInt32(textBoxID.Text),
                    Nombre = textBoxNombre.Text,
                    Email = textBoxEmail.Text,
                    Telefono = textBoxTelefono.Text
                });

                if (string.IsNullOrEmpty(textBoxID.Text))
                {
                    MessageBox.Show("Error. El campo ID no puede quedar vacío");
                }

                if (string.IsNullOrEmpty(textBoxNombre.Text))
                {
                    MessageBox.Show("Error. El campo Nombre no puede quedar vacío");
                }

                if (string.IsNullOrEmpty(textBoxEmail.Text))
                {
                    MessageBox.Show("Error. El campo Email no puede quedar vacío");
                }

                if (string.IsNullOrEmpty(textBoxTelefono.Text))
                {
                    MessageBox.Show("Error. El campo Telefono no puede quedar vacío");
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message + " Debes introducir un número en el campo ID");                            
            }            
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            /////////////OTRA FORMA DE HACERLO//////////////////////
            //Elimino un elemento de la lista utilizando su ID, se pone el -1 porque RemoveAt busca por el indice
            //ListaPersonas.RemoveAt(Convert.ToInt32(textBoxID.Text) - 1);

            //Compruebo que he seleccionado una fila
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Obtengo el indice del datagrid y lo almaceno en una variable
                int indice = dataGridView1.SelectedRows[0].Index;
                //Y ahora lo elimino del datagrid y la lista simultaneamente
                ListaPersonas.RemoveAt(indice);
            }
            else
            {
                MessageBox.Show("Tienes que seleccionar una fila para eliminarla");
            }
                   
        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            ListaPersonas.ToList<Personas>().Find(x => x.ID == Convert.ToInt32(textBoxID.Text));
        }
    }
}

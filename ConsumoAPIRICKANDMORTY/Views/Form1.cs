using ConsumoAPIRICKANDMORTY.Control;
using ConsumoAPIRICKANDMORTY.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoAPIRICKANDMORTY
{
    public partial class Form1 : Form
    {
            private PersonajeController PersonajeController;
        private Personajes personajes;
            

        public Form1()
        {
            InitializeComponent();
            PersonajeController = new PersonajeController();
            personajes = new Personajes();
        }

        private async void GetPersonajes() {
            
            personajes = await PersonajeController.GetAllPersonajes();

            if (personajes != null)
            {
                foreach (var personaje in personajes?.results)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(ListPersonajes);

                    row.Cells[0].Value = personaje.name;
                    row.Cells[1].Value = personaje.gender;
                    row.Cells[2].Value = personaje.species;
                    row.Cells[3].Value = personaje.origin.name;

                    ListPersonajes.Rows.Add(row);
                }
            }
            else {
                MessageBox.Show("NO SE OBTUVO RESPUESTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPersonajes();
        }
    }
}

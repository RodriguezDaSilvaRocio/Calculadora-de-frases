using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace seminarioejercicio5
{
    public partial class formulario1 : Form
    {
        public formulario1()
        {
            //verifico que los eventos esten conectados

            InitializeComponent();
            this.txtInput.KeyPress += new KeyPressEventHandler(this.txtbox_1_KeyPress);
            this.frasesbox.SelectedIndexChanged += new EventHandler(this.frasesbox_SelectedIndexChanged);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
        }


        private void txtbox_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // controlar accion para tecla enter

            if ((e.KeyChar) == 13)
            {
                //obtener frase sin espacios
                string phrase = txtInput.Text.Trim();

                //pregunto al usuario si realmente deseo agregar la palabra

                DialogResult Resultado = MessageBox.Show("¿Desea agregar la palabra?", "Advertencia", MessageBoxButtons.OKCancel);
                
                if (Resultado == DialogResult.OK)
                {
                    //agrego y limpio el box
                    frasesbox.Items.Add(phrase);
                    txtInput.Clear();
                    txtInput.Focus();

                }

                else 
                {
                    txtInput.Focus();
                }
                
                e.Handled = false;
            }

        }
        private void frasesbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //con el null verificio si hay un elemento seleccionado
                if(frasesbox.SelectedItem != null)
                {

                    //llamo a los metodos
                    string selectedPhrase = frasesbox.SelectedItem.ToString();

                    int characterCount = CalculatecharacterCount(selectedPhrase);
                    int spaceCount = CalculatespaceCount(selectedPhrase);
                    string firstWord = GetfirstWord(selectedPhrase);
                    string lastWord = GetlastWord(selectedPhrase);

                    //muestro resultado en el label

                    lblresultado.Text = "La cantidad de caracteres es: " + characterCount.ToString() + "\n" +
                        "Cantidad de espacios vacios: " + spaceCount.ToString() + "\n" + "Primera palabra: " +
                        firstWord + "\n" + "Ultima palabra: " + lastWord;
                }
            }
            private void btnClear_Click(object sender, EventArgs e)
            {
            //pregunto si deseo limpiar el formulario
                DialogResult resultado = MessageBox.Show("¿Desea limpiar todo el contenido?", "Confirmar", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    //limpio
                    txtInput.Clear();
                    frasesbox.Items.Clear();
                    lblresultado.Text = string.Empty;
                }
            }

        private int CalculatecharacterCount(string text)
        {
            //regreso longitud
            return text.Length;
        }

        private int CalculatespaceCount(string text)
        {
            //cuento espacios en blanco
            return text.Count(c => char.IsWhiteSpace(c));
        }
        private string GetfirstWord(string text)
        {
            //usando split obtengo la primera palabra
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length > 0 ? words[0] : string.Empty;
        }

        private string GetlastWord(string text)
        {
            //usando split obtengo la ultima palabra
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length > 0 ? words[words.Length - 1] : string.Empty;
        
        }

    
    }
}

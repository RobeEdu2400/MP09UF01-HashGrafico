using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP09UF01_HashGrafico
{
    public partial class Form1 : Form
    {
        String texto;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nombreArchivo = textBox1.Text;
            try
            {
                texto = File.ReadAllText(@nombreArchivo);

                String hash;
                hash = calcularHash(texto);

                try
                {
                    String nombre = textBox2.Text;

                    File.WriteAllText(nombre, hash);
                }
                catch
                {
                    MessageBox.Show("Introduce un nombre para el hash.");                   
                }
                
            }
            catch
            {
                MessageBox.Show("El archivo de texto no existe.");
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                texto = File.ReadAllText(textBox1.Text);

                String hash;
                String hashGuardado;
                hash = calcularHash(texto);

                try
                {
                    hashGuardado = File.ReadAllText(textBox2.Text);

                    if (hash == hashGuardado)

                    {
                        MessageBox.Show("Ha sido comprobado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No ha sido comprobado correctamente");
                    }
                }
                catch
                {
                    MessageBox.Show("El nombre del hash no existe.");
                }
            }
            catch
            {
                MessageBox.Show("El archivo de texto no existe.");
            }          
            
        }

        private static string calcularHash(string texto)
        {
            // Convertim l'string a un array de bytes
            byte[] bytesIn = UTF8Encoding.UTF8.GetBytes(texto);
            // Instanciar classe per fer hash
            SHA512Managed SHA512 = new SHA512Managed();
            // Calcular hash
            byte[] hashResult = SHA512.ComputeHash(bytesIn);

            // Si volem mostrar el hash per pantalla o guardar-lo en un arxiu de text
            // cal convertir-lo a un string

            String hash = BitConverter.ToString(hashResult, 0);


            // Eliminem la classe instanciada
            SHA512.Dispose();
            return hash;
        }        
    }
}

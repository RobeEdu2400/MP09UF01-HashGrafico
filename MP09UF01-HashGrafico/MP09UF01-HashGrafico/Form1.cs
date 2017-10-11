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
        //Boton para crear el hash
        private void button1_Click(object sender, EventArgs e)
        {
            //Guardamos el nombre del archivo escrito en el textbox en la variable
            String nombreArchivo = textBox1.Text;
            //try para comprobar que el archivo de texto existe
            try
            {
                //Leemos el contenido del archivo
                texto = File.ReadAllText(@nombreArchivo);

                String hash;
                //Llamamos al metodo calcularHash para obtener el hash del contenido del archivo de texto
                hash = calcularHash(texto);
                //try para comprobar que guarda el archivo de texto con un nombre
                try
                {
                    //Guardamos el nombre del hash
                    String nombre = textBox2.Text;
                    //Creamos un archivo con el nombre preguntando anteriormente y en su contenido guardamos el hash calculado anteriormente
                    File.WriteAllText(nombre, hash);
                    MessageBox.Show("Hash creado y guardado correctamente");
                }
                catch
                {
                    //Mensaje para que introduzca un nombre para el hash
                    MessageBox.Show("Introduce un nombre para el hash.");                   
                }
                
            }
            catch
            {
                //Para comprobar que el archivo de texto exista dentro de la carpeta bin
                MessageBox.Show("El archivo de texto no existe.");
            }
            
        }
        //Para comprobar el hash creado anteriormente 
        private void button2_Click(object sender, EventArgs e)
        {
            //try para comprobar que el archivo de texto existe
            try
            {
                //Leemos el contenido del archivo y lo guardamos en la variable texto
                texto = File.ReadAllText(textBox1.Text);

                String hash;
                String hashGuardado;
                //Metodo para calcular el hash del archivo de texto
                hash = calcularHash(texto);

                try
                {
                    //Leemos el hash creado anteriormente y lo guardamos en la variable hashGuardado
                    hashGuardado = File.ReadAllText(textBox2.Text);
                    //Comparamos los 2 hash para comprobar que sea correcto
                    if (hash == hashGuardado)

                    {
                        MessageBox.Show("Los hash coinciden.");
                    }
                    else
                    {
                        MessageBox.Show("No ha sido comprobado.");
                    }
                }
                catch
                {
                    //Para enseñar por pantalla que el hash que ha escrito no existe
                    MessageBox.Show("El nombre del hash no existe.");
                }
            }
            catch
            {
                //Para enseñar por pantalla que el archivo que ha ecrito no existe
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
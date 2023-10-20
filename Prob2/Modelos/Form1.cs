using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prob2.Algoritmos;
using System.Diagnostics;

namespace Prob2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Paso 0: Condicíon de vacío
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") )
            {
                MessageBox.Show("Hay casillas vacias");
                return;
            }

            int d = Convert.ToInt32(textBox1.Text);
            int pasos = Convert.ToInt32(textBox2.Text);
            int n = Convert.ToInt32(textBox3.Text);

            Console.WriteLine(d);

            ///
            if (d != 1 && d !=2)
            {
                MessageBox.Show("Solo puedes seleccionar 1 o 2 dimensiones");
                return;
            }
            ///

            if (pasos != 100 && pasos != 1000 && pasos != 10000)
            {
                MessageBox.Show("Solo puedes seleccionar 100, 1000 o 10000 pasos");
                return;
            }
            if (n != 100 && n != 1000 && n != 10000)
            {
                MessageBox.Show("Solo puedes seleccionar 100, 1000 o 10000 repeticiones");
                return;
            }
            Generar algoritmo = new Generar();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); 

            List<List<double>> MatrizValores = algoritmo.
                Movimiento_Browniano(d,pasos,n);

            stopwatch.Stop();
            long tiempo = stopwatch.ElapsedMilliseconds;
            visualizar(MatrizValores, tiempo);

            // Detén el cronómetro
            

            
        }

        public void visualizar(List<List<double>> matriz, double tiempo)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            double suma = 0;
            int n = matriz.Count;
            int columnas = matriz[0].Count;

            dataGridView1.Columns.Clear(); // Borra todas las columnas existentes

            for (int i = 0; i < columnas; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
            }

            dataGridView1.Columns[0].HeaderText = "Distancia Final";
            dataGridView1.Columns[1].HeaderText = "Distancia Maxima";

           


            dataGridView1.Rows.Clear();
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < columnas; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matriz[i][j].ToString();
                }
                suma = suma + matriz[i][1];
            }
            

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString(); // Mostrar números en las filas
            }

            stopwatch.Stop();
            long tiempo2 = stopwatch.ElapsedMilliseconds;

            double promedio = suma / n;
            double tiempos = tiempo + tiempo2;
            labelDistancia.Text = "Promedio Distancia Maxima: " + promedio.ToString();
            labelTiempo.Text = "Tiempo de ejecución en milisegundos: " + tiempos.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


    }
}

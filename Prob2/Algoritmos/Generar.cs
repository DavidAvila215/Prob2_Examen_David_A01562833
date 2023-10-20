using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2.Algoritmos
{
    internal class Generar
    {
        public List<List<double>> Movimiento_Browniano(int d, int pasos, int n)
        {
            List<List<double>> tabla = new List<List<double>>();
            if (d == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    int pos_x = 0;
                    double max = 0;
                    double Distancia = 0;
                    List<double> fila = new List<double>();
                    for (int j = 0; j < pasos; j++)
                    {
                        pos_x = pos_x + Aumentar_disminuir();
                        Distancia = Math.Abs(pos_x);
                        if (Distancia > max)
                        {
                            max = Distancia;
                        }
                    }
                    fila.Add(Distancia);
                    fila.Add(max);
                    tabla.Add(fila);
                }
               
            }

            else if (d == 2)
            {
                
                for (int i = 0; i < n; i++)
                {
                    int pos_x = 0;
                    int pos_y = 0;
                    double max = 0;
                    double Distancia = 0;
                    List<double> fila = new List<double>();
       
                    for (int j = 0; j < pasos; j++)
                    {
                        pos_x = pos_x + Aumentar_disminuir();
                        pos_y = pos_y + Aumentar_disminuir();
                        int suma_cuadrados = (pos_x * pos_x) + (pos_y * pos_y);
                        Distancia = Math.Sqrt(suma_cuadrados);
                        if (Distancia > max)
                        {
                            max = Distancia;
                        }
                    }
                    fila.Add(Distancia);
                    fila.Add(max);
                    tabla.Add(fila);
                }
            }

            return tabla;
        }

        public int Aumentar_disminuir()
        {
            Random random = new Random();
            int seleccion = random.Next(2);
            int Valor = 0;
            if (seleccion == 0)
            {
                Valor = 1;
            }
            else
            {
                Valor = -1;
            }
            return Valor;
        }
    }
}

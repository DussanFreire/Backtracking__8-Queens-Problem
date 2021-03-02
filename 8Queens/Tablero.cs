using System;
using System.Collections.Generic;
using System.Text;

namespace _8Queens
{
    class Tablero
    {
        string[,] tablero;
        int reinasColocadas;
        List<string[,]> tableroDeEstados;
        List<string[,]> tableroDeSoluciones;
        int[] posReinas = { -1, -1, -1, -1, -1, -1, -1, -1 };
        public Tablero() {
            inicializarProceso();
        }
        public void menu() {
            int seleccion;
            do
            {
                Console.WriteLine("****************MENU***************");
                Console.WriteLine("1. Colocar Reinas");
                Console.WriteLine("2. Mostrar Todos los tableros de soluciones");
                Console.WriteLine("3. Mostrar Todos los tableros de estados");
                Console.WriteLine("4. Mostrar Resumen de resultados");
                Console.WriteLine("0. Salir");
                Console.WriteLine("***********************************");
                seleccion = RecibirNumeroEnteroDeConsolaEnElRango(0, 4, "Seleccion:");

                Console.Clear();
                switch (seleccion)
                {
                    case 1:
                        ColocarReinas();
                        break;
                    case 2:
                        MostrarTodosLosEstados();
                        break;
                    case 3:
                        MostrarLasSoluciones();
                        break;
                    case 4:
                        MostrarResultados();
                        break;
                }

            } while (seleccion != 0);
            
        }
        private void inicializarProceso() {
            tableroDeEstados = new List<string[,]>();
            tableroDeSoluciones = new List<string[,]>();
            tablero = new string[8, 8];
            reinasColocadas = 0;
            inicializarTablero();
            tableroDeEstados.Add((string[,])tablero.Clone());
        }
        void inicializarTablero() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++)
                {
                    tablero[i,j] = "-";
                }
            }
        }
        private void  ColocarReinas() {
            inicializarProceso();
            int fila=0, columna=0;
            //string mensage;
            do { 
                if (columna < 8 && PosicionValida(fila, columna))
                {
                    // Si se llega aqui significa que se encontro un estado nuevo
                    tablero[fila, columna] = "r";
                    posReinas[reinasColocadas++] = columna;
                    fila++;
                    columna = 0;
                    tableroDeEstados.Add((string[,])tablero.Clone());
                    // MostrarTablero(tablero,$"ESTADO NRO {cantidadDeEstados}");
                }
                else if (columna >= 7 || reinasColocadas == 8)
                {
                   // mensage = "SE QUITO UNA REINA";
                    if (reinasColocadas == 8) {
                        //Si se llega a colocal la octava reina signifa que se llego a una solucion
                        tableroDeSoluciones.Add((string[,])tablero.Clone());
                        //mensage = $"SOLUCION {tableroDeSoluciones.Count}";
                        //MostrarTablero(tablero,mensage);
                    }
                    fila--;
                    if (reinasColocadas != 0) columna = posReinas[--reinasColocadas] + 1;
                    else break;
                    tablero[reinasColocadas, posReinas[reinasColocadas]] = "-";
                    //MostrarTablero(tablero,mensage);
                }
                else {
                    columna++;
                }
            }while (columna<= 8 || fila != 0);
        }
        private void MostrarResultados() {
            if (tableroDeEstados.Count>1)
                Console.WriteLine($"RESULTADO:\nCantidad de estados:{tableroDeEstados.Count}\nSoluciones encontradas: {tableroDeSoluciones.Count}" );
            else
                Console.WriteLine("No se coloco ni una reina aun");
        }
        private void MostrarTablero(string [,] tablero,string mensaje)
        {
            Console.WriteLine($"\t{mensaje}:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"\t{tablero[i, j]}  "); 
                }
                Console.WriteLine();

            }
        }
        private void MostrarTodosLosEstados()
        {
            if (tableroDeEstados.Count > 1) {
                int i = 0;
                foreach(string[,] tablero in tableroDeEstados)
                {
                    MostrarTablero(tablero,$"Estado {++i}");
                }
            }
            else
                Console.WriteLine("Error, no se coloco ni una reina aun");
        }
        private void MostrarLasSoluciones()
        {
            if (tableroDeSoluciones.Count > 0)
            {
                int i = 0;
                foreach (string[,] tablero in tableroDeSoluciones)
                {
                    MostrarTablero(tablero, $"Solucion {++i}");
                }
            }
            else
                Console.WriteLine("Error, no se coloco ni una reina aun");
        }
        private bool PosicionValida(int fila, int columna) {
            return ColumnaValida(columna) && DiagonalValido(fila, columna) &&  FilaValida(fila);
        }
        private bool ColumnaValida(int columna) {
            for (int j = 0; j < 8; j++)
            {
                if(tablero[j, columna] == "r")
                {
                    return false;
                }
            }
            return true;
        }
        private bool FilaValida(int fila)
        {
            for (int j = 0; j < 8; j++)
            {
                if (tablero[fila, j] == "r")
                {
                    return false;
                }
            }
            return true;
        }
        private bool DiagonalValido(int fila, int columna) {
            return DiagonalValidoSupIzq(fila, columna) && DiagonalValidoSupDer(fila, columna);
        }
        private bool DiagonalValidoSupIzq(int fila, int columna) {
            int[] pos = HayarInicioDeLaDiagonalSupIzq(fila, columna);
            int f = pos[0];
            int c = pos[1];
            while (f != 8 && c != 8)
            {
                if (tablero[f, c] == "r")
                {
                    return false;
                }
                f++;
                c++;
            }
            return true;
        }
        private bool DiagonalValidoSupDer(int fila, int columna)
        {
            int[] pos = HayarInicioDeLaDiagonalSupDer(fila, columna);
            int f = pos[0];
            int c = pos[1];
            while (f != 8 && c != 0)
            {
                if (tablero[f, c] == "r")
                {
                    return false;
                }
                f++;
                c--;
            }
            return true;
        }
        private int[] HayarInicioDeLaDiagonalSupIzq(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                x--;
                y--;
            }
            int[] pos = new int[] { x, y };
            return pos;
        }
        private int[] HayarInicioDeLaDiagonalSupDer(int x, int y)
        {
            while (x != 0 && y != 7)
            {
                x--;
                y++;
            }
            int[] pos = new int[] { x, y };
            return pos;
        }
        private int RecibirNumeroEnteroDeConsolaEnElRango(int desde, int hasta, string solicitud)
        {
            int numero;
            do
            {
                Console.Write(solicitud);

            } while (!int.TryParse(Console.ReadLine(), out numero) || numero < desde || numero > hasta);
            return numero;
        }

    }
}

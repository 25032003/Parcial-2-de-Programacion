using System;

class Program
{
    static int[,] Tablero;
    static int Vidas = 5;


    static void Paso1_CrearTablero(int tamaño)
    {
        Tablero = new int[tamaño, tamaño];
        for (int f = 0; f < Tablero.GetLength(0); f++)
        {
            for (int c = 0; c < Tablero.GetLength(1); c++)
            {
                Tablero[f, c] = 0;
            }
        }
    }

    static void Paso2_ColocarBarcos()
    {
        Random rnd = new Random();
        int cantidadBarcos = 0;
        switch (Tablero.GetLength(0))
        {
            case 3:
                cantidadBarcos = 3; //Son los barcos de cada nivel
                break;
            case 5:
                cantidadBarcos = 4;
                break;
            case 7:
                cantidadBarcos = 5;
                break;
            default:
                cantidadBarcos = 3; //Barcos del juego por defecto
                break;
        }

        for (int i = 0; i < cantidadBarcos; i++)
        {
            int fila = rnd.Next(0, Tablero.GetLength(0));
            int columna = rnd.Next(0, Tablero.GetLength(1));
            Tablero[fila, columna] = 1;
        }
    }


    static void Paso3_ImprimirTablero()
    {
        Console.Clear();
        Console.WriteLine("Vidas: " + Vidas); //Comentario de las vidas
        String caracter_imprimir = "";
        for (int f = 0; f < Tablero.GetLength(0); f++)
        {
            for (int c = 0; c < Tablero.GetLength(1); c++)
            {
                switch (Tablero[f, c])
                {
                    case 0:
                        caracter_imprimir = "~";
                        break;
                    case 1:
                        caracter_imprimir = "~"; //Como aparece el barco
                        break;
                    case -1:
                        caracter_imprimir = "*";
                        break;
                    case -2:
                        caracter_imprimir = "X"; //Donde fue que elijio
                        break;
                    default:
                        caracter_imprimir = "~";
                        break;
                }
                Console.Write(caracter_imprimir + " ");
            }
            Console.WriteLine();
        }
    }

    static void Paso5_SonidoDerrota()
    {
        Console.WriteLine("¡Has perdido una vida!");
        for (int i = 0; i < 2; i++) // Reproduce el sonido de derrota 2 veces
        {
            Console.Beep(350, 100); // Frecuencia: 350 Hz, Duración: 100 ms
            System.Threading.Thread.Sleep(100); // Pausa de 100 ms entre cada sonido
        }
    }
    static void MostrarMensajeBarcoEncontrado() //Funcion del mensaje del barco encontrado
    {
        Console.WriteLine("¡Encontraste un barco!");
    }


    static void Paso4_IngresoCoordenadas()

    {

        int fila, columna = 0;

        Console.WriteLine("Solo se permite numeros Positivos"); //Todo esto es la interfaz del juego (El switch de opciones)
        Console.Write("\nIngrese la Fila: ");
        fila = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingresa la Columna: ");
        columna = Convert.ToInt32(Console.ReadLine());

        if (Tablero[fila, columna] == 1) //Verifica si la celda en la posicion de fila y columna en el tablero tiene el valor de 1
        {
            Console.Beep();
            Tablero[fila, columna] = -1;
            Console.WriteLine("\n¡Le has dado a un barco!");
            Console.WriteLine("Le diste");
            System.Threading.Thread.Sleep(1000);
        }
        else
        {
            Tablero[fila, columna] = -2; //El el primer valor de la celda que se cambia a -2 lo que indica que ha golpeado el barco en esa posicion
            Vidas--;
            if (Vidas > 0) //Si el jugador tiene todavia vidas, si es asi se emite un sonido de beep
            {
                Paso5_SonidoDerrota(); // Llama a la función para reproducir el sonido de derrota
            }
            Console.WriteLine("\nHas fallado");
        }
        MostrarMensajeBarcoEncontrado();
        Paso3_ImprimirTablero();
    }
    static void Main(string[] args)
    {
        Console.WriteLine("-Este juego es Modo Individual-");

        Console.WriteLine("\nSeleccione el nivel:");
        Console.WriteLine("1) Principiante 5 x 5");
        Console.WriteLine("2) Clase Media 8 x 8");
        Console.WriteLine("3)Pro-Player 15 x 15");

        Console.WriteLine("\n4)Instrucciones del juego");
        Console.WriteLine("5) Reglas del Juego");


        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion) //es un switch de 5 opciones las primeras 3 son de los niveles
        {
            case 1:
                Paso1_CrearTablero(5); //De cuanto va hacer la matriz filas y columnas
                break;
            case 2:
                Paso1_CrearTablero(8);
                break;
            case 3:
                Paso1_CrearTablero(15);
                break;
            case 4:
                Console.WriteLine("\nInstrucciones:");
                Console.WriteLine("El objetivo del juego es encontrar los barcos ocultos en el tablero.");
                Console.WriteLine("Cada vez que ingresas una coordenada, si hay un barco en esa ubicación, pierdes una vida.");
                Console.WriteLine("Si pierdes todas las vidas, pierdes el juego.");
                Console.WriteLine("Puedes seleccionar el nivel de dificultad del juego al inicio.");
                Console.WriteLine("¡Que te diviertas!");
                Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
                Console.ReadKey();
                Main(args); // Llamada recursiva para volver al menú principal
                break;
            case 5:
                Console.WriteLine("\nReglas del juego:");
                Console.WriteLine("El objetivo del juego es encontrar los barcos ocultos en el tablero.");
                Console.WriteLine("Cada vez que ingreses una coordenada, si hay un barco en esa ubicación, perderás una vida.");
                Console.WriteLine("Si pierdes todas las vidas, pierdes el juego.");
                Console.WriteLine("Puedes seleccionar el nivel de dificultad del juego al inicio.");
                Console.WriteLine("Presiona Enter para continuar...");
                Console.ReadLine();
                break;




            default:
                Console.WriteLine("Si escribes una Opción inválida por defecto se seleccionará el nivel Principiante...");
                Paso1_CrearTablero(5);
                break;
        }

        Paso2_ColocarBarcos();
        Paso3_ImprimirTablero();
        while (Vidas > 0)
        {
            Paso4_IngresoCoordenadas();
        }

        Console.WriteLine("Game Over :(");
    }
}
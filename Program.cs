using System;
using System.Net;

internal class Program : ConsoleApp
{
    static string address = "";
    static int hosts = 0;
    static bool explain_proccess = false;

    static void Main(string[] args)
    {
        if(args.Length > 0)
            parse_args(args);

        get_addr();
        get_hosts();
        calculate();
    }

    static void parse_args(string[] args)
    {
        if (args[0] == "-h" || args[0] == "--help")
        {
            PrintLn($"Cómo usar este programa:");
            PrintLn($"  primer paso: introduce la dirección inicial del rango");
            PrintLn($"  segundo paso: introduce la cantidad de hosts que quieres añadir");
            PrintLn($"Argumentos:");
            PrintLn($"  [-h / --help]: enseña este diálogo");
            PrintLn($"  [-sp /--show-process]: enseña todo el proceso de cálculo del rango de color celeste (para los que se fían menos)");
        }
        else if (args[0] == "-sp" || args[0] == "--show-process")
        {
            explain_proccess = true;
            printp($"Los procesos de cálculos se mostrarán de este color");
        }
    }

    static void printp(object message)
    {
        if (!explain_proccess)
            return;

        PrintLn(message, ConsoleColor.Cyan);
    }

    static void get_addr()
    {
        // obtener dirección principal
        PrintLn($"¿Cuál es la dirección principal?");
        address = ReadLn() ?? "";

        if (string.IsNullOrEmpty(address))
            PrintStp($"Error: ¡no has introducido ninguna dirección!");

        if (!IPAddress.TryParse(address, out _))
            PrintStp($"Error: ¡IP no válida!");
    }

    static void get_hosts()
    {
        // obtener los hosts
        PrintLn($"¿Cuántos hosts quieres añadir?");
        var hosts_count = ReadLn();

        if (string.IsNullOrEmpty(hosts_count))
            PrintStp($"Error: ¡no has introducido ningún número de hosts!");

        if (!int.TryParse(hosts_count, out hosts))
            PrintStp($"Error: ¡Número no válido!");
    } 

    static void calculate()
    {
        // calcular todo

        int o1 = int.Parse(address.Split('.')[0]);
        if (o1 == 0)
        {
            printp($"El primer octeto empieza en \"0\", para hacer los cálculos más facil, vamos a empezar por \"1\"");
            o1 += 1;
        }

        int o2 = int.Parse(address.Split('.')[1]);
        int o3 = int.Parse(address.Split('.')[2]);
        int o4 = int.Parse(address.Split('.')[3]);

        string original = $"{o1}.{o2}.{o3}.{o4}";
        printp($"Partimos de la IP original: {original}");

        printp($"Cada vez que lleguemos a 254 en un octeto le sumaremos 1 a su octeto anterior.");
        printp($"Ten en cuenta que este programa NO TIENE EN CUENTA LA CLASE DE LA IP");
        for (int i = 0; i < hosts; i++)
        {
            if ((o4 + 1) > 254)
            {
                printp($"Se ha llegado a 254 en el octeto 4 ({original}-{o1}.{o2}.{o3}.{o4})");
                o4 = 1;

                if ((o3 + 1) > 254)
                {
                    printp($"Se ha llegado a 254 en el octeto 3 ({original}-{o1}.{o2}.{o3}.{o4})");
                    o3 = 1;

                    if ((o2 + 1) > 254)
                    {
                        printp($"Se ha llegado a 254 en el octeto 2 ({original}-{o1}.{o2}.{o3}.{o4})");
                        o2 = 1;

                        if ((o1 + 1) > 254)
                        {
                            PrintStp($"No se puede añadir tantas direcciones ({original}-{o1}.{o2}.{o3}.{o4})");
                        }

                        o3++;
                    }
                }

                o3++;
            }
            else
            {
                o4++;
            }
        }

        PrintLn($"Resultado: {original}-{o1}.{o2}.{o3}.{o4}", ConsoleColor.Green);
        Pause();
    }
}

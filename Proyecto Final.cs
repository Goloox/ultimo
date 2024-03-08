using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inteto
{
    internal class Program
    {




        class Estudiante
        {
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public double Promedio { get; set; }
            public string Condicion { get; set; }
        }

        class Programa
        {
            static Estudiante[] estudiantes = new Estudiante[10];

            static void Main(string[] args)
            {
                int opcion;

                do
                {
                    Console.WriteLine("Menú principal del sistema de estudiantes");
                    Console.WriteLine("");
                    Console.WriteLine("1. Inicializar vectores");
                    Console.WriteLine("2. Incluir estudiantes");
                    Console.WriteLine("3. Consultar estudiantes");
                    Console.WriteLine("4. Modificar estudiantes");
                    Console.WriteLine("5. Eliminar estudiantes");
                    Console.WriteLine("6. Submenú de reportes");
                    Console.WriteLine("7. Aumentar numero de estudaintes");
                    Console.WriteLine("8. Salir");

                    try
                    {
                        Console.WriteLine("");
                        Console.Write("Seleccione una opción del 1-7 para continuar o 7 para salir del programa: ");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        opcion = int.Parse(Console.ReadLine());

                        switch (opcion)
                        {
                            case 1:
                                InicializarVectores();
                                break;
                            case 2:
                                IncluirEstudiantes();
                                break;
                            case 3:
                                ConsultarEstudiantes();
                                break;
                            case 4:
                                ModificarEstudiantes();
                                break;
                            case 5:
                                EliminarEstudiantes();
                                break;
                            case 6:
                                SubmenuReportes();
                                break;
                            case 7:
                                AumentarNumeroEsrudiantes();
                                break;
                            case 8:
                                Console.WriteLine("");
                                Console.WriteLine("Saliendo del programa...");
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("");
                                Console.WriteLine("Error: Por favor, ingrese un número válido entre 1 y 8.");
                                Console.WriteLine("");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo, digitando un valor numérico.");
                        Console.WriteLine("");
                        opcion = 0;
                    }

                } while (opcion != 8);
            }

            static void InicializarVectores()
            {
                estudiantes = new Estudiante[10];
                Console.WriteLine("Los vectores han sido inicializados correctamente.");
            }

            static void IncluirEstudiantes()
            {
                for (int i = 0; i < estudiantes.Length; i++)
                {
                    if (estudiantes[i] == null)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese los datos del estudiante:");
                        Console.WriteLine("");

                        try
                        {
                            string cedulaInput;
                            do
                            {
                                Console.Write("Cédula: ");
                                cedulaInput = Console.ReadLine();
                                if (!int.TryParse(cedulaInput, out int _))
                                {
                                    Console.WriteLine("Error: La cédula debe ser un número entero.");
                                }
                            } while (!int.TryParse(cedulaInput, out int _));

                            string nombreInput;
                            do
                            {
                                Console.WriteLine("ESCRIBIR NOMBRE EN MAYUSCULAS Y APELLIDO EN MINUSCULAS");
                                Console.Write("Nombre: ");
                                nombreInput = Console.ReadLine();
                                if (nombreInput.Length < 2 || !nombreInput.All(c => char.IsLetter(c)))
                                {
                                    Console.WriteLine("Error: El nombre debe tener más de una letra y contener solo letras.");
                                }
                            } while (nombreInput.Length < 2 || !nombreInput.All(c => char.IsLetter(c)));

                            string promedioInput;
                            do
                            {
                                Console.Write("Promedio: ");
                                promedioInput = Console.ReadLine();
                                if (!double.TryParse(promedioInput, out double _))
                                {
                                    Console.WriteLine("Error: El promedio debe ser un número.");
                                }
                            } while (!double.TryParse(promedioInput, out double _));

                            double promedio = double.Parse(promedioInput);

                            string condicion;
                            if (promedio >= 70)
                                condicion = "Aprobado";
                            else if (promedio >= 60)
                                condicion = "Reprobado";
                            else
                                condicion = "Aplazado";

                            estudiantes[i] = new Estudiante { Cedula = cedulaInput, Nombre = nombreInput, Promedio = promedio, Condicion = condicion };

                            Console.WriteLine("");
                            Console.WriteLine($"El estudiante {estudiantes[i].Nombre} fue incluido correctamente.");
                            Console.WriteLine("");
                            return;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Error: Por favor, ingrese un formato válido para la cédula, nombre y promedio.");
                            Console.WriteLine("");
                            return;
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("No hay espacio disponible para incluir más estudiantes.");
                Console.WriteLine("");
            }

            static void ConsultarEstudiantes()
            {
                Console.WriteLine("");
                Console.Write("Ingrese el número de cédula del estudiante a consultar: ");
                Console.WriteLine("");
                string cedula = Console.ReadLine();

                foreach (var estudiante in estudiantes)
                {
                    if (estudiante != null && estudiante.Cedula == cedula)
                    {
                        Console.WriteLine("===================================================================================================================================================");
                        Console.WriteLine($"Cédula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}, Condición: {estudiante.Condicion}");
                        Console.WriteLine("===================================================================================================================================================");
                        Console.WriteLine("                 <PULSE CUALQUIER TECLA PARA ABANDONAR>");
                        return;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine($"El estudiante con el número de cédula {cedula} no fue encontrado.");
                Console.WriteLine("");
            }

            static void ModificarEstudiantes()
            {
                Console.WriteLine("");
                Console.Write("Ingrese el número de cédula del estudiante a modificar: ");
                Console.WriteLine("");
                string cedula = Console.ReadLine();

                for (int i = 0; i < estudiantes.Length; i++)
                {
                    if (estudiantes[i] != null && estudiantes[i].Cedula == cedula)
                    {
                        Console.WriteLine("Ingrese los nuevos datos del estudiante:");
                        Console.Write("Nombre: ");
                        estudiantes[i].Nombre = Console.ReadLine();

                        Console.Write("Promedio: ");
                        estudiantes[i].Promedio = double.Parse(Console.ReadLine());

                        if (estudiantes[i].Promedio >= 70)
                            estudiantes[i].Condicion = "Aprobado";
                        else if (estudiantes[i].Promedio >= 60)
                            estudiantes[i].Condicion = "Reprobado";
                        else if (estudiantes[i].Promedio >= 0)
                            estudiantes[i].Condicion = "Aplazado";

                        Console.WriteLine($"El estudiante con el número de cédula {cedula} fue modificado correctamente.");
                        return;
                    }
                }

                Console.WriteLine($"El estudiante con el número de cédula {cedula} no fue encontrado.");
            }

            static void EliminarEstudiantes()
            {
                Console.WriteLine("");
                Console.Write("Ingrese el número de cédula del estudiante a eliminar: ");
                Console.WriteLine("");
                string cedula = Console.ReadLine();

                for (int i = 0; i < estudiantes.Length; i++)
                {
                    if (estudiantes[i] != null && estudiantes[i].Cedula == cedula)
                    {
                        Console.WriteLine($"El estudiante {estudiantes[i].Nombre} fue eliminado correctamente.");
                        estudiantes[i] = null;
                        return;
                    }
                }

                Console.WriteLine($"El estudiante con el número de cédula {cedula} no fue encontrado.");
            }

            static void SubmenuReportes()
            {
                int opcion;
                do
                {
                    Console.WriteLine("Submenú de reportes");
                    Console.WriteLine("");
                    Console.WriteLine("1. Reporte Estudiantes por Condición");
                    Console.WriteLine("2. Reporte Todos los datos");
                    Console.WriteLine("3. Reporte Todos los Estudiantes");
                    Console.WriteLine("4. Regresar al menú principal");
                    Console.WriteLine("");
                    Console.Write("Seleccione una opción del 1-2 para continuar o 3 para regresar al menú principal: ");
                    Console.WriteLine("");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            ReporteEstudiantesPorCondicion();
                            break;
                        case 2:
                            ReporteTodosLosDatos();
                            break;
                        case 3:
                            ImprimirTodosLosEstudiantes();
                            break;
                        case 4:
                            Console.WriteLine("");
                            Console.WriteLine("Usted está regresando al menú principal...");
                            Console.WriteLine("");
                            break;
                        default:
                            Console.WriteLine("");
                            Console.WriteLine("Opción inválida. Inténtelo de nuevo digitando un número de 1-3 para continuar.");
                            Console.WriteLine("");
                            break;
                    }
                } while (opcion != 4);
            }

            static void ReporteEstudiantesPorCondicion()
            {
                Console.WriteLine("Seleccione la condición para el reporte del estudiante: ");
                Console.WriteLine("");
                Console.WriteLine("1. Aprobado");
                Console.WriteLine("2. Reprobado");
                Console.WriteLine("3. Aplazado");
                Console.WriteLine("");
                Console.Write("Seleccione una opción: ");
                Console.WriteLine("");
                int opcion = int.Parse(Console.ReadLine());

                string condicion;

                switch (opcion)
                {
                    case 1:
                        condicion = "Aprobado";
                        break;
                    case 2:
                        condicion = "Reprobado";
                        break;
                    case 3:
                        condicion = "Aplazado";
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo digitando un número de 1-3 para continuar.");
                        Console.WriteLine("");
                        return;
                }

                Console.WriteLine($"Reporte de estudiantes con la condición: '{condicion}':");
                foreach (var estudiante in estudiantes)
                {
                    if (estudiante != null && estudiante.Condicion == condicion)
                    {
                        Console.WriteLine("====================================================================================================");
                        Console.WriteLine($"Cedula:   {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}");
                        Console.WriteLine("====================================================================================================");
                        Console.WriteLine("                 < PULSE CUALQUIER TECLA PARA ABANDONAR >");
                    }
                }
            }
            static void ImprimirTodosLosEstudiantes()
            {
                Console.WriteLine("Lista de todos los estudiantes:");
                Console.WriteLine("");

                estudiantes.Where(estudiante => estudiante != null).ToList().ForEach(estudiante =>
                {
                         Console.WriteLine($"======================================================================================================" +
                                           $"Cédula: {estudiante.Cedula}, Nombre: {estudiante.Nombre} , Promedio{estudiante.Promedio} " +
                                           $"======================================================================================================");
                });

            }
            static void ReporteTodosLosDatos()
            {
                int cantidadEstudiantes = 0;
                double promedioMayor = double.MinValue;
                double promedioMenor = double.MaxValue;
                Estudiante estudianteMayor = null;
                Estudiante estudianteMenor = null;

                foreach (var estudiante in estudiantes)
                {
                    if (estudiante != null)
                    {
                        cantidadEstudiantes++;
                        if (estudiante.Promedio > promedioMayor)
                        {
                            promedioMayor = estudiante.Promedio;
                            estudianteMayor = estudiante;
                        }
                        if (estudiante.Promedio < promedioMenor)
                        {
                            promedioMenor = estudiante.Promedio;
                            estudianteMenor = estudiante;
                        }
                    }
                }

                Console.WriteLine("Reporte de todos los estudiantes:");
                Console.WriteLine($"Cantidad de estudiantes: {cantidadEstudiantes}");

                if (estudianteMayor != null)
                    Console.WriteLine($"Estudiante(s) con el promedio mayor: Cédula: {estudianteMayor.Cedula}, Nombre: {estudianteMayor.Nombre}, Promedio: {estudianteMayor.Promedio}");

                if (estudianteMenor != null)
                    Console.WriteLine($"Estudiante(s) con el promedio menor: Cédula: {estudianteMenor.Cedula}, Nombre: {estudianteMenor.Nombre}, Promedio: {estudianteMenor.Promedio}");
            }

            static void AumentarNumeroEsrudiantes()
            {


                Estudiante[] estudiantes = new Estudiante[0]; // Asegúrate de inicializar el arreglo de estudiantes

                {







                    Console.Write("Ingrese la cantidad de estudiantes a agregar: ");
                    int cantidadNueva = int.Parse(Console.ReadLine());

                    // Crear un nuevo arreglo con la longitud actual + la cantidad nueva
                    Estudiante[] nuevosEstudiantes = new Estudiante[estudiantes.Length + cantidadNueva];

                    // Copiar los estudiantes existentes al nuevo arreglo
                    estudiantes.CopyTo(nuevosEstudiantes, 0);

                    // Asignar el nuevo arreglo a la variable estudiantes
                    estudiantes = nuevosEstudiantes;

                    Console.WriteLine($"Se han agregado {cantidadNueva} estudiantes. Ahora hay un total de {estudiantes.Length} estudiantes.");





                }
            }





        }





    }
}
        
  

         
    
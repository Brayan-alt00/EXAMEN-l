using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_l
{
    //Este programa gestiona un sistema de registro de asistencia semanal para estudiantes en diferentes materias y días.
    //En este se pueden registrar estudiantes, eliminar registros y consultar asistencia por materia y día.
    
    class Program
        {
            // Constante para el máximo de estudiantes permitidos por clase
            const int MAX_ESTUDIANTES = 3;

            // Diccionario anidado: Materia -> Día -> Lista de estudiantes
            static Dictionary<string, Dictionary<string, List<string>>> asistencia;

            // Listas predefinidas de materias y días de la semana
            static List<string> materias;
            static List<string> dias;

            static void Main()
            {

                bool salir = false;
                while (!salir)
                {
                    Console.Clear();
                    Console.WriteLine("=== Sistema de Registro de Asistencia Semanal ===");
                    Console.WriteLine("1. Registrar estudiante");
                    Console.WriteLine("2. Eliminar estudiante");
                    Console.WriteLine("3. Consultar asistencia");
                    Console.WriteLine("4. Salir");
                    Console.Write("Seleccione una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            RegistrarEstudiante();
                            break;
                        case "2":
                            EliminarEstudiante();
                            break;
                        case "3":
                            ConsultarAsistencia();
                            break;
                        case "4":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente nuevamente.");
                            break;
                    }

                    if (!salir)
                    {
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }

            // Inicializa el diccionario con materias y días


            static void RegistrarEstudiante()
            {
                Console.Write("Nombre del estudiante: ");
                string estudiante = Console.ReadLine()?.Trim();

                string materia = Seleccionar("materia", materias);
                string dia = Seleccionar("día", dias);

                var lista = asistencia[materia][dia];

                if (lista.Contains(estudiante))
                {
                    Console.WriteLine("⚠️ El estudiante ya está registrado en esta clase.");
                    return;
                }

                if (lista.Count >= MAX_ESTUDIANTES)
                {
                    Console.WriteLine("❌ Clase llena. No se pueden registrar más estudiantes.");
                    return;
                }

                lista.Add(estudiante);
                Console.WriteLine("✅ Estudiante registrado con éxito.");
            }

            // Eliminar un estudiante
            static void EliminarEstudiante()
            {
                Console.Write("Nombre del estudiante a eliminar: ");
                string estudiante = Console.ReadLine()?.Trim();

                string materia = Seleccionar("materia", materias);
                string dia = Seleccionar("día", dias);

                var lista = asistencia[materia][dia];

                if (lista.Remove(estudiante))
                {
                    Console.WriteLine("✅ Estudiante eliminado.");
                }
                else
                {
                    Console.WriteLine("❌ El estudiante no se encontró en esta clase.");
                }
            }

            // Consultar asistencia
            static void ConsultarAsistencia()
            {
                Console.WriteLine("1. Consultar por materia y día");
                Console.WriteLine("2. Consultar por día completo");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    string materia = Seleccionar("materia", materias);
                    string dia = Seleccionar("día", dias);
                    MostrarLista(asistencia[materia][dia], materia, dia);
                }
                else if (opcion == "2")
                {
                    string dia = Seleccionar("día", dias);
                    foreach (var materia in materias)
                    {
                        MostrarLista(asistencia[materia][dia], materia, dia);
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }
            }

            // Función para seleccionar un elemento de una lista
            static string Seleccionar(string tipo, List<string> opciones)
            {
            Console.WriteLine($"\nSeleccione una {tipo}");
 

                while (true)
            {
                Console.Write($"Ingrese el número de la {tipo}: ");
                if (int.TryParse(Console.ReadLine(), out int seleccion)) ;

                else
                {
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                }
            }
        }

            // Muestra la lista de estudiantes por materia y día
            static void MostrarLista(List<string> lista, string materia, string dia)
            {
                Console.WriteLine($"\n📚 Asistencia para {materia} el día {dia}:");

                if (lista.Count == 0)
                {
                    Console.WriteLine("🔹 No hay estudiantes registrados.");
                }
                else
                {
                    foreach (var estudiante in lista)
                    {
                        Console.WriteLine($"- {estudiante}");
                    }
                }
            }
        }
    }




using System;
using System.Collections.Generic;

class Program
{
    static List<Persona> estudiantes = new List<Persona>();
    static List<Calificacion> calificaciones = new List<Calificacion>();

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar nuevo estudiante");
            Console.WriteLine("2. Mostrar todos los estudiantes");
            Console.WriteLine("3. Buscar estudiantes por nombre, apellido o matrícula");
            Console.WriteLine("4. Eliminar estudiante por ID");
            Console.WriteLine("5. Añadir calificaciones para un estudiante en un curso específico");
            Console.WriteLine("6. Mostrar todas las calificaciones de un estudiante");
            Console.WriteLine("7. Buscar las calificaciones por curso o estudiante");
            Console.WriteLine("8. Eliminar calificaciones por ID");
            Console.WriteLine("9. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarEstudiante();
                    break;
                case "2":
                    MostrarEstudiantes();
                    break;
                case "3":
                    BuscarEstudiantes();
                    break;
                case "4":
                    EliminarEstudiante();
                    break;
                case "5":
                    AgregarCalificacion();
                    break;
                case "6":
                    MostrarCalificaciones();
                    break;
                case "7":
                    BuscarCalificaciones();
                    break;
                case "8":
                    EliminarCalificacion();
                    break;
                case "9":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AgregarEstudiante()
    {
        Console.WriteLine("Ingrese el ID del estudiante:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nombre del estudiante:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido del estudiante:");
        string apellido = Console.ReadLine();

        Console.WriteLine("Ingrese la matrícula del estudiante:");
        string matricula = Console.ReadLine();

        estudiantes.Add(new Persona { ID = id, Nombre = nombre, Apellido = apellido, Matrícula = matricula });

        Console.WriteLine("Estudiante agregado exitosamente");
    }

    static void MostrarEstudiantes()
    {
        Console.WriteLine("Lista de estudiantes:");

        foreach (Persona estudiante in estudiantes)
        {
            Console.WriteLine($"ID: {estudiante.ID}, Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, Matrícula: {estudiante.Matrícula}");
        }
    }

    static void BuscarEstudiantes()
    {
        Console.WriteLine("Ingrese el término de búsqueda:");
        string termino = Console.ReadLine();

        List<Persona> resultados = estudiantes.FindAll(estudiante => estudiante.Nombre.Contains(termino) || estudiante.Apellido.Contains(termino) || estudiante.Matrícula.Contains(termino));

        Console.WriteLine($"Se encontraron {resultados.Count} resultados:");

        foreach (Persona estudiante in resultados)
        {
            Console.WriteLine($"ID: {estudiante.ID}, Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, Matrícula: {estudiante.Matrícula}");
        }
    }

    static void EliminarEstudiante()
    {
        Console.WriteLine("Ingrese el ID del estudiante a eliminar:");
        int id = int.Parse(Console.ReadLine());

        int eliminados = estudiantes.RemoveAll(estudiante => estudiante.ID == id);

        if (eliminados > 0)
        {
            Console.WriteLine($"Se eliminaron {eliminados} estudiantes");
        }
        else
        {
            Console.WriteLine("No se encontró ningún estudiante con ese ID");
        }
    }

    static void AgregarCalificacion()
    {
        Console.WriteLine("Ingrese el ID de la calificación:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del estudiante:");
        int idEstudiante = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el curso:");
        string curso = Console.ReadLine();

        Console.WriteLine("Ingrese la calificación:");
        double calificacion = double.Parse(Console.ReadLine());

        calificaciones.Add(new Calificacion { ID = id, ID_Estudiante = idEstudiante, Curso = curso, Calificación = calificacion });

        Console.WriteLine("Calificación agregada exitosamente");
    }

    static void MostrarCalificaciones()
    {
        Console.WriteLine("Ingrese el ID del estudiante:");
        int idEstudiante = int.Parse(Console.ReadLine());

        List<Calificacion> resultados = calificaciones.FindAll(calificacion => calificacion.ID_Estudiante == idEstudiante);

        Console.WriteLine($"Calificaciones del estudiante con ID {idEstudiante}:");

        foreach (Calificacion calificacion in resultados)
        {
            Console.WriteLine($"ID: {calificacion.ID}, Curso: {calificacion.Curso}, Calificación: {calificacion.Calificación}");
        }
    }

    static void BuscarCalificaciones()
    {
        Console.WriteLine("Ingrese el término de búsqueda:");
        string termino = Console.ReadLine();

        List<Calificacion> resultados = calificaciones.FindAll(calificacion => calificacion.Curso.Contains(termino) || calificacion.ID_Estudiante.ToString().Contains(termino));

        Console.WriteLine($"Se encontraron {resultados.Count} resultados:");

        foreach (Calificacion calificacion in resultados)
        {
            Console.WriteLine($"ID: {calificacion.ID}, ID Estudiante: {calificacion.ID_Estudiante}, Curso: {calificacion.Curso}, Calificación: {calificacion.Calificación}");
        }
    }

    static void EliminarCalificacion()
    {
        Console.WriteLine("Ingrese el ID de la calificación a eliminar:");
        int id = int.Parse(Console.ReadLine());

        int eliminados = calificaciones.RemoveAll(calificacion => calificacion.ID == id);

        if (eliminados > 0)
        {
            Console.WriteLine($"Se eliminaron {eliminados} calificaciones");
        }
        else
        {
            Console.WriteLine("No se encontró ninguna calificación con ese ID");
        }
    }
}
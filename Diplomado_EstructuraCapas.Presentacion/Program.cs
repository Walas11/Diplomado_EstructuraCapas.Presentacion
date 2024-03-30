using Diplomado_EstructuraCapas.Dominio.Services;
using Diplomado_EstructuraCapas.Infraestructura.Entidades;
using Dominio_EstructuraCapas.Comunes.Enums;

namespace Diplomado_EstructuraCapas.Presentacion
{
    internal class Program
    {
        private static EstudiantesServices _estudiantesServices;

        public Program()
        {
            _estudiantesServices = new EstudiantesServices();
        }

        static void Main()
        {
            //Cambios
            int id;
            string email;
            string nombre;
            decimal telefono;
            List<EstudianteEntity> ListaEstudiantes;
            EstudianteEntity ObjectEstudiante = new();

            //** Menu **
            Console.WriteLine("-- MENU --");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Consult_Id");
            Console.WriteLine("5. Consult_All");
            Console.WriteLine("6. Consult_Email");
            int menu = int.Parse(Console.ReadLine());

            try
            {
                switch (menu)
                {
                    case (int)OperacionEnum.Insert:
                        Console.WriteLine("Escriba el telefono del estudiante");
                        telefono = decimal.Parse(Console.ReadLine());
                        ObjectEstudiante.telefono = telefono;
                        Console.WriteLine("Escriba el id del estudiante");
                        email = Console.ReadLine();
                        ObjectEstudiante.correo = email;
                        Console.WriteLine("Escriba el correo del estudiante");
                        nombre = Console.ReadLine();
                        ObjectEstudiante.nombre = nombre;
                        ObjectEstudiante = _estudiantesServices.InsertarEstudiante(ObjectEstudiante);
                        break;
                    case (int)OperacionEnum.Update:
                        Console.WriteLine("Escriba el id del estudiante a actualizar");
                        id = int.Parse(Console.ReadLine());
                        ObjectEstudiante.id_estudiante = id;
                        Console.WriteLine("Escriba el telefono del estudiante");
                        telefono = decimal.Parse(Console.ReadLine());
                        ObjectEstudiante.telefono = telefono;
                        Console.WriteLine("Escriba el id del estudiante");
                        email = Console.ReadLine();
                        ObjectEstudiante.correo = email;
                        Console.WriteLine("Escriba el id del estudiante");
                        nombre = Console.ReadLine();
                        ObjectEstudiante.nombre = nombre;
                        ObjectEstudiante = _estudiantesServices.ActualizarEstudiante(ObjectEstudiante);
                        break;
                    case (int)OperacionEnum.Delete:
                        Console.WriteLine("Escriba el id del estudiante a eliminar");
                        id = int.Parse(Console.ReadLine());
                        string result = _estudiantesServices.EliminarEstudiante(id);
                        Console.WriteLine(result);
                        break;
                    case (int)OperacionEnum.Consult_Id:
                        Console.WriteLine("Escriba el id del estudiante a consultar");
                        id = int.Parse(Console.ReadLine());
                        ObjectEstudiante = _estudiantesServices.ObtenerEstudiantes(id);
                        Console.WriteLine(ObjectEstudiante);
                        break;
                    case (int)OperacionEnum.Consult_All:
                        ListaEstudiantes = _estudiantesServices.ObtenerEstudiantes();
                        Console.WriteLine($"ListaEstudiantes: { ListaEstudiantes}");
                        break;
                    case (int)OperacionEnum.Consult_Email:
                        Console.WriteLine("Escriba el email del estudiante a consultar");
                        email = Console.ReadLine();
                        ObjectEstudiante = _estudiantesServices.ObtenerEstudiantes(0, email);
                        Console.WriteLine($"ListaEstudiantes: {ObjectEstudiante}");
                        break;
                    default:
                        Console.WriteLine("La opción digitada no esta disponible");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}  
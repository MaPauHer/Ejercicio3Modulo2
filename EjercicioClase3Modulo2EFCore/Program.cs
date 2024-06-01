using Microsoft.EntityFrameworkCore;


namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.
            #endregion

            var options = new DbContextOptionsBuilder<BDContext>();
            options.UseSqlServer("Data Source=DESKTOP-EJRGUFU\\SQLEXPRESS;Initial Catalog=SimpleIMDB;Integrated Security=True");

            var context = new BDContext(options.Options);

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor
            
            var Actores = context.Actor.ToList();

            #endregion

            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor

            var Actrices = context.Actor.Where(actriz => actriz.Genero == "F").ToList();

            #endregion

            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor

            var ActoresMas50 = context.Actor.Where(actor => actor.Edad > 50).ToList();

            #endregion

            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"

            var EdadJulia = context.Actor.Where(actor => actor.Nombre == "Julia" && actor.Apellido == "Roberts").Select(actor => actor.Edad);

            #endregion

            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.

            Actor Darin = new Actor() { Nombre = "Ricardo", Apellido = "Darin", Edad = 67, NombreArtistico = "Ricardo Darin", Nacionalidad = "argentino", Genero = "M" };
            
            context.Actor.Add( Darin );

            context.SaveChanges();

            #endregion

            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.

            int CantExtranjeros = context.Actor.Where(extranjero => extranjero.Nacionalidad != "USA").Count();

            #endregion

            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.

            var ActoresNyA = context.Actor.Where(actor => actor.Genero == "M").Select(act => new { act.Nombre, act.Apellido }).ToList();

            #endregion
             
        }
    }
}
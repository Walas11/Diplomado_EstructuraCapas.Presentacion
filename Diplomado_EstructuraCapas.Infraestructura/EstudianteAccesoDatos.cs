using Diplomado_EstructuraCapas.Infraestructura.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Diplomado_EstructuraCapas.Infraestructura
{
    public class EstudianteAccesoDatos
    {
        private readonly Conexion _conexion;
        private SqlDataReader _reader;
        private SqlCommand _command;
        private DataTable _tabla;

        public EstudianteAccesoDatos() 
        {
            _conexion = new Conexion();
            _command = new SqlCommand();
            _tabla = new DataTable();
        }

        public DataTable CrudEstudiantes(int operacion, EstudianteEntity estudianteEntity) 
        {
            try
            {
                _command = new SqlCommand();
                _tabla = new DataTable();
                _command.Connection = _conexion.AbrirConexion();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "crudEstudiante";

                //Agregar los parametros del SP

                _command.Parameters.AddWithValue("@param_idOperacion", operacion);
                _command.Parameters.AddWithValue("@param_id", estudianteEntity.id_estudiante);
                _command.Parameters.AddWithValue("@param_nombre", estudianteEntity.nombre);
                _command.Parameters.AddWithValue("@param_telefono", estudianteEntity.telefono);
                _command.Parameters.AddWithValue("@param_direccion", estudianteEntity.direccion);
                _command.Parameters.AddWithValue("@param_correo", estudianteEntity.correo);

                _reader = _command.ExecuteReader();
                _tabla.Load(_reader);
                return _tabla;

            }
            catch (Exception e)
            {

                throw new Exception("Error en Acceso Datros Crud--" + e.Message);
            }
            finally 
            {
                _command.Dispose();
                _conexion.CerrarConexion();
            }
        }
    }
}

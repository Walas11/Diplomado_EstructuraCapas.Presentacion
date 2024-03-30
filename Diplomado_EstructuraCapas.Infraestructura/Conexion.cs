using System.Data.SqlClient;

namespace Diplomado_EstructuraCapas.Infraestructura
{
    public class Conexion
    {
        private SqlConnection _conexion;

        /// <summary>
        /// Se crea el constructor y la conexion directa de la base de datos
        /// </summary>
        public Conexion()
        {
            _conexion = new SqlConnection("Server=DESKTOP-NIS1R6M;Initial catalog=Matricula;User ID=sa;Password=Liliana11.");
        }

        /// <summary>
        /// Abrir conexion base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection AbrirConexion() 
        {
            if (_conexion.State == System.Data.ConnectionState.Closed)
                _conexion.Open();
            return _conexion;
        }        
        
        /// <summary>
        /// Cerrar conexion Base de Datos
        /// </summary>
        public void CerrarConexion() 
        {
            _conexion.Close();
        }
    }
}

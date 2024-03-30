using Diplomado_EstructuraCapas.Infraestructura;
using Diplomado_EstructuraCapas.Infraestructura.Entidades;
using Dominio_EstructuraCapas.Comunes.Enums;
using Dominio_EstructuraCapas.Comunes.Helpers;
using System.Data;

namespace Diplomado_EstructuraCapas.Dominio.Services
{
    public class EstudiantesServices
    {
        private EstudianteAccesoDatos _estudianteAccesoDatos;
        public EstudiantesServices()
        {
            _estudianteAccesoDatos = new EstudianteAccesoDatos();
        }

        /// <summary>
        ///  Metodo que retonra la lista de los estudiantes que encuentra en la DB
        /// </summary>
        /// <returns></returns>
        public List<EstudianteEntity> ObtenerEstudiantes() 
        {
            //Voy a la capa de infraestructura
            DataTable data = _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Consult_All, new EstudianteEntity());
            List<EstudianteEntity>  listaEstudianteEntities = ParsearDataTableHelper.ConvertDataTableToList<EstudianteEntity>(data);
            return listaEstudianteEntities;
        }

        /// <summary>
        /// Consulta el documento por id o por correo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="correo"></param>
        /// <returns></returns>
        public EstudianteEntity ObtenerEstudiantes(int id, string correo = "")
        {
            EstudianteEntity estudianteEntity = new EstudianteEntity();
            DataTable data;
            estudianteEntity.id_estudiante = id;

            if (!string.IsNullOrEmpty(correo))
            {
                estudianteEntity.correo = correo;
                data = _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Consult_Email, estudianteEntity);
            }
            else
            {
                data = _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Consult_Id, estudianteEntity);
            }
            //Voy a la capa de infraestructura
            estudianteEntity = ParsearDataTableHelper.ConvertDataTableToObject<EstudianteEntity>(data);
            return estudianteEntity;
        }

        /// <summary>
        /// Inserción del estudiante
        /// </summary>
        /// <param name="estudianteEntity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public EstudianteEntity InsertarEstudiante(EstudianteEntity estudianteEntity)
        {
            DataTable data = _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Insert, estudianteEntity);
            if (data.Rows.Count > 0)
            {
                return ParsearDataTableHelper.ConvertDataTableToObject<EstudianteEntity>(data);
            }
            else
                throw new Exception("No se puede insertar el estudiante, por favor intente nuevamente");
        }

        /// <summary>
        /// ACtualización del estudainte
        /// </summary>
        /// <param name="estudianteEntity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public EstudianteEntity ActualizarEstudiante(EstudianteEntity estudianteEntity)
        {
            EstudianteEntity estudiante = ObtenerEstudiantes((int)estudianteEntity.id_estudiante);
            if (estudiante!= null)
            {
                DataTable data = _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Update, estudiante);
                if (data.Rows.Count > 0)
                {
                    return ParsearDataTableHelper.ConvertDataTableToObject<EstudianteEntity>(data);
                }
                else
                    throw new Exception("No se puede actualizar el estudiante, por favor intente nuevamente");
            }
            else
            {
                throw new Exception("No se encontró el estudiante a actualizar, vuelva a intenrtar");
            }
        }

        /// <summary>
        /// Eliminar por id el estudiante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string EliminarEstudiante(int id)
        {
            EstudianteEntity estudiante = ObtenerEstudiantes(id);
            if (estudiante != null)
            {
                DataTable data = _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Delete, estudiante);
                if (data.Rows.Count > 0)
                {
                    return $"Se eliminó con exito el estudiante con id {estudiante.id_estudiante}";
                }
                else
                    return "No se pudo eliminar el estudiante";
            }
            else
            {
                throw new Exception("No se encontró el estudiante a actualizar, vuelva a intenrtar");
            }
        }
    }
}

using Diplomado_EstructuraCapas.Infraestructura.Entidades;
using Dominio_EstructuraCapas.Comunes.Enums;
using Dominio_EstructuraCapas.Comunes.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomado_EstructuraCapas.Infraestructura
{
    public class EstudiantesRepositorio : IEstudiantesRepositorio
    {
        private EstudianteAccesoDatos _estudianteAccesoDatos;
        public EstudiantesRepositorio()
        {
            _estudianteAccesoDatos = new EstudianteAccesoDatos();
        }

        public EstudianteEntity Actualizar(EstudianteEntity estudianteEntity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(EstudianteEntity estudianteEntity)
        {
            throw new NotImplementedException();
        }

        public EstudianteEntity Insertar(EstudianteEntity estudianteEntity)
        {
            throw new NotImplementedException();
        }

        public List<EstudianteEntity> ListarEstudiantes()
        {
            return ParsearDataTableHelper.ConvertDataTableToList<EstudianteEntity>
                (
                _estudianteAccesoDatos.CrudEstudiantes((int)OperacionEnum.Consult_All, new EstudianteEntity())
                );
        }
    }
}

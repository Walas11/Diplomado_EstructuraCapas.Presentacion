using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomado_EstructuraCapas.Infraestructura.Entidades
{
    public interface IEstudiantesRepositorio
    {
        List<EstudianteEntity> ListarEstudiantes();
        EstudianteEntity Insertar(EstudianteEntity estudianteEntity);
        EstudianteEntity Actualizar(EstudianteEntity estudianteEntity);
        void Eliminar(EstudianteEntity estudianteEntity);

    }
}

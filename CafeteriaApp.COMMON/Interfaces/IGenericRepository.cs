using CafeteriaApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// se usa para implementar en la capa DAL del proyecto  
/// </summary>
namespace CafeteriaApp.COMMON.Interfaces
{
    public interface IGenericRepository<T> where T:BaseDTO
    {
        /// <summary>
        /// Proporciona Informacion sobre el error ocurrido en alguna de las operaciones
        /// </summary>
        string Error { get; }
        //operaciones Crud
        /// <summary>
        /// inserta una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">entidad a insertar sin id</param>
        /// <returns>entidad completa</returns>
        T Create(T entidad);
       
        /// <summary>
        /// regresa todos los registros de la tabla
        /// </summary>
        /// 
        IEnumerable<T> Read { get; }
        /// <summary>
        /// actualiza una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">entidad a actualizar en la base de datos en base a su id</param>
        /// <returns>Entidad actualizada</returns>
        T Update(T entidad);

        /// <summary>
        /// elimina deacuerdo al id proporcionado
        /// </summary>
        /// <param name="id">Id de la entidad a elimnar </param>
        /// <returns> la confiracion de que fue eliminada la cantidad</returns>
        bool Delete(string id);

        /// <summary>
        /// ejecuta una consulta sql sobre la tabla regresando toros los campos de misma
        /// </summary>
        /// <param name="querySql">consulta sql</param>
        /// <returns> conjunto de entidades que coinciden con la consulta</returns>
        IEnumerable<T> Query(string querySql);

        /// <summary>
        /// buscar una entidad por su id
        /// </summary>
        /// <param name="id">Id de la entidad a buscar</param>
        /// <returns>Entidad que coincide </returns>
        T SearchById(string id);
    }
}

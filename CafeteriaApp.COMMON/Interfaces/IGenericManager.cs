﻿using CafeteriaApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// se utiliza en la capa biz
/// utilizados en la capas superiores 
/// </summary>
namespace CafeteriaApp.COMMON.Interfaces
{

    public interface IGenericManager<T> where T:BaseDTO
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
        T Insert(T entidad);

        /// <summary>
        /// regresa todos los registros de la tabla
        /// </summary>
        /// 
        IEnumerable<T> ObtenerTodos { get; }
        /// <summary>
        /// actualiza una entidad en la base de datos
        /// </summary>
        /// <param name="entidad">entidad a actualizar en la base de datos en base a su id</param>
        /// <returns>Entidad actualizada</returns>
        T Actualizar(T entidad);

        /// <summary>
        /// elimina deacuerdo al id proporcionado
        /// </summary>
        /// <param name="id">Id de la entidad a elimnar </param>
        /// <returns> la confiracion de que fue eliminada la cantidad</returns>
        bool Eliminar(string id);

    }
}

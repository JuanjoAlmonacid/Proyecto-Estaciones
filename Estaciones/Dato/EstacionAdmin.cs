using Estaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estaciones.Dato
{
    public class EstacionAdmin
    {
        public IEnumerable<estacion> Consultar()
        {
            ///<summary>
            /// Consulta todos las estaciones
            /// <returns>datos de los vehiculos</returns>

            using (EstacionesdbEntities contexto=new EstacionesdbEntities()) {
                return contexto.estacion.AsNoTracking().ToList();
            
            }
        }

        ///<summary>
        ///Guardar estacion en la base de datos
        /// </summary>
        /// <param name="modelo"></param>
        public void Guardar(estacion modelo) {
            using (EstacionesdbEntities contexto = new EstacionesdbEntities()) {
                contexto.estacion.Add(modelo);
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Consulta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public estacion Consultar(int id) {
            using (EstacionesdbEntities contexto = new EstacionesdbEntities()) {
                return contexto.estacion.FirstOrDefault(e => e.Id == id);
            }
        }
        /// <summary>
        /// Modifica los datos de la estacion
        /// </summary>
        /// <param name="modelo"></param>
        public void Modificar(estacion modelo) {
            using (EstacionesdbEntities contexto = new EstacionesdbEntities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Eliminar una estacion
        /// </summary>
        /// <param name="modelo"></param>
        public void Eliminar(estacion modelo) {
            using (EstacionesdbEntities contexto = new EstacionesdbEntities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        
        }
    }
}
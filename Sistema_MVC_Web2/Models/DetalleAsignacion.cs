namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("DetalleAsignacion")]
    public partial class DetalleAsignacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DetalleAsignacion()
        {
            ControlAsignacion = new HashSet<ControlAsignacion>();
        }

        [Key]
        public int detalleasignacion_id { get; set; }

        public int asignacion_id { get; set; }

        public int docente_id { get; set; }

        public int criterio_id { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Asignacion Asignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Docente Docente { get; set; }

        public List<DetalleAsignacion> Listar()//Retorna una coleccion de registros
        {
            var objDetalleAsignacion = new List<DetalleAsignacion>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objDetalleAsignacion = db.DetalleAsignacion.Include("Asignacion").Include("Docente").Include("Criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetalleAsignacion;
        }

        //Metodo obtener
        public DetalleAsignacion Obtener(int id)//retorna solo un objeto
        {
            var objDetalleAsignacion = new DetalleAsignacion();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objDetalleAsignacion = db.DetalleAsignacion.Include("Asignacion").Include("Docente").Include("Criterio")
                        .Where(x => x.detalleasignacion_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDetalleAsignacion;
        }

        //Metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.detalleasignacion_id > 0)
                    {
                        //si existe un valor mayor a 0 es porque existe un registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe registro graba(nuevo registro)
                        db.Entry(this).State = EntityState.Added;

                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Metodo Eliminar
        public void Eliminar()
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

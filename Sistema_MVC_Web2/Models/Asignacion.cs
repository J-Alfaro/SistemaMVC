namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    [Table("Asignacion")]
    public partial class Asignacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asignacion()
        {
            DetalleAsignacion = new HashSet<DetalleAsignacion>();
        }

        [Key]
        public int asignacion_id { get; set; }

        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecharegistro { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAsignacion> DetalleAsignacion { get; set; }

        public List<Asignacion> Listar()//Retorna una coleccion de registros
        {
            var objAsignacion = new List<Asignacion>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objAsignacion = db.Asignacion.Include("Semestre")/*.Include("DetalleAsignacion").Include("Docente").Include("Criterio")*/.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objAsignacion;
        }

        //Metodo obtener
        public Asignacion Obtener(int id)//retorna solo un objeto
        {
            var objAsignacion = new Asignacion();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objAsignacion = db.Asignacion.Include("Semestre")
                        .Where(x => x.asignacion_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objAsignacion;
        }

        //Metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.asignacion_id > 0)
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

namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Criterio")]
    public partial class Criterio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criterio()
        {
            Actividad = new HashSet<Actividad>();
            ControlAsignacion = new HashSet<ControlAsignacion>();
            DetalleAsignacion = new HashSet<DetalleAsignacion>();
            EvidenciaCriterio = new HashSet<EvidenciaCriterio>();
        }

        [Key]
        public int criterio_id { get; set; }

        public int modelo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_spanish { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_english { get; set; }

        [StringLength(250)]
        public string urlcriterio { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }

        public virtual Modelo Modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAsignacion> DetalleAsignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaCriterio> EvidenciaCriterio { get; set; }

        //mMtodo listar
        public List<Criterio> Listar()//Retorna una coleccion de registros
        {
            var objCriterio = new List<Criterio>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objCriterio = db.Criterio.Include("Modelo").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCriterio;
        }

        //Metodo obtener
        public Criterio Obtener(int id)//retorna solo un objeto
        {
            var objCriterio = new Criterio();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objCriterio = db.Criterio.Include("Modelo")
                        .Where(x => x.criterio_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCriterio;
        }

        //Metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.criterio_id > 0)
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

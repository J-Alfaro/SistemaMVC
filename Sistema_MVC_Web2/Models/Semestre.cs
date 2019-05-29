namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    [Table("Semestre")]
    public partial class Semestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semestre()
        {
            Actividad = new HashSet<Actividad>();
            Asignacion = new HashSet<Asignacion>();
            Control = new HashSet<Control>();
        }

        [Key]
        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        public int? anio { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asignacion> Asignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control> Control { get; set; }


        //Metodo Listar
        public List<Semestre> Listar()
        {
            var objSemestre = new List<Semestre>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objSemestre = db.Semestre.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //Metodo Obtener
        public Semestre Obtener(int id)//retorna solo un objeto
        {
            var objSemestre = new Semestre();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objSemestre = db.Semestre
                                    .Where(x => x.semestre_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.semestre_id > 0)//sis existe un valor mayor a cero es porque existe registro
                    {
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        //SINO EXISTE EL REGISTRO LO GRABA(nuevo)
                        db.Entry(this).State = System.Data.Entity.EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo Eliminar 
        public void Eliminar()
        {
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
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

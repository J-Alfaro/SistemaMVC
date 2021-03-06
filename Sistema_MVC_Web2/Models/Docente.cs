namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Docente")]
    public partial class Docente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docente()
        {
            ControlAsignacion = new HashSet<ControlAsignacion>();
            DetalleAsignacion = new HashSet<DetalleAsignacion>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int docente_id { get; set; }

        public int docente_codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [Required]
        [StringLength(250)]
        public string cargo { get; set; }

        [Required]
        [StringLength(30)]
        public string condicion { get; set; }

        [Required]
        [StringLength(50)]
        public string categoria { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAsignacion> DetalleAsignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public List<Docente> Listar()
        {
            var objDocente = new List<Docente>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objDocente = db.Docente.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDocente;
        }

        //Metodo Obtener
        public Docente Obtener(int id)//retorna solo un objeto
        {
            var objDocente = new Docente();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objDocente = db.Docente
                                    .Where(x => x.docente_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDocente;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.docente_id > 0)//sis existe un valor mayor a cero es porque existe registro
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

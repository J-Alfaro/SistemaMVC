namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    [Table("Modelo")]
    public partial class Modelo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modelo()
        {
            Criterio = new HashSet<Criterio>();
        }

        [Key]
        public int modelo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Criterio> Criterio { get; set; }

        //Metodo Listar
        public List<Modelo> Listar()
        {
            var objModelo = new List<Modelo>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objModelo = db.Modelo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objModelo;
        }

        //Metodo Obtener
        public Modelo Obtener(int id)//retorna solo un objeto
        {
            var objModelo = new Modelo();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objModelo = db.Modelo
                                    .Where(x => x.modelo_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objModelo;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.modelo_id > 0)//sis existe un valor mayor a cero es porque existe registro
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

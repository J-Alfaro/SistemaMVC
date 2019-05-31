namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.IO;

    using System.Data.Entity;
    [Table("EvidenciaCriterio")]
    public partial class EvidenciaCriterio
    {
        [Key]
        public int evidenciacriterio_id { get; set; }

        public int criterio_id { get; set; }

        //[Required]
        [StringLength(250)]
        public string archivo { get; set; }

        //[Required]
        [StringLength(10)]
        public string tamanio { get; set; }

        //[Required]
        [StringLength(10)]
        public string tipo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public virtual Criterio Criterio { get; set; }





        //Metodo Listar
        public List<EvidenciaCriterio> Listar()
        {
            var objEvidenciaCriterio = new List<EvidenciaCriterio>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objEvidenciaCriterio = db.EvidenciaCriterio.Include("Criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaCriterio;
        }

        //Metodo Obtener
        public EvidenciaCriterio Obtener(int id)//retorna solo un objeto
        {
            var objEvidenciaCriterio = new EvidenciaCriterio();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objEvidenciaCriterio = db.EvidenciaCriterio.Include("Criterio")
                                    .Where(x => x.evidenciacriterio_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaCriterio;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.evidenciacriterio_id > 0)//sis existe un valor mayor a cero es porque existe registro
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
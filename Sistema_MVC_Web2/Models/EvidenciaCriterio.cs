namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    using System.Data.Entity.Validation;
    using System.Web;
    using System.IO;

    [Table("EvidenciaCriterio")]
    public partial class EvidenciaCriterio
    {
        [Key]
        public int evidencia_id { get; set; }

        public int criterio_id { get; set; }

        [Required]
        [StringLength(250)]
        public string archivo { get; set; }

        [Required]
        [StringLength(10)]
        public string tamanio { get; set; }

        [Required]
        [StringLength(10)]
        public string tipo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public virtual Criterio Criterio { get; set; }
        

        //Metodo listar
        public List<EvidenciaCriterio> Listar()//Retorna una coleccion de registros
        {
            var objUsuario = new List<EvidenciaCriterio>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objUsuario = db.EvidenciaCriterio.Include("Criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        //Metodo obtener
        public EvidenciaCriterio Obtener(int id)//retorna solo un objeto
        {
            var objUsuario = new EvidenciaCriterio();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objUsuario = db.EvidenciaCriterio.Include("Criterio")
                        .Where(x => x.evidencia_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        //Metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.evidencia_id > 0)
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

        //metodo Eliminar
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

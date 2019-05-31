namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("EvidenciaActividad")]
    public partial class EvidenciaActividad
    {
        [Key]
        public int evidenciaactividad_id { get; set; }

        public int actividad_id { get; set; }

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

        public virtual Actividad Actividad { get; set; }

        //mMtodo listar
        public List<EvidenciaActividad> Listar()//Retorna una coleccion de registros
        {
            var objEvidenciaActividad = new List<EvidenciaActividad>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objEvidenciaActividad = db.EvidenciaActividad.Include("Actividad").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaActividad;
        }

        //Metodo obtener
        public EvidenciaActividad Obtener(int id)//retorna solo un objeto
        {
            var objEvidenciaActividad = new EvidenciaActividad();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objEvidenciaActividad = db.EvidenciaActividad.Include("Actividad")
                        .Where(x => x.evidenciaactividad_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidenciaActividad;
        }

        //Metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.evidenciaactividad_id > 0)
                    {
                        //si existe un valor mayor a 0 es porque existe un registro
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;

                    }
                    else
                    {
                        //si no existe registro graba(nuevo registro)
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

namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;


    [Table("Control")]
    public partial class Control
    {
        [Key]
        public int control_id { get; set; }

        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechacreacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Semestre Semestre { get; set; }

        //metodo listar
        public List<Control> Listar()//Retorna una coleccion de registros
        {
            var objControl = new List<Control>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objControl = db.Control.Include("Semestre").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objControl;
        }

        //metodo obtener
        public Control Obtener(int id)//retorna solo un objeto
        {
            var objControl = new Control();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objControl = db.Control.Include("Semestre")
                        .Where(x => x.control_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objControl;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.control_id > 0)
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

namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("ControlAsignacion")]
    public partial class ControlAsignacion
    {
        [Key]
        public int controlasignacion_id { get; set; }

        public int detalleasignacion_id { get; set; }

        public int docente_id { get; set; }

        public int criterio_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaasignacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaculminacion { get; set; }

        [StringLength(30)]
        public string duracion { get; set; }

        [Required]
        [StringLength(2)]
        public string sustento { get; set; }

        [Required]
        [StringLength(4)]
        public string porcentaje { get; set; }

        [Required]
        [StringLength(30)]
        public string condicion { get; set; }

        [Required]
        [StringLength(250)]
        public string archivo { get; set; }

        [Column(TypeName = "text")]
        public string observacion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual DetalleAsignacion DetalleAsignacion { get; set; }

        public virtual Docente Docente { get; set; }


        public List<ControlAsignacion> Listar()//Retorna una coleccion de registros
        {
            var objControlAsignacion = new List<ControlAsignacion>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objControlAsignacion = db.ControlAsignacion.Include("DetalleAsignacion").Include("Docente").Include("Criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objControlAsignacion;
        }

        //Metodo obtener
        public ControlAsignacion Obtener(int id)//retorna solo un objeto
        {
            var objControlAsignacion = new ControlAsignacion();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objControlAsignacion = db.ControlAsignacion.Include("DetalleAsignacion").Include("Docente").Include("Criterio")
                        .Where(x => x.controlasignacion_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objControlAsignacion;
        }

        //Metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.controlasignacion_id > 0)
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

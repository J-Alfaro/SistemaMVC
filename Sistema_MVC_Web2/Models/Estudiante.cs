namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int estudiante_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int estudiante_codigo { get; set; }

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

        [Required]
        [StringLength(250)]
        public string direccion { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        //Metodo Listar
        public List<Estudiante> Listar()
        {
            var objEstudiante = new List<Estudiante>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objEstudiante = db.Estudiante.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEstudiante;
        }

        //Metodo Obtener
        public Estudiante Obtener(int id)//retorna solo un objeto
        {
            var objEstudiante = new Estudiante();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objEstudiante = db.Estudiante
                                    .Where(x => x.estudiante_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEstudiante;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    if (this.estudiante_id > 0)//sis existe un valor mayor a cero es porque existe registro
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

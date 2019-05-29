namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int docente_id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(20)]
        public string nivel { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Docente Docente { get; set; }

        //Metodo listar
        public List<Usuario> Listar()//Retorna una coleccion de registros
        {
            var objUsuario = new List<Usuario>();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objUsuario = db.Usuario.Include("Docente").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        //Metodo obtener
        public Usuario Obtener(int id)//retorna solo un objeto
        {
            var objUsuario = new Usuario();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    objUsuario = db.Usuario.Include("Docente")
                        .Where(x => x.usuario_id == id)
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
                    if (this.usuario_id > 0)
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

        //Metodo validar Login
        public ResponseModel ValidarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    Password = HashHelper.SHA1(Password);
                    var usuario = db.Usuario.Where(x => x.nombre == Usuario)
                                             .Where(x => x.clave == Password)
                                             .SingleOrDefault();
                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.usuario_id.ToString());
                        rm.SetResponse(true);

                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario o password incorrectos ..");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }

        //Metodo Actualizar perfil Personal 
        public ResponseModel GuardarPerfil(HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new Modelo_Sistemas())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    var Usu = db.Entry(this);
                    Usu.State = EntityState.Modified;

                    if (Foto != null)
                    {
                        string extension = Path.GetExtension(Foto.FileName).ToLower();
                        int size = 1024 * 1024 * 5;

                        var filtroextension = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extensiones = Path.GetExtension(Foto.FileName);

                        if (filtroextension.Contains(extensiones) && (Foto.ContentLength <= size))
                        {
                            String archivo = Path.GetFileName(Foto.FileName);
                            Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Imagenes/" + archivo));

                            this.avatar = archivo;
                        }
                    }

                    else Usu.Property(x => x.avatar).IsModified = false;

                    if (this.usuario_id == 0) Usu.Property(x => x.usuario_id).IsModified = false;
                    if (this.docente_id == 0) Usu.Property(x => x.docente_id).IsModified = false;
                    if (this.nombre == null) Usu.Property(x => x.nombre).IsModified = false;
                    if (this.clave == null) Usu.Property(x => x.clave).IsModified = false;
                    if (this.nivel == null) Usu.Property(x => x.nivel).IsModified = false;
                    if (this.estado == null) Usu.Property(x => x.estado).IsModified = false;
                    db.SaveChanges();
                    rm.SetResponse(true);

                }

            }
            catch (DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }
    }
}

namespace Sistema_MVC_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    [Table("EvidenciaCriterio")]
    public partial class EvidenciaCriterio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int evidencia_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    }
}

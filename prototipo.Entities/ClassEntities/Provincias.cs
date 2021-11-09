namespace prototipo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db.Provincias")]
    public partial class Provincias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provincias()
        {
            Localidades = new HashSet<Localidades>();
        }

        [Key]
        public int ProvinciaID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProvinciaName { get; set; }

        public int PaisID { get; set; }

        public int Available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Localidades> Localidades { get; set; }

        public virtual Paises Paises { get; set; }
    }
}

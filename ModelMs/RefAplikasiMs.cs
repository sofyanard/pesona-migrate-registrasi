using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pesona_migrate_registrasi.ModelMs
{
    [Table("RefAplikasi")]
    internal class RefAplikasiMs
    {
        [Key]
        [StringLength(3)]
        [Column("KdApp")]
        public string? KdApp { get; set; }

        [StringLength(50)]
        [Column("NmApp")]
        public string? NmApp { get; set; }

        [StringLength(2)]
        [Column("KdGrupApp")]
        public string? KdGrupApp { get; set; }

        [Column("ActiveF")]
        public bool? ActiveF { get; set; }

        [StringLength(255)]
        [Column("URL")]
        [DefaultValue("127.0.0.1")]
        public string? URL { get; set; }

        [Column("flag_sso")]
        [DefaultValue(0)]
        public byte? FlagSso { get; set; }
    }
}

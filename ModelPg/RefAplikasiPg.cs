using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pesona_migrate_registrasi.ModelPg
{
    [Table("refaplikasi")]
    internal class RefAplikasiPg
    {
        [Key]
        [StringLength(3)]
        [Column("kdapp")]
        public string? KdApp { get; set; }

        [StringLength(50)]
        [Column("nmapp")]
        public string? NmApp { get; set; }

        [StringLength(2)]
        [Column("kdgrupapp")]
        public string? KdGrupApp { get; set; }

        [Column("activef")]
        public bool? ActiveF { get; set; }

        [StringLength(255)]
        [Column("url")]
        [DefaultValue("127.0.0.1")]
        public string? URL { get; set; }

        [Column("flag_sso")]
        [DefaultValue(0)]
        public byte? FlagSso { get; set; }
    }
}

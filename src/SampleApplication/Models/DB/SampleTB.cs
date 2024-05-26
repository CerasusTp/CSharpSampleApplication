using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApplication.Models.DB
{
    [Table("sample_tb")]
    public class SampleTB
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("data")]
        public string? Data { get; set; }
    }
}

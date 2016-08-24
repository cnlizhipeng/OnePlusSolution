using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OP.Model
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(2)]
        public string Sex { get; set; }
        [Column("UPhoto", TypeName = "image")]
        public byte[] UPhoto { get; set; }
        public Nullable<int> Age { get; set; }
        public Guid RowGuid { get; set; }
        public Nullable<int> OrganizationID { get; set; }
    }
}

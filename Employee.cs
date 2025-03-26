using System.ComponentModel.DataAnnotations.Schema;

namespace pesona_migrate_registrasi
{
    [Table("employee")]
    public class Employee
    {
        [Column("employee_id")]
        public string? EmployeeId { get; set; }

        [Column("employee_name")]
        public string? EmployeeName { get; set; }
    }
}

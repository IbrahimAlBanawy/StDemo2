using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StDemo2.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        
        public string DeptName { get; set; }
        
        public int Capacity {  get; set; }

        public virtual List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{DeptId}:{DeptName}:{Capacity}";
        }

    }
}

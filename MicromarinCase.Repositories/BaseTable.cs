

using System.ComponentModel.DataAnnotations;

namespace MicromarinCase.Repositories
{
    public  abstract class BaseTable
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

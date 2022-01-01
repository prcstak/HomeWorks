using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace hw10.Models
{
    public class Cache
    {
        [Key]
        public string Expression { get; set; }
        public string Value { get; set; }
    }
}
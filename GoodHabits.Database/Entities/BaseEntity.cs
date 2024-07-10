using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHabits.Database.Entities
{
    public class BaseEntity
    {

        [Key]
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }
    }
}

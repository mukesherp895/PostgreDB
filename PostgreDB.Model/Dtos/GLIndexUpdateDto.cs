using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.Model.Dtos
{
    public class GLIndexUpdateDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public bool IsTrigger { get; set; }
        public List<GLIndexPostDto> GLIndexPostDtos { get; set; }
    }
}

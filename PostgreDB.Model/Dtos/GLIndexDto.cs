using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.Model.Dtos
{
    public class GLIndexDto
    {
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public bool IsTrigger { get; set; }
        public List<GLIndexPostDto> GLIndexPostDtos { get; set; }
    }
    public class GLIndexPostDto
    {
        public string Description { get; set; }
    }
}

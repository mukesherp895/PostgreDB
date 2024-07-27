using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.Model.DomainModels
{
    public class GLIndex
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public bool IsTrigger { get; set; }
        public ICollection<GLIndexPost> GLIndexPosts { get; set; }
    }
}

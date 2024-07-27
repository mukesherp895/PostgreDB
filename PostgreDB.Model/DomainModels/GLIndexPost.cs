using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.Model.DomainModels
{
    public  class GLIndexPost
    {
        public int Id { get; set; }
        public int GLIndexId { get; set; }
        public string Description { get; set; }
        public virtual GLIndex GLIndex { get; set; }
    }
}

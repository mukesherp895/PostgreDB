using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreDB.Model.DomainModels
{
    public class GLIndexDetail
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int RefId { get; set; }
    }
}

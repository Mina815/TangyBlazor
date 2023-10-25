using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DemoModels
{
    public class DemoProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public bool IsActive { get; set; }
        public List<DemoProductProp> Properties { get; set; }
    }
}

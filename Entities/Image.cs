using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Byte { get; set; }

        public string Type { get; set; }

        public int Id_Owner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCore.Entities.DataTransferObjects.Medias
{
    public class MediaDto
    {
        public int MediaId { get; set; }
        public string ItemTitle { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}

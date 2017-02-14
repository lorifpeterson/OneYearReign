using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneYearReign.Core.Models
{
    public class Album
    {
        public string Name { get; set; }
        public Image Image { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

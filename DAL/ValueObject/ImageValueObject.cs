using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ValueObject
{
    public class ImageValueObject
    {

        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string OriginalFileName { get; set; }
        public Int64 ContentLength { get; set; }
        public string AbsolutePath { get; set; }
        public string FileName { get; set; }
        public string ThumbnailName { get; set; }
        public string Mime { get; set; }
        public bool IsShow { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ImageProducts
    {

        public string Url { get; set; }
        public string ThumbNail { get; set; }
        public string OriginalFileName { get; set; }
        public Int64 ContentLength { get; set; }
        public string AbsolutePath { get; set; }
        public string FileName { get; set; }
        public string ThumbnailName { get; set; }
        public string Mime { get; set; }
        public bool IsShow { get; set; }

    }
}

﻿using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater5.Models.Requests
{
    public class BookmarkRequest
    {
        public int ID { get; set; }

        [StringLength(maximumLength: 500)]
        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public DateTime CreateDate { get; set; }
    }

    
}

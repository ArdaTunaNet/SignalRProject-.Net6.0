﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
       
         public string TestName { get; set; }
        public string TestTitle { get; set; }
        public string TestImageUrl { get; set; }

        public string TestStatus { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.DiscountDtos
{
    public class ResultDiscountDto
    {
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountImageUrl { get; set; }

        public string DiscountDescription { get; set; }
        public int Amount { get; set; }
    }
}

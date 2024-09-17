using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.TestimonialDtos
{
    public class ResultTestimonialDto
    {
        public int TestiomanialID { get; set; }
        public string TestName { get; set; }
        public string TestTitle { get; set; }
        //public string TestContent { get; set; }
        public string TestImageUrl { get; set; }
        public string TestStatus { get; set; }
    }
}

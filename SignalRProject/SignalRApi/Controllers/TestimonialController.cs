using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialservice;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialservice, IMapper mapper)
        {
            _testimonialservice = testimonialservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult TestimonialMedia(CreateTestimonialDto createtestimonialDto)
        {
            _testimonialservice.TAdd(new Testimonial
            {
                TestName = createtestimonialDto.TestName,
                TestTitle = createtestimonialDto.TestTitle,
                TestImageUrl = createtestimonialDto.TestImageUrl,
                TestStatus = createtestimonialDto.TestStatus,
            });
            return Ok("Testimonial Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonail(int id)
        {
            var value = _testimonialservice.TGetByID(id);
           _testimonialservice.TDelete(value);
            return Ok("Testimonial Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
           _testimonialservice.TUpdate(new Testimonial()
            {
              TestiomanialID=updateTestimonialDto.TestiomanialID,
              TestTitle = updateTestimonialDto.TestTitle,
               TestStatus = updateTestimonialDto.TestStatus,
               TestName = updateTestimonialDto.TestName,
              TestImageUrl = updateTestimonialDto.TestImageUrl,
              //TestContent=updateTestimonialDto.TestContent,


            });
            return Ok("Testimonial Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialservice.TGetByID(id);
            return Ok(value);
        }
    }
}

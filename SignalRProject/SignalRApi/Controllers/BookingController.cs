using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBookingList(CreateBookingDto createBookingDto)
        {
            var booking = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(booking);
            return Ok("Rezarvasyon yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            if (value == null)
            {
                return NotFound("Rezarvasyon bulunamadı.");
            }
            _bookingService.TDelete(value);
            return Ok("Rezarvasyon silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var existingBooking = _bookingService.TGetByID(updateBookingDto.BookingID);
            if (existingBooking == null)
            {
                return NotFound("Güncellenecek rezarvasyon bulunamadı.");
            }

            // AutoMapper kullanarak DTO'dan entity'ye mapleme işlemi
            _mapper.Map(updateBookingDto, existingBooking);

            _bookingService.TUpdate(existingBooking);
            return Ok("Rezarvasyon güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }
    }
}

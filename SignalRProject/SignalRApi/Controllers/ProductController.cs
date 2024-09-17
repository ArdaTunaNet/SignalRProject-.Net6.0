using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount() 
        { 
            return Ok(_productService.TGetProductCount());
        }
        [HttpGet("ProductByHamburgerCount")]
        public IActionResult ProductByHamburgerCount()
        {
            return Ok(_productService.TGetHamburgerCategoryProductHamburger());
        }
        [HttpGet("ProductByDrinkName")]
        public IActionResult ProductByDrinkName()
        {
            return Ok(_productService.TGetCategoryProductName());
        }


        [HttpGet("ProductListWithCategories")]
        public IActionResult ProductListWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoriesDto
            {
                ProductDescription = y.ProductDescription,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductImageUrl = y.ProductImageUrl,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            }

            );
            return Ok(values.ToList());


        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createproductDto)
        {
            _productService.TAdd(new Product
            {

                Price = createproductDto.Price,
                ProductDescription = createproductDto.ProductDescription,
                ProductImageUrl = createproductDto.ProductImageUrl,
                ProductName = createproductDto.ProductName,
                ProductStatus = createproductDto.ProductStatus,
                CategoryID=createproductDto.CategoryID

            });
            return Ok("Ürün Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
              ProductID= updateProductDto.ProductID,
              ProductName= updateProductDto.ProductName,
              ProductStatus= updateProductDto.ProductStatus,
              ProductImageUrl= updateProductDto.ProductImageUrl,
              ProductDescription= updateProductDto.ProductDescription,
              Price= updateProductDto.Price,
              CategoryID = updateProductDto.CategoryID


            });
            return Ok("Ürün Güncellendi");
        }
       
    }
}

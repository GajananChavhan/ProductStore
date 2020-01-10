using ProductStore.Models;
using ProductStore.Repositories;
using System.Web.Http;

namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_unitOfWork.Products.GetProductById(id));
        }

        public IHttpActionResult GetAllProduct()
        {
            return Ok(_unitOfWork.Products.GetAllProduct());
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            if (!_unitOfWork.Products.RemoveProduct(id))
            {
                return BadRequest();
            }
            _unitOfWork.Complete();
            return Ok();
        }

        public IHttpActionResult PutProduct(Product product)
        {
            var dbProduct = _unitOfWork.Products.GetProductById(product.Id);
            dbProduct.Name = product.Name;
            dbProduct.Currency = product.Currency;
            dbProduct.Price = product.Price;
            dbProduct.Unit = product.Unit;
            dbProduct.CategoryId = product.CategoryId;
            _unitOfWork.Complete();
            return Ok();
        }

        public IHttpActionResult PostProduct(Product product)
        {
            _unitOfWork.Products.AddProduct(product);
            _unitOfWork.Complete();
            return Created("", product);
        }

        [Route("api/getproductsbycategory/{id}")]
        public IHttpActionResult GetProductsByCategoryId(int id)
        {
            return Ok(_unitOfWork.Products.GetProductsByCategoryId(id));
        }

        [Route("api/getproductformdata/")]
        public IHttpActionResult GetProductFormData()
        {
            var formData = _unitOfWork.Products.GetProductsFormData();
            return Ok(formData);
        }
    }
}

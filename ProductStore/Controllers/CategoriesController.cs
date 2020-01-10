using ProductStore.Models;
using ProductStore.Repositories;
using System.Web.Http;

namespace ProductStore.Controllers
{
    public class CategoriesController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_unitOfWork.Categories.GetCategoryById(id));
        }

        public IHttpActionResult GetAllCategory()
        {
            return Ok(_unitOfWork.Categories.GetAllCategory());
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            if (!_unitOfWork.Categories.RemoveCategory(id))
            {
                return BadRequest();
            }
            _unitOfWork.Complete();
            return Ok();
        }

        public IHttpActionResult PutCategory(Category category)
        {
            var dbCategory = _unitOfWork.Categories.GetCategoryById(category.Id);
            dbCategory.Name = category.Name;
            _unitOfWork.Complete();
            return Ok();
        }

        public IHttpActionResult PostCategory(Category category)
        {
            _unitOfWork.Categories.AddCategory(category);
            _unitOfWork.Complete();
            return Created("", category);
        }
    }
}

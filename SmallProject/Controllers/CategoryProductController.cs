using Microsoft.AspNetCore.Mvc;
using SmallProject.DAL.Models;
using SmallProject.DAL.DbService;
using AutoMapper;
using SmallProject.DAL.ViewModels;
using SmallProject.DAL.ViewModelsWithId;

namespace SmallProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryProductController : Controller
{
    private readonly DbService _databaseService;
    private readonly IMapper _mapper;

    public CategoryProductController(DatabaseContext databaseService, IMapper mapper)
    {
        _databaseService = new DbService(databaseService);
        _mapper = mapper;
    }

    [Route("GetCategoryProduct")]
    [HttpGet]

    public async Task<IEnumerable<CategoryProduct>> GetCategories()
    {
        return await _databaseService.GetCategoryProducts();
    }

    [Route("GetCategoryProductByName/{id}")]
    [HttpGet]

    public async Task<CategoryProduct> GetCategoriesByCategoryId(int id)
    {
        return await _databaseService.GetCategoryProductByCategoryId(id);
    }

    [Route("GetCategoryProductById/{id}")]
    [HttpGet]

    public async Task<CategoryProduct> GetCategoryProductByProductId(int id)
    {
        return await _databaseService.GetCategoryProductByProductId(id);
    }

    [Route("AddCategoryProduct")]
    [HttpPost]
    public async Task<int> AddCategoryProduct(CategoryProductViewModel CategoryProduct)
    {
        var cat = _mapper.Map<CategoryProduct>(CategoryProduct);
        var result = await _databaseService.AddCategoryProduct(cat);
        return result;
    }
    [Route("AddCategoryProducts")]
    [HttpPost]

    public async Task<int> AddCategoryProducts(IEnumerable<CategoryProductViewModel> CategoryProductViewModels)
    {
        var newCategoryProduct = _mapper.Map<IEnumerable<CategoryProduct>>(CategoryProductViewModels);
        var res = await _databaseService.AddCategoryProducts(newCategoryProduct);
        return res;
    }

    [Route("UpdateCategoryProducts")]
    [HttpPost]
    public async Task<int> UdpateCategoryProducts(IEnumerable<CategoryProductViewModelWithId> CategoryProductViewModels)
    {
        var ca = _mapper.Map<IEnumerable<CategoryProduct>>(CategoryProductViewModels);
        var res = await _databaseService.UpdateCategoryProducts(ca);
        return res;
    }
    [Route("UpdateCateogory")]
    [HttpPost]

    public async Task<int> UpdateCategoryProduct(CategoryProductViewModelWithId CategoryProduct)
    {
        var cat = _mapper.Map<CategoryProduct>(CategoryProduct);
        return await _databaseService.UpdateCategoryProduct(cat);
    }

    [Route("RemoveCategoryProduct")]
    [HttpPost]

    public async Task<int> RemoveCategoryCategoryProduct(CategoryProductViewModelWithId CategoryProduct)
    {
        var cat = _mapper.Map<CategoryProduct>(CategoryProduct);
        return await _databaseService.RemoveCategoryProduct(cat);
    }

    [Route("RemoveCategoryProducts")]
    [HttpPost]

    public async Task<int> RemoveCategoryProducts(IEnumerable<CategoryProductViewModelWithId> CategoryProductViewModelWithIds)
    {
        var cat = _mapper.Map<IEnumerable<CategoryProduct>>(CategoryProductViewModelWithIds);
        return await _databaseService.RemoveCategoryProducts(cat);
    }
}


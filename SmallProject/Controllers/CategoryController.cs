using Microsoft.AspNetCore.Mvc;
using SmallProject.DAL.Models;
using SmallProject.DAL.DbService;
using AutoMapper;
using SmallProject.DAL.ViewModels;
using SmallProject.DAL.ViewModelsWithId;

namespace SmallProject.Controllers;
[ApiController]
[Route("api/[controller]")]
    public class CategoryController : Controller
    {
    private readonly DbService _databaseService;
    private readonly IMapper _mapper;

    public CategoryController(DatabaseContext databaseService, IMapper mapper)
    {
        _databaseService = new DbService(databaseService);
        _mapper = mapper;
    }

    [Route("GetCategory")]
    [HttpGet]

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _databaseService.GetCategorys();
    }

    [Route("GetCategoryByName/{name}")]
    [HttpGet]

    public async Task<IEnumerable<Category>> GetCategoriesByName(string name)
    {
        return await _databaseService.GetCategorysByName(name);
    }

    [Route("GetCategoryById/{id}")]
    [HttpGet]

    public async Task<Category> GetCategoryById(int id)
    {
        return await _databaseService.GetCategoryById(id);
    }

    [Route("AddCategory")]
    [HttpPost]
    public async Task<int> AddCategory(CategoryViewModel category)
    {
        var cat = _mapper.Map<Category>(category);
        var result = await _databaseService.AddCategory(cat);
        return result;
    }
    [Route("AddCategorys")]
    [HttpPost]

    public async Task<int> AddCategorys(IEnumerable<CategoryViewModel> categoryViewModels)
    {
        var newcategory = _mapper.Map<IEnumerable<Category>>(categoryViewModels);
        var res = await _databaseService.AddCategorys(newcategory);
        return res;
    }

    [Route("UpdateCategorys")]
    [HttpPost]
    public async Task<int> UdpateCategorys(IEnumerable<CategoryViewModelWithId> categoryViewModels)
    {
        var ca = _mapper.Map<IEnumerable<Category>>(categoryViewModels);
        var res = await _databaseService.UpdateCategorys(ca);
        return res;
    }
    [Route("UpdateCateogory")]
    [HttpPost]

    public async Task<int> UpdateCategory(CategoryViewModelWithId category)
    {
        var cat = _mapper.Map<Category>(category);
        return await _databaseService.UpdateCategory(cat);
    }

    [Route("RemoveCategory")]
    [HttpPost]

    public async Task<int> RemoveCategory(CategoryViewModelWithId category)
    {
        var cat = _mapper.Map<Category>(category);
        return await _databaseService.RemoveCategory(cat);
    }

    [Route("RemoveCategorys")]
    [HttpPost]

    public async Task<int> RemoveCategorys(IEnumerable<CategoryViewModelWithId> categoryViewModelWithIds )
    {
        var cat = _mapper.Map<IEnumerable<Category>>(categoryViewModelWithIds);
        return await _databaseService.RemoveCategorys(cat);
    }
}


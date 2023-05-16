using Microsoft.AspNetCore.Mvc;
using SmallProject.DAL.Models;
using SmallProject.DAL.DbService;
using AutoMapper;
using SmallProject.DAL.ViewModels;
using SmallProject.DAL.ViewModelsWithId;

namespace SmallProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly DbService _databaseService;
    private readonly IMapper _mapper;

    public ProductController(DatabaseContext databaseService, IMapper mapper)
    {
        _databaseService = new DbService(databaseService);
        _mapper = mapper;
    }

    [Route("GetProduct")]
    [HttpGet]

    public async Task<IEnumerable<Product>> GetCategories()
    {
        return await _databaseService.GetProducts();
    }

    [Route("GetProductByName/{name}")]
    [HttpGet]

    public async Task<IEnumerable<Product>> GetCategoriesByName(string name)
    {
        return await _databaseService.GetProductsByName(name);
    }

    [Route("GetProductById/{id}")]
    [HttpGet]

    public async Task<Product> GetProductById(int id)
    {
        return await _databaseService.GetProductById(id);
    }

    [Route("AddProduct")]
    [HttpPost]
    public async Task<int> AddProduct(ProductViewModel Product)
    {
        var cat = _mapper.Map<Product>(Product);
        var result = await _databaseService.AddProduct(cat);
        return result;
    }
    [Route("AddProducts")]
    [HttpPost]

    public async Task<int> AddProducts(IEnumerable<ProductViewModel> ProductViewModels)
    {
        var newProduct = _mapper.Map<IEnumerable<Product>>(ProductViewModels);
        var res = await _databaseService.AddProducts(newProduct);
        return res;
    }

    [Route("UpdateProducts")]
    [HttpPost]
    public async Task<int> UdpateProducts(IEnumerable<ProductViewModelWithId> ProductViewModels)
    {
        var ca = _mapper.Map<IEnumerable<Product>>(ProductViewModels);
        var res = await _databaseService.UpdateProducts(ca);
        return res;
    }
    [Route("UpdateCateogory")]
    [HttpPost]

    public async Task<int> UpdateProduct(ProductViewModelWithId Product)
    {
        var cat = _mapper.Map<Product>(Product);
        return await _databaseService.UpdateProduct(cat);
    }

    [Route("RemoveProduct")]
    [HttpPost]

    public async Task<int> RemoveProduct(ProductViewModelWithId Product)
    {
        var cat = _mapper.Map<Product>(Product);
        return await _databaseService.RemoveProduct(cat);
    }

    [Route("RemoveProducts")]
    [HttpPost]

    public async Task<int> RemoveProducts(IEnumerable<ProductViewModelWithId> ProductViewModelWithIds)
    {
        var cat = _mapper.Map<IEnumerable<Product>>(ProductViewModelWithIds);
        return await _databaseService.RemoveProducts(cat);
    }
}


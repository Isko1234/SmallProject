using Microsoft.AspNetCore.Mvc;
using SmallProject.DAL.Models;
using SmallProject.DAL.DbService;
using AutoMapper;
using SmallProject.DAL.ViewModels;
using SmallProject.DAL.ViewModelsWithId;

namespace SmallProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductOrderController : Controller
{
    private readonly DbService _databaseService;
    private readonly IMapper _mapper;

    public ProductOrderController(DatabaseContext databaseService, IMapper mapper)
    {
        _databaseService = new DbService(databaseService);
        _mapper = mapper;
    }

    [Route("GetProductOrder")]
    [HttpGet]

    public async Task<IEnumerable<ProductOrder>> GetCategories()
    {
        return await _databaseService.GetProductOrders();
    }

    [Route("GetProductOrderByName/{id}")]
    [HttpGet]

    public async Task<ProductOrder> GetCategoriesByOrderId(int id)
    {
        return await _databaseService.GetProductOrderByOrderId(id);
    }

    [Route("GetProductOrderById/{id}")]
    [HttpGet]

    public async Task<ProductOrder> GetProductOrderByProductId(int id)
    {
        return await _databaseService.GetProductOrderByProductId(id);
    }

    [Route("AddProductOrder")]
    [HttpPost]
    public async Task<int> AddProductOrder(ProductOrderViewModel ProductOrder)
    {
        var cat = _mapper.Map<ProductOrder>(ProductOrder);
        var result = await _databaseService.AddProductOrder(cat);
        return result;
    }
    [Route("AddProductOrders")]
    [HttpPost]

    public async Task<int> AddProductOrders(IEnumerable<ProductOrderViewModel> ProductOrderViewModels)
    {
        var newProductOrder = _mapper.Map<IEnumerable<ProductOrder>>(ProductOrderViewModels);
        var res = await _databaseService.AddProductOrders(newProductOrder);
        return res;
    }

    [Route("UpdateProductOrders")]
    [HttpPost]
    public async Task<int> UdpateProductOrders(IEnumerable<ProductOrderViewModelWithId> ProductOrderViewModels)
    {
        var ca = _mapper.Map<IEnumerable<ProductOrder>>(ProductOrderViewModels);
        var res = await _databaseService.UpdateProductOrders(ca);
        return res;
    }
    [Route("UpdateCateogory")]
    [HttpPost]

    public async Task<int> UpdateProductOrder(ProductOrderViewModelWithId ProductOrder)
    {
        var cat = _mapper.Map<ProductOrder>(ProductOrder);
        return await _databaseService.UpdateProductOrder(cat);
    }

    [Route("RemoveProductOrder")]
    [HttpPost]

    public async Task<int> RemoveCategoryProductOrder(ProductOrderViewModelWithId ProductOrder)
    {
        var cat = _mapper.Map<ProductOrder>(ProductOrder);
        return await _databaseService.RemoveProductOrder(cat);
    }

    [Route("RemoveProductOrders")]
    [HttpPost]

    public async Task<int> RemoveProductOrders(IEnumerable<ProductOrderViewModelWithId> ProductOrderViewModelWithIds)
    {
        var cat = _mapper.Map<IEnumerable<ProductOrder>>(ProductOrderViewModelWithIds);
        return await _databaseService.RemoveProductOrders(cat);
    }
}


using Microsoft.AspNetCore.Mvc;
using SmallProject.DAL.Models;
using SmallProject.DAL.DbService;
using AutoMapper;
using SmallProject.DAL.ViewModels;
using SmallProject.DAL.ViewModelsWithId;

namespace SmallProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly DbService _databaseService;
    private readonly IMapper _mapper;

    public OrderController(DatabaseContext databaseService, IMapper mapper)
    {
        _databaseService = new DbService(databaseService);
        _mapper = mapper;
    }

    [Route("GetOrder")]
    [HttpGet]

    public async Task<IEnumerable<Order>> GetCategories()
    {
        return await _databaseService.GetOrders();
    }

    [Route("GetOrderByName/{price}")]
    [HttpGet]

    public async Task<IEnumerable<Order>> GetCategoriesByPrice(int price)
    {
        return await _databaseService.GetOrdersByOverAllPrice(price);
    }

    [Route("GetOrderById/{id}")]
    [HttpGet]

    public async Task<Order> GetOrderById(int id)
    {
        return await _databaseService.GetOrderById(id);
    }

    [Route("AddOrder")]
    [HttpPost]
    public async Task<int> AddOrder(OrderViewModel Order)
    {
        var cat = _mapper.Map<Order>(Order);
        var result = await _databaseService.AddOrder(cat);
        return result;
    }
    [Route("AddOrders")]
    [HttpPost]

    public async Task<int> AddOrders(IEnumerable<OrderViewModel> OrderViewModels)
    {
        var newOrder = _mapper.Map<IEnumerable<Order>>(OrderViewModels);
        var res = await _databaseService.AddOrders(newOrder);
        return res;
    }

    [Route("UpdateOrders")]
    [HttpPost]
    public async Task<int> UdpateOrders(IEnumerable<OrderViewModelWithId> OrderViewModels)
    {
        var ca = _mapper.Map<IEnumerable<Order>>(OrderViewModels);
        var res = await _databaseService.UpdateOrders(ca);
        return res;
    }
    [Route("UpdateCateogory")]
    [HttpPost]

    public async Task<int> UpdateOrder(OrderViewModelWithId Order)
    {
        var cat = _mapper.Map<Order>(Order);
        return await _databaseService.UpdateOrder(cat);
    }

    [Route("RemoveOrder")]
    [HttpPost]

    public async Task<int> RemoveOrder(OrderViewModelWithId Order)
    {
        var cat = _mapper.Map<Order>(Order);
        return await _databaseService.RemoveOrder(cat);
    }

    [Route("RemoveOrders")]
    [HttpPost]

    public async Task<int> RemoveOrders(IEnumerable<OrderViewModelWithId> OrderViewModelWithIds)
    {
        var cat = _mapper.Map<IEnumerable<Order>>(OrderViewModelWithIds);
        return await _databaseService.RemoveOrders(cat);
    }
}


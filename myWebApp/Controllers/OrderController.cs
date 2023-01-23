using AutoMapper;
using BusinessLayer;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderBL _bl;
        readonly IMapper _mapper;
        public OrderController(IOrderBL bl, IMapper mapper)
        {
            _bl = bl;
            _mapper = mapper;
        }




        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDto)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDto);
            Order Order = await _bl.addOrder(order);
            //return CreatedAtAction(nameof(Get), new { id = Order.OrderId }, Order);
            OrderDTO ordDto = _mapper.Map<Order, OrderDTO>(Order);
            return ordDto;

        }

       

       }
    } 

using AutoMapper;
using Eccommerec_BLL.DTO.Order;
using Eccommerec_BLL.GenericRepository.Interface;
using Eccommerec_BLL.Services.Interface;
using Ecommerece_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<OrderDTO> AddOrder(AddOrderDTO addOrderDTO)
        {
            using var transaction=_uow.BeginTransaction();
            try
            {
                //IEnumerable<Sale> sales=_mapper.Map<IEnumerable<Sale>>(addOrderDTO.addSalesDTOs);
                Order order=_mapper.Map<Order>(addOrderDTO);
                order =await _uow.Repository<Order>().AddAsync(order);
                await _uow.SaveChangesAsync();
                foreach (var item in addOrderDTO.addSalesDTOs)
                {
                    item.OrderId= order.OrderId;
                    Sale sale=_mapper.Map<Sale>(item);  
                    sale=await _uow.Repository<Sale>().AddAsync(sale);
                    await _uow.SaveChangesAsync();
                }
                
                transaction.Commit();
                OrderDTO orderDTO=_mapper.Map<OrderDTO>(order);
                return orderDTO;
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public void DeleteOrder(int id)
        {
            using var transaction = _uow.BeginTransaction();
            try
            {
                _uow.Repository<Order>().DeleteById(id);
                _uow.SaveChangesAsync();
                transaction.Commit();
            }
            catch(Exception ex) {
            
                transaction.Rollback(); 
                throw ex;
            }
        }

        public async Task<OrderDTO> GetOrder(int id)
        {
            Order order=_uow.Repository<Order>().GetById(id);
            OrderDTO orderDTO=_mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task<OrderDTO> GetOrderByCustomerId(int id)
        {
            Order order=_uow.Repository<Order>().GetAll().Where(x=>x.CustomerId==id).Single();
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            IEnumerable<Order> orders=_uow.Repository<Order>().GetAll();
            IEnumerable<OrderDTO> orderDTOs=_mapper.Map<IEnumerable<OrderDTO>>(orders);
            return orderDTOs;
        }
    }
}

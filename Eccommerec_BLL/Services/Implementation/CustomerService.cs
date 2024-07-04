using AutoMapper;
using Eccommerec_BLL.DTO.Order;
using Eccommerec_BLL.DTO.User;
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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;
        public CustomerService(IUnitOfWork uow,IMapper mapper) {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<CustomerDTO> AddCustomer(AddCustomerDTO addCustomerDTO)
        {
            using var transaction=_uow.BeginTransaction();
            try
            {
                Customer customer=_mapper.Map<Customer>(addCustomerDTO);
                customer= await _uow.Repository<Customer>().AddAsync(customer).ConfigureAwait(false);
                await _uow.SaveChangesAsync().ConfigureAwait(false);
                await transaction.CommitAsync();
               CustomerDTO customerDTO =_mapper.Map<CustomerDTO>(customer);
                return customerDTO;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async void DeleteCustomerById(int id)
        {
            using var tranasaction = _uow.BeginTransaction();
            try
            {
                _uow.Repository<Customer>().DeleteById(id);
                await _uow.SaveChangesAsync();
                 tranasaction.Commit();
            }
            catch(Exception ex) 
            {
                tranasaction.Rollback();
                throw ex;
            }
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            
            
                IEnumerable<Customer> customers=_uow.Repository<Customer>().GetAll();
                IEnumerable<CustomerDTO> customerDTO=_mapper.Map<IEnumerable<CustomerDTO>>(customers);
                return customerDTO; 
            
           
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            Customer customer=_uow.Repository<Customer>().GetById(id);
            CustomerDTO customerDTO=_mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }
    }
}

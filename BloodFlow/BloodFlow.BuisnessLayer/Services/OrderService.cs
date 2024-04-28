using AutoMapper;
using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.BuisnessLayer.Validation;
using BloodFlow.DataLayer.Entities;
using BloodFlow.DataLayer.Interfaces;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using BloodFlow.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;           
            _mapper = mapper;
            _orderRepository = _unitOfWork.OrderRepository;
            _donorRepository = _unitOfWork.DonorRepository;
        }

        public async Task AddAsync(OrderModel model)
        {
            OrderValidation.ValidateOrder(model);

            var orderEntity = _mapper.Map<Order>(model);

            await _orderRepository.AddAsync(orderEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddDonorAsync(int donorId, int orderId, int bloodVolume)
        {
            var orderEntity = await _orderRepository.GetByIdWithDetailsAsync(orderId);         

            BaseValidation.IsObjectNull(orderEntity, nameof(orderEntity));

            var existDonor = orderEntity!.DonorOrders?
                .FirstOrDefault(x => x.OrderId == orderId && x.DonorId == donorId);

            if (existDonor == null) 
            {
                var donorEntity = await _donorRepository.GetByIdAsync(donorId);

                BaseValidation.IsObjectNull(donorEntity, nameof(donorEntity));

                orderEntity.DonorOrders!.Add(new DonorOrder() 
                { 
                    Donor = donorEntity!,
                    Order = orderEntity,
                    OrderId = orderId,
                    DonorId = donorId
                });

                _orderRepository.Update(orderEntity);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteAsync(int modelId)
        {
            await _orderRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrderModel>>
                (await _orderRepository.GetAllWithDetailsAsync());
        }

        public async Task<IEnumerable<OrderModel>> GetByFilterAsync(FilterSearchModel filterSearch)
        {
            var orderEntities = await _orderRepository.GetAllWithDetailsAsync();

            var filteredModels = orderEntities
                .Where(oe =>
                (filterSearch.ImportanceId == null || oe.ImportanceId == filterSearch.ImportanceId) &&
                (filterSearch.BloodTypeId == null || oe.BloodTypeId == filterSearch.BloodTypeId));

            return _mapper.Map<IEnumerable<OrderModel>>(filteredModels);
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            var orderEntity = await _orderRepository.GetByIdWithDetailsAsync(id);
            BaseValidation.IsObjectNull(orderEntity, nameof(orderEntity));
            return _mapper.Map<OrderModel>(orderEntity);
        }

        public async Task RemoveDonorAsync(int donorId, int orderId)
        {
            var orderEntity = await _orderRepository.GetByIdWithDetailsAsync(orderId);

            BaseValidation.IsObjectNull(orderEntity, nameof(orderEntity));

            var existDonor = orderEntity!.DonorOrders?
               .FirstOrDefault(x => x.OrderId == orderId && x.DonorId == donorId);

            if(existDonor != null)
            {
                orderEntity.DonorOrders!.Remove(existDonor);

                _orderRepository.Update(orderEntity);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task UpdateAsync(OrderModel model)
        {
            var orderEntity = _mapper.Map<Order>(model);

            _orderRepository.Update(orderEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}

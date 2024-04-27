using AutoMapper;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.Infrastructure.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            //Order map profiles
            CreateMap<Order, OrderModel>()
                .ForMember(om => om.Title, o => o.MapFrom(x => x.Title))
                .ForMember(om => om.Description, o => o.MapFrom(x => x.Description))
                .ForMember(om => om.BloodVolume, o => o.MapFrom(x => x.BloodVolume))
                .ForMember(om => om.ImportanceId, o => o.MapFrom(x => x.Importance.Id))
                .ForMember(om => om.ImportanceName, o => o.MapFrom(x => x.Importance.Name))
                .ForMember(om => om.DonorCenterId, o => o.MapFrom(x => x.DonorCenter.Id))
                .ForMember(om => om.DonorCenterName, o => o.MapFrom(x => x.DonorCenter.Name));

            CreateMap<OrderModel, Order>();
        }
    }
}

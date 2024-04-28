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
            // Order map profiles
            CreateMap<Order, OrderModel>()
                .ForMember(om => om.Title, o => o.MapFrom(x => x.Title))
                .ForMember(om => om.Description, o => o.MapFrom(x => x.Description))
                .ForMember(om => om.BloodVolume, o => o.MapFrom(x => x.BloodVolume))
                .ForMember(om => om.ImportanceId, o => o.MapFrom(x => x.Importance.Id))
                .ForMember(om => om.ImportanceName, o => o.MapFrom(x => x.Importance.Name))
                .ForMember(om => om.DonorCenterId, o => o.MapFrom(x => x.DonorCenter.Id))
                .ForMember(om => om.DonorCenterName, o => o.MapFrom(x => x.DonorCenter.Name))
                .ForMember(om => om.BloodTypeId, o => o.MapFrom(x => x.BloodType.Id))
                .ForMember(om => om.BloodTypeName, o => o.MapFrom(x => x.BloodType.Name));

            CreateMap<OrderModel, Order>();

            // Donor map profiles
            CreateMap<Donor, DonorModel>()
                .ForMember(dm => dm.Name, d => d.MapFrom(x => x.Person.Name))
                .ForMember(dm => dm.Surname, d => d.MapFrom(x => x.Person.Surname))
                .ForMember(dm => dm.DateOfBirthday, d => d.MapFrom(x => x.Person.DateOfBirthday))
                .ForMember(dm => dm.PhotoLink, d => d.MapFrom(x => x.Person.PhotoLink))
                .ForMember(dm => dm.BloodTypeId, d => d.MapFrom(x => x.BloodTypeId))
                .ReverseMap();

            // Contact map profiles
            CreateMap<Contact, ContactModel>()
                .ForMember(cm => cm.ContactId, c => c.MapFrom(x => x.Id))
                .ForMember(cm => cm.ContactValue, c => c.MapFrom(x => x.Name))
                .ReverseMap();

            // Street map profiles
            CreateMap<Street, AddressModel>()
                .ForMember(am => am.StreetId, s => s.MapFrom(x => x.Id))
                .ForMember(am => am.StreetName, s => s.MapFrom(x => x.Name))
                .ForMember(am => am.CityName, s => s.MapFrom(x => x.City.Name))
                .ForPath(am => am.HouseNumber, s =>
                    s.MapFrom(x => string.Join("", x.People!.Where(s => s.StreetId == x.Id).Select(s => s.HouseNumber!.ToString()))));

            CreateMap<AddressModel, Street>()
                .ForMember(s => s.Name, am => am.MapFrom(x => x.StreetName))
                .ForMember(s => s.Id, am => am.MapFrom(x => x.StreetId))
                .ForMember(s => s.CityId, am => am.MapFrom(x => x.CityId));

            CreateMap<Street, StreetModel>()
                .ForMember(sm => sm.StreetId, s => s.MapFrom(x => x.Id))
                .ForMember(sm => sm.StreetName, s => s.MapFrom(x => x.Name));

            CreateMap<StreetModel, Street>();

            // Session mapper profiles
            CreateMap<Session, SessionModel>()
                .ForMember(sm => sm.DonorId, s => s.MapFrom(x => x.Donor.Id))
                .ForMember(sm => sm.DonorCenterId, s => s.MapFrom(x => x.DonorCenter.Id))
                .ForMember(sm => sm.DonorCenterName, s => s.MapFrom(x => x.DonorCenter.Name))
                .ForMember(sm => sm.BloodVolume, s => s.MapFrom(x => x.BloodVolume))
                .ForMember(sm => sm.Date, s => s.MapFrom(x => x.Date))
                .ForMember(sm => sm.StateId, s => s.MapFrom(x => x.State.Id))
                .ForMember(sm => sm.StateName, s => s.MapFrom(x => x.State.Name));

            CreateMap<SessionModel, Session>();
                

            // BloodType mapper profiles
            CreateMap<BloodType, BloodTypeModel>()
                .ForMember(btm => btm.BloodTypeId, bt => bt.MapFrom(x => x.Id))
                .ForMember(btm => btm.BloodTypeName, bt => bt.MapFrom(x => x.Name));

            CreateMap<BloodTypeModel, BloodType>();

            // City mapper profiles
            CreateMap<City, CityModel>()
                .ForMember(cm => cm.CityName, s => s.MapFrom(x => x.Name))
                .ForMember(cm => cm.CityId, s => s.MapFrom(x => x.Id));

            CreateMap<CityModel, City>();

            // Importance mapper profiles
            CreateMap<Importance, ImportanceModel>()
                .ForMember(im => im.ImportanceId, i => i.MapFrom(x => x.Id))
                .ForMember(im => im.ImportanceName, i => i.MapFrom(x => x.Name));

            CreateMap<ImportanceModel, Importance>();

            // State mapper profiles
            CreateMap<State, StateModel>()
                .ReverseMap();

            // DonorCenter mapper profiles
            CreateMap<DonorCenter, DonorCenterModel>()
                .ForMember(dcm => dcm.DonorCenterId, dc => dc.MapFrom(x => x.Id))
                .ForMember(dcm => dcm.DonorCenterName, dc => dc.MapFrom(x => x.Name));

            CreateMap<DonorCenterModel, DonorCenter>()
                .ForMember(dc => dc.Name, dcm => dcm.MapFrom(x => x.DonorCenterName))
                .ForMember(dc => dc.Id, dcm => dcm.MapFrom(x => x.DonorCenterId));

            // States mapper profiles
            CreateMap<State, StateModel>()
                .ForMember(sm => sm.StateId, s => s.MapFrom(x => x.Id))
                .ForMember(sm => sm.StateName, s => s.MapFrom(x => x.Name));

            CreateMap<StateModel, State>()
                .ForMember(s => s.Id, sm => sm.MapFrom(x => x.StateId))
                .ForMember(s => s.Name, sm => sm.MapFrom(x => x.StateName));
        }
    }
}

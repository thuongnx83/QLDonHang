using AutoMapper;
using QLDonHangAPI.Data.DTO;
using QLDonHangAPI.Data.Entities;

namespace QLDonHangAPI.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
             CreateMap<AccountInfo, Accounts>();
            //CreateMap<AddressDTO, Address>();
        }
    }
}

using AutoMapper;
using Purse.BLL.DTO;
using Purse.BLL.DTO.CostItem;
using Purse.BLL.DTO.User;
using Purse.DAL.Models;

namespace Purse.BLL.Mappers
{
    public class DataMapperProfile: Profile
    {
        public DataMapperProfile() 
        {
            MapUsers();
            MapCostItem();
        }

        public void MapUsers()
        {
            CreateMap<NewUserDTO, User>();
            CreateMap<LoginUserDTO, User>();
            CreateMap<User, UserDTO>();
        }

		public void MapCostItem()
		{
			CreateMap<CostItemDTO, CostItem>().ReverseMap();
		}
	}
}

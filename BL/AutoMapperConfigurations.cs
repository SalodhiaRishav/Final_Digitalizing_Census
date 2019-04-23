using System.Collections.Generic;
using AutoMapper;
using DAL.Domain;
using Shared.DTO;


namespace BL
{
    public class AutoMapperConfigurations
    {
        
      
        IMapper Mapper;

        public AutoMapperConfigurations()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<House, HouseDTO>().ReverseMap();
                cfg.CreateMap<HouseMember, HouseMemberDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<UserCurrentRequestStatus, UserCurrentRequestStatusDTO>().ReverseMap();
            });
            Mapper = config.CreateMapper();
          
        }

        public HouseDTO HouseToHouseDTO(House house)
        {
            return Mapper.Map<HouseDTO>(house);
        }



        public List<HouseDTO> HouseListToHouseDTOList(List<House> houses)
        {
            return Mapper.Map<List<HouseDTO>>(houses);
        }

        public HouseMemberDTO HouseMemberToHouseMemberDTO(HouseMember houseMember)
        {
            return Mapper.Map<HouseMemberDTO>(houseMember);
        }

        public UserDTO UserToUserDTO(User user)
        {
            return Mapper.Map<UserDTO>(user);
        }

        public User UserDTOToUser(UserDTO userDTO)
        {
            return Mapper.Map<User>(userDTO);
        }

        public List<UserDTO> UserListToUserDTOList(List<User> users)
        {
            return Mapper.Map<List<UserDTO>>(users);
        }

        public UserCurrentRequestStatusDTO UserCurrentRequestStatusToUserCurrentRequestStatusDTO(UserCurrentRequestStatus userCurrentRequestStatus)
        {
            return Mapper.Map<UserCurrentRequestStatusDTO>(userCurrentRequestStatus);
        }

    }
}

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

        public House HouseDTOToHouse(HouseDTO houseDTO)
        {
            return Mapper.Map<House>(houseDTO);
        }


        public List<House> HouseDTOListToHouseList(List<HouseDTO> houseDTOs)
        {
            return Mapper.Map<List<House>>(houseDTOs);
        }

        public List<HouseDTO> HouseListToHouseDTOList(List<House> houses)
        {
            return Mapper.Map<List<HouseDTO>>(houses);
        }

        public HouseMemberDTO HouseMemberToHouseMemberDTO(HouseMember houseMember)
        {
            return Mapper.Map<HouseMemberDTO>(houseMember);
        }

        public HouseMember HouseMemberDTOToHouseMember(HouseMemberDTO houseMemberDTO)
        {
            return Mapper.Map<HouseMember>(houseMemberDTO);
        }

        public List<HouseMemberDTO> HouseMemberListToHouseMemberDTOList(List<HouseMember> houseMemberList)
        {
            return Mapper.Map<List<HouseMemberDTO>>(houseMemberList);
        }

        public List<HouseMember> HouseMemberDTOListToHouseMemberList(List<HouseMemberDTO> houseMemberDTOList)
        {
            return Mapper.Map<List<HouseMember>>(houseMemberDTOList);
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

        public List<User> UserDTOListToUserList(List<UserDTO> userDTOList)
        {
            return Mapper.Map<List<User>>(userDTOList);
        }

        public UserCurrentRequestStatusDTO UserCurrentRequestStatusToUserCurrentRequestStatusDTO(UserCurrentRequestStatus userCurrentRequestStatus)
        {
            return Mapper.Map<UserCurrentRequestStatusDTO>(userCurrentRequestStatus);
        }

        public UserCurrentRequestStatus UserCurrentRequestStatusDTOToUserCurrentRequestStatus(UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            return Mapper.Map<UserCurrentRequestStatus>(userCurrentRequestStatusDTO);
        }

        public List<UserCurrentRequestStatus> UserCurrentRequestStatusDTOListToUserCurrentRequestStatusList(List<UserCurrentRequestStatusDTO> userCurrentRequestStatusDTOList)
        {
            return Mapper.Map<List<UserCurrentRequestStatus>>(userCurrentRequestStatusDTOList);
        }

        public List<UserCurrentRequestStatusDTO> UserCurrentRequestStatusListToUserCurrentRequestStatusDTOList(List<UserCurrentRequestStatus> userCurrentRequestStatusList)
        {
            return Mapper.Map<List<UserCurrentRequestStatusDTO>>(userCurrentRequestStatusList);
        }

    }
}

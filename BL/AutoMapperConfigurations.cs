﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public HouseMemberDTO HouseMemberToHouseMemberDTO(HouseMember houseMember)
        {
            return Mapper.Map<HouseMemberDTO>(houseMember);
        }

        public UserDTO UserToUserDTO(User user)
        {
            return Mapper.Map<UserDTO>(user);
        }

        public UserCurrentRequestStatusDTO UserCurrentRequestStatusToUserCurrentRequestStatusDTO(UserCurrentRequestStatus userCurrentRequestStatus)
        {
            return Mapper.Map<UserCurrentRequestStatusDTO>(userCurrentRequestStatus);
        }

    }
}
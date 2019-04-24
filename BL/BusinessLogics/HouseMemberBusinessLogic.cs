using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RepositoryInterface;
using Shared.DTO;
using Shared.Interfaces.BusinessLayerInterfaces;
using Shared.MessageFormat;
using DAL.Domain;

namespace BL.BusinessLogics
{
   public class HouseMemberBusinessLogic : IHouseMemberBusinessLayer 
    {
        private AutoMapperConfigurations AutoMapperConfigurations = new AutoMapperConfigurations();
        private IHouseMemberRepository HouseMemberRepository;
        public HouseMemberBusinessLogic(IHouseMemberRepository houseMemberRepository)
        {
            HouseMemberRepository = houseMemberRepository;
        }

        public RequestMessageFormat<HouseMemberDTO> Add(HouseMemberDTO houseMemberDTO)
        {
            throw new NotImplementedException();
        }

        public RequestMessageFormat<HouseMemberDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RequestMessageFormat<List<HouseMemberDTO>> GetAll()
        {
            List<HouseMember> houseMembers = this.HouseMemberRepository.List;
            List<HouseMemberDTO> houseMemberDTOList =this.AutoMapperConfigurations.HouseMemberListToHouseMemberDTOList(houseMembers);
            RequestMessageFormat<List<HouseMemberDTO>> response = new RequestMessageFormat<List<HouseMemberDTO>>();
            if (houseMembers.Count == 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Empty List";
            }
            else
            {
                response.Data = houseMemberDTOList;
                response.Success = true;
                response.Message = "Data fetched successfully";
            }
            return response;
        }

        public RequestMessageFormat<HouseMemberDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestMessageFormat<HouseMemberDTO> Update(HouseMemberDTO houseMemberDTO)
        {
            throw new NotImplementedException();
        }
    }
}

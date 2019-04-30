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
using Shared.CustomExceptions;

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

        private bool CheckEmptyData(HouseMemberDTO houseMemberDTO)
        {
            if (string.IsNullOrWhiteSpace(houseMemberDTO.FirstName)||
                string.IsNullOrWhiteSpace(houseMemberDTO.LastName)
                )
            {
                return true;
            }
            return false;
        }

        public RequestMessageFormat<HouseMemberDTO> Add(HouseMemberDTO houseMemberDTO)
        {
            RequestMessageFormat<HouseMemberDTO> response = new RequestMessageFormat<HouseMemberDTO>();

            try
            {
                houseMemberDTO.CreatedOn = DateTime.Now;
                houseMemberDTO.ModifiedOn = DateTime.Now;


                if (this.CheckEmptyData(houseMemberDTO))
                {
                    response.Message = "Entered Invalid Data";
                    response.Data = null;
                    response.Success = false;
                    return response;
                }

                HouseMember houseMember = this.AutoMapperConfigurations.HouseMemberDTOToHouseMember(houseMemberDTO);


                bool isAdded = this.HouseMemberRepository.Add(houseMember);
                
                

                if (isAdded)
                {
                    response.Message = "Added Successfully";
                    houseMemberDTO.ID = houseMember.ID;

                    response.Data = houseMemberDTO;
                    response.Success = true;
                    return response;
                }
            }
            catch(Exception)
            {
                response.Message = "Some Error Occurred while adding data please try again";
                response.Data = null;
                response.Success = false;
                return response;
            }
            return response;

        }

        public RequestMessageFormat<HouseMemberDTO> Delete(int id)
        {
            RequestMessageFormat<HouseMemberDTO> response = new RequestMessageFormat<HouseMemberDTO>();
            try
            {
                HouseMember houseMember = this.HouseMemberRepository.FindById(id);


                if (houseMember == null)
                {
                    response.Message = "HouseMember Not Exist";
                    response.Success = false;
                    response.Data = null;
                    return response;
                }
                else
                {


                    bool isDeleted = this.HouseMemberRepository.Delete(houseMember);
                    
                  

                    if (isDeleted)
                    {
                        response.Message = "Deleted Successfully";
                        response.Success = true;
                        response.Data = null;
                        return response;
                    }
                   
                }
            }catch(Exception)
            {
                response.Message = "Some Error Occurred while deleting data. Please try again";
                response.Success = false;
                response.Data = null;
                return response;
            }

            return response;
        }

        public RequestMessageFormat<List<HouseMemberDTO>> GetAll()
        {
            RequestMessageFormat<List<HouseMemberDTO>> response = new RequestMessageFormat<List<HouseMemberDTO>>();
            try
            {
                List<HouseMember> houseMembers = this.HouseMemberRepository.List;
                List<HouseMemberDTO> houseMemberDTOList = this.AutoMapperConfigurations.HouseMemberListToHouseMemberDTOList(houseMembers);
                if (houseMembers.Count == 0)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Empty List";
                    return response;
                }
                else
                {
                    response.Data = houseMemberDTOList;
                    response.Success = true;
                    response.Message = "Data fetched successfully";
                    return response;
                }
            }
            catch(Exception)
            {
                response.Message = "Some Error Occurred while deleting data. Please try again";
                response.Success = false;
                response.Data = null;
                return response;
            }
        }

        public RequestMessageFormat<HouseMemberDTO> GetById(int id)
        {

            RequestMessageFormat<HouseMemberDTO> response = new RequestMessageFormat<HouseMemberDTO>();

            try
            {
                HouseMember houseMember = this.HouseMemberRepository.FindById(id);
                HouseMemberDTO houseMemberDTO = this.AutoMapperConfigurations.HouseMemberToHouseMemberDTO(houseMember);
                if (houseMember == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "House Member Not Found";
                    return response;
                }
                else
                {
                    response.Data = houseMemberDTO;
                    response.Success = true;
                    response.Message = "Data fetched successfully";
                    return response;
                }
            }
            catch (Exception)
            {
                response.Message = "Some Error Occurred while deleting data. Please try again";
                response.Success = false;
                response.Data = null;
                return response;
            }
        }

        public RequestMessageFormat<HouseMemberDTO> Update(HouseMemberDTO houseMemberDTO)
        {
            throw new NotImplementedException();
        }
    }
}

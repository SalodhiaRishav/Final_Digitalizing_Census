using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces.BusinessLayerInterfaces;
using DAL.RepositoryInterface;
using Shared.DTO;
using Shared.MessageFormat;
using DAL.Domain;
using Shared.Enums;

namespace BL.BusinessLogics
{
    public class UserCurrentRequestStatusBusinessLogic : IUserCurrentRequestStatusBusinessLayer
    {
        AutoMapperConfigurations AutoMapperConfigurations;
        private IUserCurrentRequestStatusRepository UserCurrentRequestStatusRepository;
        public UserCurrentRequestStatusBusinessLogic(IUserCurrentRequestStatusRepository userCurrentRequestStatusRepository)
        {
            UserCurrentRequestStatusRepository = userCurrentRequestStatusRepository;
            AutoMapperConfigurations = new AutoMapperConfigurations();
        }

        public RequestMessageFormat<UserCurrentRequestStatusDTO> Add(UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();
            try
            {


                userCurrentRequestStatusDTO.CreatedOn = DateTime.Now;
                userCurrentRequestStatusDTO.ModifiedOn = DateTime.Now;
                UserCurrentRequestStatus userCurrentRequestStatus = this.AutoMapperConfigurations.UserCurrentRequestStatusDTOToUserCurrentRequestStatus(userCurrentRequestStatusDTO);
                bool isAdded = this.UserCurrentRequestStatusRepository.Add(userCurrentRequestStatus);

                if (isAdded)
                {
                    response.Message = "Added Successfully";
                    userCurrentRequestStatusDTO.ID = userCurrentRequestStatus.ID;

                    response.Data = userCurrentRequestStatusDTO;
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

        public RequestMessageFormat<UserCurrentRequestStatusDTO> Delete(int id)
        {
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();

            try
            {
                UserCurrentRequestStatus userCurrentRequestStatus = this.UserCurrentRequestStatusRepository.FindById(id);


                if (userCurrentRequestStatus == null)
                {
                    response.Message = "House Not Exist";
                    response.Success = false;
                    response.Data = null;
                    return response;
                }
                else
                {
                    bool isDeleted = this.UserCurrentRequestStatusRepository.Delete(userCurrentRequestStatus);
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

        public RequestMessageFormat<List<UserCurrentRequestStatusDTO>> GetAll()
        {
            RequestMessageFormat<List<UserCurrentRequestStatusDTO>> response = new RequestMessageFormat<List<UserCurrentRequestStatusDTO>>();
            try
            {
                List<UserCurrentRequestStatus> userCurrentRequestStatusList = this.UserCurrentRequestStatusRepository.List;
                List<UserCurrentRequestStatusDTO> userCurrentRequestStatusDTOList = this.AutoMapperConfigurations.UserCurrentRequestStatusListToUserCurrentRequestStatusDTOList(userCurrentRequestStatusList);

                if (userCurrentRequestStatusList.Count == 0)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Empty List";
                    return response;
                }
                else
                {
                    response.Data = userCurrentRequestStatusDTOList;
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
        //public RequestMessageFormat<List<UserCurrentRequestStatusDTO>> GetByStatus(string status)
        //{
        //    List<UserCurrentRequestStatus> userCurrentRequestStatusList = new List<UserCurrentRequestStatus>();  
        //        if(status=="declined")
        //        {
        //        userCurrentRequestStatusList = this.UserCurrentRequestStatusRepository.List.Find((item) => item.UserRequestType == UserRequestStatusType.Pending);
        //    }
        //    else if(status=="pending")
        //        {

        //        }if(status=="approved")
        //        {

        //        }
               
        //    List<UserCurrentRequestStatusDTO> userCurrentRequestStatusDTOList = this.AutoMapperConfigurations.UserCurrentRequestStatusListToUserCurrentRequestStatusDTOList(userCurrentRequestStatusList);
        //    RequestMessageFormat<List<UserCurrentRequestStatusDTO>> response = new RequestMessageFormat<List<UserCurrentRequestStatusDTO>>();
        //    if (userCurrentRequestStatusList.Count == 0)
        //    {
        //        response.Data = null;
        //        response.Success = false;
        //        response.Message = "Empty List";
        //    }
        //    else
        //    {
        //        response.Data = userCurrentRequestStatusDTOList;
        //        response.Success = true;
        //        response.Message = "Data fetched successfully";
        //    }
        //    return response;
        //}

        public RequestMessageFormat<UserCurrentRequestStatusDTO> GetById(int id)
        {
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();
            try
            {
                UserCurrentRequestStatus userCurrentRequestStatus = this.UserCurrentRequestStatusRepository.FindById(id);
                UserCurrentRequestStatusDTO userCurrentRequestStatusDTO = this.AutoMapperConfigurations.UserCurrentRequestStatusToUserCurrentRequestStatusDTO(userCurrentRequestStatus);

                if (userCurrentRequestStatus == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "House Not Found";
                    return response;
                }
                else
                {
                    response.Data = userCurrentRequestStatusDTO;
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

        public RequestMessageFormat<UserCurrentRequestStatusDTO> Update(UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();
            try
            {
                userCurrentRequestStatusDTO.ModifiedOn = DateTime.Now;
                UserCurrentRequestStatus userCurrentRequestStatus = this.AutoMapperConfigurations.UserCurrentRequestStatusDTOToUserCurrentRequestStatus(userCurrentRequestStatusDTO);

                bool isUpdated = this.UserCurrentRequestStatusRepository.Update(userCurrentRequestStatus);
                if (isUpdated)
                {
                    response.Message = "Updated Successfully";
                    response.Data = userCurrentRequestStatusDTO;
                    response.Success = true;
                    return response;
                }
              
            }
            catch(Exception)
            {

                response.Message = "Some Error Occurred";
                response.Success = false;
                response.Data = null;
                return response;
            }
            return response;


          
        }
    }
}

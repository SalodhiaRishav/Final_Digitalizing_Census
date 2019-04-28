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
            userCurrentRequestStatusDTO.CreatedOn = DateTime.Now;
            userCurrentRequestStatusDTO.ModifiedOn = DateTime.Now;

            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();

            //if (this.CheckEmptyData(houseDTO))
            //{
            //    response.Message = "Entered Invalid Data";
            //    response.Data = null;
            //    response.Success = false;
            //    return response;
            //}

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
            else
            {
                response.Message = "Some Error Occurred while adding data please try again";
                response.Data = null;
                response.Success = true;
                return response;
            }
        }

        public RequestMessageFormat<UserCurrentRequestStatusDTO> Delete(int id)
        {
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();
            UserCurrentRequestStatus userCurrentRequestStatus = this.UserCurrentRequestStatusRepository.FindById(id);


            if (userCurrentRequestStatus == null)
            {
                response.Message = "House Not Exist";
                response.Success = false;
                response.Data = null;
            }
            else
            {
                bool isDeleted = this.UserCurrentRequestStatusRepository.Delete(userCurrentRequestStatus);
                if (isDeleted)
                {
                    response.Message = "Deleted Successfully";
                    response.Success = true;
                    response.Data = null;
                }
                else
                {
                    response.Message = "Some Error Occurred while deleting data. Please try again";
                    response.Success = false;
                    response.Data = null;
                }
            }

            return response;
        }

        public RequestMessageFormat<List<UserCurrentRequestStatusDTO>> GetAll()
        {
            List<UserCurrentRequestStatus> userCurrentRequestStatusList = this.UserCurrentRequestStatusRepository.List;
            List<UserCurrentRequestStatusDTO> userCurrentRequestStatusDTOList = this.AutoMapperConfigurations.UserCurrentRequestStatusListToUserCurrentRequestStatusDTOList(userCurrentRequestStatusList);
            RequestMessageFormat<List<UserCurrentRequestStatusDTO>> response = new RequestMessageFormat<List<UserCurrentRequestStatusDTO>>();
            if (userCurrentRequestStatusList.Count == 0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Empty List";
            }
            else
            {
                response.Data = userCurrentRequestStatusDTOList;
                response.Success = true;
                response.Message = "Data fetched successfully";
            }
            return response;
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
            UserCurrentRequestStatus userCurrentRequestStatus = this.UserCurrentRequestStatusRepository.FindById(id);
            UserCurrentRequestStatusDTO userCurrentRequestStatusDTO = this.AutoMapperConfigurations.UserCurrentRequestStatusToUserCurrentRequestStatusDTO(userCurrentRequestStatus);
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();
            if (userCurrentRequestStatus == null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "House Not Found";
            }
            else
            {
                response.Data = userCurrentRequestStatusDTO;
                response.Success = true;
                response.Message = "Data fetched successfully";
            }
            return response;
        }

        public RequestMessageFormat<UserCurrentRequestStatusDTO> Update(UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            RequestMessageFormat<UserCurrentRequestStatusDTO> response = new RequestMessageFormat<UserCurrentRequestStatusDTO>();

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
            else
            {
                response.Message = "Some Error Occurred";
                response.Success = false;
                response.Data = null;
                return response;


            }


          
        }
    }
}

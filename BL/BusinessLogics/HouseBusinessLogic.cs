﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces.BusinessLayerInterfaces;
using DAL.Domain;
using Shared.DTO;
using DAL.RepositoryInterface;
using Shared.MessageFormat;
using Shared.CustomExceptions;

namespace BL.BusinessLogics
{
   public class HouseBusinessLogic : IHouseBusinessLayer
    {
        AutoMapperConfigurations AutoMapperConfigurations;
        private IHouseRepository HouseRepository;
        private IHouseMemberRepository HouseMemberRepository;
        public HouseBusinessLogic(IHouseRepository houseRepository,
           IHouseMemberRepository houseMemberRepository)
        {
            HouseRepository = houseRepository;
            HouseMemberRepository = houseMemberRepository;
            AutoMapperConfigurations = new AutoMapperConfigurations();
        }

        private bool CheckEmptyData(HouseDTO houseDTO)
        {
            if (string.IsNullOrWhiteSpace(houseDTO.BuildingNumber)|| string.IsNullOrWhiteSpace(houseDTO.City) || string.IsNullOrWhiteSpace(houseDTO.HeadName) || string.IsNullOrWhiteSpace(houseDTO.State)||string.IsNullOrWhiteSpace(houseDTO.StreetName) )
            {
                return true;
            }
            return false;
        }


        public RequestMessageFormat<HouseDTO> Add(HouseDTO houseDTO)
        {
            RequestMessageFormat<HouseDTO> response = new RequestMessageFormat<HouseDTO>();

            try
            {
                houseDTO.CreatedOn = DateTime.Now;
                houseDTO.ModifiedOn = DateTime.Now;


                if (this.CheckEmptyData(houseDTO))
                {
                    response.Message = "Entered Invalid Data";
                    response.Data = null;
                    response.Success = false;
                    return response;
                }

                House house = this.AutoMapperConfigurations.HouseDTOToHouse(houseDTO);
                bool isAdded = false;

                isAdded = this.HouseRepository.Add(house);



                if (isAdded)
                {
                    response.Message = "Added Successfully";
                    houseDTO.ID = house.ID;
                    response.Data = houseDTO;
                    response.Success = true;

                }
            }
            catch (DatabaseUpdationException)
            {
                response.Message = "Some Error Occurred while adding data please try again";
                response.Data = null;
                response.Success = false;
                return response;

            }
            return response;


        }

        RequestMessageFormat<List<HouseDTO>> IHouseBusinessLayer.GetAll()
        {
         
            RequestMessageFormat<List<HouseDTO>> response = new RequestMessageFormat<List<HouseDTO>>();
            try
            {
                List<House> houses = this.HouseRepository.List;
                List<HouseDTO> houseDTOList = this.AutoMapperConfigurations.HouseListToHouseDTOList(houses);
                if (houses.Count == 0)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Empty List";
                    return response;
                }
                else
                {
                    response.Data = houseDTOList;
                    response.Success = true;
                    response.Message = "Data fetched successfully";
                    return response;
                }
            }
            catch(Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Database Error please try again";
                return response;
            }
           
          
        }

        public RequestMessageFormat<HouseDTO> GetById(int id)
        {
            RequestMessageFormat<HouseDTO> response = new RequestMessageFormat<HouseDTO>();

            try
            {

                House house = this.HouseRepository.FindById(id);
                HouseDTO houseDTO = this.AutoMapperConfigurations.HouseToHouseDTO(house);
                if (house == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "House Not Found";
                    return response;

                }
                else
                {
                    response.Data = houseDTO;
                    response.Success = true;
                    response.Message = "Data fetched successfully";
                    return response;

                }
            }
            catch(Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Database Error please try again";
                return response;
            }
          
        }

        public RequestMessageFormat<HouseDTO> Delete(int id)
        {
            RequestMessageFormat<HouseDTO> response = new RequestMessageFormat<HouseDTO>();
            try
            {
                House house = this.HouseRepository.FindById(id);
                if (house == null)
                {
                    response.Message = "House Not Exist";
                    response.Success = false;
                    response.Data = null;
                }
                else
                {
                    bool isDeleted = this.HouseRepository.Delete(house);
                  
                    if (isDeleted)
                    {
                        response.Message = "Deleted Successfully";
                        response.Success = true;
                        response.Data = null;
                        return response;
                    }

                }
            }
            catch (Exception)
            {

                response.Message = "Some Error Occurred while deleting data. Please try again";
                response.Success = false;
                response.Data = null;
                return response;

            }


            return response;
        }

        public List<int> StatePopulation()
        {
             List<string> StateArray = new List<string>() { "Andaman & Nicobar", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra & Nagar Haveli", "Daman & Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu & Kashmir", "Jharkhand", "Karnataka", "Kerala", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Orissa", "Pondicherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Tripura", "Uttar Pradesh", "Uttaranchal", "West Bengal" };
            List<int> statePopulation = new List<int>();
            foreach(string state in StateArray)
            {

                List<House> houses = this.HouseRepository.Find(house => house.State == state).ToList();
                if (houses.Count == 0)
                {
                    statePopulation.Add(0);

                }
                else
                {
                    int populationCount = 0;
                    foreach (House house in houses)
                    {
                        int counted = this.HouseMemberRepository.Find(houseMember => houseMember.HouseId == house.ID).ToList().Count;
                        populationCount = populationCount + counted;
                    }
                    statePopulation.Add(populationCount);

                  
                }
            }
            return statePopulation;

       
                
        }
        //todo
        public RequestMessageFormat<HouseDTO> Update(HouseDTO houseDTO)
        {
            throw new NotImplementedException();
        }
    }
}

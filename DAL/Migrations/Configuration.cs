using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Domain;
using Shared.Enums;
namespace DAL.Migrations
{
   

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Database.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Database.DatabaseContext context)
        {
            List<User> users = new List<User>()
            { new User
              { Email = "rishav@admin.com", Password = "Lkjh@4321", FirstName = "Rishav", LastName = "Salodhia", ProfileImage = "‪somelink.png", AadharNumber = "123456789012", IsApprover =BooleanType.True,
            CreatedOn=DateTime.Now,
                  ModifiedOn=DateTime.Now},

            new User { Email = "salodhia@admin.com", Password = "Lkjh@4321", FirstName = "Rishav", LastName = "Salodhia", ProfileImage = "‪somelink.png", AadharNumber = "123456789011", IsApprover =BooleanType.True,
            CreatedOn=DateTime.Now,
                  ModifiedOn=DateTime.Now
            },
                };
            users.ForEach(user => context.Users.AddOrUpdate(u=>u.Email,user));
            context.SaveChanges();


            List<House> houses = new List<House>()
          {
              new House
              {
                  BuildingNumber="1010",
                  StreetName="Krishna",
                  City="Gurgaon",
                  State="Haryana",
                  HeadName="Rishav",
                  OwnershipStatus=OwnershipStatusType.Owner,
                  NumberOfRooms=3 ,
                  CreatedOn=DateTime.Now,
                  ModifiedOn=DateTime.Now
                  
              },
              new House
              {
                  BuildingNumber="1011",
                  StreetName="Kapasehra",
                  City="Delhi",
                  State="Delhi",
                  HeadName="Salodhia",
                  OwnershipStatus=OwnershipStatusType.Rented,
                  NumberOfRooms=3,
                  CreatedOn=DateTime.Now,
                  ModifiedOn=DateTime.Now
              },

          };
            houses.ForEach(house => context.Houses.AddOrUpdate(h=>h.ID,house));
            context.SaveChanges();

            List<HouseMember> houseMembers = new List<HouseMember>();



        }
    }
}

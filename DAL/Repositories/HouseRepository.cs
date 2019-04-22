using DAL.Domain;
using DAL.RepositoryInterface;
using Shared.Interfaces;


namespace DAL.Repositories
{
   public class HouseRepository : RepositoryBaseClass<House>,IHouseRepository
    {
        public HouseRepository(IHouseUnitOfWork houseUnitOfWork) : base(houseUnitOfWork)
        {

        }
    }
}

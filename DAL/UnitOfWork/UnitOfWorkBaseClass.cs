using Shared.Interfaces;
using System.Data.Entity;
using DAL.Database;
using System.Data;
using Shared.CustomExceptions;

namespace DAL.UnitOfWork
{
    public class UnitOfWorkBaseClass : IUnitOfWork
    {
        private  DatabaseContext DatabaseContext;
        public UnitOfWorkBaseClass()
        {
            DatabaseContext = new DatabaseContext();
        }

        public DbContext DbContext { get { return DatabaseContext; } }


        public bool Commit()
        {
            try
            {
                int savedChanges = DbContext.SaveChanges();
            }
            catch (DataException)
            {
                throw new DatabaseUpdationException("Error while Updating Data In database");            
            }

            return true;
        }
    }
}

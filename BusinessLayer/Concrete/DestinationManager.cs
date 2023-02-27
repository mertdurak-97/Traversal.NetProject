using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {

        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void Delete(Destination entity)
        {
            _destinationDal.Delete(entity);
        }

        public void Insert(Destination entity)
        {
            _destinationDal.Insert(entity);
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public void Update(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}

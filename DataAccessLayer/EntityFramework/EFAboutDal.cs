using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer;

namespace DataAccessLayer.EntityFramework
{
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}

using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer;

namespace DataAccessLayer.EntityFramework
{
    public class EFFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
    }
}

using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer;

namespace DataAccessLayer.EntityFramework
{
    public class EFFeature2Dal : GenericRepository<Feature2>, IFeature2Dal
    {
    }
}

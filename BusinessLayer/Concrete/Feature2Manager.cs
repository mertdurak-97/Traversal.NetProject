using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class Feature2Manager : IFeature2Service
    {
        IFeature2Dal _feature2Dal;

        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }

        public void Delete(Feature2 entity)
        {
            _feature2Dal.Delete(entity);
        }

        public void Insert(Feature2 entity)
        {
            _feature2Dal.Insert(entity);
        }

        public Feature2 TGetById(int id)
        {
            return _feature2Dal.GetById(id);
        }

        public List<Feature2> TGetList()
        {
            return _feature2Dal.GetList();
        }

        public void Update(Feature2 entity)
        {
            _feature2Dal.Update(entity);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Delete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public void Insert(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public void Update(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}

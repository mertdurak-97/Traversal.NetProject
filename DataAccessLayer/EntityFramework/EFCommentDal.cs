using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination()
        {
            using var c = new AddDbContext();
            return c.Comments.Include(x => x.AppUser).ToList(); //Business'da da aynı şekilde çağırmamız gerekiyor.
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using var c = new AddDbContext();
            return c.Comments.Where(x => x.DestinationID == id).Include(x => x.AppUser).ToList();
        }
    }
}

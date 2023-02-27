using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetListCommentWithDestination(); //Include
        List<Comment> GetListCommentWithDestinationAndUser(int id); //Include
    }
}

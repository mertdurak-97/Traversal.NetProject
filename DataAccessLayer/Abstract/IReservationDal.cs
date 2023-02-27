using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        // Metotları Birleştirmek ve Include yapmak için Dal ve EntityFramework arası yapılır.

        List<Reservation> GetListWithReservationByWaitAprroval(int id); //Rezarvasyonlarla bekleyen rezarvasyonları birleştirme anlamı taşır
        List<Reservation> GetListWithReservationByAccepted(int id); //Rezarvasyonlarla onaylanan rezarvasyonları birleştirme anlamı taşır
        List<Reservation> GetListWithReservationByPrevious(int id); //Rezarvasyonlarla geçmiş rezarvasyonları birleştirme anlamı taşır
        List<Reservation> GetAllApprovalReservations();

        //Son adım gidip EF klasöründe Include yapmak.
    }
}

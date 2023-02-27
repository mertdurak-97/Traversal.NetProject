using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{

    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetAllApprovalReservations()
        {
            using var c = new AddDbContext();
            return c.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor").ToList();
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using var c = new AddDbContext();
            return c.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();

        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using var c = new AddDbContext();
            return c.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezarvasyon" && x.AppUserId == id).ToList();
        }

        public List<Reservation> GetListWithReservationByWaitAprroval(int id)
        {
            using var c = new AddDbContext();
            return c.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
            //Bu metodu şimdi ReservationService de çağırmak için harekete geçeceğiz.
        }
    }
}

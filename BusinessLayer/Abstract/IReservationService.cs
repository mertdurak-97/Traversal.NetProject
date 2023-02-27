using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitAprroval(int id); //Include   
        List<Reservation> GetListWithReservationByAccepted(int id); //Include 
        List<Reservation> GetListWithReservationByPrevious(int id); //Include 
        List<Reservation> GetAllApprovalReservations();
    }
}

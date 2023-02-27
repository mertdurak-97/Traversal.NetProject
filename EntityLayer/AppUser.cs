using Microsoft.AspNetCore.Identity;

namespace EntityLayer
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }

        //F.K
        public List<Reservation> Reservations { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

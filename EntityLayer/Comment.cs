using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentName { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
        public bool CommentState { get; set; }

        //F.K
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}

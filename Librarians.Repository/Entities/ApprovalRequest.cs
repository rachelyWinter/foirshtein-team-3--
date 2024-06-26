using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Librarians.Repository.Entities
{
    public enum Status
    {
        Pending,
        Approved,
        Denied
    }
    public class ApprovalRequest
    {

        [Key]
        public int RequestId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public Status RequestStatus { get; set; } = Status.Pending;
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? ApprovalDate { get; set; }
        public ApprovalRequest() { }
        public ApprovalRequest(int itemId, int userId)
        {
            ItemId = itemId;
            UserId = userId;
        }
    }
}
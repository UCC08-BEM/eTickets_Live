using eTickets_Live.Data.Base;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Models;

namespace eTickets_Live.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}

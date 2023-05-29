using eTickets_Live.Data.Base;
using eTickets_Live.Models;

namespace eTickets_Live.Data.Interfaces
{
    // Aslında kullanılacak metodları içerecek fakat bunları kendi üzerinden değil bir interface üzerinden kullacak...
    public interface ICinemasService : IEntityBaseRepository<Cinema>
    {
    }
}

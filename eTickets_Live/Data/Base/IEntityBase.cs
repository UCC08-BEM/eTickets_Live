namespace eTickets_Live.Data.Base
{
    // Model sınıfların kullanılan en ortak propertyleri ortak bir yerde(interface) toplamak kod sadeliği açısından tavsiye edilir.
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}

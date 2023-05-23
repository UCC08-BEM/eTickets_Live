namespace eTickets_Live.Data.Enums
{
    public enum MovieCategory
    {
        // "Özel" bir sınıf. Sabit durumda olan verilerin tutulacağı bir sınıf.
        // Normalde index yapısında 0. index ile başlar. Fakat bunu db tarafında kullanacağım için
        // 0 dan farklı bir index numarasıyla başlatabiliyorum. Diğer sabitlerde indexlerini otomatik olarak 
        // ayarlıyorlar.
        Aksiyon = 1,
        Komedi,
        Dram,
        Belgesel,
        Animasyon,
        Korku


    }
}

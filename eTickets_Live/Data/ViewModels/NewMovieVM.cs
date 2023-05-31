using eTickets_Live.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets_Live.Data.ViewModels
{
    // Aynı Movie model gibi Details ViewInda kullanabilmek için ayrı bir class olarak yaratılıyor.
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage ="Film adı bilgisi gereklidir...")]
        public string Name { get; set; }

        [Display(Name = "Film Açıklaması")]
        [Required(ErrorMessage = "Film açıklama bilgisi gereklidir...")]
        public string Description { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Fiyat bilgisi gereklidir...")]
        public double? Price { get; set; }

        [Display(Name = "Film Posteri")]
        [Required(ErrorMessage = "Film poster bilgisi gereklidir...")]
        public string ImageURL { get; set; }

        [Display(Name = "Film Vizyon Başlangıç Tarihi")]
        [Required(ErrorMessage = "Film vizyon başlangıç tarih bilgisi gereklidir...")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Film Vizyon Bitiş Tarihi")]
        [Required(ErrorMessage = "Film vizyon bitiş tarih bilgisi gereklidir...")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Film Kategorisi")]
        [Required(ErrorMessage = "Film kategori bilgisi gereklidir...")]
        public MovieCategory MovieCategory { get; set; }

        // Relationships
        [Display(Name = "Aktör seçiniz :")]
        [Required(ErrorMessage = "Aktör bilgisi gereklidir...")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Sinema seçiniz :")]
        [Required(ErrorMessage = "Sinema bilgisi gereklidir...")]
        public int CinemaId { get; set; }

        [Display(Name = "Yapımcı seçiniz :")]
        [Required(ErrorMessage = "Yapımcı bilgisi gereklidir...")]
        public int ProducerId { get; set; }






    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models.ViewModels
{
    public class BooksViewModel
    {
        [Key]
        public long BookID { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Tên sách")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Giá")]
        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a genre")]
        [Display(Name = "Thể loại")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "hãy chọn một bức hình")]
        [Display(Name = "Hình ảnh sách")]
        public IFormFile ImageBook{ get; set; }
    }
}

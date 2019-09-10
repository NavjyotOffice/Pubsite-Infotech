using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models
{
    public enum NewsType { Featured, Trending }
    public class News
    {
        public int NewsID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        [Display(Name = "News Date")]
        public DateTime? NewsDate { get; set; }

        public int? ContentID { get; set; }

        public virtual ContentDetail ContentDetail { get; set; }

        [Required]
        [Display(Name ="News Type")]
        public string NewsType
        {
            get
            {
                return this.N_Type.ToString();
            }
            set
            {
                N_Type = value.ParseEnum<NewsType>();
            }
        }

        [NotMapped]
        [Required]
        [Display(Name = "News Type")]
        public NewsType? N_Type { get; set; }
    }

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.ViewModel
{
    public class NewsViewModel
    {
        public int NewsID { get; set; }
        public string NewsType { get; set; }
        public DateTime? NewsDate { get; set; }
        public int ContentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Author { get; set; }
        public string URL { get; set; }
        public string CompanyName { get; set; }
        public bool HideOnSite { get; set; }
        public IFormFile Upload { get; set; }
    }
}

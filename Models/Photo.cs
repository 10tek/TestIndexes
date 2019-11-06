using System;
using System.Collections.Generic;
using System.Text;

namespace IndexTests.Models
{
    public class Photo : Entity
    {
        public DateTime? PhotographDateTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsDeleted { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string PhoneModel { get; set; }
    }
}

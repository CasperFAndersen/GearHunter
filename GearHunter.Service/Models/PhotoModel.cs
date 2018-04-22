using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GearHunter.Service.Models
{
    public class PhotoModel
    {
        //public int Id { get; set; }
        [Required]
        public string Filename { get; set; }


        public PhotoModel()
        {

        }

        public PhotoModel(Photo photo)
        {
            if (photo == null)
            {
                return;
            }

            Filename = photo.Filename;
        }

        public Photo ToPhoto()
        {
            return new Photo
            {
                Filename = Filename
            };
        }
    }
}
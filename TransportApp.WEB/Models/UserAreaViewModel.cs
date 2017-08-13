using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.WEB.Models
{
    public class UserRegDataViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "BizNameRequired")]
        [Display(Name = "BizNameDisplay", ResourceType = typeof(Resources.Resource))]
        public string BizName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "BizUniqueNumberRequired")]
        [Display(Name = "BizUniqueNumberDisplay", ResourceType = typeof(Resources.Resource))]
        [StringLength(9, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "BizUniqueNumberValidation", MinimumLength = 9)]
        public string BizUniqueNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "CountryNameRequired")]
        [Display(Name = "CountryNameDisplay", ResourceType = typeof(Resources.Resource))]
        public string CountryName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "RegionNameRequired")]
        [Display(Name = "RegionNameDisplay", ResourceType = typeof(Resources.Resource))]
        public string RegionName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "CityNameRequired")]
        [Display(Name = "CityNameDisplay", ResourceType = typeof(Resources.Resource))]
        public string CityName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "AddressRequired")]
        [Display(Name = "AddressDisplay", ResourceType = typeof(Resources.Resource))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "BizStatusRequired")]
        [Display(Name = "BizStatusDisplay", ResourceType = typeof(Resources.Resource))]
        public string BizStatus { get; set; }

        [Display(Name = "BizDescriptionDisplay", ResourceType = typeof(Resources.Resource))]
        public string BizDescription { get; set; }
    }
}
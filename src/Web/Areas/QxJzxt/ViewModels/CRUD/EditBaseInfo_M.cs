using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditBaseInfo_M
    {
        public List<SelectListItem> typeList;

        [StringLength(50)]
        public string baseinfoid { get; set; }

        [StringLength(100)]
        [Display(Name = "信息项名称")]
        [Required]
        public string infoname { get; set; }

        [StringLength(50)]
        [Display(Name = "信息项类型")]
        public string infodatatype { get; set; }

        public static EditBaseInfo_M ToViewModel(award_baseInfo baseInfo,List<SelectListItem>typeList )
        {
            return new EditBaseInfo_M()
            {
                typeList= typeList,
                baseinfoid = baseInfo.baseinfoid,
                infoname = baseInfo.infoname,         
                infodatatype = baseInfo.infodatatype
            };
        }

        public award_baseInfo ToModel(string baseinfoid)
        {
            return new award_baseInfo()
            {
                baseinfoid = baseinfoid,
                infoname = infoname,
                infodatatype = infodatatype
            };
        }
    }
}
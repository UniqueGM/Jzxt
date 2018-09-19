using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class Relation_Org_UserAdd_M
    {
        public static user_position ToModel(string random, string orgnization_position_id, string user_id)
        {
            return new user_position
            {
                user_position_id= random,
                orgnization_position_id= orgnization_position_id,
                user_id= user_id
            };
        }
        public static Relation_Org_UserAdd_M ToViewModel(orgnization org)
        {
            return new Relation_Org_UserAdd_M
            {

            };
        }
        [Key]
        [Display(Name = "ID")]
        [StringLength(100)]
        public string user_position_id { get; set; }
        [Display(Name = "组织机构职位关系编号")]
        [StringLength(100)]
        public string orgnization_position_id { get; set; }
        [Display(Name = "用户编号")]
        [StringLength(100)]
        public string user_id { get; set; }
    }
}
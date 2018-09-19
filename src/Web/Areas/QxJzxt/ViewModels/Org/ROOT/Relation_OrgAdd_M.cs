using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class Relation_OrgAdd_M
    {
        public static organization_relation ToModel(string random, string orgnization_id, string other_orgnization_id)
        {
            return new organization_relation
            {
                organization_relation_id = random,
                orgnization_id = orgnization_id,
                other_orgnization_id = other_orgnization_id,
            };
        }
        public static Relation_OrgAdd_M ToViewModel(orgnization org)
        {
            return new Relation_OrgAdd_M
            {
                
            };
        }
        [Key]
        [Display(Name = "组织机构间的关系编号")]
        [StringLength(100)]
        public string organization_relation_id { get; set; }
        [Display(Name = "组织机构编号")]
        [StringLength(100)]
        public string orgnization_id { get; set; }
        [Display(Name = "关联的组织机构编号")]
        [StringLength(100)]
        public string other_orgnization_id { get; set; }
    }
}
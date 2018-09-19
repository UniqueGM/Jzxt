using Qx.Jzxt.Configs;

namespace Qx.Jzxt.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base((string)Setting.ConnectionString)
        {
        }

        public virtual DbSet<apply_status> apply_status { get; set; }
        public virtual DbSet<award_apply> award_apply { get; set; }
        public virtual DbSet<award_apply_extension> award_apply_extension { get; set; }
        public virtual DbSet<award_baseInfo> award_baseInfo { get; set; }
        public virtual DbSet<award_batch> award_batch { get; set; }
        public virtual DbSet<award_batch_instance> award_batch_instance { get; set; }
        public virtual DbSet<award_instance> award_instance { get; set; }
        public virtual DbSet<award_instance_baseInfo> award_instance_baseInfo { get; set; }
        public virtual DbSet<award_instance_value> award_instance_value { get; set; }
        public virtual DbSet<award_materia_instance> award_materia_instance { get; set; }
        public virtual DbSet<award_material> award_material { get; set; }
        public virtual DbSet<award_type> award_type { get; set; }
        public virtual DbSet<award_type_baseInfo> award_type_baseInfo { get; set; }
        public virtual DbSet<button> button { get; set; }
        public virtual DbSet<material_attrs> material_attrs { get; set; }
        public virtual DbSet<material_type> material_type { get; set; }
        public virtual DbSet<material_type_attrs> material_type_attrs { get; set; }
        public virtual DbSet<material_values> material_values { get; set; }
        public virtual DbSet<menu> menu { get; set; }
        public virtual DbSet<org> org { get; set; }
        public virtual DbSet<org_award_instance> org_award_instance { get; set; }
        public virtual DbSet<organization_level> organization_level { get; set; }
        public virtual DbSet<organization_relation> organization_relation { get; set; }
        public virtual DbSet<orgnization> orgnization { get; set; }
        public virtual DbSet<orgnization_position> orgnization_position { get; set; }
        public virtual DbSet<orgnization_type> orgnization_type { get; set; }
        public virtual DbSet<permission_user> permission_user { get; set; }
        public virtual DbSet<position> position { get; set; }
        public virtual DbSet<position_type> position_type { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<role_button_forbid> role_button_forbid { get; set; }
        public virtual DbSet<role_group> role_group { get; set; }
        public virtual DbSet<role_group_relation> role_group_relation { get; set; }
        public virtual DbSet<role_menu> role_menu { get; set; }
        public virtual DbSet<user_apply_material> user_apply_material { get; set; }
        public virtual DbSet<user_group> user_group { get; set; }
        public virtual DbSet<user_group_relation> user_group_relation { get; set; }
        public virtual DbSet<user_group_role_group_relation> user_group_role_group_relation { get; set; }
        public virtual DbSet<user_group_role_relation> user_group_role_relation { get; set; }
        public virtual DbSet<user_material> user_material { get; set; }
        public virtual DbSet<user_material_status> user_material_status { get; set; }
        public virtual DbSet<user_orgnization> user_orgnization { get; set; }
        public virtual DbSet<user_position> user_position { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }
        public virtual DbSet<user_type> user_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<apply_status>()
                .Property(e => e.statusname)
                .IsUnicode(false);

            modelBuilder.Entity<apply_status>()
                .HasMany(e => e.award_apply)
                .WithOptional(e => e.apply_status)
                .WillCascadeOnDelete();

            modelBuilder.Entity<award_apply>()
                .Property(e => e.applyid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.batchinstanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.college_opinion)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.school_opinion)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.college_examine_person)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply>()
                .Property(e => e.school_examine_person)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply_extension>()
                .Property(e => e.award_apply_extension_id)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply_extension>()
                .Property(e => e.applyid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply_extension>()
                .Property(e => e.old_instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply_extension>()
                .Property(e => e.now_instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_apply_extension>()
                .Property(e => e.revise_user)
                .IsUnicode(false);

            modelBuilder.Entity<award_baseInfo>()
                .Property(e => e.baseinfoid)
                .IsUnicode(false);

            modelBuilder.Entity<award_baseInfo>()
                .Property(e => e.infoname)
                .IsUnicode(false);

            modelBuilder.Entity<award_baseInfo>()
                .Property(e => e.infodatatype)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch>()
                .Property(e => e.batchid)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch>()
                .Property(e => e.batchname)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch>()
                .Property(e => e.IsCurrentBatch)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch_instance>()
                .Property(e => e.batchinstanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch_instance>()
                .Property(e => e.batchid)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch_instance>()
                .Property(e => e.instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_batch_instance>()
                .HasMany(e => e.award_apply)
                .WithRequired(e => e.award_batch_instance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<award_instance>()
                .Property(e => e.awardtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance>()
                .Property(e => e.instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance>()
                .Property(e => e.instancename)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance>()
                .HasMany(e => e.award_apply)
                .WithRequired(e => e.award_instance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<award_instance>()
                .HasMany(e => e.award_apply_extension)
                .WithRequired(e => e.award_instance)
                .HasForeignKey(e => e.now_instanceid);

            modelBuilder.Entity<award_instance>()
                .HasMany(e => e.award_apply_extension1)
                .WithRequired(e => e.award_instance1)
                .HasForeignKey(e => e.old_instanceid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<award_instance_baseInfo>()
                .Property(e => e.baseInfoid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance_baseInfo>()
                .Property(e => e.instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance_baseInfo>()
                .Property(e => e.instancebaseinfoid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance_value>()
                .Property(e => e.applyid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance_value>()
                .Property(e => e.instancebaseinfoid)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance_value>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<award_instance_value>()
                .Property(e => e.awardinstancevalueid)
                .IsUnicode(false);

            modelBuilder.Entity<award_materia_instance>()
                .Property(e => e.materialtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<award_materia_instance>()
                .Property(e => e.awardmaterialinstanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_materia_instance>()
                .Property(e => e.instanceid)
                .IsUnicode(false);

            modelBuilder.Entity<award_material>()
                .Property(e => e.materialtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<award_material>()
                .Property(e => e.awardtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<award_material>()
                .Property(e => e.awardmaterialid)
                .IsUnicode(false);

            modelBuilder.Entity<award_type>()
                .Property(e => e.awardtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<award_type>()
                .Property(e => e.awardname)
                .IsUnicode(false);

            modelBuilder.Entity<award_type>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<award_type_baseInfo>()
                .Property(e => e.awardtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<award_type_baseInfo>()
                .Property(e => e.baseinfoid)
                .IsUnicode(false);

            modelBuilder.Entity<award_type_baseInfo>()
                .Property(e => e.awardtypebaseinfoid)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.button_id)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<material_attrs>()
                .Property(e => e.materialattrid)
                .IsUnicode(false);

            modelBuilder.Entity<material_attrs>()
                .Property(e => e.attrname)
                .IsUnicode(false);

            modelBuilder.Entity<material_attrs>()
                .Property(e => e.infodatatype)
                .IsUnicode(false);

            modelBuilder.Entity<material_attrs>()
                .HasMany(e => e.material_type_attrs)
                .WithOptional(e => e.material_attrs)
                .WillCascadeOnDelete();

            modelBuilder.Entity<material_type>()
                .Property(e => e.materialtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<material_type>()
                .Property(e => e.typename)
                .IsUnicode(false);

            modelBuilder.Entity<material_type>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<material_type>()
                .HasMany(e => e.material_type_attrs)
                .WithOptional(e => e.material_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<material_type_attrs>()
                .Property(e => e.materialtypeattrid)
                .IsUnicode(false);

            modelBuilder.Entity<material_type_attrs>()
                .Property(e => e.materialattrid)
                .IsUnicode(false);

            modelBuilder.Entity<material_type_attrs>()
                .Property(e => e.materialtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<material_type_attrs>()
                .Property(e => e.attrtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<material_type_attrs>()
                .Property(e => e.defaultvalue)
                .IsUnicode(false);

            modelBuilder.Entity<material_type_attrs>()
                .HasMany(e => e.material_values)
                .WithRequired(e => e.material_type_attrs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<material_values>()
                .Property(e => e.usermaterialid)
                .IsUnicode(false);

            modelBuilder.Entity<material_values>()
                .Property(e => e.materialvalue)
                .IsUnicode(false);

            modelBuilder.Entity<material_values>()
                .Property(e => e.materialtypeattrid)
                .IsUnicode(false);

            modelBuilder.Entity<material_values>()
                .Property(e => e.marterialvaluesid)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.farther_id)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.note)
                .IsFixedLength();

            modelBuilder.Entity<menu>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.depth)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.sub_system)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.controller)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.action)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.image_class)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.active_li)
                .IsUnicode(false);

            modelBuilder.Entity<org>()
                .Property(e => e.orgid)
                .IsUnicode(false);

            modelBuilder.Entity<org>()
                .Property(e => e.orgname)
                .IsUnicode(false);

            modelBuilder.Entity<org>()
                .Property(e => e.fatherorgid)
                .IsUnicode(false);

            modelBuilder.Entity<org>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<org_award_instance>()
                .Property(e => e.orgawardinstanceid)
                .IsUnicode(false);

            modelBuilder.Entity<org_award_instance>()
                .Property(e => e.orgid)
                .IsUnicode(false);

            modelBuilder.Entity<org_award_instance>()
                .Property(e => e.batchinstanceid)
                .IsUnicode(false);

            modelBuilder.Entity<organization_level>()
                .Property(e => e.organization_level_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization_level>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<organization_level>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<organization_level>()
                .HasMany(e => e.orgnization)
                .WithOptional(e => e.organization_level)
                .WillCascadeOnDelete();

            modelBuilder.Entity<organization_relation>()
                .Property(e => e.organization_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization_relation>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization_relation>()
                .Property(e => e.other_orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.descripe)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.orgnization_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.sub_system)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.organization_level_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .HasMany(e => e.org_award_instance)
                .WithRequired(e => e.orgnization)
                .HasForeignKey(e => e.orgid);

            modelBuilder.Entity<orgnization>()
                .HasMany(e => e.organization_relation)
                .WithRequired(e => e.orgnization)
                .HasForeignKey(e => e.orgnization_id);

            modelBuilder.Entity<orgnization>()
                .HasMany(e => e.organization_relation1)
                .WithRequired(e => e.orgnization1)
                .HasForeignKey(e => e.other_orgnization_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<orgnization_position>()
                .Property(e => e.orgnization_position_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_position>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_position>()
                .Property(e => e.position_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_type>()
                .Property(e => e.orgnization_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_type>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.nick_name)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.user_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.user_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.position_id)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.position_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.descripe)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<position_type>()
                .Property(e => e.position_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<position_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<position_type>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.role_type)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.sub_system)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.role_Button_forbid_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.button_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<role_group>()
                .Property(e => e.role_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group>()
                .Property(e => e.role_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<role_group>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_group_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.create_userid)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.create_username)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.create_Date)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.role_menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_apply_material>()
                .Property(e => e.applymaterialid)
                .IsUnicode(false);

            modelBuilder.Entity<user_apply_material>()
                .Property(e => e.applyid)
                .IsUnicode(false);

            modelBuilder.Entity<user_apply_material>()
                .Property(e => e.usermaterialid)
                .IsUnicode(false);

            modelBuilder.Entity<user_group>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group>()
                .Property(e => e.user_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_group>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.user_group_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.nick_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.create_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.create_user_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.create_date)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.user_group_role_group_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.role_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.create_date)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.user_group_role_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.create_date)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .Property(e => e.materialtypeid)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .Property(e => e.usermaterialid)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .Property(e => e.opinion)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .Property(e => e.examine_person)
                .IsUnicode(false);

            modelBuilder.Entity<user_material>()
                .HasMany(e => e.user_apply_material)
                .WithRequired(e => e.user_material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_material_status>()
                .Property(e => e.statusname)
                .IsUnicode(false);

            modelBuilder.Entity<user_material_status>()
                .HasMany(e => e.user_material)
                .WithOptional(e => e.user_material_status)
                .WillCascadeOnDelete();

            modelBuilder.Entity<user_orgnization>()
                .Property(e => e.user_orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_orgnization>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_orgnization>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_position>()
                .Property(e => e.user_position_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_position>()
                .Property(e => e.orgnization_position_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_position>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.user_role_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_type>()
                .Property(e => e.user_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_type>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}

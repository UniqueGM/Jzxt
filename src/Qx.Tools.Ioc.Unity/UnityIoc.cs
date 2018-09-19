using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Qx.Wechat.Entity;
using Qx.Wechat.Repository;
using Qx.Wechat.Interfaces;
using Qx.Wechat.Services;
using Qx.Msg.Interfaces;
using Qx.Msg.Repository;
using Qx.Msg.Services;
using Qx.WorkFlow.Entity;
using Qx.WorkFlow.Interfaces;
using Qx.WorkFlow.Repository;
using Qx.WorkFlow.Services;
using Qx.Account.Interfaces;
using Qx.Account.Services;
using Qx.Order.Entity;
using Qx.Order.Interfaces;
using Qx.Order.Repository;
using Qx.Order.Services;
using Qx.Org.Interfaces;
using Qx.Org.Services;
using Qx.Tools.Interfaces;
using MsgProvider = Qx.Msg.Services.MsgProvider;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Services;
using Qx.Jzxt.Interfaces;
using Qx.Jzxt.Services;
using Qx.Jzxt.Entity;
using Qx.Jzxt.Repository;
using Qx.Tools.Ioc.Unity.Provider;

namespace Qx.Tools.Ioc.Unity
{
    public static class UnityIoc
    {
        public static void Register(List<Type> controllers)
        {
            //Container
            IUnityContainer container = new UnityContainer();
            //Register controllers
            controllers.ForEach(c => container.RegisterType(c));
            //Register Services
            RegisterServices(container);
            //Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        static void RegisterServices(IUnityContainer container)
        {
            
            #region QxJzxt
            container.RegisterType<QxIJzxtService, QxJzxtService>();
            container.RegisterType<IOrgService, OrgService>();
            container.RegisterType<IRepository<Jzxt.Entity.user_position>, Jzxt.Repository.user_positionRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.position_type>, Jzxt.Repository.position_typeRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.position>, Jzxt.Repository.positionRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.orgnization_type>, Jzxt.Repository.orgnization_typeRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.orgnization_position>, Jzxt.Repository.orgnization_positionRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.organization_relation>, Jzxt.Repository.organization_relationRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.organization_level>, Jzxt.Repository.organization_levelRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.orgnization>, Jzxt.Repository.orgnizationRepository>();
            container.RegisterType<IRepository<award_apply>, award_applyRepository>();
            container.RegisterType<IRepository<Jzxt.Entity.org>, orgRepository>();
            container.RegisterType<IRepository<org_award_instance>, org_award_instanceRepository>();
            container.RegisterType<IRepository<material_values>, material_valuesRepository>();
            container.RegisterType<IRepository<user_material>, user_materialRepository>();
            container.RegisterType<IRepository<award_type>, award_typeRepository>();
            container.RegisterType<IRepository<award_baseInfo>, award_baseInfoRepository>();  
            container.RegisterType<IRepository<award_batch>, award_batchRepository>();
            container.RegisterType<IRepository<material_attrs>, material_attrsRepository>();
            container.RegisterType<IRepository<material_type>, material_typeRepository>();
            container.RegisterType<IRepository<award_type_baseInfo>, award_type_baseInfoRepository>();
            container.RegisterType<IRepository<material_type_attrs>, material_type_attrsRepository>();
            container.RegisterType<IRepository<award_material>, award_materialRepository>();
            container.RegisterType<IRepository<award_instance>, award_instanceRepository>();
            container.RegisterType<IRepository<award_batch_instance>, award_batch_instanceRepository>();
            container.RegisterType<IRepository<award_materia_instance>, award_materia_instanceRepository>();
            container.RegisterType<IRepository<award_instance_baseInfo>, award_instance_baseInfoRepository>();
            #endregion
            
            #region Permission Repository
            container.RegisterType<IRepository<qx.permmision.v2.Entity.button>, qx.permmision.v2.Repository.ButtonRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.menu>, qx.permmision.v2.Repository. MenuRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_button_forbid>, qx.permmision.v2.Repository. RoleButtonForbidRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_menu>, qx.permmision.v2.Repository. RoleMenuRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role>, qx.permmision.v2.Repository. RoleRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.permission_user>, qx.permmision.v2.Repository.UserRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_role>, qx.permmision.v2.Repository. UserRoleRepository>();
            container.RegisterType<IPermissionProvider, PermissionProvider>();
            container.RegisterType<IPermmisionService,PermissionServices>();

            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_group>, qx.permmision.v2.Repository.UserGroupRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.user_group_relation>, qx.permmision.v2.Repository.UserGroupRelationRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_group>, qx.permmision.v2.Repository.RoleGroupRepository>();
            container.RegisterType<IRepository<qx.permmision.v2.Entity.role_group_relation>, qx.permmision.v2.Repository.RoleGroupRelationRepository>();
           
           
            #endregion
            
            #region Contents Repository
            container.RegisterType<IRepository<Qx.Contents.Entity.content_column_design>, Qx.Contents.Repository.ContentColumnDesignRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.content_column_value>, Qx.Contents.Repository.ContentColumnValueRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.content_table_design>, Qx.Contents.Repository.ContentTableDesignRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.content_table_query>, Qx.Contents.Repository.ContentTableQueryRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.content_type>, Qx.Contents.Repository.ContentTypeRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.data_type>, Qx.Contents.Repository.DataTypeRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.page_control_type>, Qx.Contents.Repository.PageControlTypeRepository>();
            #endregion

            #region Provider
            //container.RegisterType<IInvoicingProvider, InvoicingProvider>();
            //container.RegisterType<IEmployeeProvider, EmployeeProvider>();
            container.RegisterType<IPermissionProvider, PermissionProvider>();
            // container.RegisterType<IProductProvider, InvoicingProductProvider>();
            container.RegisterType<IAccountProvider, AccountProvider>();
            container.RegisterType<IOrderProvider, OrderProvider>();
            //container.RegisterType<IMemberProvider, MemberProvider>();
            // container.RegisterType<IFastOrg, Qx.Tools.Ioc.Unity.FastCarProvider>();
            container.RegisterType<IOrgProvider, OrgProvider>();




            #endregion

            #region Service
            container.RegisterType<IContents, ContentService>();
            //container.RegisterType<IMemberServices,MemberServices>();
            //container.RegisterType<IInvoicingServices, InvoicingServices>();
            container.RegisterType<IAccountPayService, AccountPayService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IReportServices, ReportServices>();
            //    container.RegisterType<IStockRightServices, StockRightServices>();
            //container.RegisterType<IPermission, PermissionServices>();
            container.RegisterType<IOrg, OrgServices>();
            //container.RegisterType<IProfitServices, ProfitServices>();
            // container.RegisterType<ITaskServices, TaskServices>();


            #endregion

            #region R Provider

            container.RegisterType<IWechatServices, WechatServices>();
            //container.RegisterType<IInvoicingPermissionOrder, InvoicingPermissionOrder>();
            //container.RegisterType<IInvoicingPermission, InvoicingPermission>();

            //container.RegisterType<IRServieces, RServieces>();
            //container.RegisterType<IAccountOrg, AccountOrg>();
            //container.RegisterType<IAccountFastCarOrg, AccountFastCarOrg>();
            //container.RegisterType<IAccountMember, AccountMember>();
            //container.RegisterType<IEmployeeOrg, EmployeeOrg>();
            //container.RegisterType<IVipCardProvider, VipCardProvider>();
            //container.RegisterType<IEmployeePermission, EmployeePermission>();
            //container.RegisterType<IAccountMemberVipCard, AccountMemberVipCard>();
            //container.RegisterType<IAccountInvoicingOrderProduct, AccountInvoicingOrderProduct>();
            //container.RegisterType<IMemberPermission,MemberPermission>();
            //container.RegisterType<IBonusOrg, BonusOrg>();
            //container.RegisterType<IInvoicingOrg, InvoicingOrg>();
            //container.RegisterType<ICreditCardInvoicing, CreditCardInvoicing>();
            //container.RegisterType<IMemberMsg, MemberMsg>();            
            #endregion
            
        }
    }
}

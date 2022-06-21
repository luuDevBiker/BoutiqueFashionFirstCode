using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using Iot.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Implements
{
    public class StatisticalService : IStatisticalService
    {
        private readonly IGenericRepository<Order> _orderService;
        private readonly IGenericRepository<OrderDetails> _orderDetailService;
        private readonly IGenericRepository<ProductVariants> _productVariantService;
        private readonly IGenericRepository<Products> _productService;
        private readonly IGenericRepository<user> _userService;
        private readonly IGenericRepository<RolesUser> _rolesUserService;
        public StatisticalService(IGenericRepository<Order> orderService, IGenericRepository<OrderDetails> orderDetailService, IGenericRepository<user> userService, IGenericRepository<RolesUser> rolesUserService, IGenericRepository<ProductVariants> productVariantService, IGenericRepository<Products> productService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(orderDetailService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _rolesUserService = rolesUserService ?? throw new ArgumentNullException(nameof(rolesUserService));
            _productVariantService = productVariantService ?? throw new ArgumentNullException(nameof(productVariantService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public List<StatisticalProduction> Bestseller(Guid userId)
        {
            if (userId.IsNullOrDefault() || Guid.Equals(userId, Guid.Empty))
                throw new ArgumentNullException("User Id");
            var user = _userService.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(userId) && p.IsUserEnabled.Equals(true));
            if (user.IsNullOrDefault()) throw new ArgumentNullException("user null");
            var checkRoleUser = _rolesUserService.GetAllDataQuery().Where(p => p.RolesID.Equals(user.RolesID)).Select(p => p.RolesName).FirstOrDefault();
            if (checkRoleUser.IsNullOrDefault()) throw new ArgumentNullException("get role user fail");
            if (checkRoleUser.Trim().ToLower() != "admin") throw new ArgumentNullException("non-admin account");
            var lstOrderDetail = _orderDetailService.GetAllDataQuery().Where(p => p.IsOrderDetailEnabled.Equals(true)).ToList();
            var lstProductVariant = _productVariantService.GetAllDataQuery().ToList();
            var lstProduct = _productService.GetAllDataQuery().ToList();
            List<StatisticalProduction> lstStatisticalProduction = new List<StatisticalProduction>();
            var lstOrderDetailDis = lstOrderDetail.DistinctBy(p => p.VariantID).ToList();
            foreach (var item in lstOrderDetailDis)
            {
                StatisticalProduction statisticalProduction = new StatisticalProduction();
                var product = lstProductVariant.FirstOrDefault(p => p.VariantID == item.VariantID);
                statisticalProduction.ProductName = lstProduct.Where(p => p.ProductID == product.ProductID).Select(p => p.ProductName).FirstOrDefault();
                statisticalProduction.Price = product.Price;
                statisticalProduction.QuantitySold = lstOrderDetail.Where(p => p.VariantID == item.VariantID).Select(p => p.Quantity).Sum();
                statisticalProduction.TotalSales = statisticalProduction.Price * statisticalProduction.QuantitySold;
                lstStatisticalProduction.Add(statisticalProduction);
            }
            return lstStatisticalProduction.OrderByDescending(p=>p.TotalSales).ToList();
        }


        public List<StatisticalCustomer> BestCustomer(Guid userId)
        {
            if (userId.IsNullOrDefault() || Guid.Equals(userId, Guid.Empty))
                throw new ArgumentNullException("User Id");
            var user = _userService.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(userId) && p.IsUserEnabled.Equals(true));
            if (user.IsNullOrDefault()) throw new ArgumentNullException("user null");
            var checkRoleUser = _rolesUserService.GetAllDataQuery().Where(p => p.RolesID.Equals(user.RolesID)).Select(p => p.RolesName).FirstOrDefault();
            if (checkRoleUser.IsNullOrDefault()) throw new ArgumentNullException("get role user fail");
            if (!(checkRoleUser.Trim().ToLower() == "admin" || checkRoleUser.Trim().ToLower() == "nhân viên")) throw new ArgumentNullException("non-admin account");
            var lstStatisticalCustomer = new List<StatisticalCustomer>();
            var lstUserOrder = _orderService.GetAllDataQuery().Where(p => p.IsOrderEnabled.Equals(true)).ToList();
            var lstUserOrderDis = lstUserOrder.DistinctBy(p => p.UserID).ToList();
            foreach (var item in lstUserOrderDis)
            {
                var userItem = _userService.GetAllDataQuery().FirstOrDefault(p => p.UserID == item.UserID);
                var total = lstUserOrder.Where(p => p.UserID.Equals(userItem.UserID)).ToList();
              
                var statisticalCustomer = new StatisticalCustomer();
                statisticalCustomer.CustomerName = userItem.UserName;
                statisticalCustomer.QuantityOrder = total.Select(p => p.UserID).Count();
                statisticalCustomer.TotalMoney = total.Sum(p=>p.Payments);
                foreach (var quantity in total)
                {
                   var orderDetail = _orderDetailService.GetAllDataQuery().Where(p=>p.OrderID==quantity.OrderID).Select(p=>p.Quantity).ToList();
                    statisticalCustomer.QuantityProduct += orderDetail.Sum();
                }
                lstStatisticalCustomer.Add(statisticalCustomer);
            }
            return lstStatisticalCustomer.OrderByDescending(p=>p.QuantityOrder).ToList();
        }

    }
}
    
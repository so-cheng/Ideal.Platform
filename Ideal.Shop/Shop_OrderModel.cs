using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using XAct.Collections;

namespace Ideal.Shop.Model
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Shop_OrderModel : BaseModel
    {
        public Shop_OrderModel()
        {

            this.Owner_DB_TableName = "Shop_Order";
        }

        /// <summary>
		/// 订单ID
		/// </summary>	
		[DbFieldAttribute(DbFieldMode.PRIMARY_KEY)]
        public string OrderID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Phone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string Address { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string TrackingNum { get; set; }
        /// <summary>
        /// 发货状态
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string ShippingStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string ShippingStatusName { get; set; }
        /// <summary>
        /// 签收状态
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string SignStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string SignStatusName { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string ProductName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal ProductPrice { get; set; }
        /// <summary>
        /// 运费
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public decimal Freight { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public DateTime ShippingTime { get; set; }
        /// <summary>
        /// 是否退货
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.ALL_SAVE)]
        public string IsReturn { get; set; }
        /// <summary>
        /// 
        /// </summary>	
        [DbFieldAttribute(DbFieldMode.NEVER_SAVE)]
        public string IsReturnName { get; set; }
    }
}
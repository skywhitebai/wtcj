/**  版本信息模板在安装目录下，可自行修改。
* JD_SITE.cs
*
* 功 能： N/A
* 类 名： JD_SITE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/7/3 15:10:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace WTCJ.Model
{
	/// <summary>
	/// JD_SITE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JD_SITE
	{
		public JD_SITE()
		{}
		#region Model
		private string _id;
		private string _部门;
		private string _类别;
		private string _区域;
		private string _客户;
		private string _站点编码;
		private string _站点名称;
		private string _地址;
		private string _建站类型;
		private string _站点类型归属;
		private DateTime? _预算表或损益表审批时间;
		private DateTime? _与伟通签订单项合同日期;
		private string _最新状态;
		private decimal? _经度;
		private decimal? _纬度;
		private decimal? _租金;
		private decimal? _年限;
		private decimal? _总收入;
		private decimal? _伟通应收款;
		private DateTime? _摘牌时间;
		private DateTime? _预计进场日期;
		private DateTime? _预计完工日期;
		private int? _建站周期;
		private DateTime? _选址定点;
		private DateTime? _签订租赁合同开始日期;
		private DateTime? _签订租赁合同完成日期;
		private DateTime? _地墈开始日期;
		private DateTime? _地墈完成日期;
		private DateTime? _设计出图开始日期;
		private DateTime? _设计出图完成日期;
		private DateTime? _土建施工开始日期;
		private DateTime? _土建施工完成日期;
		private DateTime? _产品采购开始日期;
		private DateTime? _产品采购完成日期;
		private DateTime? _产品安装开始日期;
		private DateTime? _产品安装完成日期;
		private DateTime? _电力报建开始日期;
		private DateTime? _电力报建完成日期;
		private DateTime? _销售验收日期;
		private DateTime? _运营商验收交付开始日期;
		private DateTime? _运营商验收交付完成日期;
		private DateTime? _运营商签订合同开始日期;
		private DateTime? _运营商签订合同完成日期;
		private int? _进场时间预警;
		private int? _交付时间预警;
		private int? _运营合同签约时间预警;
		private string _是否退点;
		private string _备注;
		private string _remark;
		private string _createby;
		private DateTime? _createtime;
		private string _updateby;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 部门
		{
			set{ _部门=value;}
			get{return _部门;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 类别
		{
			set{ _类别=value;}
			get{return _类别;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 区域
		{
			set{ _区域=value;}
			get{return _区域;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 客户
		{
			set{ _客户=value;}
			get{return _客户;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 站点编码
		{
			set{ _站点编码=value;}
			get{return _站点编码;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 站点名称
		{
			set{ _站点名称=value;}
			get{return _站点名称;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 地址
		{
			set{ _地址=value;}
			get{return _地址;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 建站类型
		{
			set{ _建站类型=value;}
			get{return _建站类型;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 站点类型归属
		{
			set{ _站点类型归属=value;}
			get{return _站点类型归属;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 预算表或损益表审批时间
		{
			set{ _预算表或损益表审批时间=value;}
			get{return _预算表或损益表审批时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 与伟通签订单项合同日期
		{
			set{ _与伟通签订单项合同日期=value;}
			get{return _与伟通签订单项合同日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 最新状态
		{
			set{ _最新状态=value;}
			get{return _最新状态;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 经度
		{
			set{ _经度=value;}
			get{return _经度;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 纬度
		{
			set{ _纬度=value;}
			get{return _纬度;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 租金
		{
			set{ _租金=value;}
			get{return _租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 年限
		{
			set{ _年限=value;}
			get{return _年限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 总收入
		{
			set{ _总收入=value;}
			get{return _总收入;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通应收款
		{
			set{ _伟通应收款=value;}
			get{return _伟通应收款;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 摘牌时间
		{
			set{ _摘牌时间=value;}
			get{return _摘牌时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 预计进场日期
		{
			set{ _预计进场日期=value;}
			get{return _预计进场日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 预计完工日期
		{
			set{ _预计完工日期=value;}
			get{return _预计完工日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 建站周期
		{
			set{ _建站周期=value;}
			get{return _建站周期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 选址定点
		{
			set{ _选址定点=value;}
			get{return _选址定点;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 签订租赁合同开始日期
		{
			set{ _签订租赁合同开始日期=value;}
			get{return _签订租赁合同开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 签订租赁合同完成日期
		{
			set{ _签订租赁合同完成日期=value;}
			get{return _签订租赁合同完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 地墈开始日期
		{
			set{ _地墈开始日期=value;}
			get{return _地墈开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 地墈完成日期
		{
			set{ _地墈完成日期=value;}
			get{return _地墈完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 设计出图开始日期
		{
			set{ _设计出图开始日期=value;}
			get{return _设计出图开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 设计出图完成日期
		{
			set{ _设计出图完成日期=value;}
			get{return _设计出图完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 土建施工开始日期
		{
			set{ _土建施工开始日期=value;}
			get{return _土建施工开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 土建施工完成日期
		{
			set{ _土建施工完成日期=value;}
			get{return _土建施工完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 产品采购开始日期
		{
			set{ _产品采购开始日期=value;}
			get{return _产品采购开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 产品采购完成日期
		{
			set{ _产品采购完成日期=value;}
			get{return _产品采购完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 产品安装开始日期
		{
			set{ _产品安装开始日期=value;}
			get{return _产品安装开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 产品安装完成日期
		{
			set{ _产品安装完成日期=value;}
			get{return _产品安装完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 电力报建开始日期
		{
			set{ _电力报建开始日期=value;}
			get{return _电力报建开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 电力报建完成日期
		{
			set{ _电力报建完成日期=value;}
			get{return _电力报建完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 销售验收日期
		{
			set{ _销售验收日期=value;}
			get{return _销售验收日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商验收交付开始日期
		{
			set{ _运营商验收交付开始日期=value;}
			get{return _运营商验收交付开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商验收交付完成日期
		{
			set{ _运营商验收交付完成日期=value;}
			get{return _运营商验收交付完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商签订合同开始日期
		{
			set{ _运营商签订合同开始日期=value;}
			get{return _运营商签订合同开始日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商签订合同完成日期
		{
			set{ _运营商签订合同完成日期=value;}
			get{return _运营商签订合同完成日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 进场时间预警
		{
			set{ _进场时间预警=value;}
			get{return _进场时间预警;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 交付时间预警
		{
			set{ _交付时间预警=value;}
			get{return _交付时间预警;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 运营合同签约时间预警
		{
			set{ _运营合同签约时间预警=value;}
			get{return _运营合同签约时间预警;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 是否退点
		{
			set{ _是否退点=value;}
			get{return _是否退点;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 备注
		{
			set{ _备注=value;}
			get{return _备注;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}


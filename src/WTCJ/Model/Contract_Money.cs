/**  版本信息模板在安装目录下，可自行修改。
* Contract_Money.cs
*
* 功 能： N/A
* 类 名： Contract_Money
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/7/3 10:41:22   N/A    初版
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
	/// Contract_Money:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Contract_Money
	{
		public Contract_Money()
		{}
		#region Model
		private string _id;
		private string _区域;
		private string _类别;
		private string _客户名称;
		private string _站点编码;
		private string _站点名称;
		private DateTime? _销售合同第一年回款日期;
		private DateTime? _合同签订时间建设合同;
		private DateTime? _合同签订时间买卖合同;
		private DateTime? _合同签订时间维护合同;
		private int? _运营商收入信息年限;
		private decimal? _运营商收入信息含税租金;
		private decimal? _运营商收入信息合同金额;
		private decimal? _运营商收入信息不含税租金;
		private decimal? _运营商收入信息不含税总额;
		private decimal? _运营商收入信息税率;
		private decimal? _运营商收入信息税额;
		private DateTime? _运营商收入信息生效时间;
		private DateTime? _运营商收入信息到期时间;
		private DateTime? _运营商收入信息签订时间;
		private string _运营商收入信息签订方;
		private string _运营商收入信息合同编码;
		private string _运营商收入信息项目区域;
		private string _运营商收入信息合同内容;
		private string _运营商收入信息合同付款方式条例;
		private decimal? _预估运营商收入;
		private decimal? _运营商收入差额;
		private decimal? _伟通预估收入;
		private decimal? _伟通第一年应收销售款;
		private decimal? _差额对比收入;
		private decimal? _差额对比成本;
		private DateTime? _运营商开票及回款开票时间;
		private decimal? _运营商开票及回款开票金额;
		private DateTime? _运营商开票及回款回款时间;
		private decimal? _运营商开票及回款回款金额;
		private DateTime? _伟通开票及回款开票时间;
		private decimal? _伟通开票及回款开票金额;
		private DateTime? _伟通开票及回款回款时间;
		private decimal? _伟通开票及回款已回款金额;
		private decimal? _伟通开票及回款未回款金额;
		private string _运营商合同收款账号;
		private string _运营商合同收款账号账号开户行;
		private string _销售共管账号;
		private string _销售共管账号账号开户行;
		private DateTime? _建设验收单签订时间;
		private DateTime? _销售验收单签订时间;
		private DateTime? _运营商验收交付单确认时间;
		private string _备注;
		private int? _isdeleted;
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
		public string 区域
		{
			set{ _区域=value;}
			get{return _区域;}
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
		public string 客户名称
		{
			set{ _客户名称=value;}
			get{return _客户名称;}
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
		public DateTime? 销售合同第一年回款日期
		{
			set{ _销售合同第一年回款日期=value;}
			get{return _销售合同第一年回款日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 合同签订时间建设合同
		{
			set{ _合同签订时间建设合同=value;}
			get{return _合同签订时间建设合同;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 合同签订时间买卖合同
		{
			set{ _合同签订时间买卖合同=value;}
			get{return _合同签订时间买卖合同;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 合同签订时间维护合同
		{
			set{ _合同签订时间维护合同=value;}
			get{return _合同签订时间维护合同;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 运营商收入信息年限
		{
			set{ _运营商收入信息年限=value;}
			get{return _运营商收入信息年限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入信息含税租金
		{
			set{ _运营商收入信息含税租金=value;}
			get{return _运营商收入信息含税租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入信息合同金额
		{
			set{ _运营商收入信息合同金额=value;}
			get{return _运营商收入信息合同金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入信息不含税租金
		{
			set{ _运营商收入信息不含税租金=value;}
			get{return _运营商收入信息不含税租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入信息不含税总额
		{
			set{ _运营商收入信息不含税总额=value;}
			get{return _运营商收入信息不含税总额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入信息税率
		{
			set{ _运营商收入信息税率=value;}
			get{return _运营商收入信息税率;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入信息税额
		{
			set{ _运营商收入信息税额=value;}
			get{return _运营商收入信息税额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商收入信息生效时间
		{
			set{ _运营商收入信息生效时间=value;}
			get{return _运营商收入信息生效时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商收入信息到期时间
		{
			set{ _运营商收入信息到期时间=value;}
			get{return _运营商收入信息到期时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商收入信息签订时间
		{
			set{ _运营商收入信息签订时间=value;}
			get{return _运营商收入信息签订时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商收入信息签订方
		{
			set{ _运营商收入信息签订方=value;}
			get{return _运营商收入信息签订方;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商收入信息合同编码
		{
			set{ _运营商收入信息合同编码=value;}
			get{return _运营商收入信息合同编码;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商收入信息项目区域
		{
			set{ _运营商收入信息项目区域=value;}
			get{return _运营商收入信息项目区域;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商收入信息合同内容
		{
			set{ _运营商收入信息合同内容=value;}
			get{return _运营商收入信息合同内容;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商收入信息合同付款方式条例
		{
			set{ _运营商收入信息合同付款方式条例=value;}
			get{return _运营商收入信息合同付款方式条例;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 预估运营商收入
		{
			set{ _预估运营商收入=value;}
			get{return _预估运营商收入;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商收入差额
		{
			set{ _运营商收入差额=value;}
			get{return _运营商收入差额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通预估收入
		{
			set{ _伟通预估收入=value;}
			get{return _伟通预估收入;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通第一年应收销售款
		{
			set{ _伟通第一年应收销售款=value;}
			get{return _伟通第一年应收销售款;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 差额对比收入
		{
			set{ _差额对比收入=value;}
			get{return _差额对比收入;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 差额对比成本
		{
			set{ _差额对比成本=value;}
			get{return _差额对比成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商开票及回款开票时间
		{
			set{ _运营商开票及回款开票时间=value;}
			get{return _运营商开票及回款开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商开票及回款开票金额
		{
			set{ _运营商开票及回款开票金额=value;}
			get{return _运营商开票及回款开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商开票及回款回款时间
		{
			set{ _运营商开票及回款回款时间=value;}
			get{return _运营商开票及回款回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商开票及回款回款金额
		{
			set{ _运营商开票及回款回款金额=value;}
			get{return _运营商开票及回款回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 伟通开票及回款开票时间
		{
			set{ _伟通开票及回款开票时间=value;}
			get{return _伟通开票及回款开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通开票及回款开票金额
		{
			set{ _伟通开票及回款开票金额=value;}
			get{return _伟通开票及回款开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 伟通开票及回款回款时间
		{
			set{ _伟通开票及回款回款时间=value;}
			get{return _伟通开票及回款回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通开票及回款已回款金额
		{
			set{ _伟通开票及回款已回款金额=value;}
			get{return _伟通开票及回款已回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通开票及回款未回款金额
		{
			set{ _伟通开票及回款未回款金额=value;}
			get{return _伟通开票及回款未回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商合同收款账号
		{
			set{ _运营商合同收款账号=value;}
			get{return _运营商合同收款账号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 运营商合同收款账号账号开户行
		{
			set{ _运营商合同收款账号账号开户行=value;}
			get{return _运营商合同收款账号账号开户行;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 销售共管账号
		{
			set{ _销售共管账号=value;}
			get{return _销售共管账号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 销售共管账号账号开户行
		{
			set{ _销售共管账号账号开户行=value;}
			get{return _销售共管账号账号开户行;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 建设验收单签订时间
		{
			set{ _建设验收单签订时间=value;}
			get{return _建设验收单签订时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 销售验收单签订时间
		{
			set{ _销售验收单签订时间=value;}
			get{return _销售验收单签订时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商验收交付单确认时间
		{
			set{ _运营商验收交付单确认时间=value;}
			get{return _运营商验收交付单确认时间;}
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
		public int? IsDeleted
		{
			set{ _isdeleted=value;}
			get{return _isdeleted;}
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


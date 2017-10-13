/**  版本信息模板在安装目录下，可自行修改。
* Health_Xs.cs
*
* 功 能： N/A
* 类 名： Health_Xs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/7/21 12:39:52   N/A    初版
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
	/// Health_Xs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Health_Xs
	{
		public Health_Xs()
		{}
		#region Model
		private string _id;
		private string _区域;
		private string _客户名称;
		private string _站点名称;
		private string _站点编码;
		private string _回款期限;
		private decimal? _租金金额;
		private decimal? _基站销售款;
		private decimal? _累计应收金额;
		private decimal? _税率;
		private decimal? _伟通收入不含税;
		private DateTime? __2016年开票时间;
		private decimal? __2016年开票金额;
		private DateTime? __2016年合同收款时间;
		private decimal? __2016年合同收款金额;
		private decimal? __2016年实际回款金额;
		private decimal? __2016年应收未收金额;
		private decimal? __2016年到期应收未收金额;
		private DateTime? __2016年实际回款时间;
		private DateTime? __2017年开票时间;
		private decimal? __2017年开票金额;
		private DateTime? __2017年合同收款时间;
		private decimal? __2017年合同收款金额;
		private decimal? __2017年实际回款金额;
		private decimal? __2017年应收未收金额;
		private decimal? __2017年到期应收未收金额;
		private DateTime? __2017年实际回款时间;
		private DateTime? __2018年开票时间;
		private decimal? __2018年开票金额;
		private DateTime? __2018年合同收款时间;
		private decimal? __2018年合同收款金额;
		private decimal? __2018年实际回款金额;
		private decimal? __2018年应收未收金额;
		private decimal? __2018年到期应收未收金额;
		private DateTime? __2018年实际回款时间;
		private DateTime? __2019年开票时间;
		private decimal? __2019年开票金额;
		private DateTime? __2019年合同收款时间;
		private decimal? __2019年合同收款金额;
		private decimal? __2019年实际回款金额;
		private decimal? __2019年应收未收金额;
		private decimal? __2019年到期应收未收金额;
		private DateTime? __2019年实际回款时间;
		private DateTime? __2020年开票时间;
		private decimal? __2020年开票金额;
		private DateTime? __2020年合同收款时间;
		private decimal? __2020年合同收款金额;
		private decimal? __2020年实际回款金额;
		private decimal? __2020年应收未收金额;
		private decimal? __2020年到期应收未收金额;
		private DateTime? __2020年实际回款时间;
		private DateTime? __2021年开票时间;
		private decimal? __2021年开票金额;
		private DateTime? __2021年合同收款时间;
		private decimal? __2021年合同收款金额;
		private decimal? __2021年实际回款金额;
		private decimal? __2021年应收未收金额;
		private decimal? __2021年到期应收未收金额;
		private DateTime? __2021年实际回款时间;
		private DateTime? __2022年开票时间;
		private decimal? __2022年开票金额;
		private DateTime? __2022年合同收款时间;
		private decimal? __2022年合同收款金额;
		private decimal? __2022年实际回款金额;
		private decimal? __2022年应收未收金额;
		private decimal? __2022年到期应收未收金额;
		private DateTime? __2022年实际回款时间;
		private DateTime? __2023年开票时间;
		private decimal? __2023年开票金额;
		private DateTime? __2023年合同收款时间;
		private decimal? __2023年合同收款金额;
		private decimal? __2023年实际回款金额;
		private decimal? __2023年应收未收金额;
		private decimal? __2023年到期应收未收金额;
		private DateTime? __2023年实际回款时间;
		private DateTime? __2024年开票时间;
		private decimal? __2024年开票金额;
		private DateTime? __2024年合同收款时间;
		private decimal? __2024年合同收款金额;
		private decimal? __2024年实际回款金额;
		private decimal? __2024年应收未收金额;
		private decimal? __2024年到期应收未收金额;
		private DateTime? __2024年实际回款时间;
		private DateTime? __2025年开票时间;
		private decimal? __2025年开票金额;
		private DateTime? __2025年合同收款时间;
		private decimal? __2025年合同收款金额;
		private decimal? __2025年实际回款金额;
		private decimal? __2025年应收未收金额;
		private decimal? __2025年到期应收未收金额;
		private DateTime? __2025年实际回款时间;
		private DateTime? __2026年开票时间;
		private decimal? __2026年开票金额;
		private DateTime? __2026年合同收款时间;
		private decimal? __2026年合同收款金额;
		private decimal? __2026年实际回款金额;
		private decimal? __2026年应收未收金额;
		private decimal? __2026年到期应收未收金额;
		private DateTime? __2026年实际回款时间;
		private DateTime? __2027年开票时间;
		private decimal? __2027年开票金额;
		private DateTime? __2027年合同收款时间;
		private decimal? __2027年合同收款金额;
		private decimal? __2027年实际回款金额;
		private decimal? __2027年应收未收金额;
		private decimal? __2027年到期应收未收金额;
		private DateTime? __2027年实际回款时间;
		private DateTime? __2028年开票时间;
		private decimal? __2028年开票金额;
		private DateTime? __2028年合同收款时间;
		private decimal? __2028年合同收款金额;
		private decimal? __2028年实际回款金额;
		private decimal? __2028年应收未收金额;
		private decimal? __2028年到期应收未收金额;
		private DateTime? __2028年实际回款时间;
		private DateTime? __2029年开票时间;
		private decimal? __2029年开票金额;
		private DateTime? __2029年合同收款时间;
		private decimal? __2029年合同收款金额;
		private decimal? __2029年实际回款金额;
		private decimal? __2029年应收未收金额;
		private decimal? __2029年到期应收未收金额;
		private DateTime? __2029年实际回款时间;
		private DateTime? __2030年开票时间;
		private decimal? __2030年开票金额;
		private DateTime? __2030年合同收款时间;
		private decimal? __2030年合同收款金额;
		private decimal? __2030年实际回款金额;
		private decimal? __2030年应收未收金额;
		private decimal? __2030年到期应收未收金额;
		private DateTime? __2030年实际回款时间;
		private decimal? _推迟收款时间;
		private DateTime? _实际竣工时间;
		private decimal? _竣工与实际收款时间差异;
		private DateTime? _移动交付;
		private DateTime? _电信交付;
		private DateTime? _联通交付;
		private DateTime? _铁塔交付;
		private DateTime? _运营商合同签订日期;
		private decimal? _运营商交付单与租赁合同时间差;
		private DateTime? _移动实际付款时间;
		private DateTime? _电信实际付款时间;
		private DateTime? _联通实际付款时间;
		private string _备注;
		private int? _isdeleted=0;
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
		public string 客户名称
		{
			set{ _客户名称=value;}
			get{return _客户名称;}
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
		public string 站点编码
		{
			set{ _站点编码=value;}
			get{return _站点编码;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 回款期限
		{
			set{ _回款期限=value;}
			get{return _回款期限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 租金金额
		{
			set{ _租金金额=value;}
			get{return _租金金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 基站销售款
		{
			set{ _基站销售款=value;}
			get{return _基站销售款;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 累计应收金额
		{
			set{ _累计应收金额=value;}
			get{return _累计应收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 税率
		{
			set{ _税率=value;}
			get{return _税率;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通收入不含税
		{
			set{ _伟通收入不含税=value;}
			get{return _伟通收入不含税;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2016年开票时间
		{
			set{ __2016年开票时间=value;}
			get{return __2016年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2016年开票金额
		{
			set{ __2016年开票金额=value;}
			get{return __2016年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2016年合同收款时间
		{
			set{ __2016年合同收款时间=value;}
			get{return __2016年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2016年合同收款金额
		{
			set{ __2016年合同收款金额=value;}
			get{return __2016年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2016年实际回款金额
		{
			set{ __2016年实际回款金额=value;}
			get{return __2016年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2016年应收未收金额
		{
			set{ __2016年应收未收金额=value;}
			get{return __2016年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2016年到期应收未收金额
		{
			set{ __2016年到期应收未收金额=value;}
			get{return __2016年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2016年实际回款时间
		{
			set{ __2016年实际回款时间=value;}
			get{return __2016年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2017年开票时间
		{
			set{ __2017年开票时间=value;}
			get{return __2017年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2017年开票金额
		{
			set{ __2017年开票金额=value;}
			get{return __2017年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2017年合同收款时间
		{
			set{ __2017年合同收款时间=value;}
			get{return __2017年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2017年合同收款金额
		{
			set{ __2017年合同收款金额=value;}
			get{return __2017年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2017年实际回款金额
		{
			set{ __2017年实际回款金额=value;}
			get{return __2017年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2017年应收未收金额
		{
			set{ __2017年应收未收金额=value;}
			get{return __2017年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2017年到期应收未收金额
		{
			set{ __2017年到期应收未收金额=value;}
			get{return __2017年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2017年实际回款时间
		{
			set{ __2017年实际回款时间=value;}
			get{return __2017年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2018年开票时间
		{
			set{ __2018年开票时间=value;}
			get{return __2018年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2018年开票金额
		{
			set{ __2018年开票金额=value;}
			get{return __2018年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2018年合同收款时间
		{
			set{ __2018年合同收款时间=value;}
			get{return __2018年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2018年合同收款金额
		{
			set{ __2018年合同收款金额=value;}
			get{return __2018年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2018年实际回款金额
		{
			set{ __2018年实际回款金额=value;}
			get{return __2018年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2018年应收未收金额
		{
			set{ __2018年应收未收金额=value;}
			get{return __2018年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2018年到期应收未收金额
		{
			set{ __2018年到期应收未收金额=value;}
			get{return __2018年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2018年实际回款时间
		{
			set{ __2018年实际回款时间=value;}
			get{return __2018年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2019年开票时间
		{
			set{ __2019年开票时间=value;}
			get{return __2019年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2019年开票金额
		{
			set{ __2019年开票金额=value;}
			get{return __2019年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2019年合同收款时间
		{
			set{ __2019年合同收款时间=value;}
			get{return __2019年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2019年合同收款金额
		{
			set{ __2019年合同收款金额=value;}
			get{return __2019年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2019年实际回款金额
		{
			set{ __2019年实际回款金额=value;}
			get{return __2019年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2019年应收未收金额
		{
			set{ __2019年应收未收金额=value;}
			get{return __2019年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2019年到期应收未收金额
		{
			set{ __2019年到期应收未收金额=value;}
			get{return __2019年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2019年实际回款时间
		{
			set{ __2019年实际回款时间=value;}
			get{return __2019年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2020年开票时间
		{
			set{ __2020年开票时间=value;}
			get{return __2020年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2020年开票金额
		{
			set{ __2020年开票金额=value;}
			get{return __2020年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2020年合同收款时间
		{
			set{ __2020年合同收款时间=value;}
			get{return __2020年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2020年合同收款金额
		{
			set{ __2020年合同收款金额=value;}
			get{return __2020年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2020年实际回款金额
		{
			set{ __2020年实际回款金额=value;}
			get{return __2020年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2020年应收未收金额
		{
			set{ __2020年应收未收金额=value;}
			get{return __2020年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2020年到期应收未收金额
		{
			set{ __2020年到期应收未收金额=value;}
			get{return __2020年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2020年实际回款时间
		{
			set{ __2020年实际回款时间=value;}
			get{return __2020年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2021年开票时间
		{
			set{ __2021年开票时间=value;}
			get{return __2021年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2021年开票金额
		{
			set{ __2021年开票金额=value;}
			get{return __2021年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2021年合同收款时间
		{
			set{ __2021年合同收款时间=value;}
			get{return __2021年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2021年合同收款金额
		{
			set{ __2021年合同收款金额=value;}
			get{return __2021年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2021年实际回款金额
		{
			set{ __2021年实际回款金额=value;}
			get{return __2021年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2021年应收未收金额
		{
			set{ __2021年应收未收金额=value;}
			get{return __2021年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2021年到期应收未收金额
		{
			set{ __2021年到期应收未收金额=value;}
			get{return __2021年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2021年实际回款时间
		{
			set{ __2021年实际回款时间=value;}
			get{return __2021年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2022年开票时间
		{
			set{ __2022年开票时间=value;}
			get{return __2022年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2022年开票金额
		{
			set{ __2022年开票金额=value;}
			get{return __2022年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2022年合同收款时间
		{
			set{ __2022年合同收款时间=value;}
			get{return __2022年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2022年合同收款金额
		{
			set{ __2022年合同收款金额=value;}
			get{return __2022年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2022年实际回款金额
		{
			set{ __2022年实际回款金额=value;}
			get{return __2022年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2022年应收未收金额
		{
			set{ __2022年应收未收金额=value;}
			get{return __2022年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2022年到期应收未收金额
		{
			set{ __2022年到期应收未收金额=value;}
			get{return __2022年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2022年实际回款时间
		{
			set{ __2022年实际回款时间=value;}
			get{return __2022年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2023年开票时间
		{
			set{ __2023年开票时间=value;}
			get{return __2023年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2023年开票金额
		{
			set{ __2023年开票金额=value;}
			get{return __2023年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2023年合同收款时间
		{
			set{ __2023年合同收款时间=value;}
			get{return __2023年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2023年合同收款金额
		{
			set{ __2023年合同收款金额=value;}
			get{return __2023年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2023年实际回款金额
		{
			set{ __2023年实际回款金额=value;}
			get{return __2023年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2023年应收未收金额
		{
			set{ __2023年应收未收金额=value;}
			get{return __2023年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2023年到期应收未收金额
		{
			set{ __2023年到期应收未收金额=value;}
			get{return __2023年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2023年实际回款时间
		{
			set{ __2023年实际回款时间=value;}
			get{return __2023年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2024年开票时间
		{
			set{ __2024年开票时间=value;}
			get{return __2024年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2024年开票金额
		{
			set{ __2024年开票金额=value;}
			get{return __2024年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2024年合同收款时间
		{
			set{ __2024年合同收款时间=value;}
			get{return __2024年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2024年合同收款金额
		{
			set{ __2024年合同收款金额=value;}
			get{return __2024年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2024年实际回款金额
		{
			set{ __2024年实际回款金额=value;}
			get{return __2024年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2024年应收未收金额
		{
			set{ __2024年应收未收金额=value;}
			get{return __2024年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2024年到期应收未收金额
		{
			set{ __2024年到期应收未收金额=value;}
			get{return __2024年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2024年实际回款时间
		{
			set{ __2024年实际回款时间=value;}
			get{return __2024年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2025年开票时间
		{
			set{ __2025年开票时间=value;}
			get{return __2025年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2025年开票金额
		{
			set{ __2025年开票金额=value;}
			get{return __2025年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2025年合同收款时间
		{
			set{ __2025年合同收款时间=value;}
			get{return __2025年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2025年合同收款金额
		{
			set{ __2025年合同收款金额=value;}
			get{return __2025年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2025年实际回款金额
		{
			set{ __2025年实际回款金额=value;}
			get{return __2025年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2025年应收未收金额
		{
			set{ __2025年应收未收金额=value;}
			get{return __2025年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2025年到期应收未收金额
		{
			set{ __2025年到期应收未收金额=value;}
			get{return __2025年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2025年实际回款时间
		{
			set{ __2025年实际回款时间=value;}
			get{return __2025年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2026年开票时间
		{
			set{ __2026年开票时间=value;}
			get{return __2026年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2026年开票金额
		{
			set{ __2026年开票金额=value;}
			get{return __2026年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2026年合同收款时间
		{
			set{ __2026年合同收款时间=value;}
			get{return __2026年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2026年合同收款金额
		{
			set{ __2026年合同收款金额=value;}
			get{return __2026年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2026年实际回款金额
		{
			set{ __2026年实际回款金额=value;}
			get{return __2026年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2026年应收未收金额
		{
			set{ __2026年应收未收金额=value;}
			get{return __2026年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2026年到期应收未收金额
		{
			set{ __2026年到期应收未收金额=value;}
			get{return __2026年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2026年实际回款时间
		{
			set{ __2026年实际回款时间=value;}
			get{return __2026年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2027年开票时间
		{
			set{ __2027年开票时间=value;}
			get{return __2027年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2027年开票金额
		{
			set{ __2027年开票金额=value;}
			get{return __2027年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2027年合同收款时间
		{
			set{ __2027年合同收款时间=value;}
			get{return __2027年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2027年合同收款金额
		{
			set{ __2027年合同收款金额=value;}
			get{return __2027年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2027年实际回款金额
		{
			set{ __2027年实际回款金额=value;}
			get{return __2027年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2027年应收未收金额
		{
			set{ __2027年应收未收金额=value;}
			get{return __2027年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2027年到期应收未收金额
		{
			set{ __2027年到期应收未收金额=value;}
			get{return __2027年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2027年实际回款时间
		{
			set{ __2027年实际回款时间=value;}
			get{return __2027年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2028年开票时间
		{
			set{ __2028年开票时间=value;}
			get{return __2028年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2028年开票金额
		{
			set{ __2028年开票金额=value;}
			get{return __2028年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2028年合同收款时间
		{
			set{ __2028年合同收款时间=value;}
			get{return __2028年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2028年合同收款金额
		{
			set{ __2028年合同收款金额=value;}
			get{return __2028年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2028年实际回款金额
		{
			set{ __2028年实际回款金额=value;}
			get{return __2028年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2028年应收未收金额
		{
			set{ __2028年应收未收金额=value;}
			get{return __2028年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2028年到期应收未收金额
		{
			set{ __2028年到期应收未收金额=value;}
			get{return __2028年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2028年实际回款时间
		{
			set{ __2028年实际回款时间=value;}
			get{return __2028年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2029年开票时间
		{
			set{ __2029年开票时间=value;}
			get{return __2029年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2029年开票金额
		{
			set{ __2029年开票金额=value;}
			get{return __2029年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2029年合同收款时间
		{
			set{ __2029年合同收款时间=value;}
			get{return __2029年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2029年合同收款金额
		{
			set{ __2029年合同收款金额=value;}
			get{return __2029年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2029年实际回款金额
		{
			set{ __2029年实际回款金额=value;}
			get{return __2029年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2029年应收未收金额
		{
			set{ __2029年应收未收金额=value;}
			get{return __2029年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2029年到期应收未收金额
		{
			set{ __2029年到期应收未收金额=value;}
			get{return __2029年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2029年实际回款时间
		{
			set{ __2029年实际回款时间=value;}
			get{return __2029年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2030年开票时间
		{
			set{ __2030年开票时间=value;}
			get{return __2030年开票时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2030年开票金额
		{
			set{ __2030年开票金额=value;}
			get{return __2030年开票金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2030年合同收款时间
		{
			set{ __2030年合同收款时间=value;}
			get{return __2030年合同收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2030年合同收款金额
		{
			set{ __2030年合同收款金额=value;}
			get{return __2030年合同收款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2030年实际回款金额
		{
			set{ __2030年实际回款金额=value;}
			get{return __2030年实际回款金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2030年应收未收金额
		{
			set{ __2030年应收未收金额=value;}
			get{return __2030年应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? _2030年到期应收未收金额
		{
			set{ __2030年到期应收未收金额=value;}
			get{return __2030年到期应收未收金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? _2030年实际回款时间
		{
			set{ __2030年实际回款时间=value;}
			get{return __2030年实际回款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 推迟收款时间
		{
			set{ _推迟收款时间=value;}
			get{return _推迟收款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 实际竣工时间
		{
			set{ _实际竣工时间=value;}
			get{return _实际竣工时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 竣工与实际收款时间差异
		{
			set{ _竣工与实际收款时间差异=value;}
			get{return _竣工与实际收款时间差异;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 移动交付
		{
			set{ _移动交付=value;}
			get{return _移动交付;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 电信交付
		{
			set{ _电信交付=value;}
			get{return _电信交付;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 联通交付
		{
			set{ _联通交付=value;}
			get{return _联通交付;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 铁塔交付
		{
			set{ _铁塔交付=value;}
			get{return _铁塔交付;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 运营商合同签订日期
		{
			set{ _运营商合同签订日期=value;}
			get{return _运营商合同签订日期;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 运营商交付单与租赁合同时间差
		{
			set{ _运营商交付单与租赁合同时间差=value;}
			get{return _运营商交付单与租赁合同时间差;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 移动实际付款时间
		{
			set{ _移动实际付款时间=value;}
			get{return _移动实际付款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 电信实际付款时间
		{
			set{ _电信实际付款时间=value;}
			get{return _电信实际付款时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 联通实际付款时间
		{
			set{ _联通实际付款时间=value;}
			get{return _联通实际付款时间;}
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


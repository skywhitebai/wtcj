/**  版本信息模板在安装目录下，可自行修改。
* YzdjSy.cs
*
* 功 能： N/A
* 类 名： YzdjSy
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/7/21 12:45:02   N/A    初版
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
	/// YzdjSy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YzdjSy
	{
		public YzdjSy()
		{}
		#region Model
		private string _id;
		private string _部门;
		private string _区域;
		private string _客户名称;
		private string _站点编码;
		private string _站点名称;
		private string _建站类型;
		private decimal? _经度;
		private decimal? _纬度;
		private DateTime? _摘牌时间;
		private DateTime? _进场施工时间;
		private DateTime? _预计完工时间;
		private int? _建站周期;
		private decimal? _预估运营商收入年租金;
		private int? _预估运营商收入年限;
		private decimal? _预估运营商收入总租金;
		private decimal? _伟通收入;
		private string _成本设备单位1;
		private decimal? _成本设备成本1;
		private string _成本设备单位2;
		private decimal? _成本设备成本2;
		private string _成本场地业主;
		private decimal? _成本租赁成本;
		private string _成本设计单位;
		private decimal? _成本设计成本;
		private string _成本地勘单位;
		private decimal? _成本地勘成本;
		private string _成本监理单位;
		private decimal? _成本监理成本;
		private string _成本项目管理单位;
		private decimal? _成本项目管理成本;
		private string _成本土建施工单位1;
		private decimal? _成本土建施工成本1;
		private string _成本土建施工单位2;
		private decimal? _成本土建施工成本2;
		private string _成本铁塔加工单位;
		private decimal? _成本铁塔加工成本;
		private string _成本安装施工单位;
		private decimal? _成本安装施工成本;
		private string _成本外电单位;
		private decimal? _成本外电费;
		private string _成本杆体搬运单位;
		private decimal? _成本杆体搬运费;
		private string _成本选址费用单位;
		private decimal? _成本选址费;
		private string _成本其他费用单位;
		private decimal? _成本其他费用;
		private decimal? _总成本;
		private decimal? _毛利率;
		private string _已付款设备单位1;
		private decimal? _已付款设备费1;
		private string _已付款设备单位2;
		private decimal? _已付款设备费2;
		private string _已付款业主;
		private decimal? _已付款业主租金;
		private string _已付款设计单位;
		private decimal? _已付款设计费;
		private string _已付款墈察单位;
		private decimal? _已付款墈察费;
		private string _已付款监理单位;
		private decimal? _已付款监理费;
		private string _已付款项目管理单位;
		private decimal? _已付款项目管理费;
		private string _已付款土建施工单位1;
		private decimal? _已付款土建施工费1;
		private string _已付款土建施工单位2;
		private decimal? _已付款土建施工费2;
		private string _已付款铁塔加工单位;
		private decimal? _已付款铁塔加工费;
		private string _已付款安装施工单位;
		private decimal? _已付款安装施工费;
		private string _已付款外电单位;
		private decimal? _已付款外电施工费;
		private string _已付款杆体搬运单位;
		private decimal? _已付款杆体搬运费;
		private string _已付款选址费用单位;
		private decimal? _已付款选址费;
		private string _已付款其他费用单位;
		private decimal? _已付款其他费用;
		private decimal? _总计付款;
		private string _发票情况设备单位1;
		private decimal? _发票情况设备费1;
		private string _发票情况设备单位2;
		private decimal? _发票情况设备费2;
		private string _发票情况业主;
		private decimal? _发票情况业主租金;
		private string _发票情况设计单位;
		private decimal? _发票情况设计费;
		private string _发票情况墈察单位;
		private decimal? _发票情况墈察费;
		private string _发票情况监理单位;
		private decimal? _发票情况监理费;
		private string _发票情况项目管理单位;
		private decimal? _发票情况项目管理费;
		private string _发票情况土建施工单位1;
		private decimal? _发票情况土建施工费1;
		private string _发票情况土建施工单位2;
		private decimal? _发票情况土建施工费2;
		private string _发票情况铁塔加工单位;
		private decimal? _发票情况铁塔加工费;
		private string _发票情况安装施工单位;
		private decimal? _发票情况安装施工费;
		private string _发票情况外电单位;
		private decimal? _发票情况外电施工费;
		private string _发票情况杆体搬运单位;
		private decimal? _发票情况杆体搬运费;
		private string _发票情况选址费用单位;
		private decimal? _发票情况选址费;
		private string _发票情况其他费用单位;
		private decimal? _发票情况其他费用;
		private decimal? _发票情况总计金额;
		private string _已付款未回发票设备单位1;
		private decimal? _已付款未回发票设备费1;
		private string _已付款未回发票设备单位2;
		private decimal? _已付款未回发票设备费2;
		private string _已付款未回发票业主;
		private decimal? _已付款未回发票业主租金;
		private string _已付款未回发票设计单位;
		private decimal? _已付款未回发票设计费;
		private string _已付款未回发票墈察单位;
		private decimal? _已付款未回发票墈察费;
		private string _已付款未回发票监理单位;
		private decimal? _已付款未回发票监理费;
		private string _已付款未回发票项目管理单位;
		private decimal? _已付款未回发票项目管理费;
		private string _已付款未回发票土建施工单位1;
		private decimal? _已付款未回发票土建施工费1;
		private string _已付款未回发票土建施工单位2;
		private decimal? _已付款未回发票土建施工费2;
		private string _已付款未回发票铁塔加工单位;
		private decimal? _已付款未回发票铁塔加工费;
		private string _已付款未回发票安装施工单位;
		private decimal? _已付款未回发票安装施工费;
		private string _已付款未回发票外电单位;
		private decimal? _已付款未回发票外电施工费;
		private string _已付款未回发票杆体搬运单位;
		private decimal? _已付款未回发票杆体搬运费;
		private string _已付款未回发票选址费用单位;
		private decimal? _已付款未回发票选址费;
		private string _已付款未回发票其他费用单位;
		private decimal? _已付款未回发票其他费用;
		private decimal? _已付款未回发票总计金额;
		private string _未付款设备单位1;
		private decimal? _未付款设备费1;
		private string _未付款设备单位2;
		private decimal? _未付款设备费2;
		private string _未付款业主;
		private decimal? _未付款业主租金;
		private string _未付款设计单位;
		private decimal? _未付款设计费;
		private string _未付款墈察单位;
		private decimal? _未付款墈察费;
		private string _未付款监理单位;
		private decimal? _未付款监理费;
		private string _未付款项目管理单位;
		private decimal? _未付款项目管理费;
		private string _未付款土建施工单位1;
		private decimal? _未付款土建施工费1;
		private string _未付款土建施工单位2;
		private decimal? _未付款土建施工费2;
		private string _未付款铁塔加工单位;
		private decimal? _未付款铁塔加工费;
		private string _未付款安装施工单位;
		private decimal? _未付款安装施工费;
		private string _未付款外电单位;
		private decimal? _未付款外电施工费;
		private string _未付款杆体搬运单位;
		private decimal? _未付款杆体搬运费;
		private string _未付款选址费用单位;
		private decimal? _未付款选址费;
		private string _未付款其他费用单位;
		private decimal? _未付款其他费用;
		private decimal? _未付款总计金额;
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
		public string 部门
		{
			set{ _部门=value;}
			get{return _部门;}
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
		public string 建站类型
		{
			set{ _建站类型=value;}
			get{return _建站类型;}
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
		public DateTime? 摘牌时间
		{
			set{ _摘牌时间=value;}
			get{return _摘牌时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 进场施工时间
		{
			set{ _进场施工时间=value;}
			get{return _进场施工时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? 预计完工时间
		{
			set{ _预计完工时间=value;}
			get{return _预计完工时间;}
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
		public decimal? 预估运营商收入年租金
		{
			set{ _预估运营商收入年租金=value;}
			get{return _预估运营商收入年租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 预估运营商收入年限
		{
			set{ _预估运营商收入年限=value;}
			get{return _预估运营商收入年限;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 预估运营商收入总租金
		{
			set{ _预估运营商收入总租金=value;}
			get{return _预估运营商收入总租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 伟通收入
		{
			set{ _伟通收入=value;}
			get{return _伟通收入;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本设备单位1
		{
			set{ _成本设备单位1=value;}
			get{return _成本设备单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本设备成本1
		{
			set{ _成本设备成本1=value;}
			get{return _成本设备成本1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本设备单位2
		{
			set{ _成本设备单位2=value;}
			get{return _成本设备单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本设备成本2
		{
			set{ _成本设备成本2=value;}
			get{return _成本设备成本2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本场地业主
		{
			set{ _成本场地业主=value;}
			get{return _成本场地业主;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本租赁成本
		{
			set{ _成本租赁成本=value;}
			get{return _成本租赁成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本设计单位
		{
			set{ _成本设计单位=value;}
			get{return _成本设计单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本设计成本
		{
			set{ _成本设计成本=value;}
			get{return _成本设计成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本地勘单位
		{
			set{ _成本地勘单位=value;}
			get{return _成本地勘单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本地勘成本
		{
			set{ _成本地勘成本=value;}
			get{return _成本地勘成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本监理单位
		{
			set{ _成本监理单位=value;}
			get{return _成本监理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本监理成本
		{
			set{ _成本监理成本=value;}
			get{return _成本监理成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本项目管理单位
		{
			set{ _成本项目管理单位=value;}
			get{return _成本项目管理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本项目管理成本
		{
			set{ _成本项目管理成本=value;}
			get{return _成本项目管理成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本土建施工单位1
		{
			set{ _成本土建施工单位1=value;}
			get{return _成本土建施工单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本土建施工成本1
		{
			set{ _成本土建施工成本1=value;}
			get{return _成本土建施工成本1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本土建施工单位2
		{
			set{ _成本土建施工单位2=value;}
			get{return _成本土建施工单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本土建施工成本2
		{
			set{ _成本土建施工成本2=value;}
			get{return _成本土建施工成本2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本铁塔加工单位
		{
			set{ _成本铁塔加工单位=value;}
			get{return _成本铁塔加工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本铁塔加工成本
		{
			set{ _成本铁塔加工成本=value;}
			get{return _成本铁塔加工成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本安装施工单位
		{
			set{ _成本安装施工单位=value;}
			get{return _成本安装施工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本安装施工成本
		{
			set{ _成本安装施工成本=value;}
			get{return _成本安装施工成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本外电单位
		{
			set{ _成本外电单位=value;}
			get{return _成本外电单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本外电费
		{
			set{ _成本外电费=value;}
			get{return _成本外电费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本杆体搬运单位
		{
			set{ _成本杆体搬运单位=value;}
			get{return _成本杆体搬运单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本杆体搬运费
		{
			set{ _成本杆体搬运费=value;}
			get{return _成本杆体搬运费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本选址费用单位
		{
			set{ _成本选址费用单位=value;}
			get{return _成本选址费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本选址费
		{
			set{ _成本选址费=value;}
			get{return _成本选址费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 成本其他费用单位
		{
			set{ _成本其他费用单位=value;}
			get{return _成本其他费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 成本其他费用
		{
			set{ _成本其他费用=value;}
			get{return _成本其他费用;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 总成本
		{
			set{ _总成本=value;}
			get{return _总成本;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 毛利率
		{
			set{ _毛利率=value;}
			get{return _毛利率;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款设备单位1
		{
			set{ _已付款设备单位1=value;}
			get{return _已付款设备单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款设备费1
		{
			set{ _已付款设备费1=value;}
			get{return _已付款设备费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款设备单位2
		{
			set{ _已付款设备单位2=value;}
			get{return _已付款设备单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款设备费2
		{
			set{ _已付款设备费2=value;}
			get{return _已付款设备费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款业主
		{
			set{ _已付款业主=value;}
			get{return _已付款业主;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款业主租金
		{
			set{ _已付款业主租金=value;}
			get{return _已付款业主租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款设计单位
		{
			set{ _已付款设计单位=value;}
			get{return _已付款设计单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款设计费
		{
			set{ _已付款设计费=value;}
			get{return _已付款设计费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款墈察单位
		{
			set{ _已付款墈察单位=value;}
			get{return _已付款墈察单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款墈察费
		{
			set{ _已付款墈察费=value;}
			get{return _已付款墈察费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款监理单位
		{
			set{ _已付款监理单位=value;}
			get{return _已付款监理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款监理费
		{
			set{ _已付款监理费=value;}
			get{return _已付款监理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款项目管理单位
		{
			set{ _已付款项目管理单位=value;}
			get{return _已付款项目管理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款项目管理费
		{
			set{ _已付款项目管理费=value;}
			get{return _已付款项目管理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款土建施工单位1
		{
			set{ _已付款土建施工单位1=value;}
			get{return _已付款土建施工单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款土建施工费1
		{
			set{ _已付款土建施工费1=value;}
			get{return _已付款土建施工费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款土建施工单位2
		{
			set{ _已付款土建施工单位2=value;}
			get{return _已付款土建施工单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款土建施工费2
		{
			set{ _已付款土建施工费2=value;}
			get{return _已付款土建施工费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款铁塔加工单位
		{
			set{ _已付款铁塔加工单位=value;}
			get{return _已付款铁塔加工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款铁塔加工费
		{
			set{ _已付款铁塔加工费=value;}
			get{return _已付款铁塔加工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款安装施工单位
		{
			set{ _已付款安装施工单位=value;}
			get{return _已付款安装施工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款安装施工费
		{
			set{ _已付款安装施工费=value;}
			get{return _已付款安装施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款外电单位
		{
			set{ _已付款外电单位=value;}
			get{return _已付款外电单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款外电施工费
		{
			set{ _已付款外电施工费=value;}
			get{return _已付款外电施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款杆体搬运单位
		{
			set{ _已付款杆体搬运单位=value;}
			get{return _已付款杆体搬运单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款杆体搬运费
		{
			set{ _已付款杆体搬运费=value;}
			get{return _已付款杆体搬运费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款选址费用单位
		{
			set{ _已付款选址费用单位=value;}
			get{return _已付款选址费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款选址费
		{
			set{ _已付款选址费=value;}
			get{return _已付款选址费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款其他费用单位
		{
			set{ _已付款其他费用单位=value;}
			get{return _已付款其他费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款其他费用
		{
			set{ _已付款其他费用=value;}
			get{return _已付款其他费用;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 总计付款
		{
			set{ _总计付款=value;}
			get{return _总计付款;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况设备单位1
		{
			set{ _发票情况设备单位1=value;}
			get{return _发票情况设备单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况设备费1
		{
			set{ _发票情况设备费1=value;}
			get{return _发票情况设备费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况设备单位2
		{
			set{ _发票情况设备单位2=value;}
			get{return _发票情况设备单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况设备费2
		{
			set{ _发票情况设备费2=value;}
			get{return _发票情况设备费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况业主
		{
			set{ _发票情况业主=value;}
			get{return _发票情况业主;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况业主租金
		{
			set{ _发票情况业主租金=value;}
			get{return _发票情况业主租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况设计单位
		{
			set{ _发票情况设计单位=value;}
			get{return _发票情况设计单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况设计费
		{
			set{ _发票情况设计费=value;}
			get{return _发票情况设计费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况墈察单位
		{
			set{ _发票情况墈察单位=value;}
			get{return _发票情况墈察单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况墈察费
		{
			set{ _发票情况墈察费=value;}
			get{return _发票情况墈察费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况监理单位
		{
			set{ _发票情况监理单位=value;}
			get{return _发票情况监理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况监理费
		{
			set{ _发票情况监理费=value;}
			get{return _发票情况监理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况项目管理单位
		{
			set{ _发票情况项目管理单位=value;}
			get{return _发票情况项目管理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况项目管理费
		{
			set{ _发票情况项目管理费=value;}
			get{return _发票情况项目管理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况土建施工单位1
		{
			set{ _发票情况土建施工单位1=value;}
			get{return _发票情况土建施工单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况土建施工费1
		{
			set{ _发票情况土建施工费1=value;}
			get{return _发票情况土建施工费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况土建施工单位2
		{
			set{ _发票情况土建施工单位2=value;}
			get{return _发票情况土建施工单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况土建施工费2
		{
			set{ _发票情况土建施工费2=value;}
			get{return _发票情况土建施工费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况铁塔加工单位
		{
			set{ _发票情况铁塔加工单位=value;}
			get{return _发票情况铁塔加工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况铁塔加工费
		{
			set{ _发票情况铁塔加工费=value;}
			get{return _发票情况铁塔加工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况安装施工单位
		{
			set{ _发票情况安装施工单位=value;}
			get{return _发票情况安装施工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况安装施工费
		{
			set{ _发票情况安装施工费=value;}
			get{return _发票情况安装施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况外电单位
		{
			set{ _发票情况外电单位=value;}
			get{return _发票情况外电单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况外电施工费
		{
			set{ _发票情况外电施工费=value;}
			get{return _发票情况外电施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况杆体搬运单位
		{
			set{ _发票情况杆体搬运单位=value;}
			get{return _发票情况杆体搬运单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况杆体搬运费
		{
			set{ _发票情况杆体搬运费=value;}
			get{return _发票情况杆体搬运费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况选址费用单位
		{
			set{ _发票情况选址费用单位=value;}
			get{return _发票情况选址费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况选址费
		{
			set{ _发票情况选址费=value;}
			get{return _发票情况选址费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 发票情况其他费用单位
		{
			set{ _发票情况其他费用单位=value;}
			get{return _发票情况其他费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况其他费用
		{
			set{ _发票情况其他费用=value;}
			get{return _发票情况其他费用;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 发票情况总计金额
		{
			set{ _发票情况总计金额=value;}
			get{return _发票情况总计金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票设备单位1
		{
			set{ _已付款未回发票设备单位1=value;}
			get{return _已付款未回发票设备单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票设备费1
		{
			set{ _已付款未回发票设备费1=value;}
			get{return _已付款未回发票设备费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票设备单位2
		{
			set{ _已付款未回发票设备单位2=value;}
			get{return _已付款未回发票设备单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票设备费2
		{
			set{ _已付款未回发票设备费2=value;}
			get{return _已付款未回发票设备费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票业主
		{
			set{ _已付款未回发票业主=value;}
			get{return _已付款未回发票业主;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票业主租金
		{
			set{ _已付款未回发票业主租金=value;}
			get{return _已付款未回发票业主租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票设计单位
		{
			set{ _已付款未回发票设计单位=value;}
			get{return _已付款未回发票设计单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票设计费
		{
			set{ _已付款未回发票设计费=value;}
			get{return _已付款未回发票设计费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票墈察单位
		{
			set{ _已付款未回发票墈察单位=value;}
			get{return _已付款未回发票墈察单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票墈察费
		{
			set{ _已付款未回发票墈察费=value;}
			get{return _已付款未回发票墈察费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票监理单位
		{
			set{ _已付款未回发票监理单位=value;}
			get{return _已付款未回发票监理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票监理费
		{
			set{ _已付款未回发票监理费=value;}
			get{return _已付款未回发票监理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票项目管理单位
		{
			set{ _已付款未回发票项目管理单位=value;}
			get{return _已付款未回发票项目管理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票项目管理费
		{
			set{ _已付款未回发票项目管理费=value;}
			get{return _已付款未回发票项目管理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票土建施工单位1
		{
			set{ _已付款未回发票土建施工单位1=value;}
			get{return _已付款未回发票土建施工单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票土建施工费1
		{
			set{ _已付款未回发票土建施工费1=value;}
			get{return _已付款未回发票土建施工费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票土建施工单位2
		{
			set{ _已付款未回发票土建施工单位2=value;}
			get{return _已付款未回发票土建施工单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票土建施工费2
		{
			set{ _已付款未回发票土建施工费2=value;}
			get{return _已付款未回发票土建施工费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票铁塔加工单位
		{
			set{ _已付款未回发票铁塔加工单位=value;}
			get{return _已付款未回发票铁塔加工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票铁塔加工费
		{
			set{ _已付款未回发票铁塔加工费=value;}
			get{return _已付款未回发票铁塔加工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票安装施工单位
		{
			set{ _已付款未回发票安装施工单位=value;}
			get{return _已付款未回发票安装施工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票安装施工费
		{
			set{ _已付款未回发票安装施工费=value;}
			get{return _已付款未回发票安装施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票外电单位
		{
			set{ _已付款未回发票外电单位=value;}
			get{return _已付款未回发票外电单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票外电施工费
		{
			set{ _已付款未回发票外电施工费=value;}
			get{return _已付款未回发票外电施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票杆体搬运单位
		{
			set{ _已付款未回发票杆体搬运单位=value;}
			get{return _已付款未回发票杆体搬运单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票杆体搬运费
		{
			set{ _已付款未回发票杆体搬运费=value;}
			get{return _已付款未回发票杆体搬运费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票选址费用单位
		{
			set{ _已付款未回发票选址费用单位=value;}
			get{return _已付款未回发票选址费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票选址费
		{
			set{ _已付款未回发票选址费=value;}
			get{return _已付款未回发票选址费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 已付款未回发票其他费用单位
		{
			set{ _已付款未回发票其他费用单位=value;}
			get{return _已付款未回发票其他费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票其他费用
		{
			set{ _已付款未回发票其他费用=value;}
			get{return _已付款未回发票其他费用;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 已付款未回发票总计金额
		{
			set{ _已付款未回发票总计金额=value;}
			get{return _已付款未回发票总计金额;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款设备单位1
		{
			set{ _未付款设备单位1=value;}
			get{return _未付款设备单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款设备费1
		{
			set{ _未付款设备费1=value;}
			get{return _未付款设备费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款设备单位2
		{
			set{ _未付款设备单位2=value;}
			get{return _未付款设备单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款设备费2
		{
			set{ _未付款设备费2=value;}
			get{return _未付款设备费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款业主
		{
			set{ _未付款业主=value;}
			get{return _未付款业主;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款业主租金
		{
			set{ _未付款业主租金=value;}
			get{return _未付款业主租金;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款设计单位
		{
			set{ _未付款设计单位=value;}
			get{return _未付款设计单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款设计费
		{
			set{ _未付款设计费=value;}
			get{return _未付款设计费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款墈察单位
		{
			set{ _未付款墈察单位=value;}
			get{return _未付款墈察单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款墈察费
		{
			set{ _未付款墈察费=value;}
			get{return _未付款墈察费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款监理单位
		{
			set{ _未付款监理单位=value;}
			get{return _未付款监理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款监理费
		{
			set{ _未付款监理费=value;}
			get{return _未付款监理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款项目管理单位
		{
			set{ _未付款项目管理单位=value;}
			get{return _未付款项目管理单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款项目管理费
		{
			set{ _未付款项目管理费=value;}
			get{return _未付款项目管理费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款土建施工单位1
		{
			set{ _未付款土建施工单位1=value;}
			get{return _未付款土建施工单位1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款土建施工费1
		{
			set{ _未付款土建施工费1=value;}
			get{return _未付款土建施工费1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款土建施工单位2
		{
			set{ _未付款土建施工单位2=value;}
			get{return _未付款土建施工单位2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款土建施工费2
		{
			set{ _未付款土建施工费2=value;}
			get{return _未付款土建施工费2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款铁塔加工单位
		{
			set{ _未付款铁塔加工单位=value;}
			get{return _未付款铁塔加工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款铁塔加工费
		{
			set{ _未付款铁塔加工费=value;}
			get{return _未付款铁塔加工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款安装施工单位
		{
			set{ _未付款安装施工单位=value;}
			get{return _未付款安装施工单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款安装施工费
		{
			set{ _未付款安装施工费=value;}
			get{return _未付款安装施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款外电单位
		{
			set{ _未付款外电单位=value;}
			get{return _未付款外电单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款外电施工费
		{
			set{ _未付款外电施工费=value;}
			get{return _未付款外电施工费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款杆体搬运单位
		{
			set{ _未付款杆体搬运单位=value;}
			get{return _未付款杆体搬运单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款杆体搬运费
		{
			set{ _未付款杆体搬运费=value;}
			get{return _未付款杆体搬运费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款选址费用单位
		{
			set{ _未付款选址费用单位=value;}
			get{return _未付款选址费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款选址费
		{
			set{ _未付款选址费=value;}
			get{return _未付款选址费;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 未付款其他费用单位
		{
			set{ _未付款其他费用单位=value;}
			get{return _未付款其他费用单位;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款其他费用
		{
			set{ _未付款其他费用=value;}
			get{return _未付款其他费用;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? 未付款总计金额
		{
			set{ _未付款总计金额=value;}
			get{return _未付款总计金额;}
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


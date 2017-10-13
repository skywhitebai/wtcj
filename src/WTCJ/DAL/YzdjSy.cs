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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WTCJ.DBUtility;//Please add references
namespace WTCJ.DAL
{
	/// <summary>
	/// 数据访问类:YzdjSy
	/// </summary>
	public partial class YzdjSy
	{
		public YzdjSy()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YzdjSy");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.YzdjSy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YzdjSy(");
			strSql.Append("id,部门,区域,客户名称,站点编码,站点名称,建站类型,经度,纬度,摘牌时间,进场施工时间,预计完工时间,建站周期,预估运营商收入年租金,预估运营商收入年限,预估运营商收入总租金,伟通收入,成本设备单位1,成本设备成本1,成本设备单位2,成本设备成本2,成本场地业主,成本租赁成本,成本设计单位,成本设计成本,成本地勘单位,成本地勘成本,成本监理单位,成本监理成本,成本项目管理单位,成本项目管理成本,成本土建施工单位1,成本土建施工成本1,成本土建施工单位2,成本土建施工成本2,成本铁塔加工单位,成本铁塔加工成本,成本安装施工单位,成本安装施工成本,成本外电单位,成本外电费,成本杆体搬运单位,成本杆体搬运费,成本选址费用单位,成本选址费,成本其他费用单位,成本其他费用,总成本,毛利率,已付款设备单位1,已付款设备费1,已付款设备单位2,已付款设备费2,已付款业主,已付款业主租金,已付款设计单位,已付款设计费,已付款墈察单位,已付款墈察费,已付款监理单位,已付款监理费,已付款项目管理单位,已付款项目管理费,已付款土建施工单位1,已付款土建施工费1,已付款土建施工单位2,已付款土建施工费2,已付款铁塔加工单位,已付款铁塔加工费,已付款安装施工单位,已付款安装施工费,已付款外电单位,已付款外电施工费,已付款杆体搬运单位,已付款杆体搬运费,已付款选址费用单位,已付款选址费,已付款其他费用单位,已付款其他费用,总计付款,发票情况设备单位1,发票情况设备费1,发票情况设备单位2,发票情况设备费2,发票情况业主,发票情况业主租金,发票情况设计单位,发票情况设计费,发票情况墈察单位,发票情况墈察费,发票情况监理单位,发票情况监理费,发票情况项目管理单位,发票情况项目管理费,发票情况土建施工单位1,发票情况土建施工费1,发票情况土建施工单位2,发票情况土建施工费2,发票情况铁塔加工单位,发票情况铁塔加工费,发票情况安装施工单位,发票情况安装施工费,发票情况外电单位,发票情况外电施工费,发票情况杆体搬运单位,发票情况杆体搬运费,发票情况选址费用单位,发票情况选址费,发票情况其他费用单位,发票情况其他费用,发票情况总计金额,已付款未回发票设备单位1,已付款未回发票设备费1,已付款未回发票设备单位2,已付款未回发票设备费2,已付款未回发票业主,已付款未回发票业主租金,已付款未回发票设计单位,已付款未回发票设计费,已付款未回发票墈察单位,已付款未回发票墈察费,已付款未回发票监理单位,已付款未回发票监理费,已付款未回发票项目管理单位,已付款未回发票项目管理费,已付款未回发票土建施工单位1,已付款未回发票土建施工费1,已付款未回发票土建施工单位2,已付款未回发票土建施工费2,已付款未回发票铁塔加工单位,已付款未回发票铁塔加工费,已付款未回发票安装施工单位,已付款未回发票安装施工费,已付款未回发票外电单位,已付款未回发票外电施工费,已付款未回发票杆体搬运单位,已付款未回发票杆体搬运费,已付款未回发票选址费用单位,已付款未回发票选址费,已付款未回发票其他费用单位,已付款未回发票其他费用,已付款未回发票总计金额,未付款设备单位1,未付款设备费1,未付款设备单位2,未付款设备费2,未付款业主,未付款业主租金,未付款设计单位,未付款设计费,未付款墈察单位,未付款墈察费,未付款监理单位,未付款监理费,未付款项目管理单位,未付款项目管理费,未付款土建施工单位1,未付款土建施工费1,未付款土建施工单位2,未付款土建施工费2,未付款铁塔加工单位,未付款铁塔加工费,未付款安装施工单位,未付款安装施工费,未付款外电单位,未付款外电施工费,未付款杆体搬运单位,未付款杆体搬运费,未付款选址费用单位,未付款选址费,未付款其他费用单位,未付款其他费用,未付款总计金额,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@部门,@区域,@客户名称,@站点编码,@站点名称,@建站类型,@经度,@纬度,@摘牌时间,@进场施工时间,@预计完工时间,@建站周期,@预估运营商收入年租金,@预估运营商收入年限,@预估运营商收入总租金,@伟通收入,@成本设备单位1,@成本设备成本1,@成本设备单位2,@成本设备成本2,@成本场地业主,@成本租赁成本,@成本设计单位,@成本设计成本,@成本地勘单位,@成本地勘成本,@成本监理单位,@成本监理成本,@成本项目管理单位,@成本项目管理成本,@成本土建施工单位1,@成本土建施工成本1,@成本土建施工单位2,@成本土建施工成本2,@成本铁塔加工单位,@成本铁塔加工成本,@成本安装施工单位,@成本安装施工成本,@成本外电单位,@成本外电费,@成本杆体搬运单位,@成本杆体搬运费,@成本选址费用单位,@成本选址费,@成本其他费用单位,@成本其他费用,@总成本,@毛利率,@已付款设备单位1,@已付款设备费1,@已付款设备单位2,@已付款设备费2,@已付款业主,@已付款业主租金,@已付款设计单位,@已付款设计费,@已付款墈察单位,@已付款墈察费,@已付款监理单位,@已付款监理费,@已付款项目管理单位,@已付款项目管理费,@已付款土建施工单位1,@已付款土建施工费1,@已付款土建施工单位2,@已付款土建施工费2,@已付款铁塔加工单位,@已付款铁塔加工费,@已付款安装施工单位,@已付款安装施工费,@已付款外电单位,@已付款外电施工费,@已付款杆体搬运单位,@已付款杆体搬运费,@已付款选址费用单位,@已付款选址费,@已付款其他费用单位,@已付款其他费用,@总计付款,@发票情况设备单位1,@发票情况设备费1,@发票情况设备单位2,@发票情况设备费2,@发票情况业主,@发票情况业主租金,@发票情况设计单位,@发票情况设计费,@发票情况墈察单位,@发票情况墈察费,@发票情况监理单位,@发票情况监理费,@发票情况项目管理单位,@发票情况项目管理费,@发票情况土建施工单位1,@发票情况土建施工费1,@发票情况土建施工单位2,@发票情况土建施工费2,@发票情况铁塔加工单位,@发票情况铁塔加工费,@发票情况安装施工单位,@发票情况安装施工费,@发票情况外电单位,@发票情况外电施工费,@发票情况杆体搬运单位,@发票情况杆体搬运费,@发票情况选址费用单位,@发票情况选址费,@发票情况其他费用单位,@发票情况其他费用,@发票情况总计金额,@已付款未回发票设备单位1,@已付款未回发票设备费1,@已付款未回发票设备单位2,@已付款未回发票设备费2,@已付款未回发票业主,@已付款未回发票业主租金,@已付款未回发票设计单位,@已付款未回发票设计费,@已付款未回发票墈察单位,@已付款未回发票墈察费,@已付款未回发票监理单位,@已付款未回发票监理费,@已付款未回发票项目管理单位,@已付款未回发票项目管理费,@已付款未回发票土建施工单位1,@已付款未回发票土建施工费1,@已付款未回发票土建施工单位2,@已付款未回发票土建施工费2,@已付款未回发票铁塔加工单位,@已付款未回发票铁塔加工费,@已付款未回发票安装施工单位,@已付款未回发票安装施工费,@已付款未回发票外电单位,@已付款未回发票外电施工费,@已付款未回发票杆体搬运单位,@已付款未回发票杆体搬运费,@已付款未回发票选址费用单位,@已付款未回发票选址费,@已付款未回发票其他费用单位,@已付款未回发票其他费用,@已付款未回发票总计金额,@未付款设备单位1,@未付款设备费1,@未付款设备单位2,@未付款设备费2,@未付款业主,@未付款业主租金,@未付款设计单位,@未付款设计费,@未付款墈察单位,@未付款墈察费,@未付款监理单位,@未付款监理费,@未付款项目管理单位,@未付款项目管理费,@未付款土建施工单位1,@未付款土建施工费1,@未付款土建施工单位2,@未付款土建施工费2,@未付款铁塔加工单位,@未付款铁塔加工费,@未付款安装施工单位,@未付款安装施工费,@未付款外电单位,@未付款外电施工费,@未付款杆体搬运单位,@未付款杆体搬运费,@未付款选址费用单位,@未付款选址费,@未付款其他费用单位,@未付款其他费用,@未付款总计金额,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@建站类型", SqlDbType.VarChar,200),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@进场施工时间", SqlDbType.DateTime),
					new SqlParameter("@预计完工时间", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入年租金", SqlDbType.Decimal,9),
					new SqlParameter("@预估运营商收入年限", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入总租金", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本场地业主", SqlDbType.VarChar,200),
					new SqlParameter("@成本租赁成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本设计成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本地勘单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本地勘成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本监理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本项目管理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本铁塔加工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本安装施工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本外电费", SqlDbType.Decimal,9),
					new SqlParameter("@成本杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@成本选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本选址费", SqlDbType.Decimal,9),
					new SqlParameter("@成本其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@成本其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总成本", SqlDbType.Decimal,9),
					new SqlParameter("@毛利率", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总计付款", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况业主", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设计费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况监理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况选址费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@未付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@未付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@未付款总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.部门;
			parameters[2].Value = model.区域;
			parameters[3].Value = model.客户名称;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.站点名称;
			parameters[6].Value = model.建站类型;
			parameters[7].Value = model.经度;
			parameters[8].Value = model.纬度;
			parameters[9].Value = model.摘牌时间;
			parameters[10].Value = model.进场施工时间;
			parameters[11].Value = model.预计完工时间;
			parameters[12].Value = model.建站周期;
			parameters[13].Value = model.预估运营商收入年租金;
			parameters[14].Value = model.预估运营商收入年限;
			parameters[15].Value = model.预估运营商收入总租金;
			parameters[16].Value = model.伟通收入;
			parameters[17].Value = model.成本设备单位1;
			parameters[18].Value = model.成本设备成本1;
			parameters[19].Value = model.成本设备单位2;
			parameters[20].Value = model.成本设备成本2;
			parameters[21].Value = model.成本场地业主;
			parameters[22].Value = model.成本租赁成本;
			parameters[23].Value = model.成本设计单位;
			parameters[24].Value = model.成本设计成本;
			parameters[25].Value = model.成本地勘单位;
			parameters[26].Value = model.成本地勘成本;
			parameters[27].Value = model.成本监理单位;
			parameters[28].Value = model.成本监理成本;
			parameters[29].Value = model.成本项目管理单位;
			parameters[30].Value = model.成本项目管理成本;
			parameters[31].Value = model.成本土建施工单位1;
			parameters[32].Value = model.成本土建施工成本1;
			parameters[33].Value = model.成本土建施工单位2;
			parameters[34].Value = model.成本土建施工成本2;
			parameters[35].Value = model.成本铁塔加工单位;
			parameters[36].Value = model.成本铁塔加工成本;
			parameters[37].Value = model.成本安装施工单位;
			parameters[38].Value = model.成本安装施工成本;
			parameters[39].Value = model.成本外电单位;
			parameters[40].Value = model.成本外电费;
			parameters[41].Value = model.成本杆体搬运单位;
			parameters[42].Value = model.成本杆体搬运费;
			parameters[43].Value = model.成本选址费用单位;
			parameters[44].Value = model.成本选址费;
			parameters[45].Value = model.成本其他费用单位;
			parameters[46].Value = model.成本其他费用;
			parameters[47].Value = model.总成本;
			parameters[48].Value = model.毛利率;
			parameters[49].Value = model.已付款设备单位1;
			parameters[50].Value = model.已付款设备费1;
			parameters[51].Value = model.已付款设备单位2;
			parameters[52].Value = model.已付款设备费2;
			parameters[53].Value = model.已付款业主;
			parameters[54].Value = model.已付款业主租金;
			parameters[55].Value = model.已付款设计单位;
			parameters[56].Value = model.已付款设计费;
			parameters[57].Value = model.已付款墈察单位;
			parameters[58].Value = model.已付款墈察费;
			parameters[59].Value = model.已付款监理单位;
			parameters[60].Value = model.已付款监理费;
			parameters[61].Value = model.已付款项目管理单位;
			parameters[62].Value = model.已付款项目管理费;
			parameters[63].Value = model.已付款土建施工单位1;
			parameters[64].Value = model.已付款土建施工费1;
			parameters[65].Value = model.已付款土建施工单位2;
			parameters[66].Value = model.已付款土建施工费2;
			parameters[67].Value = model.已付款铁塔加工单位;
			parameters[68].Value = model.已付款铁塔加工费;
			parameters[69].Value = model.已付款安装施工单位;
			parameters[70].Value = model.已付款安装施工费;
			parameters[71].Value = model.已付款外电单位;
			parameters[72].Value = model.已付款外电施工费;
			parameters[73].Value = model.已付款杆体搬运单位;
			parameters[74].Value = model.已付款杆体搬运费;
			parameters[75].Value = model.已付款选址费用单位;
			parameters[76].Value = model.已付款选址费;
			parameters[77].Value = model.已付款其他费用单位;
			parameters[78].Value = model.已付款其他费用;
			parameters[79].Value = model.总计付款;
			parameters[80].Value = model.发票情况设备单位1;
			parameters[81].Value = model.发票情况设备费1;
			parameters[82].Value = model.发票情况设备单位2;
			parameters[83].Value = model.发票情况设备费2;
			parameters[84].Value = model.发票情况业主;
			parameters[85].Value = model.发票情况业主租金;
			parameters[86].Value = model.发票情况设计单位;
			parameters[87].Value = model.发票情况设计费;
			parameters[88].Value = model.发票情况墈察单位;
			parameters[89].Value = model.发票情况墈察费;
			parameters[90].Value = model.发票情况监理单位;
			parameters[91].Value = model.发票情况监理费;
			parameters[92].Value = model.发票情况项目管理单位;
			parameters[93].Value = model.发票情况项目管理费;
			parameters[94].Value = model.发票情况土建施工单位1;
			parameters[95].Value = model.发票情况土建施工费1;
			parameters[96].Value = model.发票情况土建施工单位2;
			parameters[97].Value = model.发票情况土建施工费2;
			parameters[98].Value = model.发票情况铁塔加工单位;
			parameters[99].Value = model.发票情况铁塔加工费;
			parameters[100].Value = model.发票情况安装施工单位;
			parameters[101].Value = model.发票情况安装施工费;
			parameters[102].Value = model.发票情况外电单位;
			parameters[103].Value = model.发票情况外电施工费;
			parameters[104].Value = model.发票情况杆体搬运单位;
			parameters[105].Value = model.发票情况杆体搬运费;
			parameters[106].Value = model.发票情况选址费用单位;
			parameters[107].Value = model.发票情况选址费;
			parameters[108].Value = model.发票情况其他费用单位;
			parameters[109].Value = model.发票情况其他费用;
			parameters[110].Value = model.发票情况总计金额;
			parameters[111].Value = model.已付款未回发票设备单位1;
			parameters[112].Value = model.已付款未回发票设备费1;
			parameters[113].Value = model.已付款未回发票设备单位2;
			parameters[114].Value = model.已付款未回发票设备费2;
			parameters[115].Value = model.已付款未回发票业主;
			parameters[116].Value = model.已付款未回发票业主租金;
			parameters[117].Value = model.已付款未回发票设计单位;
			parameters[118].Value = model.已付款未回发票设计费;
			parameters[119].Value = model.已付款未回发票墈察单位;
			parameters[120].Value = model.已付款未回发票墈察费;
			parameters[121].Value = model.已付款未回发票监理单位;
			parameters[122].Value = model.已付款未回发票监理费;
			parameters[123].Value = model.已付款未回发票项目管理单位;
			parameters[124].Value = model.已付款未回发票项目管理费;
			parameters[125].Value = model.已付款未回发票土建施工单位1;
			parameters[126].Value = model.已付款未回发票土建施工费1;
			parameters[127].Value = model.已付款未回发票土建施工单位2;
			parameters[128].Value = model.已付款未回发票土建施工费2;
			parameters[129].Value = model.已付款未回发票铁塔加工单位;
			parameters[130].Value = model.已付款未回发票铁塔加工费;
			parameters[131].Value = model.已付款未回发票安装施工单位;
			parameters[132].Value = model.已付款未回发票安装施工费;
			parameters[133].Value = model.已付款未回发票外电单位;
			parameters[134].Value = model.已付款未回发票外电施工费;
			parameters[135].Value = model.已付款未回发票杆体搬运单位;
			parameters[136].Value = model.已付款未回发票杆体搬运费;
			parameters[137].Value = model.已付款未回发票选址费用单位;
			parameters[138].Value = model.已付款未回发票选址费;
			parameters[139].Value = model.已付款未回发票其他费用单位;
			parameters[140].Value = model.已付款未回发票其他费用;
			parameters[141].Value = model.已付款未回发票总计金额;
			parameters[142].Value = model.未付款设备单位1;
			parameters[143].Value = model.未付款设备费1;
			parameters[144].Value = model.未付款设备单位2;
			parameters[145].Value = model.未付款设备费2;
			parameters[146].Value = model.未付款业主;
			parameters[147].Value = model.未付款业主租金;
			parameters[148].Value = model.未付款设计单位;
			parameters[149].Value = model.未付款设计费;
			parameters[150].Value = model.未付款墈察单位;
			parameters[151].Value = model.未付款墈察费;
			parameters[152].Value = model.未付款监理单位;
			parameters[153].Value = model.未付款监理费;
			parameters[154].Value = model.未付款项目管理单位;
			parameters[155].Value = model.未付款项目管理费;
			parameters[156].Value = model.未付款土建施工单位1;
			parameters[157].Value = model.未付款土建施工费1;
			parameters[158].Value = model.未付款土建施工单位2;
			parameters[159].Value = model.未付款土建施工费2;
			parameters[160].Value = model.未付款铁塔加工单位;
			parameters[161].Value = model.未付款铁塔加工费;
			parameters[162].Value = model.未付款安装施工单位;
			parameters[163].Value = model.未付款安装施工费;
			parameters[164].Value = model.未付款外电单位;
			parameters[165].Value = model.未付款外电施工费;
			parameters[166].Value = model.未付款杆体搬运单位;
			parameters[167].Value = model.未付款杆体搬运费;
			parameters[168].Value = model.未付款选址费用单位;
			parameters[169].Value = model.未付款选址费;
			parameters[170].Value = model.未付款其他费用单位;
			parameters[171].Value = model.未付款其他费用;
			parameters[172].Value = model.未付款总计金额;
			parameters[173].Value = model.备注;
			parameters[174].Value = model.IsDeleted;
			parameters[175].Value = model.CreateBy;
			parameters[176].Value = model.CreateTime;
			parameters[177].Value = model.UpdateBy;
			parameters[178].Value = model.UpdateTime;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SqlTransaction tran,WTCJ.Model.YzdjSy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YzdjSy(");
			strSql.Append("id,部门,区域,客户名称,站点编码,站点名称,建站类型,经度,纬度,摘牌时间,进场施工时间,预计完工时间,建站周期,预估运营商收入年租金,预估运营商收入年限,预估运营商收入总租金,伟通收入,成本设备单位1,成本设备成本1,成本设备单位2,成本设备成本2,成本场地业主,成本租赁成本,成本设计单位,成本设计成本,成本地勘单位,成本地勘成本,成本监理单位,成本监理成本,成本项目管理单位,成本项目管理成本,成本土建施工单位1,成本土建施工成本1,成本土建施工单位2,成本土建施工成本2,成本铁塔加工单位,成本铁塔加工成本,成本安装施工单位,成本安装施工成本,成本外电单位,成本外电费,成本杆体搬运单位,成本杆体搬运费,成本选址费用单位,成本选址费,成本其他费用单位,成本其他费用,总成本,毛利率,已付款设备单位1,已付款设备费1,已付款设备单位2,已付款设备费2,已付款业主,已付款业主租金,已付款设计单位,已付款设计费,已付款墈察单位,已付款墈察费,已付款监理单位,已付款监理费,已付款项目管理单位,已付款项目管理费,已付款土建施工单位1,已付款土建施工费1,已付款土建施工单位2,已付款土建施工费2,已付款铁塔加工单位,已付款铁塔加工费,已付款安装施工单位,已付款安装施工费,已付款外电单位,已付款外电施工费,已付款杆体搬运单位,已付款杆体搬运费,已付款选址费用单位,已付款选址费,已付款其他费用单位,已付款其他费用,总计付款,发票情况设备单位1,发票情况设备费1,发票情况设备单位2,发票情况设备费2,发票情况业主,发票情况业主租金,发票情况设计单位,发票情况设计费,发票情况墈察单位,发票情况墈察费,发票情况监理单位,发票情况监理费,发票情况项目管理单位,发票情况项目管理费,发票情况土建施工单位1,发票情况土建施工费1,发票情况土建施工单位2,发票情况土建施工费2,发票情况铁塔加工单位,发票情况铁塔加工费,发票情况安装施工单位,发票情况安装施工费,发票情况外电单位,发票情况外电施工费,发票情况杆体搬运单位,发票情况杆体搬运费,发票情况选址费用单位,发票情况选址费,发票情况其他费用单位,发票情况其他费用,发票情况总计金额,已付款未回发票设备单位1,已付款未回发票设备费1,已付款未回发票设备单位2,已付款未回发票设备费2,已付款未回发票业主,已付款未回发票业主租金,已付款未回发票设计单位,已付款未回发票设计费,已付款未回发票墈察单位,已付款未回发票墈察费,已付款未回发票监理单位,已付款未回发票监理费,已付款未回发票项目管理单位,已付款未回发票项目管理费,已付款未回发票土建施工单位1,已付款未回发票土建施工费1,已付款未回发票土建施工单位2,已付款未回发票土建施工费2,已付款未回发票铁塔加工单位,已付款未回发票铁塔加工费,已付款未回发票安装施工单位,已付款未回发票安装施工费,已付款未回发票外电单位,已付款未回发票外电施工费,已付款未回发票杆体搬运单位,已付款未回发票杆体搬运费,已付款未回发票选址费用单位,已付款未回发票选址费,已付款未回发票其他费用单位,已付款未回发票其他费用,已付款未回发票总计金额,未付款设备单位1,未付款设备费1,未付款设备单位2,未付款设备费2,未付款业主,未付款业主租金,未付款设计单位,未付款设计费,未付款墈察单位,未付款墈察费,未付款监理单位,未付款监理费,未付款项目管理单位,未付款项目管理费,未付款土建施工单位1,未付款土建施工费1,未付款土建施工单位2,未付款土建施工费2,未付款铁塔加工单位,未付款铁塔加工费,未付款安装施工单位,未付款安装施工费,未付款外电单位,未付款外电施工费,未付款杆体搬运单位,未付款杆体搬运费,未付款选址费用单位,未付款选址费,未付款其他费用单位,未付款其他费用,未付款总计金额,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@部门,@区域,@客户名称,@站点编码,@站点名称,@建站类型,@经度,@纬度,@摘牌时间,@进场施工时间,@预计完工时间,@建站周期,@预估运营商收入年租金,@预估运营商收入年限,@预估运营商收入总租金,@伟通收入,@成本设备单位1,@成本设备成本1,@成本设备单位2,@成本设备成本2,@成本场地业主,@成本租赁成本,@成本设计单位,@成本设计成本,@成本地勘单位,@成本地勘成本,@成本监理单位,@成本监理成本,@成本项目管理单位,@成本项目管理成本,@成本土建施工单位1,@成本土建施工成本1,@成本土建施工单位2,@成本土建施工成本2,@成本铁塔加工单位,@成本铁塔加工成本,@成本安装施工单位,@成本安装施工成本,@成本外电单位,@成本外电费,@成本杆体搬运单位,@成本杆体搬运费,@成本选址费用单位,@成本选址费,@成本其他费用单位,@成本其他费用,@总成本,@毛利率,@已付款设备单位1,@已付款设备费1,@已付款设备单位2,@已付款设备费2,@已付款业主,@已付款业主租金,@已付款设计单位,@已付款设计费,@已付款墈察单位,@已付款墈察费,@已付款监理单位,@已付款监理费,@已付款项目管理单位,@已付款项目管理费,@已付款土建施工单位1,@已付款土建施工费1,@已付款土建施工单位2,@已付款土建施工费2,@已付款铁塔加工单位,@已付款铁塔加工费,@已付款安装施工单位,@已付款安装施工费,@已付款外电单位,@已付款外电施工费,@已付款杆体搬运单位,@已付款杆体搬运费,@已付款选址费用单位,@已付款选址费,@已付款其他费用单位,@已付款其他费用,@总计付款,@发票情况设备单位1,@发票情况设备费1,@发票情况设备单位2,@发票情况设备费2,@发票情况业主,@发票情况业主租金,@发票情况设计单位,@发票情况设计费,@发票情况墈察单位,@发票情况墈察费,@发票情况监理单位,@发票情况监理费,@发票情况项目管理单位,@发票情况项目管理费,@发票情况土建施工单位1,@发票情况土建施工费1,@发票情况土建施工单位2,@发票情况土建施工费2,@发票情况铁塔加工单位,@发票情况铁塔加工费,@发票情况安装施工单位,@发票情况安装施工费,@发票情况外电单位,@发票情况外电施工费,@发票情况杆体搬运单位,@发票情况杆体搬运费,@发票情况选址费用单位,@发票情况选址费,@发票情况其他费用单位,@发票情况其他费用,@发票情况总计金额,@已付款未回发票设备单位1,@已付款未回发票设备费1,@已付款未回发票设备单位2,@已付款未回发票设备费2,@已付款未回发票业主,@已付款未回发票业主租金,@已付款未回发票设计单位,@已付款未回发票设计费,@已付款未回发票墈察单位,@已付款未回发票墈察费,@已付款未回发票监理单位,@已付款未回发票监理费,@已付款未回发票项目管理单位,@已付款未回发票项目管理费,@已付款未回发票土建施工单位1,@已付款未回发票土建施工费1,@已付款未回发票土建施工单位2,@已付款未回发票土建施工费2,@已付款未回发票铁塔加工单位,@已付款未回发票铁塔加工费,@已付款未回发票安装施工单位,@已付款未回发票安装施工费,@已付款未回发票外电单位,@已付款未回发票外电施工费,@已付款未回发票杆体搬运单位,@已付款未回发票杆体搬运费,@已付款未回发票选址费用单位,@已付款未回发票选址费,@已付款未回发票其他费用单位,@已付款未回发票其他费用,@已付款未回发票总计金额,@未付款设备单位1,@未付款设备费1,@未付款设备单位2,@未付款设备费2,@未付款业主,@未付款业主租金,@未付款设计单位,@未付款设计费,@未付款墈察单位,@未付款墈察费,@未付款监理单位,@未付款监理费,@未付款项目管理单位,@未付款项目管理费,@未付款土建施工单位1,@未付款土建施工费1,@未付款土建施工单位2,@未付款土建施工费2,@未付款铁塔加工单位,@未付款铁塔加工费,@未付款安装施工单位,@未付款安装施工费,@未付款外电单位,@未付款外电施工费,@未付款杆体搬运单位,@未付款杆体搬运费,@未付款选址费用单位,@未付款选址费,@未付款其他费用单位,@未付款其他费用,@未付款总计金额,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@建站类型", SqlDbType.VarChar,200),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@进场施工时间", SqlDbType.DateTime),
					new SqlParameter("@预计完工时间", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入年租金", SqlDbType.Decimal,9),
					new SqlParameter("@预估运营商收入年限", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入总租金", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本场地业主", SqlDbType.VarChar,200),
					new SqlParameter("@成本租赁成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本设计成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本地勘单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本地勘成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本监理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本项目管理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本铁塔加工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本安装施工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本外电费", SqlDbType.Decimal,9),
					new SqlParameter("@成本杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@成本选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本选址费", SqlDbType.Decimal,9),
					new SqlParameter("@成本其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@成本其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总成本", SqlDbType.Decimal,9),
					new SqlParameter("@毛利率", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总计付款", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况业主", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设计费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况监理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况选址费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@未付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@未付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@未付款总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.部门;
			parameters[2].Value = model.区域;
			parameters[3].Value = model.客户名称;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.站点名称;
			parameters[6].Value = model.建站类型;
			parameters[7].Value = model.经度;
			parameters[8].Value = model.纬度;
			parameters[9].Value = model.摘牌时间;
			parameters[10].Value = model.进场施工时间;
			parameters[11].Value = model.预计完工时间;
			parameters[12].Value = model.建站周期;
			parameters[13].Value = model.预估运营商收入年租金;
			parameters[14].Value = model.预估运营商收入年限;
			parameters[15].Value = model.预估运营商收入总租金;
			parameters[16].Value = model.伟通收入;
			parameters[17].Value = model.成本设备单位1;
			parameters[18].Value = model.成本设备成本1;
			parameters[19].Value = model.成本设备单位2;
			parameters[20].Value = model.成本设备成本2;
			parameters[21].Value = model.成本场地业主;
			parameters[22].Value = model.成本租赁成本;
			parameters[23].Value = model.成本设计单位;
			parameters[24].Value = model.成本设计成本;
			parameters[25].Value = model.成本地勘单位;
			parameters[26].Value = model.成本地勘成本;
			parameters[27].Value = model.成本监理单位;
			parameters[28].Value = model.成本监理成本;
			parameters[29].Value = model.成本项目管理单位;
			parameters[30].Value = model.成本项目管理成本;
			parameters[31].Value = model.成本土建施工单位1;
			parameters[32].Value = model.成本土建施工成本1;
			parameters[33].Value = model.成本土建施工单位2;
			parameters[34].Value = model.成本土建施工成本2;
			parameters[35].Value = model.成本铁塔加工单位;
			parameters[36].Value = model.成本铁塔加工成本;
			parameters[37].Value = model.成本安装施工单位;
			parameters[38].Value = model.成本安装施工成本;
			parameters[39].Value = model.成本外电单位;
			parameters[40].Value = model.成本外电费;
			parameters[41].Value = model.成本杆体搬运单位;
			parameters[42].Value = model.成本杆体搬运费;
			parameters[43].Value = model.成本选址费用单位;
			parameters[44].Value = model.成本选址费;
			parameters[45].Value = model.成本其他费用单位;
			parameters[46].Value = model.成本其他费用;
			parameters[47].Value = model.总成本;
			parameters[48].Value = model.毛利率;
			parameters[49].Value = model.已付款设备单位1;
			parameters[50].Value = model.已付款设备费1;
			parameters[51].Value = model.已付款设备单位2;
			parameters[52].Value = model.已付款设备费2;
			parameters[53].Value = model.已付款业主;
			parameters[54].Value = model.已付款业主租金;
			parameters[55].Value = model.已付款设计单位;
			parameters[56].Value = model.已付款设计费;
			parameters[57].Value = model.已付款墈察单位;
			parameters[58].Value = model.已付款墈察费;
			parameters[59].Value = model.已付款监理单位;
			parameters[60].Value = model.已付款监理费;
			parameters[61].Value = model.已付款项目管理单位;
			parameters[62].Value = model.已付款项目管理费;
			parameters[63].Value = model.已付款土建施工单位1;
			parameters[64].Value = model.已付款土建施工费1;
			parameters[65].Value = model.已付款土建施工单位2;
			parameters[66].Value = model.已付款土建施工费2;
			parameters[67].Value = model.已付款铁塔加工单位;
			parameters[68].Value = model.已付款铁塔加工费;
			parameters[69].Value = model.已付款安装施工单位;
			parameters[70].Value = model.已付款安装施工费;
			parameters[71].Value = model.已付款外电单位;
			parameters[72].Value = model.已付款外电施工费;
			parameters[73].Value = model.已付款杆体搬运单位;
			parameters[74].Value = model.已付款杆体搬运费;
			parameters[75].Value = model.已付款选址费用单位;
			parameters[76].Value = model.已付款选址费;
			parameters[77].Value = model.已付款其他费用单位;
			parameters[78].Value = model.已付款其他费用;
			parameters[79].Value = model.总计付款;
			parameters[80].Value = model.发票情况设备单位1;
			parameters[81].Value = model.发票情况设备费1;
			parameters[82].Value = model.发票情况设备单位2;
			parameters[83].Value = model.发票情况设备费2;
			parameters[84].Value = model.发票情况业主;
			parameters[85].Value = model.发票情况业主租金;
			parameters[86].Value = model.发票情况设计单位;
			parameters[87].Value = model.发票情况设计费;
			parameters[88].Value = model.发票情况墈察单位;
			parameters[89].Value = model.发票情况墈察费;
			parameters[90].Value = model.发票情况监理单位;
			parameters[91].Value = model.发票情况监理费;
			parameters[92].Value = model.发票情况项目管理单位;
			parameters[93].Value = model.发票情况项目管理费;
			parameters[94].Value = model.发票情况土建施工单位1;
			parameters[95].Value = model.发票情况土建施工费1;
			parameters[96].Value = model.发票情况土建施工单位2;
			parameters[97].Value = model.发票情况土建施工费2;
			parameters[98].Value = model.发票情况铁塔加工单位;
			parameters[99].Value = model.发票情况铁塔加工费;
			parameters[100].Value = model.发票情况安装施工单位;
			parameters[101].Value = model.发票情况安装施工费;
			parameters[102].Value = model.发票情况外电单位;
			parameters[103].Value = model.发票情况外电施工费;
			parameters[104].Value = model.发票情况杆体搬运单位;
			parameters[105].Value = model.发票情况杆体搬运费;
			parameters[106].Value = model.发票情况选址费用单位;
			parameters[107].Value = model.发票情况选址费;
			parameters[108].Value = model.发票情况其他费用单位;
			parameters[109].Value = model.发票情况其他费用;
			parameters[110].Value = model.发票情况总计金额;
			parameters[111].Value = model.已付款未回发票设备单位1;
			parameters[112].Value = model.已付款未回发票设备费1;
			parameters[113].Value = model.已付款未回发票设备单位2;
			parameters[114].Value = model.已付款未回发票设备费2;
			parameters[115].Value = model.已付款未回发票业主;
			parameters[116].Value = model.已付款未回发票业主租金;
			parameters[117].Value = model.已付款未回发票设计单位;
			parameters[118].Value = model.已付款未回发票设计费;
			parameters[119].Value = model.已付款未回发票墈察单位;
			parameters[120].Value = model.已付款未回发票墈察费;
			parameters[121].Value = model.已付款未回发票监理单位;
			parameters[122].Value = model.已付款未回发票监理费;
			parameters[123].Value = model.已付款未回发票项目管理单位;
			parameters[124].Value = model.已付款未回发票项目管理费;
			parameters[125].Value = model.已付款未回发票土建施工单位1;
			parameters[126].Value = model.已付款未回发票土建施工费1;
			parameters[127].Value = model.已付款未回发票土建施工单位2;
			parameters[128].Value = model.已付款未回发票土建施工费2;
			parameters[129].Value = model.已付款未回发票铁塔加工单位;
			parameters[130].Value = model.已付款未回发票铁塔加工费;
			parameters[131].Value = model.已付款未回发票安装施工单位;
			parameters[132].Value = model.已付款未回发票安装施工费;
			parameters[133].Value = model.已付款未回发票外电单位;
			parameters[134].Value = model.已付款未回发票外电施工费;
			parameters[135].Value = model.已付款未回发票杆体搬运单位;
			parameters[136].Value = model.已付款未回发票杆体搬运费;
			parameters[137].Value = model.已付款未回发票选址费用单位;
			parameters[138].Value = model.已付款未回发票选址费;
			parameters[139].Value = model.已付款未回发票其他费用单位;
			parameters[140].Value = model.已付款未回发票其他费用;
			parameters[141].Value = model.已付款未回发票总计金额;
			parameters[142].Value = model.未付款设备单位1;
			parameters[143].Value = model.未付款设备费1;
			parameters[144].Value = model.未付款设备单位2;
			parameters[145].Value = model.未付款设备费2;
			parameters[146].Value = model.未付款业主;
			parameters[147].Value = model.未付款业主租金;
			parameters[148].Value = model.未付款设计单位;
			parameters[149].Value = model.未付款设计费;
			parameters[150].Value = model.未付款墈察单位;
			parameters[151].Value = model.未付款墈察费;
			parameters[152].Value = model.未付款监理单位;
			parameters[153].Value = model.未付款监理费;
			parameters[154].Value = model.未付款项目管理单位;
			parameters[155].Value = model.未付款项目管理费;
			parameters[156].Value = model.未付款土建施工单位1;
			parameters[157].Value = model.未付款土建施工费1;
			parameters[158].Value = model.未付款土建施工单位2;
			parameters[159].Value = model.未付款土建施工费2;
			parameters[160].Value = model.未付款铁塔加工单位;
			parameters[161].Value = model.未付款铁塔加工费;
			parameters[162].Value = model.未付款安装施工单位;
			parameters[163].Value = model.未付款安装施工费;
			parameters[164].Value = model.未付款外电单位;
			parameters[165].Value = model.未付款外电施工费;
			parameters[166].Value = model.未付款杆体搬运单位;
			parameters[167].Value = model.未付款杆体搬运费;
			parameters[168].Value = model.未付款选址费用单位;
			parameters[169].Value = model.未付款选址费;
			parameters[170].Value = model.未付款其他费用单位;
			parameters[171].Value = model.未付款其他费用;
			parameters[172].Value = model.未付款总计金额;
			parameters[173].Value = model.备注;
			parameters[174].Value = model.IsDeleted;
			parameters[175].Value = model.CreateBy;
			parameters[176].Value = model.CreateTime;
			parameters[177].Value = model.UpdateBy;
			parameters[178].Value = model.UpdateTime;

			int rows=DbHelperSQL.ExecuteSql(tran,strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WTCJ.Model.YzdjSy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YzdjSy set ");
			strSql.Append("部门=@部门,");
			strSql.Append("区域=@区域,");
			strSql.Append("客户名称=@客户名称,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("建站类型=@建站类型,");
			strSql.Append("经度=@经度,");
			strSql.Append("纬度=@纬度,");
			strSql.Append("摘牌时间=@摘牌时间,");
			strSql.Append("进场施工时间=@进场施工时间,");
			strSql.Append("预计完工时间=@预计完工时间,");
			strSql.Append("建站周期=@建站周期,");
			strSql.Append("预估运营商收入年租金=@预估运营商收入年租金,");
			strSql.Append("预估运营商收入年限=@预估运营商收入年限,");
			strSql.Append("预估运营商收入总租金=@预估运营商收入总租金,");
			strSql.Append("伟通收入=@伟通收入,");
			strSql.Append("成本设备单位1=@成本设备单位1,");
			strSql.Append("成本设备成本1=@成本设备成本1,");
			strSql.Append("成本设备单位2=@成本设备单位2,");
			strSql.Append("成本设备成本2=@成本设备成本2,");
			strSql.Append("成本场地业主=@成本场地业主,");
			strSql.Append("成本租赁成本=@成本租赁成本,");
			strSql.Append("成本设计单位=@成本设计单位,");
			strSql.Append("成本设计成本=@成本设计成本,");
			strSql.Append("成本地勘单位=@成本地勘单位,");
			strSql.Append("成本地勘成本=@成本地勘成本,");
			strSql.Append("成本监理单位=@成本监理单位,");
			strSql.Append("成本监理成本=@成本监理成本,");
			strSql.Append("成本项目管理单位=@成本项目管理单位,");
			strSql.Append("成本项目管理成本=@成本项目管理成本,");
			strSql.Append("成本土建施工单位1=@成本土建施工单位1,");
			strSql.Append("成本土建施工成本1=@成本土建施工成本1,");
			strSql.Append("成本土建施工单位2=@成本土建施工单位2,");
			strSql.Append("成本土建施工成本2=@成本土建施工成本2,");
			strSql.Append("成本铁塔加工单位=@成本铁塔加工单位,");
			strSql.Append("成本铁塔加工成本=@成本铁塔加工成本,");
			strSql.Append("成本安装施工单位=@成本安装施工单位,");
			strSql.Append("成本安装施工成本=@成本安装施工成本,");
			strSql.Append("成本外电单位=@成本外电单位,");
			strSql.Append("成本外电费=@成本外电费,");
			strSql.Append("成本杆体搬运单位=@成本杆体搬运单位,");
			strSql.Append("成本杆体搬运费=@成本杆体搬运费,");
			strSql.Append("成本选址费用单位=@成本选址费用单位,");
			strSql.Append("成本选址费=@成本选址费,");
			strSql.Append("成本其他费用单位=@成本其他费用单位,");
			strSql.Append("成本其他费用=@成本其他费用,");
			strSql.Append("总成本=@总成本,");
			strSql.Append("毛利率=@毛利率,");
			strSql.Append("已付款设备单位1=@已付款设备单位1,");
			strSql.Append("已付款设备费1=@已付款设备费1,");
			strSql.Append("已付款设备单位2=@已付款设备单位2,");
			strSql.Append("已付款设备费2=@已付款设备费2,");
			strSql.Append("已付款业主=@已付款业主,");
			strSql.Append("已付款业主租金=@已付款业主租金,");
			strSql.Append("已付款设计单位=@已付款设计单位,");
			strSql.Append("已付款设计费=@已付款设计费,");
			strSql.Append("已付款墈察单位=@已付款墈察单位,");
			strSql.Append("已付款墈察费=@已付款墈察费,");
			strSql.Append("已付款监理单位=@已付款监理单位,");
			strSql.Append("已付款监理费=@已付款监理费,");
			strSql.Append("已付款项目管理单位=@已付款项目管理单位,");
			strSql.Append("已付款项目管理费=@已付款项目管理费,");
			strSql.Append("已付款土建施工单位1=@已付款土建施工单位1,");
			strSql.Append("已付款土建施工费1=@已付款土建施工费1,");
			strSql.Append("已付款土建施工单位2=@已付款土建施工单位2,");
			strSql.Append("已付款土建施工费2=@已付款土建施工费2,");
			strSql.Append("已付款铁塔加工单位=@已付款铁塔加工单位,");
			strSql.Append("已付款铁塔加工费=@已付款铁塔加工费,");
			strSql.Append("已付款安装施工单位=@已付款安装施工单位,");
			strSql.Append("已付款安装施工费=@已付款安装施工费,");
			strSql.Append("已付款外电单位=@已付款外电单位,");
			strSql.Append("已付款外电施工费=@已付款外电施工费,");
			strSql.Append("已付款杆体搬运单位=@已付款杆体搬运单位,");
			strSql.Append("已付款杆体搬运费=@已付款杆体搬运费,");
			strSql.Append("已付款选址费用单位=@已付款选址费用单位,");
			strSql.Append("已付款选址费=@已付款选址费,");
			strSql.Append("已付款其他费用单位=@已付款其他费用单位,");
			strSql.Append("已付款其他费用=@已付款其他费用,");
			strSql.Append("总计付款=@总计付款,");
			strSql.Append("发票情况设备单位1=@发票情况设备单位1,");
			strSql.Append("发票情况设备费1=@发票情况设备费1,");
			strSql.Append("发票情况设备单位2=@发票情况设备单位2,");
			strSql.Append("发票情况设备费2=@发票情况设备费2,");
			strSql.Append("发票情况业主=@发票情况业主,");
			strSql.Append("发票情况业主租金=@发票情况业主租金,");
			strSql.Append("发票情况设计单位=@发票情况设计单位,");
			strSql.Append("发票情况设计费=@发票情况设计费,");
			strSql.Append("发票情况墈察单位=@发票情况墈察单位,");
			strSql.Append("发票情况墈察费=@发票情况墈察费,");
			strSql.Append("发票情况监理单位=@发票情况监理单位,");
			strSql.Append("发票情况监理费=@发票情况监理费,");
			strSql.Append("发票情况项目管理单位=@发票情况项目管理单位,");
			strSql.Append("发票情况项目管理费=@发票情况项目管理费,");
			strSql.Append("发票情况土建施工单位1=@发票情况土建施工单位1,");
			strSql.Append("发票情况土建施工费1=@发票情况土建施工费1,");
			strSql.Append("发票情况土建施工单位2=@发票情况土建施工单位2,");
			strSql.Append("发票情况土建施工费2=@发票情况土建施工费2,");
			strSql.Append("发票情况铁塔加工单位=@发票情况铁塔加工单位,");
			strSql.Append("发票情况铁塔加工费=@发票情况铁塔加工费,");
			strSql.Append("发票情况安装施工单位=@发票情况安装施工单位,");
			strSql.Append("发票情况安装施工费=@发票情况安装施工费,");
			strSql.Append("发票情况外电单位=@发票情况外电单位,");
			strSql.Append("发票情况外电施工费=@发票情况外电施工费,");
			strSql.Append("发票情况杆体搬运单位=@发票情况杆体搬运单位,");
			strSql.Append("发票情况杆体搬运费=@发票情况杆体搬运费,");
			strSql.Append("发票情况选址费用单位=@发票情况选址费用单位,");
			strSql.Append("发票情况选址费=@发票情况选址费,");
			strSql.Append("发票情况其他费用单位=@发票情况其他费用单位,");
			strSql.Append("发票情况其他费用=@发票情况其他费用,");
			strSql.Append("发票情况总计金额=@发票情况总计金额,");
			strSql.Append("已付款未回发票设备单位1=@已付款未回发票设备单位1,");
			strSql.Append("已付款未回发票设备费1=@已付款未回发票设备费1,");
			strSql.Append("已付款未回发票设备单位2=@已付款未回发票设备单位2,");
			strSql.Append("已付款未回发票设备费2=@已付款未回发票设备费2,");
			strSql.Append("已付款未回发票业主=@已付款未回发票业主,");
			strSql.Append("已付款未回发票业主租金=@已付款未回发票业主租金,");
			strSql.Append("已付款未回发票设计单位=@已付款未回发票设计单位,");
			strSql.Append("已付款未回发票设计费=@已付款未回发票设计费,");
			strSql.Append("已付款未回发票墈察单位=@已付款未回发票墈察单位,");
			strSql.Append("已付款未回发票墈察费=@已付款未回发票墈察费,");
			strSql.Append("已付款未回发票监理单位=@已付款未回发票监理单位,");
			strSql.Append("已付款未回发票监理费=@已付款未回发票监理费,");
			strSql.Append("已付款未回发票项目管理单位=@已付款未回发票项目管理单位,");
			strSql.Append("已付款未回发票项目管理费=@已付款未回发票项目管理费,");
			strSql.Append("已付款未回发票土建施工单位1=@已付款未回发票土建施工单位1,");
			strSql.Append("已付款未回发票土建施工费1=@已付款未回发票土建施工费1,");
			strSql.Append("已付款未回发票土建施工单位2=@已付款未回发票土建施工单位2,");
			strSql.Append("已付款未回发票土建施工费2=@已付款未回发票土建施工费2,");
			strSql.Append("已付款未回发票铁塔加工单位=@已付款未回发票铁塔加工单位,");
			strSql.Append("已付款未回发票铁塔加工费=@已付款未回发票铁塔加工费,");
			strSql.Append("已付款未回发票安装施工单位=@已付款未回发票安装施工单位,");
			strSql.Append("已付款未回发票安装施工费=@已付款未回发票安装施工费,");
			strSql.Append("已付款未回发票外电单位=@已付款未回发票外电单位,");
			strSql.Append("已付款未回发票外电施工费=@已付款未回发票外电施工费,");
			strSql.Append("已付款未回发票杆体搬运单位=@已付款未回发票杆体搬运单位,");
			strSql.Append("已付款未回发票杆体搬运费=@已付款未回发票杆体搬运费,");
			strSql.Append("已付款未回发票选址费用单位=@已付款未回发票选址费用单位,");
			strSql.Append("已付款未回发票选址费=@已付款未回发票选址费,");
			strSql.Append("已付款未回发票其他费用单位=@已付款未回发票其他费用单位,");
			strSql.Append("已付款未回发票其他费用=@已付款未回发票其他费用,");
			strSql.Append("已付款未回发票总计金额=@已付款未回发票总计金额,");
			strSql.Append("未付款设备单位1=@未付款设备单位1,");
			strSql.Append("未付款设备费1=@未付款设备费1,");
			strSql.Append("未付款设备单位2=@未付款设备单位2,");
			strSql.Append("未付款设备费2=@未付款设备费2,");
			strSql.Append("未付款业主=@未付款业主,");
			strSql.Append("未付款业主租金=@未付款业主租金,");
			strSql.Append("未付款设计单位=@未付款设计单位,");
			strSql.Append("未付款设计费=@未付款设计费,");
			strSql.Append("未付款墈察单位=@未付款墈察单位,");
			strSql.Append("未付款墈察费=@未付款墈察费,");
			strSql.Append("未付款监理单位=@未付款监理单位,");
			strSql.Append("未付款监理费=@未付款监理费,");
			strSql.Append("未付款项目管理单位=@未付款项目管理单位,");
			strSql.Append("未付款项目管理费=@未付款项目管理费,");
			strSql.Append("未付款土建施工单位1=@未付款土建施工单位1,");
			strSql.Append("未付款土建施工费1=@未付款土建施工费1,");
			strSql.Append("未付款土建施工单位2=@未付款土建施工单位2,");
			strSql.Append("未付款土建施工费2=@未付款土建施工费2,");
			strSql.Append("未付款铁塔加工单位=@未付款铁塔加工单位,");
			strSql.Append("未付款铁塔加工费=@未付款铁塔加工费,");
			strSql.Append("未付款安装施工单位=@未付款安装施工单位,");
			strSql.Append("未付款安装施工费=@未付款安装施工费,");
			strSql.Append("未付款外电单位=@未付款外电单位,");
			strSql.Append("未付款外电施工费=@未付款外电施工费,");
			strSql.Append("未付款杆体搬运单位=@未付款杆体搬运单位,");
			strSql.Append("未付款杆体搬运费=@未付款杆体搬运费,");
			strSql.Append("未付款选址费用单位=@未付款选址费用单位,");
			strSql.Append("未付款选址费=@未付款选址费,");
			strSql.Append("未付款其他费用单位=@未付款其他费用单位,");
			strSql.Append("未付款其他费用=@未付款其他费用,");
			strSql.Append("未付款总计金额=@未付款总计金额,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@建站类型", SqlDbType.VarChar,200),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@进场施工时间", SqlDbType.DateTime),
					new SqlParameter("@预计完工时间", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入年租金", SqlDbType.Decimal,9),
					new SqlParameter("@预估运营商收入年限", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入总租金", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本场地业主", SqlDbType.VarChar,200),
					new SqlParameter("@成本租赁成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本设计成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本地勘单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本地勘成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本监理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本项目管理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本铁塔加工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本安装施工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本外电费", SqlDbType.Decimal,9),
					new SqlParameter("@成本杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@成本选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本选址费", SqlDbType.Decimal,9),
					new SqlParameter("@成本其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@成本其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总成本", SqlDbType.Decimal,9),
					new SqlParameter("@毛利率", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总计付款", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况业主", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设计费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况监理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况选址费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@未付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@未付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@未付款总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.部门;
			parameters[1].Value = model.区域;
			parameters[2].Value = model.客户名称;
			parameters[3].Value = model.站点编码;
			parameters[4].Value = model.站点名称;
			parameters[5].Value = model.建站类型;
			parameters[6].Value = model.经度;
			parameters[7].Value = model.纬度;
			parameters[8].Value = model.摘牌时间;
			parameters[9].Value = model.进场施工时间;
			parameters[10].Value = model.预计完工时间;
			parameters[11].Value = model.建站周期;
			parameters[12].Value = model.预估运营商收入年租金;
			parameters[13].Value = model.预估运营商收入年限;
			parameters[14].Value = model.预估运营商收入总租金;
			parameters[15].Value = model.伟通收入;
			parameters[16].Value = model.成本设备单位1;
			parameters[17].Value = model.成本设备成本1;
			parameters[18].Value = model.成本设备单位2;
			parameters[19].Value = model.成本设备成本2;
			parameters[20].Value = model.成本场地业主;
			parameters[21].Value = model.成本租赁成本;
			parameters[22].Value = model.成本设计单位;
			parameters[23].Value = model.成本设计成本;
			parameters[24].Value = model.成本地勘单位;
			parameters[25].Value = model.成本地勘成本;
			parameters[26].Value = model.成本监理单位;
			parameters[27].Value = model.成本监理成本;
			parameters[28].Value = model.成本项目管理单位;
			parameters[29].Value = model.成本项目管理成本;
			parameters[30].Value = model.成本土建施工单位1;
			parameters[31].Value = model.成本土建施工成本1;
			parameters[32].Value = model.成本土建施工单位2;
			parameters[33].Value = model.成本土建施工成本2;
			parameters[34].Value = model.成本铁塔加工单位;
			parameters[35].Value = model.成本铁塔加工成本;
			parameters[36].Value = model.成本安装施工单位;
			parameters[37].Value = model.成本安装施工成本;
			parameters[38].Value = model.成本外电单位;
			parameters[39].Value = model.成本外电费;
			parameters[40].Value = model.成本杆体搬运单位;
			parameters[41].Value = model.成本杆体搬运费;
			parameters[42].Value = model.成本选址费用单位;
			parameters[43].Value = model.成本选址费;
			parameters[44].Value = model.成本其他费用单位;
			parameters[45].Value = model.成本其他费用;
			parameters[46].Value = model.总成本;
			parameters[47].Value = model.毛利率;
			parameters[48].Value = model.已付款设备单位1;
			parameters[49].Value = model.已付款设备费1;
			parameters[50].Value = model.已付款设备单位2;
			parameters[51].Value = model.已付款设备费2;
			parameters[52].Value = model.已付款业主;
			parameters[53].Value = model.已付款业主租金;
			parameters[54].Value = model.已付款设计单位;
			parameters[55].Value = model.已付款设计费;
			parameters[56].Value = model.已付款墈察单位;
			parameters[57].Value = model.已付款墈察费;
			parameters[58].Value = model.已付款监理单位;
			parameters[59].Value = model.已付款监理费;
			parameters[60].Value = model.已付款项目管理单位;
			parameters[61].Value = model.已付款项目管理费;
			parameters[62].Value = model.已付款土建施工单位1;
			parameters[63].Value = model.已付款土建施工费1;
			parameters[64].Value = model.已付款土建施工单位2;
			parameters[65].Value = model.已付款土建施工费2;
			parameters[66].Value = model.已付款铁塔加工单位;
			parameters[67].Value = model.已付款铁塔加工费;
			parameters[68].Value = model.已付款安装施工单位;
			parameters[69].Value = model.已付款安装施工费;
			parameters[70].Value = model.已付款外电单位;
			parameters[71].Value = model.已付款外电施工费;
			parameters[72].Value = model.已付款杆体搬运单位;
			parameters[73].Value = model.已付款杆体搬运费;
			parameters[74].Value = model.已付款选址费用单位;
			parameters[75].Value = model.已付款选址费;
			parameters[76].Value = model.已付款其他费用单位;
			parameters[77].Value = model.已付款其他费用;
			parameters[78].Value = model.总计付款;
			parameters[79].Value = model.发票情况设备单位1;
			parameters[80].Value = model.发票情况设备费1;
			parameters[81].Value = model.发票情况设备单位2;
			parameters[82].Value = model.发票情况设备费2;
			parameters[83].Value = model.发票情况业主;
			parameters[84].Value = model.发票情况业主租金;
			parameters[85].Value = model.发票情况设计单位;
			parameters[86].Value = model.发票情况设计费;
			parameters[87].Value = model.发票情况墈察单位;
			parameters[88].Value = model.发票情况墈察费;
			parameters[89].Value = model.发票情况监理单位;
			parameters[90].Value = model.发票情况监理费;
			parameters[91].Value = model.发票情况项目管理单位;
			parameters[92].Value = model.发票情况项目管理费;
			parameters[93].Value = model.发票情况土建施工单位1;
			parameters[94].Value = model.发票情况土建施工费1;
			parameters[95].Value = model.发票情况土建施工单位2;
			parameters[96].Value = model.发票情况土建施工费2;
			parameters[97].Value = model.发票情况铁塔加工单位;
			parameters[98].Value = model.发票情况铁塔加工费;
			parameters[99].Value = model.发票情况安装施工单位;
			parameters[100].Value = model.发票情况安装施工费;
			parameters[101].Value = model.发票情况外电单位;
			parameters[102].Value = model.发票情况外电施工费;
			parameters[103].Value = model.发票情况杆体搬运单位;
			parameters[104].Value = model.发票情况杆体搬运费;
			parameters[105].Value = model.发票情况选址费用单位;
			parameters[106].Value = model.发票情况选址费;
			parameters[107].Value = model.发票情况其他费用单位;
			parameters[108].Value = model.发票情况其他费用;
			parameters[109].Value = model.发票情况总计金额;
			parameters[110].Value = model.已付款未回发票设备单位1;
			parameters[111].Value = model.已付款未回发票设备费1;
			parameters[112].Value = model.已付款未回发票设备单位2;
			parameters[113].Value = model.已付款未回发票设备费2;
			parameters[114].Value = model.已付款未回发票业主;
			parameters[115].Value = model.已付款未回发票业主租金;
			parameters[116].Value = model.已付款未回发票设计单位;
			parameters[117].Value = model.已付款未回发票设计费;
			parameters[118].Value = model.已付款未回发票墈察单位;
			parameters[119].Value = model.已付款未回发票墈察费;
			parameters[120].Value = model.已付款未回发票监理单位;
			parameters[121].Value = model.已付款未回发票监理费;
			parameters[122].Value = model.已付款未回发票项目管理单位;
			parameters[123].Value = model.已付款未回发票项目管理费;
			parameters[124].Value = model.已付款未回发票土建施工单位1;
			parameters[125].Value = model.已付款未回发票土建施工费1;
			parameters[126].Value = model.已付款未回发票土建施工单位2;
			parameters[127].Value = model.已付款未回发票土建施工费2;
			parameters[128].Value = model.已付款未回发票铁塔加工单位;
			parameters[129].Value = model.已付款未回发票铁塔加工费;
			parameters[130].Value = model.已付款未回发票安装施工单位;
			parameters[131].Value = model.已付款未回发票安装施工费;
			parameters[132].Value = model.已付款未回发票外电单位;
			parameters[133].Value = model.已付款未回发票外电施工费;
			parameters[134].Value = model.已付款未回发票杆体搬运单位;
			parameters[135].Value = model.已付款未回发票杆体搬运费;
			parameters[136].Value = model.已付款未回发票选址费用单位;
			parameters[137].Value = model.已付款未回发票选址费;
			parameters[138].Value = model.已付款未回发票其他费用单位;
			parameters[139].Value = model.已付款未回发票其他费用;
			parameters[140].Value = model.已付款未回发票总计金额;
			parameters[141].Value = model.未付款设备单位1;
			parameters[142].Value = model.未付款设备费1;
			parameters[143].Value = model.未付款设备单位2;
			parameters[144].Value = model.未付款设备费2;
			parameters[145].Value = model.未付款业主;
			parameters[146].Value = model.未付款业主租金;
			parameters[147].Value = model.未付款设计单位;
			parameters[148].Value = model.未付款设计费;
			parameters[149].Value = model.未付款墈察单位;
			parameters[150].Value = model.未付款墈察费;
			parameters[151].Value = model.未付款监理单位;
			parameters[152].Value = model.未付款监理费;
			parameters[153].Value = model.未付款项目管理单位;
			parameters[154].Value = model.未付款项目管理费;
			parameters[155].Value = model.未付款土建施工单位1;
			parameters[156].Value = model.未付款土建施工费1;
			parameters[157].Value = model.未付款土建施工单位2;
			parameters[158].Value = model.未付款土建施工费2;
			parameters[159].Value = model.未付款铁塔加工单位;
			parameters[160].Value = model.未付款铁塔加工费;
			parameters[161].Value = model.未付款安装施工单位;
			parameters[162].Value = model.未付款安装施工费;
			parameters[163].Value = model.未付款外电单位;
			parameters[164].Value = model.未付款外电施工费;
			parameters[165].Value = model.未付款杆体搬运单位;
			parameters[166].Value = model.未付款杆体搬运费;
			parameters[167].Value = model.未付款选址费用单位;
			parameters[168].Value = model.未付款选址费;
			parameters[169].Value = model.未付款其他费用单位;
			parameters[170].Value = model.未付款其他费用;
			parameters[171].Value = model.未付款总计金额;
			parameters[172].Value = model.备注;
			parameters[173].Value = model.IsDeleted;
			parameters[174].Value = model.CreateBy;
			parameters[175].Value = model.CreateTime;
			parameters[176].Value = model.UpdateBy;
			parameters[177].Value = model.UpdateTime;
			parameters[178].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SqlTransaction tran,WTCJ.Model.YzdjSy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YzdjSy set ");
			strSql.Append("部门=@部门,");
			strSql.Append("区域=@区域,");
			strSql.Append("客户名称=@客户名称,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("建站类型=@建站类型,");
			strSql.Append("经度=@经度,");
			strSql.Append("纬度=@纬度,");
			strSql.Append("摘牌时间=@摘牌时间,");
			strSql.Append("进场施工时间=@进场施工时间,");
			strSql.Append("预计完工时间=@预计完工时间,");
			strSql.Append("建站周期=@建站周期,");
			strSql.Append("预估运营商收入年租金=@预估运营商收入年租金,");
			strSql.Append("预估运营商收入年限=@预估运营商收入年限,");
			strSql.Append("预估运营商收入总租金=@预估运营商收入总租金,");
			strSql.Append("伟通收入=@伟通收入,");
			strSql.Append("成本设备单位1=@成本设备单位1,");
			strSql.Append("成本设备成本1=@成本设备成本1,");
			strSql.Append("成本设备单位2=@成本设备单位2,");
			strSql.Append("成本设备成本2=@成本设备成本2,");
			strSql.Append("成本场地业主=@成本场地业主,");
			strSql.Append("成本租赁成本=@成本租赁成本,");
			strSql.Append("成本设计单位=@成本设计单位,");
			strSql.Append("成本设计成本=@成本设计成本,");
			strSql.Append("成本地勘单位=@成本地勘单位,");
			strSql.Append("成本地勘成本=@成本地勘成本,");
			strSql.Append("成本监理单位=@成本监理单位,");
			strSql.Append("成本监理成本=@成本监理成本,");
			strSql.Append("成本项目管理单位=@成本项目管理单位,");
			strSql.Append("成本项目管理成本=@成本项目管理成本,");
			strSql.Append("成本土建施工单位1=@成本土建施工单位1,");
			strSql.Append("成本土建施工成本1=@成本土建施工成本1,");
			strSql.Append("成本土建施工单位2=@成本土建施工单位2,");
			strSql.Append("成本土建施工成本2=@成本土建施工成本2,");
			strSql.Append("成本铁塔加工单位=@成本铁塔加工单位,");
			strSql.Append("成本铁塔加工成本=@成本铁塔加工成本,");
			strSql.Append("成本安装施工单位=@成本安装施工单位,");
			strSql.Append("成本安装施工成本=@成本安装施工成本,");
			strSql.Append("成本外电单位=@成本外电单位,");
			strSql.Append("成本外电费=@成本外电费,");
			strSql.Append("成本杆体搬运单位=@成本杆体搬运单位,");
			strSql.Append("成本杆体搬运费=@成本杆体搬运费,");
			strSql.Append("成本选址费用单位=@成本选址费用单位,");
			strSql.Append("成本选址费=@成本选址费,");
			strSql.Append("成本其他费用单位=@成本其他费用单位,");
			strSql.Append("成本其他费用=@成本其他费用,");
			strSql.Append("总成本=@总成本,");
			strSql.Append("毛利率=@毛利率,");
			strSql.Append("已付款设备单位1=@已付款设备单位1,");
			strSql.Append("已付款设备费1=@已付款设备费1,");
			strSql.Append("已付款设备单位2=@已付款设备单位2,");
			strSql.Append("已付款设备费2=@已付款设备费2,");
			strSql.Append("已付款业主=@已付款业主,");
			strSql.Append("已付款业主租金=@已付款业主租金,");
			strSql.Append("已付款设计单位=@已付款设计单位,");
			strSql.Append("已付款设计费=@已付款设计费,");
			strSql.Append("已付款墈察单位=@已付款墈察单位,");
			strSql.Append("已付款墈察费=@已付款墈察费,");
			strSql.Append("已付款监理单位=@已付款监理单位,");
			strSql.Append("已付款监理费=@已付款监理费,");
			strSql.Append("已付款项目管理单位=@已付款项目管理单位,");
			strSql.Append("已付款项目管理费=@已付款项目管理费,");
			strSql.Append("已付款土建施工单位1=@已付款土建施工单位1,");
			strSql.Append("已付款土建施工费1=@已付款土建施工费1,");
			strSql.Append("已付款土建施工单位2=@已付款土建施工单位2,");
			strSql.Append("已付款土建施工费2=@已付款土建施工费2,");
			strSql.Append("已付款铁塔加工单位=@已付款铁塔加工单位,");
			strSql.Append("已付款铁塔加工费=@已付款铁塔加工费,");
			strSql.Append("已付款安装施工单位=@已付款安装施工单位,");
			strSql.Append("已付款安装施工费=@已付款安装施工费,");
			strSql.Append("已付款外电单位=@已付款外电单位,");
			strSql.Append("已付款外电施工费=@已付款外电施工费,");
			strSql.Append("已付款杆体搬运单位=@已付款杆体搬运单位,");
			strSql.Append("已付款杆体搬运费=@已付款杆体搬运费,");
			strSql.Append("已付款选址费用单位=@已付款选址费用单位,");
			strSql.Append("已付款选址费=@已付款选址费,");
			strSql.Append("已付款其他费用单位=@已付款其他费用单位,");
			strSql.Append("已付款其他费用=@已付款其他费用,");
			strSql.Append("总计付款=@总计付款,");
			strSql.Append("发票情况设备单位1=@发票情况设备单位1,");
			strSql.Append("发票情况设备费1=@发票情况设备费1,");
			strSql.Append("发票情况设备单位2=@发票情况设备单位2,");
			strSql.Append("发票情况设备费2=@发票情况设备费2,");
			strSql.Append("发票情况业主=@发票情况业主,");
			strSql.Append("发票情况业主租金=@发票情况业主租金,");
			strSql.Append("发票情况设计单位=@发票情况设计单位,");
			strSql.Append("发票情况设计费=@发票情况设计费,");
			strSql.Append("发票情况墈察单位=@发票情况墈察单位,");
			strSql.Append("发票情况墈察费=@发票情况墈察费,");
			strSql.Append("发票情况监理单位=@发票情况监理单位,");
			strSql.Append("发票情况监理费=@发票情况监理费,");
			strSql.Append("发票情况项目管理单位=@发票情况项目管理单位,");
			strSql.Append("发票情况项目管理费=@发票情况项目管理费,");
			strSql.Append("发票情况土建施工单位1=@发票情况土建施工单位1,");
			strSql.Append("发票情况土建施工费1=@发票情况土建施工费1,");
			strSql.Append("发票情况土建施工单位2=@发票情况土建施工单位2,");
			strSql.Append("发票情况土建施工费2=@发票情况土建施工费2,");
			strSql.Append("发票情况铁塔加工单位=@发票情况铁塔加工单位,");
			strSql.Append("发票情况铁塔加工费=@发票情况铁塔加工费,");
			strSql.Append("发票情况安装施工单位=@发票情况安装施工单位,");
			strSql.Append("发票情况安装施工费=@发票情况安装施工费,");
			strSql.Append("发票情况外电单位=@发票情况外电单位,");
			strSql.Append("发票情况外电施工费=@发票情况外电施工费,");
			strSql.Append("发票情况杆体搬运单位=@发票情况杆体搬运单位,");
			strSql.Append("发票情况杆体搬运费=@发票情况杆体搬运费,");
			strSql.Append("发票情况选址费用单位=@发票情况选址费用单位,");
			strSql.Append("发票情况选址费=@发票情况选址费,");
			strSql.Append("发票情况其他费用单位=@发票情况其他费用单位,");
			strSql.Append("发票情况其他费用=@发票情况其他费用,");
			strSql.Append("发票情况总计金额=@发票情况总计金额,");
			strSql.Append("已付款未回发票设备单位1=@已付款未回发票设备单位1,");
			strSql.Append("已付款未回发票设备费1=@已付款未回发票设备费1,");
			strSql.Append("已付款未回发票设备单位2=@已付款未回发票设备单位2,");
			strSql.Append("已付款未回发票设备费2=@已付款未回发票设备费2,");
			strSql.Append("已付款未回发票业主=@已付款未回发票业主,");
			strSql.Append("已付款未回发票业主租金=@已付款未回发票业主租金,");
			strSql.Append("已付款未回发票设计单位=@已付款未回发票设计单位,");
			strSql.Append("已付款未回发票设计费=@已付款未回发票设计费,");
			strSql.Append("已付款未回发票墈察单位=@已付款未回发票墈察单位,");
			strSql.Append("已付款未回发票墈察费=@已付款未回发票墈察费,");
			strSql.Append("已付款未回发票监理单位=@已付款未回发票监理单位,");
			strSql.Append("已付款未回发票监理费=@已付款未回发票监理费,");
			strSql.Append("已付款未回发票项目管理单位=@已付款未回发票项目管理单位,");
			strSql.Append("已付款未回发票项目管理费=@已付款未回发票项目管理费,");
			strSql.Append("已付款未回发票土建施工单位1=@已付款未回发票土建施工单位1,");
			strSql.Append("已付款未回发票土建施工费1=@已付款未回发票土建施工费1,");
			strSql.Append("已付款未回发票土建施工单位2=@已付款未回发票土建施工单位2,");
			strSql.Append("已付款未回发票土建施工费2=@已付款未回发票土建施工费2,");
			strSql.Append("已付款未回发票铁塔加工单位=@已付款未回发票铁塔加工单位,");
			strSql.Append("已付款未回发票铁塔加工费=@已付款未回发票铁塔加工费,");
			strSql.Append("已付款未回发票安装施工单位=@已付款未回发票安装施工单位,");
			strSql.Append("已付款未回发票安装施工费=@已付款未回发票安装施工费,");
			strSql.Append("已付款未回发票外电单位=@已付款未回发票外电单位,");
			strSql.Append("已付款未回发票外电施工费=@已付款未回发票外电施工费,");
			strSql.Append("已付款未回发票杆体搬运单位=@已付款未回发票杆体搬运单位,");
			strSql.Append("已付款未回发票杆体搬运费=@已付款未回发票杆体搬运费,");
			strSql.Append("已付款未回发票选址费用单位=@已付款未回发票选址费用单位,");
			strSql.Append("已付款未回发票选址费=@已付款未回发票选址费,");
			strSql.Append("已付款未回发票其他费用单位=@已付款未回发票其他费用单位,");
			strSql.Append("已付款未回发票其他费用=@已付款未回发票其他费用,");
			strSql.Append("已付款未回发票总计金额=@已付款未回发票总计金额,");
			strSql.Append("未付款设备单位1=@未付款设备单位1,");
			strSql.Append("未付款设备费1=@未付款设备费1,");
			strSql.Append("未付款设备单位2=@未付款设备单位2,");
			strSql.Append("未付款设备费2=@未付款设备费2,");
			strSql.Append("未付款业主=@未付款业主,");
			strSql.Append("未付款业主租金=@未付款业主租金,");
			strSql.Append("未付款设计单位=@未付款设计单位,");
			strSql.Append("未付款设计费=@未付款设计费,");
			strSql.Append("未付款墈察单位=@未付款墈察单位,");
			strSql.Append("未付款墈察费=@未付款墈察费,");
			strSql.Append("未付款监理单位=@未付款监理单位,");
			strSql.Append("未付款监理费=@未付款监理费,");
			strSql.Append("未付款项目管理单位=@未付款项目管理单位,");
			strSql.Append("未付款项目管理费=@未付款项目管理费,");
			strSql.Append("未付款土建施工单位1=@未付款土建施工单位1,");
			strSql.Append("未付款土建施工费1=@未付款土建施工费1,");
			strSql.Append("未付款土建施工单位2=@未付款土建施工单位2,");
			strSql.Append("未付款土建施工费2=@未付款土建施工费2,");
			strSql.Append("未付款铁塔加工单位=@未付款铁塔加工单位,");
			strSql.Append("未付款铁塔加工费=@未付款铁塔加工费,");
			strSql.Append("未付款安装施工单位=@未付款安装施工单位,");
			strSql.Append("未付款安装施工费=@未付款安装施工费,");
			strSql.Append("未付款外电单位=@未付款外电单位,");
			strSql.Append("未付款外电施工费=@未付款外电施工费,");
			strSql.Append("未付款杆体搬运单位=@未付款杆体搬运单位,");
			strSql.Append("未付款杆体搬运费=@未付款杆体搬运费,");
			strSql.Append("未付款选址费用单位=@未付款选址费用单位,");
			strSql.Append("未付款选址费=@未付款选址费,");
			strSql.Append("未付款其他费用单位=@未付款其他费用单位,");
			strSql.Append("未付款其他费用=@未付款其他费用,");
			strSql.Append("未付款总计金额=@未付款总计金额,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@建站类型", SqlDbType.VarChar,200),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@进场施工时间", SqlDbType.DateTime),
					new SqlParameter("@预计完工时间", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入年租金", SqlDbType.Decimal,9),
					new SqlParameter("@预估运营商收入年限", SqlDbType.Int,4),
					new SqlParameter("@预估运营商收入总租金", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本设备成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本场地业主", SqlDbType.VarChar,200),
					new SqlParameter("@成本租赁成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本设计成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本地勘单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本地勘成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本监理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本项目管理成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本1", SqlDbType.Decimal,9),
					new SqlParameter("@成本土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@成本土建施工成本2", SqlDbType.Decimal,9),
					new SqlParameter("@成本铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本铁塔加工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本安装施工成本", SqlDbType.Decimal,9),
					new SqlParameter("@成本外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本外电费", SqlDbType.Decimal,9),
					new SqlParameter("@成本杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@成本选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@成本选址费", SqlDbType.Decimal,9),
					new SqlParameter("@成本其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@成本其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总成本", SqlDbType.Decimal,9),
					new SqlParameter("@毛利率", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@总计付款", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况业主", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况设计费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况监理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@发票情况选址费", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@发票情况其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@发票情况总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票业主", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票设计费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票监理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@已付款未回发票选址费", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@已付款未回发票其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@已付款未回发票总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设备单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设备费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款业主", SqlDbType.VarChar,200),
					new SqlParameter("@未付款业主租金", SqlDbType.Decimal,9),
					new SqlParameter("@未付款设计单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款设计费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款墈察单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款墈察费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款监理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款监理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款项目管理单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款项目管理费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位1", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费1", SqlDbType.Decimal,9),
					new SqlParameter("@未付款土建施工单位2", SqlDbType.VarChar,36),
					new SqlParameter("@未付款土建施工费2", SqlDbType.Decimal,9),
					new SqlParameter("@未付款铁塔加工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款铁塔加工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款安装施工单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款安装施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款外电单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款外电施工费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款杆体搬运单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款杆体搬运费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款选址费用单位", SqlDbType.VarChar,36),
					new SqlParameter("@未付款选址费", SqlDbType.Decimal,9),
					new SqlParameter("@未付款其他费用单位", SqlDbType.VarChar,200),
					new SqlParameter("@未付款其他费用", SqlDbType.Decimal,9),
					new SqlParameter("@未付款总计金额", SqlDbType.Decimal,9),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.部门;
			parameters[1].Value = model.区域;
			parameters[2].Value = model.客户名称;
			parameters[3].Value = model.站点编码;
			parameters[4].Value = model.站点名称;
			parameters[5].Value = model.建站类型;
			parameters[6].Value = model.经度;
			parameters[7].Value = model.纬度;
			parameters[8].Value = model.摘牌时间;
			parameters[9].Value = model.进场施工时间;
			parameters[10].Value = model.预计完工时间;
			parameters[11].Value = model.建站周期;
			parameters[12].Value = model.预估运营商收入年租金;
			parameters[13].Value = model.预估运营商收入年限;
			parameters[14].Value = model.预估运营商收入总租金;
			parameters[15].Value = model.伟通收入;
			parameters[16].Value = model.成本设备单位1;
			parameters[17].Value = model.成本设备成本1;
			parameters[18].Value = model.成本设备单位2;
			parameters[19].Value = model.成本设备成本2;
			parameters[20].Value = model.成本场地业主;
			parameters[21].Value = model.成本租赁成本;
			parameters[22].Value = model.成本设计单位;
			parameters[23].Value = model.成本设计成本;
			parameters[24].Value = model.成本地勘单位;
			parameters[25].Value = model.成本地勘成本;
			parameters[26].Value = model.成本监理单位;
			parameters[27].Value = model.成本监理成本;
			parameters[28].Value = model.成本项目管理单位;
			parameters[29].Value = model.成本项目管理成本;
			parameters[30].Value = model.成本土建施工单位1;
			parameters[31].Value = model.成本土建施工成本1;
			parameters[32].Value = model.成本土建施工单位2;
			parameters[33].Value = model.成本土建施工成本2;
			parameters[34].Value = model.成本铁塔加工单位;
			parameters[35].Value = model.成本铁塔加工成本;
			parameters[36].Value = model.成本安装施工单位;
			parameters[37].Value = model.成本安装施工成本;
			parameters[38].Value = model.成本外电单位;
			parameters[39].Value = model.成本外电费;
			parameters[40].Value = model.成本杆体搬运单位;
			parameters[41].Value = model.成本杆体搬运费;
			parameters[42].Value = model.成本选址费用单位;
			parameters[43].Value = model.成本选址费;
			parameters[44].Value = model.成本其他费用单位;
			parameters[45].Value = model.成本其他费用;
			parameters[46].Value = model.总成本;
			parameters[47].Value = model.毛利率;
			parameters[48].Value = model.已付款设备单位1;
			parameters[49].Value = model.已付款设备费1;
			parameters[50].Value = model.已付款设备单位2;
			parameters[51].Value = model.已付款设备费2;
			parameters[52].Value = model.已付款业主;
			parameters[53].Value = model.已付款业主租金;
			parameters[54].Value = model.已付款设计单位;
			parameters[55].Value = model.已付款设计费;
			parameters[56].Value = model.已付款墈察单位;
			parameters[57].Value = model.已付款墈察费;
			parameters[58].Value = model.已付款监理单位;
			parameters[59].Value = model.已付款监理费;
			parameters[60].Value = model.已付款项目管理单位;
			parameters[61].Value = model.已付款项目管理费;
			parameters[62].Value = model.已付款土建施工单位1;
			parameters[63].Value = model.已付款土建施工费1;
			parameters[64].Value = model.已付款土建施工单位2;
			parameters[65].Value = model.已付款土建施工费2;
			parameters[66].Value = model.已付款铁塔加工单位;
			parameters[67].Value = model.已付款铁塔加工费;
			parameters[68].Value = model.已付款安装施工单位;
			parameters[69].Value = model.已付款安装施工费;
			parameters[70].Value = model.已付款外电单位;
			parameters[71].Value = model.已付款外电施工费;
			parameters[72].Value = model.已付款杆体搬运单位;
			parameters[73].Value = model.已付款杆体搬运费;
			parameters[74].Value = model.已付款选址费用单位;
			parameters[75].Value = model.已付款选址费;
			parameters[76].Value = model.已付款其他费用单位;
			parameters[77].Value = model.已付款其他费用;
			parameters[78].Value = model.总计付款;
			parameters[79].Value = model.发票情况设备单位1;
			parameters[80].Value = model.发票情况设备费1;
			parameters[81].Value = model.发票情况设备单位2;
			parameters[82].Value = model.发票情况设备费2;
			parameters[83].Value = model.发票情况业主;
			parameters[84].Value = model.发票情况业主租金;
			parameters[85].Value = model.发票情况设计单位;
			parameters[86].Value = model.发票情况设计费;
			parameters[87].Value = model.发票情况墈察单位;
			parameters[88].Value = model.发票情况墈察费;
			parameters[89].Value = model.发票情况监理单位;
			parameters[90].Value = model.发票情况监理费;
			parameters[91].Value = model.发票情况项目管理单位;
			parameters[92].Value = model.发票情况项目管理费;
			parameters[93].Value = model.发票情况土建施工单位1;
			parameters[94].Value = model.发票情况土建施工费1;
			parameters[95].Value = model.发票情况土建施工单位2;
			parameters[96].Value = model.发票情况土建施工费2;
			parameters[97].Value = model.发票情况铁塔加工单位;
			parameters[98].Value = model.发票情况铁塔加工费;
			parameters[99].Value = model.发票情况安装施工单位;
			parameters[100].Value = model.发票情况安装施工费;
			parameters[101].Value = model.发票情况外电单位;
			parameters[102].Value = model.发票情况外电施工费;
			parameters[103].Value = model.发票情况杆体搬运单位;
			parameters[104].Value = model.发票情况杆体搬运费;
			parameters[105].Value = model.发票情况选址费用单位;
			parameters[106].Value = model.发票情况选址费;
			parameters[107].Value = model.发票情况其他费用单位;
			parameters[108].Value = model.发票情况其他费用;
			parameters[109].Value = model.发票情况总计金额;
			parameters[110].Value = model.已付款未回发票设备单位1;
			parameters[111].Value = model.已付款未回发票设备费1;
			parameters[112].Value = model.已付款未回发票设备单位2;
			parameters[113].Value = model.已付款未回发票设备费2;
			parameters[114].Value = model.已付款未回发票业主;
			parameters[115].Value = model.已付款未回发票业主租金;
			parameters[116].Value = model.已付款未回发票设计单位;
			parameters[117].Value = model.已付款未回发票设计费;
			parameters[118].Value = model.已付款未回发票墈察单位;
			parameters[119].Value = model.已付款未回发票墈察费;
			parameters[120].Value = model.已付款未回发票监理单位;
			parameters[121].Value = model.已付款未回发票监理费;
			parameters[122].Value = model.已付款未回发票项目管理单位;
			parameters[123].Value = model.已付款未回发票项目管理费;
			parameters[124].Value = model.已付款未回发票土建施工单位1;
			parameters[125].Value = model.已付款未回发票土建施工费1;
			parameters[126].Value = model.已付款未回发票土建施工单位2;
			parameters[127].Value = model.已付款未回发票土建施工费2;
			parameters[128].Value = model.已付款未回发票铁塔加工单位;
			parameters[129].Value = model.已付款未回发票铁塔加工费;
			parameters[130].Value = model.已付款未回发票安装施工单位;
			parameters[131].Value = model.已付款未回发票安装施工费;
			parameters[132].Value = model.已付款未回发票外电单位;
			parameters[133].Value = model.已付款未回发票外电施工费;
			parameters[134].Value = model.已付款未回发票杆体搬运单位;
			parameters[135].Value = model.已付款未回发票杆体搬运费;
			parameters[136].Value = model.已付款未回发票选址费用单位;
			parameters[137].Value = model.已付款未回发票选址费;
			parameters[138].Value = model.已付款未回发票其他费用单位;
			parameters[139].Value = model.已付款未回发票其他费用;
			parameters[140].Value = model.已付款未回发票总计金额;
			parameters[141].Value = model.未付款设备单位1;
			parameters[142].Value = model.未付款设备费1;
			parameters[143].Value = model.未付款设备单位2;
			parameters[144].Value = model.未付款设备费2;
			parameters[145].Value = model.未付款业主;
			parameters[146].Value = model.未付款业主租金;
			parameters[147].Value = model.未付款设计单位;
			parameters[148].Value = model.未付款设计费;
			parameters[149].Value = model.未付款墈察单位;
			parameters[150].Value = model.未付款墈察费;
			parameters[151].Value = model.未付款监理单位;
			parameters[152].Value = model.未付款监理费;
			parameters[153].Value = model.未付款项目管理单位;
			parameters[154].Value = model.未付款项目管理费;
			parameters[155].Value = model.未付款土建施工单位1;
			parameters[156].Value = model.未付款土建施工费1;
			parameters[157].Value = model.未付款土建施工单位2;
			parameters[158].Value = model.未付款土建施工费2;
			parameters[159].Value = model.未付款铁塔加工单位;
			parameters[160].Value = model.未付款铁塔加工费;
			parameters[161].Value = model.未付款安装施工单位;
			parameters[162].Value = model.未付款安装施工费;
			parameters[163].Value = model.未付款外电单位;
			parameters[164].Value = model.未付款外电施工费;
			parameters[165].Value = model.未付款杆体搬运单位;
			parameters[166].Value = model.未付款杆体搬运费;
			parameters[167].Value = model.未付款选址费用单位;
			parameters[168].Value = model.未付款选址费;
			parameters[169].Value = model.未付款其他费用单位;
			parameters[170].Value = model.未付款其他费用;
			parameters[171].Value = model.未付款总计金额;
			parameters[172].Value = model.备注;
			parameters[173].Value = model.IsDeleted;
			parameters[174].Value = model.CreateBy;
			parameters[175].Value = model.CreateTime;
			parameters[176].Value = model.UpdateBy;
			parameters[177].Value = model.UpdateTime;
			parameters[178].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(tran,strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YzdjSy ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YzdjSy ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WTCJ.Model.YzdjSy GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,部门,区域,客户名称,站点编码,站点名称,建站类型,经度,纬度,摘牌时间,进场施工时间,预计完工时间,建站周期,预估运营商收入年租金,预估运营商收入年限,预估运营商收入总租金,伟通收入,成本设备单位1,成本设备成本1,成本设备单位2,成本设备成本2,成本场地业主,成本租赁成本,成本设计单位,成本设计成本,成本地勘单位,成本地勘成本,成本监理单位,成本监理成本,成本项目管理单位,成本项目管理成本,成本土建施工单位1,成本土建施工成本1,成本土建施工单位2,成本土建施工成本2,成本铁塔加工单位,成本铁塔加工成本,成本安装施工单位,成本安装施工成本,成本外电单位,成本外电费,成本杆体搬运单位,成本杆体搬运费,成本选址费用单位,成本选址费,成本其他费用单位,成本其他费用,总成本,毛利率,已付款设备单位1,已付款设备费1,已付款设备单位2,已付款设备费2,已付款业主,已付款业主租金,已付款设计单位,已付款设计费,已付款墈察单位,已付款墈察费,已付款监理单位,已付款监理费,已付款项目管理单位,已付款项目管理费,已付款土建施工单位1,已付款土建施工费1,已付款土建施工单位2,已付款土建施工费2,已付款铁塔加工单位,已付款铁塔加工费,已付款安装施工单位,已付款安装施工费,已付款外电单位,已付款外电施工费,已付款杆体搬运单位,已付款杆体搬运费,已付款选址费用单位,已付款选址费,已付款其他费用单位,已付款其他费用,总计付款,发票情况设备单位1,发票情况设备费1,发票情况设备单位2,发票情况设备费2,发票情况业主,发票情况业主租金,发票情况设计单位,发票情况设计费,发票情况墈察单位,发票情况墈察费,发票情况监理单位,发票情况监理费,发票情况项目管理单位,发票情况项目管理费,发票情况土建施工单位1,发票情况土建施工费1,发票情况土建施工单位2,发票情况土建施工费2,发票情况铁塔加工单位,发票情况铁塔加工费,发票情况安装施工单位,发票情况安装施工费,发票情况外电单位,发票情况外电施工费,发票情况杆体搬运单位,发票情况杆体搬运费,发票情况选址费用单位,发票情况选址费,发票情况其他费用单位,发票情况其他费用,发票情况总计金额,已付款未回发票设备单位1,已付款未回发票设备费1,已付款未回发票设备单位2,已付款未回发票设备费2,已付款未回发票业主,已付款未回发票业主租金,已付款未回发票设计单位,已付款未回发票设计费,已付款未回发票墈察单位,已付款未回发票墈察费,已付款未回发票监理单位,已付款未回发票监理费,已付款未回发票项目管理单位,已付款未回发票项目管理费,已付款未回发票土建施工单位1,已付款未回发票土建施工费1,已付款未回发票土建施工单位2,已付款未回发票土建施工费2,已付款未回发票铁塔加工单位,已付款未回发票铁塔加工费,已付款未回发票安装施工单位,已付款未回发票安装施工费,已付款未回发票外电单位,已付款未回发票外电施工费,已付款未回发票杆体搬运单位,已付款未回发票杆体搬运费,已付款未回发票选址费用单位,已付款未回发票选址费,已付款未回发票其他费用单位,已付款未回发票其他费用,已付款未回发票总计金额,未付款设备单位1,未付款设备费1,未付款设备单位2,未付款设备费2,未付款业主,未付款业主租金,未付款设计单位,未付款设计费,未付款墈察单位,未付款墈察费,未付款监理单位,未付款监理费,未付款项目管理单位,未付款项目管理费,未付款土建施工单位1,未付款土建施工费1,未付款土建施工单位2,未付款土建施工费2,未付款铁塔加工单位,未付款铁塔加工费,未付款安装施工单位,未付款安装施工费,未付款外电单位,未付款外电施工费,未付款杆体搬运单位,未付款杆体搬运费,未付款选址费用单位,未付款选址费,未付款其他费用单位,未付款其他费用,未付款总计金额,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime from YzdjSy ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			WTCJ.Model.YzdjSy model=new WTCJ.Model.YzdjSy();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WTCJ.Model.YzdjSy DataRowToModel(DataRow row)
		{
			WTCJ.Model.YzdjSy model=new WTCJ.Model.YzdjSy();
			if (row != null)
			{
				if(row["id"]!=null)
				{
					model.id=row["id"].ToString();
				}
				if(row["部门"]!=null)
				{
					model.部门=row["部门"].ToString();
				}
				if(row["区域"]!=null)
				{
					model.区域=row["区域"].ToString();
				}
				if(row["客户名称"]!=null)
				{
					model.客户名称=row["客户名称"].ToString();
				}
				if(row["站点编码"]!=null)
				{
					model.站点编码=row["站点编码"].ToString();
				}
				if(row["站点名称"]!=null)
				{
					model.站点名称=row["站点名称"].ToString();
				}
				if(row["建站类型"]!=null)
				{
					model.建站类型=row["建站类型"].ToString();
				}
				if(row["经度"]!=null && row["经度"].ToString()!="")
				{
					model.经度=decimal.Parse(row["经度"].ToString());
				}
				if(row["纬度"]!=null && row["纬度"].ToString()!="")
				{
					model.纬度=decimal.Parse(row["纬度"].ToString());
				}
				if(row["摘牌时间"]!=null && row["摘牌时间"].ToString()!="")
				{
					model.摘牌时间=DateTime.Parse(row["摘牌时间"].ToString());
				}
				if(row["进场施工时间"]!=null && row["进场施工时间"].ToString()!="")
				{
					model.进场施工时间=DateTime.Parse(row["进场施工时间"].ToString());
				}
				if(row["预计完工时间"]!=null && row["预计完工时间"].ToString()!="")
				{
					model.预计完工时间=DateTime.Parse(row["预计完工时间"].ToString());
				}
				if(row["建站周期"]!=null && row["建站周期"].ToString()!="")
				{
					model.建站周期=int.Parse(row["建站周期"].ToString());
				}
				if(row["预估运营商收入年租金"]!=null && row["预估运营商收入年租金"].ToString()!="")
				{
					model.预估运营商收入年租金=decimal.Parse(row["预估运营商收入年租金"].ToString());
				}
				if(row["预估运营商收入年限"]!=null && row["预估运营商收入年限"].ToString()!="")
				{
					model.预估运营商收入年限=int.Parse(row["预估运营商收入年限"].ToString());
				}
				if(row["预估运营商收入总租金"]!=null && row["预估运营商收入总租金"].ToString()!="")
				{
					model.预估运营商收入总租金=decimal.Parse(row["预估运营商收入总租金"].ToString());
				}
				if(row["伟通收入"]!=null && row["伟通收入"].ToString()!="")
				{
					model.伟通收入=decimal.Parse(row["伟通收入"].ToString());
				}
				if(row["成本设备单位1"]!=null)
				{
					model.成本设备单位1=row["成本设备单位1"].ToString();
				}
				if(row["成本设备成本1"]!=null && row["成本设备成本1"].ToString()!="")
				{
					model.成本设备成本1=decimal.Parse(row["成本设备成本1"].ToString());
				}
				if(row["成本设备单位2"]!=null)
				{
					model.成本设备单位2=row["成本设备单位2"].ToString();
				}
				if(row["成本设备成本2"]!=null && row["成本设备成本2"].ToString()!="")
				{
					model.成本设备成本2=decimal.Parse(row["成本设备成本2"].ToString());
				}
				if(row["成本场地业主"]!=null)
				{
					model.成本场地业主=row["成本场地业主"].ToString();
				}
				if(row["成本租赁成本"]!=null && row["成本租赁成本"].ToString()!="")
				{
					model.成本租赁成本=decimal.Parse(row["成本租赁成本"].ToString());
				}
				if(row["成本设计单位"]!=null)
				{
					model.成本设计单位=row["成本设计单位"].ToString();
				}
				if(row["成本设计成本"]!=null && row["成本设计成本"].ToString()!="")
				{
					model.成本设计成本=decimal.Parse(row["成本设计成本"].ToString());
				}
				if(row["成本地勘单位"]!=null)
				{
					model.成本地勘单位=row["成本地勘单位"].ToString();
				}
				if(row["成本地勘成本"]!=null && row["成本地勘成本"].ToString()!="")
				{
					model.成本地勘成本=decimal.Parse(row["成本地勘成本"].ToString());
				}
				if(row["成本监理单位"]!=null)
				{
					model.成本监理单位=row["成本监理单位"].ToString();
				}
				if(row["成本监理成本"]!=null && row["成本监理成本"].ToString()!="")
				{
					model.成本监理成本=decimal.Parse(row["成本监理成本"].ToString());
				}
				if(row["成本项目管理单位"]!=null)
				{
					model.成本项目管理单位=row["成本项目管理单位"].ToString();
				}
				if(row["成本项目管理成本"]!=null && row["成本项目管理成本"].ToString()!="")
				{
					model.成本项目管理成本=decimal.Parse(row["成本项目管理成本"].ToString());
				}
				if(row["成本土建施工单位1"]!=null)
				{
					model.成本土建施工单位1=row["成本土建施工单位1"].ToString();
				}
				if(row["成本土建施工成本1"]!=null && row["成本土建施工成本1"].ToString()!="")
				{
					model.成本土建施工成本1=decimal.Parse(row["成本土建施工成本1"].ToString());
				}
				if(row["成本土建施工单位2"]!=null)
				{
					model.成本土建施工单位2=row["成本土建施工单位2"].ToString();
				}
				if(row["成本土建施工成本2"]!=null && row["成本土建施工成本2"].ToString()!="")
				{
					model.成本土建施工成本2=decimal.Parse(row["成本土建施工成本2"].ToString());
				}
				if(row["成本铁塔加工单位"]!=null)
				{
					model.成本铁塔加工单位=row["成本铁塔加工单位"].ToString();
				}
				if(row["成本铁塔加工成本"]!=null && row["成本铁塔加工成本"].ToString()!="")
				{
					model.成本铁塔加工成本=decimal.Parse(row["成本铁塔加工成本"].ToString());
				}
				if(row["成本安装施工单位"]!=null)
				{
					model.成本安装施工单位=row["成本安装施工单位"].ToString();
				}
				if(row["成本安装施工成本"]!=null && row["成本安装施工成本"].ToString()!="")
				{
					model.成本安装施工成本=decimal.Parse(row["成本安装施工成本"].ToString());
				}
				if(row["成本外电单位"]!=null)
				{
					model.成本外电单位=row["成本外电单位"].ToString();
				}
				if(row["成本外电费"]!=null && row["成本外电费"].ToString()!="")
				{
					model.成本外电费=decimal.Parse(row["成本外电费"].ToString());
				}
				if(row["成本杆体搬运单位"]!=null)
				{
					model.成本杆体搬运单位=row["成本杆体搬运单位"].ToString();
				}
				if(row["成本杆体搬运费"]!=null && row["成本杆体搬运费"].ToString()!="")
				{
					model.成本杆体搬运费=decimal.Parse(row["成本杆体搬运费"].ToString());
				}
				if(row["成本选址费用单位"]!=null)
				{
					model.成本选址费用单位=row["成本选址费用单位"].ToString();
				}
				if(row["成本选址费"]!=null && row["成本选址费"].ToString()!="")
				{
					model.成本选址费=decimal.Parse(row["成本选址费"].ToString());
				}
				if(row["成本其他费用单位"]!=null)
				{
					model.成本其他费用单位=row["成本其他费用单位"].ToString();
				}
				if(row["成本其他费用"]!=null && row["成本其他费用"].ToString()!="")
				{
					model.成本其他费用=decimal.Parse(row["成本其他费用"].ToString());
				}
				if(row["总成本"]!=null && row["总成本"].ToString()!="")
				{
					model.总成本=decimal.Parse(row["总成本"].ToString());
				}
				if(row["毛利率"]!=null && row["毛利率"].ToString()!="")
				{
					model.毛利率=decimal.Parse(row["毛利率"].ToString());
				}
				if(row["已付款设备单位1"]!=null)
				{
					model.已付款设备单位1=row["已付款设备单位1"].ToString();
				}
				if(row["已付款设备费1"]!=null && row["已付款设备费1"].ToString()!="")
				{
					model.已付款设备费1=decimal.Parse(row["已付款设备费1"].ToString());
				}
				if(row["已付款设备单位2"]!=null)
				{
					model.已付款设备单位2=row["已付款设备单位2"].ToString();
				}
				if(row["已付款设备费2"]!=null && row["已付款设备费2"].ToString()!="")
				{
					model.已付款设备费2=decimal.Parse(row["已付款设备费2"].ToString());
				}
				if(row["已付款业主"]!=null)
				{
					model.已付款业主=row["已付款业主"].ToString();
				}
				if(row["已付款业主租金"]!=null && row["已付款业主租金"].ToString()!="")
				{
					model.已付款业主租金=decimal.Parse(row["已付款业主租金"].ToString());
				}
				if(row["已付款设计单位"]!=null)
				{
					model.已付款设计单位=row["已付款设计单位"].ToString();
				}
				if(row["已付款设计费"]!=null && row["已付款设计费"].ToString()!="")
				{
					model.已付款设计费=decimal.Parse(row["已付款设计费"].ToString());
				}
				if(row["已付款墈察单位"]!=null)
				{
					model.已付款墈察单位=row["已付款墈察单位"].ToString();
				}
				if(row["已付款墈察费"]!=null && row["已付款墈察费"].ToString()!="")
				{
					model.已付款墈察费=decimal.Parse(row["已付款墈察费"].ToString());
				}
				if(row["已付款监理单位"]!=null)
				{
					model.已付款监理单位=row["已付款监理单位"].ToString();
				}
				if(row["已付款监理费"]!=null && row["已付款监理费"].ToString()!="")
				{
					model.已付款监理费=decimal.Parse(row["已付款监理费"].ToString());
				}
				if(row["已付款项目管理单位"]!=null)
				{
					model.已付款项目管理单位=row["已付款项目管理单位"].ToString();
				}
				if(row["已付款项目管理费"]!=null && row["已付款项目管理费"].ToString()!="")
				{
					model.已付款项目管理费=decimal.Parse(row["已付款项目管理费"].ToString());
				}
				if(row["已付款土建施工单位1"]!=null)
				{
					model.已付款土建施工单位1=row["已付款土建施工单位1"].ToString();
				}
				if(row["已付款土建施工费1"]!=null && row["已付款土建施工费1"].ToString()!="")
				{
					model.已付款土建施工费1=decimal.Parse(row["已付款土建施工费1"].ToString());
				}
				if(row["已付款土建施工单位2"]!=null)
				{
					model.已付款土建施工单位2=row["已付款土建施工单位2"].ToString();
				}
				if(row["已付款土建施工费2"]!=null && row["已付款土建施工费2"].ToString()!="")
				{
					model.已付款土建施工费2=decimal.Parse(row["已付款土建施工费2"].ToString());
				}
				if(row["已付款铁塔加工单位"]!=null)
				{
					model.已付款铁塔加工单位=row["已付款铁塔加工单位"].ToString();
				}
				if(row["已付款铁塔加工费"]!=null && row["已付款铁塔加工费"].ToString()!="")
				{
					model.已付款铁塔加工费=decimal.Parse(row["已付款铁塔加工费"].ToString());
				}
				if(row["已付款安装施工单位"]!=null)
				{
					model.已付款安装施工单位=row["已付款安装施工单位"].ToString();
				}
				if(row["已付款安装施工费"]!=null && row["已付款安装施工费"].ToString()!="")
				{
					model.已付款安装施工费=decimal.Parse(row["已付款安装施工费"].ToString());
				}
				if(row["已付款外电单位"]!=null)
				{
					model.已付款外电单位=row["已付款外电单位"].ToString();
				}
				if(row["已付款外电施工费"]!=null && row["已付款外电施工费"].ToString()!="")
				{
					model.已付款外电施工费=decimal.Parse(row["已付款外电施工费"].ToString());
				}
				if(row["已付款杆体搬运单位"]!=null)
				{
					model.已付款杆体搬运单位=row["已付款杆体搬运单位"].ToString();
				}
				if(row["已付款杆体搬运费"]!=null && row["已付款杆体搬运费"].ToString()!="")
				{
					model.已付款杆体搬运费=decimal.Parse(row["已付款杆体搬运费"].ToString());
				}
				if(row["已付款选址费用单位"]!=null)
				{
					model.已付款选址费用单位=row["已付款选址费用单位"].ToString();
				}
				if(row["已付款选址费"]!=null && row["已付款选址费"].ToString()!="")
				{
					model.已付款选址费=decimal.Parse(row["已付款选址费"].ToString());
				}
				if(row["已付款其他费用单位"]!=null)
				{
					model.已付款其他费用单位=row["已付款其他费用单位"].ToString();
				}
				if(row["已付款其他费用"]!=null && row["已付款其他费用"].ToString()!="")
				{
					model.已付款其他费用=decimal.Parse(row["已付款其他费用"].ToString());
				}
				if(row["总计付款"]!=null && row["总计付款"].ToString()!="")
				{
					model.总计付款=decimal.Parse(row["总计付款"].ToString());
				}
				if(row["发票情况设备单位1"]!=null)
				{
					model.发票情况设备单位1=row["发票情况设备单位1"].ToString();
				}
				if(row["发票情况设备费1"]!=null && row["发票情况设备费1"].ToString()!="")
				{
					model.发票情况设备费1=decimal.Parse(row["发票情况设备费1"].ToString());
				}
				if(row["发票情况设备单位2"]!=null)
				{
					model.发票情况设备单位2=row["发票情况设备单位2"].ToString();
				}
				if(row["发票情况设备费2"]!=null && row["发票情况设备费2"].ToString()!="")
				{
					model.发票情况设备费2=decimal.Parse(row["发票情况设备费2"].ToString());
				}
				if(row["发票情况业主"]!=null)
				{
					model.发票情况业主=row["发票情况业主"].ToString();
				}
				if(row["发票情况业主租金"]!=null && row["发票情况业主租金"].ToString()!="")
				{
					model.发票情况业主租金=decimal.Parse(row["发票情况业主租金"].ToString());
				}
				if(row["发票情况设计单位"]!=null)
				{
					model.发票情况设计单位=row["发票情况设计单位"].ToString();
				}
				if(row["发票情况设计费"]!=null && row["发票情况设计费"].ToString()!="")
				{
					model.发票情况设计费=decimal.Parse(row["发票情况设计费"].ToString());
				}
				if(row["发票情况墈察单位"]!=null)
				{
					model.发票情况墈察单位=row["发票情况墈察单位"].ToString();
				}
				if(row["发票情况墈察费"]!=null && row["发票情况墈察费"].ToString()!="")
				{
					model.发票情况墈察费=decimal.Parse(row["发票情况墈察费"].ToString());
				}
				if(row["发票情况监理单位"]!=null)
				{
					model.发票情况监理单位=row["发票情况监理单位"].ToString();
				}
				if(row["发票情况监理费"]!=null && row["发票情况监理费"].ToString()!="")
				{
					model.发票情况监理费=decimal.Parse(row["发票情况监理费"].ToString());
				}
				if(row["发票情况项目管理单位"]!=null)
				{
					model.发票情况项目管理单位=row["发票情况项目管理单位"].ToString();
				}
				if(row["发票情况项目管理费"]!=null && row["发票情况项目管理费"].ToString()!="")
				{
					model.发票情况项目管理费=decimal.Parse(row["发票情况项目管理费"].ToString());
				}
				if(row["发票情况土建施工单位1"]!=null)
				{
					model.发票情况土建施工单位1=row["发票情况土建施工单位1"].ToString();
				}
				if(row["发票情况土建施工费1"]!=null && row["发票情况土建施工费1"].ToString()!="")
				{
					model.发票情况土建施工费1=decimal.Parse(row["发票情况土建施工费1"].ToString());
				}
				if(row["发票情况土建施工单位2"]!=null)
				{
					model.发票情况土建施工单位2=row["发票情况土建施工单位2"].ToString();
				}
				if(row["发票情况土建施工费2"]!=null && row["发票情况土建施工费2"].ToString()!="")
				{
					model.发票情况土建施工费2=decimal.Parse(row["发票情况土建施工费2"].ToString());
				}
				if(row["发票情况铁塔加工单位"]!=null)
				{
					model.发票情况铁塔加工单位=row["发票情况铁塔加工单位"].ToString();
				}
				if(row["发票情况铁塔加工费"]!=null && row["发票情况铁塔加工费"].ToString()!="")
				{
					model.发票情况铁塔加工费=decimal.Parse(row["发票情况铁塔加工费"].ToString());
				}
				if(row["发票情况安装施工单位"]!=null)
				{
					model.发票情况安装施工单位=row["发票情况安装施工单位"].ToString();
				}
				if(row["发票情况安装施工费"]!=null && row["发票情况安装施工费"].ToString()!="")
				{
					model.发票情况安装施工费=decimal.Parse(row["发票情况安装施工费"].ToString());
				}
				if(row["发票情况外电单位"]!=null)
				{
					model.发票情况外电单位=row["发票情况外电单位"].ToString();
				}
				if(row["发票情况外电施工费"]!=null && row["发票情况外电施工费"].ToString()!="")
				{
					model.发票情况外电施工费=decimal.Parse(row["发票情况外电施工费"].ToString());
				}
				if(row["发票情况杆体搬运单位"]!=null)
				{
					model.发票情况杆体搬运单位=row["发票情况杆体搬运单位"].ToString();
				}
				if(row["发票情况杆体搬运费"]!=null && row["发票情况杆体搬运费"].ToString()!="")
				{
					model.发票情况杆体搬运费=decimal.Parse(row["发票情况杆体搬运费"].ToString());
				}
				if(row["发票情况选址费用单位"]!=null)
				{
					model.发票情况选址费用单位=row["发票情况选址费用单位"].ToString();
				}
				if(row["发票情况选址费"]!=null && row["发票情况选址费"].ToString()!="")
				{
					model.发票情况选址费=decimal.Parse(row["发票情况选址费"].ToString());
				}
				if(row["发票情况其他费用单位"]!=null)
				{
					model.发票情况其他费用单位=row["发票情况其他费用单位"].ToString();
				}
				if(row["发票情况其他费用"]!=null && row["发票情况其他费用"].ToString()!="")
				{
					model.发票情况其他费用=decimal.Parse(row["发票情况其他费用"].ToString());
				}
				if(row["发票情况总计金额"]!=null && row["发票情况总计金额"].ToString()!="")
				{
					model.发票情况总计金额=decimal.Parse(row["发票情况总计金额"].ToString());
				}
				if(row["已付款未回发票设备单位1"]!=null)
				{
					model.已付款未回发票设备单位1=row["已付款未回发票设备单位1"].ToString();
				}
				if(row["已付款未回发票设备费1"]!=null && row["已付款未回发票设备费1"].ToString()!="")
				{
					model.已付款未回发票设备费1=decimal.Parse(row["已付款未回发票设备费1"].ToString());
				}
				if(row["已付款未回发票设备单位2"]!=null)
				{
					model.已付款未回发票设备单位2=row["已付款未回发票设备单位2"].ToString();
				}
				if(row["已付款未回发票设备费2"]!=null && row["已付款未回发票设备费2"].ToString()!="")
				{
					model.已付款未回发票设备费2=decimal.Parse(row["已付款未回发票设备费2"].ToString());
				}
				if(row["已付款未回发票业主"]!=null)
				{
					model.已付款未回发票业主=row["已付款未回发票业主"].ToString();
				}
				if(row["已付款未回发票业主租金"]!=null && row["已付款未回发票业主租金"].ToString()!="")
				{
					model.已付款未回发票业主租金=decimal.Parse(row["已付款未回发票业主租金"].ToString());
				}
				if(row["已付款未回发票设计单位"]!=null)
				{
					model.已付款未回发票设计单位=row["已付款未回发票设计单位"].ToString();
				}
				if(row["已付款未回发票设计费"]!=null && row["已付款未回发票设计费"].ToString()!="")
				{
					model.已付款未回发票设计费=decimal.Parse(row["已付款未回发票设计费"].ToString());
				}
				if(row["已付款未回发票墈察单位"]!=null)
				{
					model.已付款未回发票墈察单位=row["已付款未回发票墈察单位"].ToString();
				}
				if(row["已付款未回发票墈察费"]!=null && row["已付款未回发票墈察费"].ToString()!="")
				{
					model.已付款未回发票墈察费=decimal.Parse(row["已付款未回发票墈察费"].ToString());
				}
				if(row["已付款未回发票监理单位"]!=null)
				{
					model.已付款未回发票监理单位=row["已付款未回发票监理单位"].ToString();
				}
				if(row["已付款未回发票监理费"]!=null && row["已付款未回发票监理费"].ToString()!="")
				{
					model.已付款未回发票监理费=decimal.Parse(row["已付款未回发票监理费"].ToString());
				}
				if(row["已付款未回发票项目管理单位"]!=null)
				{
					model.已付款未回发票项目管理单位=row["已付款未回发票项目管理单位"].ToString();
				}
				if(row["已付款未回发票项目管理费"]!=null && row["已付款未回发票项目管理费"].ToString()!="")
				{
					model.已付款未回发票项目管理费=decimal.Parse(row["已付款未回发票项目管理费"].ToString());
				}
				if(row["已付款未回发票土建施工单位1"]!=null)
				{
					model.已付款未回发票土建施工单位1=row["已付款未回发票土建施工单位1"].ToString();
				}
				if(row["已付款未回发票土建施工费1"]!=null && row["已付款未回发票土建施工费1"].ToString()!="")
				{
					model.已付款未回发票土建施工费1=decimal.Parse(row["已付款未回发票土建施工费1"].ToString());
				}
				if(row["已付款未回发票土建施工单位2"]!=null)
				{
					model.已付款未回发票土建施工单位2=row["已付款未回发票土建施工单位2"].ToString();
				}
				if(row["已付款未回发票土建施工费2"]!=null && row["已付款未回发票土建施工费2"].ToString()!="")
				{
					model.已付款未回发票土建施工费2=decimal.Parse(row["已付款未回发票土建施工费2"].ToString());
				}
				if(row["已付款未回发票铁塔加工单位"]!=null)
				{
					model.已付款未回发票铁塔加工单位=row["已付款未回发票铁塔加工单位"].ToString();
				}
				if(row["已付款未回发票铁塔加工费"]!=null && row["已付款未回发票铁塔加工费"].ToString()!="")
				{
					model.已付款未回发票铁塔加工费=decimal.Parse(row["已付款未回发票铁塔加工费"].ToString());
				}
				if(row["已付款未回发票安装施工单位"]!=null)
				{
					model.已付款未回发票安装施工单位=row["已付款未回发票安装施工单位"].ToString();
				}
				if(row["已付款未回发票安装施工费"]!=null && row["已付款未回发票安装施工费"].ToString()!="")
				{
					model.已付款未回发票安装施工费=decimal.Parse(row["已付款未回发票安装施工费"].ToString());
				}
				if(row["已付款未回发票外电单位"]!=null)
				{
					model.已付款未回发票外电单位=row["已付款未回发票外电单位"].ToString();
				}
				if(row["已付款未回发票外电施工费"]!=null && row["已付款未回发票外电施工费"].ToString()!="")
				{
					model.已付款未回发票外电施工费=decimal.Parse(row["已付款未回发票外电施工费"].ToString());
				}
				if(row["已付款未回发票杆体搬运单位"]!=null)
				{
					model.已付款未回发票杆体搬运单位=row["已付款未回发票杆体搬运单位"].ToString();
				}
				if(row["已付款未回发票杆体搬运费"]!=null && row["已付款未回发票杆体搬运费"].ToString()!="")
				{
					model.已付款未回发票杆体搬运费=decimal.Parse(row["已付款未回发票杆体搬运费"].ToString());
				}
				if(row["已付款未回发票选址费用单位"]!=null)
				{
					model.已付款未回发票选址费用单位=row["已付款未回发票选址费用单位"].ToString();
				}
				if(row["已付款未回发票选址费"]!=null && row["已付款未回发票选址费"].ToString()!="")
				{
					model.已付款未回发票选址费=decimal.Parse(row["已付款未回发票选址费"].ToString());
				}
				if(row["已付款未回发票其他费用单位"]!=null)
				{
					model.已付款未回发票其他费用单位=row["已付款未回发票其他费用单位"].ToString();
				}
				if(row["已付款未回发票其他费用"]!=null && row["已付款未回发票其他费用"].ToString()!="")
				{
					model.已付款未回发票其他费用=decimal.Parse(row["已付款未回发票其他费用"].ToString());
				}
				if(row["已付款未回发票总计金额"]!=null && row["已付款未回发票总计金额"].ToString()!="")
				{
					model.已付款未回发票总计金额=decimal.Parse(row["已付款未回发票总计金额"].ToString());
				}
				if(row["未付款设备单位1"]!=null)
				{
					model.未付款设备单位1=row["未付款设备单位1"].ToString();
				}
				if(row["未付款设备费1"]!=null && row["未付款设备费1"].ToString()!="")
				{
					model.未付款设备费1=decimal.Parse(row["未付款设备费1"].ToString());
				}
				if(row["未付款设备单位2"]!=null)
				{
					model.未付款设备单位2=row["未付款设备单位2"].ToString();
				}
				if(row["未付款设备费2"]!=null && row["未付款设备费2"].ToString()!="")
				{
					model.未付款设备费2=decimal.Parse(row["未付款设备费2"].ToString());
				}
				if(row["未付款业主"]!=null)
				{
					model.未付款业主=row["未付款业主"].ToString();
				}
				if(row["未付款业主租金"]!=null && row["未付款业主租金"].ToString()!="")
				{
					model.未付款业主租金=decimal.Parse(row["未付款业主租金"].ToString());
				}
				if(row["未付款设计单位"]!=null)
				{
					model.未付款设计单位=row["未付款设计单位"].ToString();
				}
				if(row["未付款设计费"]!=null && row["未付款设计费"].ToString()!="")
				{
					model.未付款设计费=decimal.Parse(row["未付款设计费"].ToString());
				}
				if(row["未付款墈察单位"]!=null)
				{
					model.未付款墈察单位=row["未付款墈察单位"].ToString();
				}
				if(row["未付款墈察费"]!=null && row["未付款墈察费"].ToString()!="")
				{
					model.未付款墈察费=decimal.Parse(row["未付款墈察费"].ToString());
				}
				if(row["未付款监理单位"]!=null)
				{
					model.未付款监理单位=row["未付款监理单位"].ToString();
				}
				if(row["未付款监理费"]!=null && row["未付款监理费"].ToString()!="")
				{
					model.未付款监理费=decimal.Parse(row["未付款监理费"].ToString());
				}
				if(row["未付款项目管理单位"]!=null)
				{
					model.未付款项目管理单位=row["未付款项目管理单位"].ToString();
				}
				if(row["未付款项目管理费"]!=null && row["未付款项目管理费"].ToString()!="")
				{
					model.未付款项目管理费=decimal.Parse(row["未付款项目管理费"].ToString());
				}
				if(row["未付款土建施工单位1"]!=null)
				{
					model.未付款土建施工单位1=row["未付款土建施工单位1"].ToString();
				}
				if(row["未付款土建施工费1"]!=null && row["未付款土建施工费1"].ToString()!="")
				{
					model.未付款土建施工费1=decimal.Parse(row["未付款土建施工费1"].ToString());
				}
				if(row["未付款土建施工单位2"]!=null)
				{
					model.未付款土建施工单位2=row["未付款土建施工单位2"].ToString();
				}
				if(row["未付款土建施工费2"]!=null && row["未付款土建施工费2"].ToString()!="")
				{
					model.未付款土建施工费2=decimal.Parse(row["未付款土建施工费2"].ToString());
				}
				if(row["未付款铁塔加工单位"]!=null)
				{
					model.未付款铁塔加工单位=row["未付款铁塔加工单位"].ToString();
				}
				if(row["未付款铁塔加工费"]!=null && row["未付款铁塔加工费"].ToString()!="")
				{
					model.未付款铁塔加工费=decimal.Parse(row["未付款铁塔加工费"].ToString());
				}
				if(row["未付款安装施工单位"]!=null)
				{
					model.未付款安装施工单位=row["未付款安装施工单位"].ToString();
				}
				if(row["未付款安装施工费"]!=null && row["未付款安装施工费"].ToString()!="")
				{
					model.未付款安装施工费=decimal.Parse(row["未付款安装施工费"].ToString());
				}
				if(row["未付款外电单位"]!=null)
				{
					model.未付款外电单位=row["未付款外电单位"].ToString();
				}
				if(row["未付款外电施工费"]!=null && row["未付款外电施工费"].ToString()!="")
				{
					model.未付款外电施工费=decimal.Parse(row["未付款外电施工费"].ToString());
				}
				if(row["未付款杆体搬运单位"]!=null)
				{
					model.未付款杆体搬运单位=row["未付款杆体搬运单位"].ToString();
				}
				if(row["未付款杆体搬运费"]!=null && row["未付款杆体搬运费"].ToString()!="")
				{
					model.未付款杆体搬运费=decimal.Parse(row["未付款杆体搬运费"].ToString());
				}
				if(row["未付款选址费用单位"]!=null)
				{
					model.未付款选址费用单位=row["未付款选址费用单位"].ToString();
				}
				if(row["未付款选址费"]!=null && row["未付款选址费"].ToString()!="")
				{
					model.未付款选址费=decimal.Parse(row["未付款选址费"].ToString());
				}
				if(row["未付款其他费用单位"]!=null)
				{
					model.未付款其他费用单位=row["未付款其他费用单位"].ToString();
				}
				if(row["未付款其他费用"]!=null && row["未付款其他费用"].ToString()!="")
				{
					model.未付款其他费用=decimal.Parse(row["未付款其他费用"].ToString());
				}
				if(row["未付款总计金额"]!=null && row["未付款总计金额"].ToString()!="")
				{
					model.未付款总计金额=decimal.Parse(row["未付款总计金额"].ToString());
				}
				if(row["备注"]!=null)
				{
					model.备注=row["备注"].ToString();
				}
				if(row["IsDeleted"]!=null && row["IsDeleted"].ToString()!="")
				{
					model.IsDeleted=int.Parse(row["IsDeleted"].ToString());
				}
				if(row["CreateBy"]!=null)
				{
					model.CreateBy=row["CreateBy"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["UpdateBy"]!=null)
				{
					model.UpdateBy=row["UpdateBy"].ToString();
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,部门,区域,客户名称,站点编码,站点名称,建站类型,经度,纬度,摘牌时间,进场施工时间,预计完工时间,建站周期,预估运营商收入年租金,预估运营商收入年限,预估运营商收入总租金,伟通收入,成本设备单位1,成本设备成本1,成本设备单位2,成本设备成本2,成本场地业主,成本租赁成本,成本设计单位,成本设计成本,成本地勘单位,成本地勘成本,成本监理单位,成本监理成本,成本项目管理单位,成本项目管理成本,成本土建施工单位1,成本土建施工成本1,成本土建施工单位2,成本土建施工成本2,成本铁塔加工单位,成本铁塔加工成本,成本安装施工单位,成本安装施工成本,成本外电单位,成本外电费,成本杆体搬运单位,成本杆体搬运费,成本选址费用单位,成本选址费,成本其他费用单位,成本其他费用,总成本,毛利率,已付款设备单位1,已付款设备费1,已付款设备单位2,已付款设备费2,已付款业主,已付款业主租金,已付款设计单位,已付款设计费,已付款墈察单位,已付款墈察费,已付款监理单位,已付款监理费,已付款项目管理单位,已付款项目管理费,已付款土建施工单位1,已付款土建施工费1,已付款土建施工单位2,已付款土建施工费2,已付款铁塔加工单位,已付款铁塔加工费,已付款安装施工单位,已付款安装施工费,已付款外电单位,已付款外电施工费,已付款杆体搬运单位,已付款杆体搬运费,已付款选址费用单位,已付款选址费,已付款其他费用单位,已付款其他费用,总计付款,发票情况设备单位1,发票情况设备费1,发票情况设备单位2,发票情况设备费2,发票情况业主,发票情况业主租金,发票情况设计单位,发票情况设计费,发票情况墈察单位,发票情况墈察费,发票情况监理单位,发票情况监理费,发票情况项目管理单位,发票情况项目管理费,发票情况土建施工单位1,发票情况土建施工费1,发票情况土建施工单位2,发票情况土建施工费2,发票情况铁塔加工单位,发票情况铁塔加工费,发票情况安装施工单位,发票情况安装施工费,发票情况外电单位,发票情况外电施工费,发票情况杆体搬运单位,发票情况杆体搬运费,发票情况选址费用单位,发票情况选址费,发票情况其他费用单位,发票情况其他费用,发票情况总计金额,已付款未回发票设备单位1,已付款未回发票设备费1,已付款未回发票设备单位2,已付款未回发票设备费2,已付款未回发票业主,已付款未回发票业主租金,已付款未回发票设计单位,已付款未回发票设计费,已付款未回发票墈察单位,已付款未回发票墈察费,已付款未回发票监理单位,已付款未回发票监理费,已付款未回发票项目管理单位,已付款未回发票项目管理费,已付款未回发票土建施工单位1,已付款未回发票土建施工费1,已付款未回发票土建施工单位2,已付款未回发票土建施工费2,已付款未回发票铁塔加工单位,已付款未回发票铁塔加工费,已付款未回发票安装施工单位,已付款未回发票安装施工费,已付款未回发票外电单位,已付款未回发票外电施工费,已付款未回发票杆体搬运单位,已付款未回发票杆体搬运费,已付款未回发票选址费用单位,已付款未回发票选址费,已付款未回发票其他费用单位,已付款未回发票其他费用,已付款未回发票总计金额,未付款设备单位1,未付款设备费1,未付款设备单位2,未付款设备费2,未付款业主,未付款业主租金,未付款设计单位,未付款设计费,未付款墈察单位,未付款墈察费,未付款监理单位,未付款监理费,未付款项目管理单位,未付款项目管理费,未付款土建施工单位1,未付款土建施工费1,未付款土建施工单位2,未付款土建施工费2,未付款铁塔加工单位,未付款铁塔加工费,未付款安装施工单位,未付款安装施工费,未付款外电单位,未付款外电施工费,未付款杆体搬运单位,未付款杆体搬运费,未付款选址费用单位,未付款选址费,未付款其他费用单位,未付款其他费用,未付款总计金额,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM YzdjSy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,部门,区域,客户名称,站点编码,站点名称,建站类型,经度,纬度,摘牌时间,进场施工时间,预计完工时间,建站周期,预估运营商收入年租金,预估运营商收入年限,预估运营商收入总租金,伟通收入,成本设备单位1,成本设备成本1,成本设备单位2,成本设备成本2,成本场地业主,成本租赁成本,成本设计单位,成本设计成本,成本地勘单位,成本地勘成本,成本监理单位,成本监理成本,成本项目管理单位,成本项目管理成本,成本土建施工单位1,成本土建施工成本1,成本土建施工单位2,成本土建施工成本2,成本铁塔加工单位,成本铁塔加工成本,成本安装施工单位,成本安装施工成本,成本外电单位,成本外电费,成本杆体搬运单位,成本杆体搬运费,成本选址费用单位,成本选址费,成本其他费用单位,成本其他费用,总成本,毛利率,已付款设备单位1,已付款设备费1,已付款设备单位2,已付款设备费2,已付款业主,已付款业主租金,已付款设计单位,已付款设计费,已付款墈察单位,已付款墈察费,已付款监理单位,已付款监理费,已付款项目管理单位,已付款项目管理费,已付款土建施工单位1,已付款土建施工费1,已付款土建施工单位2,已付款土建施工费2,已付款铁塔加工单位,已付款铁塔加工费,已付款安装施工单位,已付款安装施工费,已付款外电单位,已付款外电施工费,已付款杆体搬运单位,已付款杆体搬运费,已付款选址费用单位,已付款选址费,已付款其他费用单位,已付款其他费用,总计付款,发票情况设备单位1,发票情况设备费1,发票情况设备单位2,发票情况设备费2,发票情况业主,发票情况业主租金,发票情况设计单位,发票情况设计费,发票情况墈察单位,发票情况墈察费,发票情况监理单位,发票情况监理费,发票情况项目管理单位,发票情况项目管理费,发票情况土建施工单位1,发票情况土建施工费1,发票情况土建施工单位2,发票情况土建施工费2,发票情况铁塔加工单位,发票情况铁塔加工费,发票情况安装施工单位,发票情况安装施工费,发票情况外电单位,发票情况外电施工费,发票情况杆体搬运单位,发票情况杆体搬运费,发票情况选址费用单位,发票情况选址费,发票情况其他费用单位,发票情况其他费用,发票情况总计金额,已付款未回发票设备单位1,已付款未回发票设备费1,已付款未回发票设备单位2,已付款未回发票设备费2,已付款未回发票业主,已付款未回发票业主租金,已付款未回发票设计单位,已付款未回发票设计费,已付款未回发票墈察单位,已付款未回发票墈察费,已付款未回发票监理单位,已付款未回发票监理费,已付款未回发票项目管理单位,已付款未回发票项目管理费,已付款未回发票土建施工单位1,已付款未回发票土建施工费1,已付款未回发票土建施工单位2,已付款未回发票土建施工费2,已付款未回发票铁塔加工单位,已付款未回发票铁塔加工费,已付款未回发票安装施工单位,已付款未回发票安装施工费,已付款未回发票外电单位,已付款未回发票外电施工费,已付款未回发票杆体搬运单位,已付款未回发票杆体搬运费,已付款未回发票选址费用单位,已付款未回发票选址费,已付款未回发票其他费用单位,已付款未回发票其他费用,已付款未回发票总计金额,未付款设备单位1,未付款设备费1,未付款设备单位2,未付款设备费2,未付款业主,未付款业主租金,未付款设计单位,未付款设计费,未付款墈察单位,未付款墈察费,未付款监理单位,未付款监理费,未付款项目管理单位,未付款项目管理费,未付款土建施工单位1,未付款土建施工费1,未付款土建施工单位2,未付款土建施工费2,未付款铁塔加工单位,未付款铁塔加工费,未付款安装施工单位,未付款安装施工费,未付款外电单位,未付款外电施工费,未付款杆体搬运单位,未付款杆体搬运费,未付款选址费用单位,未付款选址费,未付款其他费用单位,未付款其他费用,未付款总计金额,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM YzdjSy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(SqlTransaction tran,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,部门,区域,客户名称,站点编码,站点名称,建站类型,经度,纬度,摘牌时间,进场施工时间,预计完工时间,建站周期,预估运营商收入年租金,预估运营商收入年限,预估运营商收入总租金,伟通收入,成本设备单位1,成本设备成本1,成本设备单位2,成本设备成本2,成本场地业主,成本租赁成本,成本设计单位,成本设计成本,成本地勘单位,成本地勘成本,成本监理单位,成本监理成本,成本项目管理单位,成本项目管理成本,成本土建施工单位1,成本土建施工成本1,成本土建施工单位2,成本土建施工成本2,成本铁塔加工单位,成本铁塔加工成本,成本安装施工单位,成本安装施工成本,成本外电单位,成本外电费,成本杆体搬运单位,成本杆体搬运费,成本选址费用单位,成本选址费,成本其他费用单位,成本其他费用,总成本,毛利率,已付款设备单位1,已付款设备费1,已付款设备单位2,已付款设备费2,已付款业主,已付款业主租金,已付款设计单位,已付款设计费,已付款墈察单位,已付款墈察费,已付款监理单位,已付款监理费,已付款项目管理单位,已付款项目管理费,已付款土建施工单位1,已付款土建施工费1,已付款土建施工单位2,已付款土建施工费2,已付款铁塔加工单位,已付款铁塔加工费,已付款安装施工单位,已付款安装施工费,已付款外电单位,已付款外电施工费,已付款杆体搬运单位,已付款杆体搬运费,已付款选址费用单位,已付款选址费,已付款其他费用单位,已付款其他费用,总计付款,发票情况设备单位1,发票情况设备费1,发票情况设备单位2,发票情况设备费2,发票情况业主,发票情况业主租金,发票情况设计单位,发票情况设计费,发票情况墈察单位,发票情况墈察费,发票情况监理单位,发票情况监理费,发票情况项目管理单位,发票情况项目管理费,发票情况土建施工单位1,发票情况土建施工费1,发票情况土建施工单位2,发票情况土建施工费2,发票情况铁塔加工单位,发票情况铁塔加工费,发票情况安装施工单位,发票情况安装施工费,发票情况外电单位,发票情况外电施工费,发票情况杆体搬运单位,发票情况杆体搬运费,发票情况选址费用单位,发票情况选址费,发票情况其他费用单位,发票情况其他费用,发票情况总计金额,已付款未回发票设备单位1,已付款未回发票设备费1,已付款未回发票设备单位2,已付款未回发票设备费2,已付款未回发票业主,已付款未回发票业主租金,已付款未回发票设计单位,已付款未回发票设计费,已付款未回发票墈察单位,已付款未回发票墈察费,已付款未回发票监理单位,已付款未回发票监理费,已付款未回发票项目管理单位,已付款未回发票项目管理费,已付款未回发票土建施工单位1,已付款未回发票土建施工费1,已付款未回发票土建施工单位2,已付款未回发票土建施工费2,已付款未回发票铁塔加工单位,已付款未回发票铁塔加工费,已付款未回发票安装施工单位,已付款未回发票安装施工费,已付款未回发票外电单位,已付款未回发票外电施工费,已付款未回发票杆体搬运单位,已付款未回发票杆体搬运费,已付款未回发票选址费用单位,已付款未回发票选址费,已付款未回发票其他费用单位,已付款未回发票其他费用,已付款未回发票总计金额,未付款设备单位1,未付款设备费1,未付款设备单位2,未付款设备费2,未付款业主,未付款业主租金,未付款设计单位,未付款设计费,未付款墈察单位,未付款墈察费,未付款监理单位,未付款监理费,未付款项目管理单位,未付款项目管理费,未付款土建施工单位1,未付款土建施工费1,未付款土建施工单位2,未付款土建施工费2,未付款铁塔加工单位,未付款铁塔加工费,未付款安装施工单位,未付款安装施工费,未付款外电单位,未付款外电施工费,未付款杆体搬运单位,未付款杆体搬运费,未付款选址费用单位,未付款选址费,未付款其他费用单位,未付款其他费用,未付款总计金额,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM YzdjSy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(tran,strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM YzdjSy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from YzdjSy T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "YzdjSy";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


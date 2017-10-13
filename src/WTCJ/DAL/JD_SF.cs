/**  版本信息模板在安装目录下，可自行修改。
* JD_SF.cs
*
* 功 能： N/A
* 类 名： JD_SF
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/7/3 15:10:36   N/A    初版
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
	/// 数据访问类:JD_SF
	/// </summary>
	public partial class JD_SF
	{
		public JD_SF()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from JD_SF");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.JD_SF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JD_SF(");
			strSql.Append("id,部门,类别,区域,客户,站点编码,站点名称,地址,建站面积,预算表或损益表审批时间,与伟通签订单项合同日期,最新状态,经度,纬度,年租金,年限,总收入,伟通应收款,摘牌时间,预计进场日期,预计完工日期,建站周期,选址定点,设计出图完成日期,设计出图完成百分比,设计出图完成设计面积,产品采购开始日期,产品采购主材百分比,产品采购辅材百分比,产品安装地停百分比,产品安装地停面积,产品安装平层百分比,产品安装平层面积,产品安装电梯百分比,主机安装完成日期,光缆到位完成日期,设备开通完成日期,销售验收日期,运营商验收交付开始日期,运营商验收交付完成日期,运营商签订合同开始日期,运营商签订合同完成日期,是否退点,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@部门,@类别,@区域,@客户,@站点编码,@站点名称,@地址,@建站面积,@预算表或损益表审批时间,@与伟通签订单项合同日期,@最新状态,@经度,@纬度,@年租金,@年限,@总收入,@伟通应收款,@摘牌时间,@预计进场日期,@预计完工日期,@建站周期,@选址定点,@设计出图完成日期,@设计出图完成百分比,@设计出图完成设计面积,@产品采购开始日期,@产品采购主材百分比,@产品采购辅材百分比,@产品安装地停百分比,@产品安装地停面积,@产品安装平层百分比,@产品安装平层面积,@产品安装电梯百分比,@主机安装完成日期,@光缆到位完成日期,@设备开通完成日期,@销售验收日期,@运营商验收交付开始日期,@运营商验收交付完成日期,@运营商签订合同开始日期,@运营商签订合同完成日期,@是否退点,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@地址", SqlDbType.VarChar,500),
					new SqlParameter("@建站面积", SqlDbType.Decimal,9),
					new SqlParameter("@预算表或损益表审批时间", SqlDbType.DateTime),
					new SqlParameter("@与伟通签订单项合同日期", SqlDbType.DateTime),
					new SqlParameter("@最新状态", SqlDbType.VarChar,50),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@年租金", SqlDbType.Decimal,9),
					new SqlParameter("@年限", SqlDbType.Decimal,9),
					new SqlParameter("@总收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通应收款", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@预计进场日期", SqlDbType.DateTime),
					new SqlParameter("@预计完工日期", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@选址定点", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成日期", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成百分比", SqlDbType.Decimal,9),
					new SqlParameter("@设计出图完成设计面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购开始日期", SqlDbType.DateTime),
					new SqlParameter("@产品采购主材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购辅材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装电梯百分比", SqlDbType.Decimal,9),
					new SqlParameter("@主机安装完成日期", SqlDbType.DateTime),
					new SqlParameter("@光缆到位完成日期", SqlDbType.DateTime),
					new SqlParameter("@设备开通完成日期", SqlDbType.DateTime),
					new SqlParameter("@销售验收日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付完成日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同完成日期", SqlDbType.DateTime),
					new SqlParameter("@是否退点", SqlDbType.VarChar,200),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.部门;
			parameters[2].Value = model.类别;
			parameters[3].Value = model.区域;
			parameters[4].Value = model.客户;
			parameters[5].Value = model.站点编码;
			parameters[6].Value = model.站点名称;
			parameters[7].Value = model.地址;
			parameters[8].Value = model.建站面积;
			parameters[9].Value = model.预算表或损益表审批时间;
			parameters[10].Value = model.与伟通签订单项合同日期;
			parameters[11].Value = model.最新状态;
			parameters[12].Value = model.经度;
			parameters[13].Value = model.纬度;
			parameters[14].Value = model.年租金;
			parameters[15].Value = model.年限;
			parameters[16].Value = model.总收入;
			parameters[17].Value = model.伟通应收款;
			parameters[18].Value = model.摘牌时间;
			parameters[19].Value = model.预计进场日期;
			parameters[20].Value = model.预计完工日期;
			parameters[21].Value = model.建站周期;
			parameters[22].Value = model.选址定点;
			parameters[23].Value = model.设计出图完成日期;
			parameters[24].Value = model.设计出图完成百分比;
			parameters[25].Value = model.设计出图完成设计面积;
			parameters[26].Value = model.产品采购开始日期;
			parameters[27].Value = model.产品采购主材百分比;
			parameters[28].Value = model.产品采购辅材百分比;
			parameters[29].Value = model.产品安装地停百分比;
			parameters[30].Value = model.产品安装地停面积;
			parameters[31].Value = model.产品安装平层百分比;
			parameters[32].Value = model.产品安装平层面积;
			parameters[33].Value = model.产品安装电梯百分比;
			parameters[34].Value = model.主机安装完成日期;
			parameters[35].Value = model.光缆到位完成日期;
			parameters[36].Value = model.设备开通完成日期;
			parameters[37].Value = model.销售验收日期;
			parameters[38].Value = model.运营商验收交付开始日期;
			parameters[39].Value = model.运营商验收交付完成日期;
			parameters[40].Value = model.运营商签订合同开始日期;
			parameters[41].Value = model.运营商签订合同完成日期;
			parameters[42].Value = model.是否退点;
			parameters[43].Value = model.备注;
			parameters[44].Value = model.IsDeleted;
			parameters[45].Value = model.CreateBy;
			parameters[46].Value = model.CreateTime;
			parameters[47].Value = model.UpdateBy;
			parameters[48].Value = model.UpdateTime;

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
		public bool Add(SqlTransaction tran,WTCJ.Model.JD_SF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JD_SF(");
			strSql.Append("id,部门,类别,区域,客户,站点编码,站点名称,地址,建站面积,预算表或损益表审批时间,与伟通签订单项合同日期,最新状态,经度,纬度,年租金,年限,总收入,伟通应收款,摘牌时间,预计进场日期,预计完工日期,建站周期,选址定点,设计出图完成日期,设计出图完成百分比,设计出图完成设计面积,产品采购开始日期,产品采购主材百分比,产品采购辅材百分比,产品安装地停百分比,产品安装地停面积,产品安装平层百分比,产品安装平层面积,产品安装电梯百分比,主机安装完成日期,光缆到位完成日期,设备开通完成日期,销售验收日期,运营商验收交付开始日期,运营商验收交付完成日期,运营商签订合同开始日期,运营商签订合同完成日期,是否退点,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@部门,@类别,@区域,@客户,@站点编码,@站点名称,@地址,@建站面积,@预算表或损益表审批时间,@与伟通签订单项合同日期,@最新状态,@经度,@纬度,@年租金,@年限,@总收入,@伟通应收款,@摘牌时间,@预计进场日期,@预计完工日期,@建站周期,@选址定点,@设计出图完成日期,@设计出图完成百分比,@设计出图完成设计面积,@产品采购开始日期,@产品采购主材百分比,@产品采购辅材百分比,@产品安装地停百分比,@产品安装地停面积,@产品安装平层百分比,@产品安装平层面积,@产品安装电梯百分比,@主机安装完成日期,@光缆到位完成日期,@设备开通完成日期,@销售验收日期,@运营商验收交付开始日期,@运营商验收交付完成日期,@运营商签订合同开始日期,@运营商签订合同完成日期,@是否退点,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@地址", SqlDbType.VarChar,500),
					new SqlParameter("@建站面积", SqlDbType.Decimal,9),
					new SqlParameter("@预算表或损益表审批时间", SqlDbType.DateTime),
					new SqlParameter("@与伟通签订单项合同日期", SqlDbType.DateTime),
					new SqlParameter("@最新状态", SqlDbType.VarChar,50),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@年租金", SqlDbType.Decimal,9),
					new SqlParameter("@年限", SqlDbType.Decimal,9),
					new SqlParameter("@总收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通应收款", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@预计进场日期", SqlDbType.DateTime),
					new SqlParameter("@预计完工日期", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@选址定点", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成日期", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成百分比", SqlDbType.Decimal,9),
					new SqlParameter("@设计出图完成设计面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购开始日期", SqlDbType.DateTime),
					new SqlParameter("@产品采购主材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购辅材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装电梯百分比", SqlDbType.Decimal,9),
					new SqlParameter("@主机安装完成日期", SqlDbType.DateTime),
					new SqlParameter("@光缆到位完成日期", SqlDbType.DateTime),
					new SqlParameter("@设备开通完成日期", SqlDbType.DateTime),
					new SqlParameter("@销售验收日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付完成日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同完成日期", SqlDbType.DateTime),
					new SqlParameter("@是否退点", SqlDbType.VarChar,200),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.部门;
			parameters[2].Value = model.类别;
			parameters[3].Value = model.区域;
			parameters[4].Value = model.客户;
			parameters[5].Value = model.站点编码;
			parameters[6].Value = model.站点名称;
			parameters[7].Value = model.地址;
			parameters[8].Value = model.建站面积;
			parameters[9].Value = model.预算表或损益表审批时间;
			parameters[10].Value = model.与伟通签订单项合同日期;
			parameters[11].Value = model.最新状态;
			parameters[12].Value = model.经度;
			parameters[13].Value = model.纬度;
			parameters[14].Value = model.年租金;
			parameters[15].Value = model.年限;
			parameters[16].Value = model.总收入;
			parameters[17].Value = model.伟通应收款;
			parameters[18].Value = model.摘牌时间;
			parameters[19].Value = model.预计进场日期;
			parameters[20].Value = model.预计完工日期;
			parameters[21].Value = model.建站周期;
			parameters[22].Value = model.选址定点;
			parameters[23].Value = model.设计出图完成日期;
			parameters[24].Value = model.设计出图完成百分比;
			parameters[25].Value = model.设计出图完成设计面积;
			parameters[26].Value = model.产品采购开始日期;
			parameters[27].Value = model.产品采购主材百分比;
			parameters[28].Value = model.产品采购辅材百分比;
			parameters[29].Value = model.产品安装地停百分比;
			parameters[30].Value = model.产品安装地停面积;
			parameters[31].Value = model.产品安装平层百分比;
			parameters[32].Value = model.产品安装平层面积;
			parameters[33].Value = model.产品安装电梯百分比;
			parameters[34].Value = model.主机安装完成日期;
			parameters[35].Value = model.光缆到位完成日期;
			parameters[36].Value = model.设备开通完成日期;
			parameters[37].Value = model.销售验收日期;
			parameters[38].Value = model.运营商验收交付开始日期;
			parameters[39].Value = model.运营商验收交付完成日期;
			parameters[40].Value = model.运营商签订合同开始日期;
			parameters[41].Value = model.运营商签订合同完成日期;
			parameters[42].Value = model.是否退点;
			parameters[43].Value = model.备注;
			parameters[44].Value = model.IsDeleted;
			parameters[45].Value = model.CreateBy;
			parameters[46].Value = model.CreateTime;
			parameters[47].Value = model.UpdateBy;
			parameters[48].Value = model.UpdateTime;

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
		public bool Update(WTCJ.Model.JD_SF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JD_SF set ");
			strSql.Append("部门=@部门,");
			strSql.Append("类别=@类别,");
			strSql.Append("区域=@区域,");
			strSql.Append("客户=@客户,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("地址=@地址,");
			strSql.Append("建站面积=@建站面积,");
			strSql.Append("预算表或损益表审批时间=@预算表或损益表审批时间,");
			strSql.Append("与伟通签订单项合同日期=@与伟通签订单项合同日期,");
			strSql.Append("最新状态=@最新状态,");
			strSql.Append("经度=@经度,");
			strSql.Append("纬度=@纬度,");
			strSql.Append("年租金=@年租金,");
			strSql.Append("年限=@年限,");
			strSql.Append("总收入=@总收入,");
			strSql.Append("伟通应收款=@伟通应收款,");
			strSql.Append("摘牌时间=@摘牌时间,");
			strSql.Append("预计进场日期=@预计进场日期,");
			strSql.Append("预计完工日期=@预计完工日期,");
			strSql.Append("建站周期=@建站周期,");
			strSql.Append("选址定点=@选址定点,");
			strSql.Append("设计出图完成日期=@设计出图完成日期,");
			strSql.Append("设计出图完成百分比=@设计出图完成百分比,");
			strSql.Append("设计出图完成设计面积=@设计出图完成设计面积,");
			strSql.Append("产品采购开始日期=@产品采购开始日期,");
			strSql.Append("产品采购主材百分比=@产品采购主材百分比,");
			strSql.Append("产品采购辅材百分比=@产品采购辅材百分比,");
			strSql.Append("产品安装地停百分比=@产品安装地停百分比,");
			strSql.Append("产品安装地停面积=@产品安装地停面积,");
			strSql.Append("产品安装平层百分比=@产品安装平层百分比,");
			strSql.Append("产品安装平层面积=@产品安装平层面积,");
			strSql.Append("产品安装电梯百分比=@产品安装电梯百分比,");
			strSql.Append("主机安装完成日期=@主机安装完成日期,");
			strSql.Append("光缆到位完成日期=@光缆到位完成日期,");
			strSql.Append("设备开通完成日期=@设备开通完成日期,");
			strSql.Append("销售验收日期=@销售验收日期,");
			strSql.Append("运营商验收交付开始日期=@运营商验收交付开始日期,");
			strSql.Append("运营商验收交付完成日期=@运营商验收交付完成日期,");
			strSql.Append("运营商签订合同开始日期=@运营商签订合同开始日期,");
			strSql.Append("运营商签订合同完成日期=@运营商签订合同完成日期,");
			strSql.Append("是否退点=@是否退点,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@地址", SqlDbType.VarChar,500),
					new SqlParameter("@建站面积", SqlDbType.Decimal,9),
					new SqlParameter("@预算表或损益表审批时间", SqlDbType.DateTime),
					new SqlParameter("@与伟通签订单项合同日期", SqlDbType.DateTime),
					new SqlParameter("@最新状态", SqlDbType.VarChar,50),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@年租金", SqlDbType.Decimal,9),
					new SqlParameter("@年限", SqlDbType.Decimal,9),
					new SqlParameter("@总收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通应收款", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@预计进场日期", SqlDbType.DateTime),
					new SqlParameter("@预计完工日期", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@选址定点", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成日期", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成百分比", SqlDbType.Decimal,9),
					new SqlParameter("@设计出图完成设计面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购开始日期", SqlDbType.DateTime),
					new SqlParameter("@产品采购主材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购辅材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装电梯百分比", SqlDbType.Decimal,9),
					new SqlParameter("@主机安装完成日期", SqlDbType.DateTime),
					new SqlParameter("@光缆到位完成日期", SqlDbType.DateTime),
					new SqlParameter("@设备开通完成日期", SqlDbType.DateTime),
					new SqlParameter("@销售验收日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付完成日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同完成日期", SqlDbType.DateTime),
					new SqlParameter("@是否退点", SqlDbType.VarChar,200),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,50)};
			parameters[0].Value = model.部门;
			parameters[1].Value = model.类别;
			parameters[2].Value = model.区域;
			parameters[3].Value = model.客户;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.站点名称;
			parameters[6].Value = model.地址;
			parameters[7].Value = model.建站面积;
			parameters[8].Value = model.预算表或损益表审批时间;
			parameters[9].Value = model.与伟通签订单项合同日期;
			parameters[10].Value = model.最新状态;
			parameters[11].Value = model.经度;
			parameters[12].Value = model.纬度;
			parameters[13].Value = model.年租金;
			parameters[14].Value = model.年限;
			parameters[15].Value = model.总收入;
			parameters[16].Value = model.伟通应收款;
			parameters[17].Value = model.摘牌时间;
			parameters[18].Value = model.预计进场日期;
			parameters[19].Value = model.预计完工日期;
			parameters[20].Value = model.建站周期;
			parameters[21].Value = model.选址定点;
			parameters[22].Value = model.设计出图完成日期;
			parameters[23].Value = model.设计出图完成百分比;
			parameters[24].Value = model.设计出图完成设计面积;
			parameters[25].Value = model.产品采购开始日期;
			parameters[26].Value = model.产品采购主材百分比;
			parameters[27].Value = model.产品采购辅材百分比;
			parameters[28].Value = model.产品安装地停百分比;
			parameters[29].Value = model.产品安装地停面积;
			parameters[30].Value = model.产品安装平层百分比;
			parameters[31].Value = model.产品安装平层面积;
			parameters[32].Value = model.产品安装电梯百分比;
			parameters[33].Value = model.主机安装完成日期;
			parameters[34].Value = model.光缆到位完成日期;
			parameters[35].Value = model.设备开通完成日期;
			parameters[36].Value = model.销售验收日期;
			parameters[37].Value = model.运营商验收交付开始日期;
			parameters[38].Value = model.运营商验收交付完成日期;
			parameters[39].Value = model.运营商签订合同开始日期;
			parameters[40].Value = model.运营商签订合同完成日期;
			parameters[41].Value = model.是否退点;
			parameters[42].Value = model.备注;
			parameters[43].Value = model.IsDeleted;
			parameters[44].Value = model.CreateBy;
			parameters[45].Value = model.CreateTime;
			parameters[46].Value = model.UpdateBy;
			parameters[47].Value = model.UpdateTime;
			parameters[48].Value = model.id;

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
		public bool Update(SqlTransaction tran,WTCJ.Model.JD_SF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JD_SF set ");
			strSql.Append("部门=@部门,");
			strSql.Append("类别=@类别,");
			strSql.Append("区域=@区域,");
			strSql.Append("客户=@客户,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("地址=@地址,");
			strSql.Append("建站面积=@建站面积,");
			strSql.Append("预算表或损益表审批时间=@预算表或损益表审批时间,");
			strSql.Append("与伟通签订单项合同日期=@与伟通签订单项合同日期,");
			strSql.Append("最新状态=@最新状态,");
			strSql.Append("经度=@经度,");
			strSql.Append("纬度=@纬度,");
			strSql.Append("年租金=@年租金,");
			strSql.Append("年限=@年限,");
			strSql.Append("总收入=@总收入,");
			strSql.Append("伟通应收款=@伟通应收款,");
			strSql.Append("摘牌时间=@摘牌时间,");
			strSql.Append("预计进场日期=@预计进场日期,");
			strSql.Append("预计完工日期=@预计完工日期,");
			strSql.Append("建站周期=@建站周期,");
			strSql.Append("选址定点=@选址定点,");
			strSql.Append("设计出图完成日期=@设计出图完成日期,");
			strSql.Append("设计出图完成百分比=@设计出图完成百分比,");
			strSql.Append("设计出图完成设计面积=@设计出图完成设计面积,");
			strSql.Append("产品采购开始日期=@产品采购开始日期,");
			strSql.Append("产品采购主材百分比=@产品采购主材百分比,");
			strSql.Append("产品采购辅材百分比=@产品采购辅材百分比,");
			strSql.Append("产品安装地停百分比=@产品安装地停百分比,");
			strSql.Append("产品安装地停面积=@产品安装地停面积,");
			strSql.Append("产品安装平层百分比=@产品安装平层百分比,");
			strSql.Append("产品安装平层面积=@产品安装平层面积,");
			strSql.Append("产品安装电梯百分比=@产品安装电梯百分比,");
			strSql.Append("主机安装完成日期=@主机安装完成日期,");
			strSql.Append("光缆到位完成日期=@光缆到位完成日期,");
			strSql.Append("设备开通完成日期=@设备开通完成日期,");
			strSql.Append("销售验收日期=@销售验收日期,");
			strSql.Append("运营商验收交付开始日期=@运营商验收交付开始日期,");
			strSql.Append("运营商验收交付完成日期=@运营商验收交付完成日期,");
			strSql.Append("运营商签订合同开始日期=@运营商签订合同开始日期,");
			strSql.Append("运营商签订合同完成日期=@运营商签订合同完成日期,");
			strSql.Append("是否退点=@是否退点,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@部门", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@地址", SqlDbType.VarChar,500),
					new SqlParameter("@建站面积", SqlDbType.Decimal,9),
					new SqlParameter("@预算表或损益表审批时间", SqlDbType.DateTime),
					new SqlParameter("@与伟通签订单项合同日期", SqlDbType.DateTime),
					new SqlParameter("@最新状态", SqlDbType.VarChar,50),
					new SqlParameter("@经度", SqlDbType.Decimal,9),
					new SqlParameter("@纬度", SqlDbType.Decimal,9),
					new SqlParameter("@年租金", SqlDbType.Decimal,9),
					new SqlParameter("@年限", SqlDbType.Decimal,9),
					new SqlParameter("@总收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通应收款", SqlDbType.Decimal,9),
					new SqlParameter("@摘牌时间", SqlDbType.DateTime),
					new SqlParameter("@预计进场日期", SqlDbType.DateTime),
					new SqlParameter("@预计完工日期", SqlDbType.DateTime),
					new SqlParameter("@建站周期", SqlDbType.Int,4),
					new SqlParameter("@选址定点", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成日期", SqlDbType.DateTime),
					new SqlParameter("@设计出图完成百分比", SqlDbType.Decimal,9),
					new SqlParameter("@设计出图完成设计面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购开始日期", SqlDbType.DateTime),
					new SqlParameter("@产品采购主材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品采购辅材百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装地停面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层百分比", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装平层面积", SqlDbType.Decimal,9),
					new SqlParameter("@产品安装电梯百分比", SqlDbType.Decimal,9),
					new SqlParameter("@主机安装完成日期", SqlDbType.DateTime),
					new SqlParameter("@光缆到位完成日期", SqlDbType.DateTime),
					new SqlParameter("@设备开通完成日期", SqlDbType.DateTime),
					new SqlParameter("@销售验收日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付完成日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同开始日期", SqlDbType.DateTime),
					new SqlParameter("@运营商签订合同完成日期", SqlDbType.DateTime),
					new SqlParameter("@是否退点", SqlDbType.VarChar,200),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,50)};
			parameters[0].Value = model.部门;
			parameters[1].Value = model.类别;
			parameters[2].Value = model.区域;
			parameters[3].Value = model.客户;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.站点名称;
			parameters[6].Value = model.地址;
			parameters[7].Value = model.建站面积;
			parameters[8].Value = model.预算表或损益表审批时间;
			parameters[9].Value = model.与伟通签订单项合同日期;
			parameters[10].Value = model.最新状态;
			parameters[11].Value = model.经度;
			parameters[12].Value = model.纬度;
			parameters[13].Value = model.年租金;
			parameters[14].Value = model.年限;
			parameters[15].Value = model.总收入;
			parameters[16].Value = model.伟通应收款;
			parameters[17].Value = model.摘牌时间;
			parameters[18].Value = model.预计进场日期;
			parameters[19].Value = model.预计完工日期;
			parameters[20].Value = model.建站周期;
			parameters[21].Value = model.选址定点;
			parameters[22].Value = model.设计出图完成日期;
			parameters[23].Value = model.设计出图完成百分比;
			parameters[24].Value = model.设计出图完成设计面积;
			parameters[25].Value = model.产品采购开始日期;
			parameters[26].Value = model.产品采购主材百分比;
			parameters[27].Value = model.产品采购辅材百分比;
			parameters[28].Value = model.产品安装地停百分比;
			parameters[29].Value = model.产品安装地停面积;
			parameters[30].Value = model.产品安装平层百分比;
			parameters[31].Value = model.产品安装平层面积;
			parameters[32].Value = model.产品安装电梯百分比;
			parameters[33].Value = model.主机安装完成日期;
			parameters[34].Value = model.光缆到位完成日期;
			parameters[35].Value = model.设备开通完成日期;
			parameters[36].Value = model.销售验收日期;
			parameters[37].Value = model.运营商验收交付开始日期;
			parameters[38].Value = model.运营商验收交付完成日期;
			parameters[39].Value = model.运营商签订合同开始日期;
			parameters[40].Value = model.运营商签订合同完成日期;
			parameters[41].Value = model.是否退点;
			parameters[42].Value = model.备注;
			parameters[43].Value = model.IsDeleted;
			parameters[44].Value = model.CreateBy;
			parameters[45].Value = model.CreateTime;
			parameters[46].Value = model.UpdateBy;
			parameters[47].Value = model.UpdateTime;
			parameters[48].Value = model.id;

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
			strSql.Append("delete from JD_SF ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
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
			strSql.Append("delete from JD_SF ");
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
		public WTCJ.Model.JD_SF GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,部门,类别,区域,客户,站点编码,站点名称,地址,建站面积,预算表或损益表审批时间,与伟通签订单项合同日期,最新状态,经度,纬度,年租金,年限,总收入,伟通应收款,摘牌时间,预计进场日期,预计完工日期,建站周期,选址定点,设计出图完成日期,设计出图完成百分比,设计出图完成设计面积,产品采购开始日期,产品采购主材百分比,产品采购辅材百分比,产品安装地停百分比,产品安装地停面积,产品安装平层百分比,产品安装平层面积,产品安装电梯百分比,主机安装完成日期,光缆到位完成日期,设备开通完成日期,销售验收日期,运营商验收交付开始日期,运营商验收交付完成日期,运营商签订合同开始日期,运营商签订合同完成日期,是否退点,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime from JD_SF ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;

			WTCJ.Model.JD_SF model=new WTCJ.Model.JD_SF();
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
		public WTCJ.Model.JD_SF DataRowToModel(DataRow row)
		{
			WTCJ.Model.JD_SF model=new WTCJ.Model.JD_SF();
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
				if(row["类别"]!=null)
				{
					model.类别=row["类别"].ToString();
				}
				if(row["区域"]!=null)
				{
					model.区域=row["区域"].ToString();
				}
				if(row["客户"]!=null)
				{
					model.客户=row["客户"].ToString();
				}
				if(row["站点编码"]!=null)
				{
					model.站点编码=row["站点编码"].ToString();
				}
				if(row["站点名称"]!=null)
				{
					model.站点名称=row["站点名称"].ToString();
				}
				if(row["地址"]!=null)
				{
					model.地址=row["地址"].ToString();
				}
				if(row["建站面积"]!=null && row["建站面积"].ToString()!="")
				{
					model.建站面积=decimal.Parse(row["建站面积"].ToString());
				}
				if(row["预算表或损益表审批时间"]!=null && row["预算表或损益表审批时间"].ToString()!="")
				{
					model.预算表或损益表审批时间=DateTime.Parse(row["预算表或损益表审批时间"].ToString());
				}
				if(row["与伟通签订单项合同日期"]!=null && row["与伟通签订单项合同日期"].ToString()!="")
				{
					model.与伟通签订单项合同日期=DateTime.Parse(row["与伟通签订单项合同日期"].ToString());
				}
				if(row["最新状态"]!=null)
				{
					model.最新状态=row["最新状态"].ToString();
				}
				if(row["经度"]!=null && row["经度"].ToString()!="")
				{
					model.经度=decimal.Parse(row["经度"].ToString());
				}
				if(row["纬度"]!=null && row["纬度"].ToString()!="")
				{
					model.纬度=decimal.Parse(row["纬度"].ToString());
				}
				if(row["年租金"]!=null && row["年租金"].ToString()!="")
				{
					model.年租金=decimal.Parse(row["年租金"].ToString());
				}
				if(row["年限"]!=null && row["年限"].ToString()!="")
				{
					model.年限=decimal.Parse(row["年限"].ToString());
				}
				if(row["总收入"]!=null && row["总收入"].ToString()!="")
				{
					model.总收入=decimal.Parse(row["总收入"].ToString());
				}
				if(row["伟通应收款"]!=null && row["伟通应收款"].ToString()!="")
				{
					model.伟通应收款=decimal.Parse(row["伟通应收款"].ToString());
				}
				if(row["摘牌时间"]!=null && row["摘牌时间"].ToString()!="")
				{
					model.摘牌时间=DateTime.Parse(row["摘牌时间"].ToString());
				}
				if(row["预计进场日期"]!=null && row["预计进场日期"].ToString()!="")
				{
					model.预计进场日期=DateTime.Parse(row["预计进场日期"].ToString());
				}
				if(row["预计完工日期"]!=null && row["预计完工日期"].ToString()!="")
				{
					model.预计完工日期=DateTime.Parse(row["预计完工日期"].ToString());
				}
				if(row["建站周期"]!=null && row["建站周期"].ToString()!="")
				{
					model.建站周期=int.Parse(row["建站周期"].ToString());
				}
				if(row["选址定点"]!=null && row["选址定点"].ToString()!="")
				{
					model.选址定点=DateTime.Parse(row["选址定点"].ToString());
				}
				if(row["设计出图完成日期"]!=null && row["设计出图完成日期"].ToString()!="")
				{
					model.设计出图完成日期=DateTime.Parse(row["设计出图完成日期"].ToString());
				}
				if(row["设计出图完成百分比"]!=null && row["设计出图完成百分比"].ToString()!="")
				{
					model.设计出图完成百分比=decimal.Parse(row["设计出图完成百分比"].ToString());
				}
				if(row["设计出图完成设计面积"]!=null && row["设计出图完成设计面积"].ToString()!="")
				{
					model.设计出图完成设计面积=decimal.Parse(row["设计出图完成设计面积"].ToString());
				}
				if(row["产品采购开始日期"]!=null && row["产品采购开始日期"].ToString()!="")
				{
					model.产品采购开始日期=DateTime.Parse(row["产品采购开始日期"].ToString());
				}
				if(row["产品采购主材百分比"]!=null && row["产品采购主材百分比"].ToString()!="")
				{
					model.产品采购主材百分比=decimal.Parse(row["产品采购主材百分比"].ToString());
				}
				if(row["产品采购辅材百分比"]!=null && row["产品采购辅材百分比"].ToString()!="")
				{
					model.产品采购辅材百分比=decimal.Parse(row["产品采购辅材百分比"].ToString());
				}
				if(row["产品安装地停百分比"]!=null && row["产品安装地停百分比"].ToString()!="")
				{
					model.产品安装地停百分比=decimal.Parse(row["产品安装地停百分比"].ToString());
				}
				if(row["产品安装地停面积"]!=null && row["产品安装地停面积"].ToString()!="")
				{
					model.产品安装地停面积=decimal.Parse(row["产品安装地停面积"].ToString());
				}
				if(row["产品安装平层百分比"]!=null && row["产品安装平层百分比"].ToString()!="")
				{
					model.产品安装平层百分比=decimal.Parse(row["产品安装平层百分比"].ToString());
				}
				if(row["产品安装平层面积"]!=null && row["产品安装平层面积"].ToString()!="")
				{
					model.产品安装平层面积=decimal.Parse(row["产品安装平层面积"].ToString());
				}
				if(row["产品安装电梯百分比"]!=null && row["产品安装电梯百分比"].ToString()!="")
				{
					model.产品安装电梯百分比=decimal.Parse(row["产品安装电梯百分比"].ToString());
				}
				if(row["主机安装完成日期"]!=null && row["主机安装完成日期"].ToString()!="")
				{
					model.主机安装完成日期=DateTime.Parse(row["主机安装完成日期"].ToString());
				}
				if(row["光缆到位完成日期"]!=null && row["光缆到位完成日期"].ToString()!="")
				{
					model.光缆到位完成日期=DateTime.Parse(row["光缆到位完成日期"].ToString());
				}
				if(row["设备开通完成日期"]!=null && row["设备开通完成日期"].ToString()!="")
				{
					model.设备开通完成日期=DateTime.Parse(row["设备开通完成日期"].ToString());
				}
				if(row["销售验收日期"]!=null && row["销售验收日期"].ToString()!="")
				{
					model.销售验收日期=DateTime.Parse(row["销售验收日期"].ToString());
				}
				if(row["运营商验收交付开始日期"]!=null && row["运营商验收交付开始日期"].ToString()!="")
				{
					model.运营商验收交付开始日期=DateTime.Parse(row["运营商验收交付开始日期"].ToString());
				}
				if(row["运营商验收交付完成日期"]!=null && row["运营商验收交付完成日期"].ToString()!="")
				{
					model.运营商验收交付完成日期=DateTime.Parse(row["运营商验收交付完成日期"].ToString());
				}
				if(row["运营商签订合同开始日期"]!=null && row["运营商签订合同开始日期"].ToString()!="")
				{
					model.运营商签订合同开始日期=DateTime.Parse(row["运营商签订合同开始日期"].ToString());
				}
				if(row["运营商签订合同完成日期"]!=null && row["运营商签订合同完成日期"].ToString()!="")
				{
					model.运营商签订合同完成日期=DateTime.Parse(row["运营商签订合同完成日期"].ToString());
				}
				if(row["是否退点"]!=null)
				{
					model.是否退点=row["是否退点"].ToString();
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
			strSql.Append("select id,部门,类别,区域,客户,站点编码,站点名称,地址,建站面积,预算表或损益表审批时间,与伟通签订单项合同日期,最新状态,经度,纬度,年租金,年限,总收入,伟通应收款,摘牌时间,预计进场日期,预计完工日期,建站周期,选址定点,设计出图完成日期,设计出图完成百分比,设计出图完成设计面积,产品采购开始日期,产品采购主材百分比,产品采购辅材百分比,产品安装地停百分比,产品安装地停面积,产品安装平层百分比,产品安装平层面积,产品安装电梯百分比,主机安装完成日期,光缆到位完成日期,设备开通完成日期,销售验收日期,运营商验收交付开始日期,运营商验收交付完成日期,运营商签订合同开始日期,运营商签订合同完成日期,是否退点,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM JD_SF ");
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
			strSql.Append(" id,部门,类别,区域,客户,站点编码,站点名称,地址,建站面积,预算表或损益表审批时间,与伟通签订单项合同日期,最新状态,经度,纬度,年租金,年限,总收入,伟通应收款,摘牌时间,预计进场日期,预计完工日期,建站周期,选址定点,设计出图完成日期,设计出图完成百分比,设计出图完成设计面积,产品采购开始日期,产品采购主材百分比,产品采购辅材百分比,产品安装地停百分比,产品安装地停面积,产品安装平层百分比,产品安装平层面积,产品安装电梯百分比,主机安装完成日期,光缆到位完成日期,设备开通完成日期,销售验收日期,运营商验收交付开始日期,运营商验收交付完成日期,运营商签订合同开始日期,运营商签订合同完成日期,是否退点,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM JD_SF ");
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
			strSql.Append("select id,部门,类别,区域,客户,站点编码,站点名称,地址,建站面积,预算表或损益表审批时间,与伟通签订单项合同日期,最新状态,经度,纬度,年租金,年限,总收入,伟通应收款,摘牌时间,预计进场日期,预计完工日期,建站周期,选址定点,设计出图完成日期,设计出图完成百分比,设计出图完成设计面积,产品采购开始日期,产品采购主材百分比,产品采购辅材百分比,产品安装地停百分比,产品安装地停面积,产品安装平层百分比,产品安装平层面积,产品安装电梯百分比,主机安装完成日期,光缆到位完成日期,设备开通完成日期,销售验收日期,运营商验收交付开始日期,运营商验收交付完成日期,运营商签订合同开始日期,运营商签订合同完成日期,是否退点,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM JD_SF ");
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
			strSql.Append("select count(1) FROM JD_SF ");
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
			strSql.Append(")AS Row, T.*  from JD_SF T ");
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
			parameters[0].Value = "JD_SF";
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


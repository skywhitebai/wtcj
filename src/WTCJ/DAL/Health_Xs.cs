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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WTCJ.DBUtility;//Please add references
namespace WTCJ.DAL
{
	/// <summary>
	/// 数据访问类:Health_Xs
	/// </summary>
	public partial class Health_Xs
	{
		public Health_Xs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Health_Xs");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.Health_Xs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Health_Xs(");
			strSql.Append("id,区域,客户名称,站点名称,站点编码,回款期限,租金金额,基站销售款,累计应收金额,税率,伟通收入不含税,_2016年开票时间,_2016年开票金额,_2016年合同收款时间,_2016年合同收款金额,_2016年实际回款金额,_2016年应收未收金额,_2016年到期应收未收金额,_2016年实际回款时间,_2017年开票时间,_2017年开票金额,_2017年合同收款时间,_2017年合同收款金额,_2017年实际回款金额,_2017年应收未收金额,_2017年到期应收未收金额,_2017年实际回款时间,_2018年开票时间,_2018年开票金额,_2018年合同收款时间,_2018年合同收款金额,_2018年实际回款金额,_2018年应收未收金额,_2018年到期应收未收金额,_2018年实际回款时间,_2019年开票时间,_2019年开票金额,_2019年合同收款时间,_2019年合同收款金额,_2019年实际回款金额,_2019年应收未收金额,_2019年到期应收未收金额,_2019年实际回款时间,_2020年开票时间,_2020年开票金额,_2020年合同收款时间,_2020年合同收款金额,_2020年实际回款金额,_2020年应收未收金额,_2020年到期应收未收金额,_2020年实际回款时间,_2021年开票时间,_2021年开票金额,_2021年合同收款时间,_2021年合同收款金额,_2021年实际回款金额,_2021年应收未收金额,_2021年到期应收未收金额,_2021年实际回款时间,_2022年开票时间,_2022年开票金额,_2022年合同收款时间,_2022年合同收款金额,_2022年实际回款金额,_2022年应收未收金额,_2022年到期应收未收金额,_2022年实际回款时间,_2023年开票时间,_2023年开票金额,_2023年合同收款时间,_2023年合同收款金额,_2023年实际回款金额,_2023年应收未收金额,_2023年到期应收未收金额,_2023年实际回款时间,_2024年开票时间,_2024年开票金额,_2024年合同收款时间,_2024年合同收款金额,_2024年实际回款金额,_2024年应收未收金额,_2024年到期应收未收金额,_2024年实际回款时间,_2025年开票时间,_2025年开票金额,_2025年合同收款时间,_2025年合同收款金额,_2025年实际回款金额,_2025年应收未收金额,_2025年到期应收未收金额,_2025年实际回款时间,_2026年开票时间,_2026年开票金额,_2026年合同收款时间,_2026年合同收款金额,_2026年实际回款金额,_2026年应收未收金额,_2026年到期应收未收金额,_2026年实际回款时间,_2027年开票时间,_2027年开票金额,_2027年合同收款时间,_2027年合同收款金额,_2027年实际回款金额,_2027年应收未收金额,_2027年到期应收未收金额,_2027年实际回款时间,_2028年开票时间,_2028年开票金额,_2028年合同收款时间,_2028年合同收款金额,_2028年实际回款金额,_2028年应收未收金额,_2028年到期应收未收金额,_2028年实际回款时间,_2029年开票时间,_2029年开票金额,_2029年合同收款时间,_2029年合同收款金额,_2029年实际回款金额,_2029年应收未收金额,_2029年到期应收未收金额,_2029年实际回款时间,_2030年开票时间,_2030年开票金额,_2030年合同收款时间,_2030年合同收款金额,_2030年实际回款金额,_2030年应收未收金额,_2030年到期应收未收金额,_2030年实际回款时间,推迟收款时间,实际竣工时间,竣工与实际收款时间差异,移动交付,电信交付,联通交付,铁塔交付,运营商合同签订日期,运营商交付单与租赁合同时间差,移动实际付款时间,电信实际付款时间,联通实际付款时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@区域,@客户名称,@站点名称,@站点编码,@回款期限,@租金金额,@基站销售款,@累计应收金额,@税率,@伟通收入不含税,@_2016年开票时间,@_2016年开票金额,@_2016年合同收款时间,@_2016年合同收款金额,@_2016年实际回款金额,@_2016年应收未收金额,@_2016年到期应收未收金额,@_2016年实际回款时间,@_2017年开票时间,@_2017年开票金额,@_2017年合同收款时间,@_2017年合同收款金额,@_2017年实际回款金额,@_2017年应收未收金额,@_2017年到期应收未收金额,@_2017年实际回款时间,@_2018年开票时间,@_2018年开票金额,@_2018年合同收款时间,@_2018年合同收款金额,@_2018年实际回款金额,@_2018年应收未收金额,@_2018年到期应收未收金额,@_2018年实际回款时间,@_2019年开票时间,@_2019年开票金额,@_2019年合同收款时间,@_2019年合同收款金额,@_2019年实际回款金额,@_2019年应收未收金额,@_2019年到期应收未收金额,@_2019年实际回款时间,@_2020年开票时间,@_2020年开票金额,@_2020年合同收款时间,@_2020年合同收款金额,@_2020年实际回款金额,@_2020年应收未收金额,@_2020年到期应收未收金额,@_2020年实际回款时间,@_2021年开票时间,@_2021年开票金额,@_2021年合同收款时间,@_2021年合同收款金额,@_2021年实际回款金额,@_2021年应收未收金额,@_2021年到期应收未收金额,@_2021年实际回款时间,@_2022年开票时间,@_2022年开票金额,@_2022年合同收款时间,@_2022年合同收款金额,@_2022年实际回款金额,@_2022年应收未收金额,@_2022年到期应收未收金额,@_2022年实际回款时间,@_2023年开票时间,@_2023年开票金额,@_2023年合同收款时间,@_2023年合同收款金额,@_2023年实际回款金额,@_2023年应收未收金额,@_2023年到期应收未收金额,@_2023年实际回款时间,@_2024年开票时间,@_2024年开票金额,@_2024年合同收款时间,@_2024年合同收款金额,@_2024年实际回款金额,@_2024年应收未收金额,@_2024年到期应收未收金额,@_2024年实际回款时间,@_2025年开票时间,@_2025年开票金额,@_2025年合同收款时间,@_2025年合同收款金额,@_2025年实际回款金额,@_2025年应收未收金额,@_2025年到期应收未收金额,@_2025年实际回款时间,@_2026年开票时间,@_2026年开票金额,@_2026年合同收款时间,@_2026年合同收款金额,@_2026年实际回款金额,@_2026年应收未收金额,@_2026年到期应收未收金额,@_2026年实际回款时间,@_2027年开票时间,@_2027年开票金额,@_2027年合同收款时间,@_2027年合同收款金额,@_2027年实际回款金额,@_2027年应收未收金额,@_2027年到期应收未收金额,@_2027年实际回款时间,@_2028年开票时间,@_2028年开票金额,@_2028年合同收款时间,@_2028年合同收款金额,@_2028年实际回款金额,@_2028年应收未收金额,@_2028年到期应收未收金额,@_2028年实际回款时间,@_2029年开票时间,@_2029年开票金额,@_2029年合同收款时间,@_2029年合同收款金额,@_2029年实际回款金额,@_2029年应收未收金额,@_2029年到期应收未收金额,@_2029年实际回款时间,@_2030年开票时间,@_2030年开票金额,@_2030年合同收款时间,@_2030年合同收款金额,@_2030年实际回款金额,@_2030年应收未收金额,@_2030年到期应收未收金额,@_2030年实际回款时间,@推迟收款时间,@实际竣工时间,@竣工与实际收款时间差异,@移动交付,@电信交付,@联通交付,@铁塔交付,@运营商合同签订日期,@运营商交付单与租赁合同时间差,@移动实际付款时间,@电信实际付款时间,@联通实际付款时间,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@回款期限", SqlDbType.VarChar,200),
					new SqlParameter("@租金金额", SqlDbType.Decimal,9),
					new SqlParameter("@基站销售款", SqlDbType.Decimal,9),
					new SqlParameter("@累计应收金额", SqlDbType.Decimal,9),
					new SqlParameter("@税率", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入不含税", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@推迟收款时间", SqlDbType.Decimal,9),
					new SqlParameter("@实际竣工时间", SqlDbType.DateTime),
					new SqlParameter("@竣工与实际收款时间差异", SqlDbType.Decimal,9),
					new SqlParameter("@移动交付", SqlDbType.DateTime),
					new SqlParameter("@电信交付", SqlDbType.DateTime),
					new SqlParameter("@联通交付", SqlDbType.DateTime),
					new SqlParameter("@铁塔交付", SqlDbType.DateTime),
					new SqlParameter("@运营商合同签订日期", SqlDbType.DateTime),
					new SqlParameter("@运营商交付单与租赁合同时间差", SqlDbType.Decimal,9),
					new SqlParameter("@移动实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@电信实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@联通实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.区域;
			parameters[2].Value = model.客户名称;
			parameters[3].Value = model.站点名称;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.回款期限;
			parameters[6].Value = model.租金金额;
			parameters[7].Value = model.基站销售款;
			parameters[8].Value = model.累计应收金额;
			parameters[9].Value = model.税率;
			parameters[10].Value = model.伟通收入不含税;
			parameters[11].Value = model._2016年开票时间;
			parameters[12].Value = model._2016年开票金额;
			parameters[13].Value = model._2016年合同收款时间;
			parameters[14].Value = model._2016年合同收款金额;
			parameters[15].Value = model._2016年实际回款金额;
			parameters[16].Value = model._2016年应收未收金额;
			parameters[17].Value = model._2016年到期应收未收金额;
			parameters[18].Value = model._2016年实际回款时间;
			parameters[19].Value = model._2017年开票时间;
			parameters[20].Value = model._2017年开票金额;
			parameters[21].Value = model._2017年合同收款时间;
			parameters[22].Value = model._2017年合同收款金额;
			parameters[23].Value = model._2017年实际回款金额;
			parameters[24].Value = model._2017年应收未收金额;
			parameters[25].Value = model._2017年到期应收未收金额;
			parameters[26].Value = model._2017年实际回款时间;
			parameters[27].Value = model._2018年开票时间;
			parameters[28].Value = model._2018年开票金额;
			parameters[29].Value = model._2018年合同收款时间;
			parameters[30].Value = model._2018年合同收款金额;
			parameters[31].Value = model._2018年实际回款金额;
			parameters[32].Value = model._2018年应收未收金额;
			parameters[33].Value = model._2018年到期应收未收金额;
			parameters[34].Value = model._2018年实际回款时间;
			parameters[35].Value = model._2019年开票时间;
			parameters[36].Value = model._2019年开票金额;
			parameters[37].Value = model._2019年合同收款时间;
			parameters[38].Value = model._2019年合同收款金额;
			parameters[39].Value = model._2019年实际回款金额;
			parameters[40].Value = model._2019年应收未收金额;
			parameters[41].Value = model._2019年到期应收未收金额;
			parameters[42].Value = model._2019年实际回款时间;
			parameters[43].Value = model._2020年开票时间;
			parameters[44].Value = model._2020年开票金额;
			parameters[45].Value = model._2020年合同收款时间;
			parameters[46].Value = model._2020年合同收款金额;
			parameters[47].Value = model._2020年实际回款金额;
			parameters[48].Value = model._2020年应收未收金额;
			parameters[49].Value = model._2020年到期应收未收金额;
			parameters[50].Value = model._2020年实际回款时间;
			parameters[51].Value = model._2021年开票时间;
			parameters[52].Value = model._2021年开票金额;
			parameters[53].Value = model._2021年合同收款时间;
			parameters[54].Value = model._2021年合同收款金额;
			parameters[55].Value = model._2021年实际回款金额;
			parameters[56].Value = model._2021年应收未收金额;
			parameters[57].Value = model._2021年到期应收未收金额;
			parameters[58].Value = model._2021年实际回款时间;
			parameters[59].Value = model._2022年开票时间;
			parameters[60].Value = model._2022年开票金额;
			parameters[61].Value = model._2022年合同收款时间;
			parameters[62].Value = model._2022年合同收款金额;
			parameters[63].Value = model._2022年实际回款金额;
			parameters[64].Value = model._2022年应收未收金额;
			parameters[65].Value = model._2022年到期应收未收金额;
			parameters[66].Value = model._2022年实际回款时间;
			parameters[67].Value = model._2023年开票时间;
			parameters[68].Value = model._2023年开票金额;
			parameters[69].Value = model._2023年合同收款时间;
			parameters[70].Value = model._2023年合同收款金额;
			parameters[71].Value = model._2023年实际回款金额;
			parameters[72].Value = model._2023年应收未收金额;
			parameters[73].Value = model._2023年到期应收未收金额;
			parameters[74].Value = model._2023年实际回款时间;
			parameters[75].Value = model._2024年开票时间;
			parameters[76].Value = model._2024年开票金额;
			parameters[77].Value = model._2024年合同收款时间;
			parameters[78].Value = model._2024年合同收款金额;
			parameters[79].Value = model._2024年实际回款金额;
			parameters[80].Value = model._2024年应收未收金额;
			parameters[81].Value = model._2024年到期应收未收金额;
			parameters[82].Value = model._2024年实际回款时间;
			parameters[83].Value = model._2025年开票时间;
			parameters[84].Value = model._2025年开票金额;
			parameters[85].Value = model._2025年合同收款时间;
			parameters[86].Value = model._2025年合同收款金额;
			parameters[87].Value = model._2025年实际回款金额;
			parameters[88].Value = model._2025年应收未收金额;
			parameters[89].Value = model._2025年到期应收未收金额;
			parameters[90].Value = model._2025年实际回款时间;
			parameters[91].Value = model._2026年开票时间;
			parameters[92].Value = model._2026年开票金额;
			parameters[93].Value = model._2026年合同收款时间;
			parameters[94].Value = model._2026年合同收款金额;
			parameters[95].Value = model._2026年实际回款金额;
			parameters[96].Value = model._2026年应收未收金额;
			parameters[97].Value = model._2026年到期应收未收金额;
			parameters[98].Value = model._2026年实际回款时间;
			parameters[99].Value = model._2027年开票时间;
			parameters[100].Value = model._2027年开票金额;
			parameters[101].Value = model._2027年合同收款时间;
			parameters[102].Value = model._2027年合同收款金额;
			parameters[103].Value = model._2027年实际回款金额;
			parameters[104].Value = model._2027年应收未收金额;
			parameters[105].Value = model._2027年到期应收未收金额;
			parameters[106].Value = model._2027年实际回款时间;
			parameters[107].Value = model._2028年开票时间;
			parameters[108].Value = model._2028年开票金额;
			parameters[109].Value = model._2028年合同收款时间;
			parameters[110].Value = model._2028年合同收款金额;
			parameters[111].Value = model._2028年实际回款金额;
			parameters[112].Value = model._2028年应收未收金额;
			parameters[113].Value = model._2028年到期应收未收金额;
			parameters[114].Value = model._2028年实际回款时间;
			parameters[115].Value = model._2029年开票时间;
			parameters[116].Value = model._2029年开票金额;
			parameters[117].Value = model._2029年合同收款时间;
			parameters[118].Value = model._2029年合同收款金额;
			parameters[119].Value = model._2029年实际回款金额;
			parameters[120].Value = model._2029年应收未收金额;
			parameters[121].Value = model._2029年到期应收未收金额;
			parameters[122].Value = model._2029年实际回款时间;
			parameters[123].Value = model._2030年开票时间;
			parameters[124].Value = model._2030年开票金额;
			parameters[125].Value = model._2030年合同收款时间;
			parameters[126].Value = model._2030年合同收款金额;
			parameters[127].Value = model._2030年实际回款金额;
			parameters[128].Value = model._2030年应收未收金额;
			parameters[129].Value = model._2030年到期应收未收金额;
			parameters[130].Value = model._2030年实际回款时间;
			parameters[131].Value = model.推迟收款时间;
			parameters[132].Value = model.实际竣工时间;
			parameters[133].Value = model.竣工与实际收款时间差异;
			parameters[134].Value = model.移动交付;
			parameters[135].Value = model.电信交付;
			parameters[136].Value = model.联通交付;
			parameters[137].Value = model.铁塔交付;
			parameters[138].Value = model.运营商合同签订日期;
			parameters[139].Value = model.运营商交付单与租赁合同时间差;
			parameters[140].Value = model.移动实际付款时间;
			parameters[141].Value = model.电信实际付款时间;
			parameters[142].Value = model.联通实际付款时间;
			parameters[143].Value = model.备注;
			parameters[144].Value = model.IsDeleted;
			parameters[145].Value = model.CreateBy;
			parameters[146].Value = model.CreateTime;
			parameters[147].Value = model.UpdateBy;
			parameters[148].Value = model.UpdateTime;

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
		public bool Add(SqlTransaction tran,WTCJ.Model.Health_Xs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Health_Xs(");
			strSql.Append("id,区域,客户名称,站点名称,站点编码,回款期限,租金金额,基站销售款,累计应收金额,税率,伟通收入不含税,_2016年开票时间,_2016年开票金额,_2016年合同收款时间,_2016年合同收款金额,_2016年实际回款金额,_2016年应收未收金额,_2016年到期应收未收金额,_2016年实际回款时间,_2017年开票时间,_2017年开票金额,_2017年合同收款时间,_2017年合同收款金额,_2017年实际回款金额,_2017年应收未收金额,_2017年到期应收未收金额,_2017年实际回款时间,_2018年开票时间,_2018年开票金额,_2018年合同收款时间,_2018年合同收款金额,_2018年实际回款金额,_2018年应收未收金额,_2018年到期应收未收金额,_2018年实际回款时间,_2019年开票时间,_2019年开票金额,_2019年合同收款时间,_2019年合同收款金额,_2019年实际回款金额,_2019年应收未收金额,_2019年到期应收未收金额,_2019年实际回款时间,_2020年开票时间,_2020年开票金额,_2020年合同收款时间,_2020年合同收款金额,_2020年实际回款金额,_2020年应收未收金额,_2020年到期应收未收金额,_2020年实际回款时间,_2021年开票时间,_2021年开票金额,_2021年合同收款时间,_2021年合同收款金额,_2021年实际回款金额,_2021年应收未收金额,_2021年到期应收未收金额,_2021年实际回款时间,_2022年开票时间,_2022年开票金额,_2022年合同收款时间,_2022年合同收款金额,_2022年实际回款金额,_2022年应收未收金额,_2022年到期应收未收金额,_2022年实际回款时间,_2023年开票时间,_2023年开票金额,_2023年合同收款时间,_2023年合同收款金额,_2023年实际回款金额,_2023年应收未收金额,_2023年到期应收未收金额,_2023年实际回款时间,_2024年开票时间,_2024年开票金额,_2024年合同收款时间,_2024年合同收款金额,_2024年实际回款金额,_2024年应收未收金额,_2024年到期应收未收金额,_2024年实际回款时间,_2025年开票时间,_2025年开票金额,_2025年合同收款时间,_2025年合同收款金额,_2025年实际回款金额,_2025年应收未收金额,_2025年到期应收未收金额,_2025年实际回款时间,_2026年开票时间,_2026年开票金额,_2026年合同收款时间,_2026年合同收款金额,_2026年实际回款金额,_2026年应收未收金额,_2026年到期应收未收金额,_2026年实际回款时间,_2027年开票时间,_2027年开票金额,_2027年合同收款时间,_2027年合同收款金额,_2027年实际回款金额,_2027年应收未收金额,_2027年到期应收未收金额,_2027年实际回款时间,_2028年开票时间,_2028年开票金额,_2028年合同收款时间,_2028年合同收款金额,_2028年实际回款金额,_2028年应收未收金额,_2028年到期应收未收金额,_2028年实际回款时间,_2029年开票时间,_2029年开票金额,_2029年合同收款时间,_2029年合同收款金额,_2029年实际回款金额,_2029年应收未收金额,_2029年到期应收未收金额,_2029年实际回款时间,_2030年开票时间,_2030年开票金额,_2030年合同收款时间,_2030年合同收款金额,_2030年实际回款金额,_2030年应收未收金额,_2030年到期应收未收金额,_2030年实际回款时间,推迟收款时间,实际竣工时间,竣工与实际收款时间差异,移动交付,电信交付,联通交付,铁塔交付,运营商合同签订日期,运营商交付单与租赁合同时间差,移动实际付款时间,电信实际付款时间,联通实际付款时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@区域,@客户名称,@站点名称,@站点编码,@回款期限,@租金金额,@基站销售款,@累计应收金额,@税率,@伟通收入不含税,@_2016年开票时间,@_2016年开票金额,@_2016年合同收款时间,@_2016年合同收款金额,@_2016年实际回款金额,@_2016年应收未收金额,@_2016年到期应收未收金额,@_2016年实际回款时间,@_2017年开票时间,@_2017年开票金额,@_2017年合同收款时间,@_2017年合同收款金额,@_2017年实际回款金额,@_2017年应收未收金额,@_2017年到期应收未收金额,@_2017年实际回款时间,@_2018年开票时间,@_2018年开票金额,@_2018年合同收款时间,@_2018年合同收款金额,@_2018年实际回款金额,@_2018年应收未收金额,@_2018年到期应收未收金额,@_2018年实际回款时间,@_2019年开票时间,@_2019年开票金额,@_2019年合同收款时间,@_2019年合同收款金额,@_2019年实际回款金额,@_2019年应收未收金额,@_2019年到期应收未收金额,@_2019年实际回款时间,@_2020年开票时间,@_2020年开票金额,@_2020年合同收款时间,@_2020年合同收款金额,@_2020年实际回款金额,@_2020年应收未收金额,@_2020年到期应收未收金额,@_2020年实际回款时间,@_2021年开票时间,@_2021年开票金额,@_2021年合同收款时间,@_2021年合同收款金额,@_2021年实际回款金额,@_2021年应收未收金额,@_2021年到期应收未收金额,@_2021年实际回款时间,@_2022年开票时间,@_2022年开票金额,@_2022年合同收款时间,@_2022年合同收款金额,@_2022年实际回款金额,@_2022年应收未收金额,@_2022年到期应收未收金额,@_2022年实际回款时间,@_2023年开票时间,@_2023年开票金额,@_2023年合同收款时间,@_2023年合同收款金额,@_2023年实际回款金额,@_2023年应收未收金额,@_2023年到期应收未收金额,@_2023年实际回款时间,@_2024年开票时间,@_2024年开票金额,@_2024年合同收款时间,@_2024年合同收款金额,@_2024年实际回款金额,@_2024年应收未收金额,@_2024年到期应收未收金额,@_2024年实际回款时间,@_2025年开票时间,@_2025年开票金额,@_2025年合同收款时间,@_2025年合同收款金额,@_2025年实际回款金额,@_2025年应收未收金额,@_2025年到期应收未收金额,@_2025年实际回款时间,@_2026年开票时间,@_2026年开票金额,@_2026年合同收款时间,@_2026年合同收款金额,@_2026年实际回款金额,@_2026年应收未收金额,@_2026年到期应收未收金额,@_2026年实际回款时间,@_2027年开票时间,@_2027年开票金额,@_2027年合同收款时间,@_2027年合同收款金额,@_2027年实际回款金额,@_2027年应收未收金额,@_2027年到期应收未收金额,@_2027年实际回款时间,@_2028年开票时间,@_2028年开票金额,@_2028年合同收款时间,@_2028年合同收款金额,@_2028年实际回款金额,@_2028年应收未收金额,@_2028年到期应收未收金额,@_2028年实际回款时间,@_2029年开票时间,@_2029年开票金额,@_2029年合同收款时间,@_2029年合同收款金额,@_2029年实际回款金额,@_2029年应收未收金额,@_2029年到期应收未收金额,@_2029年实际回款时间,@_2030年开票时间,@_2030年开票金额,@_2030年合同收款时间,@_2030年合同收款金额,@_2030年实际回款金额,@_2030年应收未收金额,@_2030年到期应收未收金额,@_2030年实际回款时间,@推迟收款时间,@实际竣工时间,@竣工与实际收款时间差异,@移动交付,@电信交付,@联通交付,@铁塔交付,@运营商合同签订日期,@运营商交付单与租赁合同时间差,@移动实际付款时间,@电信实际付款时间,@联通实际付款时间,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@回款期限", SqlDbType.VarChar,200),
					new SqlParameter("@租金金额", SqlDbType.Decimal,9),
					new SqlParameter("@基站销售款", SqlDbType.Decimal,9),
					new SqlParameter("@累计应收金额", SqlDbType.Decimal,9),
					new SqlParameter("@税率", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入不含税", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@推迟收款时间", SqlDbType.Decimal,9),
					new SqlParameter("@实际竣工时间", SqlDbType.DateTime),
					new SqlParameter("@竣工与实际收款时间差异", SqlDbType.Decimal,9),
					new SqlParameter("@移动交付", SqlDbType.DateTime),
					new SqlParameter("@电信交付", SqlDbType.DateTime),
					new SqlParameter("@联通交付", SqlDbType.DateTime),
					new SqlParameter("@铁塔交付", SqlDbType.DateTime),
					new SqlParameter("@运营商合同签订日期", SqlDbType.DateTime),
					new SqlParameter("@运营商交付单与租赁合同时间差", SqlDbType.Decimal,9),
					new SqlParameter("@移动实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@电信实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@联通实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.区域;
			parameters[2].Value = model.客户名称;
			parameters[3].Value = model.站点名称;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.回款期限;
			parameters[6].Value = model.租金金额;
			parameters[7].Value = model.基站销售款;
			parameters[8].Value = model.累计应收金额;
			parameters[9].Value = model.税率;
			parameters[10].Value = model.伟通收入不含税;
			parameters[11].Value = model._2016年开票时间;
			parameters[12].Value = model._2016年开票金额;
			parameters[13].Value = model._2016年合同收款时间;
			parameters[14].Value = model._2016年合同收款金额;
			parameters[15].Value = model._2016年实际回款金额;
			parameters[16].Value = model._2016年应收未收金额;
			parameters[17].Value = model._2016年到期应收未收金额;
			parameters[18].Value = model._2016年实际回款时间;
			parameters[19].Value = model._2017年开票时间;
			parameters[20].Value = model._2017年开票金额;
			parameters[21].Value = model._2017年合同收款时间;
			parameters[22].Value = model._2017年合同收款金额;
			parameters[23].Value = model._2017年实际回款金额;
			parameters[24].Value = model._2017年应收未收金额;
			parameters[25].Value = model._2017年到期应收未收金额;
			parameters[26].Value = model._2017年实际回款时间;
			parameters[27].Value = model._2018年开票时间;
			parameters[28].Value = model._2018年开票金额;
			parameters[29].Value = model._2018年合同收款时间;
			parameters[30].Value = model._2018年合同收款金额;
			parameters[31].Value = model._2018年实际回款金额;
			parameters[32].Value = model._2018年应收未收金额;
			parameters[33].Value = model._2018年到期应收未收金额;
			parameters[34].Value = model._2018年实际回款时间;
			parameters[35].Value = model._2019年开票时间;
			parameters[36].Value = model._2019年开票金额;
			parameters[37].Value = model._2019年合同收款时间;
			parameters[38].Value = model._2019年合同收款金额;
			parameters[39].Value = model._2019年实际回款金额;
			parameters[40].Value = model._2019年应收未收金额;
			parameters[41].Value = model._2019年到期应收未收金额;
			parameters[42].Value = model._2019年实际回款时间;
			parameters[43].Value = model._2020年开票时间;
			parameters[44].Value = model._2020年开票金额;
			parameters[45].Value = model._2020年合同收款时间;
			parameters[46].Value = model._2020年合同收款金额;
			parameters[47].Value = model._2020年实际回款金额;
			parameters[48].Value = model._2020年应收未收金额;
			parameters[49].Value = model._2020年到期应收未收金额;
			parameters[50].Value = model._2020年实际回款时间;
			parameters[51].Value = model._2021年开票时间;
			parameters[52].Value = model._2021年开票金额;
			parameters[53].Value = model._2021年合同收款时间;
			parameters[54].Value = model._2021年合同收款金额;
			parameters[55].Value = model._2021年实际回款金额;
			parameters[56].Value = model._2021年应收未收金额;
			parameters[57].Value = model._2021年到期应收未收金额;
			parameters[58].Value = model._2021年实际回款时间;
			parameters[59].Value = model._2022年开票时间;
			parameters[60].Value = model._2022年开票金额;
			parameters[61].Value = model._2022年合同收款时间;
			parameters[62].Value = model._2022年合同收款金额;
			parameters[63].Value = model._2022年实际回款金额;
			parameters[64].Value = model._2022年应收未收金额;
			parameters[65].Value = model._2022年到期应收未收金额;
			parameters[66].Value = model._2022年实际回款时间;
			parameters[67].Value = model._2023年开票时间;
			parameters[68].Value = model._2023年开票金额;
			parameters[69].Value = model._2023年合同收款时间;
			parameters[70].Value = model._2023年合同收款金额;
			parameters[71].Value = model._2023年实际回款金额;
			parameters[72].Value = model._2023年应收未收金额;
			parameters[73].Value = model._2023年到期应收未收金额;
			parameters[74].Value = model._2023年实际回款时间;
			parameters[75].Value = model._2024年开票时间;
			parameters[76].Value = model._2024年开票金额;
			parameters[77].Value = model._2024年合同收款时间;
			parameters[78].Value = model._2024年合同收款金额;
			parameters[79].Value = model._2024年实际回款金额;
			parameters[80].Value = model._2024年应收未收金额;
			parameters[81].Value = model._2024年到期应收未收金额;
			parameters[82].Value = model._2024年实际回款时间;
			parameters[83].Value = model._2025年开票时间;
			parameters[84].Value = model._2025年开票金额;
			parameters[85].Value = model._2025年合同收款时间;
			parameters[86].Value = model._2025年合同收款金额;
			parameters[87].Value = model._2025年实际回款金额;
			parameters[88].Value = model._2025年应收未收金额;
			parameters[89].Value = model._2025年到期应收未收金额;
			parameters[90].Value = model._2025年实际回款时间;
			parameters[91].Value = model._2026年开票时间;
			parameters[92].Value = model._2026年开票金额;
			parameters[93].Value = model._2026年合同收款时间;
			parameters[94].Value = model._2026年合同收款金额;
			parameters[95].Value = model._2026年实际回款金额;
			parameters[96].Value = model._2026年应收未收金额;
			parameters[97].Value = model._2026年到期应收未收金额;
			parameters[98].Value = model._2026年实际回款时间;
			parameters[99].Value = model._2027年开票时间;
			parameters[100].Value = model._2027年开票金额;
			parameters[101].Value = model._2027年合同收款时间;
			parameters[102].Value = model._2027年合同收款金额;
			parameters[103].Value = model._2027年实际回款金额;
			parameters[104].Value = model._2027年应收未收金额;
			parameters[105].Value = model._2027年到期应收未收金额;
			parameters[106].Value = model._2027年实际回款时间;
			parameters[107].Value = model._2028年开票时间;
			parameters[108].Value = model._2028年开票金额;
			parameters[109].Value = model._2028年合同收款时间;
			parameters[110].Value = model._2028年合同收款金额;
			parameters[111].Value = model._2028年实际回款金额;
			parameters[112].Value = model._2028年应收未收金额;
			parameters[113].Value = model._2028年到期应收未收金额;
			parameters[114].Value = model._2028年实际回款时间;
			parameters[115].Value = model._2029年开票时间;
			parameters[116].Value = model._2029年开票金额;
			parameters[117].Value = model._2029年合同收款时间;
			parameters[118].Value = model._2029年合同收款金额;
			parameters[119].Value = model._2029年实际回款金额;
			parameters[120].Value = model._2029年应收未收金额;
			parameters[121].Value = model._2029年到期应收未收金额;
			parameters[122].Value = model._2029年实际回款时间;
			parameters[123].Value = model._2030年开票时间;
			parameters[124].Value = model._2030年开票金额;
			parameters[125].Value = model._2030年合同收款时间;
			parameters[126].Value = model._2030年合同收款金额;
			parameters[127].Value = model._2030年实际回款金额;
			parameters[128].Value = model._2030年应收未收金额;
			parameters[129].Value = model._2030年到期应收未收金额;
			parameters[130].Value = model._2030年实际回款时间;
			parameters[131].Value = model.推迟收款时间;
			parameters[132].Value = model.实际竣工时间;
			parameters[133].Value = model.竣工与实际收款时间差异;
			parameters[134].Value = model.移动交付;
			parameters[135].Value = model.电信交付;
			parameters[136].Value = model.联通交付;
			parameters[137].Value = model.铁塔交付;
			parameters[138].Value = model.运营商合同签订日期;
			parameters[139].Value = model.运营商交付单与租赁合同时间差;
			parameters[140].Value = model.移动实际付款时间;
			parameters[141].Value = model.电信实际付款时间;
			parameters[142].Value = model.联通实际付款时间;
			parameters[143].Value = model.备注;
			parameters[144].Value = model.IsDeleted;
			parameters[145].Value = model.CreateBy;
			parameters[146].Value = model.CreateTime;
			parameters[147].Value = model.UpdateBy;
			parameters[148].Value = model.UpdateTime;

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
		public bool Update(WTCJ.Model.Health_Xs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Health_Xs set ");
			strSql.Append("区域=@区域,");
			strSql.Append("客户名称=@客户名称,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("回款期限=@回款期限,");
			strSql.Append("租金金额=@租金金额,");
			strSql.Append("基站销售款=@基站销售款,");
			strSql.Append("累计应收金额=@累计应收金额,");
			strSql.Append("税率=@税率,");
			strSql.Append("伟通收入不含税=@伟通收入不含税,");
			strSql.Append("_2016年开票时间=@_2016年开票时间,");
			strSql.Append("_2016年开票金额=@_2016年开票金额,");
			strSql.Append("_2016年合同收款时间=@_2016年合同收款时间,");
			strSql.Append("_2016年合同收款金额=@_2016年合同收款金额,");
			strSql.Append("_2016年实际回款金额=@_2016年实际回款金额,");
			strSql.Append("_2016年应收未收金额=@_2016年应收未收金额,");
			strSql.Append("_2016年到期应收未收金额=@_2016年到期应收未收金额,");
			strSql.Append("_2016年实际回款时间=@_2016年实际回款时间,");
			strSql.Append("_2017年开票时间=@_2017年开票时间,");
			strSql.Append("_2017年开票金额=@_2017年开票金额,");
			strSql.Append("_2017年合同收款时间=@_2017年合同收款时间,");
			strSql.Append("_2017年合同收款金额=@_2017年合同收款金额,");
			strSql.Append("_2017年实际回款金额=@_2017年实际回款金额,");
			strSql.Append("_2017年应收未收金额=@_2017年应收未收金额,");
			strSql.Append("_2017年到期应收未收金额=@_2017年到期应收未收金额,");
			strSql.Append("_2017年实际回款时间=@_2017年实际回款时间,");
			strSql.Append("_2018年开票时间=@_2018年开票时间,");
			strSql.Append("_2018年开票金额=@_2018年开票金额,");
			strSql.Append("_2018年合同收款时间=@_2018年合同收款时间,");
			strSql.Append("_2018年合同收款金额=@_2018年合同收款金额,");
			strSql.Append("_2018年实际回款金额=@_2018年实际回款金额,");
			strSql.Append("_2018年应收未收金额=@_2018年应收未收金额,");
			strSql.Append("_2018年到期应收未收金额=@_2018年到期应收未收金额,");
			strSql.Append("_2018年实际回款时间=@_2018年实际回款时间,");
			strSql.Append("_2019年开票时间=@_2019年开票时间,");
			strSql.Append("_2019年开票金额=@_2019年开票金额,");
			strSql.Append("_2019年合同收款时间=@_2019年合同收款时间,");
			strSql.Append("_2019年合同收款金额=@_2019年合同收款金额,");
			strSql.Append("_2019年实际回款金额=@_2019年实际回款金额,");
			strSql.Append("_2019年应收未收金额=@_2019年应收未收金额,");
			strSql.Append("_2019年到期应收未收金额=@_2019年到期应收未收金额,");
			strSql.Append("_2019年实际回款时间=@_2019年实际回款时间,");
			strSql.Append("_2020年开票时间=@_2020年开票时间,");
			strSql.Append("_2020年开票金额=@_2020年开票金额,");
			strSql.Append("_2020年合同收款时间=@_2020年合同收款时间,");
			strSql.Append("_2020年合同收款金额=@_2020年合同收款金额,");
			strSql.Append("_2020年实际回款金额=@_2020年实际回款金额,");
			strSql.Append("_2020年应收未收金额=@_2020年应收未收金额,");
			strSql.Append("_2020年到期应收未收金额=@_2020年到期应收未收金额,");
			strSql.Append("_2020年实际回款时间=@_2020年实际回款时间,");
			strSql.Append("_2021年开票时间=@_2021年开票时间,");
			strSql.Append("_2021年开票金额=@_2021年开票金额,");
			strSql.Append("_2021年合同收款时间=@_2021年合同收款时间,");
			strSql.Append("_2021年合同收款金额=@_2021年合同收款金额,");
			strSql.Append("_2021年实际回款金额=@_2021年实际回款金额,");
			strSql.Append("_2021年应收未收金额=@_2021年应收未收金额,");
			strSql.Append("_2021年到期应收未收金额=@_2021年到期应收未收金额,");
			strSql.Append("_2021年实际回款时间=@_2021年实际回款时间,");
			strSql.Append("_2022年开票时间=@_2022年开票时间,");
			strSql.Append("_2022年开票金额=@_2022年开票金额,");
			strSql.Append("_2022年合同收款时间=@_2022年合同收款时间,");
			strSql.Append("_2022年合同收款金额=@_2022年合同收款金额,");
			strSql.Append("_2022年实际回款金额=@_2022年实际回款金额,");
			strSql.Append("_2022年应收未收金额=@_2022年应收未收金额,");
			strSql.Append("_2022年到期应收未收金额=@_2022年到期应收未收金额,");
			strSql.Append("_2022年实际回款时间=@_2022年实际回款时间,");
			strSql.Append("_2023年开票时间=@_2023年开票时间,");
			strSql.Append("_2023年开票金额=@_2023年开票金额,");
			strSql.Append("_2023年合同收款时间=@_2023年合同收款时间,");
			strSql.Append("_2023年合同收款金额=@_2023年合同收款金额,");
			strSql.Append("_2023年实际回款金额=@_2023年实际回款金额,");
			strSql.Append("_2023年应收未收金额=@_2023年应收未收金额,");
			strSql.Append("_2023年到期应收未收金额=@_2023年到期应收未收金额,");
			strSql.Append("_2023年实际回款时间=@_2023年实际回款时间,");
			strSql.Append("_2024年开票时间=@_2024年开票时间,");
			strSql.Append("_2024年开票金额=@_2024年开票金额,");
			strSql.Append("_2024年合同收款时间=@_2024年合同收款时间,");
			strSql.Append("_2024年合同收款金额=@_2024年合同收款金额,");
			strSql.Append("_2024年实际回款金额=@_2024年实际回款金额,");
			strSql.Append("_2024年应收未收金额=@_2024年应收未收金额,");
			strSql.Append("_2024年到期应收未收金额=@_2024年到期应收未收金额,");
			strSql.Append("_2024年实际回款时间=@_2024年实际回款时间,");
			strSql.Append("_2025年开票时间=@_2025年开票时间,");
			strSql.Append("_2025年开票金额=@_2025年开票金额,");
			strSql.Append("_2025年合同收款时间=@_2025年合同收款时间,");
			strSql.Append("_2025年合同收款金额=@_2025年合同收款金额,");
			strSql.Append("_2025年实际回款金额=@_2025年实际回款金额,");
			strSql.Append("_2025年应收未收金额=@_2025年应收未收金额,");
			strSql.Append("_2025年到期应收未收金额=@_2025年到期应收未收金额,");
			strSql.Append("_2025年实际回款时间=@_2025年实际回款时间,");
			strSql.Append("_2026年开票时间=@_2026年开票时间,");
			strSql.Append("_2026年开票金额=@_2026年开票金额,");
			strSql.Append("_2026年合同收款时间=@_2026年合同收款时间,");
			strSql.Append("_2026年合同收款金额=@_2026年合同收款金额,");
			strSql.Append("_2026年实际回款金额=@_2026年实际回款金额,");
			strSql.Append("_2026年应收未收金额=@_2026年应收未收金额,");
			strSql.Append("_2026年到期应收未收金额=@_2026年到期应收未收金额,");
			strSql.Append("_2026年实际回款时间=@_2026年实际回款时间,");
			strSql.Append("_2027年开票时间=@_2027年开票时间,");
			strSql.Append("_2027年开票金额=@_2027年开票金额,");
			strSql.Append("_2027年合同收款时间=@_2027年合同收款时间,");
			strSql.Append("_2027年合同收款金额=@_2027年合同收款金额,");
			strSql.Append("_2027年实际回款金额=@_2027年实际回款金额,");
			strSql.Append("_2027年应收未收金额=@_2027年应收未收金额,");
			strSql.Append("_2027年到期应收未收金额=@_2027年到期应收未收金额,");
			strSql.Append("_2027年实际回款时间=@_2027年实际回款时间,");
			strSql.Append("_2028年开票时间=@_2028年开票时间,");
			strSql.Append("_2028年开票金额=@_2028年开票金额,");
			strSql.Append("_2028年合同收款时间=@_2028年合同收款时间,");
			strSql.Append("_2028年合同收款金额=@_2028年合同收款金额,");
			strSql.Append("_2028年实际回款金额=@_2028年实际回款金额,");
			strSql.Append("_2028年应收未收金额=@_2028年应收未收金额,");
			strSql.Append("_2028年到期应收未收金额=@_2028年到期应收未收金额,");
			strSql.Append("_2028年实际回款时间=@_2028年实际回款时间,");
			strSql.Append("_2029年开票时间=@_2029年开票时间,");
			strSql.Append("_2029年开票金额=@_2029年开票金额,");
			strSql.Append("_2029年合同收款时间=@_2029年合同收款时间,");
			strSql.Append("_2029年合同收款金额=@_2029年合同收款金额,");
			strSql.Append("_2029年实际回款金额=@_2029年实际回款金额,");
			strSql.Append("_2029年应收未收金额=@_2029年应收未收金额,");
			strSql.Append("_2029年到期应收未收金额=@_2029年到期应收未收金额,");
			strSql.Append("_2029年实际回款时间=@_2029年实际回款时间,");
			strSql.Append("_2030年开票时间=@_2030年开票时间,");
			strSql.Append("_2030年开票金额=@_2030年开票金额,");
			strSql.Append("_2030年合同收款时间=@_2030年合同收款时间,");
			strSql.Append("_2030年合同收款金额=@_2030年合同收款金额,");
			strSql.Append("_2030年实际回款金额=@_2030年实际回款金额,");
			strSql.Append("_2030年应收未收金额=@_2030年应收未收金额,");
			strSql.Append("_2030年到期应收未收金额=@_2030年到期应收未收金额,");
			strSql.Append("_2030年实际回款时间=@_2030年实际回款时间,");
			strSql.Append("推迟收款时间=@推迟收款时间,");
			strSql.Append("实际竣工时间=@实际竣工时间,");
			strSql.Append("竣工与实际收款时间差异=@竣工与实际收款时间差异,");
			strSql.Append("移动交付=@移动交付,");
			strSql.Append("电信交付=@电信交付,");
			strSql.Append("联通交付=@联通交付,");
			strSql.Append("铁塔交付=@铁塔交付,");
			strSql.Append("运营商合同签订日期=@运营商合同签订日期,");
			strSql.Append("运营商交付单与租赁合同时间差=@运营商交付单与租赁合同时间差,");
			strSql.Append("移动实际付款时间=@移动实际付款时间,");
			strSql.Append("电信实际付款时间=@电信实际付款时间,");
			strSql.Append("联通实际付款时间=@联通实际付款时间,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@回款期限", SqlDbType.VarChar,200),
					new SqlParameter("@租金金额", SqlDbType.Decimal,9),
					new SqlParameter("@基站销售款", SqlDbType.Decimal,9),
					new SqlParameter("@累计应收金额", SqlDbType.Decimal,9),
					new SqlParameter("@税率", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入不含税", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@推迟收款时间", SqlDbType.Decimal,9),
					new SqlParameter("@实际竣工时间", SqlDbType.DateTime),
					new SqlParameter("@竣工与实际收款时间差异", SqlDbType.Decimal,9),
					new SqlParameter("@移动交付", SqlDbType.DateTime),
					new SqlParameter("@电信交付", SqlDbType.DateTime),
					new SqlParameter("@联通交付", SqlDbType.DateTime),
					new SqlParameter("@铁塔交付", SqlDbType.DateTime),
					new SqlParameter("@运营商合同签订日期", SqlDbType.DateTime),
					new SqlParameter("@运营商交付单与租赁合同时间差", SqlDbType.Decimal,9),
					new SqlParameter("@移动实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@电信实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@联通实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.区域;
			parameters[1].Value = model.客户名称;
			parameters[2].Value = model.站点名称;
			parameters[3].Value = model.站点编码;
			parameters[4].Value = model.回款期限;
			parameters[5].Value = model.租金金额;
			parameters[6].Value = model.基站销售款;
			parameters[7].Value = model.累计应收金额;
			parameters[8].Value = model.税率;
			parameters[9].Value = model.伟通收入不含税;
			parameters[10].Value = model._2016年开票时间;
			parameters[11].Value = model._2016年开票金额;
			parameters[12].Value = model._2016年合同收款时间;
			parameters[13].Value = model._2016年合同收款金额;
			parameters[14].Value = model._2016年实际回款金额;
			parameters[15].Value = model._2016年应收未收金额;
			parameters[16].Value = model._2016年到期应收未收金额;
			parameters[17].Value = model._2016年实际回款时间;
			parameters[18].Value = model._2017年开票时间;
			parameters[19].Value = model._2017年开票金额;
			parameters[20].Value = model._2017年合同收款时间;
			parameters[21].Value = model._2017年合同收款金额;
			parameters[22].Value = model._2017年实际回款金额;
			parameters[23].Value = model._2017年应收未收金额;
			parameters[24].Value = model._2017年到期应收未收金额;
			parameters[25].Value = model._2017年实际回款时间;
			parameters[26].Value = model._2018年开票时间;
			parameters[27].Value = model._2018年开票金额;
			parameters[28].Value = model._2018年合同收款时间;
			parameters[29].Value = model._2018年合同收款金额;
			parameters[30].Value = model._2018年实际回款金额;
			parameters[31].Value = model._2018年应收未收金额;
			parameters[32].Value = model._2018年到期应收未收金额;
			parameters[33].Value = model._2018年实际回款时间;
			parameters[34].Value = model._2019年开票时间;
			parameters[35].Value = model._2019年开票金额;
			parameters[36].Value = model._2019年合同收款时间;
			parameters[37].Value = model._2019年合同收款金额;
			parameters[38].Value = model._2019年实际回款金额;
			parameters[39].Value = model._2019年应收未收金额;
			parameters[40].Value = model._2019年到期应收未收金额;
			parameters[41].Value = model._2019年实际回款时间;
			parameters[42].Value = model._2020年开票时间;
			parameters[43].Value = model._2020年开票金额;
			parameters[44].Value = model._2020年合同收款时间;
			parameters[45].Value = model._2020年合同收款金额;
			parameters[46].Value = model._2020年实际回款金额;
			parameters[47].Value = model._2020年应收未收金额;
			parameters[48].Value = model._2020年到期应收未收金额;
			parameters[49].Value = model._2020年实际回款时间;
			parameters[50].Value = model._2021年开票时间;
			parameters[51].Value = model._2021年开票金额;
			parameters[52].Value = model._2021年合同收款时间;
			parameters[53].Value = model._2021年合同收款金额;
			parameters[54].Value = model._2021年实际回款金额;
			parameters[55].Value = model._2021年应收未收金额;
			parameters[56].Value = model._2021年到期应收未收金额;
			parameters[57].Value = model._2021年实际回款时间;
			parameters[58].Value = model._2022年开票时间;
			parameters[59].Value = model._2022年开票金额;
			parameters[60].Value = model._2022年合同收款时间;
			parameters[61].Value = model._2022年合同收款金额;
			parameters[62].Value = model._2022年实际回款金额;
			parameters[63].Value = model._2022年应收未收金额;
			parameters[64].Value = model._2022年到期应收未收金额;
			parameters[65].Value = model._2022年实际回款时间;
			parameters[66].Value = model._2023年开票时间;
			parameters[67].Value = model._2023年开票金额;
			parameters[68].Value = model._2023年合同收款时间;
			parameters[69].Value = model._2023年合同收款金额;
			parameters[70].Value = model._2023年实际回款金额;
			parameters[71].Value = model._2023年应收未收金额;
			parameters[72].Value = model._2023年到期应收未收金额;
			parameters[73].Value = model._2023年实际回款时间;
			parameters[74].Value = model._2024年开票时间;
			parameters[75].Value = model._2024年开票金额;
			parameters[76].Value = model._2024年合同收款时间;
			parameters[77].Value = model._2024年合同收款金额;
			parameters[78].Value = model._2024年实际回款金额;
			parameters[79].Value = model._2024年应收未收金额;
			parameters[80].Value = model._2024年到期应收未收金额;
			parameters[81].Value = model._2024年实际回款时间;
			parameters[82].Value = model._2025年开票时间;
			parameters[83].Value = model._2025年开票金额;
			parameters[84].Value = model._2025年合同收款时间;
			parameters[85].Value = model._2025年合同收款金额;
			parameters[86].Value = model._2025年实际回款金额;
			parameters[87].Value = model._2025年应收未收金额;
			parameters[88].Value = model._2025年到期应收未收金额;
			parameters[89].Value = model._2025年实际回款时间;
			parameters[90].Value = model._2026年开票时间;
			parameters[91].Value = model._2026年开票金额;
			parameters[92].Value = model._2026年合同收款时间;
			parameters[93].Value = model._2026年合同收款金额;
			parameters[94].Value = model._2026年实际回款金额;
			parameters[95].Value = model._2026年应收未收金额;
			parameters[96].Value = model._2026年到期应收未收金额;
			parameters[97].Value = model._2026年实际回款时间;
			parameters[98].Value = model._2027年开票时间;
			parameters[99].Value = model._2027年开票金额;
			parameters[100].Value = model._2027年合同收款时间;
			parameters[101].Value = model._2027年合同收款金额;
			parameters[102].Value = model._2027年实际回款金额;
			parameters[103].Value = model._2027年应收未收金额;
			parameters[104].Value = model._2027年到期应收未收金额;
			parameters[105].Value = model._2027年实际回款时间;
			parameters[106].Value = model._2028年开票时间;
			parameters[107].Value = model._2028年开票金额;
			parameters[108].Value = model._2028年合同收款时间;
			parameters[109].Value = model._2028年合同收款金额;
			parameters[110].Value = model._2028年实际回款金额;
			parameters[111].Value = model._2028年应收未收金额;
			parameters[112].Value = model._2028年到期应收未收金额;
			parameters[113].Value = model._2028年实际回款时间;
			parameters[114].Value = model._2029年开票时间;
			parameters[115].Value = model._2029年开票金额;
			parameters[116].Value = model._2029年合同收款时间;
			parameters[117].Value = model._2029年合同收款金额;
			parameters[118].Value = model._2029年实际回款金额;
			parameters[119].Value = model._2029年应收未收金额;
			parameters[120].Value = model._2029年到期应收未收金额;
			parameters[121].Value = model._2029年实际回款时间;
			parameters[122].Value = model._2030年开票时间;
			parameters[123].Value = model._2030年开票金额;
			parameters[124].Value = model._2030年合同收款时间;
			parameters[125].Value = model._2030年合同收款金额;
			parameters[126].Value = model._2030年实际回款金额;
			parameters[127].Value = model._2030年应收未收金额;
			parameters[128].Value = model._2030年到期应收未收金额;
			parameters[129].Value = model._2030年实际回款时间;
			parameters[130].Value = model.推迟收款时间;
			parameters[131].Value = model.实际竣工时间;
			parameters[132].Value = model.竣工与实际收款时间差异;
			parameters[133].Value = model.移动交付;
			parameters[134].Value = model.电信交付;
			parameters[135].Value = model.联通交付;
			parameters[136].Value = model.铁塔交付;
			parameters[137].Value = model.运营商合同签订日期;
			parameters[138].Value = model.运营商交付单与租赁合同时间差;
			parameters[139].Value = model.移动实际付款时间;
			parameters[140].Value = model.电信实际付款时间;
			parameters[141].Value = model.联通实际付款时间;
			parameters[142].Value = model.备注;
			parameters[143].Value = model.IsDeleted;
			parameters[144].Value = model.CreateBy;
			parameters[145].Value = model.CreateTime;
			parameters[146].Value = model.UpdateBy;
			parameters[147].Value = model.UpdateTime;
			parameters[148].Value = model.id;

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
		public bool Update(SqlTransaction tran,WTCJ.Model.Health_Xs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Health_Xs set ");
			strSql.Append("区域=@区域,");
			strSql.Append("客户名称=@客户名称,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("回款期限=@回款期限,");
			strSql.Append("租金金额=@租金金额,");
			strSql.Append("基站销售款=@基站销售款,");
			strSql.Append("累计应收金额=@累计应收金额,");
			strSql.Append("税率=@税率,");
			strSql.Append("伟通收入不含税=@伟通收入不含税,");
			strSql.Append("_2016年开票时间=@_2016年开票时间,");
			strSql.Append("_2016年开票金额=@_2016年开票金额,");
			strSql.Append("_2016年合同收款时间=@_2016年合同收款时间,");
			strSql.Append("_2016年合同收款金额=@_2016年合同收款金额,");
			strSql.Append("_2016年实际回款金额=@_2016年实际回款金额,");
			strSql.Append("_2016年应收未收金额=@_2016年应收未收金额,");
			strSql.Append("_2016年到期应收未收金额=@_2016年到期应收未收金额,");
			strSql.Append("_2016年实际回款时间=@_2016年实际回款时间,");
			strSql.Append("_2017年开票时间=@_2017年开票时间,");
			strSql.Append("_2017年开票金额=@_2017年开票金额,");
			strSql.Append("_2017年合同收款时间=@_2017年合同收款时间,");
			strSql.Append("_2017年合同收款金额=@_2017年合同收款金额,");
			strSql.Append("_2017年实际回款金额=@_2017年实际回款金额,");
			strSql.Append("_2017年应收未收金额=@_2017年应收未收金额,");
			strSql.Append("_2017年到期应收未收金额=@_2017年到期应收未收金额,");
			strSql.Append("_2017年实际回款时间=@_2017年实际回款时间,");
			strSql.Append("_2018年开票时间=@_2018年开票时间,");
			strSql.Append("_2018年开票金额=@_2018年开票金额,");
			strSql.Append("_2018年合同收款时间=@_2018年合同收款时间,");
			strSql.Append("_2018年合同收款金额=@_2018年合同收款金额,");
			strSql.Append("_2018年实际回款金额=@_2018年实际回款金额,");
			strSql.Append("_2018年应收未收金额=@_2018年应收未收金额,");
			strSql.Append("_2018年到期应收未收金额=@_2018年到期应收未收金额,");
			strSql.Append("_2018年实际回款时间=@_2018年实际回款时间,");
			strSql.Append("_2019年开票时间=@_2019年开票时间,");
			strSql.Append("_2019年开票金额=@_2019年开票金额,");
			strSql.Append("_2019年合同收款时间=@_2019年合同收款时间,");
			strSql.Append("_2019年合同收款金额=@_2019年合同收款金额,");
			strSql.Append("_2019年实际回款金额=@_2019年实际回款金额,");
			strSql.Append("_2019年应收未收金额=@_2019年应收未收金额,");
			strSql.Append("_2019年到期应收未收金额=@_2019年到期应收未收金额,");
			strSql.Append("_2019年实际回款时间=@_2019年实际回款时间,");
			strSql.Append("_2020年开票时间=@_2020年开票时间,");
			strSql.Append("_2020年开票金额=@_2020年开票金额,");
			strSql.Append("_2020年合同收款时间=@_2020年合同收款时间,");
			strSql.Append("_2020年合同收款金额=@_2020年合同收款金额,");
			strSql.Append("_2020年实际回款金额=@_2020年实际回款金额,");
			strSql.Append("_2020年应收未收金额=@_2020年应收未收金额,");
			strSql.Append("_2020年到期应收未收金额=@_2020年到期应收未收金额,");
			strSql.Append("_2020年实际回款时间=@_2020年实际回款时间,");
			strSql.Append("_2021年开票时间=@_2021年开票时间,");
			strSql.Append("_2021年开票金额=@_2021年开票金额,");
			strSql.Append("_2021年合同收款时间=@_2021年合同收款时间,");
			strSql.Append("_2021年合同收款金额=@_2021年合同收款金额,");
			strSql.Append("_2021年实际回款金额=@_2021年实际回款金额,");
			strSql.Append("_2021年应收未收金额=@_2021年应收未收金额,");
			strSql.Append("_2021年到期应收未收金额=@_2021年到期应收未收金额,");
			strSql.Append("_2021年实际回款时间=@_2021年实际回款时间,");
			strSql.Append("_2022年开票时间=@_2022年开票时间,");
			strSql.Append("_2022年开票金额=@_2022年开票金额,");
			strSql.Append("_2022年合同收款时间=@_2022年合同收款时间,");
			strSql.Append("_2022年合同收款金额=@_2022年合同收款金额,");
			strSql.Append("_2022年实际回款金额=@_2022年实际回款金额,");
			strSql.Append("_2022年应收未收金额=@_2022年应收未收金额,");
			strSql.Append("_2022年到期应收未收金额=@_2022年到期应收未收金额,");
			strSql.Append("_2022年实际回款时间=@_2022年实际回款时间,");
			strSql.Append("_2023年开票时间=@_2023年开票时间,");
			strSql.Append("_2023年开票金额=@_2023年开票金额,");
			strSql.Append("_2023年合同收款时间=@_2023年合同收款时间,");
			strSql.Append("_2023年合同收款金额=@_2023年合同收款金额,");
			strSql.Append("_2023年实际回款金额=@_2023年实际回款金额,");
			strSql.Append("_2023年应收未收金额=@_2023年应收未收金额,");
			strSql.Append("_2023年到期应收未收金额=@_2023年到期应收未收金额,");
			strSql.Append("_2023年实际回款时间=@_2023年实际回款时间,");
			strSql.Append("_2024年开票时间=@_2024年开票时间,");
			strSql.Append("_2024年开票金额=@_2024年开票金额,");
			strSql.Append("_2024年合同收款时间=@_2024年合同收款时间,");
			strSql.Append("_2024年合同收款金额=@_2024年合同收款金额,");
			strSql.Append("_2024年实际回款金额=@_2024年实际回款金额,");
			strSql.Append("_2024年应收未收金额=@_2024年应收未收金额,");
			strSql.Append("_2024年到期应收未收金额=@_2024年到期应收未收金额,");
			strSql.Append("_2024年实际回款时间=@_2024年实际回款时间,");
			strSql.Append("_2025年开票时间=@_2025年开票时间,");
			strSql.Append("_2025年开票金额=@_2025年开票金额,");
			strSql.Append("_2025年合同收款时间=@_2025年合同收款时间,");
			strSql.Append("_2025年合同收款金额=@_2025年合同收款金额,");
			strSql.Append("_2025年实际回款金额=@_2025年实际回款金额,");
			strSql.Append("_2025年应收未收金额=@_2025年应收未收金额,");
			strSql.Append("_2025年到期应收未收金额=@_2025年到期应收未收金额,");
			strSql.Append("_2025年实际回款时间=@_2025年实际回款时间,");
			strSql.Append("_2026年开票时间=@_2026年开票时间,");
			strSql.Append("_2026年开票金额=@_2026年开票金额,");
			strSql.Append("_2026年合同收款时间=@_2026年合同收款时间,");
			strSql.Append("_2026年合同收款金额=@_2026年合同收款金额,");
			strSql.Append("_2026年实际回款金额=@_2026年实际回款金额,");
			strSql.Append("_2026年应收未收金额=@_2026年应收未收金额,");
			strSql.Append("_2026年到期应收未收金额=@_2026年到期应收未收金额,");
			strSql.Append("_2026年实际回款时间=@_2026年实际回款时间,");
			strSql.Append("_2027年开票时间=@_2027年开票时间,");
			strSql.Append("_2027年开票金额=@_2027年开票金额,");
			strSql.Append("_2027年合同收款时间=@_2027年合同收款时间,");
			strSql.Append("_2027年合同收款金额=@_2027年合同收款金额,");
			strSql.Append("_2027年实际回款金额=@_2027年实际回款金额,");
			strSql.Append("_2027年应收未收金额=@_2027年应收未收金额,");
			strSql.Append("_2027年到期应收未收金额=@_2027年到期应收未收金额,");
			strSql.Append("_2027年实际回款时间=@_2027年实际回款时间,");
			strSql.Append("_2028年开票时间=@_2028年开票时间,");
			strSql.Append("_2028年开票金额=@_2028年开票金额,");
			strSql.Append("_2028年合同收款时间=@_2028年合同收款时间,");
			strSql.Append("_2028年合同收款金额=@_2028年合同收款金额,");
			strSql.Append("_2028年实际回款金额=@_2028年实际回款金额,");
			strSql.Append("_2028年应收未收金额=@_2028年应收未收金额,");
			strSql.Append("_2028年到期应收未收金额=@_2028年到期应收未收金额,");
			strSql.Append("_2028年实际回款时间=@_2028年实际回款时间,");
			strSql.Append("_2029年开票时间=@_2029年开票时间,");
			strSql.Append("_2029年开票金额=@_2029年开票金额,");
			strSql.Append("_2029年合同收款时间=@_2029年合同收款时间,");
			strSql.Append("_2029年合同收款金额=@_2029年合同收款金额,");
			strSql.Append("_2029年实际回款金额=@_2029年实际回款金额,");
			strSql.Append("_2029年应收未收金额=@_2029年应收未收金额,");
			strSql.Append("_2029年到期应收未收金额=@_2029年到期应收未收金额,");
			strSql.Append("_2029年实际回款时间=@_2029年实际回款时间,");
			strSql.Append("_2030年开票时间=@_2030年开票时间,");
			strSql.Append("_2030年开票金额=@_2030年开票金额,");
			strSql.Append("_2030年合同收款时间=@_2030年合同收款时间,");
			strSql.Append("_2030年合同收款金额=@_2030年合同收款金额,");
			strSql.Append("_2030年实际回款金额=@_2030年实际回款金额,");
			strSql.Append("_2030年应收未收金额=@_2030年应收未收金额,");
			strSql.Append("_2030年到期应收未收金额=@_2030年到期应收未收金额,");
			strSql.Append("_2030年实际回款时间=@_2030年实际回款时间,");
			strSql.Append("推迟收款时间=@推迟收款时间,");
			strSql.Append("实际竣工时间=@实际竣工时间,");
			strSql.Append("竣工与实际收款时间差异=@竣工与实际收款时间差异,");
			strSql.Append("移动交付=@移动交付,");
			strSql.Append("电信交付=@电信交付,");
			strSql.Append("联通交付=@联通交付,");
			strSql.Append("铁塔交付=@铁塔交付,");
			strSql.Append("运营商合同签订日期=@运营商合同签订日期,");
			strSql.Append("运营商交付单与租赁合同时间差=@运营商交付单与租赁合同时间差,");
			strSql.Append("移动实际付款时间=@移动实际付款时间,");
			strSql.Append("电信实际付款时间=@电信实际付款时间,");
			strSql.Append("联通实际付款时间=@联通实际付款时间,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@回款期限", SqlDbType.VarChar,200),
					new SqlParameter("@租金金额", SqlDbType.Decimal,9),
					new SqlParameter("@基站销售款", SqlDbType.Decimal,9),
					new SqlParameter("@累计应收金额", SqlDbType.Decimal,9),
					new SqlParameter("@税率", SqlDbType.Decimal,9),
					new SqlParameter("@伟通收入不含税", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2016年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2016年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2017年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2017年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2018年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2018年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2019年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2019年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2020年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2020年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2021年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2021年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2022年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2022年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2023年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2023年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2024年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2024年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2025年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2025年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2026年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2026年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2027年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2027年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2028年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2028年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2029年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2029年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年合同收款时间", SqlDbType.DateTime),
					new SqlParameter("@_2030年合同收款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年到期应收未收金额", SqlDbType.Decimal,9),
					new SqlParameter("@_2030年实际回款时间", SqlDbType.DateTime),
					new SqlParameter("@推迟收款时间", SqlDbType.Decimal,9),
					new SqlParameter("@实际竣工时间", SqlDbType.DateTime),
					new SqlParameter("@竣工与实际收款时间差异", SqlDbType.Decimal,9),
					new SqlParameter("@移动交付", SqlDbType.DateTime),
					new SqlParameter("@电信交付", SqlDbType.DateTime),
					new SqlParameter("@联通交付", SqlDbType.DateTime),
					new SqlParameter("@铁塔交付", SqlDbType.DateTime),
					new SqlParameter("@运营商合同签订日期", SqlDbType.DateTime),
					new SqlParameter("@运营商交付单与租赁合同时间差", SqlDbType.Decimal,9),
					new SqlParameter("@移动实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@电信实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@联通实际付款时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.区域;
			parameters[1].Value = model.客户名称;
			parameters[2].Value = model.站点名称;
			parameters[3].Value = model.站点编码;
			parameters[4].Value = model.回款期限;
			parameters[5].Value = model.租金金额;
			parameters[6].Value = model.基站销售款;
			parameters[7].Value = model.累计应收金额;
			parameters[8].Value = model.税率;
			parameters[9].Value = model.伟通收入不含税;
			parameters[10].Value = model._2016年开票时间;
			parameters[11].Value = model._2016年开票金额;
			parameters[12].Value = model._2016年合同收款时间;
			parameters[13].Value = model._2016年合同收款金额;
			parameters[14].Value = model._2016年实际回款金额;
			parameters[15].Value = model._2016年应收未收金额;
			parameters[16].Value = model._2016年到期应收未收金额;
			parameters[17].Value = model._2016年实际回款时间;
			parameters[18].Value = model._2017年开票时间;
			parameters[19].Value = model._2017年开票金额;
			parameters[20].Value = model._2017年合同收款时间;
			parameters[21].Value = model._2017年合同收款金额;
			parameters[22].Value = model._2017年实际回款金额;
			parameters[23].Value = model._2017年应收未收金额;
			parameters[24].Value = model._2017年到期应收未收金额;
			parameters[25].Value = model._2017年实际回款时间;
			parameters[26].Value = model._2018年开票时间;
			parameters[27].Value = model._2018年开票金额;
			parameters[28].Value = model._2018年合同收款时间;
			parameters[29].Value = model._2018年合同收款金额;
			parameters[30].Value = model._2018年实际回款金额;
			parameters[31].Value = model._2018年应收未收金额;
			parameters[32].Value = model._2018年到期应收未收金额;
			parameters[33].Value = model._2018年实际回款时间;
			parameters[34].Value = model._2019年开票时间;
			parameters[35].Value = model._2019年开票金额;
			parameters[36].Value = model._2019年合同收款时间;
			parameters[37].Value = model._2019年合同收款金额;
			parameters[38].Value = model._2019年实际回款金额;
			parameters[39].Value = model._2019年应收未收金额;
			parameters[40].Value = model._2019年到期应收未收金额;
			parameters[41].Value = model._2019年实际回款时间;
			parameters[42].Value = model._2020年开票时间;
			parameters[43].Value = model._2020年开票金额;
			parameters[44].Value = model._2020年合同收款时间;
			parameters[45].Value = model._2020年合同收款金额;
			parameters[46].Value = model._2020年实际回款金额;
			parameters[47].Value = model._2020年应收未收金额;
			parameters[48].Value = model._2020年到期应收未收金额;
			parameters[49].Value = model._2020年实际回款时间;
			parameters[50].Value = model._2021年开票时间;
			parameters[51].Value = model._2021年开票金额;
			parameters[52].Value = model._2021年合同收款时间;
			parameters[53].Value = model._2021年合同收款金额;
			parameters[54].Value = model._2021年实际回款金额;
			parameters[55].Value = model._2021年应收未收金额;
			parameters[56].Value = model._2021年到期应收未收金额;
			parameters[57].Value = model._2021年实际回款时间;
			parameters[58].Value = model._2022年开票时间;
			parameters[59].Value = model._2022年开票金额;
			parameters[60].Value = model._2022年合同收款时间;
			parameters[61].Value = model._2022年合同收款金额;
			parameters[62].Value = model._2022年实际回款金额;
			parameters[63].Value = model._2022年应收未收金额;
			parameters[64].Value = model._2022年到期应收未收金额;
			parameters[65].Value = model._2022年实际回款时间;
			parameters[66].Value = model._2023年开票时间;
			parameters[67].Value = model._2023年开票金额;
			parameters[68].Value = model._2023年合同收款时间;
			parameters[69].Value = model._2023年合同收款金额;
			parameters[70].Value = model._2023年实际回款金额;
			parameters[71].Value = model._2023年应收未收金额;
			parameters[72].Value = model._2023年到期应收未收金额;
			parameters[73].Value = model._2023年实际回款时间;
			parameters[74].Value = model._2024年开票时间;
			parameters[75].Value = model._2024年开票金额;
			parameters[76].Value = model._2024年合同收款时间;
			parameters[77].Value = model._2024年合同收款金额;
			parameters[78].Value = model._2024年实际回款金额;
			parameters[79].Value = model._2024年应收未收金额;
			parameters[80].Value = model._2024年到期应收未收金额;
			parameters[81].Value = model._2024年实际回款时间;
			parameters[82].Value = model._2025年开票时间;
			parameters[83].Value = model._2025年开票金额;
			parameters[84].Value = model._2025年合同收款时间;
			parameters[85].Value = model._2025年合同收款金额;
			parameters[86].Value = model._2025年实际回款金额;
			parameters[87].Value = model._2025年应收未收金额;
			parameters[88].Value = model._2025年到期应收未收金额;
			parameters[89].Value = model._2025年实际回款时间;
			parameters[90].Value = model._2026年开票时间;
			parameters[91].Value = model._2026年开票金额;
			parameters[92].Value = model._2026年合同收款时间;
			parameters[93].Value = model._2026年合同收款金额;
			parameters[94].Value = model._2026年实际回款金额;
			parameters[95].Value = model._2026年应收未收金额;
			parameters[96].Value = model._2026年到期应收未收金额;
			parameters[97].Value = model._2026年实际回款时间;
			parameters[98].Value = model._2027年开票时间;
			parameters[99].Value = model._2027年开票金额;
			parameters[100].Value = model._2027年合同收款时间;
			parameters[101].Value = model._2027年合同收款金额;
			parameters[102].Value = model._2027年实际回款金额;
			parameters[103].Value = model._2027年应收未收金额;
			parameters[104].Value = model._2027年到期应收未收金额;
			parameters[105].Value = model._2027年实际回款时间;
			parameters[106].Value = model._2028年开票时间;
			parameters[107].Value = model._2028年开票金额;
			parameters[108].Value = model._2028年合同收款时间;
			parameters[109].Value = model._2028年合同收款金额;
			parameters[110].Value = model._2028年实际回款金额;
			parameters[111].Value = model._2028年应收未收金额;
			parameters[112].Value = model._2028年到期应收未收金额;
			parameters[113].Value = model._2028年实际回款时间;
			parameters[114].Value = model._2029年开票时间;
			parameters[115].Value = model._2029年开票金额;
			parameters[116].Value = model._2029年合同收款时间;
			parameters[117].Value = model._2029年合同收款金额;
			parameters[118].Value = model._2029年实际回款金额;
			parameters[119].Value = model._2029年应收未收金额;
			parameters[120].Value = model._2029年到期应收未收金额;
			parameters[121].Value = model._2029年实际回款时间;
			parameters[122].Value = model._2030年开票时间;
			parameters[123].Value = model._2030年开票金额;
			parameters[124].Value = model._2030年合同收款时间;
			parameters[125].Value = model._2030年合同收款金额;
			parameters[126].Value = model._2030年实际回款金额;
			parameters[127].Value = model._2030年应收未收金额;
			parameters[128].Value = model._2030年到期应收未收金额;
			parameters[129].Value = model._2030年实际回款时间;
			parameters[130].Value = model.推迟收款时间;
			parameters[131].Value = model.实际竣工时间;
			parameters[132].Value = model.竣工与实际收款时间差异;
			parameters[133].Value = model.移动交付;
			parameters[134].Value = model.电信交付;
			parameters[135].Value = model.联通交付;
			parameters[136].Value = model.铁塔交付;
			parameters[137].Value = model.运营商合同签订日期;
			parameters[138].Value = model.运营商交付单与租赁合同时间差;
			parameters[139].Value = model.移动实际付款时间;
			parameters[140].Value = model.电信实际付款时间;
			parameters[141].Value = model.联通实际付款时间;
			parameters[142].Value = model.备注;
			parameters[143].Value = model.IsDeleted;
			parameters[144].Value = model.CreateBy;
			parameters[145].Value = model.CreateTime;
			parameters[146].Value = model.UpdateBy;
			parameters[147].Value = model.UpdateTime;
			parameters[148].Value = model.id;

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
			strSql.Append("delete from Health_Xs ");
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
			strSql.Append("delete from Health_Xs ");
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
		public WTCJ.Model.Health_Xs GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,区域,客户名称,站点名称,站点编码,回款期限,租金金额,基站销售款,累计应收金额,税率,伟通收入不含税,_2016年开票时间,_2016年开票金额,_2016年合同收款时间,_2016年合同收款金额,_2016年实际回款金额,_2016年应收未收金额,_2016年到期应收未收金额,_2016年实际回款时间,_2017年开票时间,_2017年开票金额,_2017年合同收款时间,_2017年合同收款金额,_2017年实际回款金额,_2017年应收未收金额,_2017年到期应收未收金额,_2017年实际回款时间,_2018年开票时间,_2018年开票金额,_2018年合同收款时间,_2018年合同收款金额,_2018年实际回款金额,_2018年应收未收金额,_2018年到期应收未收金额,_2018年实际回款时间,_2019年开票时间,_2019年开票金额,_2019年合同收款时间,_2019年合同收款金额,_2019年实际回款金额,_2019年应收未收金额,_2019年到期应收未收金额,_2019年实际回款时间,_2020年开票时间,_2020年开票金额,_2020年合同收款时间,_2020年合同收款金额,_2020年实际回款金额,_2020年应收未收金额,_2020年到期应收未收金额,_2020年实际回款时间,_2021年开票时间,_2021年开票金额,_2021年合同收款时间,_2021年合同收款金额,_2021年实际回款金额,_2021年应收未收金额,_2021年到期应收未收金额,_2021年实际回款时间,_2022年开票时间,_2022年开票金额,_2022年合同收款时间,_2022年合同收款金额,_2022年实际回款金额,_2022年应收未收金额,_2022年到期应收未收金额,_2022年实际回款时间,_2023年开票时间,_2023年开票金额,_2023年合同收款时间,_2023年合同收款金额,_2023年实际回款金额,_2023年应收未收金额,_2023年到期应收未收金额,_2023年实际回款时间,_2024年开票时间,_2024年开票金额,_2024年合同收款时间,_2024年合同收款金额,_2024年实际回款金额,_2024年应收未收金额,_2024年到期应收未收金额,_2024年实际回款时间,_2025年开票时间,_2025年开票金额,_2025年合同收款时间,_2025年合同收款金额,_2025年实际回款金额,_2025年应收未收金额,_2025年到期应收未收金额,_2025年实际回款时间,_2026年开票时间,_2026年开票金额,_2026年合同收款时间,_2026年合同收款金额,_2026年实际回款金额,_2026年应收未收金额,_2026年到期应收未收金额,_2026年实际回款时间,_2027年开票时间,_2027年开票金额,_2027年合同收款时间,_2027年合同收款金额,_2027年实际回款金额,_2027年应收未收金额,_2027年到期应收未收金额,_2027年实际回款时间,_2028年开票时间,_2028年开票金额,_2028年合同收款时间,_2028年合同收款金额,_2028年实际回款金额,_2028年应收未收金额,_2028年到期应收未收金额,_2028年实际回款时间,_2029年开票时间,_2029年开票金额,_2029年合同收款时间,_2029年合同收款金额,_2029年实际回款金额,_2029年应收未收金额,_2029年到期应收未收金额,_2029年实际回款时间,_2030年开票时间,_2030年开票金额,_2030年合同收款时间,_2030年合同收款金额,_2030年实际回款金额,_2030年应收未收金额,_2030年到期应收未收金额,_2030年实际回款时间,推迟收款时间,实际竣工时间,竣工与实际收款时间差异,移动交付,电信交付,联通交付,铁塔交付,运营商合同签订日期,运营商交付单与租赁合同时间差,移动实际付款时间,电信实际付款时间,联通实际付款时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime from Health_Xs ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			WTCJ.Model.Health_Xs model=new WTCJ.Model.Health_Xs();
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
		public WTCJ.Model.Health_Xs DataRowToModel(DataRow row)
		{
			WTCJ.Model.Health_Xs model=new WTCJ.Model.Health_Xs();
			if (row != null)
			{
				if(row["id"]!=null)
				{
					model.id=row["id"].ToString();
				}
				if(row["区域"]!=null)
				{
					model.区域=row["区域"].ToString();
				}
				if(row["客户名称"]!=null)
				{
					model.客户名称=row["客户名称"].ToString();
				}
				if(row["站点名称"]!=null)
				{
					model.站点名称=row["站点名称"].ToString();
				}
				if(row["站点编码"]!=null)
				{
					model.站点编码=row["站点编码"].ToString();
				}
				if(row["回款期限"]!=null)
				{
					model.回款期限=row["回款期限"].ToString();
				}
				if(row["租金金额"]!=null && row["租金金额"].ToString()!="")
				{
					model.租金金额=decimal.Parse(row["租金金额"].ToString());
				}
				if(row["基站销售款"]!=null && row["基站销售款"].ToString()!="")
				{
					model.基站销售款=decimal.Parse(row["基站销售款"].ToString());
				}
				if(row["累计应收金额"]!=null && row["累计应收金额"].ToString()!="")
				{
					model.累计应收金额=decimal.Parse(row["累计应收金额"].ToString());
				}
				if(row["税率"]!=null && row["税率"].ToString()!="")
				{
					model.税率=decimal.Parse(row["税率"].ToString());
				}
				if(row["伟通收入不含税"]!=null && row["伟通收入不含税"].ToString()!="")
				{
					model.伟通收入不含税=decimal.Parse(row["伟通收入不含税"].ToString());
				}
				if(row["_2016年开票时间"]!=null && row["_2016年开票时间"].ToString()!="")
				{
					model._2016年开票时间=DateTime.Parse(row["_2016年开票时间"].ToString());
				}
				if(row["_2016年开票金额"]!=null && row["_2016年开票金额"].ToString()!="")
				{
					model._2016年开票金额=decimal.Parse(row["_2016年开票金额"].ToString());
				}
				if(row["_2016年合同收款时间"]!=null && row["_2016年合同收款时间"].ToString()!="")
				{
					model._2016年合同收款时间=DateTime.Parse(row["_2016年合同收款时间"].ToString());
				}
				if(row["_2016年合同收款金额"]!=null && row["_2016年合同收款金额"].ToString()!="")
				{
					model._2016年合同收款金额=decimal.Parse(row["_2016年合同收款金额"].ToString());
				}
				if(row["_2016年实际回款金额"]!=null && row["_2016年实际回款金额"].ToString()!="")
				{
					model._2016年实际回款金额=decimal.Parse(row["_2016年实际回款金额"].ToString());
				}
				if(row["_2016年应收未收金额"]!=null && row["_2016年应收未收金额"].ToString()!="")
				{
					model._2016年应收未收金额=decimal.Parse(row["_2016年应收未收金额"].ToString());
				}
				if(row["_2016年到期应收未收金额"]!=null && row["_2016年到期应收未收金额"].ToString()!="")
				{
					model._2016年到期应收未收金额=decimal.Parse(row["_2016年到期应收未收金额"].ToString());
				}
				if(row["_2016年实际回款时间"]!=null && row["_2016年实际回款时间"].ToString()!="")
				{
					model._2016年实际回款时间=DateTime.Parse(row["_2016年实际回款时间"].ToString());
				}
				if(row["_2017年开票时间"]!=null && row["_2017年开票时间"].ToString()!="")
				{
					model._2017年开票时间=DateTime.Parse(row["_2017年开票时间"].ToString());
				}
				if(row["_2017年开票金额"]!=null && row["_2017年开票金额"].ToString()!="")
				{
					model._2017年开票金额=decimal.Parse(row["_2017年开票金额"].ToString());
				}
				if(row["_2017年合同收款时间"]!=null && row["_2017年合同收款时间"].ToString()!="")
				{
					model._2017年合同收款时间=DateTime.Parse(row["_2017年合同收款时间"].ToString());
				}
				if(row["_2017年合同收款金额"]!=null && row["_2017年合同收款金额"].ToString()!="")
				{
					model._2017年合同收款金额=decimal.Parse(row["_2017年合同收款金额"].ToString());
				}
				if(row["_2017年实际回款金额"]!=null && row["_2017年实际回款金额"].ToString()!="")
				{
					model._2017年实际回款金额=decimal.Parse(row["_2017年实际回款金额"].ToString());
				}
				if(row["_2017年应收未收金额"]!=null && row["_2017年应收未收金额"].ToString()!="")
				{
					model._2017年应收未收金额=decimal.Parse(row["_2017年应收未收金额"].ToString());
				}
				if(row["_2017年到期应收未收金额"]!=null && row["_2017年到期应收未收金额"].ToString()!="")
				{
					model._2017年到期应收未收金额=decimal.Parse(row["_2017年到期应收未收金额"].ToString());
				}
				if(row["_2017年实际回款时间"]!=null && row["_2017年实际回款时间"].ToString()!="")
				{
					model._2017年实际回款时间=DateTime.Parse(row["_2017年实际回款时间"].ToString());
				}
				if(row["_2018年开票时间"]!=null && row["_2018年开票时间"].ToString()!="")
				{
					model._2018年开票时间=DateTime.Parse(row["_2018年开票时间"].ToString());
				}
				if(row["_2018年开票金额"]!=null && row["_2018年开票金额"].ToString()!="")
				{
					model._2018年开票金额=decimal.Parse(row["_2018年开票金额"].ToString());
				}
				if(row["_2018年合同收款时间"]!=null && row["_2018年合同收款时间"].ToString()!="")
				{
					model._2018年合同收款时间=DateTime.Parse(row["_2018年合同收款时间"].ToString());
				}
				if(row["_2018年合同收款金额"]!=null && row["_2018年合同收款金额"].ToString()!="")
				{
					model._2018年合同收款金额=decimal.Parse(row["_2018年合同收款金额"].ToString());
				}
				if(row["_2018年实际回款金额"]!=null && row["_2018年实际回款金额"].ToString()!="")
				{
					model._2018年实际回款金额=decimal.Parse(row["_2018年实际回款金额"].ToString());
				}
				if(row["_2018年应收未收金额"]!=null && row["_2018年应收未收金额"].ToString()!="")
				{
					model._2018年应收未收金额=decimal.Parse(row["_2018年应收未收金额"].ToString());
				}
				if(row["_2018年到期应收未收金额"]!=null && row["_2018年到期应收未收金额"].ToString()!="")
				{
					model._2018年到期应收未收金额=decimal.Parse(row["_2018年到期应收未收金额"].ToString());
				}
				if(row["_2018年实际回款时间"]!=null && row["_2018年实际回款时间"].ToString()!="")
				{
					model._2018年实际回款时间=DateTime.Parse(row["_2018年实际回款时间"].ToString());
				}
				if(row["_2019年开票时间"]!=null && row["_2019年开票时间"].ToString()!="")
				{
					model._2019年开票时间=DateTime.Parse(row["_2019年开票时间"].ToString());
				}
				if(row["_2019年开票金额"]!=null && row["_2019年开票金额"].ToString()!="")
				{
					model._2019年开票金额=decimal.Parse(row["_2019年开票金额"].ToString());
				}
				if(row["_2019年合同收款时间"]!=null && row["_2019年合同收款时间"].ToString()!="")
				{
					model._2019年合同收款时间=DateTime.Parse(row["_2019年合同收款时间"].ToString());
				}
				if(row["_2019年合同收款金额"]!=null && row["_2019年合同收款金额"].ToString()!="")
				{
					model._2019年合同收款金额=decimal.Parse(row["_2019年合同收款金额"].ToString());
				}
				if(row["_2019年实际回款金额"]!=null && row["_2019年实际回款金额"].ToString()!="")
				{
					model._2019年实际回款金额=decimal.Parse(row["_2019年实际回款金额"].ToString());
				}
				if(row["_2019年应收未收金额"]!=null && row["_2019年应收未收金额"].ToString()!="")
				{
					model._2019年应收未收金额=decimal.Parse(row["_2019年应收未收金额"].ToString());
				}
				if(row["_2019年到期应收未收金额"]!=null && row["_2019年到期应收未收金额"].ToString()!="")
				{
					model._2019年到期应收未收金额=decimal.Parse(row["_2019年到期应收未收金额"].ToString());
				}
				if(row["_2019年实际回款时间"]!=null && row["_2019年实际回款时间"].ToString()!="")
				{
					model._2019年实际回款时间=DateTime.Parse(row["_2019年实际回款时间"].ToString());
				}
				if(row["_2020年开票时间"]!=null && row["_2020年开票时间"].ToString()!="")
				{
					model._2020年开票时间=DateTime.Parse(row["_2020年开票时间"].ToString());
				}
				if(row["_2020年开票金额"]!=null && row["_2020年开票金额"].ToString()!="")
				{
					model._2020年开票金额=decimal.Parse(row["_2020年开票金额"].ToString());
				}
				if(row["_2020年合同收款时间"]!=null && row["_2020年合同收款时间"].ToString()!="")
				{
					model._2020年合同收款时间=DateTime.Parse(row["_2020年合同收款时间"].ToString());
				}
				if(row["_2020年合同收款金额"]!=null && row["_2020年合同收款金额"].ToString()!="")
				{
					model._2020年合同收款金额=decimal.Parse(row["_2020年合同收款金额"].ToString());
				}
				if(row["_2020年实际回款金额"]!=null && row["_2020年实际回款金额"].ToString()!="")
				{
					model._2020年实际回款金额=decimal.Parse(row["_2020年实际回款金额"].ToString());
				}
				if(row["_2020年应收未收金额"]!=null && row["_2020年应收未收金额"].ToString()!="")
				{
					model._2020年应收未收金额=decimal.Parse(row["_2020年应收未收金额"].ToString());
				}
				if(row["_2020年到期应收未收金额"]!=null && row["_2020年到期应收未收金额"].ToString()!="")
				{
					model._2020年到期应收未收金额=decimal.Parse(row["_2020年到期应收未收金额"].ToString());
				}
				if(row["_2020年实际回款时间"]!=null && row["_2020年实际回款时间"].ToString()!="")
				{
					model._2020年实际回款时间=DateTime.Parse(row["_2020年实际回款时间"].ToString());
				}
				if(row["_2021年开票时间"]!=null && row["_2021年开票时间"].ToString()!="")
				{
					model._2021年开票时间=DateTime.Parse(row["_2021年开票时间"].ToString());
				}
				if(row["_2021年开票金额"]!=null && row["_2021年开票金额"].ToString()!="")
				{
					model._2021年开票金额=decimal.Parse(row["_2021年开票金额"].ToString());
				}
				if(row["_2021年合同收款时间"]!=null && row["_2021年合同收款时间"].ToString()!="")
				{
					model._2021年合同收款时间=DateTime.Parse(row["_2021年合同收款时间"].ToString());
				}
				if(row["_2021年合同收款金额"]!=null && row["_2021年合同收款金额"].ToString()!="")
				{
					model._2021年合同收款金额=decimal.Parse(row["_2021年合同收款金额"].ToString());
				}
				if(row["_2021年实际回款金额"]!=null && row["_2021年实际回款金额"].ToString()!="")
				{
					model._2021年实际回款金额=decimal.Parse(row["_2021年实际回款金额"].ToString());
				}
				if(row["_2021年应收未收金额"]!=null && row["_2021年应收未收金额"].ToString()!="")
				{
					model._2021年应收未收金额=decimal.Parse(row["_2021年应收未收金额"].ToString());
				}
				if(row["_2021年到期应收未收金额"]!=null && row["_2021年到期应收未收金额"].ToString()!="")
				{
					model._2021年到期应收未收金额=decimal.Parse(row["_2021年到期应收未收金额"].ToString());
				}
				if(row["_2021年实际回款时间"]!=null && row["_2021年实际回款时间"].ToString()!="")
				{
					model._2021年实际回款时间=DateTime.Parse(row["_2021年实际回款时间"].ToString());
				}
				if(row["_2022年开票时间"]!=null && row["_2022年开票时间"].ToString()!="")
				{
					model._2022年开票时间=DateTime.Parse(row["_2022年开票时间"].ToString());
				}
				if(row["_2022年开票金额"]!=null && row["_2022年开票金额"].ToString()!="")
				{
					model._2022年开票金额=decimal.Parse(row["_2022年开票金额"].ToString());
				}
				if(row["_2022年合同收款时间"]!=null && row["_2022年合同收款时间"].ToString()!="")
				{
					model._2022年合同收款时间=DateTime.Parse(row["_2022年合同收款时间"].ToString());
				}
				if(row["_2022年合同收款金额"]!=null && row["_2022年合同收款金额"].ToString()!="")
				{
					model._2022年合同收款金额=decimal.Parse(row["_2022年合同收款金额"].ToString());
				}
				if(row["_2022年实际回款金额"]!=null && row["_2022年实际回款金额"].ToString()!="")
				{
					model._2022年实际回款金额=decimal.Parse(row["_2022年实际回款金额"].ToString());
				}
				if(row["_2022年应收未收金额"]!=null && row["_2022年应收未收金额"].ToString()!="")
				{
					model._2022年应收未收金额=decimal.Parse(row["_2022年应收未收金额"].ToString());
				}
				if(row["_2022年到期应收未收金额"]!=null && row["_2022年到期应收未收金额"].ToString()!="")
				{
					model._2022年到期应收未收金额=decimal.Parse(row["_2022年到期应收未收金额"].ToString());
				}
				if(row["_2022年实际回款时间"]!=null && row["_2022年实际回款时间"].ToString()!="")
				{
					model._2022年实际回款时间=DateTime.Parse(row["_2022年实际回款时间"].ToString());
				}
				if(row["_2023年开票时间"]!=null && row["_2023年开票时间"].ToString()!="")
				{
					model._2023年开票时间=DateTime.Parse(row["_2023年开票时间"].ToString());
				}
				if(row["_2023年开票金额"]!=null && row["_2023年开票金额"].ToString()!="")
				{
					model._2023年开票金额=decimal.Parse(row["_2023年开票金额"].ToString());
				}
				if(row["_2023年合同收款时间"]!=null && row["_2023年合同收款时间"].ToString()!="")
				{
					model._2023年合同收款时间=DateTime.Parse(row["_2023年合同收款时间"].ToString());
				}
				if(row["_2023年合同收款金额"]!=null && row["_2023年合同收款金额"].ToString()!="")
				{
					model._2023年合同收款金额=decimal.Parse(row["_2023年合同收款金额"].ToString());
				}
				if(row["_2023年实际回款金额"]!=null && row["_2023年实际回款金额"].ToString()!="")
				{
					model._2023年实际回款金额=decimal.Parse(row["_2023年实际回款金额"].ToString());
				}
				if(row["_2023年应收未收金额"]!=null && row["_2023年应收未收金额"].ToString()!="")
				{
					model._2023年应收未收金额=decimal.Parse(row["_2023年应收未收金额"].ToString());
				}
				if(row["_2023年到期应收未收金额"]!=null && row["_2023年到期应收未收金额"].ToString()!="")
				{
					model._2023年到期应收未收金额=decimal.Parse(row["_2023年到期应收未收金额"].ToString());
				}
				if(row["_2023年实际回款时间"]!=null && row["_2023年实际回款时间"].ToString()!="")
				{
					model._2023年实际回款时间=DateTime.Parse(row["_2023年实际回款时间"].ToString());
				}
				if(row["_2024年开票时间"]!=null && row["_2024年开票时间"].ToString()!="")
				{
					model._2024年开票时间=DateTime.Parse(row["_2024年开票时间"].ToString());
				}
				if(row["_2024年开票金额"]!=null && row["_2024年开票金额"].ToString()!="")
				{
					model._2024年开票金额=decimal.Parse(row["_2024年开票金额"].ToString());
				}
				if(row["_2024年合同收款时间"]!=null && row["_2024年合同收款时间"].ToString()!="")
				{
					model._2024年合同收款时间=DateTime.Parse(row["_2024年合同收款时间"].ToString());
				}
				if(row["_2024年合同收款金额"]!=null && row["_2024年合同收款金额"].ToString()!="")
				{
					model._2024年合同收款金额=decimal.Parse(row["_2024年合同收款金额"].ToString());
				}
				if(row["_2024年实际回款金额"]!=null && row["_2024年实际回款金额"].ToString()!="")
				{
					model._2024年实际回款金额=decimal.Parse(row["_2024年实际回款金额"].ToString());
				}
				if(row["_2024年应收未收金额"]!=null && row["_2024年应收未收金额"].ToString()!="")
				{
					model._2024年应收未收金额=decimal.Parse(row["_2024年应收未收金额"].ToString());
				}
				if(row["_2024年到期应收未收金额"]!=null && row["_2024年到期应收未收金额"].ToString()!="")
				{
					model._2024年到期应收未收金额=decimal.Parse(row["_2024年到期应收未收金额"].ToString());
				}
				if(row["_2024年实际回款时间"]!=null && row["_2024年实际回款时间"].ToString()!="")
				{
					model._2024年实际回款时间=DateTime.Parse(row["_2024年实际回款时间"].ToString());
				}
				if(row["_2025年开票时间"]!=null && row["_2025年开票时间"].ToString()!="")
				{
					model._2025年开票时间=DateTime.Parse(row["_2025年开票时间"].ToString());
				}
				if(row["_2025年开票金额"]!=null && row["_2025年开票金额"].ToString()!="")
				{
					model._2025年开票金额=decimal.Parse(row["_2025年开票金额"].ToString());
				}
				if(row["_2025年合同收款时间"]!=null && row["_2025年合同收款时间"].ToString()!="")
				{
					model._2025年合同收款时间=DateTime.Parse(row["_2025年合同收款时间"].ToString());
				}
				if(row["_2025年合同收款金额"]!=null && row["_2025年合同收款金额"].ToString()!="")
				{
					model._2025年合同收款金额=decimal.Parse(row["_2025年合同收款金额"].ToString());
				}
				if(row["_2025年实际回款金额"]!=null && row["_2025年实际回款金额"].ToString()!="")
				{
					model._2025年实际回款金额=decimal.Parse(row["_2025年实际回款金额"].ToString());
				}
				if(row["_2025年应收未收金额"]!=null && row["_2025年应收未收金额"].ToString()!="")
				{
					model._2025年应收未收金额=decimal.Parse(row["_2025年应收未收金额"].ToString());
				}
				if(row["_2025年到期应收未收金额"]!=null && row["_2025年到期应收未收金额"].ToString()!="")
				{
					model._2025年到期应收未收金额=decimal.Parse(row["_2025年到期应收未收金额"].ToString());
				}
				if(row["_2025年实际回款时间"]!=null && row["_2025年实际回款时间"].ToString()!="")
				{
					model._2025年实际回款时间=DateTime.Parse(row["_2025年实际回款时间"].ToString());
				}
				if(row["_2026年开票时间"]!=null && row["_2026年开票时间"].ToString()!="")
				{
					model._2026年开票时间=DateTime.Parse(row["_2026年开票时间"].ToString());
				}
				if(row["_2026年开票金额"]!=null && row["_2026年开票金额"].ToString()!="")
				{
					model._2026年开票金额=decimal.Parse(row["_2026年开票金额"].ToString());
				}
				if(row["_2026年合同收款时间"]!=null && row["_2026年合同收款时间"].ToString()!="")
				{
					model._2026年合同收款时间=DateTime.Parse(row["_2026年合同收款时间"].ToString());
				}
				if(row["_2026年合同收款金额"]!=null && row["_2026年合同收款金额"].ToString()!="")
				{
					model._2026年合同收款金额=decimal.Parse(row["_2026年合同收款金额"].ToString());
				}
				if(row["_2026年实际回款金额"]!=null && row["_2026年实际回款金额"].ToString()!="")
				{
					model._2026年实际回款金额=decimal.Parse(row["_2026年实际回款金额"].ToString());
				}
				if(row["_2026年应收未收金额"]!=null && row["_2026年应收未收金额"].ToString()!="")
				{
					model._2026年应收未收金额=decimal.Parse(row["_2026年应收未收金额"].ToString());
				}
				if(row["_2026年到期应收未收金额"]!=null && row["_2026年到期应收未收金额"].ToString()!="")
				{
					model._2026年到期应收未收金额=decimal.Parse(row["_2026年到期应收未收金额"].ToString());
				}
				if(row["_2026年实际回款时间"]!=null && row["_2026年实际回款时间"].ToString()!="")
				{
					model._2026年实际回款时间=DateTime.Parse(row["_2026年实际回款时间"].ToString());
				}
				if(row["_2027年开票时间"]!=null && row["_2027年开票时间"].ToString()!="")
				{
					model._2027年开票时间=DateTime.Parse(row["_2027年开票时间"].ToString());
				}
				if(row["_2027年开票金额"]!=null && row["_2027年开票金额"].ToString()!="")
				{
					model._2027年开票金额=decimal.Parse(row["_2027年开票金额"].ToString());
				}
				if(row["_2027年合同收款时间"]!=null && row["_2027年合同收款时间"].ToString()!="")
				{
					model._2027年合同收款时间=DateTime.Parse(row["_2027年合同收款时间"].ToString());
				}
				if(row["_2027年合同收款金额"]!=null && row["_2027年合同收款金额"].ToString()!="")
				{
					model._2027年合同收款金额=decimal.Parse(row["_2027年合同收款金额"].ToString());
				}
				if(row["_2027年实际回款金额"]!=null && row["_2027年实际回款金额"].ToString()!="")
				{
					model._2027年实际回款金额=decimal.Parse(row["_2027年实际回款金额"].ToString());
				}
				if(row["_2027年应收未收金额"]!=null && row["_2027年应收未收金额"].ToString()!="")
				{
					model._2027年应收未收金额=decimal.Parse(row["_2027年应收未收金额"].ToString());
				}
				if(row["_2027年到期应收未收金额"]!=null && row["_2027年到期应收未收金额"].ToString()!="")
				{
					model._2027年到期应收未收金额=decimal.Parse(row["_2027年到期应收未收金额"].ToString());
				}
				if(row["_2027年实际回款时间"]!=null && row["_2027年实际回款时间"].ToString()!="")
				{
					model._2027年实际回款时间=DateTime.Parse(row["_2027年实际回款时间"].ToString());
				}
				if(row["_2028年开票时间"]!=null && row["_2028年开票时间"].ToString()!="")
				{
					model._2028年开票时间=DateTime.Parse(row["_2028年开票时间"].ToString());
				}
				if(row["_2028年开票金额"]!=null && row["_2028年开票金额"].ToString()!="")
				{
					model._2028年开票金额=decimal.Parse(row["_2028年开票金额"].ToString());
				}
				if(row["_2028年合同收款时间"]!=null && row["_2028年合同收款时间"].ToString()!="")
				{
					model._2028年合同收款时间=DateTime.Parse(row["_2028年合同收款时间"].ToString());
				}
				if(row["_2028年合同收款金额"]!=null && row["_2028年合同收款金额"].ToString()!="")
				{
					model._2028年合同收款金额=decimal.Parse(row["_2028年合同收款金额"].ToString());
				}
				if(row["_2028年实际回款金额"]!=null && row["_2028年实际回款金额"].ToString()!="")
				{
					model._2028年实际回款金额=decimal.Parse(row["_2028年实际回款金额"].ToString());
				}
				if(row["_2028年应收未收金额"]!=null && row["_2028年应收未收金额"].ToString()!="")
				{
					model._2028年应收未收金额=decimal.Parse(row["_2028年应收未收金额"].ToString());
				}
				if(row["_2028年到期应收未收金额"]!=null && row["_2028年到期应收未收金额"].ToString()!="")
				{
					model._2028年到期应收未收金额=decimal.Parse(row["_2028年到期应收未收金额"].ToString());
				}
				if(row["_2028年实际回款时间"]!=null && row["_2028年实际回款时间"].ToString()!="")
				{
					model._2028年实际回款时间=DateTime.Parse(row["_2028年实际回款时间"].ToString());
				}
				if(row["_2029年开票时间"]!=null && row["_2029年开票时间"].ToString()!="")
				{
					model._2029年开票时间=DateTime.Parse(row["_2029年开票时间"].ToString());
				}
				if(row["_2029年开票金额"]!=null && row["_2029年开票金额"].ToString()!="")
				{
					model._2029年开票金额=decimal.Parse(row["_2029年开票金额"].ToString());
				}
				if(row["_2029年合同收款时间"]!=null && row["_2029年合同收款时间"].ToString()!="")
				{
					model._2029年合同收款时间=DateTime.Parse(row["_2029年合同收款时间"].ToString());
				}
				if(row["_2029年合同收款金额"]!=null && row["_2029年合同收款金额"].ToString()!="")
				{
					model._2029年合同收款金额=decimal.Parse(row["_2029年合同收款金额"].ToString());
				}
				if(row["_2029年实际回款金额"]!=null && row["_2029年实际回款金额"].ToString()!="")
				{
					model._2029年实际回款金额=decimal.Parse(row["_2029年实际回款金额"].ToString());
				}
				if(row["_2029年应收未收金额"]!=null && row["_2029年应收未收金额"].ToString()!="")
				{
					model._2029年应收未收金额=decimal.Parse(row["_2029年应收未收金额"].ToString());
				}
				if(row["_2029年到期应收未收金额"]!=null && row["_2029年到期应收未收金额"].ToString()!="")
				{
					model._2029年到期应收未收金额=decimal.Parse(row["_2029年到期应收未收金额"].ToString());
				}
				if(row["_2029年实际回款时间"]!=null && row["_2029年实际回款时间"].ToString()!="")
				{
					model._2029年实际回款时间=DateTime.Parse(row["_2029年实际回款时间"].ToString());
				}
				if(row["_2030年开票时间"]!=null && row["_2030年开票时间"].ToString()!="")
				{
					model._2030年开票时间=DateTime.Parse(row["_2030年开票时间"].ToString());
				}
				if(row["_2030年开票金额"]!=null && row["_2030年开票金额"].ToString()!="")
				{
					model._2030年开票金额=decimal.Parse(row["_2030年开票金额"].ToString());
				}
				if(row["_2030年合同收款时间"]!=null && row["_2030年合同收款时间"].ToString()!="")
				{
					model._2030年合同收款时间=DateTime.Parse(row["_2030年合同收款时间"].ToString());
				}
				if(row["_2030年合同收款金额"]!=null && row["_2030年合同收款金额"].ToString()!="")
				{
					model._2030年合同收款金额=decimal.Parse(row["_2030年合同收款金额"].ToString());
				}
				if(row["_2030年实际回款金额"]!=null && row["_2030年实际回款金额"].ToString()!="")
				{
					model._2030年实际回款金额=decimal.Parse(row["_2030年实际回款金额"].ToString());
				}
				if(row["_2030年应收未收金额"]!=null && row["_2030年应收未收金额"].ToString()!="")
				{
					model._2030年应收未收金额=decimal.Parse(row["_2030年应收未收金额"].ToString());
				}
				if(row["_2030年到期应收未收金额"]!=null && row["_2030年到期应收未收金额"].ToString()!="")
				{
					model._2030年到期应收未收金额=decimal.Parse(row["_2030年到期应收未收金额"].ToString());
				}
				if(row["_2030年实际回款时间"]!=null && row["_2030年实际回款时间"].ToString()!="")
				{
					model._2030年实际回款时间=DateTime.Parse(row["_2030年实际回款时间"].ToString());
				}
				if(row["推迟收款时间"]!=null && row["推迟收款时间"].ToString()!="")
				{
					model.推迟收款时间=decimal.Parse(row["推迟收款时间"].ToString());
				}
				if(row["实际竣工时间"]!=null && row["实际竣工时间"].ToString()!="")
				{
					model.实际竣工时间=DateTime.Parse(row["实际竣工时间"].ToString());
				}
				if(row["竣工与实际收款时间差异"]!=null && row["竣工与实际收款时间差异"].ToString()!="")
				{
					model.竣工与实际收款时间差异=decimal.Parse(row["竣工与实际收款时间差异"].ToString());
				}
				if(row["移动交付"]!=null && row["移动交付"].ToString()!="")
				{
					model.移动交付=DateTime.Parse(row["移动交付"].ToString());
				}
				if(row["电信交付"]!=null && row["电信交付"].ToString()!="")
				{
					model.电信交付=DateTime.Parse(row["电信交付"].ToString());
				}
				if(row["联通交付"]!=null && row["联通交付"].ToString()!="")
				{
					model.联通交付=DateTime.Parse(row["联通交付"].ToString());
				}
				if(row["铁塔交付"]!=null && row["铁塔交付"].ToString()!="")
				{
					model.铁塔交付=DateTime.Parse(row["铁塔交付"].ToString());
				}
				if(row["运营商合同签订日期"]!=null && row["运营商合同签订日期"].ToString()!="")
				{
					model.运营商合同签订日期=DateTime.Parse(row["运营商合同签订日期"].ToString());
				}
				if(row["运营商交付单与租赁合同时间差"]!=null && row["运营商交付单与租赁合同时间差"].ToString()!="")
				{
					model.运营商交付单与租赁合同时间差=decimal.Parse(row["运营商交付单与租赁合同时间差"].ToString());
				}
				if(row["移动实际付款时间"]!=null && row["移动实际付款时间"].ToString()!="")
				{
					model.移动实际付款时间=DateTime.Parse(row["移动实际付款时间"].ToString());
				}
				if(row["电信实际付款时间"]!=null && row["电信实际付款时间"].ToString()!="")
				{
					model.电信实际付款时间=DateTime.Parse(row["电信实际付款时间"].ToString());
				}
				if(row["联通实际付款时间"]!=null && row["联通实际付款时间"].ToString()!="")
				{
					model.联通实际付款时间=DateTime.Parse(row["联通实际付款时间"].ToString());
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
			strSql.Append("select id,区域,客户名称,站点名称,站点编码,回款期限,租金金额,基站销售款,累计应收金额,税率,伟通收入不含税,_2016年开票时间,_2016年开票金额,_2016年合同收款时间,_2016年合同收款金额,_2016年实际回款金额,_2016年应收未收金额,_2016年到期应收未收金额,_2016年实际回款时间,_2017年开票时间,_2017年开票金额,_2017年合同收款时间,_2017年合同收款金额,_2017年实际回款金额,_2017年应收未收金额,_2017年到期应收未收金额,_2017年实际回款时间,_2018年开票时间,_2018年开票金额,_2018年合同收款时间,_2018年合同收款金额,_2018年实际回款金额,_2018年应收未收金额,_2018年到期应收未收金额,_2018年实际回款时间,_2019年开票时间,_2019年开票金额,_2019年合同收款时间,_2019年合同收款金额,_2019年实际回款金额,_2019年应收未收金额,_2019年到期应收未收金额,_2019年实际回款时间,_2020年开票时间,_2020年开票金额,_2020年合同收款时间,_2020年合同收款金额,_2020年实际回款金额,_2020年应收未收金额,_2020年到期应收未收金额,_2020年实际回款时间,_2021年开票时间,_2021年开票金额,_2021年合同收款时间,_2021年合同收款金额,_2021年实际回款金额,_2021年应收未收金额,_2021年到期应收未收金额,_2021年实际回款时间,_2022年开票时间,_2022年开票金额,_2022年合同收款时间,_2022年合同收款金额,_2022年实际回款金额,_2022年应收未收金额,_2022年到期应收未收金额,_2022年实际回款时间,_2023年开票时间,_2023年开票金额,_2023年合同收款时间,_2023年合同收款金额,_2023年实际回款金额,_2023年应收未收金额,_2023年到期应收未收金额,_2023年实际回款时间,_2024年开票时间,_2024年开票金额,_2024年合同收款时间,_2024年合同收款金额,_2024年实际回款金额,_2024年应收未收金额,_2024年到期应收未收金额,_2024年实际回款时间,_2025年开票时间,_2025年开票金额,_2025年合同收款时间,_2025年合同收款金额,_2025年实际回款金额,_2025年应收未收金额,_2025年到期应收未收金额,_2025年实际回款时间,_2026年开票时间,_2026年开票金额,_2026年合同收款时间,_2026年合同收款金额,_2026年实际回款金额,_2026年应收未收金额,_2026年到期应收未收金额,_2026年实际回款时间,_2027年开票时间,_2027年开票金额,_2027年合同收款时间,_2027年合同收款金额,_2027年实际回款金额,_2027年应收未收金额,_2027年到期应收未收金额,_2027年实际回款时间,_2028年开票时间,_2028年开票金额,_2028年合同收款时间,_2028年合同收款金额,_2028年实际回款金额,_2028年应收未收金额,_2028年到期应收未收金额,_2028年实际回款时间,_2029年开票时间,_2029年开票金额,_2029年合同收款时间,_2029年合同收款金额,_2029年实际回款金额,_2029年应收未收金额,_2029年到期应收未收金额,_2029年实际回款时间,_2030年开票时间,_2030年开票金额,_2030年合同收款时间,_2030年合同收款金额,_2030年实际回款金额,_2030年应收未收金额,_2030年到期应收未收金额,_2030年实际回款时间,推迟收款时间,实际竣工时间,竣工与实际收款时间差异,移动交付,电信交付,联通交付,铁塔交付,运营商合同签订日期,运营商交付单与租赁合同时间差,移动实际付款时间,电信实际付款时间,联通实际付款时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Health_Xs ");
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
			strSql.Append(" id,区域,客户名称,站点名称,站点编码,回款期限,租金金额,基站销售款,累计应收金额,税率,伟通收入不含税,_2016年开票时间,_2016年开票金额,_2016年合同收款时间,_2016年合同收款金额,_2016年实际回款金额,_2016年应收未收金额,_2016年到期应收未收金额,_2016年实际回款时间,_2017年开票时间,_2017年开票金额,_2017年合同收款时间,_2017年合同收款金额,_2017年实际回款金额,_2017年应收未收金额,_2017年到期应收未收金额,_2017年实际回款时间,_2018年开票时间,_2018年开票金额,_2018年合同收款时间,_2018年合同收款金额,_2018年实际回款金额,_2018年应收未收金额,_2018年到期应收未收金额,_2018年实际回款时间,_2019年开票时间,_2019年开票金额,_2019年合同收款时间,_2019年合同收款金额,_2019年实际回款金额,_2019年应收未收金额,_2019年到期应收未收金额,_2019年实际回款时间,_2020年开票时间,_2020年开票金额,_2020年合同收款时间,_2020年合同收款金额,_2020年实际回款金额,_2020年应收未收金额,_2020年到期应收未收金额,_2020年实际回款时间,_2021年开票时间,_2021年开票金额,_2021年合同收款时间,_2021年合同收款金额,_2021年实际回款金额,_2021年应收未收金额,_2021年到期应收未收金额,_2021年实际回款时间,_2022年开票时间,_2022年开票金额,_2022年合同收款时间,_2022年合同收款金额,_2022年实际回款金额,_2022年应收未收金额,_2022年到期应收未收金额,_2022年实际回款时间,_2023年开票时间,_2023年开票金额,_2023年合同收款时间,_2023年合同收款金额,_2023年实际回款金额,_2023年应收未收金额,_2023年到期应收未收金额,_2023年实际回款时间,_2024年开票时间,_2024年开票金额,_2024年合同收款时间,_2024年合同收款金额,_2024年实际回款金额,_2024年应收未收金额,_2024年到期应收未收金额,_2024年实际回款时间,_2025年开票时间,_2025年开票金额,_2025年合同收款时间,_2025年合同收款金额,_2025年实际回款金额,_2025年应收未收金额,_2025年到期应收未收金额,_2025年实际回款时间,_2026年开票时间,_2026年开票金额,_2026年合同收款时间,_2026年合同收款金额,_2026年实际回款金额,_2026年应收未收金额,_2026年到期应收未收金额,_2026年实际回款时间,_2027年开票时间,_2027年开票金额,_2027年合同收款时间,_2027年合同收款金额,_2027年实际回款金额,_2027年应收未收金额,_2027年到期应收未收金额,_2027年实际回款时间,_2028年开票时间,_2028年开票金额,_2028年合同收款时间,_2028年合同收款金额,_2028年实际回款金额,_2028年应收未收金额,_2028年到期应收未收金额,_2028年实际回款时间,_2029年开票时间,_2029年开票金额,_2029年合同收款时间,_2029年合同收款金额,_2029年实际回款金额,_2029年应收未收金额,_2029年到期应收未收金额,_2029年实际回款时间,_2030年开票时间,_2030年开票金额,_2030年合同收款时间,_2030年合同收款金额,_2030年实际回款金额,_2030年应收未收金额,_2030年到期应收未收金额,_2030年实际回款时间,推迟收款时间,实际竣工时间,竣工与实际收款时间差异,移动交付,电信交付,联通交付,铁塔交付,运营商合同签订日期,运营商交付单与租赁合同时间差,移动实际付款时间,电信实际付款时间,联通实际付款时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Health_Xs ");
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
			strSql.Append("select id,区域,客户名称,站点名称,站点编码,回款期限,租金金额,基站销售款,累计应收金额,税率,伟通收入不含税,_2016年开票时间,_2016年开票金额,_2016年合同收款时间,_2016年合同收款金额,_2016年实际回款金额,_2016年应收未收金额,_2016年到期应收未收金额,_2016年实际回款时间,_2017年开票时间,_2017年开票金额,_2017年合同收款时间,_2017年合同收款金额,_2017年实际回款金额,_2017年应收未收金额,_2017年到期应收未收金额,_2017年实际回款时间,_2018年开票时间,_2018年开票金额,_2018年合同收款时间,_2018年合同收款金额,_2018年实际回款金额,_2018年应收未收金额,_2018年到期应收未收金额,_2018年实际回款时间,_2019年开票时间,_2019年开票金额,_2019年合同收款时间,_2019年合同收款金额,_2019年实际回款金额,_2019年应收未收金额,_2019年到期应收未收金额,_2019年实际回款时间,_2020年开票时间,_2020年开票金额,_2020年合同收款时间,_2020年合同收款金额,_2020年实际回款金额,_2020年应收未收金额,_2020年到期应收未收金额,_2020年实际回款时间,_2021年开票时间,_2021年开票金额,_2021年合同收款时间,_2021年合同收款金额,_2021年实际回款金额,_2021年应收未收金额,_2021年到期应收未收金额,_2021年实际回款时间,_2022年开票时间,_2022年开票金额,_2022年合同收款时间,_2022年合同收款金额,_2022年实际回款金额,_2022年应收未收金额,_2022年到期应收未收金额,_2022年实际回款时间,_2023年开票时间,_2023年开票金额,_2023年合同收款时间,_2023年合同收款金额,_2023年实际回款金额,_2023年应收未收金额,_2023年到期应收未收金额,_2023年实际回款时间,_2024年开票时间,_2024年开票金额,_2024年合同收款时间,_2024年合同收款金额,_2024年实际回款金额,_2024年应收未收金额,_2024年到期应收未收金额,_2024年实际回款时间,_2025年开票时间,_2025年开票金额,_2025年合同收款时间,_2025年合同收款金额,_2025年实际回款金额,_2025年应收未收金额,_2025年到期应收未收金额,_2025年实际回款时间,_2026年开票时间,_2026年开票金额,_2026年合同收款时间,_2026年合同收款金额,_2026年实际回款金额,_2026年应收未收金额,_2026年到期应收未收金额,_2026年实际回款时间,_2027年开票时间,_2027年开票金额,_2027年合同收款时间,_2027年合同收款金额,_2027年实际回款金额,_2027年应收未收金额,_2027年到期应收未收金额,_2027年实际回款时间,_2028年开票时间,_2028年开票金额,_2028年合同收款时间,_2028年合同收款金额,_2028年实际回款金额,_2028年应收未收金额,_2028年到期应收未收金额,_2028年实际回款时间,_2029年开票时间,_2029年开票金额,_2029年合同收款时间,_2029年合同收款金额,_2029年实际回款金额,_2029年应收未收金额,_2029年到期应收未收金额,_2029年实际回款时间,_2030年开票时间,_2030年开票金额,_2030年合同收款时间,_2030年合同收款金额,_2030年实际回款金额,_2030年应收未收金额,_2030年到期应收未收金额,_2030年实际回款时间,推迟收款时间,实际竣工时间,竣工与实际收款时间差异,移动交付,电信交付,联通交付,铁塔交付,运营商合同签订日期,运营商交付单与租赁合同时间差,移动实际付款时间,电信实际付款时间,联通实际付款时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Health_Xs ");
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
			strSql.Append("select count(1) FROM Health_Xs ");
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
			strSql.Append(")AS Row, T.*  from Health_Xs T ");
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
			parameters[0].Value = "Health_Xs";
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


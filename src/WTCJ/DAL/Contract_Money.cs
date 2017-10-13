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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WTCJ.DBUtility;//Please add references
namespace WTCJ.DAL
{
	/// <summary>
	/// 数据访问类:Contract_Money
	/// </summary>
	public partial class Contract_Money
	{
		public Contract_Money()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Contract_Money");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.Contract_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Contract_Money(");
			strSql.Append("id,区域,类别,客户名称,站点编码,站点名称,销售合同第一年回款日期,合同签订时间建设合同,合同签订时间买卖合同,合同签订时间维护合同,运营商收入信息年限,运营商收入信息含税租金,运营商收入信息合同金额,运营商收入信息不含税租金,运营商收入信息不含税总额,运营商收入信息税率,运营商收入信息税额,运营商收入信息生效时间,运营商收入信息到期时间,运营商收入信息签订时间,运营商收入信息签订方,运营商收入信息合同编码,运营商收入信息项目区域,运营商收入信息合同内容,运营商收入信息合同付款方式条例,预估运营商收入,运营商收入差额,伟通预估收入,伟通第一年应收销售款,差额对比收入,差额对比成本,运营商开票及回款开票时间,运营商开票及回款开票金额,运营商开票及回款回款时间,运营商开票及回款回款金额,伟通开票及回款开票时间,伟通开票及回款开票金额,伟通开票及回款回款时间,伟通开票及回款已回款金额,伟通开票及回款未回款金额,运营商合同收款账号,运营商合同收款账号账号开户行,销售共管账号,销售共管账号账号开户行,建设验收单签订时间,销售验收单签订时间,运营商验收交付单确认时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@区域,@类别,@客户名称,@站点编码,@站点名称,@销售合同第一年回款日期,@合同签订时间建设合同,@合同签订时间买卖合同,@合同签订时间维护合同,@运营商收入信息年限,@运营商收入信息含税租金,@运营商收入信息合同金额,@运营商收入信息不含税租金,@运营商收入信息不含税总额,@运营商收入信息税率,@运营商收入信息税额,@运营商收入信息生效时间,@运营商收入信息到期时间,@运营商收入信息签订时间,@运营商收入信息签订方,@运营商收入信息合同编码,@运营商收入信息项目区域,@运营商收入信息合同内容,@运营商收入信息合同付款方式条例,@预估运营商收入,@运营商收入差额,@伟通预估收入,@伟通第一年应收销售款,@差额对比收入,@差额对比成本,@运营商开票及回款开票时间,@运营商开票及回款开票金额,@运营商开票及回款回款时间,@运营商开票及回款回款金额,@伟通开票及回款开票时间,@伟通开票及回款开票金额,@伟通开票及回款回款时间,@伟通开票及回款已回款金额,@伟通开票及回款未回款金额,@运营商合同收款账号,@运营商合同收款账号账号开户行,@销售共管账号,@销售共管账号账号开户行,@建设验收单签订时间,@销售验收单签订时间,@运营商验收交付单确认时间,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@销售合同第一年回款日期", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间建设合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间买卖合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间维护合同", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息年限", SqlDbType.Int,4),
					new SqlParameter("@运营商收入信息含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息合同金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税总额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税率", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息生效时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息到期时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订方", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同编码", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息项目区域", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同内容", SqlDbType.VarChar,4000),
					new SqlParameter("@运营商收入信息合同付款方式条例", SqlDbType.VarChar,200),
					new SqlParameter("@预估运营商收入", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入差额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通预估收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通第一年应收销售款", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比收入", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比成本", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款已回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款未回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商合同收款账号", SqlDbType.VarChar,200),
					new SqlParameter("@运营商合同收款账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@建设验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@销售验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付单确认时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.区域;
			parameters[2].Value = model.类别;
			parameters[3].Value = model.客户名称;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.站点名称;
			parameters[6].Value = model.销售合同第一年回款日期;
			parameters[7].Value = model.合同签订时间建设合同;
			parameters[8].Value = model.合同签订时间买卖合同;
			parameters[9].Value = model.合同签订时间维护合同;
			parameters[10].Value = model.运营商收入信息年限;
			parameters[11].Value = model.运营商收入信息含税租金;
			parameters[12].Value = model.运营商收入信息合同金额;
			parameters[13].Value = model.运营商收入信息不含税租金;
			parameters[14].Value = model.运营商收入信息不含税总额;
			parameters[15].Value = model.运营商收入信息税率;
			parameters[16].Value = model.运营商收入信息税额;
			parameters[17].Value = model.运营商收入信息生效时间;
			parameters[18].Value = model.运营商收入信息到期时间;
			parameters[19].Value = model.运营商收入信息签订时间;
			parameters[20].Value = model.运营商收入信息签订方;
			parameters[21].Value = model.运营商收入信息合同编码;
			parameters[22].Value = model.运营商收入信息项目区域;
			parameters[23].Value = model.运营商收入信息合同内容;
			parameters[24].Value = model.运营商收入信息合同付款方式条例;
			parameters[25].Value = model.预估运营商收入;
			parameters[26].Value = model.运营商收入差额;
			parameters[27].Value = model.伟通预估收入;
			parameters[28].Value = model.伟通第一年应收销售款;
			parameters[29].Value = model.差额对比收入;
			parameters[30].Value = model.差额对比成本;
			parameters[31].Value = model.运营商开票及回款开票时间;
			parameters[32].Value = model.运营商开票及回款开票金额;
			parameters[33].Value = model.运营商开票及回款回款时间;
			parameters[34].Value = model.运营商开票及回款回款金额;
			parameters[35].Value = model.伟通开票及回款开票时间;
			parameters[36].Value = model.伟通开票及回款开票金额;
			parameters[37].Value = model.伟通开票及回款回款时间;
			parameters[38].Value = model.伟通开票及回款已回款金额;
			parameters[39].Value = model.伟通开票及回款未回款金额;
			parameters[40].Value = model.运营商合同收款账号;
			parameters[41].Value = model.运营商合同收款账号账号开户行;
			parameters[42].Value = model.销售共管账号;
			parameters[43].Value = model.销售共管账号账号开户行;
			parameters[44].Value = model.建设验收单签订时间;
			parameters[45].Value = model.销售验收单签订时间;
			parameters[46].Value = model.运营商验收交付单确认时间;
			parameters[47].Value = model.备注;
			parameters[48].Value = model.IsDeleted;
			parameters[49].Value = model.CreateBy;
			parameters[50].Value = model.CreateTime;
			parameters[51].Value = model.UpdateBy;
			parameters[52].Value = model.UpdateTime;

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
		public bool Add(SqlTransaction tran,WTCJ.Model.Contract_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Contract_Money(");
			strSql.Append("id,区域,类别,客户名称,站点编码,站点名称,销售合同第一年回款日期,合同签订时间建设合同,合同签订时间买卖合同,合同签订时间维护合同,运营商收入信息年限,运营商收入信息含税租金,运营商收入信息合同金额,运营商收入信息不含税租金,运营商收入信息不含税总额,运营商收入信息税率,运营商收入信息税额,运营商收入信息生效时间,运营商收入信息到期时间,运营商收入信息签订时间,运营商收入信息签订方,运营商收入信息合同编码,运营商收入信息项目区域,运营商收入信息合同内容,运营商收入信息合同付款方式条例,预估运营商收入,运营商收入差额,伟通预估收入,伟通第一年应收销售款,差额对比收入,差额对比成本,运营商开票及回款开票时间,运营商开票及回款开票金额,运营商开票及回款回款时间,运营商开票及回款回款金额,伟通开票及回款开票时间,伟通开票及回款开票金额,伟通开票及回款回款时间,伟通开票及回款已回款金额,伟通开票及回款未回款金额,运营商合同收款账号,运营商合同收款账号账号开户行,销售共管账号,销售共管账号账号开户行,建设验收单签订时间,销售验收单签订时间,运营商验收交付单确认时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@id,@区域,@类别,@客户名称,@站点编码,@站点名称,@销售合同第一年回款日期,@合同签订时间建设合同,@合同签订时间买卖合同,@合同签订时间维护合同,@运营商收入信息年限,@运营商收入信息含税租金,@运营商收入信息合同金额,@运营商收入信息不含税租金,@运营商收入信息不含税总额,@运营商收入信息税率,@运营商收入信息税额,@运营商收入信息生效时间,@运营商收入信息到期时间,@运营商收入信息签订时间,@运营商收入信息签订方,@运营商收入信息合同编码,@运营商收入信息项目区域,@运营商收入信息合同内容,@运营商收入信息合同付款方式条例,@预估运营商收入,@运营商收入差额,@伟通预估收入,@伟通第一年应收销售款,@差额对比收入,@差额对比成本,@运营商开票及回款开票时间,@运营商开票及回款开票金额,@运营商开票及回款回款时间,@运营商开票及回款回款金额,@伟通开票及回款开票时间,@伟通开票及回款开票金额,@伟通开票及回款回款时间,@伟通开票及回款已回款金额,@伟通开票及回款未回款金额,@运营商合同收款账号,@运营商合同收款账号账号开户行,@销售共管账号,@销售共管账号账号开户行,@建设验收单签订时间,@销售验收单签订时间,@运营商验收交付单确认时间,@备注,@IsDeleted,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@销售合同第一年回款日期", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间建设合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间买卖合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间维护合同", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息年限", SqlDbType.Int,4),
					new SqlParameter("@运营商收入信息含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息合同金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税总额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税率", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息生效时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息到期时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订方", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同编码", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息项目区域", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同内容", SqlDbType.VarChar,4000),
					new SqlParameter("@运营商收入信息合同付款方式条例", SqlDbType.VarChar,200),
					new SqlParameter("@预估运营商收入", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入差额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通预估收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通第一年应收销售款", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比收入", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比成本", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款已回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款未回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商合同收款账号", SqlDbType.VarChar,200),
					new SqlParameter("@运营商合同收款账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@建设验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@销售验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付单确认时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.区域;
			parameters[2].Value = model.类别;
			parameters[3].Value = model.客户名称;
			parameters[4].Value = model.站点编码;
			parameters[5].Value = model.站点名称;
			parameters[6].Value = model.销售合同第一年回款日期;
			parameters[7].Value = model.合同签订时间建设合同;
			parameters[8].Value = model.合同签订时间买卖合同;
			parameters[9].Value = model.合同签订时间维护合同;
			parameters[10].Value = model.运营商收入信息年限;
			parameters[11].Value = model.运营商收入信息含税租金;
			parameters[12].Value = model.运营商收入信息合同金额;
			parameters[13].Value = model.运营商收入信息不含税租金;
			parameters[14].Value = model.运营商收入信息不含税总额;
			parameters[15].Value = model.运营商收入信息税率;
			parameters[16].Value = model.运营商收入信息税额;
			parameters[17].Value = model.运营商收入信息生效时间;
			parameters[18].Value = model.运营商收入信息到期时间;
			parameters[19].Value = model.运营商收入信息签订时间;
			parameters[20].Value = model.运营商收入信息签订方;
			parameters[21].Value = model.运营商收入信息合同编码;
			parameters[22].Value = model.运营商收入信息项目区域;
			parameters[23].Value = model.运营商收入信息合同内容;
			parameters[24].Value = model.运营商收入信息合同付款方式条例;
			parameters[25].Value = model.预估运营商收入;
			parameters[26].Value = model.运营商收入差额;
			parameters[27].Value = model.伟通预估收入;
			parameters[28].Value = model.伟通第一年应收销售款;
			parameters[29].Value = model.差额对比收入;
			parameters[30].Value = model.差额对比成本;
			parameters[31].Value = model.运营商开票及回款开票时间;
			parameters[32].Value = model.运营商开票及回款开票金额;
			parameters[33].Value = model.运营商开票及回款回款时间;
			parameters[34].Value = model.运营商开票及回款回款金额;
			parameters[35].Value = model.伟通开票及回款开票时间;
			parameters[36].Value = model.伟通开票及回款开票金额;
			parameters[37].Value = model.伟通开票及回款回款时间;
			parameters[38].Value = model.伟通开票及回款已回款金额;
			parameters[39].Value = model.伟通开票及回款未回款金额;
			parameters[40].Value = model.运营商合同收款账号;
			parameters[41].Value = model.运营商合同收款账号账号开户行;
			parameters[42].Value = model.销售共管账号;
			parameters[43].Value = model.销售共管账号账号开户行;
			parameters[44].Value = model.建设验收单签订时间;
			parameters[45].Value = model.销售验收单签订时间;
			parameters[46].Value = model.运营商验收交付单确认时间;
			parameters[47].Value = model.备注;
			parameters[48].Value = model.IsDeleted;
			parameters[49].Value = model.CreateBy;
			parameters[50].Value = model.CreateTime;
			parameters[51].Value = model.UpdateBy;
			parameters[52].Value = model.UpdateTime;

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
		public bool Update(WTCJ.Model.Contract_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Contract_Money set ");
			strSql.Append("区域=@区域,");
			strSql.Append("类别=@类别,");
			strSql.Append("客户名称=@客户名称,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("销售合同第一年回款日期=@销售合同第一年回款日期,");
			strSql.Append("合同签订时间建设合同=@合同签订时间建设合同,");
			strSql.Append("合同签订时间买卖合同=@合同签订时间买卖合同,");
			strSql.Append("合同签订时间维护合同=@合同签订时间维护合同,");
			strSql.Append("运营商收入信息年限=@运营商收入信息年限,");
			strSql.Append("运营商收入信息含税租金=@运营商收入信息含税租金,");
			strSql.Append("运营商收入信息合同金额=@运营商收入信息合同金额,");
			strSql.Append("运营商收入信息不含税租金=@运营商收入信息不含税租金,");
			strSql.Append("运营商收入信息不含税总额=@运营商收入信息不含税总额,");
			strSql.Append("运营商收入信息税率=@运营商收入信息税率,");
			strSql.Append("运营商收入信息税额=@运营商收入信息税额,");
			strSql.Append("运营商收入信息生效时间=@运营商收入信息生效时间,");
			strSql.Append("运营商收入信息到期时间=@运营商收入信息到期时间,");
			strSql.Append("运营商收入信息签订时间=@运营商收入信息签订时间,");
			strSql.Append("运营商收入信息签订方=@运营商收入信息签订方,");
			strSql.Append("运营商收入信息合同编码=@运营商收入信息合同编码,");
			strSql.Append("运营商收入信息项目区域=@运营商收入信息项目区域,");
			strSql.Append("运营商收入信息合同内容=@运营商收入信息合同内容,");
			strSql.Append("运营商收入信息合同付款方式条例=@运营商收入信息合同付款方式条例,");
			strSql.Append("预估运营商收入=@预估运营商收入,");
			strSql.Append("运营商收入差额=@运营商收入差额,");
			strSql.Append("伟通预估收入=@伟通预估收入,");
			strSql.Append("伟通第一年应收销售款=@伟通第一年应收销售款,");
			strSql.Append("差额对比收入=@差额对比收入,");
			strSql.Append("差额对比成本=@差额对比成本,");
			strSql.Append("运营商开票及回款开票时间=@运营商开票及回款开票时间,");
			strSql.Append("运营商开票及回款开票金额=@运营商开票及回款开票金额,");
			strSql.Append("运营商开票及回款回款时间=@运营商开票及回款回款时间,");
			strSql.Append("运营商开票及回款回款金额=@运营商开票及回款回款金额,");
			strSql.Append("伟通开票及回款开票时间=@伟通开票及回款开票时间,");
			strSql.Append("伟通开票及回款开票金额=@伟通开票及回款开票金额,");
			strSql.Append("伟通开票及回款回款时间=@伟通开票及回款回款时间,");
			strSql.Append("伟通开票及回款已回款金额=@伟通开票及回款已回款金额,");
			strSql.Append("伟通开票及回款未回款金额=@伟通开票及回款未回款金额,");
			strSql.Append("运营商合同收款账号=@运营商合同收款账号,");
			strSql.Append("运营商合同收款账号账号开户行=@运营商合同收款账号账号开户行,");
			strSql.Append("销售共管账号=@销售共管账号,");
			strSql.Append("销售共管账号账号开户行=@销售共管账号账号开户行,");
			strSql.Append("建设验收单签订时间=@建设验收单签订时间,");
			strSql.Append("销售验收单签订时间=@销售验收单签订时间,");
			strSql.Append("运营商验收交付单确认时间=@运营商验收交付单确认时间,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@销售合同第一年回款日期", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间建设合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间买卖合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间维护合同", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息年限", SqlDbType.Int,4),
					new SqlParameter("@运营商收入信息含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息合同金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税总额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税率", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息生效时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息到期时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订方", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同编码", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息项目区域", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同内容", SqlDbType.VarChar,4000),
					new SqlParameter("@运营商收入信息合同付款方式条例", SqlDbType.VarChar,200),
					new SqlParameter("@预估运营商收入", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入差额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通预估收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通第一年应收销售款", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比收入", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比成本", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款已回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款未回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商合同收款账号", SqlDbType.VarChar,200),
					new SqlParameter("@运营商合同收款账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@建设验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@销售验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付单确认时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,50)};
			parameters[0].Value = model.区域;
			parameters[1].Value = model.类别;
			parameters[2].Value = model.客户名称;
			parameters[3].Value = model.站点编码;
			parameters[4].Value = model.站点名称;
			parameters[5].Value = model.销售合同第一年回款日期;
			parameters[6].Value = model.合同签订时间建设合同;
			parameters[7].Value = model.合同签订时间买卖合同;
			parameters[8].Value = model.合同签订时间维护合同;
			parameters[9].Value = model.运营商收入信息年限;
			parameters[10].Value = model.运营商收入信息含税租金;
			parameters[11].Value = model.运营商收入信息合同金额;
			parameters[12].Value = model.运营商收入信息不含税租金;
			parameters[13].Value = model.运营商收入信息不含税总额;
			parameters[14].Value = model.运营商收入信息税率;
			parameters[15].Value = model.运营商收入信息税额;
			parameters[16].Value = model.运营商收入信息生效时间;
			parameters[17].Value = model.运营商收入信息到期时间;
			parameters[18].Value = model.运营商收入信息签订时间;
			parameters[19].Value = model.运营商收入信息签订方;
			parameters[20].Value = model.运营商收入信息合同编码;
			parameters[21].Value = model.运营商收入信息项目区域;
			parameters[22].Value = model.运营商收入信息合同内容;
			parameters[23].Value = model.运营商收入信息合同付款方式条例;
			parameters[24].Value = model.预估运营商收入;
			parameters[25].Value = model.运营商收入差额;
			parameters[26].Value = model.伟通预估收入;
			parameters[27].Value = model.伟通第一年应收销售款;
			parameters[28].Value = model.差额对比收入;
			parameters[29].Value = model.差额对比成本;
			parameters[30].Value = model.运营商开票及回款开票时间;
			parameters[31].Value = model.运营商开票及回款开票金额;
			parameters[32].Value = model.运营商开票及回款回款时间;
			parameters[33].Value = model.运营商开票及回款回款金额;
			parameters[34].Value = model.伟通开票及回款开票时间;
			parameters[35].Value = model.伟通开票及回款开票金额;
			parameters[36].Value = model.伟通开票及回款回款时间;
			parameters[37].Value = model.伟通开票及回款已回款金额;
			parameters[38].Value = model.伟通开票及回款未回款金额;
			parameters[39].Value = model.运营商合同收款账号;
			parameters[40].Value = model.运营商合同收款账号账号开户行;
			parameters[41].Value = model.销售共管账号;
			parameters[42].Value = model.销售共管账号账号开户行;
			parameters[43].Value = model.建设验收单签订时间;
			parameters[44].Value = model.销售验收单签订时间;
			parameters[45].Value = model.运营商验收交付单确认时间;
			parameters[46].Value = model.备注;
			parameters[47].Value = model.IsDeleted;
			parameters[48].Value = model.CreateBy;
			parameters[49].Value = model.CreateTime;
			parameters[50].Value = model.UpdateBy;
			parameters[51].Value = model.UpdateTime;
			parameters[52].Value = model.id;

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
		public bool Update(SqlTransaction tran,WTCJ.Model.Contract_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Contract_Money set ");
			strSql.Append("区域=@区域,");
			strSql.Append("类别=@类别,");
			strSql.Append("客户名称=@客户名称,");
			strSql.Append("站点编码=@站点编码,");
			strSql.Append("站点名称=@站点名称,");
			strSql.Append("销售合同第一年回款日期=@销售合同第一年回款日期,");
			strSql.Append("合同签订时间建设合同=@合同签订时间建设合同,");
			strSql.Append("合同签订时间买卖合同=@合同签订时间买卖合同,");
			strSql.Append("合同签订时间维护合同=@合同签订时间维护合同,");
			strSql.Append("运营商收入信息年限=@运营商收入信息年限,");
			strSql.Append("运营商收入信息含税租金=@运营商收入信息含税租金,");
			strSql.Append("运营商收入信息合同金额=@运营商收入信息合同金额,");
			strSql.Append("运营商收入信息不含税租金=@运营商收入信息不含税租金,");
			strSql.Append("运营商收入信息不含税总额=@运营商收入信息不含税总额,");
			strSql.Append("运营商收入信息税率=@运营商收入信息税率,");
			strSql.Append("运营商收入信息税额=@运营商收入信息税额,");
			strSql.Append("运营商收入信息生效时间=@运营商收入信息生效时间,");
			strSql.Append("运营商收入信息到期时间=@运营商收入信息到期时间,");
			strSql.Append("运营商收入信息签订时间=@运营商收入信息签订时间,");
			strSql.Append("运营商收入信息签订方=@运营商收入信息签订方,");
			strSql.Append("运营商收入信息合同编码=@运营商收入信息合同编码,");
			strSql.Append("运营商收入信息项目区域=@运营商收入信息项目区域,");
			strSql.Append("运营商收入信息合同内容=@运营商收入信息合同内容,");
			strSql.Append("运营商收入信息合同付款方式条例=@运营商收入信息合同付款方式条例,");
			strSql.Append("预估运营商收入=@预估运营商收入,");
			strSql.Append("运营商收入差额=@运营商收入差额,");
			strSql.Append("伟通预估收入=@伟通预估收入,");
			strSql.Append("伟通第一年应收销售款=@伟通第一年应收销售款,");
			strSql.Append("差额对比收入=@差额对比收入,");
			strSql.Append("差额对比成本=@差额对比成本,");
			strSql.Append("运营商开票及回款开票时间=@运营商开票及回款开票时间,");
			strSql.Append("运营商开票及回款开票金额=@运营商开票及回款开票金额,");
			strSql.Append("运营商开票及回款回款时间=@运营商开票及回款回款时间,");
			strSql.Append("运营商开票及回款回款金额=@运营商开票及回款回款金额,");
			strSql.Append("伟通开票及回款开票时间=@伟通开票及回款开票时间,");
			strSql.Append("伟通开票及回款开票金额=@伟通开票及回款开票金额,");
			strSql.Append("伟通开票及回款回款时间=@伟通开票及回款回款时间,");
			strSql.Append("伟通开票及回款已回款金额=@伟通开票及回款已回款金额,");
			strSql.Append("伟通开票及回款未回款金额=@伟通开票及回款未回款金额,");
			strSql.Append("运营商合同收款账号=@运营商合同收款账号,");
			strSql.Append("运营商合同收款账号账号开户行=@运营商合同收款账号账号开户行,");
			strSql.Append("销售共管账号=@销售共管账号,");
			strSql.Append("销售共管账号账号开户行=@销售共管账号账号开户行,");
			strSql.Append("建设验收单签订时间=@建设验收单签订时间,");
			strSql.Append("销售验收单签订时间=@销售验收单签订时间,");
			strSql.Append("运营商验收交付单确认时间=@运营商验收交付单确认时间,");
			strSql.Append("备注=@备注,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@区域", SqlDbType.VarChar,36),
					new SqlParameter("@类别", SqlDbType.VarChar,50),
					new SqlParameter("@客户名称", SqlDbType.VarChar,36),
					new SqlParameter("@站点编码", SqlDbType.VarChar,200),
					new SqlParameter("@站点名称", SqlDbType.VarChar,200),
					new SqlParameter("@销售合同第一年回款日期", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间建设合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间买卖合同", SqlDbType.DateTime),
					new SqlParameter("@合同签订时间维护合同", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息年限", SqlDbType.Int,4),
					new SqlParameter("@运营商收入信息含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息合同金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税租金", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息不含税总额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税率", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息税额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入信息生效时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息到期时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商收入信息签订方", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同编码", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息项目区域", SqlDbType.VarChar,200),
					new SqlParameter("@运营商收入信息合同内容", SqlDbType.VarChar,4000),
					new SqlParameter("@运营商收入信息合同付款方式条例", SqlDbType.VarChar,200),
					new SqlParameter("@预估运营商收入", SqlDbType.Decimal,9),
					new SqlParameter("@运营商收入差额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通预估收入", SqlDbType.Decimal,9),
					new SqlParameter("@伟通第一年应收销售款", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比收入", SqlDbType.Decimal,9),
					new SqlParameter("@差额对比成本", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@运营商开票及回款回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款开票时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款开票金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款回款时间", SqlDbType.DateTime),
					new SqlParameter("@伟通开票及回款已回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@伟通开票及回款未回款金额", SqlDbType.Decimal,9),
					new SqlParameter("@运营商合同收款账号", SqlDbType.VarChar,200),
					new SqlParameter("@运营商合同收款账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号", SqlDbType.VarChar,200),
					new SqlParameter("@销售共管账号账号开户行", SqlDbType.VarChar,200),
					new SqlParameter("@建设验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@销售验收单签订时间", SqlDbType.DateTime),
					new SqlParameter("@运营商验收交付单确认时间", SqlDbType.DateTime),
					new SqlParameter("@备注", SqlDbType.VarChar,500),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.VarChar,50)};
			parameters[0].Value = model.区域;
			parameters[1].Value = model.类别;
			parameters[2].Value = model.客户名称;
			parameters[3].Value = model.站点编码;
			parameters[4].Value = model.站点名称;
			parameters[5].Value = model.销售合同第一年回款日期;
			parameters[6].Value = model.合同签订时间建设合同;
			parameters[7].Value = model.合同签订时间买卖合同;
			parameters[8].Value = model.合同签订时间维护合同;
			parameters[9].Value = model.运营商收入信息年限;
			parameters[10].Value = model.运营商收入信息含税租金;
			parameters[11].Value = model.运营商收入信息合同金额;
			parameters[12].Value = model.运营商收入信息不含税租金;
			parameters[13].Value = model.运营商收入信息不含税总额;
			parameters[14].Value = model.运营商收入信息税率;
			parameters[15].Value = model.运营商收入信息税额;
			parameters[16].Value = model.运营商收入信息生效时间;
			parameters[17].Value = model.运营商收入信息到期时间;
			parameters[18].Value = model.运营商收入信息签订时间;
			parameters[19].Value = model.运营商收入信息签订方;
			parameters[20].Value = model.运营商收入信息合同编码;
			parameters[21].Value = model.运营商收入信息项目区域;
			parameters[22].Value = model.运营商收入信息合同内容;
			parameters[23].Value = model.运营商收入信息合同付款方式条例;
			parameters[24].Value = model.预估运营商收入;
			parameters[25].Value = model.运营商收入差额;
			parameters[26].Value = model.伟通预估收入;
			parameters[27].Value = model.伟通第一年应收销售款;
			parameters[28].Value = model.差额对比收入;
			parameters[29].Value = model.差额对比成本;
			parameters[30].Value = model.运营商开票及回款开票时间;
			parameters[31].Value = model.运营商开票及回款开票金额;
			parameters[32].Value = model.运营商开票及回款回款时间;
			parameters[33].Value = model.运营商开票及回款回款金额;
			parameters[34].Value = model.伟通开票及回款开票时间;
			parameters[35].Value = model.伟通开票及回款开票金额;
			parameters[36].Value = model.伟通开票及回款回款时间;
			parameters[37].Value = model.伟通开票及回款已回款金额;
			parameters[38].Value = model.伟通开票及回款未回款金额;
			parameters[39].Value = model.运营商合同收款账号;
			parameters[40].Value = model.运营商合同收款账号账号开户行;
			parameters[41].Value = model.销售共管账号;
			parameters[42].Value = model.销售共管账号账号开户行;
			parameters[43].Value = model.建设验收单签订时间;
			parameters[44].Value = model.销售验收单签订时间;
			parameters[45].Value = model.运营商验收交付单确认时间;
			parameters[46].Value = model.备注;
			parameters[47].Value = model.IsDeleted;
			parameters[48].Value = model.CreateBy;
			parameters[49].Value = model.CreateTime;
			parameters[50].Value = model.UpdateBy;
			parameters[51].Value = model.UpdateTime;
			parameters[52].Value = model.id;

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
			strSql.Append("delete from Contract_Money ");
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
			strSql.Append("delete from Contract_Money ");
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
		public WTCJ.Model.Contract_Money GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,区域,类别,客户名称,站点编码,站点名称,销售合同第一年回款日期,合同签订时间建设合同,合同签订时间买卖合同,合同签订时间维护合同,运营商收入信息年限,运营商收入信息含税租金,运营商收入信息合同金额,运营商收入信息不含税租金,运营商收入信息不含税总额,运营商收入信息税率,运营商收入信息税额,运营商收入信息生效时间,运营商收入信息到期时间,运营商收入信息签订时间,运营商收入信息签订方,运营商收入信息合同编码,运营商收入信息项目区域,运营商收入信息合同内容,运营商收入信息合同付款方式条例,预估运营商收入,运营商收入差额,伟通预估收入,伟通第一年应收销售款,差额对比收入,差额对比成本,运营商开票及回款开票时间,运营商开票及回款开票金额,运营商开票及回款回款时间,运营商开票及回款回款金额,伟通开票及回款开票时间,伟通开票及回款开票金额,伟通开票及回款回款时间,伟通开票及回款已回款金额,伟通开票及回款未回款金额,运营商合同收款账号,运营商合同收款账号账号开户行,销售共管账号,销售共管账号账号开户行,建设验收单签订时间,销售验收单签订时间,运营商验收交付单确认时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime from Contract_Money ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
			parameters[0].Value = id;

			WTCJ.Model.Contract_Money model=new WTCJ.Model.Contract_Money();
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
		public WTCJ.Model.Contract_Money DataRowToModel(DataRow row)
		{
			WTCJ.Model.Contract_Money model=new WTCJ.Model.Contract_Money();
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
				if(row["类别"]!=null)
				{
					model.类别=row["类别"].ToString();
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
				if(row["销售合同第一年回款日期"]!=null && row["销售合同第一年回款日期"].ToString()!="")
				{
					model.销售合同第一年回款日期=DateTime.Parse(row["销售合同第一年回款日期"].ToString());
				}
				if(row["合同签订时间建设合同"]!=null && row["合同签订时间建设合同"].ToString()!="")
				{
					model.合同签订时间建设合同=DateTime.Parse(row["合同签订时间建设合同"].ToString());
				}
				if(row["合同签订时间买卖合同"]!=null && row["合同签订时间买卖合同"].ToString()!="")
				{
					model.合同签订时间买卖合同=DateTime.Parse(row["合同签订时间买卖合同"].ToString());
				}
				if(row["合同签订时间维护合同"]!=null && row["合同签订时间维护合同"].ToString()!="")
				{
					model.合同签订时间维护合同=DateTime.Parse(row["合同签订时间维护合同"].ToString());
				}
				if(row["运营商收入信息年限"]!=null && row["运营商收入信息年限"].ToString()!="")
				{
					model.运营商收入信息年限=int.Parse(row["运营商收入信息年限"].ToString());
				}
				if(row["运营商收入信息含税租金"]!=null && row["运营商收入信息含税租金"].ToString()!="")
				{
					model.运营商收入信息含税租金=decimal.Parse(row["运营商收入信息含税租金"].ToString());
				}
				if(row["运营商收入信息合同金额"]!=null && row["运营商收入信息合同金额"].ToString()!="")
				{
					model.运营商收入信息合同金额=decimal.Parse(row["运营商收入信息合同金额"].ToString());
				}
				if(row["运营商收入信息不含税租金"]!=null && row["运营商收入信息不含税租金"].ToString()!="")
				{
					model.运营商收入信息不含税租金=decimal.Parse(row["运营商收入信息不含税租金"].ToString());
				}
				if(row["运营商收入信息不含税总额"]!=null && row["运营商收入信息不含税总额"].ToString()!="")
				{
					model.运营商收入信息不含税总额=decimal.Parse(row["运营商收入信息不含税总额"].ToString());
				}
				if(row["运营商收入信息税率"]!=null && row["运营商收入信息税率"].ToString()!="")
				{
					model.运营商收入信息税率=decimal.Parse(row["运营商收入信息税率"].ToString());
				}
				if(row["运营商收入信息税额"]!=null && row["运营商收入信息税额"].ToString()!="")
				{
					model.运营商收入信息税额=decimal.Parse(row["运营商收入信息税额"].ToString());
				}
				if(row["运营商收入信息生效时间"]!=null && row["运营商收入信息生效时间"].ToString()!="")
				{
					model.运营商收入信息生效时间=DateTime.Parse(row["运营商收入信息生效时间"].ToString());
				}
				if(row["运营商收入信息到期时间"]!=null && row["运营商收入信息到期时间"].ToString()!="")
				{
					model.运营商收入信息到期时间=DateTime.Parse(row["运营商收入信息到期时间"].ToString());
				}
				if(row["运营商收入信息签订时间"]!=null && row["运营商收入信息签订时间"].ToString()!="")
				{
					model.运营商收入信息签订时间=DateTime.Parse(row["运营商收入信息签订时间"].ToString());
				}
				if(row["运营商收入信息签订方"]!=null)
				{
					model.运营商收入信息签订方=row["运营商收入信息签订方"].ToString();
				}
				if(row["运营商收入信息合同编码"]!=null)
				{
					model.运营商收入信息合同编码=row["运营商收入信息合同编码"].ToString();
				}
				if(row["运营商收入信息项目区域"]!=null)
				{
					model.运营商收入信息项目区域=row["运营商收入信息项目区域"].ToString();
				}
				if(row["运营商收入信息合同内容"]!=null)
				{
					model.运营商收入信息合同内容=row["运营商收入信息合同内容"].ToString();
				}
				if(row["运营商收入信息合同付款方式条例"]!=null)
				{
					model.运营商收入信息合同付款方式条例=row["运营商收入信息合同付款方式条例"].ToString();
				}
				if(row["预估运营商收入"]!=null && row["预估运营商收入"].ToString()!="")
				{
					model.预估运营商收入=decimal.Parse(row["预估运营商收入"].ToString());
				}
				if(row["运营商收入差额"]!=null && row["运营商收入差额"].ToString()!="")
				{
					model.运营商收入差额=decimal.Parse(row["运营商收入差额"].ToString());
				}
				if(row["伟通预估收入"]!=null && row["伟通预估收入"].ToString()!="")
				{
					model.伟通预估收入=decimal.Parse(row["伟通预估收入"].ToString());
				}
				if(row["伟通第一年应收销售款"]!=null && row["伟通第一年应收销售款"].ToString()!="")
				{
					model.伟通第一年应收销售款=decimal.Parse(row["伟通第一年应收销售款"].ToString());
				}
				if(row["差额对比收入"]!=null && row["差额对比收入"].ToString()!="")
				{
					model.差额对比收入=decimal.Parse(row["差额对比收入"].ToString());
				}
				if(row["差额对比成本"]!=null && row["差额对比成本"].ToString()!="")
				{
					model.差额对比成本=decimal.Parse(row["差额对比成本"].ToString());
				}
				if(row["运营商开票及回款开票时间"]!=null && row["运营商开票及回款开票时间"].ToString()!="")
				{
					model.运营商开票及回款开票时间=DateTime.Parse(row["运营商开票及回款开票时间"].ToString());
				}
				if(row["运营商开票及回款开票金额"]!=null && row["运营商开票及回款开票金额"].ToString()!="")
				{
					model.运营商开票及回款开票金额=decimal.Parse(row["运营商开票及回款开票金额"].ToString());
				}
				if(row["运营商开票及回款回款时间"]!=null && row["运营商开票及回款回款时间"].ToString()!="")
				{
					model.运营商开票及回款回款时间=DateTime.Parse(row["运营商开票及回款回款时间"].ToString());
				}
				if(row["运营商开票及回款回款金额"]!=null && row["运营商开票及回款回款金额"].ToString()!="")
				{
					model.运营商开票及回款回款金额=decimal.Parse(row["运营商开票及回款回款金额"].ToString());
				}
				if(row["伟通开票及回款开票时间"]!=null && row["伟通开票及回款开票时间"].ToString()!="")
				{
					model.伟通开票及回款开票时间=DateTime.Parse(row["伟通开票及回款开票时间"].ToString());
				}
				if(row["伟通开票及回款开票金额"]!=null && row["伟通开票及回款开票金额"].ToString()!="")
				{
					model.伟通开票及回款开票金额=decimal.Parse(row["伟通开票及回款开票金额"].ToString());
				}
				if(row["伟通开票及回款回款时间"]!=null && row["伟通开票及回款回款时间"].ToString()!="")
				{
					model.伟通开票及回款回款时间=DateTime.Parse(row["伟通开票及回款回款时间"].ToString());
				}
				if(row["伟通开票及回款已回款金额"]!=null && row["伟通开票及回款已回款金额"].ToString()!="")
				{
					model.伟通开票及回款已回款金额=decimal.Parse(row["伟通开票及回款已回款金额"].ToString());
				}
				if(row["伟通开票及回款未回款金额"]!=null && row["伟通开票及回款未回款金额"].ToString()!="")
				{
					model.伟通开票及回款未回款金额=decimal.Parse(row["伟通开票及回款未回款金额"].ToString());
				}
				if(row["运营商合同收款账号"]!=null)
				{
					model.运营商合同收款账号=row["运营商合同收款账号"].ToString();
				}
				if(row["运营商合同收款账号账号开户行"]!=null)
				{
					model.运营商合同收款账号账号开户行=row["运营商合同收款账号账号开户行"].ToString();
				}
				if(row["销售共管账号"]!=null)
				{
					model.销售共管账号=row["销售共管账号"].ToString();
				}
				if(row["销售共管账号账号开户行"]!=null)
				{
					model.销售共管账号账号开户行=row["销售共管账号账号开户行"].ToString();
				}
				if(row["建设验收单签订时间"]!=null && row["建设验收单签订时间"].ToString()!="")
				{
					model.建设验收单签订时间=DateTime.Parse(row["建设验收单签订时间"].ToString());
				}
				if(row["销售验收单签订时间"]!=null && row["销售验收单签订时间"].ToString()!="")
				{
					model.销售验收单签订时间=DateTime.Parse(row["销售验收单签订时间"].ToString());
				}
				if(row["运营商验收交付单确认时间"]!=null && row["运营商验收交付单确认时间"].ToString()!="")
				{
					model.运营商验收交付单确认时间=DateTime.Parse(row["运营商验收交付单确认时间"].ToString());
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
			strSql.Append("select id,区域,类别,客户名称,站点编码,站点名称,销售合同第一年回款日期,合同签订时间建设合同,合同签订时间买卖合同,合同签订时间维护合同,运营商收入信息年限,运营商收入信息含税租金,运营商收入信息合同金额,运营商收入信息不含税租金,运营商收入信息不含税总额,运营商收入信息税率,运营商收入信息税额,运营商收入信息生效时间,运营商收入信息到期时间,运营商收入信息签订时间,运营商收入信息签订方,运营商收入信息合同编码,运营商收入信息项目区域,运营商收入信息合同内容,运营商收入信息合同付款方式条例,预估运营商收入,运营商收入差额,伟通预估收入,伟通第一年应收销售款,差额对比收入,差额对比成本,运营商开票及回款开票时间,运营商开票及回款开票金额,运营商开票及回款回款时间,运营商开票及回款回款金额,伟通开票及回款开票时间,伟通开票及回款开票金额,伟通开票及回款回款时间,伟通开票及回款已回款金额,伟通开票及回款未回款金额,运营商合同收款账号,运营商合同收款账号账号开户行,销售共管账号,销售共管账号账号开户行,建设验收单签订时间,销售验收单签订时间,运营商验收交付单确认时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Contract_Money ");
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
			strSql.Append(" id,区域,类别,客户名称,站点编码,站点名称,销售合同第一年回款日期,合同签订时间建设合同,合同签订时间买卖合同,合同签订时间维护合同,运营商收入信息年限,运营商收入信息含税租金,运营商收入信息合同金额,运营商收入信息不含税租金,运营商收入信息不含税总额,运营商收入信息税率,运营商收入信息税额,运营商收入信息生效时间,运营商收入信息到期时间,运营商收入信息签订时间,运营商收入信息签订方,运营商收入信息合同编码,运营商收入信息项目区域,运营商收入信息合同内容,运营商收入信息合同付款方式条例,预估运营商收入,运营商收入差额,伟通预估收入,伟通第一年应收销售款,差额对比收入,差额对比成本,运营商开票及回款开票时间,运营商开票及回款开票金额,运营商开票及回款回款时间,运营商开票及回款回款金额,伟通开票及回款开票时间,伟通开票及回款开票金额,伟通开票及回款回款时间,伟通开票及回款已回款金额,伟通开票及回款未回款金额,运营商合同收款账号,运营商合同收款账号账号开户行,销售共管账号,销售共管账号账号开户行,建设验收单签订时间,销售验收单签订时间,运营商验收交付单确认时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Contract_Money ");
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
			strSql.Append("select id,区域,类别,客户名称,站点编码,站点名称,销售合同第一年回款日期,合同签订时间建设合同,合同签订时间买卖合同,合同签订时间维护合同,运营商收入信息年限,运营商收入信息含税租金,运营商收入信息合同金额,运营商收入信息不含税租金,运营商收入信息不含税总额,运营商收入信息税率,运营商收入信息税额,运营商收入信息生效时间,运营商收入信息到期时间,运营商收入信息签订时间,运营商收入信息签订方,运营商收入信息合同编码,运营商收入信息项目区域,运营商收入信息合同内容,运营商收入信息合同付款方式条例,预估运营商收入,运营商收入差额,伟通预估收入,伟通第一年应收销售款,差额对比收入,差额对比成本,运营商开票及回款开票时间,运营商开票及回款开票金额,运营商开票及回款回款时间,运营商开票及回款回款金额,伟通开票及回款开票时间,伟通开票及回款开票金额,伟通开票及回款回款时间,伟通开票及回款已回款金额,伟通开票及回款未回款金额,运营商合同收款账号,运营商合同收款账号账号开户行,销售共管账号,销售共管账号账号开户行,建设验收单签订时间,销售验收单签订时间,运营商验收交付单确认时间,备注,IsDeleted,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Contract_Money ");
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
			strSql.Append("select count(1) FROM Contract_Money ");
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
			strSql.Append(")AS Row, T.*  from Contract_Money T ");
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
			parameters[0].Value = "Contract_Money";
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


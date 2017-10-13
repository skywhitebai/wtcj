/**  版本信息模板在安装目录下，可自行修改。
* Customer.cs
*
* 功 能： N/A
* 类 名： Customer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/6/20 11:48:24   N/A    初版
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
	/// 数据访问类:Customer
	/// </summary>
	public partial class Customer
	{
		public Customer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CustomerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Customer");
			strSql.Append(" where CustomerID=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)			};
			parameters[0].Value = CustomerID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Customer(");
			strSql.Append("CustomerID,CustomerName,Linkman,Telephone,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@CustomerID,@CustomerName,@Linkman,@Telephone,@OrderBy,@Remark,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,200),
					new SqlParameter("@Linkman", SqlDbType.VarChar,50),
					new SqlParameter("@Telephone", SqlDbType.VarChar,50),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.CustomerID;
			parameters[1].Value = model.CustomerName;
			parameters[2].Value = model.Linkman;
			parameters[3].Value = model.Telephone;
			parameters[4].Value = model.OrderBy;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.CreateBy;
			parameters[7].Value = model.CreateTime;
			parameters[8].Value = model.UpdateBy;
			parameters[9].Value = model.UpdateTime;

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
		public bool Update(WTCJ.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Customer set ");
			strSql.Append("CustomerName=@CustomerName,");
			strSql.Append("Linkman=@Linkman,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("OrderBy=@OrderBy,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where CustomerID=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.VarChar,200),
					new SqlParameter("@Linkman", SqlDbType.VarChar,50),
					new SqlParameter("@Telephone", SqlDbType.VarChar,50),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.CustomerName;
			parameters[1].Value = model.Linkman;
			parameters[2].Value = model.Telephone;
			parameters[3].Value = model.OrderBy;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.UpdateBy;
			parameters[8].Value = model.UpdateTime;
			parameters[9].Value = model.CustomerID;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CustomerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Customer ");
			strSql.Append(" where CustomerID=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)			};
			parameters[0].Value = CustomerID;

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
		public bool DeleteList(string CustomerIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Customer ");
			strSql.Append(" where CustomerID in ("+CustomerIDlist + ")  ");
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
		public WTCJ.Model.Customer GetModel(string CustomerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CustomerID,CustomerName,Linkman,Telephone,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime from Customer ");
			strSql.Append(" where CustomerID=@CustomerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)			};
			parameters[0].Value = CustomerID;

			WTCJ.Model.Customer model=new WTCJ.Model.Customer();
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
		public WTCJ.Model.Customer DataRowToModel(DataRow row)
		{
			WTCJ.Model.Customer model=new WTCJ.Model.Customer();
			if (row != null)
			{
				if(row["CustomerID"]!=null)
				{
					model.CustomerID=row["CustomerID"].ToString();
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
				}
				if(row["Linkman"]!=null)
				{
					model.Linkman=row["Linkman"].ToString();
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["OrderBy"]!=null && row["OrderBy"].ToString()!="")
				{
					model.OrderBy=int.Parse(row["OrderBy"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select CustomerID,CustomerName,Linkman,Telephone,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Customer ");
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
			strSql.Append(" CustomerID,CustomerName,Linkman,Telephone,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Customer ");
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
				strSql.Append("order by T.CustomerID desc");
			}
			strSql.Append(")AS Row, T.*  from Customer T ");
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
			parameters[0].Value = "Customer";
			parameters[1].Value = "CustomerID";
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


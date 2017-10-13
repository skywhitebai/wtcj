/**  版本信息模板在安装目录下，可自行修改。
* Department.cs
*
* 功 能： N/A
* 类 名： Department
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/6/20 12:57:09   N/A    初版
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
	/// 数据访问类:Department
	/// </summary>
	public partial class Department
	{
		public Department()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DepartmentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Department");
			strSql.Append(" where DepartmentID=@DepartmentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,36)			};
			parameters[0].Value = DepartmentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Department(");
			strSql.Append("DepartmentID,DepartmentName,OrderBy,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@DepartmentID,@DepartmentName,@OrderBy,@Remark,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,36),
					new SqlParameter("@DepartmentName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36)};
			parameters[0].Value = model.DepartmentID;
			parameters[1].Value = model.DepartmentName;
			parameters[2].Value = model.OrderBy;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.CreateBy;
			parameters[6].Value = model.UpdateTime;
			parameters[7].Value = model.UpdateBy;

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
		public bool Update(WTCJ.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Department set ");
			strSql.Append("DepartmentName=@DepartmentName,");
			strSql.Append("OrderBy=@OrderBy,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where DepartmentID=@DepartmentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.DepartmentName;
			parameters[1].Value = model.OrderBy;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.CreateBy;
			parameters[5].Value = model.UpdateTime;
			parameters[6].Value = model.UpdateBy;
			parameters[7].Value = model.DepartmentID;

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
		public bool Delete(string DepartmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where DepartmentID=@DepartmentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,36)			};
			parameters[0].Value = DepartmentID;

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
		public bool DeleteList(string DepartmentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where DepartmentID in ("+DepartmentIDlist + ")  ");
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
		public WTCJ.Model.Department GetModel(string DepartmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DepartmentID,DepartmentName,OrderBy,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy from Department ");
			strSql.Append(" where DepartmentID=@DepartmentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,36)			};
			parameters[0].Value = DepartmentID;

			WTCJ.Model.Department model=new WTCJ.Model.Department();
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
		public WTCJ.Model.Department DataRowToModel(DataRow row)
		{
			WTCJ.Model.Department model=new WTCJ.Model.Department();
			if (row != null)
			{
				if(row["DepartmentID"]!=null)
				{
					model.DepartmentID=row["DepartmentID"].ToString();
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["OrderBy"]!=null && row["OrderBy"].ToString()!="")
				{
					model.OrderBy=int.Parse(row["OrderBy"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["CreateBy"]!=null)
				{
					model.CreateBy=row["CreateBy"].ToString();
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
				}
				if(row["UpdateBy"]!=null)
				{
					model.UpdateBy=row["UpdateBy"].ToString();
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
			strSql.Append("select DepartmentID,DepartmentName,OrderBy,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy ");
			strSql.Append(" FROM Department ");
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
			strSql.Append(" DepartmentID,DepartmentName,OrderBy,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy ");
			strSql.Append(" FROM Department ");
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
			strSql.Append("select count(1) FROM Department ");
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
				strSql.Append("order by T.DepartmentID desc");
			}
			strSql.Append(")AS Row, T.*  from Department T ");
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
			parameters[0].Value = "Department";
			parameters[1].Value = "DepartmentID";
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


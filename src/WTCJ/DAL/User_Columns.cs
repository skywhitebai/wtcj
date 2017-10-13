/**  版本信息模板在安装目录下，可自行修改。
* User_Columns.cs
*
* 功 能： N/A
* 类 名： User_Columns
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/7/5 15:05:26   N/A    初版
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
	/// 数据访问类:User_Columns
	/// </summary>
	public partial class User_Columns
	{
		public User_Columns()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_Columns");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.User_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_Columns(");
			strSql.Append("id,type,tableName,allColumns,showColumns,hideColumns,UserID,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@id,@type,@tableName,@allColumns,@showColumns,@hideColumns,@UserID,@Remark,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@tableName", SqlDbType.VarChar,50),
					new SqlParameter("@allColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@showColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@hideColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.type;
			parameters[2].Value = model.tableName;
			parameters[3].Value = model.allColumns;
			parameters[4].Value = model.showColumns;
			parameters[5].Value = model.hideColumns;
			parameters[6].Value = model.UserID;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.CreateBy;
			parameters[10].Value = model.UpdateTime;
			parameters[11].Value = model.UpdateBy;

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
		public bool Add(SqlTransaction tran,WTCJ.Model.User_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_Columns(");
			strSql.Append("id,type,tableName,allColumns,showColumns,hideColumns,UserID,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@id,@type,@tableName,@allColumns,@showColumns,@hideColumns,@UserID,@Remark,@CreateTime,@CreateBy,@UpdateTime,@UpdateBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@tableName", SqlDbType.VarChar,50),
					new SqlParameter("@allColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@showColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@hideColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.type;
			parameters[2].Value = model.tableName;
			parameters[3].Value = model.allColumns;
			parameters[4].Value = model.showColumns;
			parameters[5].Value = model.hideColumns;
			parameters[6].Value = model.UserID;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.CreateTime;
			parameters[9].Value = model.CreateBy;
			parameters[10].Value = model.UpdateTime;
			parameters[11].Value = model.UpdateBy;

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
		public bool Update(WTCJ.Model.User_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_Columns set ");
			strSql.Append("type=@type,");
			strSql.Append("tableName=@tableName,");
			strSql.Append("allColumns=@allColumns,");
			strSql.Append("showColumns=@showColumns,");
			strSql.Append("hideColumns=@hideColumns,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@tableName", SqlDbType.VarChar,50),
					new SqlParameter("@allColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@showColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@hideColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.type;
			parameters[1].Value = model.tableName;
			parameters[2].Value = model.allColumns;
			parameters[3].Value = model.showColumns;
			parameters[4].Value = model.hideColumns;
			parameters[5].Value = model.UserID;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.CreateTime;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.UpdateTime;
			parameters[10].Value = model.UpdateBy;
			parameters[11].Value = model.id;

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
		public bool Update(SqlTransaction tran,WTCJ.Model.User_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_Columns set ");
			strSql.Append("type=@type,");
			strSql.Append("tableName=@tableName,");
			strSql.Append("allColumns=@allColumns,");
			strSql.Append("showColumns=@showColumns,");
			strSql.Append("hideColumns=@hideColumns,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@tableName", SqlDbType.VarChar,50),
					new SqlParameter("@allColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@showColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@hideColumns", SqlDbType.VarChar,4000),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@id", SqlDbType.VarChar,36)};
			parameters[0].Value = model.type;
			parameters[1].Value = model.tableName;
			parameters[2].Value = model.allColumns;
			parameters[3].Value = model.showColumns;
			parameters[4].Value = model.hideColumns;
			parameters[5].Value = model.UserID;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.CreateTime;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.UpdateTime;
			parameters[10].Value = model.UpdateBy;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from User_Columns ");
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
			strSql.Append("delete from User_Columns ");
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
		public WTCJ.Model.User_Columns GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,type,tableName,allColumns,showColumns,hideColumns,UserID,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy from User_Columns ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,36)			};
			parameters[0].Value = id;

			WTCJ.Model.User_Columns model=new WTCJ.Model.User_Columns();
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
		public WTCJ.Model.User_Columns DataRowToModel(DataRow row)
		{
			WTCJ.Model.User_Columns model=new WTCJ.Model.User_Columns();
			if (row != null)
			{
				if(row["id"]!=null)
				{
					model.id=row["id"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["tableName"]!=null)
				{
					model.tableName=row["tableName"].ToString();
				}
				if(row["allColumns"]!=null)
				{
					model.allColumns=row["allColumns"].ToString();
				}
				if(row["showColumns"]!=null)
				{
					model.showColumns=row["showColumns"].ToString();
				}
				if(row["hideColumns"]!=null)
				{
					model.hideColumns=row["hideColumns"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
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
			strSql.Append("select id,type,tableName,allColumns,showColumns,hideColumns,UserID,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy ");
			strSql.Append(" FROM User_Columns ");
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
			strSql.Append(" id,type,tableName,allColumns,showColumns,hideColumns,UserID,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy ");
			strSql.Append(" FROM User_Columns ");
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
			strSql.Append("select id,type,tableName,allColumns,showColumns,hideColumns,UserID,Remark,CreateTime,CreateBy,UpdateTime,UpdateBy ");
			strSql.Append(" FROM User_Columns ");
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
			strSql.Append("select count(1) FROM User_Columns ");
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
			strSql.Append(")AS Row, T.*  from User_Columns T ");
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
			parameters[0].Value = "User_Columns";
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


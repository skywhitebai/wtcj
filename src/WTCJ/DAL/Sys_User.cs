/**  版本信息模板在安装目录下，可自行修改。
* Sys_User.cs
*
* 功 能： N/A
* 类 名： Sys_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/6/19 10:16:40   N/A    初版
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
	/// 数据访问类:Sys_User
	/// </summary>
	public partial class Sys_User
	{
		public Sys_User()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50)			};
			parameters[0].Value = UserID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_User(");
			strSql.Append("UserID,LoginID,UserName,Sex,Mobile,EMail,Remark,Password,IsValid,IsEmployee,OuID,OuType)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@LoginID,@UserName,@Sex,@Mobile,@EMail,@Remark,@Password,@IsValid,@IsEmployee,@OuID,@OuType)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@LoginID", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@EMail", SqlDbType.VarChar,150),
					new SqlParameter("@Remark", SqlDbType.VarChar,550),
					new SqlParameter("@Password", SqlDbType.VarChar,100),
					new SqlParameter("@IsValid", SqlDbType.VarChar,1),
					new SqlParameter("@IsEmployee", SqlDbType.VarChar,1),
					new SqlParameter("@OuID", SqlDbType.VarChar,50),
					new SqlParameter("@OuType", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.LoginID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Mobile;
			parameters[5].Value = model.EMail;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Password;
			parameters[8].Value = model.IsValid;
			parameters[9].Value = model.IsEmployee;
			parameters[10].Value = model.OuID;
			parameters[11].Value = model.OuType;

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
		public bool Update(WTCJ.Model.Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_User set ");
			strSql.Append("LoginID=@LoginID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("EMail=@EMail,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Password=@Password,");
			strSql.Append("IsValid=@IsValid,");
			strSql.Append("IsEmployee=@IsEmployee,");
			strSql.Append("OuID=@OuID,");
			strSql.Append("OuType=@OuType");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@EMail", SqlDbType.VarChar,150),
					new SqlParameter("@Remark", SqlDbType.VarChar,550),
					new SqlParameter("@Password", SqlDbType.VarChar,100),
					new SqlParameter("@IsValid", SqlDbType.VarChar,1),
					new SqlParameter("@IsEmployee", SqlDbType.VarChar,1),
					new SqlParameter("@OuID", SqlDbType.VarChar,50),
					new SqlParameter("@OuType", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.LoginID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.EMail;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.Password;
			parameters[7].Value = model.IsValid;
			parameters[8].Value = model.IsEmployee;
			parameters[9].Value = model.OuID;
			parameters[10].Value = model.OuType;
			parameters[11].Value = model.UserID;

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
		public bool Delete(string UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50)			};
			parameters[0].Value = UserID;

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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public WTCJ.Model.Sys_User GetModel(string UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,LoginID,UserName,Sex,Mobile,EMail,Remark,Password,IsValid,IsEmployee,OuID,OuType from Sys_User ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50)			};
			parameters[0].Value = UserID;

			WTCJ.Model.Sys_User model=new WTCJ.Model.Sys_User();
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
		public WTCJ.Model.Sys_User DataRowToModel(DataRow row)
		{
			WTCJ.Model.Sys_User model=new WTCJ.Model.Sys_User();
			if (row != null)
			{
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["LoginID"]!=null)
				{
					model.LoginID=row["LoginID"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["EMail"]!=null)
				{
					model.EMail=row["EMail"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["IsValid"]!=null)
				{
					model.IsValid=row["IsValid"].ToString();
				}
				if(row["IsEmployee"]!=null)
				{
					model.IsEmployee=row["IsEmployee"].ToString();
				}
				if(row["OuID"]!=null)
				{
					model.OuID=row["OuID"].ToString();
				}
				if(row["OuType"]!=null)
				{
					model.OuType=row["OuType"].ToString();
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
			strSql.Append("select UserID,LoginID,UserName,Sex,Mobile,EMail,Remark,Password,IsValid,IsEmployee,OuID,OuType ");
			strSql.Append(" FROM Sys_User ");
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
			strSql.Append(" UserID,LoginID,UserName,Sex,Mobile,EMail,Remark,Password,IsValid,IsEmployee,OuID,OuType ");
			strSql.Append(" FROM Sys_User ");
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
			strSql.Append("select count(1) FROM Sys_User ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_User T ");
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
			parameters[0].Value = "Sys_User";
			parameters[1].Value = "UserID";
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


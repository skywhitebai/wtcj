/**  版本信息模板在安装目录下，可自行修改。
* Area.cs
*
* 功 能： N/A
* 类 名： Area
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
	/// 数据访问类:Area
	/// </summary>
	public partial class Area
	{
		public Area()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AreaID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Area");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.VarChar,36)			};
			parameters[0].Value = AreaID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WTCJ.Model.Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Area(");
			strSql.Append("AreaID,AreaName,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@AreaID,@AreaName,@OrderBy,@Remark,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.VarChar,36),
					new SqlParameter("@AreaName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.AreaID;
			parameters[1].Value = model.AreaName;
			parameters[2].Value = model.OrderBy;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.CreateBy;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.UpdateBy;
			parameters[7].Value = model.UpdateTime;

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
		public bool Update(WTCJ.Model.Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Area set ");
			strSql.Append("AreaName=@AreaName,");
			strSql.Append("OrderBy=@OrderBy,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateBy=@UpdateBy,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,36),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,36),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@AreaID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.AreaName;
			parameters[1].Value = model.OrderBy;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.CreateBy;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.UpdateBy;
			parameters[6].Value = model.UpdateTime;
			parameters[7].Value = model.AreaID;

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
		public bool Delete(string AreaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Area ");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.VarChar,36)			};
			parameters[0].Value = AreaID;

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
		public bool DeleteList(string AreaIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Area ");
			strSql.Append(" where AreaID in ("+AreaIDlist + ")  ");
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
		public WTCJ.Model.Area GetModel(string AreaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AreaID,AreaName,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime from Area ");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.VarChar,36)			};
			parameters[0].Value = AreaID;

			WTCJ.Model.Area model=new WTCJ.Model.Area();
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
		public WTCJ.Model.Area DataRowToModel(DataRow row)
		{
			WTCJ.Model.Area model=new WTCJ.Model.Area();
			if (row != null)
			{
				if(row["AreaID"]!=null)
				{
					model.AreaID=row["AreaID"].ToString();
				}
				if(row["AreaName"]!=null)
				{
					model.AreaName=row["AreaName"].ToString();
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
			strSql.Append("select AreaID,AreaName,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Area ");
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
			strSql.Append(" AreaID,AreaName,OrderBy,Remark,CreateBy,CreateTime,UpdateBy,UpdateTime ");
			strSql.Append(" FROM Area ");
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
			strSql.Append("select count(1) FROM Area ");
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
				strSql.Append("order by T.AreaID desc");
			}
			strSql.Append(")AS Row, T.*  from Area T ");
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
			parameters[0].Value = "Area";
			parameters[1].Value = "AreaID";
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


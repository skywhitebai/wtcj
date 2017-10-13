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
namespace WTCJ.Model
{
	/// <summary>
	/// User_Columns:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User_Columns
	{
		public User_Columns()
		{}
		#region Model
		private string _id;
		private string _type;
		private string _tablename;
		private string _allcolumns;
		private string _showcolumns;
		private string _hidecolumns;
		private string _userid;
		private string _remark;
		private DateTime? _createtime;
		private string _createby;
		private DateTime? _updatetime;
		private string _updateby;
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
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string allColumns
		{
			set{ _allcolumns=value;}
			get{return _allcolumns;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string showColumns
		{
			set{ _showcolumns=value;}
			get{return _showcolumns;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hideColumns
		{
			set{ _hidecolumns=value;}
			get{return _hidecolumns;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		#endregion Model

	}
}


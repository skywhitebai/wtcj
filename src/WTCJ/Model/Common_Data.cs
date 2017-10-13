/**  版本信息模板在安装目录下，可自行修改。
* Common_Data.cs
*
* 功 能： N/A
* 类 名： Common_Data
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/6/19 10:57:58   N/A    初版
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
	/// Common_Data数据字典表:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Common_Data
	{
		public Common_Data()
		{}
		#region Model
		private string _dataid;
		private string _datatext;
		private string _datavalue;
		private string _datatype;
		private int? _orderby;
		private string _remark;
		private string _createby;
		private DateTime? _createtime;
		private string _updateby;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public string DataID
		{
			set{ _dataid=value;}
			get{return _dataid;}
		}
		/// <summary>
		/// 数据text值
		/// </summary>
		public string DataText
		{
			set{ _datatext=value;}
			get{return _datatext;}
		}
		/// <summary>
		/// 数据Value值
		/// </summary>
		public string DataValue
		{
			set{ _datavalue=value;}
			get{return _datavalue;}
		}
		/// <summary>
		/// 数据类型
		/// </summary>
		public string DataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? OrderBy
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public string UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}


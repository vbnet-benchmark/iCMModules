using System;
using System.Data;
using System.Configuration;
using System.Diagnostics; 
using iConsulting;
using iConsulting.iCMServer; 
using iConsulting.iCMServer.iCDataManager;

namespace iConsulting.iCMServer.Modules.ModuleDefinition
{
	/// <summary>
	/// Summary description for clsModuleDefinition.
	/// </summary>
	public class clsModuleDefinition
	{
		private iCDataObject oDO	= new iCDataObject();  
		private clsCrypto oCrypto	= new clsCrypto();
		private string ED			= string.Empty;
		private string EC			= string.Empty;
		private clsSiteSettings oSite;     
		private int m_PagId			= 0;
		private int m_ModId			= 0;

		public clsModuleDefinition(int PagId ,int ModId)
		{
			m_PagId = PagId;
			m_ModId = ModId;
			ED		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["DataSource"]);
			EC		= oCrypto.Encrypt(ConfigurationSettings.AppSettings["ConnectionString"]);
			oSite	= (clsSiteSettings) System.Web.HttpContext.Current.Items["SiteSettings"]; 
		}

		public DataSet GetStandardModules()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mde_moduledefinitions", "sit_id = " + oSite.SiteId + " AND mde_hidden = 0", "mde_name", ref sError, ED, EC, ref ds))
				{
					throw new Exception(); 
				}
				return ds;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetStandardModules()");
				return new DataSet();	
			}
		}

		public DataSet GetServerModules()
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mde_moduledefinitions", "sit_id = " + oSite.SiteId + " AND mde_hidden = 1", "mde_name", ref sError, ED, EC, ref ds))
				{
					throw new Exception(); 
				}
				return ds;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetServerModules()");
				return new DataSet();	
			}
		}

		public DataSet GetModule(string MdeId)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mde_moduledefinitions", "sit_id = " + oSite.SiteId + " AND mde_id = " + MdeId, "", ref sError, ED, EC, ref ds))
				{
					throw new Exception(); 
				}
				return ds;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "GetModule()");
				return new DataSet();	
			}
		}

		public bool UpdateModule(string MdeId, string Name, string Url)
		{
			try
			{
				DataSet ds		= new DataSet();
				string sError	= string.Empty;
				if(!oDO.GetDataSet("mde_moduledefinitions", "sit_id = " + oSite.SiteId + " AND mde_id = " + MdeId, "", ref sError, ED, EC, ref ds))
				{
					throw new Exception(); 
				}
				ds.Tables[0].Rows[0]["mde_name"]		= Name;  
				ds.Tables[0].Rows[0]["mde_desktopsrc"]	= Url; 
				if(!oDO.SaveDataSet(ref sError, ED, EC, ref ds, false))
				{
					throw new Exception(); 
				}
				return true;
			}
			catch(Exception ex)
			{
				ErrorHandler(ex, "UpdateModule()");
				return false;
			}
		}

		private void ErrorHandler(Exception ex, string Function)
		{
			EventLog.WriteEntry(
				"iConsulting.iCMServer.Modules.ModuleDefinition", 
				ex.GetType().ToString() + "occured in " + Function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message  + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace, 
				EventLogEntryType.Error
				);
		}
	}
}

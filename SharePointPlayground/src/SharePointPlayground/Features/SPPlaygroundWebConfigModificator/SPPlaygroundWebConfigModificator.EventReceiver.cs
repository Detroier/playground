using System;
using System.Runtime.InteropServices;
using Microsoft.SharePoint;

namespace SharePointPlayground.Features.SPPlaygroundWebConfigModificator
{
	/// <summary>
	/// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
	/// </summary>
	/// <remarks>
	/// The GUID attached to this class may be used during packaging and should not be modified.
	/// </remarks>

	[Guid("33503f7f-424d-4dbc-a359-b0aa97d73137")]
	public class SPPlaygroundWebConfigModificatorEventReceiver : SPFeatureReceiver
	{
		public override void FeatureActivated(SPFeatureReceiverProperties properties)
		{
			//need to provide configuration!
			//can't use injection here, since this feature needs to do the configuration :(
			//should Sharterkit implementation be taken?
			//or
			//maybe just have configuration projects for each environment? and don't care about this feature?
			//so configuration WSP package?
		}

		public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
		{
		}

		public override void FeatureInstalled(SPFeatureReceiverProperties properties)
		{
		}

		public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
		{
		}

		public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
		{
		}
	}
}

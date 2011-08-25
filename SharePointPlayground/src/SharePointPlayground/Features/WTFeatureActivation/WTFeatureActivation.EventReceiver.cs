using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace SharePointPlayground.Features.WTFeatureActivation
{
	/// <summary>
	/// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
	/// </summary>
	/// <remarks>
	/// The GUID attached to this class may be used during packaging and should not be modified.
	/// </remarks>

	[Guid("3176391b-9ac8-424d-b03f-facfaab85818")]
	public class WTFeatureActivationEventReceiver : SPFeatureReceiver
	{
		public override void FeatureActivated(SPFeatureReceiverProperties properties)
		{
			//Ensure that scope is correctly set
			if (properties.Feature.Parent is SPWeb)
			{
				SPWeb web = (SPWeb)properties.Feature.Parent;
				foreach (SPFeatureProperty property in properties.Feature.Properties)
				{
					Guid featureGuid = new Guid(property.Value);
					//Verify feature status
					SPFeature feature = web.Site.Features[featureGuid];
					if (feature == null)
					{
						//Activate site collection scoped feature, if requested and not currently activated
						web.Site.Features.Add(featureGuid);
					}
				}
			}
		}
	}
}

<%@ Page Language="C#" CodeBehind="DefaultPageLayout.aspx.cs" Inherits="SPWindsor.Elements.UI.PageLayouts.DefaultPageLayout, SPWindsor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=911058ac89dd2a30"
	meta:progid="SharePoint.WebPartPage.Document" %>

<%@ Register TagPrefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls"
	Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
	Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls"
	Assembly="Microsoft.SharePoint.Publishing, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation"
	Assembly="Microsoft.SharePoint.Publishing, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<asp:content contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">	
</asp:content>

<asp:content contentplaceholderid="GoogleAnalyticsPlaceHolder" runat="server">
</asp:content>

<asp:content contentplaceholderid="PlaceHolderPageTitle" runat="server">
	<SharePointWebControls:FieldValue id="PageTitle" FieldName="Title" runat="server"/>
</asp:content>

<asp:content contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<SharePointWebControls:UIVersionedContent UIVersion="4" runat="server">
		<ContentTemplate>
		</ContentTemplate>
	</SharePointWebControls:UIVersionedContent>	
</asp:content>

<asp:content contentplaceholderid="PlaceHolderMain" runat="server">	 

	<asp:Label runat="server" id="lblHelloWorld" />

	<WebPartPages:WebPartZone runat="server" AllowPersonalization="false" ID="TopZone" FrameType="TitleBarOnly"
						Title="<%$Resources:cms,WebPartZoneTitle_Top%>" Orientation="Vertical"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
	
	<table cellpadding="0" cellspacing="6" width="100%" class="splashLinkFrame">
		<tbody>
		<tr>
			<td width="50%" valign="top" class="splashLinkArea">
						<WebPartPages:WebPartZone runat="server" AllowPersonalization="false" ID="BottomLeftZone" FrameType="TitleBarOnly"
							Title="<%$Resources:cms,WebPartZoneTitle_BottomLeft%>" Orientation="Vertical"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
			</td>
			<td width="50%" valign="top" class="splashLinkArea">
				<WebPartPages:WebPartZone runat="server" AllowPersonalization="false" ID="BottomRightZone" FrameType="TitleBarOnly"
					Title="<%$Resources:cms,WebPartZoneTitle_BottomRight%>" Orientation="Vertical"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
			</td>
		</tr>
	</table>

		
</asp:content>

<asp:content contentplaceholderid="PlaceHolderPageImage" runat="server"></asp:content>

<asp:content contentplaceholderid="PlaceHolderNavSpacer" runat="server" />

<asp:content contentplaceholderid="PlaceHolderUtilityContent" runat="server">
</asp:content>

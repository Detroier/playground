<%@ Page language="C#"   Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=14.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceholderID="PlaceHolderAdditionalPageHead" runat="server">
	<script type='text/javascript' src='/_layouts/scripts/upm/jquery.js' />
	<SharePointWebControls:UIVersionedContent UIVersion="3" runat="server">
		<ContentTemplate>
			<style type="text/css">
					.ms-pagetitleareaframe table, .ms-titleareaframe
					{
						background: none;
						height: 10px;
						overflow:hidden;
					}
					.ms-pagetitle, .ms-titlearea
					{
						display:none;
					}
			</style>
			<SharePointWebControls:CssRegistration name="<% $SPUrl:~sitecollection/Style Library/~language/Core Styles/pageLayouts.css %>" runat="server"/>
			<PublishingWebControls:editmodepanel runat="server">
				<!-- Styles for edit mode only-->
				<SharePointWebControls:CssRegistration name="<% $SPUrl:~sitecollection/Style Library/~language/Core Styles/zz2_editMode.css %>" runat="server"/>
			</PublishingWebControls:editmodepanel>
		</ContentTemplate>
	</SharePointWebControls:UIVersionedContent>
	<SharePointWebControls:UIVersionedContent UIVersion="4" runat="server">
		<ContentTemplate>
			<style type="text/css">
				.v4master #s4-leftpanel { display: none; }
				.v4master .s4-ca { margin-left: 0px; }
			</style>
			<SharePointWebControls:CssRegistration name="<% $SPUrl:~sitecollection/Style Library/~language/Core Styles/page-layouts-21.css %>" runat="server"/>
			<PublishingWebControls:EditModePanel runat="server">
				<!-- Styles for edit mode only-->
				<SharePointWebControls:CssRegistration name="<% $SPUrl:~sitecollection/Style Library/~language/Core Styles/edit-mode-21.css %>"
					After="<% $SPUrl:~sitecollection/Style Library/~language/Core Styles/page-layouts-21.css %>" runat="server"/>
			</PublishingWebControls:EditModePanel>
		</ContentTemplate>
	</SharePointWebControls:UIVersionedContent>
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderPageTitle" runat="server">
	<SharePointWebControls:FieldValue id="PageTitle" FieldName="Title" runat="server"/>
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderPageTitleInTitleArea" runat="server">
	<SharePointWebControls:TextField runat="server" FieldName="Title"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleBreadcrumb" runat="server"> <SharePointWebControls:VersionedPlaceHolder UIVersion="3" runat="server"> <ContentTemplate> <asp:SiteMapPath ID="siteMapPath" runat="server" SiteMapProvider="CurrentNavigation" RenderCurrentNodeAsLink="false" SkipLinkText="" CurrentNodeStyle-CssClass="current" NodeStyle-CssClass="ms-sitemapdirectional"/> </ContentTemplate> </SharePointWebControls:VersionedPlaceHolder> <SharePointWebControls:UIVersionedContent UIVersion="4" runat="server"> <ContentTemplate> <SharePointWebControls:ListSiteMapPath runat="server" SiteMapProviders="CurrentNavigation" RenderCurrentNodeAsLink="false" PathSeparator="" CssClass="s4-breadcrumb" NodeStyle-CssClass="s4-breadcrumbNode" CurrentNodeStyle-CssClass="s4-breadcrumbCurrentNode" RootNodeStyle-CssClass="s4-breadcrumbRootNode" NodeImageOffsetX=0 NodeImageOffsetY=353 NodeImageWidth=16 NodeImageHeight=16 NodeImageUrl="/_layouts/images/fgimg.png" HideInteriorRootNodes="true" SkipLinkText="" /> </ContentTemplate> </SharePointWebControls:UIVersionedContent> </asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderMain" runat="server">
	<SharePointWebControls:UIVersionedContent UIVersion="3" runat="server">
		<ContentTemplate>
			<div class="ms-pagebreadcrumb removeMargins">
				<asp:SiteMapPath Runat="server" SiteMapProvider="CurrentNavSiteMapProviderNoEncode" RenderCurrentNodeAsLink="false" SkipLinkText="" NodeStyle-CssClass="ms-sitemapdirectional" />
			</div>
			<div style="clear:both">&#160;</div>
			<div class="floatLeft image">
				<PublishingWebControls:RichImageField id="PageImage" FieldName="PublishingPageImage"  runat="server" />
			</div>
			<div class="pageContent">
				<PublishingWebControls:RichHtmlField id="PageContent" FieldName="PublishingPageContent" runat="server"/>
			</div>
			<div style="clear:both">&#160;</div>
		</ContentTemplate>
	</SharePointWebControls:UIVersionedContent>
	<SharePointWebControls:UIVersionedContent UIVersion="4" runat="server">
		<ContentTemplate>
			<div class="welcome welcome-toc">
				<PublishingWebControls:EditModePanel runat="server" CssClass="edit-mode-panel">
					<SharePointWebControls:TextField runat="server" FieldName="Title"/>
				</PublishingWebControls:EditModePanel>
				<div class="welcome-image">
					<PublishingWebControls:RichImageField FieldName="PublishingPageImage"  runat="server"/>
				</div>
				<div class="welcome-content">
					<PublishingWebControls:RichHtmlField FieldName="PublishingPageContent" HasInitialFocus="True" MinimumEditHeight="400px" runat="server"/>
				</div>
				<div class="clearer"></div>
		</ContentTemplate>
	</SharePointWebControls:UIVersionedContent>
	<table width="100%">
		<tr>
			<td width="100%" valign="top" colspan="2">
				<WebPartPages:WebPartZone runat="server" AllowPersonalization="true" ID="TopColumnZone" FrameType="TitleBarOnly"
					Title="<%$Resources:cms,WebPartZoneTitle_Top%>" Orientation="Vertical"></WebPartPages:WebPartZone>
			</td>
		</tr>
		<tr>
			<td width="50%" valign="top">
				<WebPartPages:WebPartZone runat="server" AllowPersonalization="true" ID="LeftColumnZone" FrameType="TitleBarOnly"
					Title="<%$Resources:cms,WebPartZoneTitle_LeftColumn%>" Orientation="Vertical"></WebPartPages:WebPartZone>
			</td>
			<td width="50%" valign="top">
				<WebPartPages:WebPartZone runat="server" AllowPersonalization="true" ID="RightColumnZone" FrameType="TitleBarOnly"
					Title="<%$Resources:cms,WebPartZoneTitle_RightColumn%>" Orientation="Vertical"></WebPartPages:WebPartZone>
			</td>
		</tr>
	</table>
	<SharePointWebControls:UIVersionedContent UIVersion="4" runat="server">
		<ContentTemplate>
			</div>
		</ContentTemplate>
	</SharePointWebControls:UIVersionedContent>
</asp:Content>

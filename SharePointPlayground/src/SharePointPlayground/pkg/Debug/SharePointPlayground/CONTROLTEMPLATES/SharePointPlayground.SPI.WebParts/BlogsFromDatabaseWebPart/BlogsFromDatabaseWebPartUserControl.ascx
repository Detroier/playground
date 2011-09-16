<%@ Assembly Name="SharePointPlayground, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4f2964e4fc1c04d8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
	Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
	Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogsFromDatabaseWebPartUserControl.ascx.cs"
	Inherits="SharePointPlayground.SPI.WebParts.BlogsFromDatabaseWebPart.BlogsFromDatabaseWebPartUserControl" %>
<div style="display: block">
	<asp:Repeater runat="server" ID="_repPosts">
		<ItemTemplate>
			<div>
				<h3>
					<%# Eval("Title")%></h3>
				<div>
					<%# Eval("Body")%>
				</div>
				<asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' />
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<h3>
		And
		<asp:Literal runat="server" ID="_litAdditionalCount" />
		more!</h3>
	<asp:Button runat="server" ID="_btnAddRandomPost" Text="TryAddPost" />
</div>

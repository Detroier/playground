<%@ Assembly Name="SharePointPlayground, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4f2964e4fc1c04d8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
	Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
	Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastTasksByUserWebPartUserControl.ascx.cs"
	Inherits="SharePointPlayground.SPI.WebParts.LastTasksByUserWebPart.LastTasksByUserWebPartUserControl" %>
<asp:Repeater ID="_repTasks" runat="server">
	<HeaderTemplate>
		<table style="width: 100%">
			<tr>
				<th>
					ID
				</th>
				<th>
					Title
				</th>
				<th>
					Start Date
				</th>
				<th>
					Due Date
				</th>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<th>
				<%# Eval("ID") %>
			</th>
			<th>
				<%# Eval("Title") %>
			</th>
			<th>
				<%# Eval("StartDate") %>
			</th>
			<th>
				<%# Eval("DueDate") %>
			</th>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>

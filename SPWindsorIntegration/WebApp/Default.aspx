<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater runat="server" ID="_repTasks">
            <HeaderTemplate>
                <h1>
                    Recent 5 tasks:</h1>
                <table>
                    <tr>
                        <th>
                            Name:
                        </th>
                        <th>
                            Start date:
                        </th>
                        <th>
                            Due date:
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td>
                        <%# Eval("StartDate") %>
                    </td>
                    <td>
                        <%# Eval("DueDate") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater runat="server" ID="_repPerformers">
            <HeaderTemplate>
                <h1>
                    Best performers</h1>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <%# Eval("Name") %>
                    -
                    <%# Eval("Points") %>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>

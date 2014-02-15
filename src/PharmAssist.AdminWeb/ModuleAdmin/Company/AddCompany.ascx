<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCompany.ascx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Company.AddCompany" %>
<div>
	<table>
		<tr>
			<td>
				<asp:Literal ID="ltlCompanyCode" runat="server" Text="Customer Code"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtCompanyCode" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlCompanyName" runat="server" Text="Company Name"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtCompanyName" runat="server" ></asp:TextBox>
			</td>
		</tr>
	</table>
	<asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>

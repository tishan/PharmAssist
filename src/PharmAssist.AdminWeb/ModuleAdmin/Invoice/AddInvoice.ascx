 <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddInvoice.ascx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Invoice.AddInvoice" %>


<div>
	<table>
		<tr>
			<td>
			<asp:Literal ID="ltlInvoiceDate" runat="server" Text="Invoice Date"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtInvoiceDate" runat="server"></asp:TextBox>
			</td>
			</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlCustomer" runat="server" Text="Customer"></asp:Literal>
			</td>
			<td>
				
				<asp:DropDownList ID="ddlCustomer" runat="server"></asp:DropDownList>
			</td>
			</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlCompany" runat="server" Text="Company"></asp:Literal>
			</td>
			<td>
				
				<asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>
			</td>
			</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlInvoiceNumber" runat="server" Text="Invoice No"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtInvoiceNumber" runat="server"></asp:TextBox>
			</td>
		</tr>
			<tr>
			<td>
			<asp:Literal ID="ltlAmount" runat="server" Text="Amount"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
			</td>
		</tr>
		</tr>
			<tr>
			<td>
			<asp:Literal ID="ltlCreditPeriod" runat="server" Text="Credit Period"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtCreditPeriod" runat="server"></asp:TextBox>
			</td>
		</tr>
		
	</table>
</div>
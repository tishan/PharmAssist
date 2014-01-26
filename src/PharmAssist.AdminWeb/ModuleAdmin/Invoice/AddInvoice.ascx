<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddInvoice.ascx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Invoice.AddInvoice" %>

<script>
	$(function () {
		$("#<%= txtInvoiceDate.ClientID %>").datepicker();
});
</script>

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
		
	</table>
</div>
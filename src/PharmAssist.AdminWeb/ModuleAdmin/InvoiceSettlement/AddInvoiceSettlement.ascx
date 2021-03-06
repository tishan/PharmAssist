﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddInvoiceSettlement.ascx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.InvoiceSettlement.AddInvoiceSettlement"%>
<div>
	<table>
		<tr>
			<td>
			<asp:Literal ID="ltlCompanyName" runat="server" Text="Company Name"></asp:Literal>
			</td>
			<td>
				<asp:DropDownList ID="ddlCompanyName" runat='server' AutoPostBack='true' OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlCustomerBusinessName" runat="server" Text="Customer Business Name"></asp:Literal>
			</td>
			<td>
				<asp:DropDownList ID="ddlCustomerBusinessName" runat="server"  AutoPostBack='true' OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlInvoiceNumber" runat="server" Text="Invoice No"></asp:Literal>
			</td>
			<td>
				<asp:DropDownList ID="ddlInvoiceNumber" runat="server"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlCollectionDate" runat="server" Text="Collection Date"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtCollectionDate" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlSettlementType" runat="server" Text="Settlement Type"></asp:Literal>
			</td>
			<td>
				<asp:DropDownList ID="ddlCollectionType" runat="server"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlSettlementAmount" runat="server" Text="Settlement Amount"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtSettlementAmount" runat="server"></asp:TextBox>
			</td>
		</tr>

			<tr>
			<td>
			<asp:Literal ID="ltlDepositeDate" runat="server" Text="Deposit Date"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtDepositDate" runat="server"></asp:TextBox>
			</td>
		</tr>		
		<tr>
			<td>
			<asp:Literal ID="ltlInterest" runat="server" Text="Interest"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtInterest" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlGRNid" runat="server" Text="GRN Id"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtGRNid" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlBalanceAmount" runat="server" Text="Balance Amount"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtBalanceAmount" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
			<asp:Literal ID="ltlTotalOutstanding" runat="server" Text="Total Outstanding"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtTotalOutstading" runat="server"></asp:TextBox>
			</td>
		</tr>
		
	</table>
</div>
<asp:HiddenField ID="hdfInvoiceSettlmentId" runat="server" />

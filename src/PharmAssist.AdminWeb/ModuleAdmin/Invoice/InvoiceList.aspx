﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceList.aspx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Invoice.InvoiceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>INVOICES</h2>
	<asp:HyperLink ID="lnkAddInvoice" runat="server" CssClass="aDialog">Add Invoice</asp:HyperLink>
	<asp:GridView ID="gvInvoiceList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvInvoiceList_RowDataBound" Width="231px">
		<Columns>
			<asp:BoundField DataField="invoiceNumber" HeaderText="Invoice No" />
			<asp:BoundField DataField="invoiceDate" HeaderText="Invoice Date" />
			<asp:BoundField DataField="amount" HeaderText="Amount" />			
			<asp:BoundField DataField="customerId" HeaderText="Customer" />
			<asp:BoundField DataField="companyId" HeaderText="Company" />
			<asp:TemplateField>
				<ItemTemplate>
							<asp:HyperLink ID="lnkInvoiceEdit" runat="server" CssClass="aDialog">Edit</asp:HyperLink>
						</ItemTemplate>
						<ItemStyle/>
			</asp:TemplateField>
		</Columns>
		</asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceSettlementList.aspx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.InvoiceSettlement.InvoiceSettlementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Invoice Settlements</h2>
	<asp:HyperLink ID="lnkAddSettlement" runat="server" CssClass="aDialog">Perform Settlement</asp:HyperLink>
	<asp:GridView ID="gvInvoiceSettlementList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvInvoiceSettlementList_RowDataBound" Width="231px">
		<Columns>
			<asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
			<asp:BoundField DataField="CustomerBusinessName" HeaderText="Customer" />
			<asp:BoundField DataField="InvoiceSettlementId" HeaderText="Invoice Settlement Id" />
			<asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice No" />
			<asp:BoundField DataField="CollectionDate" HeaderText="Collection Date" />
			<asp:BoundField DataField="SettlementType" HeaderText="Type of Settlement" />
			<asp:BoundField DataField="DepositDate" HeaderText="Deposit Date" />
			<asp:TemplateField>
				<ItemTemplate>
							<asp:HyperLink ID="lnkInvoiceSettlementEdit" runat="server" CssClass="aDialog">Edit</asp:HyperLink>
						</ItemTemplate>
						<ItemStyle/>
			</asp:TemplateField>
		</Columns>
		</asp:GridView>
</asp:Content>

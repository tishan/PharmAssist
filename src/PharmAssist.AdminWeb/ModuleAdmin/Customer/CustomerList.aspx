<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Customer.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Customer List</h2>
	<div>
		<asp:HyperLink ID="lnkAddCustomer" runat="server" CssClass="aDialog">Add Customer</asp:HyperLink>
	</div>
	<asp:GridView ID="gvCustomerList" runat="server"
		AutoGenerateColumns="False" OnRowDataBound="gvCustomerList_RowDataBound" OnRowCommand="gvCustomerList_RowCommand">
		<Columns>
			<asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
			<asp:BoundField DataField="CutomerBussinessName"
				HeaderText="Customer Bussiness Name" />
			<asp:BoundField DataField="Town" HeaderText="Town" />
			<asp:TemplateField>
				<ItemTemplate>
					<asp:HyperLink ID="lnkCustomerEdit" runat="server" CssClass="aDialog">Edit</asp:HyperLink>
					<asp:LinkButton ID="lbtnDelete" runat="server" CommandName="DeleteCustomer" CssClass="grid_icon_link delete"
						ToolTip="Delete" OnClientClick="return confirm('Are you sure to delete the location?');" >Delete</asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>

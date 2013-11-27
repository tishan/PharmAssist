<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Customer.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Customer List</h2>


<div>
	<asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" />
</div>
	<asp:GridView ID="gvCustomerList" runat="server" 
	AutoGenerateColumns="False" onrowdatabound="gvCustomerList_RowDataBound">
		<Columns>
			<asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
			<asp:BoundField DataField="CutomerBussinessName" 
				HeaderText="Customer Bussiness Name" />
			<asp:BoundField DataField="Town" HeaderText="Town" />
			<asp:TemplateField>
						<ItemTemplate>
							<asp:HyperLink ID="lnkCustomerEdit" runat="server" CssClass="aDialog">Edit</asp:HyperLink>
						</ItemTemplate>
						<ItemStyle/>
					</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Company.CompanyList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Company List</h2>
<div>
	<asp:HyperLink ID="lnkAddCompany" runat="server" CssClass="aDialog">Add Company</asp:HyperLink>
</div>
	<asp:GridView ID="gvCompanyList" runat="server" AutoGenerateColumns="False" onrowdatabound="gvCompanyList_RowDataBound">
		<Columns>
			<asp:BoundField DataField="CompanyCode" HeaderText="Company Code" />
			<asp:BoundField DataField="CompanyName" HeaderText="Customer Name" />
			<asp:TemplateField>
				<ItemTemplate>
					<asp:HyperLink ID="lnkCompanyEdit" runat="server" CssClass="aDialog">Edit</asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditCustomer.aspx.cs" Inherits="PharmAssist.AdminWeb.ModuleAdmin.Customer.AddEditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
        Add Customer
    </h2>
	<div>
	<table>
		<tr>
			<td>
				<asp:Literal ID="ltlCustomerBussinessName" runat="server" Text="Customer Business Name"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtCustomerBusinessName" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlCustomerPersonalName" runat="server" Text="Customer Personal Name"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtCustomerPersonalName" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlTown" runat="server" Text="Town"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtTown" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlTelephone" runat="server" Text="Telephone"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtTelephone" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlMobile" runat="server" Text="Mobile"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtMobile" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlEmail" runat="server" Text="Email"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal ID="ltlComments" runat="server" Text="Comments"></asp:Literal>
			</td>
			<td>
				<asp:TextBox ID="txtComments" runat="server" ></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
			</td>
			<td>
				<asp:Button ID="btnCancel" runat="server" Text="Cancle" />
			</td>
		</tr>
	</table>
	<asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>
</asp:Content>

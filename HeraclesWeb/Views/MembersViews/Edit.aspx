<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="HeraclesWeb.Views.MembersViews.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Actualizar Miembro</h3>
        </div>
        <div class="container layout_padding2-top">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <form id="formMembresy" runat="server">
                        <div>
                            <asp:TextBox ID="txtId" runat="server" type="hidden"/>
                        </div>
                        <div>
                            <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Nombre"/>
                        </div>
                        <div>
                            <asp:TextBox ID="txtLastName" runat="server" type="text" placeholder="Apellido" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtSecondLastName" runat="server" type="text" placeholder="Apellido materno" />
                        </div>
                        <div class="input-container">
                            <div>
                                <asp:Label runat="server" Text="Peso"></asp:Label>
                                <asp:TextBox ID="txtWeight" runat="server" CssClass="input-item" type="number" placeholder="Peso" />
                            </div>
                            <div>
                                <asp:Label runat="server" Text="Medida de pecho"></asp:Label>
                                <asp:TextBox ID="txtChest" runat="server" CssClass="input-item" type="number" placeholder="Medida de pecho" />
                            </div>
                            <div>
                                <asp:Label runat="server" Text="Diametro de brazo"></asp:Label>
                                <asp:TextBox ID="txtArms" runat="server" CssClass="input-item" type="number" placeholder="Diametro de brazo" />
                            </div>
                            <div>
                                <asp:Label runat="server" Text="Diametro de pierna"></asp:Label>
                                <asp:TextBox ID="txtLeg" runat="server" CssClass="input-item" type="number" placeholder="Diametro de pierna" />
                            </div>
                            <div>
                                <asp:Label runat="server" Text="Diametro de cintura"></asp:Label>
                                <asp:TextBox ID="txtWaist" runat="server" CssClass="input-item" type="number" placeholder="Diametro de cintura" />
                            </div>
                        </div>
                        <div class="input-container">
                            <asp:Button runat="server" Text="Actualizar" OnClick="btnUpdate_Click" ID="btnUpdate" CssClass="button-class"/>
                            <asp:Button runat="server" Text="Volver" OnClick="btnBack_Click" ID="btnBack" CssClass="button-class"/>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</asp:Content>

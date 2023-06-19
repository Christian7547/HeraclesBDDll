<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuCoach.aspx.cs" Inherits="HeraclesWeb.Views.MenuCoach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">Menu</div>
    <div class="cards_wrap">
		<div class="card_item">
			<div class="card_inner">
				<span class="fa fa-user"></span>
				<image src="../../Images/personcard.png" class="logo"></image>
				<div class="role_name">Inscripciones</div>
				<div class="film">Gestión de Inscripciones</div>
				<br />
				<a class="link-styleCard" href="#">Ver Inscripciones</a>
			</div>
		</div>
		<div class="card_item">
			<div class="card_inner">
				<span class="fa fa-user"></span>
				<image src="../../Images/training.png" class="logo"></image>
				<div class="role_name">Clases</div>
				<div class="film">Gestión de clases</div>
				<br />
				<a class="link-styleCard" href="#">Ver Clases</a>
			</div>
		</div>
		<div class="card_item">
			<div class="card_inner">
				<span class="fa fa-user"></span>
				<image src="../../Images/schedule.png" class="logo"></image>
				<div class="role_name">Horarios</div>
				<div class="film">Gestión de horarios</div>
				<br />
				<a class="link-styleCard" href="#">Ver Horarios</a>
			</div>
		</div>
		<div class="card_item">
			<div class="card_inner">
				<span class="fa fa-user"></span>
				<image src="../../Images/default_Profile.png" class="logo"></image>
				<div class="role_name">Cuenta</div>
				<div class="film">Cambiar contraseña</div>
				<br />
				<form runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
					<asp:Button ID="btnChangePassword" OnClick="btnChangePassword_Click" Text="Cambiar contraseña" runat="server" CssClass="link-styleCard"/>
					<ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="btnChangePassword"
						PopupControlID="pnlConfirmation" BackgroundCssClass="modal-background" OkControlID="btnOk" CancelControlID="btnCancel" />
					<asp:Panel ID="pnlConfirmation" runat="server" CssClass="modal-panel">
						<h3>Cambio de contraseña</h3>
						<asp:TextBox ID="txtOldPassword" runat="server" CssClass="input-modal" type="password" placeholder="Contraseña actual"></asp:TextBox>
						<asp:TextBox ID="txtNewPassword" runat="server" CssClass="input-modal" type="password" placeholder="Nueva contraseña"></asp:TextBox>
						<asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-modal" type="password" placeholder="Confirmar contraseña"></asp:TextBox>
						<div class="modal-buttons">
							<asp:Button runat="server" ID="btnOk" OnClick="btnOk_Click" Text="Aceptar" CssClass="button-modal" />
							<asp:Button runat="server" ID="btnCancel" Text="Cancelar" CssClass="button-modal" />
						</div>
					</asp:Panel>
					<script>

                    </script>
				</form>
			</div>
		</div>
	</div>
</asp:Content>

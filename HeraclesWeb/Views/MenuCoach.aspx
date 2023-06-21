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
				<div class="film">Opciones de perfil</div>
				<br />
				<a class="link-styleCard" href="changepassword">Cambiar contraseña</a>
			</div>
		</div>
	</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="HeraclesWeb.Views.BranchViews.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
        <div class="custom_heading-container">
            <h3 class="typographyClass">Editar Sucursal</h3>
        </div>
        <div class="container layout_padding2-top">
            <div style="display: flex; margin: 40px; padding-bottom: 50px;">
                <div style="margin-right: 40px; width: 600px; margin-top: 100px;">
                    <form id="formMembresy" runat="server">
                        <asp:TextBox runat="server" ID="txtId" type="hidden"/>
                        <div>
                            <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Nombre de la sucursal" />
                        </div>
                        <div>
                            <asp:TextBox ID="txtDirection" runat="server" type="text" placeholder="Dirección de la sucursal" />
                        </div>
                        <div>
                            <asp:DropDownList runat="server" ID="cmbLocation" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txtLatitude" type="hidden"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtLongitude" type="hidden"></asp:TextBox>
                        </div>
                        <div class="input-container">
                            <asp:Button runat="server" Text="Actualizar" OnClick="btnUpdate_Click" ID="btnUpdate" CssClass="button-class" />
                            <asp:Button runat="server" Text="Volver" OnClick="btnBack_Click" ID="btnBack" CssClass="button-class" />
                        </div>
                    </form>
                </div>
                <div class="divMap">
                    <asp:Label runat="server" Text="Seleccione una ubicación"></asp:Label>
                    <div id="map" style="width: 600px; height: 600px;"></div>
                </div>
            </div>
        </div>   
        <script type="text/javascript">
            var map
            var marker

            const loadMap = () => {
                var bingMaps = "AgfX3Lt338M1fXHQBLzao_pSuD1WXDM4IGbn3FXBG9lziA7QYZ3hUW84AKCxcMlW"
                var script = document.createElement('script')
                script.src = "http://www.bing.com/api/maps/mapcontrol?callback=initMap&key=" + bingMaps;
                document.body.appendChild(script)
            }

            function initMap() {
                map = new Microsoft.Maps.Map(document.getElementById('map'), {
                    credentials: "AgfX3Lt338M1fXHQBLzao_pSuD1WXDM4IGbn3FXBG9lziA7QYZ3hUW84AKCxcMlW",
                    center: new Microsoft.Maps.Location(-17.393496874429385, -66.15692841770928),
                    zoom: 17
                })

                loadMaker()

                refreshMap()

                Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
                    if (marker) {
                        map.entities.remove(marker)
                    }
                    var location = e.location
                    marker = new Microsoft.Maps.Pushpin(location, {
                        title: 'My point',
                        subTitle: ''
                    })
                    map.entities.push(marker)

                    var inputLatitude = document.getElementById('<%= txtLatitude.ClientID%>')
                    var inputLongitude = document.getElementById('<%= txtLongitude.ClientID%>')
                    inputLatitude.value = location.latitude
                    inputLongitude.value = location.longitude
                })
            }
            window.onload = loadMap

            const loadMaker = () => {
                var latTxtValue = document.getElementById('<%=txtLatitude.ClientID%>')
                var lonTxtValue = document.getElementById('<%=txtLongitude.ClientID%>')
                function addMaker () {
                    var location = new Microsoft.Maps.Location(latTxtValue.value.replace(',', '.'), lonTxtValue.value.replace(',', '.'))
                    marker = new Microsoft.Maps.Pushpin(location)
                    map.entities.push(marker)
                    map.setView({ center: location, zoom: 17 })
                }
                addMaker()
            }

            const refreshMap = () => {
                var selectionChanged = document.getElementById('<%=cmbLocation.ClientID%>')
                selectionChanged.addEventListener('change', () => {
                    var selectedValue = selectionChanged.value
                    if (selectedValue === '1') { 
                        map.setView({ center: new Microsoft.Maps.Location(-17.393496874429385, -66.15692841770928), zoom: 17 })
                    } else if (selectedValue === '2') {
                        map.setView({ center: new Microsoft.Maps.Location(-17.810339482847326, -63.152239238559666), zoom: 17 })
                    } else if (selectedValue === '3') {
                        map.setView({ center: new Microsoft.Maps.Location(-16.488436864854233, -68.11927524848547), zoom: 17 })
                    } else if (selectedValue === '4') {
                        map.setView({ center: new Microsoft.Maps.Location(-14.831559888992476, -64.90407863556396), zoom: 17 })
                    } else if (selectedValue === '5') {
                        map.setView({ center: new Microsoft.Maps.Location(-19.036211095196702, -65.26185634222716), zoom: 17 })
                    }
                })
            }

        </script>
    </section>
</asp:Content>

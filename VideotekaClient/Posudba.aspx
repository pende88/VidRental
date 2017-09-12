<%@ Page Title="Posudba" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Posudba.aspx.cs" Inherits="VideotekaClient.Posudba" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/bootbox.min.js"></script>




    <br />
    <br />


    <div class="container">
        <div class="row">
            <br /><br />
            <div class="col-md-8 col-md-offset-2">

                <fieldset>
                    <legend>Posudba</legend>

                    <asp:DropDownList ID="ddlZauzetiFilmovi" DataValueField="idFilm" DataTextField="Naziv" runat="server" Visible="false" AutoPostBack="false" AppendDataBoundItems="false"></asp:DropDownList>

                    <div class="form group">
                        <asp:Label AssociatedControlID="txtIdPosudbe" ControlStyle-CssClass="control-label col-md-3" ID="lblId" runat="server" Text="id Posudbe: " Enabled="false"></asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtIdPosudbe" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>

                    </div>
                    <br />
                    <div class="form group ">
                        <asp:Label ID="lblFilm" runat="server" CssClass="control-label col-md-3" Text="Naziv Filma: " AssociatedControlID="ddlFilm"></asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlFilm" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="idFilm" DataTextField="Naziv">
                                <Items>
                                    <asp:ListItem Text="Odaberi film" Value="" Selected="True"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="validatorDdlFilm" runat="server" ErrorMessage="Molimo odaberite film " OnServerValidate="validatorDdlFilm_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>


                    <div class="form group ">
                        <asp:Label ID="ddlLabel" runat="server" CssClass="control-label col-md-3" Text="Medij:" AssociatedControlID="ddlTipMedija"></asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlTipMedija" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="id" DataTextField="Naziv">
                                <Items>
                                    <asp:ListItem Text="Odaberi medij" Value="" Selected="True"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="validatorDdlTipMedija" runat="server" ErrorMessage="Molimo odaberite tip medija" OnServerValidate="validatorDdlTipMedija_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>

                    <div class="form group ">
                        <asp:Label ID="lblKlijent" runat="server" CssClass="control-label col-md-3" Text="Naziv Klijenta:" AssociatedControlID="ddlKlijent"></asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlKlijent" AppendDataBoundItems="true" CssClass="form-control" AutoPostBack="false" DataValueField="id" DataTextField="prezime" runat="server">
                                <Items>
                                    <asp:ListItem Text="Odaberi klijenta:" Value="" Selected="True"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="validatorDdlKlijent" runat="server" ErrorMessage="Molimo odaberite klijenta" OnServerValidate="validatorDdlKlijent_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>
                    <div class="form group ">
                        <asp:Label ID="lblDatumPosudbe" CssClass="control-label col-md-3" runat="server" Text="Datum Posudbe:" AssociatedControlID="txtDatumPosudbe"></asp:Label>
                        <div class="col-md-9">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatumPosudbe" DaysModeTitleFormat="MMMM d, yyyy" Format="MMMM d, yyyy" />
                            <asp:TextBox  ToolTip="Mjesec, dan, godina" ID="txtDatumPosudbe" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Datum posudbe je obavezan" ControlToValidate="txtDatumPosudbe"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="validatorDatumaPosudbe" runat="server" ErrorMessage="Datum nije u pravilnom formatu" OnServerValidate="validatorDatumaPosudbe_ServerValidate"></asp:CustomValidator>
                           
                            </div>
                    </div>
                     <div class="form group ">
                        <asp:label id="lbldatumpovrata" cssclass="control-label col-md-3" runat="server" text="Datum Povrata:" associatedcontrolid="txtDatumPovrata"></asp:label>
                        <div class="col-sm-9">
                            <ajaxtoolkit:calendarextender id="calendarextender2" runat="server" targetcontrolid="txtDatumPovrata" DaysModeTitleFormat="MMMM d, yyyy" Format="MMMM d, yyyy" />

                            <asp:textbox ToolTip="Mjesec, dan, godina" id="txtDatumPovrata" runat="server" cssclass="form-control"></asp:textbox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Datum povrata ne može biti ranije od datuma posudbe ili nije u pravilnom formatu" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </div>
                    </div>
                    

                    
                   
                   
                
                </fieldset>
                <br />
                <div class="form-group">
                    <div class="col-md-9 col-md-offset-3">
                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click1" />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnSave_Click1" />
                        <asp:Button CssClass="btn btn-default" ID="btnDelete" runat="server" Text="Delete" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDelete_Click" CausesValidation="false" />
                        <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />

                    </div>
                </div>


            </div>
        </div>
        <br />
        <asp:Label class="col-md-offset-4" ID="statusLabel" runat="server" Text=""></asp:Label>
        <br />

        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <br />

                <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" Visible="true" ID="GridViewPosudba" DataKeyNames="id" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewPosudba_SelectedIndexChanged">
                    <Columns>

                        <asp:TemplateField HeaderText="Id Posudbe" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdPosudba" runat="server" Text='<%#Eval("id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ime Korisnika">
                            <ItemTemplate>
                                <asp:Label ID="lblIme" runat="server" Text='<%#Eval("Ime") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prezime Korisnika">
                            <ItemTemplate>
                                <asp:Label ID="lblPrezime" runat="server" Text='<%#Eval("Prezime") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Film">
                            <ItemTemplate>
                                <asp:Label ID="lblFilm" runat="server" Text='<%#Eval("NazivFilma") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Medij">
                            <ItemTemplate>
                                <asp:Label ID="lblMedij" runat="server" Text='<%#Eval("Medij") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Datum Posudbe">
                            <ItemTemplate>
                                <asp:Label ID="lblDatumPosudbe" runat="server" Text='<%#Eval("DatumPosudbe","{0:MMMM d, yyyy}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Datum Povrata">
                            <ItemTemplate>
                                <asp:Label ID="lblDatumPovrata" runat="server" Text='<%# Eval("DatumPovrata","{0:MMMM d, yyyy}") %>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="idFilm" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdFilm" runat="server" Text='<%#Eval("idFilm") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="idKorisnik" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdKorisnik" runat="server" Text='<%#Eval("idKorisnik") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="idTipMedija" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdTipMedija" runat="server" Text='<%#Eval("idTipmedija") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>



                    </Columns>


                </asp:GridView>

            </div>
        </div>
    </div>
     <script type="text/javascript">
        var confirmed = false;

        function ShowConfirm(controlID) {
            if (confirmed) { return true; }

            bootbox.confirm("Jeste li sigurni?", function (result) {
                if (result) {
                    if (controlID != null) {
                        var controlToClick = document.getElementById(controlID);
                        if (controlToClick != null) {
                            confirmed = true;
                            controlToClick.click();
                            confirmed = false;
                        }
                    }
                }

            });

            return false;

        }
    </script>
</asp:Content>

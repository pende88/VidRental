<%@ Page Title="Film" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Film.aspx.cs" Inherits="VideotekaClient.Film" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <script src="Scripts/bootbox.min.js"></script>

    <div class="container">
          <br />
    <br />
        <div class="row">
              <br />
    <br />
            <div class="col-md-8 col-md-offset-3">
                <div class="form-group form-inline">
                    <asp:Label ControlStyle-CssClass=" control-label col-sm-4"  AssociatedControlID="txtPretraga" ID="lblPretraga" runat="server" Text="Pretraži filmove:     "></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="txtPretraga" runat="server"></asp:TextBox>
                    <asp:Button CssClass="btn btn-default" ID="btnPretraga" runat="server" Text="Traži" OnClick="btnPretraga_Click" CausesValidation="false" />
              </div>
                </div>
            </div>
                <br />
                <br />
                <br />

        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <fieldset>
                    <legend>Film</legend>

                    <div class="form-group col-md-offset-1">
                        <asp:Label AssociatedControlID="txtFilmId" CssClass="control-label col-sm-2" ID="lblID" runat="server" Text="Film ID" Enabled="false"></asp:Label>
                        <div class="col-sm-10">
                        <asp:TextBox CssClass="form-control" ID="txtFilmId" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-offset-1"">
                        <asp:Label AssociatedControlID="txtNaziv" CssClass="control-label col-sm-2" ID="lblNaziv" runat="server" Text="Naziv:"></asp:Label>
                      <div class="col-sm-10">
                        <asp:TextBox CssClass="form-control" ID="txtNaziv" runat="server"></asp:TextBox>
                          <asp:CustomValidator ID="validatorTxtNaziva" runat="server" ErrorMessage="Molimo unesite naziv filma" OnServerValidate="validatorTxtNaziva_ServerValidate"></asp:CustomValidator>
                    </div>
                      </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-sm-2" ID="ddlLabel" runat="server" Text="Zanr:" AssociatedControlID="ddlZanr"></asp:Label>
                       <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlZanr" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="Id" DataTextField="Naziv">
                            <Items>
                                <asp:ListItem Text="Odaberi kategoriju" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                                                   <asp:CustomValidator ID="validatorDdlZanr" runat="server" ErrorMessage="Molimo odaberite zanr" OnServerValidate="validatorDdlZanr_ServerValidate"></asp:CustomValidator>

                           </div>
                    </div>

                    <div class="form-group">
                        <asp:Label AssociatedControlID="txtGodina" CssClass="control-label col-sm-2" ID="lblGodina" runat="server" Text="Godina:"></asp:Label>
                                             <div class="col-sm-10">
                
                                                 <asp:TextBox CssClass="form-control" ID="txtGodina" runat="server"></asp:TextBox>
                                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtGodina" DaysModeTitleFormat="yyyy" DefaultView="Years" Format="yyyy" TodaysDateFormat="yyyy" />
                                                 
                                                
                                                 <asp:CustomValidator ID="validatorTxtGodina" runat="server" ErrorMessage="Molimo unesite godinu u formatu yyyy" OnServerValidate="validatorTxtGodina_ServerValidate"></asp:CustomValidator>
                   </div>
                    </div>
                    <div class="form-group">
                       <div class="col-sm-10 col-sm-offset-2">
                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click1" />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnSave_Click1" />
                        <asp:Button CssClass="btn btn-default" ID="btnDeleteSafe" runat="server" Text="Delete Safe" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDeleteSafe_Click" CausesValidation="false" />
                        <asp:Button CssClass="btn btn-default" ID="btnDeletFull" runat="server" Text="Delete Full" OnClick="btnDeletFull_Click" OnClientClick="return ShowConfirm(this.id);" CausesValidation="false" />
                        <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"  CausesValidation="false"/>
                             </div>
                    </div>

                </fieldset>
                <br />
                <asp:Label CssClass="col-md-offset-2" ID="lblStatus" runat="server" Text="" Visible="true"></asp:Label>
                <br />
                <br />
                <asp:GridView ShowHeaderWhenEmpty="True" CssClass="table table-hover table-striped table-responsive table-bordered" GridLines="None" ID="GridViewFilm" DataKeyNames="IdFilm" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewFilm_SelectedIndexChanged">
                    <Columns>

                        <asp:TemplateField HeaderText="Id Filma" visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIdFilm" runat="server" Text='<%#Eval("IdFilm") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Naziv Filma">
                            <ItemTemplate>
                                <asp:Label ID="lblNaziv" runat="server" Text='<%#Eval("naziv") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Zanrid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="labelaDropdown" runat="server" Text='<%#Eval("zanrId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Naziv Žanra">
                            <ItemTemplate>
                                
                                <asp:Label ID="lblNazivZanra"   runat="server" Text='<%# Eval("FilmZanr") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Godina">
                            <ItemTemplate>
                                <asp:Label ID="lblGodina" runat="server" Text='<%#Eval("godina") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false"/>
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

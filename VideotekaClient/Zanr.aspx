<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zanr.aspx.cs" Inherits="VideotekaClient.Zanr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/bootbox.min.js"></script>




    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">

            <div class="col-md-8 col-md-offset-2">
                <fieldset>
                <legend>Žanr</legend>

                <div class="form-group">


                    <asp:Label ID="lblID" AssociatedControlID="txtID" ControlStyle-CssClass=" control-label  col-sm-2 " runat="server" Enabled="false">Zanr Id Proba</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>

                    </div>


                </div>

                <div class="form-group">
                    <asp:Label ID="lblNaziv" AssociatedControlID="txtNaziv" CssClass="control-label col-sm-2" runat="server">Naziv Žanra:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNaziv" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nazivValidator" runat="server" ErrorMessage="Naziv Žanra je obavezan." ControlToValidate="txtNaziv"></asp:RequiredFieldValidator>
                    </div>


                </div>
                <div class="form-group">
                    <div class="col-sm-10 col-sm-offset-2">
                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click1" />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnSave_Click1" />
                         <asp:Button CssClass="btn btn-default" ID="btnDeleteSafe" runat="server" Text="Delete Safe" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDeleteSafe_Click" CausesValidation="false"/>
                         <asp:Button CssClass="btn btn-default" ID="btnDeleteFull" runat="server" Text="Delete Full" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDeleteFull_Click" CausesValidation="false"/>

                        <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false"/>
                    </div>

                </div>
                    </fieldset>
                <asp:Label ID="lblStatus" runat="server" Text="" CssClass="col-md-offset-1"></asp:Label>



                <br />
                <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewZanr" DataKeyNames="Id" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewZanr_SelectedIndexChanged">

                    <Columns>

                        <asp:TemplateField HeaderText="Id Zanra" ControlStyle-CssClass="col-sm-5">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Naziv Žanra" ControlStyle-CssClass="col-sm-5">
                            <ItemTemplate>
                                <asp:Label ID="lblNaziv" runat="server" Text='<%#Eval("Naziv") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="col-sm-2">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Klijent.aspx.cs" Inherits="VideotekaClient.Klijent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <script src="Scripts/bootbox.min.js"></script>

    <div class="row">


        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Klijent</legend>

                <div class="form-group">
                    <asp:Label ID="lblID" ControlStyle-CssClass="control-label  col-sm-2" runat="server">ID Korisnik:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtID" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtIme" ID="lblIme" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Ime:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIme" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtIme"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtPrezime" ID="lblPrezime" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Prezime:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPrezime" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPrezime"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtAdresa" ID="lblAdresa" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Adresa:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAdresa" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtAdresa"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtGrad" ID="lblGrad" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Grad:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtGrad" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtGrad"></asp:RequiredFieldValidator>

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
            </div>
        </div>
  
    <br />
    <asp:Label ID="statusLbl" runat="server" Text="" CssClass="col-md-offset-4"></asp:Label>
    <br />
    <div class="row">
        <div class="col-md-offset-2 col-md-8 ">
        <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewKlijent" DataKeyNames="id" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewKlijent_SelectedIndexChanged">

            <Columns>

                <asp:TemplateField HeaderText="Id Klijent">
                    <ItemTemplate>
                        <asp:Label ID="lblKlijent" runat="server" Text='<%#Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ime">
                    <ItemTemplate>
                        <asp:Label ID="lblIme" runat="server" Text='<%#Eval("ime") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prezime">
                    <ItemTemplate>
                        <asp:Label ID="lblPrezime" runat="server" Text='<%#Eval("prezime") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Adresa">
                    <ItemTemplate>
                        <asp:Label ID="lblAdresa" runat="server" Text='<%#Eval("adresa") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Grad">
                    <ItemTemplate>
                        <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("grad") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>


        </asp:GridView>
            </div>

        <div class="com-md-2"></div>
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

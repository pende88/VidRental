using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideotekaClient
{
    public partial class Film : System.Web.UI.Page
    {
        VideoReference.IService1 proxy = new VideoReference.Service1Client();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                FillDdl();
                
            }

            btnUpdate.Enabled = false;
            btnDeletFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnSave.Enabled = true;


        }

        private void FillDdl()
        {
           
            ddlZanr.DataSource = proxy.GetZanr();
            ddlZanr.DataBind();

        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                VideoReference.Film f = new VideoReference.Film();

                f.idFilm = txtFilmId.Text == "" ? 0 : Convert.ToInt32(txtFilmId.Text);

                f.naziv = txtNaziv.Text;

                f.zanrId = Convert.ToInt32(ddlZanr.SelectedValue);

                f.godina = txtGodina.Text;

                proxy.AddUppFilm(f);

                FillGridView();

                lblStatus.Text = "Operacija uspješno spremljena";

                ClearAll();
            }

            



        }


        void FillGridView()
        {
            GridViewFilm.DataSource = proxy.GetFilmZanr();
            GridViewFilm.DataBind();
        }



        protected void GridViewFilm_SelectedIndexChanged(object sender, EventArgs e)
        {


            txtFilmId.Text = GridViewFilm.DataKeys[GridViewFilm.SelectedRow.RowIndex].Value.ToString();

            txtNaziv.Text = (GridViewFilm.SelectedRow.FindControl("lblNaziv") as Label).Text;

            string probaZanr = (GridViewFilm.SelectedRow.FindControl("labelaDropdown") as Label).Text.Trim();
            if (probaZanr == "0")
            {
                ddlZanr.SelectedValue = "";
            }
            else
            {
                ddlZanr.SelectedValue = (GridViewFilm.SelectedRow.FindControl("labelaDropdown") as Label).Text.Trim();

            }

            txtGodina.Text = (GridViewFilm.SelectedRow.FindControl("lblGodina") as Label).Text;

            btnSave.Enabled = false;
            btnDeletFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnUpdate.Enabled = true;
        }



        private void ClearAll()
        {
           txtGodina.Text = txtNaziv.Text = txtFilmId.Text = "";
            
            btnSave.Enabled = true;
            btnDeleteSafe.Enabled = false;
            btnUpdate.Enabled = false;
            btnDeletFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            ddlZanr.SelectedIndex = 0;
            //txtPretraga.Text = "";
            FillGridView();
           
        }

        protected void btnDeleteSafe_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFilmId.Text);


            proxy.DeleteFilmSafe(id);
            int rezultat = (int) (proxy.DeleteFilmSafe(id));
            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeletFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnClear.Enabled = false;
            if(rezultat == 1)
            {
                lblStatus.Text = "Podaci nisu obrisani jer su vezani uz druge tablice, za potpuno brisanje koristite tipku Full Delete";
            }
            else
            {
                lblStatus.Text ="Podaci uspoješno obrisani";
            }


        }

        protected void btnDeletFull_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFilmId.Text);


            proxy.DeleteFilm(id);

            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnDeletFull.Enabled = false;
            btnClear.Enabled = false;

            lblStatus.Text = "Svi povezani podaci uspješno izbrisani";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtPretraga.Text = "";
        }

        protected void btnPretraga_Click(object sender, EventArgs e)
        {
            string naziv;
            naziv = txtPretraga.Text;
            GridViewFilm.DataSource = proxy.SearchFilm(naziv);
            GridViewFilm.DataBind();

            if(GridViewFilm.Rows.Count <= 0)
            {
                lblStatus.Text = "Nije pronađen niti jedan film koji odgovara vašem upitu";
            }
        
        }

        protected void validatorTxtNaziva_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(txtNaziv.Text == "")
            {
                args.IsValid = false;
            }
        }

        protected void validatorDdlZanr_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlZanr.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void validatorTxtGodina_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime godina;
            args.IsValid = DateTime.TryParseExact(txtGodina.Text, "yyyy", null, DateTimeStyles.None, out godina);
        }

        
    }
}
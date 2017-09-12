using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideotekaClient
{   
    public partial class Posudba : System.Web.UI.Page
    {
        VideoReference.IService1 proxy = new VideoReference.Service1Client();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                FillDdlTipMedija();
                FillDdlKlijent();
                FillDdlFilmovi();


                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                
            }
            


        }

       

        private void FillDdlFilmovi()
        {



            ddlFilm.DataSource = proxy.GetFilmDDL();

            ddlFilm.DataBind();
           

            ddlZauzetiFilmovi.DataSource = proxy.GetSlobodniFilmovi();
            ddlZauzetiFilmovi.DataBind();

            ReFillDDLfilmovi();

        }

        public void ReFillDDLfilmovi()
        {
            foreach (ListItem li in ddlFilm.Items)
            {
                if (ddlZauzetiFilmovi.Items.Contains(li))
                {
                    li.Attributes.Add("disabled", "disabled");
                }
            }
        }

        private void FillDdlTipMedija()
        {

            ddlTipMedija.DataSource = proxy.GetTipMedija();
            ddlTipMedija.DataBind();

        }

        private void FillDdlKlijent()
        {
            
            ddlKlijent.DataSource = proxy.GetKlijentDDL();
            ddlKlijent.DataBind();
        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
           
            if(Page.IsValid)
            {
                VideoReference.Posudba p = new VideoReference.Posudba();

                p.id = txtIdPosudbe.Text == "" ? 0 : Convert.ToInt32(txtIdPosudbe.Text);

                p.idFilm = Convert.ToInt32(ddlFilm.SelectedValue);

                p.idKorisnik = Convert.ToInt32(ddlKlijent.SelectedValue);

                p.idFilm = Convert.ToInt32(ddlFilm.SelectedValue);

                p.idTipmedija = Convert.ToInt32(ddlTipMedija.SelectedValue);

                

                p.datumPosudbe = Convert.ToDateTime(txtDatumPosudbe.Text);

                string DatumPovrata = txtDatumPovrata.Text;

                if(DatumPovrata == "")
                {
                    p.datumPovrata = new DateTime(1800,1,1);
                }
                else
                {
                   p.datumPovrata = Convert.ToDateTime(txtDatumPovrata.Text);
                }
                

                statusLabel.Text = "Operacija uspješno izvršena";

                

                proxy.AddUppPosudba(p);

                FillGridView();
                FillDdlFilmovi();
                ClearAll();
                
            }

            



        }


        void FillGridView()
        {
            GridViewPosudba.DataSource = proxy.GetAktivnaPosudba();
            GridViewPosudba.DataBind();
        }


        private void ClearAll()
        {
            txtIdPosudbe.Text = "";
            ddlFilm.SelectedIndex = 0;
            ddlKlijent.SelectedIndex = 0;
            ddlTipMedija.SelectedIndex = 0;
            

            txtDatumPosudbe.Text = txtDatumPovrata.Text = "";
            txtDatumPovrata.Text = txtDatumPovrata.Text = "";




            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;


            FillGridView();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdPosudbe.Text);

            proxy.DeletePosudba(id);
            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;

            FillDdlFilmovi();

            statusLabel.Text = "Uspješno obrisano";

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
          
        }

        protected void GridViewPosudba_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

            txtIdPosudbe.Text = GridViewPosudba.DataKeys[GridViewPosudba.SelectedRow.RowIndex].Value.ToString();

            string probaFilm = (GridViewPosudba.SelectedRow.FindControl("lblIdFilm") as Label).Text.Trim();
            if(probaFilm == "0")
            {
                ddlFilm.SelectedValue = "";
            }
            else
            {
               ddlFilm.SelectedValue = (GridViewPosudba.SelectedRow.FindControl("lblIdFilm") as Label).Text.Trim();
            }


            string probaKlijent = (GridViewPosudba.SelectedRow.FindControl("lblIdKorisnik") as Label).Text.Trim();
            if(probaKlijent == "0")
            {
                ddlKlijent.SelectedValue = "";
            }
            else
            {
                ddlKlijent.SelectedValue = (GridViewPosudba.SelectedRow.FindControl("lblIdKorisnik") as Label).Text.Trim();

            }

            ddlTipMedija.SelectedValue = (GridViewPosudba.SelectedRow.FindControl("lblIdTipMedija") as Label).Text.Trim();



            txtDatumPovrata.Text = (GridViewPosudba.SelectedRow.FindControl("lblDatumPovrata") as Label).Text.Trim();

           
            txtDatumPosudbe.Text = (GridViewPosudba.SelectedRow.FindControl("lblDatumPosudbe") as Label).Text.Trim();


            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;


        }

      

       

        protected void validatorDdlFilm_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ddlFilm.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void validatorDdlTipMedija_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTipMedija.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void validatorDdlKlijent_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlKlijent.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
           

            DateTime povrat;
            args.IsValid = DateTime.TryParseExact(txtDatumPovrata.Text, "MMMM d, yyyy", null, DateTimeStyles.None, out povrat);



            string provjera = txtDatumPovrata.Text;

            if (provjera == "")
            {
                args.IsValid = true;
            }




        }

        protected void validatorDatumaPosudbe_ServerValidate(object source, ServerValidateEventArgs args)
        {

            DateTime posudba;
            args.IsValid = DateTime.TryParseExact(txtDatumPosudbe.Text, "MMMM d, yyyy", null, DateTimeStyles.None, out posudba);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideotekaClient
{
    public partial class Klijent : System.Web.UI.Page
    {
        VideoReference.IService1 proxy = new VideoReference.Service1Client();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }
            btnUpdate.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnDeleteFull.Enabled = false;
            btnSave.Enabled = true;



        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                VideoReference.Klijent k = new VideoReference.Klijent();

                k.id = txtID.Text == "" ? 0 : Convert.ToInt32(txtID.Text);

                k.ime = txtIme.Text;
                k.prezime = txtPrezime.Text;
                k.adresa = txtAdresa.Text;
                k.grad = txtGrad.Text;

                statusLbl.Text = "Operacija uspješno izvršena";
                proxy.AddUppKlijent(k);
                ClearAll();
                FillGridView();

            }



        }


        void FillGridView()
        {
            GridViewKlijent.DataSource = proxy.GetKlijent();
            GridViewKlijent.DataBind();
        }



        protected void GridViewKlijent_SelectedIndexChanged(object sender, EventArgs e)
        {


            txtID.Text = GridViewKlijent.DataKeys[GridViewKlijent.SelectedRow.RowIndex].Value.ToString();

            txtIme.Text = (GridViewKlijent.SelectedRow.FindControl("lblIme") as Label).Text;
            txtPrezime.Text = (GridViewKlijent.SelectedRow.FindControl("lblPrezime") as Label).Text;
            txtAdresa.Text = (GridViewKlijent.SelectedRow.FindControl("lblGrad") as Label).Text;
            txtGrad.Text = (GridViewKlijent.SelectedRow.FindControl("lblAdresa") as Label).Text;

            statusLbl.Text = "";

            btnSave.Enabled = false;
            btnDeleteSafe.Enabled = true;
            btnDeleteFull.Enabled = true;
            btnUpdate.Enabled = true;
        }



        private void ClearAll()
        {
            txtIme.Text = txtID.Text = "";
            txtPrezime.Text = txtID.Text = "";
            txtAdresa.Text = txtID.Text = "";
            txtGrad.Text = txtID.Text = "";

           // statusLbl.Text = "";

            btnSave.Enabled = true;
            btnDeleteSafe.Enabled = false;
            btnUpdate.Enabled = false;
            btnDeleteFull.Enabled = false;
        }

        protected void btnDeleteSafe_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);


            proxy.DeleteKlijentSafe(id);
            int rezultat = (int)(proxy.DeleteKlijentSafe(id));
            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeleteFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnClear.Enabled = false;
            if (rezultat == 1)
            {
                statusLbl.Text = "Podaci nisu obrisani jer su vezani uz druge tablice, za potpuno brisanje koristite tipku Full Delete";
            }
            else
            {
                statusLbl.Text = "Podaci uspoješno obrisani";
            }

        }

        protected void btnDeleteFull_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);


            proxy.DeleteKlijentSafe(id);

            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnDeleteFull.Enabled = false;
            btnClear.Enabled = false;

            statusLbl.Text = "Svi povezani podaci uspješno izbrisani";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            statusLbl.Text = "";
        }

       

        
    }
}


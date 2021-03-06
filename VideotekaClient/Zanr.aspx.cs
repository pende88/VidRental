﻿using System;
using System.Web.UI.WebControls;


namespace VideotekaClient
{
    public partial class Zanr : System.Web.UI.Page
    {

        VideoReference.IService1 proxy = new VideoReference.Service1Client();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }

            btnUpdate.Enabled = false;
            btnDeleteFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnSave.Enabled = true;


        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                VideoReference.Zanr z = new VideoReference.Zanr();

                z.Id = txtID.Text == "" ? 0 : Convert.ToInt32(txtID.Text);

                z.Naziv = txtNaziv.Text;

                proxy.AddUppZanr(z);

                FillGridView();
                

                lblStatus.Text ="Podaci uspješno spremljeni";

            }

            



        }


        void FillGridView()
        {
            GridViewZanr.DataSource = proxy.GetZanr();
            GridViewZanr.DataBind();
        }



        protected void GridViewZanr_SelectedIndexChanged(object sender, EventArgs e)
        {


            txtID.Text = GridViewZanr.DataKeys[GridViewZanr.SelectedRow.RowIndex].Value.ToString();

            txtNaziv.Text = (GridViewZanr.SelectedRow.FindControl("lblNaziv") as Label).Text;

            btnSave.Enabled = false;
            btnDeleteFull.Enabled = true;
            btnUpdate.Enabled = true;

            btnUpdate.Enabled = true;
            btnDeleteSafe.Enabled = true;
            btnSave.Enabled = false;
            lblStatus.Text = "";
        }

        

        private void ClearAll()
        {
            txtNaziv.Text = txtID.Text = "";
            btnSave.Enabled = true;
            btnDeleteFull.Enabled = false;
            btnUpdate.Enabled = false;
            btnDeleteSafe.Enabled = false;
           // lblStatus.Text = "";
        }

        protected void btnDeleteSafe_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);


            proxy.DeleteZanrSafe(id);
            int rezultat = (int)(proxy.DeleteZanrSafe(id));
            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeleteFull.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnClear.Enabled = false;
            if (rezultat == 1)
            {
                lblStatus.Text = "Podaci nisu obrisani jer su vezani uz druge tablice, za potpuno brisanje koristite tipku Full Delete";
            }
            else
            {
                lblStatus.Text = "Podaci uspješno obrisani";
            }

        }

        protected void btnDeleteFull_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);


            proxy.deleteZanr(id);

            ClearAll();
            FillGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDeleteSafe.Enabled = false;
            btnDeleteFull.Enabled = false;
            btnClear.Enabled = false;

            lblStatus.Text = "Svi povezani podaci uspješno izbrisani";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            lblStatus.Text = "";
        }

       
    }
}
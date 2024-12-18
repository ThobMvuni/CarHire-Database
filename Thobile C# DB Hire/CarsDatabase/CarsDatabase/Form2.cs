﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading; 

namespace CarsDatabase
{
    public partial class frmSearch :  Form

    {
       

 SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");

 DataTable dtbl = new DataTable();
 public frmSearch()
 {
     InitializeComponent();
 }


  private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            frmCars frc = new frmCars();
            frc.Show();
        }

        private void btnRun_Click(object sender, EventArgs e)
       {
          SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
           SqlDataAdapter sda = new SqlDataAdapter("Select Available From tblCar", Con);
           DataTable dt = new DataTable();
            
            try
            {
                SqlCommand cmd = new SqlCommand("Select Available From tblCar", Con);
                Con.Open();
                
               
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtValue.Text = dr[1].ToString();
                
 
                }
                dr.Close();
            }
        
        catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
            {

       if (Con.State == ConnectionState.Open)
                {
    
      
           Con.Close();
       }
}
}
    


            private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

          

            private void txtValue_TextChanged(object sender, EventArgs e)
            {
             if (cboOperator.Text == "=" )
                {
                SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where '=' like '" + txtValue.Text+ "%' ", Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dgvSearch.DataSource = dtbl;
                }

                else if (cboOperator.Text == "<")
                {
                SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where ' <' like '" + txtValue.Text+ "%'  ", Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dgvSearch.DataSource = dtbl;
                }
                else if (cboOperator.Text == ">")
                {
                     SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where '>' like '" + txtValue.Text+ "%' ", Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dgvSearch.DataSource = dtbl;
                }
                else if (cboOperator.Text == "=<")
                {
                     SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where =< like '" + txtValue.Text+ "%' ", Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dgvSearch.DataSource = dtbl;
                }
                else if (cboOperator.Text == "=>")
                {
                 SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where => like '" + txtValue.Text+ "%' ", Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dgvSearch.DataSource = dtbl;
                }

             
              if (cboField.Text == "Make")
             {
                 SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                 SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where Make like '" + txtValue.Text + "%' ", Con);
                 DataTable dtbl = new DataTable();
                 sda.Fill(dtbl);
                 dgvSearch.DataSource = dtbl;
             }
             else if (cboField.Text == "EngineSize")
             {
                 SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                 SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where EngineSize like '" + txtValue.Text + "%' ", Con);
                 DataTable dtbl = new DataTable();
                 sda.Fill(dtbl);
                 dgvSearch.DataSource = dtbl;
             }
             

             else if (cboField.Text == "RentalPerDay")
             {
                 SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                 SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where RentalPerDay like '" + txtValue.Text + "%' ", Con);
                 DataTable dtbl = new DataTable();
                 sda.Fill(dtbl);
                 dgvSearch.DataSource = dtbl;
             }
             else if (cboField.Text == "Available ")
             {
                 SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
                 SqlDataAdapter sda = new SqlDataAdapter("SELECT VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available FROM tblCar where Available like '" + txtValue.Text + "%' ", Con);
                 DataTable dtbl = new DataTable();
                 sda.Fill(dtbl);
                 dgvSearch.DataSource = dtbl;
             }
            
                    
                
            }

        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
  
                

           

        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            cboField.Text = "Make";
            cboField.Text = "EngineSize";
            cboField.Text = "RentalPerDay";
            cboField.Text = "Available";

            cboOperator.Text = "=";
            cboOperator.Text = "<";
            cboOperator.Text = ">";
            cboOperator.Text = "<=";
            cboOperator.Text = ">=";
           
           

            // TODO: This line of code loads data into the 'hireDataSet.tblCar' table. You can move, or remove it, as needed.
            this.tblCarTableAdapter.Fill(this.hireDataSet.tblCar);
            DataGridViewComboBoxColumn dgvSearch = new DataGridViewComboBoxColumn();
        }

        
            
            

            


        }
        
           
            

            }

      
     
      
          

           
                  
  



           

    

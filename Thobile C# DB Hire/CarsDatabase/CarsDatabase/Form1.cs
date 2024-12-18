﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace CarsDatabase
{
    public partial class frmCars : Form
        
    {   
        


        SqlConnection Con = new SqlConnection(@"Data Source=MVUNI\SQLEXPRESS;Initial Catalog=Hire;Integrated Security=True");
     

        SqlDataAdapter  adapter;
        DataTable dtbl = new DataTable();
        int pos = 1;
        int length = 1;


        

        public frmCars()
        {
            InitializeComponent();

            }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch openForm =  new frmSearch();
            openForm.Show();
            Visible = false;
        }

           
        // clears the texbox and the checbox
         private void btnCancel_Click(object sender, EventArgs e)
        {
            txtVehicleNo.Text = "";
            txtMake.Text = "";
            txtRent.Text = "";
            txtDate.Text = "";
            chkAvailable.Checked = false;
            txtEngineSize.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            string VehicleRegNo = txtVehicleNo.Text.ToString();
            string Make = txtMake.Text.ToString();
            string EngineSize = txtEngineSize.Text;
            string DateRegistered =  Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy");
            Double i;
            Double.TryParse(txtRent.Text, out i);
            string Rent = i.ToString(",00");
            bool Available = Convert.ToBoolean(chkAvailable.Checked);

            try
            {
                SqlCommand sqlCmd = Con.CreateCommand();
                SqlCommand sqlcmd = new SqlCommand("insert into tblCar values(VehiclRegNo ='" + txtVehicleNo.Text + "', Make= '" + txtMake.Text + "',Rent='" + txtRent.Text + "',EngSize= '" + txtEngineSize.Text + "',DateReg= '" + txtDate.Text + "', Available= '" + chkAvailable.Checked + "')", Con);
                Con.Open();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();



            }
            catch 
            {
                MessageBox.Show("Recorders Added Successfully");
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

   private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string VehicleRegNo = txtVehicleNo.Text.ToString();
            string Make = txtMake.Text.ToString();
            string EngineSize = txtEngineSize.Text;
            string DateRegistered =Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy");
            Double i;
            Double.TryParse(txtRent.Text, out i);
            string Rent = i.ToString(",00");
            bool Available = Convert.ToBoolean(chkAvailable.Checked);

           try
            {
                SqlCommand sqlcmd = Con.CreateCommand();
                SqlCommand cmdUpdate = new SqlCommand("Update tblcar SET VehicleRegNo= " + txtVehicleNo.Text + ", Make= " + txtMake.Text + ",Rent='" + txtRent.Text + ",EngSize= " + txtEngineSize.Text + ",DateReg= " + txtDate.Text + ", Available= " + chkAvailable.Checked + "", Con);
                Con.Open();
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.ExecuteNonQuery();


               

            }
            catch 
            {
                MessageBox.Show( "Recorders Updated Successfully");
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string VehicleRegNo = txtVehicleNo.Text.ToString();
            string Make = txtMake.Text.ToString();
            string EngineSize = txtEngineSize.Text;
             string DateRegistered = Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy");
             Double i;
             Double.TryParse(txtRent.Text, out i );
             string Rent = i.ToString(",00");
            bool Available = Convert.ToBoolean(chkAvailable.Checked);

            try
            {
                SqlCommand sqlcmd = Con.CreateCommand();
                SqlCommand cmddel = new SqlCommand("delete from tblcar where VehicleRegNo= " + txtVehicleNo.Text + "", Con);
                Con.Open();
                cmddel.CommandType = CommandType.Text;
                cmddel.ExecuteNonQuery();

            }
            catch 
            {
                MessageBox.Show("Recorders Deleted Successfully");
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos =  1;
            showData(pos);
            txtnn.Text = pos.ToString();
        }

        private void frmCars_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtDate, "Enter a date");
            toolTip1.SetToolTip(txtEngineSize, "Enter the engine size");
            toolTip1.SetToolTip(txtMake, "Enter the Make of the Car");
    
            adapter = new SqlDataAdapter("SELECT * FROM tblCar",Con);
            adapter.Fill(dtbl);
            showData(pos);

            while ((pos /= 14) >= 1)
            {
                length++;
            }

             

         
        }

         public void showData(int index)
        {
           txtVehicleNo.Text = dtbl.Rows[index][0].ToString();
            txtMake.Text= dtbl.Rows[index][1].ToString();
           txtEngineSize.Text= dtbl.Rows[index][2].ToString();
            txtDate.Text = dtbl.Rows[index][3].ToString();
            txtRent.Text = dtbl.Rows[index][4].ToString(); 
             bool chkAvailable = true;
             if (chkAvailable)
             {
                 dtbl.Rows[index][5].ToString();
             }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < dtbl.Rows.Count)
            {
               showData(pos);
               txtnn.Text = pos.ToString();
            }
            else
            {
                MessageBox.Show("End");
                pos = dtbl.Rows.Count - 1;
            } 
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
         pos = dtbl.Rows.Count - 1;
            showData(pos);
            txtnn.Text = pos.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
        pos--;
            if (pos >= 1)
            {
               showData(pos);
               txtnn.Text = pos.ToString();

            }

            else
            {
                MessageBox.Show("End");

            }

        }

        private void txtVehicleNo_TextChanged(object sender, EventArgs e)
        {

        }

        

       

        }


        }

  


            

        
    

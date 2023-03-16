using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Server =  DESKTOP-EFR1DG0\SQLEXPRESS02; Database = DotNet20Dec; Integrated Security = True;");

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into product3 values(@name,@comp,@price)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@comp", txtcompany.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtprice.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "update product3 set name=@name,company=@comp, price=@price where id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@comp", txtcompany.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtprice.Text));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record updated..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from product3 where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtname.Text = dr["name"].ToString();
                        txtcompany.Text = dr["company"].ToString();
                        txtprice.Text = dr["price"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from product3 where id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record deleted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnshowallproduct_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from product3";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dr);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}


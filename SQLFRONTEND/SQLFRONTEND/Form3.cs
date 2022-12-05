using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
/*
Stored procedure code

USE [CPSCBOOK]
GO
/****** Object:  StoredProcedure [dbo].[FormThree]    Script Date: 12/4/2022 8:02:23 PM *****
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[FormThree] (@COM nvarchar(4000), @Com_Title int, @COM_Time datetime)

AS
BEGIN
BEGIN TRY


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO COMMENT (COMMENT, Title_ID,Comment_Timestamp) VALUES(@COM,@Com_Title,@COM_Time)

	Select * from COMMENT

END TRY
BEGIN CATCH
print 'catch err!'
END CATCH
END
*/


namespace SQLFRONTEND
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //INSERT INTO JOB (JOB_ID, JOB_Description,JOB_Salary,JOB_Premium) VALUES(@JOB_ID,@JOB_Description,@JOB_Sala
        }

        private void buildAndDisplay(string pCOM, int pCOM_Title, DateTime pCOM_Time)
        {
            try
            {
                //Step 1: 
                //   SQL string is not passed as an argument to the constructor of
                //   the Command object...SP name will be assigned to the 
                //   Command object's Text property
                //   Also, the connection is assigned to the "Connection" property
                //   of the Command object ... not passed as second argument
                //   in constructor
                SqlConnection objConnection = new SqlConnection("Data Source=(local);initial catalog=CPSCBOOK; User ID=sa;Password=SQL2022");
                SqlCommand objCommand = new SqlCommand();


                //Step 2:  Assign property values to Coomand object
                objCommand.Connection = objConnection;
                objCommand.CommandText = "FormThree";
                objCommand.CommandType = CommandType.StoredProcedure;
                //Name of parameter(s) must match name in SP... data types must also be compatible
                objCommand.Parameters.AddWithValue("@COM", pCOM);
                objCommand.Parameters.AddWithValue("@COM_Title", pCOM_Title);
                objCommand.Parameters.AddWithValue("@COM_Time", pCOM_Time);

                //Step 3: Make DB connection
                objConnection.Open();

                //Step 4. Tell DBMS to execute SP .. the command objects "ExecuteNonQuery" method is
                //used when executing action queries
                objCommand.ExecuteNonQuery();
            }

            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    string comment = textBox2.Text;
                    DateTime time = Convert.ToDateTime(textBox3.Text);
                    buildAndDisplay(comment,id, time);
                    button1.Enabled = false;
                    MessageBox.Show("Record Inserted");
                }
                else
                {
                    MessageBox.Show("ERR in Input");
                    textBox1.Focus();
                }


            }
            catch
            {
                MessageBox.Show("Enter valid Title_ID");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    string comment = textBox2.Text;
                    DateTime time = Convert.ToDateTime(textBox3.Text);
                    buildAndDisplay(comment, id, time);
                    button1.Enabled = false;
                    MessageBox.Show("Record Inserted");
                }
                else
                {
                    MessageBox.Show("ERR in Input");
                    textBox1.Focus();
                }


            }
            catch
            {
                MessageBox.Show("Enter valid Title_ID");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}

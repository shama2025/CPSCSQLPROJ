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
namespace SQLFRONTEND
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        private void buildAndDisplay(int pTid, int pSid,string pbook_con, string pbook_type, long pIsbn, string pAuthorF, string pAuthorL, int pPubID, string pbookTitle,  DateTime pPubDate)
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
                objCommand.CommandText = "FormFour";
                objCommand.CommandType = CommandType.StoredProcedure;
                //Name of parameter(s) must match name in SP... data types must also be compatible
                objCommand.Parameters.AddWithValue("@title_id", pTid);
                objCommand.Parameters.AddWithValue("@staff_id", pSid);
                objCommand.Parameters.AddWithValue("@book_condition", pbook_con);
                objCommand.Parameters.AddWithValue("@book_type", pbook_type); 
                objCommand.Parameters.AddWithValue("@isbn", pIsbn);
                objCommand.Parameters.AddWithValue("@author_first", pAuthorF);
                objCommand.Parameters.AddWithValue("@autho_last", pAuthorL);
                objCommand.Parameters.AddWithValue("@pub_id", pPubID);
                objCommand.Parameters.AddWithValue("@book_title", pbookTitle);
                objCommand.Parameters.AddWithValue("@publish_date", pPubDate);
                //Step 3: Make DB connection
                objConnection.Open();
                //int pTid, int pSid,string pbook_con, string pbook_type, long pIsbn, string pAuthorF, string pAuthorL, int pPubID, string pbookTitle,  DateTime pPubDate
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
                    int Tid = Convert.ToInt32(textBox1.Text);
                    int Sid = Convert.ToInt32(textBox4.Text);
                    string book_condition = textBox5.Text;
                    string book_type = textBox6.Text;
                    long isbn = Convert.ToInt64(textBox7.Text);
                    string authorFirst = textBox8.Text;
                    string authorLast = textBox9.Text;
                    int publish_Id = Convert.ToInt32(textBox10.Text);
                    string book_title = textBox11.Text;
                    DateTime publish_date = Convert.ToDateTime(textBox12.Text);
                    buildAndDisplay(Tid,Sid,book_condition,book_type,isbn,authorFirst,authorLast,publish_Id,book_title,publish_date);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLFRONTEND
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // Overview:
            //  This method executes all the code to connect to the HRSQL database
            //  (Sql Server Version), instruct the database engine to process an embedded
            //  SQL string (inner join), and then display the result set to a 
            //  listbox.

            //  Since a static snapshot of the data is needed, the following ADO
            //  components are used:
            //  1.  Connection object to establish a connection to the DBMS/DB
            //  2.  A Command object to store the SQL string and instantiate a 
            //  3.  DataReader (like a fast foreward cursor on the client end)

            //  The ADO .NET DataReader is a good object to use in this situation because
            //  1. (Rapidly populate rows in a listbox then disconnects from the DB).
            //  2. The data is displayed in the same order that it occurs in the
            //     result set and is not traversed thereafter.
            //  3. *Note, it would be possible to manipulate fields of the current record
            //     if necessary.

            //  Summary:  This combination of ADO .NET objects is appropriate
            //    when you just want to display a result set on the client end 
            //    because it connects ==> passes SQL to DBMS Engine ==>
            //    returns result set to client (rapidly)one row at a time==>
            //    disconnects      (Rapidly populate rows in a listbox then disconnect from the DB)


            try
            {
                //Step 1: Create object from local variables
                SqlConnection objConnection = new SqlConnection("Data Source=(local);initial catalog=CPSCBOOK; User ID=sa;Password=SQL2022");
                SqlCommand objCommand = new SqlCommand("SELECT STAFF.Staff_FName from STAFF INNER JOIN BOOK ON BOOK.Staff_ID = STAFF.STAFF_ID GROUP BY Staff_FName HAVING COUNT(*) >1", objConnection);
                SqlDataReader objReader;

                //Step 2: Open Database conection 
                objConnection.Open();

                //Step 3:  Instruct DBMS to execute SQL...
                //         this also instantiates a DataReader object
                objReader = objCommand.ExecuteReader(); //executing the objcommand variable and reading and giving it to the objReader


                //Step 4:  Fetch data from result set 1 row at a time (connection open throughout)
                while (objReader.Read()) //while objReader.Read(a boolean method) can be read it will run the loop
                                         //pulls in the next row from the sql result set
                {
                    listBox1.Items.Add(objReader[0].ToString().PadRight(50) /*+ objReader[1].ToString().PadRight(55) + objReader[2].ToString().PadLeft(5)*/);

                }

                objConnection.Close(); //unnecessary because local variable loses scope and lifetime at end of
                //event method
            }

            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=TLzGIjWW6EY");
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

            try
            {
                //Step 1: Create object from local variables
                SqlConnection objConnection = new SqlConnection("Data Source=(local);initial catalog=CPSCBOOK; User ID=sa;Password=SQL2022");
                SqlCommand objCommand = new SqlCommand("SELECT STAFF.Staff_FName from STAFF INNER JOIN BOOK ON BOOK.Staff_ID = STAFF.STAFF_ID GROUP BY Staff_FName HAVING COUNT(*) >1", objConnection);
                SqlDataReader objReader;

                //Step 2: Open Database conection 
                objConnection.Open();

                //Step 3:  Instruct DBMS to execute SQL...
                //         this also instantiates a DataReader object
                objReader = objCommand.ExecuteReader(); //executing the objcommand variable and reading and giving it to the objReader


                //Step 4:  Fetch data from result set 1 row at a time (connection open throughout)
                while (objReader.Read()) //while objReader.Read(a boolean method) can be read it will run the loop
                                         //pulls in the next row from the sql result set
                {
                     listBox1.Items.Add(objReader[0].ToString().PadRight(50) /*+ objReader[1].ToString().PadRight(55) + objReader[2].ToString().PadLeft(5)*/);

                }

                objConnection.Close(); //unnecessary because local variable loses scope and lifetime at end of
                //event method
            }

            catch { }
        }
    }
    }


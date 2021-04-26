using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_And_MySQL
{
    public partial class Insert_Update_Delete_Search_Display : Form
    {
        public Insert_Update_Delete_Search_Display()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='test_db';username=root;password=");
        MySqlCommand command;
        private void Insert_Update_Delete_Search_Display_Load(object sender, EventArgs e)
        {
            populateDGV();
        }

        public void populateDGV()
        {
            // populate the datagridview
            string selectQuery = "SELECT * FROM users";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView_USERS.DataSource = table;
        }

        private void dataGridView_USERS_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView_USERS.CurrentRow.Cells[0].Value.ToString();
            textBoxFName.Text = dataGridView_USERS.CurrentRow.Cells[1].Value.ToString();
            textBoxLName.Text = dataGridView_USERS.CurrentRow.Cells[2].Value.ToString();
            textBoxAge.Text = dataGridView_USERS.CurrentRow.Cells[3].Value.ToString();
        }

        public void openConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query,connection);

                if(command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }

                else
                {
                    MessageBox.Show("Query Not Executed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                closeConnection();
            }
        }

        private void BTN_INSERT_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO users(fname, lname, age) VALUES('" + textBoxFName.Text + "','" + textBoxLName.Text + "'," + textBoxAge.Text +")";
            executeMyQuery(insertQuery);
            populateDGV();
        }

        private void BTN_UPDATE_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE users SET fname='"+textBoxFName.Text+"',lname='"+textBoxLName.Text+"',age="+textBoxAge.Text+" WHERE id ="+int.Parse(textBoxID.Text);
            executeMyQuery(updateQuery);
            populateDGV();
        }

        private void BTN_DELETE_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM users WHERE id = "+int.Parse(textBoxID.Text);
            executeMyQuery(deleteQuery);
            populateDGV();
        }

        private void BTN_SEARCH_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            string select = "SELECT * FROM users WHERE id = " + textBoxID.Text;
            command = new MySqlCommand(select,connection);
            openConnection();
            mdr = command.ExecuteReader();

            if(mdr.Read())
            {
                textBoxFName.Text = mdr.GetString("fname");
                textBoxLName.Text = mdr.GetString("lname");
                textBoxAge.Text = mdr.GetInt32("age").ToString();
            }
            else
            {
                MessageBox.Show("User Not Found");
            }

            closeConnection();
        }
     
    }
}

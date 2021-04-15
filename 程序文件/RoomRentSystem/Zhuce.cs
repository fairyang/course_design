using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomRentSystem
{
    public partial class Zhuce : Form
    {
        public Zhuce()
        {
            InitializeComponent();
        }
 
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user, pwd, id;
                user = textBox2.Text;
                pwd = textBox5.Text;
                id = "admin";
                if (comboBox2.SelectedItem.ToString().Equals("管理员"))
                { id = "admin"; }
                else if (comboBox2.SelectedItem.ToString().Equals("经理"))
                { id = "manager"; }
                else if (comboBox2.SelectedItem.ToString().Equals("员工"))
                { id = "worker"; }
                string sqltext2 = "insert into manageruser values('" + user + "','" + pwd + "','" + id + "')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext2, null);
                MessageBox.Show("注册成功");
                Login Login = new Login();
                this.Hide();
                Login.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Hide();
            Login.Show();
        }
    }
}

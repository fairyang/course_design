using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;

namespace RoomRentSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void labelclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                string username, password;
                string shenfen = "worker";
                string sqltext1;
                username = usertextBox.Text;
                password = textBoxpwd.Text;
                if (comboBox1.SelectedItem.ToString().Equals("管理员"))
                { shenfen = "admin"; }
                else if (comboBox1.SelectedItem.ToString().Equals("经理"))
                { shenfen = "manager"; }
                else if (comboBox1.SelectedItem.ToString().Equals("员工"))
                { shenfen = "worker"; }

                sqltext1 = "select password from manageruser where user='" + username + "'and shenfen ='"+ shenfen +"'";
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("用户名不存在");
                }
                else
                {
                    string truepwd = ds.Tables[0].Rows[0]["password"].ToString();
                    if (truepwd.CompareTo(password) == 0)
                    {
                        MainForm mainform = new MainForm(username,shenfen);
                        this.Hide();
                        mainform.Show();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void usertextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zhuce Zhuce = new Zhuce();
            this.Hide();
            Zhuce.Show();
        }
    }
}

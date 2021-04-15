﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomRentSystem
{
    public partial class Managerinf : Form
    {
        public Managerinf()
        {
            InitializeComponent();
        }

        private void Managerinf_Load(object sender, EventArgs e)
        {
            try
            {
                string sqltext1 = "select * from manageruser ";
                managerdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
                managerdataGridView.Columns["user"].HeaderText = "用户名";
                managerdataGridView.Columns["password"].HeaderText = "密码";
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user, pwd,id;
                user = textBox1.Text;
                pwd = textBox2.Text;
                id = "admin";
                if (comboBox1.SelectedItem.ToString().Equals("管理员"))
                { id = "admin"; }
                else if (comboBox1.SelectedItem.ToString().Equals("经理"))
                { id = "manager"; }
                else if (comboBox1.SelectedItem.ToString().Equals("员工"))
                { id = "worker"; }
                string sqltext1 = "insert into manageruser values('" + user + "','" + pwd + "','"+id+"')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                managerdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from manageruser ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string user, pwd,id;
                user = textBox1.Text;
                pwd = textBox2.Text;
                id = "admin";
                if (comboBox1.SelectedItem.ToString().Equals("管理员"))
                { id = "admin"; }
                else if (comboBox1.SelectedItem.ToString().Equals("经理"))
                { id = "manager"; }
                else if (comboBox1.SelectedItem.ToString().Equals("员工"))
                { id = "worker"; }
                string sqltext1 = "update manageruser set password='" + pwd + "',shenfen='"+id+"' where user='" + user + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                managerdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from manageruser ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string user;
                user = textBox1.Text;
                string sqltext1 = "delete from manageruser where user='" + user + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                managerdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from manageruser ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}

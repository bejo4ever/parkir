using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commons
{
    public partial class FormLogin : FormBase
    {
        private bool isDrag = false;
        private Point lastPosition;

        public FormLogin()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return txtUsername.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                Cursor = Cursors.Hand;
                lastPosition.X = e.X;
                lastPosition.Y = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                this.Left = this.Left + e.X - lastPosition.X;
                this.Top = this.Top + e.Y - lastPosition.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = false;
                Cursor = Cursors.Default;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                Cursor = Cursors.Hand;
                lastPosition.X = e.X;
                lastPosition.Y = e.Y;
            }
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                this.Left = this.Left + e.X - lastPosition.X;
                this.Top = this.Top + e.Y - lastPosition.Y;
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = false;
                Cursor = Cursors.Default;
            }
        }
    }
}
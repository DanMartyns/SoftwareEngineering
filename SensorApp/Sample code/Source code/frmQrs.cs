using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestBioLib
{
    public partial class frmQrs : Form
    {
        public frmQrs()
        {
            InitializeComponent();

            listBox1.Items.Clear();
            listBox1.Items.Add("QRS detected in BioLib:");

            listBox2.Items.Clear();
            listBox2.Items.Add("QRS detected use QrsDetector:");
        }

        public void SetQrs1(string text)
        {
            listBox1.Items.Add(text);
        }

        public void SetQrs2(string text)
        {
            listBox2.Items.Add(text);
        }
    }
}

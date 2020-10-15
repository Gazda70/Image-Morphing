using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace ImageMorphing
{
    public partial class Form1 : Form
    {
        private test myTest;
        public Form1()
        {
            myTest = new test();
            InitializeComponent();
        }
    }
}

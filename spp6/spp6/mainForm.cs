using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spp6
{
    delegate void InputStrDelegate(string str);
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        public void AddLogInfo(string str)
        {
            if (InvokeRequired)
            {
                Invoke(new InputStrDelegate(AddLogInfo), str);
            }
            else
            {
                textBoxLog.AppendText(str);
            }
        }

        private void buttonCreateThread_Click(object sender, EventArgs e)
        {
            var myThreadPool = new ThreadPool();
        }
    }
}

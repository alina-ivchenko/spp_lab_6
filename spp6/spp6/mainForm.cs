using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace spp6
{
    delegate void InputStrDelegate(string str);
    public partial class mainForm : Form
    {
        private ThreadPool myThreadPool;
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
            int min = 0;
            int max = 0;
            try
            {
                min = Int32.Parse(textBoxMin.Text);
                if (min < 2)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("min не огонь! Берем 2.");
            }

            try
            {
                max = Int32.Parse(textBoxMax.Text);
                if ((max < 2) || (max < min))
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("max не огонь! Берем 5.");
            }
            myThreadPool = new ThreadPool(min, max);
            buttonCreateThread.Enabled = false;
        }

        private void buttonTestTask_Click(object sender, EventArgs e)
        {
            if (myThreadPool != null)
                myThreadPool.AddTask(() =>
                {
                    Log.Show("Тест" + Environment.NewLine);
                    Thread.Sleep(1000);
                });
        }
    }
}

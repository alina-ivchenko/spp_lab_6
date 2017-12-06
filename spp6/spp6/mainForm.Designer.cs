namespace spp6
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonCreateThread = new System.Windows.Forms.Button();
            this.buttonTestTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 78);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(428, 172);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonCreateThread
            // 
            this.buttonCreateThread.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonCreateThread.Location = new System.Drawing.Point(12, 12);
            this.buttonCreateThread.Name = "buttonCreateThread";
            this.buttonCreateThread.Size = new System.Drawing.Size(133, 54);
            this.buttonCreateThread.TabIndex = 1;
            this.buttonCreateThread.Text = "Создать пул потоков";
            this.buttonCreateThread.UseVisualStyleBackColor = false;
            this.buttonCreateThread.Click += new System.EventHandler(this.buttonCreateThread_Click);
            // 
            // buttonTestTask
            // 
            this.buttonTestTask.Location = new System.Drawing.Point(184, 16);
            this.buttonTestTask.Name = "buttonTestTask";
            this.buttonTestTask.Size = new System.Drawing.Size(49, 47);
            this.buttonTestTask.TabIndex = 2;
            this.buttonTestTask.Text = "+";
            this.buttonTestTask.UseVisualStyleBackColor = true;
            this.buttonTestTask.Click += new System.EventHandler(this.buttonTestTask_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 262);
            this.Controls.Add(this.buttonTestTask);
            this.Controls.Add(this.buttonCreateThread);
            this.Controls.Add(this.textBoxLog);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonCreateThread;
        private System.Windows.Forms.Button buttonTestTask;
    }
}


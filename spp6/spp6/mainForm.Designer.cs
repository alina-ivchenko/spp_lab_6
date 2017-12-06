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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonCreateThread = new System.Windows.Forms.Button();
            this.buttonTestTask = new System.Windows.Forms.Button();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.buttonCreateThread.Location = new System.Drawing.Point(233, 12);
            this.buttonCreateThread.Name = "buttonCreateThread";
            this.buttonCreateThread.Size = new System.Drawing.Size(133, 54);
            this.buttonCreateThread.TabIndex = 1;
            this.buttonCreateThread.Text = "Создать пул потоков";
            this.buttonCreateThread.UseVisualStyleBackColor = false;
            this.buttonCreateThread.Click += new System.EventHandler(this.buttonCreateThread_Click);
            // 
            // buttonTestTask
            // 
            this.buttonTestTask.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTestTask.BackgroundImage")));
            this.buttonTestTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTestTask.Location = new System.Drawing.Point(386, 12);
            this.buttonTestTask.Name = "buttonTestTask";
            this.buttonTestTask.Size = new System.Drawing.Size(54, 54);
            this.buttonTestTask.TabIndex = 2;
            this.buttonTestTask.Text = "+";
            this.buttonTestTask.UseVisualStyleBackColor = true;
            this.buttonTestTask.Click += new System.EventHandler(this.buttonTestTask_Click);
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(47, 15);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(168, 20);
            this.textBoxMin.TabIndex = 3;
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(47, 46);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(168, 20);
            this.textBoxMax.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "max";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.textBoxMin);
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
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


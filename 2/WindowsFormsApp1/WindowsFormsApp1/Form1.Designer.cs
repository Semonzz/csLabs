using System.Windows.Forms;

namespace lab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.showMatrixButton = new System.Windows.Forms.Button();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.widthTrackBar = new System.Windows.Forms.TrackBar();
            this.heightTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelError = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.widthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // showMatrixButton
            // 
            this.showMatrixButton.Location = new System.Drawing.Point(349, 165);
            this.showMatrixButton.Name = "showMatrixButton";
            this.showMatrixButton.Size = new System.Drawing.Size(115, 72);
            this.showMatrixButton.TabIndex = 0;
            this.showMatrixButton.Text = "Показать матрицу";
            this.showMatrixButton.UseVisualStyleBackColor = true;
            this.showMatrixButton.Click += new System.EventHandler(this.showMatrixButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.Location = new System.Drawing.Point(12, 68);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(331, 199);
            this.inputPanel.TabIndex = 2;
            // 
            // outputPanel
            // 
            
                this.outputPanel.Location = new System.Drawing.Point(470, 68);
                this.outputPanel.Name = "outputPanel";
                this.outputPanel.Size = new System.Drawing.Size(318, 199);
                this.outputPanel.TabIndex = 3;
           
            // 
            // widthTrackBar
            // 
            this.widthTrackBar.Location = new System.Drawing.Point(15, 12);
            this.widthTrackBar.Maximum = 6;
            this.widthTrackBar.Minimum = 1;
            this.widthTrackBar.Name = "widthTrackBar";
            this.widthTrackBar.Size = new System.Drawing.Size(104, 56);
            this.widthTrackBar.TabIndex = 4;
            this.widthTrackBar.Value = 3;
            this.widthTrackBar.Scroll += new System.EventHandler(this.WidthTrackBar_Scroll);
            // 
            // heightTrackBar
            // 
            this.heightTrackBar.Location = new System.Drawing.Point(150, 12);
            this.heightTrackBar.Maximum = 6;
            this.heightTrackBar.Minimum = 1;
            this.heightTrackBar.Name = "heightTrackBar";
            this.heightTrackBar.Size = new System.Drawing.Size(104, 56);
            this.heightTrackBar.TabIndex = 5;
            this.heightTrackBar.Value = 3;
            this.heightTrackBar.Scroll += new System.EventHandler(this.HeightTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(682, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Изменяем матрицу по правилу: Aij = bij/sum, если sum>0, Aij = -bij/sum, если sum<0, Aij = 0, если sum=0,\nгде sum - это сумма элементов i-той строки";
            // 
            // label2
            // 
    //        this.label2.AutoSize = true;
    //        this.label2.Location = new System.Drawing.Point(101, 325);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(584, 16);
    //        this.label2.TabIndex = 7;
    //        this.label2.Text = "Введена буква вместо цифры - обрабатываем как 0. Не ввели число - обрабатываем как " +
    //"0.";
            // 
            // panelError
            // 
            this.panelError.Location = new System.Drawing.Point(84, 370);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(622, 41);
            this.panelError.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.showMatrixButton);
            this.Controls.Add(this.widthTrackBar);
            this.Controls.Add(this.heightTrackBar);
            this.Name = "Form1";
            this.Text = "Lab2";
            ((System.ComponentModel.ISupportInitialize)(this.widthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button showMatrixButton;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.TrackBar widthTrackBar;
        private System.Windows.Forms.TrackBar heightTrackBar;
        private System.Windows.Forms.Panel panelError;
        private Label label1;
        private Label label2;
    }
}


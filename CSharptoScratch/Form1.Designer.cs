namespace CSharptoScratch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBoxStage = new GroupBox();
            buttonRun = new Button();
            timerTick = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // groupBoxStage
            // 
            groupBoxStage.Location = new Point(12, 12);
            groupBoxStage.Name = "groupBoxStage";
            groupBoxStage.Size = new Size(480, 360);
            groupBoxStage.TabIndex = 0;
            groupBoxStage.TabStop = false;
            groupBoxStage.Text = "Stage";
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(498, 12);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(94, 29);
            buttonRun.TabIndex = 0;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // timerTick
            // 
            timerTick.Interval = 33;
            timerTick.Tick += timerTick_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 841);
            Controls.Add(buttonRun);
            Controls.Add(groupBoxStage);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Label labelSprites;
        private GroupBox groupBoxStage;
        private Button buttonRun;
        private System.Windows.Forms.Timer timerTick;
    }
}

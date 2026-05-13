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
            listBoxSprites = new ListBox();
            buttonAddSprite = new Button();
            textBoxName = new TextBox();
            labelName = new Label();
            richTextBoxCode = new RichTextBox();
            groupBoxCode = new GroupBox();
            labelCurrentSprite = new Label();
            buttonCancel = new Button();
            buttonSave = new Button();
            groupBoxSprites = new GroupBox();
            groupBoxCode.SuspendLayout();
            groupBoxSprites.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxSprites
            // 
            listBoxSprites.FormattingEnabled = true;
            listBoxSprites.ItemHeight = 15;
            listBoxSprites.Location = new Point(6, 22);
            listBoxSprites.Name = "listBoxSprites";
            listBoxSprites.Size = new Size(120, 109);
            listBoxSprites.TabIndex = 0;
            listBoxSprites.SelectedIndexChanged += listBoxSprites_SelectedIndexChanged;
            // 
            // buttonAddSprite
            // 
            buttonAddSprite.Location = new Point(132, 66);
            buttonAddSprite.Name = "buttonAddSprite";
            buttonAddSprite.Size = new Size(120, 65);
            buttonAddSprite.TabIndex = 2;
            buttonAddSprite.Text = "Add Sprite";
            buttonAddSprite.UseVisualStyleBackColor = true;
            buttonAddSprite.Click += buttonAddSprite_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(132, 37);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(120, 23);
            textBoxName.TabIndex = 3;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(132, 19);
            labelName.Name = "labelName";
            labelName.Size = new Size(72, 15);
            labelName.TabIndex = 4;
            labelName.Text = "Sprite Name";
            // 
            // richTextBoxCode
            // 
            richTextBoxCode.Location = new Point(6, 52);
            richTextBoxCode.Name = "richTextBoxCode";
            richTextBoxCode.Size = new Size(234, 120);
            richTextBoxCode.TabIndex = 5;
            richTextBoxCode.Text = "";
            // 
            // groupBoxCode
            // 
            groupBoxCode.Controls.Add(labelCurrentSprite);
            groupBoxCode.Controls.Add(buttonCancel);
            groupBoxCode.Controls.Add(buttonSave);
            groupBoxCode.Controls.Add(richTextBoxCode);
            groupBoxCode.Enabled = false;
            groupBoxCode.Location = new Point(298, 12);
            groupBoxCode.Name = "groupBoxCode";
            groupBoxCode.Size = new Size(246, 208);
            groupBoxCode.TabIndex = 6;
            groupBoxCode.TabStop = false;
            groupBoxCode.Text = "Code";
            // 
            // labelCurrentSprite
            // 
            labelCurrentSprite.AutoSize = true;
            labelCurrentSprite.Location = new Point(6, 22);
            labelCurrentSprite.Name = "labelCurrentSprite";
            labelCurrentSprite.Size = new Size(12, 15);
            labelCurrentSprite.TabIndex = 8;
            labelCurrentSprite.Text = "-";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(126, 178);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(114, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(6, 178);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(114, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // groupBoxSprites
            // 
            groupBoxSprites.Controls.Add(listBoxSprites);
            groupBoxSprites.Controls.Add(labelName);
            groupBoxSprites.Controls.Add(buttonAddSprite);
            groupBoxSprites.Controls.Add(textBoxName);
            groupBoxSprites.Location = new Point(12, 12);
            groupBoxSprites.Name = "groupBoxSprites";
            groupBoxSprites.Size = new Size(261, 142);
            groupBoxSprites.TabIndex = 7;
            groupBoxSprites.TabStop = false;
            groupBoxSprites.Text = "Sprites";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxSprites);
            Controls.Add(groupBoxCode);
            Name = "Form1";
            Text = "Form1";
            groupBoxCode.ResumeLayout(false);
            groupBoxCode.PerformLayout();
            groupBoxSprites.ResumeLayout(false);
            groupBoxSprites.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxSprites;
        private Label labelSprites;
        private Button buttonAddSprite;
        private TextBox textBoxName;
        private Label labelName;
        private RichTextBox richTextBoxCode;
        private GroupBox groupBoxCode;
        private GroupBox groupBoxSprites;
        private Button buttonCancel;
        private Button buttonSave;
        private Label labelCurrentSprite;
    }
}

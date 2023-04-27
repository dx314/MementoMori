namespace MementoMori
{
    partial class DeadManSwitch
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
            codeBox = new TextBox();
            unlockBtn = new Button();
            SuspendLayout();
            // 
            // codeBox
            // 
            codeBox.Location = new Point(12, 12);
            codeBox.Name = "codeBox";
            codeBox.PasswordChar = '0';
            codeBox.Size = new Size(353, 23);
            codeBox.TabIndex = 0;
            codeBox.UseSystemPasswordChar = true;
            codeBox.KeyDown += OnTextBoxKeyDown;
            // 
            // unlockBtn
            // 
            unlockBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            unlockBtn.Location = new Point(12, 41);
            unlockBtn.Name = "unlockBtn";
            unlockBtn.Size = new Size(353, 23);
            unlockBtn.TabIndex = 1;
            unlockBtn.Text = "UNLOCK";
            unlockBtn.UseVisualStyleBackColor = true;
            unlockBtn.Click += OnUnlockClick;
            // 
            // DeadManSwitch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 76);
            Controls.Add(unlockBtn);
            Controls.Add(codeBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DeadManSwitch";
            Text = "Memento Mori Guard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox codeBox;
        private Button unlockBtn;
    }
}
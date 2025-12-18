namespace SnowMan
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Winter = new System.Windows.Forms.PictureBox();
            this.changeBorder_button = new System.Windows.Forms.Button();
            this.changeBorder = new System.Windows.Forms.Label();
            this.changeFill_button = new System.Windows.Forms.Button();
            this.changeFill = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AddToDB = new System.Windows.Forms.Label();
            this.listComb = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Winter)).BeginInit();
            this.SuspendLayout();
            // 
            // Winter
            // 
            this.Winter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Winter.BackgroundImage")));
            this.Winter.InitialImage = ((System.Drawing.Image)(resources.GetObject("Winter.InitialImage")));
            this.Winter.Location = new System.Drawing.Point(12, 12);
            this.Winter.Name = "Winter";
            this.Winter.Size = new System.Drawing.Size(768, 980);
            this.Winter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Winter.TabIndex = 0;
            this.Winter.TabStop = false;
            this.Winter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Winter_MouseClick);
            // 
            // changeBorder_button
            // 
            this.changeBorder_button.Location = new System.Drawing.Point(1656, 12);
            this.changeBorder_button.Name = "changeBorder_button";
            this.changeBorder_button.Size = new System.Drawing.Size(100, 100);
            this.changeBorder_button.TabIndex = 1;
            this.changeBorder_button.Text = "click";
            this.changeBorder_button.UseVisualStyleBackColor = true;
            this.changeBorder_button.Click += new System.EventHandler(this.changeBorder_button_Click);
            // 
            // changeBorder
            // 
            this.changeBorder.AutoSize = true;
            this.changeBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.changeBorder.Location = new System.Drawing.Point(1221, 35);
            this.changeBorder.Name = "changeBorder";
            this.changeBorder.Size = new System.Drawing.Size(377, 46);
            this.changeBorder.TabIndex = 2;
            this.changeBorder.Text = "change color border";
            // 
            // changeFill_button
            // 
            this.changeFill_button.Location = new System.Drawing.Point(1656, 118);
            this.changeFill_button.Name = "changeFill_button";
            this.changeFill_button.Size = new System.Drawing.Size(100, 100);
            this.changeFill_button.TabIndex = 1;
            this.changeFill_button.Text = "click";
            this.changeFill_button.UseVisualStyleBackColor = true;
            this.changeFill_button.Click += new System.EventHandler(this.changeFill_button_Click);
            // 
            // changeFill
            // 
            this.changeFill.AutoSize = true;
            this.changeFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.changeFill.Location = new System.Drawing.Point(1221, 142);
            this.changeFill.Name = "changeFill";
            this.changeFill.Size = new System.Drawing.Size(300, 46);
            this.changeFill.TabIndex = 2;
            this.changeFill.Text = "change color fill";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1656, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddToDB_button_Click);
            // 
            // AddToDB
            // 
            this.AddToDB.AutoSize = true;
            this.AddToDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.AddToDB.Location = new System.Drawing.Point(1221, 243);
            this.AddToDB.Name = "AddToDB";
            this.AddToDB.Size = new System.Drawing.Size(317, 46);
            this.AddToDB.TabIndex = 2;
            this.AddToDB.Text = "add to DataBase";
            // 
            // listComb
            // 
            this.listComb.FormattingEnabled = true;
            this.listComb.ItemHeight = 20;
            this.listComb.Location = new System.Drawing.Point(1228, 329);
            this.listComb.Name = "listComb";
            this.listComb.Size = new System.Drawing.Size(528, 104);
            this.listComb.TabIndex = 3;
            this.listComb.SelectedIndexChanged += new System.EventHandler(this.listComb_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1794, 1017);
            this.Controls.Add(this.listComb);
            this.Controls.Add(this.AddToDB);
            this.Controls.Add(this.changeFill);
            this.Controls.Add(this.changeBorder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.changeFill_button);
            this.Controls.Add(this.changeBorder_button);
            this.Controls.Add(this.Winter);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Winter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Winter;
        private System.Windows.Forms.Button changeBorder_button;
        private System.Windows.Forms.Label changeBorder;
        private System.Windows.Forms.Button changeFill_button;
        private System.Windows.Forms.Label changeFill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label AddToDB;
        private System.Windows.Forms.ListBox listComb;
    }
}


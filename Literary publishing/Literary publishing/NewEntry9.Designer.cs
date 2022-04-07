namespace Literary_publishing
{
    partial class NewEntry9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewEntry9));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2_save = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox9_Customer_type = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.button1_clear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 149);
            this.panel1.TabIndex = 1;
            // 
            // button1_clear
            // 
            this.button1_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1_clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1_clear.BackgroundImage")));
            this.button1_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button1_clear.Location = new System.Drawing.Point(577, 42);
            this.button1_clear.Name = "button1_clear";
            this.button1_clear.Size = new System.Drawing.Size(60, 60);
            this.button1_clear.TabIndex = 2;
            this.button1_clear.UseVisualStyleBackColor = true;
            this.button1_clear.Click += new System.EventHandler(this.button1_clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oswald Light", 28.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.MaximumSize = new System.Drawing.Size(280, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 128);
            this.label1.TabIndex = 1;
            this.label1.Text = "Создание Записи: Типы Заказчиков";
            // 
            // button2_save
            // 
            this.button2_save.Font = new System.Drawing.Font("Oswald Light", 20F);
            this.button2_save.Location = new System.Drawing.Point(224, 327);
            this.button2_save.Name = "button2_save";
            this.button2_save.Size = new System.Drawing.Size(160, 50);
            this.button2_save.TabIndex = 8;
            this.button2_save.Text = "Сохранить";
            this.button2_save.UseVisualStyleBackColor = true;
            this.button2_save.Click += new System.EventHandler(this.button2_save_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Oswald Light", 20F);
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(130, 200);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(170, 46);
            this.label31.TabIndex = 11;
            this.label31.Text = "Тип Заказчика :";
            // 
            // textBox9_Customer_type
            // 
            this.textBox9_Customer_type.Location = new System.Drawing.Point(306, 219);
            this.textBox9_Customer_type.Name = "textBox9_Customer_type";
            this.textBox9_Customer_type.Size = new System.Drawing.Size(280, 20);
            this.textBox9_Customer_type.TabIndex = 10;
            this.textBox9_Customer_type.TextChanged += new System.EventHandler(this.textBox8_Type_of_printed_products_TextChanged);
            // 
            // NewEntry9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(118)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.textBox9_Customer_type);
            this.Controls.Add(this.button2_save);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewEntry9";
            this.Text = "Создание Записи: Типы Заказчиков";
            this.Load += new System.EventHandler(this.NewEntry9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1_clear;
        private System.Windows.Forms.Button button2_save;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBox9_Customer_type;
    }
}
namespace BongoCat
{
    partial class App
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.Left = new System.Windows.Forms.PictureBox();
            this.Right = new System.Windows.Forms.PictureBox();
            this.Cat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cat)).BeginInit();
            this.SuspendLayout();
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.Transparent;
            this.Left.Image = global::BongoCat.Properties.Resources.unpressed_left;
            this.Left.Location = new System.Drawing.Point(270, 0);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(270, 350);
            this.Left.TabIndex = 2;
            this.Left.TabStop = false;
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.Transparent;
            this.Right.Image = global::BongoCat.Properties.Resources.unpressed_right;
            this.Right.Location = new System.Drawing.Point(0, 0);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(270, 350);
            this.Right.TabIndex = 1;
            this.Right.TabStop = false;
            // 
            // Cat
            // 
            this.Cat.BackColor = System.Drawing.Color.Transparent;
            this.Cat.BackgroundImage = global::BongoCat.Properties.Resources.cat_table;
            this.Cat.Location = new System.Drawing.Point(0, 0);
            this.Cat.Name = "Cat";
            this.Cat.Size = new System.Drawing.Size(540, 350);
            this.Cat.TabIndex = 0;
            this.Cat.TabStop = false;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 350);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Cat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "App";
            this.Text = "Bongo Cat | Press \'O\' to open settings";
            ((System.ComponentModel.ISupportInitialize)(this.Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Right;
        private System.Windows.Forms.PictureBox Left;
        public System.Windows.Forms.PictureBox Cat;
    }
}


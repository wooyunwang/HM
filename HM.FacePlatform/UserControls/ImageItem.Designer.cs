namespace HM.FacePlatform.UserControls
{
    partial class ImageItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImage.InitialImage = global::HM.FacePlatform.Properties.Resources.userPhoto;
            this.picImage.Location = new System.Drawing.Point(10, 7);
            this.picImage.Margin = new System.Windows.Forms.Padding(4);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(152, 175);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 2;
            this.picImage.TabStop = false;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.BackgroundImage = global::HM.FacePlatform.Properties.Resources.delete;
            this.btnDeleteImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteImage.FlatAppearance.BorderSize = 0;
            this.btnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage.Location = new System.Drawing.Point(132, 12);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteImage.TabIndex = 3;
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // ImageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.picImage);
            this.Name = "ImageItem";
            this.Size = new System.Drawing.Size(176, 186);
            this.Load += new System.EventHandler(this.ImageItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnDeleteImage;


    }
}

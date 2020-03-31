namespace Map_API
{
    partial class Map_form
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.Label_1 = new System.Windows.Forms.Label();
            this.StartLocation = new System.Windows.Forms.TextBox();
            this.Load_Location = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EndLocation = new System.Windows.Forms.TextBox();
            this.Display = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(451, 501);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 13);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(423, 476);
            this.gMapControl1.TabIndex = 1;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GMapControl1_MouseClick);
            // 
            // Label_1
            // 
            this.Label_1.AutoSize = true;
            this.Label_1.Location = new System.Drawing.Point(495, 34);
            this.Label_1.Name = "Label_1";
            this.Label_1.Size = new System.Drawing.Size(86, 13);
            this.Label_1.TabIndex = 2;
            this.Label_1.Text = "Začetna lokacija";
            // 
            // StartLocation
            // 
            this.StartLocation.Location = new System.Drawing.Point(498, 67);
            this.StartLocation.Name = "StartLocation";
            this.StartLocation.Size = new System.Drawing.Size(139, 20);
            this.StartLocation.TabIndex = 3;
            // 
            // Load_Location
            // 
            this.Load_Location.Location = new System.Drawing.Point(498, 192);
            this.Load_Location.Name = "Load_Location";
            this.Load_Location.Size = new System.Drawing.Size(75, 23);
            this.Load_Location.TabIndex = 4;
            this.Load_Location.Text = "Prikaži";
            this.Load_Location.UseVisualStyleBackColor = true;
            this.Load_Location.Click += new System.EventHandler(this.Load_Location_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zadnja lokacija";
            // 
            // EndLocation
            // 
            this.EndLocation.Location = new System.Drawing.Point(498, 136);
            this.EndLocation.Name = "EndLocation";
            this.EndLocation.Size = new System.Drawing.Size(139, 20);
            this.EndLocation.TabIndex = 6;
            // 
            // Display
            // 
            this.Display.FormattingEnabled = true;
            this.Display.Location = new System.Drawing.Point(480, 280);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(305, 199);
            this.Display.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lokacije";
            // 
            // Map_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.EndLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Load_Location);
            this.Controls.Add(this.StartLocation);
            this.Controls.Add(this.Label_1);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.splitter1);
            this.Name = "Map_form";
            this.Text = "Zemljevid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Label Label_1;
        private System.Windows.Forms.TextBox StartLocation;
        private System.Windows.Forms.Button Load_Location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EndLocation;
        private System.Windows.Forms.ListBox Display;
        private System.Windows.Forms.Label label2;
    }
}


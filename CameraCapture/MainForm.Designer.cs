namespace CameraCapture
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbFrame = new System.Windows.Forms.PictureBox();
            this.labelPicture = new System.Windows.Forms.Label();
            this.btnCapturePicture = new System.Windows.Forms.Button();
            this.labelVideo = new System.Windows.Forms.Label();
            this.btnVideoControl = new System.Windows.Forms.Button();
            this.btnStopVideo = new System.Windows.Forms.Button();
            this.timerFrame = new System.Windows.Forms.Timer(this.components);
            this.labelSource = new System.Windows.Forms.Label();
            this.rbCamera = new System.Windows.Forms.RadioButton();
            this.rbScreen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFrame
            // 
            this.pbFrame.Location = new System.Drawing.Point(12, 12);
            this.pbFrame.Name = "pbFrame";
            this.pbFrame.Size = new System.Drawing.Size(640, 480);
            this.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFrame.TabIndex = 0;
            this.pbFrame.TabStop = false;
            // 
            // labelPicture
            // 
            this.labelPicture.AutoSize = true;
            this.labelPicture.Location = new System.Drawing.Point(12, 525);
            this.labelPicture.Name = "labelPicture";
            this.labelPicture.Size = new System.Drawing.Size(53, 12);
            this.labelPicture.TabIndex = 0;
            this.labelPicture.Text = "圖片擷取";
            // 
            // btnCapturePicture
            // 
            this.btnCapturePicture.Location = new System.Drawing.Point(71, 520);
            this.btnCapturePicture.Name = "btnCapturePicture";
            this.btnCapturePicture.Size = new System.Drawing.Size(75, 23);
            this.btnCapturePicture.TabIndex = 1;
            this.btnCapturePicture.Text = "擷取";
            this.btnCapturePicture.UseVisualStyleBackColor = true;
            this.btnCapturePicture.Click += new System.EventHandler(this.btnCapturePicture_Click);
            // 
            // labelVideo
            // 
            this.labelVideo.AutoSize = true;
            this.labelVideo.Location = new System.Drawing.Point(175, 525);
            this.labelVideo.Name = "labelVideo";
            this.labelVideo.Size = new System.Drawing.Size(53, 12);
            this.labelVideo.TabIndex = 2;
            this.labelVideo.Text = "影片擷取";
            // 
            // btnVideoControl
            // 
            this.btnVideoControl.Location = new System.Drawing.Point(234, 520);
            this.btnVideoControl.Name = "btnVideoControl";
            this.btnVideoControl.Size = new System.Drawing.Size(75, 23);
            this.btnVideoControl.TabIndex = 3;
            this.btnVideoControl.Text = "開始";
            this.btnVideoControl.UseVisualStyleBackColor = true;
            this.btnVideoControl.Click += new System.EventHandler(this.btnVideoControl_Click);
            // 
            // btnStopVideo
            // 
            this.btnStopVideo.Enabled = false;
            this.btnStopVideo.Location = new System.Drawing.Point(315, 520);
            this.btnStopVideo.Name = "btnStopVideo";
            this.btnStopVideo.Size = new System.Drawing.Size(75, 23);
            this.btnStopVideo.TabIndex = 4;
            this.btnStopVideo.Text = "停止";
            this.btnStopVideo.UseVisualStyleBackColor = true;
            this.btnStopVideo.Click += new System.EventHandler(this.btnStopVideo_Click);
            // 
            // timerFrame
            // 
            this.timerFrame.Tick += new System.EventHandler(this.timerFrame_Tick);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(12, 565);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(53, 12);
            this.labelSource.TabIndex = 5;
            this.labelSource.Text = "擷取來源";
            // 
            // rbCamera
            // 
            this.rbCamera.AutoSize = true;
            this.rbCamera.Checked = true;
            this.rbCamera.Location = new System.Drawing.Point(71, 563);
            this.rbCamera.Name = "rbCamera";
            this.rbCamera.Size = new System.Drawing.Size(59, 16);
            this.rbCamera.TabIndex = 6;
            this.rbCamera.TabStop = true;
            this.rbCamera.Text = "攝影機";
            this.rbCamera.UseVisualStyleBackColor = true;
            this.rbCamera.CheckedChanged += new System.EventHandler(this.rbCamera_CheckedChanged);
            // 
            // rbScreen
            // 
            this.rbScreen.AutoSize = true;
            this.rbScreen.Location = new System.Drawing.Point(136, 563);
            this.rbScreen.Name = "rbScreen";
            this.rbScreen.Size = new System.Drawing.Size(47, 16);
            this.rbScreen.TabIndex = 7;
            this.rbScreen.Text = "螢幕";
            this.rbScreen.UseVisualStyleBackColor = true;
            this.rbScreen.CheckedChanged += new System.EventHandler(this.rbScreen_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 601);
            this.Controls.Add(this.rbScreen);
            this.Controls.Add(this.rbCamera);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.btnStopVideo);
            this.Controls.Add(this.btnVideoControl);
            this.Controls.Add(this.labelVideo);
            this.Controls.Add(this.btnCapturePicture);
            this.Controls.Add(this.labelPicture);
            this.Controls.Add(this.pbFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "擷取工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFrame;
        private System.Windows.Forms.Label labelPicture;
        private System.Windows.Forms.Button btnCapturePicture;
        private System.Windows.Forms.Label labelVideo;
        private System.Windows.Forms.Button btnVideoControl;
        private System.Windows.Forms.Button btnStopVideo;
        private System.Windows.Forms.Timer timerFrame;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.RadioButton rbCamera;
        private System.Windows.Forms.RadioButton rbScreen;
    }
}


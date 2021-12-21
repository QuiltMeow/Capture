using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CameraCapture
{
    public partial class MainForm : Form
    {
        private VideoCapture videoCapture;
        private VideoWriter videoWriter;
        private readonly Random random;

        private bool pause;
        private int fps;
        private Size cameraSize, resolution;
        private CaptureSource source;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            source = CaptureSource.CAMERA;
            videoCapture = new VideoCapture(Constant.DEFAULT_CAMERA);
            fps = getCameraFPS();
            cameraSize = new Size(videoCapture.Width, videoCapture.Height);
            resolution = ScreenCapture.getResolution();
            updateInterval(fps);
            timerFrame.Start();
        }

        private void updateInterval(int fps)
        {
            int interval = fpsToInterval(fps);
            if (interval <= 0)
            {
                interval = 1;
            }
            timerFrame.Interval = interval;
        }

        private int getCameraFPS()
        {
            return (int)videoCapture.GetCaptureProperty(CapProp.Fps);
        }

        public static Mat bitmapToMat(Bitmap bitmap)
        {
            Image<Bgr, byte> cvImage = new Image<Bgr, byte>(bitmap);
            return cvImage.Mat;
        }

        private void timerFrame_Tick(object sender, EventArgs e)
        {
            if (source == CaptureSource.CAMERA)
            {
                try
                {
                    Mat mat = videoCapture.QueryFrame();
                    pbFrame.Image = mat.Bitmap;
                    writeVideo(mat);
                }
                catch (Exception ex)
                {
                    timerFrame.Stop();
                    MessageBox.Show("擷取攝影機影像時發生例外狀況 : " + ex.Message);
                    Environment.Exit(1);
                }
            }
            else
            {
                Bitmap capture = ScreenCapture.captureScreen();
                pbFrame.Image = capture;
                Mat mat = bitmapToMat(capture);
                writeVideo(mat);
            }
        }

        private void writeVideo(Mat mat)
        {
            if (videoWriter != null && !pause)
            {
                videoWriter.Write(mat);
            }
        }

        private void captureSourceChange(CaptureSource source)
        {
            if (this.source == source)
            {
                return;
            }
            this.source = source;

            if (videoWriter != null)
            {
                stopVideo();
            }
            updateInterval(source == CaptureSource.CAMERA ? fps : Constant.DEFAULT_FPS);
        }

        public static int fpsToInterval(int fps)
        {
            return (int)(1000D / fps);
        }

        private void btnCapturePicture_Click(object sender, EventArgs e)
        {
            pbFrame.Image.Save("./capture-" + getUniqueFileName() + ".png", ImageFormat.Png);
        }

        private string getUniqueFileName()
        {
            return DateTime.Now.Ticks + "-" + random.Next();
        }

        private void btnVideoControl_Click(object sender, EventArgs e)
        {
            if (videoWriter == null)
            {
                int compressionCode = VideoWriter.Fourcc('M', 'P', '4', 'V');
                videoWriter = new VideoWriter("./video-" + getUniqueFileName() + ".mp4", compressionCode, source == CaptureSource.CAMERA ? fps : Constant.DEFAULT_FPS, source == CaptureSource.CAMERA ? cameraSize : resolution, true);
            }
            else
            {
                pause = !pause;
            }
            btnVideoControl.Text = pause ? "繼續" : "暫停";
            btnStopVideo.Enabled = true;
        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            stopVideo();
        }

        private void stopVideo()
        {
            videoWriter = null;
            pause = false;
            btnVideoControl.Text = "開始";
            btnStopVideo.Enabled = false;
        }

        private void rbCamera_CheckedChanged(object sender, EventArgs e)
        {
            captureSourceChange(CaptureSource.CAMERA);
        }

        private void rbScreen_CheckedChanged(object sender, EventArgs e)
        {
            captureSourceChange(CaptureSource.SCREEN);
        }
    }
}
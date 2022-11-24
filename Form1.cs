//The bitmap image to Video File
/*video going in file saving as the application context is running
 * select save location 
 * screen pause and start functionality
 * 
 * we can store that bitmap in a array ofimage and convery that array to video  
 * or savae the images in a particular directory and assemble those images into a file
 * use regular expression to filter out files
 * shortcut or toolbar button to quickly capture screenshoot
 * include this in a seperate class ScreenRecorder and call the methods using this class
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ScreenRecorder
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            

        }

       
       


        private void button3_Click(object sender, EventArgs e) //Stop Recording
        {
            //Stop CUrrent Recording
            //use thread to join all the images to a video file

            Thread.CurrentThread.Abort();
            Application.Exit();


            //and save all the images as a mp4 file
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            pictureBox1.Image = bitmap;

            bitmap.Save("testimage.jpg");



        }



        void CaptureImages()
        {
            int fileCounter = 0;
            while (true)
            {
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                pictureBox1.Image = bitmap;


               // bitmap.SetResolution(100,200);


                Thread.Sleep(1000); //Putting this thread to halt execution till 1 second

                System.IO.Directory.CreateDirectory("RecorderTemperoryPictures");

                bitmap.Save(@"D:\Ma Y uR\My Stuffs\Practice Projects\dot NET\ScreenRecorder\ScreenRecorder\bin\Debug\TestPics\" + fileCounter +"RecorDer.jpeg");

                fileCounter++;

              //  WriteVideoFrame to combine in anathor function

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {



            Thread.CurrentThread.Abort();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CaptureImages);
            thread.Start();

            ScreenRecorder screenRecorder = new ScreenRecorder();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;


        }
    }
}

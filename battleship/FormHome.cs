using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //Enable paint via message to reduce flicker. 
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            Form1 form1 = new Form1(name);
            form1.Show();
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = this.Location;
            form1.Size = this.Size;
            this.Hide();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
        }
        //Whether the animation starts.
        bool currentlyAnimating = false;
        //Indicate if update the animation.
        bool isAnimating = true;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (isAnimating)
            {
                //Begin the animation.
                AnimateImage();
                //Update the frames. The cell would paint the next frame of the image late on.
                ImageAnimator.UpdateFrames();
            }
            base.OnPaintBackground(e);
        }
        //This method begins the animation.
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(this.BackgroundImage, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }
        private void OnFrameChanged(object o, EventArgs e)
        {
            //Force to redraw the form.
            this.Invalidate();
        }
    }
}

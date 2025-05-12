using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baocao.GUI
{
    public partial class fSplashScreen: Form
    {
        private int delayCounter = 0;
        public fSplashScreen()
        {
            InitializeComponent();
            HexaTech.Visible = false;

            // Initialize splash screen properties
            Opacity = 0; // Start with a fully transparent splash screen
            this.TransparencyKey = BackColor; // Make the background transparent
            timer1.Interval = 50; // Set timer interval (e.g., 50ms for smooth fade-in)
            timer1.Tick += Timer1_Tick; // Attach timer tick event handler
            timer1.Start(); // Start the timer
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Gradually increase the opacity to create a fade-in effect  
            if (Opacity < 1.0)
            {
                Opacity += 0.02; // Increment opacity (adjust value for desired fade-in speed)  
            }
            else
            {
                HexaTech.Visible = true;
                if (HexaTech.Location.X < 285)
                {
                    Location = new Point(Location.X - 2, Location.Y); // Move the splash screen to the left
                                                                      // Move the HexaTech image to the right
                    HexaTech.Location = new Point(HexaTech.Location.X + 6, HexaTech.Location.Y);
                }
                delayCounter += timer1.Interval;
                // Once fully opaque, stop the timer and show the login form  
                if (delayCounter >= 4000)
                {
                    timer1.Stop();
                    this.Hide(); // Hide the splash screen  
                    using (fDangNhap loginForm = new fDangNhap()) // Show the login form  
                    {
                        loginForm.ShowDialog();
                    }
                    this.Close(); // Close the splash screen after the login form is closed  
                }
            }
        }
    }
}

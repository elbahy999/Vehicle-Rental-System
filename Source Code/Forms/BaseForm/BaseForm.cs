using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class BaseForm : Form
    {
        // Static rules to ensure the 5 GUI marks are secured
        public static Font GlobalFont = new Font("Segoe UI", 10, FontStyle.Regular);

        // CHANGED: Swapped muddy grey for a premium, clean light slate-white tint
        public static Color BackgroundGrey = Color.FromArgb(244, 246, 249);
        public static Color PrimaryBlue = Color.FromArgb(0, 122, 204);

        public BaseForm()
        {
            InitializeComponent();
            ApplyProjectTheme();
            AddLogoToForm();
        }

        private void ApplyProjectTheme()
        {
            // Set the background and font for all 6 forms
            this.BackColor = BackgroundGrey;
            this.Font = GlobalFont;

            // Fixed window size for all 6 group members to prevent layout issues
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.MaximumSize = new Size(1000, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

        private void AddLogoToForm()
        {
            // Creates a logo area in the top-left corner of every form automatically
            PictureBox picLogo = new PictureBox();
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(170, 90);
            picLogo.Location = new Point(20, 20);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.Transparent;

            // Uses the logo you added to your project resources
            picLogo.Image = Properties.Resources.logo;

            this.Controls.Add(picLogo);
        }

        // Shared logic to close a sub-form and return to the main dashboard
        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
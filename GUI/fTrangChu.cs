using baocao.GUI.Managers;
using baocao.GUI.BaseForm;
namespace baocao.GUI
{
    public partial class fTrangChu : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance; //7/4/2025
        Color light = Color.FromArgb(229, 236, 191);
        Color dark = Color.FromArgb(6, 56, 69);
        public fTrangChu()
        {
            //Default Initialize
            InitializeComponent();
            //labelTitleCompany.Parent = pictureCompanyMousEnter;
            //labelCompanyDescription.BackColor = Color.Transparent;
            //labelCompanyDescription.Parent = pictureCompanyMousEnter;
            //Back Color
            //pictureCompanyMousEnter.BackColor = dark;
            //panelRightBottom.BackColor = dark;
            //panelRightTop.BackColor = dark;
            //labelPanelRightBottom.BackColor = light;
            //labelPanelRightTop.BackColor = light;
            //CircleProgress.BackColor = light;
            //CircleProgress.ForeColor = dark;
            //Fill Color
            //panelRightBottom.FillColor = light;
            //panelRightTop.FillColor = light;
            //Border Color
            //panelRightBottom.BorderColor = light;
            //panelRightTop.BorderColor = light;
            //Fore Color
            //labelPanelRightBottom.ForeColor = dark;
            //labelPanelRightTop.ForeColor = dark;
            //labelCompanyDescription.ForeColor = light;
            //Progress Color
            //CircleProgress.ProgressColor = dark;
            //CircleProgress.ProgressColor2 = dark;
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            


        } //
        protected override void ApplyDarkMode(bool IsDarkMode)
        {
            this.BackColor = DarkModeManager.GetBackgroundColor();
        }
        public Color ChangeOpacityByPercentage(Color baseColor, int opacityPercentage)
        {
            // Ensure percentage is within valid range (0% to 100%)
            opacityPercentage = Math.Max(0, Math.Min(100, opacityPercentage));

            // Calculate alpha from the percentage
            int alpha = (int)((opacityPercentage / 100.0) * 255);

            // Return a new transparent color
            return Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
        }
    }
}

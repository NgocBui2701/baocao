using FontAwesome.Sharp;

namespace baocao.GUI.Managers
{
    public static class DarkModeManager
    {
        public static event Action<bool> DarkModeChanged;
        private static bool _isDarkMode = Properties.Settings.Default.DarkMode;
        private static Color Dark = Color.FromArgb(3, 82, 101);
        private static Color Light = Color.FromArgb(240, 237, 204);
        public static Color GetBackgroundColor() => IsDarkMode ? Dark : Light;
        public static Color GetForeColor() => IsDarkMode ? Light : Dark;
        public static Color GetDark() => Dark;
        public static Color GetLight() => Light;
        public static bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    Properties.Settings.Default.DarkMode = value;
                    Properties.Settings.Default.Save();
                    DarkModeChanged?.Invoke(value);
                }
            }
        }
        public static void ApplyDarkModeToForm(Form form, bool darkMode)
        {
            form.BackColor = GetBackgroundColor();
            form.ForeColor = GetForeColor();
            foreach (Control control in form.Controls)
            {
                control.BackColor = GetBackgroundColor();
                control.ForeColor = GetForeColor();
                if (control is IconButton iconButton)
                {
                    iconButton.IconColor = GetForeColor();
                    iconButton.BackColor = GetBackgroundColor();
                    iconButton.ForeColor = GetForeColor();
                }
                if (control is Panel panel)
                {
                    ApplyDarkModeToControls(panel.Controls, darkMode);
                }
            }
        }
        private static void ApplyDarkModeToControls(Control.ControlCollection controls, bool darkMode)
        {
            foreach (Control control in controls)
            {
                control.BackColor = GetBackgroundColor();
                control.ForeColor = GetForeColor();

                if (control is IconButton iconButton)
                {
                    iconButton.IconColor = GetForeColor();
                    iconButton.BackColor = GetBackgroundColor();
                    iconButton.ForeColor = GetForeColor();
                }

                if (control is Panel panel)
                {
                    ApplyDarkModeToControls(panel.Controls, darkMode);
                }
            }
        }

    }
}

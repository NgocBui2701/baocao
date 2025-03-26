using System.Windows.Forms;
using baocao.GUI.Managers;

namespace baocao.GUI.BaseForm
{
    public class DarkModeForm : Form
    {
        protected DarkModeForm()
        {
            DarkModeManager.DarkModeChanged += OnDarkModeChanged;
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }

        protected virtual void ApplyDarkMode(bool darkMode)
        {
            DarkModeManager.ApplyDarkModeToForm(this, darkMode);
        }

        protected virtual void OnDarkModeChanged(bool darkMode)
        {
            ApplyDarkMode(darkMode);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (DarkModeManager.IsDarkMode)
            {
                DarkModeManager.DarkModeChanged -= OnDarkModeChanged;
            }
            base.OnFormClosing(e);
        }
    }
}

using System;
using System.Windows.Forms;
using baocao.GUI.Managers;
using FontAwesome.Sharp;

namespace baocao.GUI.BaseForm
{
    public abstract class EditForm<T> : DarkModeForm where T : class
    {
        protected bool isEdit = false;
        protected T curr = null;
        protected EditForm(T item = null)
        {
            if (item != null)
            {
                isEdit = true;
                curr = item;
            }
            ApplyDarkMode(DarkModeManager.IsDarkMode);
        }

        protected abstract T GetFormData();
        protected abstract void LoadData();
        protected abstract bool ValidateData(T data);
        protected abstract bool SaveData(T data);

        private bool Save()
        {
            curr = GetFormData();
            if (!ValidateData(curr))
            {
                return false;
            }
            bool success = SaveData(curr);
            if (success)
            {
                MessageBox.Show(
           isEdit ? LanguageManager.Instance.Translate("update_success") : LanguageManager.Instance.Translate("insert_success"),
           LanguageManager.Instance.Translate("notification"),
           MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
            LanguageManager.Instance.Translate("operation_failed"),
            LanguageManager.Instance.Translate("error"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }
        protected override void ApplyDarkMode(bool darkMode)
        {
            base.ApplyDarkMode(darkMode);
            foreach (Control control in Controls)
            {
                if (control is Button button && control is not IconButton)
                {
                    button.BackColor = DarkModeManager.GetForeColor();
                    button.ForeColor = this.BackColor;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                }
                if (control is TextBox || control is DateTimePicker || control is ComboBox)
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.Black;
                }
            }
        }
        #region Common Event Handlers
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                LanguageManager.Instance.Translate("save_before_exit"),
                LanguageManager.Instance.Translate("confirmation"),
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                btnSave_Click(sender, e);
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }
        #endregion
    }
}
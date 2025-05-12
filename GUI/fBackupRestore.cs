using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Threading.Tasks;
using baocao.GUI.Managers;
using baocao.GUI.BaseForm;
using Microsoft.Data.SqlClient;
using baocao.DAO;

namespace baocao.GUI
{
    public partial class fBackupRestore : DarkModeForm
    {
        private string databaseName;
        private string backupPath;
        private DataProvider dataProvider;

        public fBackupRestore()
        {
            InitializeComponent();
            dataProvider = DataProvider.Instance;
            databaseName = "QUAN_LY_DON_HANG_MOI_TRUONG";
            backupPath = @"C:\SQLBackups";
            txtDatabaseName.Text = databaseName;
            txtBackupPath.Text = backupPath;
            LoadBackupFiles();
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            labelPathBackup.ForeColor = DarkModeManager.GetForeColor();
            labelDb.ForeColor = DarkModeManager.GetForeColor();
            txtBackupPath.BackColor = Color.White;
            txtDatabaseName.BackColor = Color.White;
            btnSelectBackup.BackColor = Color.White;
            btnBackup.BackColor = Color.White;
            btnRestore.BackColor = Color.White;
            lstBackupFiles.BackColor = Color.White;
        }
        private void btnSelectBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    backupPath = fbd.SelectedPath;
                    txtBackupPath.Text = backupPath;
                    LoadBackupFiles();
                }
            }
        }

        private async void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!dataProvider.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến SQL Server. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            databaseName = txtDatabaseName.Text;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Backup file|*.bak",
                Title = "Chọn nơi lưu file backup",
                InitialDirectory = backupPath,
                FileName = $"{databaseName}_Backup_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.bak"
            })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string backupFile = saveFileDialog.FileName;

                btnBackup.Enabled = false;
                progressBar.Value = 0;

                try
                {
                    string directory = Path.GetDirectoryName(backupFile);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    try
                    {
                        string testFile = Path.Combine(directory, "test.txt");
                        File.WriteAllText(testFile, "test");
                        File.Delete(testFile);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Không có quyền ghi vào thư mục: {ex.Message}");
                    }

                    await Task.Run(() => dataProvider.BackupDatabase(backupFile));
                    progressBar.Value = 100;
                    MessageBox.Show($"Sao lưu thành công: {backupFile}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBackupFiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sao lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnBackup.Enabled = true;
                }
            }
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            if (lstBackupFiles.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn file backup để khôi phục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedBackup = Path.Combine(backupPath, lstBackupFiles.SelectedItem.ToString());

            if (!File.Exists(selectedBackup))
            {
                MessageBox.Show("File backup không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!dataProvider.TestConnection())
            {
                MessageBox.Show("Không thể kết nối đến SQL Server. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            databaseName = txtDatabaseName.Text;

            btnRestore.Enabled = false;
            progressBar.Value = 0;

            try
            {
                if (MessageBox.Show("Khôi phục sẽ ghi đè database hiện tại. Bạn có chắc chắn muốn tiếp tục?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                await Task.Run(() => dataProvider.RestoreDatabase(selectedBackup));
                progressBar.Value = 100;
                if (dataProvider.TestConnection())
                {
                    MessageBox.Show("Khôi phục database thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Khôi phục database thành công nhưng không thể kết nối lại. Vui lòng kiểm tra!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khôi phục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRestore.Enabled = true;
            }
        }

        private void LoadBackupFiles()
        {
            lstBackupFiles.Items.Clear();
            if (Directory.Exists(backupPath))
            {
                string[] backupFiles = Directory.GetFiles(backupPath, "*.bak");
                foreach (string file in backupFiles)
                {
                    lstBackupFiles.Items.Add(Path.GetFileName(file));
                }
            }
        }

        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            this.Hide(); // này sửa sao cho nó trả ra cài đặt z
        }
    }
}

using System;
using System.IO;
using System.IO.Compression;

namespace baocao.GUI.Managers
{
    class BackupRestoreManager
    {
        private string sourcePath;
        private string backupPath;
        public BackupRestoreManager(string source, string backup)
        {
            sourcePath = source;
            backupPath = backup;
        }
        public void BackupData()
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFile = Path.Combine(backupPath, $"Backup_{timestamp}.zip");

                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }

                ZipFile.CreateFromDirectory(sourcePath, backupFile);
                Console.WriteLine($"Sao lưu thành công: {backupFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi sao lưu: {ex.Message}");
            }
        }
        public void RestoreData(string backupFilePath)
        {
            try
            {
                if (!File.Exists(backupFilePath))
                {
                    Console.WriteLine("File backup không tồn tại!");
                    return;
                }

                if (Directory.Exists(sourcePath))
                {
                    Directory.Delete(sourcePath, true);
                }

                ZipFile.ExtractToDirectory(backupFilePath, sourcePath);
                Console.WriteLine("Khôi phục dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi khôi phục: {ex.Message}");
            }
        }
        public void ListBackupFiles()
        {
            try
            {
                if (Directory.Exists(backupPath))
                {
                    string[] backupFiles = Directory.GetFiles(backupPath, "*.zip");
                    if (backupFiles.Length == 0)
                    {
                        Console.WriteLine("Không có file backup nào!");
                        return;
                    }

                    Console.WriteLine("Danh sách file backup:");
                    foreach (string file in backupFiles)
                    {
                        Console.WriteLine(Path.GetFileName(file));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi liệt kê: {ex.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using Newtonsoft.Json;
using System.IO;
using Vosk;
using baocao.GUI.Managers;
using baocao.GUI.BaseForm;

namespace baocao.GUI
{
    public partial class fAITiengViet : DarkModeForm
    {
        private LanguageManager langManager = LanguageManager.Instance;
        private ITextUpdatable parentForm;
        private WaveInEvent waveIn;
        private VoskRecognizer recognizer;
        private bool isRecording = false;
        public interface ITextUpdatable
        {
            void UpdateText(string text);
        }
        public fAITiengViet(ITextUpdatable parent)
        {
            InitializeComponent();
            parentForm = parent;
            InitVosk();
            UpdateLanguageTexts();
            langManager.LanguageChanged += LangManager_LanguageChanged;
            ApplyDarkMode(DarkModeManager.IsDarkMode);
            this.BackColor = DarkModeManager.GetForeColor();
            btnStart.BackColor = DarkModeManager.GetBackgroundColor();
            btnStop.BackColor = DarkModeManager.GetBackgroundColor();
            btnExit.BackColor = DarkModeManager.GetForeColor();
            btnExit.IconColor = DarkModeManager.GetBackgroundColor();
            btnStart.ForeColor = DarkModeManager.GetForeColor();
            btnStop.ForeColor = DarkModeManager.GetForeColor();
        }
        private void LangManager_LanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }
        private void InitVosk()
        {
            try
            {
                Vosk.Vosk.SetLogLevel(0);
                string modelPath = @"D:\baocao (9)\baocao\vosk-model-vn-0.4";
                if (!Directory.Exists(modelPath))
                {
                    MessageBox.Show("Không tìm thấy mô hình: " + modelPath);
                    this.Close();
                    return;
                }
                recognizer = new VoskRecognizer(new Model(modelPath), 16000.0f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo Vosk: " + ex.Message);
                this.Close();
            }
        }
        private void UpdateLanguageTexts()
        {

            btnStart.Text = langManager.Translate("start");
            btnStop.Text = langManager.Translate("stop");
            this.Text = langManager.Translate("ai_language_title");
        }
        protected virtual void OnLanguageChanged(object sender, EventArgs e)
        {
            UpdateLanguageTexts();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            langManager.LanguageChanged -= LangManager_LanguageChanged;

            waveIn?.Dispose();
            recognizer?.Dispose();
        }
        private void StartRecording()
        {
            if (isRecording) return;

            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(16000, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;

            isRecording = true;
            waveIn.StartRecording();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                if (recognizer == null) return;

                if (e.Buffer == null || e.BytesRecorded <= 0)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi: Dữ liệu âm thanh không hợp lệ!");
                    return;
                }

                recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded);
                string partialJson = recognizer.PartialResult();
                System.Diagnostics.Debug.WriteLine("Partial result: " + partialJson);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi khi xử lý âm thanh: " + ex.Message);
            }
        }

        private void StopRecording()
        {
            if (!isRecording) return;

            waveIn.StopRecording();
            waveIn.Dispose();
            isRecording = false;
        }

        private void ProcessFinalResult()
        {
            if (recognizer == null) return;
            string finalResult = recognizer.FinalResult();
            if (string.IsNullOrWhiteSpace(finalResult))
            {
                MessageBox.Show("Không có âm thanh nào được nhận diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateParentText(finalResult);
        }

        private void UpdateParentText(string jsonResult)
        {
            string recognizedText = ExtractTextFromJson(jsonResult);
            if (!string.IsNullOrEmpty(recognizedText))
            {
                var numberMapping = new Dictionary<string, string>()
                {
                    // số 0

                    { "không", "0" },
{ "hùng", "0" },
{ "khóc", "0" },
{ "khum", "0" },
{ "khâm", "0" },
{ "khung", "0" },
{ "khôm", "0" },
{ "khom", "0" },
{ "khùng", "0" },
{ "hôm", "0" },
{ "khồng", "0" },
{ "khoong", "0" },
{ "khóong", "0" },
{ "khoỏng", "0" },
{ "khô", "0" },
{ "hung", "0" },
{ "hum", "0" },
{ "thành", "0" },
{ "công", "0" },

{ "một", "1" },
{ "mộp", "1" },
{ "mọt", "1" },
{ "mụt", "1" },
{ "mợp", "1" },
{ "mợt", "1" },
{ "mọp", "1" },
{ "mộng", "1" },
{ "mộ", "1" },
{ "màu", "1" },
{ "ngọt", "1" },
{ "mê", "1" },
{ "mít", "1" },
{ "mộc", "1" },
{ "ma", "1" },
{ "mướp", "1" },

{ "hai", "2" },
{ "hây", "2" },
{ "hơi", "2" },
{ "hơ", "2" },
{ "he", "2" },
{ "hay", "2" },
{ "ai", "2" },
{ "hãy", "2" },
{ "hồn", "2" },

{ "ba", "3" },
{ "bay", "3" },
{ "be", "3" },
{ "bo", "3" },
{ "bâu", "3" },
{ "bà", "3" },
{ "buồng", "3" },

{ "bốn", "4" },
{ "bốm", "4" },
{ "bón", "4" },
{ "bóm", "4" },
{ "bún", "4" },
{ "vốn", "4" },
{ "buồn", "4" },
{ "môn", "4" },
{ "uống", "4" },
{ "muốn", "4" },

{ "năm", "5" },
{ "nằm", "5" },
{ "nam", "5" },
{ "nâm", "5" },
{ "nươm", "5" },
{ "nơm", "5" },
{ "năng", "5" },
{ "làm", "5" },

{ "sáu", "6" },
{ "sau", "6" },
{ "sấu", "6" },
{ "xấu", "6" },
{ "sáo", "6" },
{ "xáo", "6" },
{ "xáu", "6" },
{ "xáy", "6" },
{ "xấy", "6" },
{ "sáy", "6" },

{ "bảy", "7" },
{ "bẩy", "7" },
{ "bãy", "7" },
{ "bẫy", "7" },
{ "vậy", "7" },
{ "bải", "7" },
{ "bãi", "7" },

{ "tám", "8" },
{ "tắm", "8" },
{ "tóm", "8" },
{ "tớm", "8" },
{ "túm", "8" },

{ "chín", "9" },
{ "chính", "9" },
{ "chíến", "9" },
{ "chí", "9" },

{ "chấm", "." },
{ "chúm", "." }


                };
                string[] words = recognizedText.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (var word in words)
                {
                    if (numberMapping.ContainsKey(word))
                    {
                        sb.Append(numberMapping[word]);
                    }
                }
                string finalDigits = sb.ToString(); if (string.IsNullOrEmpty(finalDigits))
                {
                    MessageBox.Show("Không nhận diện được số nào trong giọng nói.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    parentForm.UpdateText(finalDigits);
                }
            }
            else
            {
                MessageBox.Show("Không thể nhận diện giọng nói. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ExtractTextFromJson(string json)
        {
            try
            {
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                return jsonObj.text ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartRecording();
            btnExit.Enabled = false;
            btnStart.Text = "Recording...";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopRecording();
            ProcessFinalResult();
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
            btnExit.IconColor = Color.White;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = DarkModeManager.GetBackgroundColor();
            btnExit.IconColor = DarkModeManager.GetForeColor();
        }
    }
}
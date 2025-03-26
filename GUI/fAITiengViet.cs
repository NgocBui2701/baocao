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
using Vosk;

namespace baocao.GUI
{
    public partial class fAITiengViet : Form
    {
        private fHopDong parentForm;
        private WaveInEvent waveIn;
        private VoskRecognizer recognizer;
        private bool isRecording = false;

        public fAITiengViet(fHopDong parent)
        {
            InitializeComponent();
            parentForm = parent;
            InitVosk();
        }

        private void InitVosk()
        {
            try
            {
                Vosk.Vosk.SetLogLevel(0);
                string modelPath = @"D:\baocao\vosk-model-vn-0.4";
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
            UpdateParentText(finalResult);
        }

        private void UpdateParentText(string jsonResult)
        {
            string recognizedText = ExtractTextFromJson(jsonResult);
            if (!string.IsNullOrEmpty(recognizedText))
            {
                var numberMapping = new Dictionary<string, string>()
                {
                    { "không", "0" },
                    { "hùng", "0" },
                    { "một", "1" },
                    { "mộng", "1" },
                    { "mộ", "1" },
                    { "màu", "1" },
                    { "ngọt", "1" },
                    { "mê", "1" },
                    { "hai", "2" },
                    { "hơi", "2" },
                    { "hay", "2" },
                    { "ai", "2" },
                    { "hãy", "2" },
                    { "ba", "3" },
                    { "bà", "3" },
                    { "buồng", "3" },
                    { "bốn", "4" },
                    { "vốn", "4" },
                    { "buồn", "4" },
                    { "môn", "4" },
                    { "uống", "4" },
                    { "năm", "5" },
                    { "nam", "5" },
                    { "sáu", "6" },
                    { "sau", "6" },
                    { "bảy", "7" },
                    { "vậy", "7" },
                    { "tám", "8" },
                    { "chín", "9" },
                    { "chính", "9" }
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
                string finalDigits = sb.ToString();
                parentForm.UpdateText(finalDigits);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (isRecording) StopRecording();
            recognizer?.Dispose();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartRecording();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopRecording();
            ProcessFinalResult();
            this.Close();
        }
    }
}

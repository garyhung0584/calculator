using System;
using System.Windows.Forms;

namespace calculator
{
    public partial class CalculatorForm : Form
    {
        private readonly Model _model = new Model();

        public CalculatorForm()
        {
            InitializeComponent();
        }

        // 載入事件
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Click += UpdateDisplay;
                }
            }
        }

        // 更新顯示
        private void UpdateDisplay(object sender, EventArgs e)
        {
            textBox1.Text = _model.GetDisplay();
        }

        // 數字事件
        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _model.ProcessDigit(button.Text);
            }
        }

        // 小數點事件
        private void ButtonDot_Click(object sender, EventArgs e)
        {
            _model.ProcessDecimal();
        }

        // 清除鍵事件
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            _model.ProcessClear();
        }

        // 顯示值事件
        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            _model.ProcessClearEntry();
        }

        // 加號事件
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            _model.ProcessOperation('+');
        }

        // 減號事件
        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            _model.ProcessOperation('-');
        }

        // 乘號事件
        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            _model.ProcessOperation('*');

        }

        // 除號事件
        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            _model.ProcessOperation('/');
        }

        // 等於事件
        private void ButtonEqual_Click(object sender, EventArgs e)
        {

            _model.ProcessEquals();
        }

        // 記憶體加事件
        private void ButtonMemoryPlus_Click(object sender, EventArgs e)
        {
            _model.ProcessMemoryOperation('+');
        }

        // 記憶體減事件
        private void ButtonMemoryMinus_Click(object sender, EventArgs e)
        {
            _model.ProcessMemoryOperation('-');
        }

        // 記憶體清除事件
        private void ButtonMemoryClear_Click(object sender, EventArgs e)
        {
            _model.ProcessMemoryOperation('C');
        }

        // 記憶體讀取事件
        private void ButtonMemoryRecall_Click(object sender, EventArgs e)
        {
            _model.ProcessMemoryRecall();
        }

        // 記憶體指定事件
        private void ButtonMemoryStore_Click(object sender, EventArgs e)
        {
            _model.ProcessMemoryOperation('S');
        }
    }
}

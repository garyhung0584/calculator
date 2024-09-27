using System.Web;
using System.Windows.Forms;

namespace calculator
{
    public class Model
    {
        // view更新 display使用
        public string GetDisplay()
        {
            return _display;
        }

        // 記憶體操作
        public void ProcessMemoryOperation(char sign)
        {
            if (_display == "")
            {
                return;
            }
            switch (sign)
            {
                case (char)Operation.MEMORY_CLEAR:
                    _memory = 0;
                    break;
                case (char)Operation.MEMORY_STORE:
                    _memory = double.Parse(_display);
                    break;
                case (char)Operation.PLUS:
                    _memory += double.Parse(_display);
                    break;
                case (char)Operation.MINUS:
                    _memory -= double.Parse(_display);
                    break;
            }
            ProcessClearEntry();
        }

        // 記憶體讀取
        public void ProcessMemoryRecall()
        {
            _display = _memory.ToString();
        }

        // 計算清除
        public void ProcessClear()
        {
            ProcessClearEntry();
            _value = "";
            _temp = 0;
            _operation = ' ';
        }

        // 清除輸入
        public void ProcessClearEntry()
        {
            _display = "";
        }

        // 計算等於
        public void ProcessEquals()
        {
            if (_value == "" || _display == "")
            {
                return;
            }

            double value;
            double display = double.Parse(_display);

            if (_temp != 0)
            {
                value = _temp;
            }
            else
            {
                _temp = display;
                value = double.Parse(_value);
            }
            Calculate(value, display);
            _value = _display;
            _isEqualPressed = true;
        }

        // 處理數字輸入
        public void ProcessDigit(string digit)
        {
            if (_display == "0" || _isEqualPressed)
            {
                ProcessClear();
                _display = digit;
            }
            else
            {
                _display += digit;
            }
            _temp = 0;
            _isEqualPressed = false;
        }

        // 處理小數點
        public void ProcessDecimal()
        {
            if (_isEqualPressed)
            {
                ProcessClear();
                _isEqualPressed = false;
            }
            if (!_display.Contains("."))
            {
                if (_display == "")
                {
                    _display = "0";
                }
                _display += ".";
            }
        }

        // 處理運算
        public void ProcessOperation(char operation)
        {
            if (_display != "" && _display != "-")
            {
                if (!_isEqualPressed)
                {
                    // 如果display的數字不是結果，則先計算
                    ProcessEquals();
                }
                _value = _display;
                _operation = operation;
                ProcessClearEntry();
            }
            else if (_display == "" && operation == (char)Operation.MINUS)
            {
                _display = "-";
            }
            else if (_display == "-")
            {
                _display = "";
            }
            _temp = 0;
            _isEqualPressed = false;
        }

        // 處理運算
        private void Calculate(double value, double display)
        {
            switch (_operation)
            {
                case (char)Operation.PLUS:
                    _display = (value + display).ToString();
                    break;
                case (char)Operation.MINUS:
                    if (_isEqualPressed)
                    {
                        _display = (display - value).ToString();
                    }
                    else
                    {
                        _display = (value - display).ToString();
                    }
                    break;
                case (char)Operation.MULTIPLY:
                    _display = (value * display).ToString();
                    break;
                case (char)Operation.DIVIDE:
                    if (display == 0)
                    {
                        MessageBox.Show("除數不能為0", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProcessClear();
                        break;
                    }
                    if (_isEqualPressed)
                    {
                        _display = (display / value).ToString();
                    }
                    else
                    {
                        _display = (value / display).ToString();
                    }
                    break;
            }
        }
        public enum Operation
        {
            MEMORY_CLEAR = 'C',
            MEMORY_STORE = 'S',
            PLUS = '+',
            MINUS = '-',
            MULTIPLY = '*',
            DIVIDE = '/'
        }

        // 私有變數
        private string _value = "";
        private string _display = "";
        private double _memory = 0;
        private char _operation;
        private double _temp = 0;
        private bool _isEqualPressed;
    }
}

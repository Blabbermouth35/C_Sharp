using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow
    {
        private decimal _inputtedNumber;
        private decimal _secondInputtedNumber;
        private char _currentOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string? buttonText = button.Content.ToString();
                if (decimal.TryParse(buttonText, out decimal number))
                {
                    _inputtedNumber = _inputtedNumber * 10 + number;
                    UpdateDisplay();
                }
            }
        }

        private void Button_Click_Operator(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string? operatorText = button.Content.ToString();
                if (operatorText is { Length: 1 } && "+-*/".Contains(operatorText))
                {
                    _currentOperator = operatorText[0];
                    _secondInputtedNumber = _inputtedNumber;
                    _inputtedNumber = 0;
                }
            }
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            if (_currentOperator != '\0')
            {
                switch (_currentOperator)
                {
                    case '+':
                        _inputtedNumber = _secondInputtedNumber + _inputtedNumber;
                        break;
                    case '-':
                        _inputtedNumber = _secondInputtedNumber - _inputtedNumber;
                        break;
                    case '*':
                        _inputtedNumber = _secondInputtedNumber * _inputtedNumber;
                        break;
                    case '/':
                        if (_inputtedNumber != 0)
                        {
                            _inputtedNumber = _secondInputtedNumber / _inputtedNumber;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero.");
                        }
                        break;
                }
                _currentOperator = '\0';
                UpdateDisplay();
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            _inputtedNumber = 0;
            _secondInputtedNumber = 0;
            _currentOperator = '\0';
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            CultureInfo europeanCulture = new CultureInfo("fr-FR");
            ResultTextBlock.Text = _inputtedNumber.ToString("F2", europeanCulture);
        }

    }
}

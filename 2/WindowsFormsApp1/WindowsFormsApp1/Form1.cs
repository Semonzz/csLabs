using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization; // Необходимо для использования CultureInfo 
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace lab2
{

    public class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }
        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }

    public partial class Form1 : Form
    {
        private TextBox[,] matrixTextBoxes;
        private int rows = 3; // Количество строк
        private int cols = 3; // Количество столбцов

        public Form1()
        {
            InitializeComponent();
            InitializeMatrixInputPanel(); // Инициализируем панели
        }

        private void WidthTrackBar_Scroll(object sender, EventArgs e)
        {
            cols = widthTrackBar.Value;
            InitializeMatrixInputPanel(); // Обновить панель ввода
        }

        private void HeightTrackBar_Scroll(object sender, EventArgs e)
        {
            rows = heightTrackBar.Value;
            InitializeMatrixInputPanel(); // Обновить панель ввода
        }

        private void InitializeMatrixInputPanel()
        {
            inputPanel.Controls.Clear(); // Очистить старые текстбоксы
            matrixTextBoxes = new TextBox[rows, cols];
            int textBoxWidth = 40;
            int textBoxHeight = 20;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrixTextBoxes[i, j] = new TextBox
                    {
                        Width = textBoxWidth,
                        Height = textBoxHeight,
                        Location = new Point(j * textBoxWidth, i * textBoxHeight)
                    };
                    inputPanel.Controls.Add(matrixTextBoxes[i, j]);
                }
            }
        }

        private void showMatrixButton_Click(object sender, EventArgs e) // Обработчик для кнопки
        {
            ShowMatrix(outputPanel);
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        

        private void ShowMatrix(Panel outputPanel)
        {
            panelError.ResetText();
            List<Pair<int, int>> listOFErrors = new List<Pair<int, int>>();
            List<Pair<double, bool>> listOfElements = new List<Pair<double, bool>>();

            outputPanel.Controls.Clear(); // Очистить предыдущее содержимое

            for (int i = 0; i < rows; i++)
            {
                listOfElements.Clear();
                double sum = 0;
                for (int j = 0; j < cols; j++)
                {

                    bool err = false;
                    double aij;
                    string input = matrixTextBoxes[i, j].Text.Trim();
                    input = input.Replace(',', '.');

                    CultureInfo culture = CultureInfo.InvariantCulture; 
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        err = true;
                        aij = 0;
                        listOFErrors.Add(new Pair<int, int>(i, j));
                    }
                    else if (!double.TryParse(input, NumberStyles.Any, culture, out aij))
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            err = true;
                            aij = 0;
                            listOFErrors.Add(new Pair<int, int>(i, j));
                        }
                        else if (!IsDigitsOnly(input))
                        {
                            err = true;
                            aij = 0;
                            listOFErrors.Add(new Pair<int, int>(i, j));
                        }

                    sum += aij;
                    listOfElements.Add(new Pair<double, bool>(aij, err));
                }
                for (int j = 0; j < cols; j++) {
                    Label label = new Label
                    {
                        Width = 40,
                        Height = 20,
                        Location = new Point(j * 40, i * 20)
                    };
                    if (sum > 0)
                    { 
                        label.Text = listOfElements[j].Second ? "Error" : (listOfElements[j].First /sum).ToString();
                        
                    }
                    if (sum < 0)
                    {
                        label.Text = listOfElements[j].Second ? "Error" : (-listOfElements[j].First / sum).ToString();
                    }
                    if (sum == 0)
                    {
                        label.Text = listOfElements[j].Second ? "Error" : "0";
                    }
                    
                    outputPanel.Controls.Add(label);
                }
            }


            String message = "Ошибки допущены в элементах: ";
            if (listOFErrors.Count == 0)
            {
                message = "Ошибок при заполнении нет.";
            }

            for (int i = 0; i < listOFErrors.Count; i++)
            {
                message += ("(" + (listOFErrors[i].First + ", " + listOFErrors[i].Second + "), "));
            }

            Label labelErr = new Label
            {
                Text = message.ToString(),
                Width = 1000,
                Height = 30,

            };
            panelError.Controls.Clear();
            panelError.Controls.Add(labelErr);
        }
    }
}
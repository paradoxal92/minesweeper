using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace саперянварь
{
    public partial class Form1 : Form
    {
        private int[,] matrix;
        private bool isButtonClicked;
        private int Numberofbombs;
        private Timer timer;
        private int seconds;
        private int minutes;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            // создаем матрицу которая представляет собой игровое поле где 0 - это мина, 9 - пустая клетка и остальные цифры представляют собой количество мин с соседних клетках
            int matrixSize = 16;
            Random random = new Random();
            matrix = new int[matrixSize, matrixSize];
            HashSet<int> chosenNumbers = new HashSet<int>();
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            for (int i = 0; i < 40; i++)
            {
                int cost = 0;
                int r;

                do
                {
                    r = random.Next(0, matrixSize * matrixSize);
                } while (chosenNumbers.Contains(r));

                chosenNumbers.Add(r);

                for (int k = 0; k < matrixSize; k++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        cost += 1;
                        if (cost == r)
                        {
                            matrix[k, j] = 0;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    int count = 0;
                    if (matrix[i, j] != 0)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                for (int k = i; k < i + 2; k++)
                                {
                                    for (int l = j; l < j + 2; l++)
                                    {
                                        if (matrix[k, l] == 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    matrix[i, j] = count;
                                }
                                else
                                {
                                    matrix[i, j] = 9;
                                }
                            }
                            else if (j == matrixSize - 1)
                            {
                                for (int k = i; k < i + 2; k++)
                                {
                                    for (int l = j - 1; l < j + 1; l++)
                                    {
                                        if (matrix[k, l] == 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    matrix[i, j] = count;
                                }
                                else
                                {
                                    matrix[i, j] = 9;
                                }
                            }
                            else
                            {
                                for (int k = i; k < i + 2; k++)
                                {
                                    for (int l = j - 1; l < j + 2; l++)
                                    {
                                        if (matrix[k, l] == 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    matrix[i, j] = count;
                                }
                                else
                                {
                                    matrix[i, j] = 9;
                                }
                            }
                        }
                        if (i == matrixSize - 1)
                        {
                            if (j == 0)
                            {
                                for (int k = i - 1; k < i + 1; k++)
                                {
                                    for (int l = j; l < j + 2; l++)
                                    {
                                        if (matrix[k, l] == 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    matrix[i, j] = count;
                                }
                                else
                                {
                                    matrix[i, j] = 9;
                                }
                            }
                            else if (j == matrixSize - 1)
                            {
                                for (int k = i - 1; k < i + 1; k++)
                                {
                                    for (int l = j - 1; l < j + 1; l++)
                                    {
                                        if (matrix[k, l] == 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    matrix[i, j] = count;
                                }
                                else
                                {
                                    matrix[i, j] = 9;
                                }
                            }
                            else
                            {
                                for (int k = i - 1; k < i + 1; k++)
                                {
                                    for (int l = j - 1; l < j + 2; l++)
                                    {
                                        if (matrix[k, l] == 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                                if (count != 0)
                                {
                                    matrix[i, j] = count;
                                }
                                else
                                {
                                    matrix[i, j] = 9;
                                }
                            }
                        }
                        if ((j == 0) & (i != 0) & (i != matrixSize - 1))
                        {
                            for (int k = i - 1; k < i + 2; k++)
                            {
                                for (int l = j; l < j + 2; l++)
                                {
                                    if (matrix[k, l] == 0)
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            if (count != 0)
                            {
                                matrix[i, j] = count;
                            }
                            else
                            {
                                matrix[i, j] = 9;
                            }
                        }
                        if ((j == matrixSize - 1) & (i != 0) & (i != matrixSize - 1))
                        {
                            for (int k = i - 1; k < i + 2; k++)
                            {
                                for (int l = j - 1; l < j + 1; l++)
                                {
                                    if (matrix[k, l] == 0)
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            if (count != 0)
                            {
                                matrix[i, j] = count;
                            }
                            else
                            {
                                matrix[i, j] = 9;
                            }
                        }
                        if ((i != 0) & (j != 0) & (i != matrixSize - 1) & (j != matrixSize - 1))
                        {
                            for (int k = i - 1; k < i + 2; k++)
                            {
                                for (int l = j - 1; l < j + 2; l++)
                                {
                                    if (matrix[k, l] == 0)
                                    {
                                        count += 1;
                                    }
                                }
                            }
                            if (count != 0)
                            {
                                matrix[i, j] = count;
                            }
                            else
                            {
                                matrix[i, j] = 9;
                            }
                        }



                    }
                }
            }
            pictureBox1.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\bomb40.png");
            pictureBox1.Show();
            button2.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\flag.png");
            isButtonClicked = true;
            Numberofbombs = 40;
            InitializeTimer();
            timer.Start();
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
                UpdateTime();
            }

            UpdateTime();
        }
        private void UpdateTime()
        {
            // Установка картинок в PictureBox для отображения времени
            pictureBoxSeconds1.Image = GetImageForDigit(seconds % 10);
            pictureBoxSeconds2.Image = GetImageForDigit(seconds / 10);
            pictureBoxMinutes1.Image = GetImageForDigit(minutes % 10);
            pictureBoxMinutes2.Image = GetImageForDigit(minutes / 10);
        }

        private Image GetImageForDigit(int digit)
        {
            switch (digit)
            {
                case 0:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time0.png");
                case 1:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time1.png");
                case 2:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time2.png");
                case 3:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time3.png");
                case 4:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time4.png");
                case 5:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time5.png");
                case 6:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time6.png");
                case 7:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time7.png");
                case 8:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time8.png");
                case 9:
                    return Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\time9.png");
                default:
                    return null;
            }
        }
        private void proverka(int x, int y)
        {
            if (matrix[x, y] == 0)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\bomb.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 1)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\1.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 2)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\2.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 3)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\3.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 4)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\4.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 5)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\5.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 6)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\6.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 7)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\7.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 8)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\8.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 9)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\0.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
        }
        private void proverka1(int x, int y)
        {
            if (isButtonClicked == false)
            {
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button.Image != null)
                {
                    button.Image = null;
                    button.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\cell2.png");
                    Numberofbombs += 1;
                }
                else
                {
                    if (Numberofbombs != 0)
                    {
                        button.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\flag2.png");
                        Numberofbombs -= 1;
                    }
                }
                pictureBox1.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\bomb" + Numberofbombs.ToString() + ".png");
            }
            else if (matrix[x, y] == 0)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\bomb.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            proverka(i, j);
                        }
                    }
                }
                timer.Stop();
                button1.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\sad.png");
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }

                // Включаем конкретную кнопку
                button1.Enabled = true;
            }
            else if (matrix[x, y] == 1)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\1.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 2)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\2.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 3)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\3.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 4)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\4.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 5)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\5.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 6)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\6.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 7)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\7.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 8)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", x + 1, y + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\8.png");
                    pictureBox.Show();

                }
                var buttonName = string.Format("button{0}_{1}", x + 1, y + 1);
                var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Visible = false;

                }
            }
            else if (matrix[x, y] == 9)
            {
                OpenCell(x, y);
            }
        }
        private void Checkingthecondition()
        {
            for (int i = 0; i < 16; i++) 
            { 
                for (int j = 0; j < 16; j++) 
                {
                    var buttonName = string.Format("button{0}_{1}", i + 1, j + 1);
                    var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                    if (button != null)
                    {
                        if (button.Visible == true)
                        {
                            if (matrix[i, j] != 0)
                            {
                                return;
                            }
                        }

                    }
                }
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        var buttonName = string.Format("button{0}_{1}", i + 1, j + 1);
                        var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
                        button.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\flag2.png");
                    }
                }
            }
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
            pictureBox1.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\bomb0.png");
            timer.Stop();
            // Включаем конкретную кнопку
            button1.Enabled = true;
            button1.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\cool.png");

        }
        // открываем пустые клетки
        private void OpenCell(int row, int col)
        {
            var buttonName = string.Format("button{0}_{1}", row + 1, col + 1);
            var button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
            if (button == null || button.Visible == false || row < 0 || col < 0 || row >= 16 || col >= 16 || matrix[row, col] != 9)
            {
                return;
            }
            if (matrix[row, col] == 9)
            {
                string pictureBoxName = string.Format("pictureBox{0}_{1}", row + 1, col + 1);
                var pictureBox = Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\0.png");
                    pictureBox.Show();

                }
                button.Visible = false;
                // проверка верхней клетки
                if (row > 0 && matrix[row - 1, col] >= 1 && matrix[row - 1, col] <= 8)
                {
                    proverka(row - 1, col);
                }

                // Проверка нижней клетки
                if (row < 15 && matrix[row + 1, col] >= 1 && matrix[row + 1, col] <= 8)
                {
                    proverka(row + 1, col);
                }

                // Проверка левой клетки
                if (col > 0 && matrix[row, col - 1] >= 1 && matrix[row, col - 1] <= 8)
                {
                    proverka(row, col - 1);
                }

                // Проверка правой клетки
                if (col < 15 && matrix[row, col + 1] >= 1 && matrix[row, col + 1] <= 8)
                {
                    proverka(row, col + 1);
                }

                // Проверка верхней-левой клетки
                if (row > 0 && col > 0 && matrix[row - 1, col - 1] >= 1 && matrix[row - 1, col - 1] <= 8)
                {
                    proverka(row - 1, col - 1);
                }

                // Проверка верхней-правой клетки
                if (row > 0 && col < 15 && matrix[row - 1, col + 1] >= 1 && matrix[row - 1, col + 1] <= 8)
                {
                    proverka(row - 1, col + 1);
                }

                // Проверка нижней-левой клетки
                if (row < 15 && col > 0 && matrix[row + 1, col - 1] >= 1 && matrix[row + 1, col - 1] <= 8)
                {
                    proverka(row + 1, col - 1);
                }

                // Проверка нижней-правой клетки
                if (row < 15 && col < 15 && matrix[row + 1, col + 1] >= 1 && matrix[row + 1, col + 1] <= 8)
                {
                    proverka(row + 1, col + 1);
                }
            }

                // Поиск вверх
            OpenCell(row - 1, col);
                // Поиск вниз
            OpenCell(row + 1, col);
            // Поиск влево
            OpenCell(row, col - 1);
            // Поиск вправо
            OpenCell(row, col + 1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_1_Click(object sender, EventArgs e)
        {    
            proverka1(0,0);
            Checkingthecondition();
        }

        private void button1_2_Click(object sender, EventArgs e)
        {
            proverka1(0, 1);
            Checkingthecondition();
        }

        private void button1_3_Click(object sender, EventArgs e)
        {
            proverka1(0, 2);
            Checkingthecondition();
        }

        private void button1_4_Click(object sender, EventArgs e)
        {
            proverka1(0, 3);
            Checkingthecondition();
        }

        private void button1_5_Click(object sender, EventArgs e)
        {
            proverka1(0, 4);
            Checkingthecondition();
        }

        private void button1_6_Click(object sender, EventArgs e)
        {
            proverka1(0, 5);
            Checkingthecondition();
        }

        private void button1_7_Click(object sender, EventArgs e)
        {
            proverka1(0, 6);
            Checkingthecondition();
        }

        private void button1_8_Click(object sender, EventArgs e)
        {
            proverka1(0, 7);
            Checkingthecondition();
        }

        private void button1_9_Click(object sender, EventArgs e)
        {
            proverka1(0, 8);
            Checkingthecondition();
        }

        private void button1_10_Click(object sender, EventArgs e)
        {
            proverka1(0, 9);
            Checkingthecondition();
        }

        private void button1_11_Click(object sender, EventArgs e)
        {
            proverka1(0, 10);
            Checkingthecondition();
        }

        private void button1_12_Click(object sender, EventArgs e)
        {
            proverka1(0, 11);
            Checkingthecondition();
        }

        private void button1_13_Click(object sender, EventArgs e)
        {
            proverka1(0, 12);
            Checkingthecondition();
        }

        private void button1_14_Click(object sender, EventArgs e)
        {
            proverka1(0, 13);
            Checkingthecondition();
        }

        private void button1_15_Click(object sender, EventArgs e)
        {
            proverka1(0, 14);
            Checkingthecondition();
        }

        private void button1_16_Click(object sender, EventArgs e)
        {
            proverka1(0, 15);
            Checkingthecondition();
        }

        private void button2_1_Click(object sender, EventArgs e)
        {
            proverka1(1, 0);
            Checkingthecondition();
        }

        private void button2_2_Click(object sender, EventArgs e)
        {
            proverka1(1, 1);
            Checkingthecondition();
        }

        private void button2_3_Click(object sender, EventArgs e)
        {
            proverka1(1, 2);
            Checkingthecondition();
        }

        private void button2_4_Click(object sender, EventArgs e)
        {
            proverka1(1, 3);
            Checkingthecondition();
        }

        private void button2_5_Click(object sender, EventArgs e)
        {
            proverka1(1, 4);
            Checkingthecondition();
        }

        private void button2_6_Click(object sender, EventArgs e)
        {
            proverka1(1, 5);
            Checkingthecondition();
        }

        private void button2_7_Click(object sender, EventArgs e)
        {
            proverka1(1, 6);
            Checkingthecondition();
        }

        private void button2_8_Click(object sender, EventArgs e)
        {
            proverka1(1, 7);
            Checkingthecondition();
        }

        private void button2_9_Click(object sender, EventArgs e)
        {
            proverka1(1, 8);
            Checkingthecondition();
        }

        private void button2_10_Click(object sender, EventArgs e)
        {
            proverka1(1, 9);
            Checkingthecondition();
        }

        private void button2_11_Click(object sender, EventArgs e)
        {
            proverka1(1, 10);
            Checkingthecondition();
        }

        private void button2_12_Click(object sender, EventArgs e)
        {
            proverka1(1, 11);
            Checkingthecondition();
        }

        private void button2_13_Click(object sender, EventArgs e)
        {
            proverka1(1, 12);
            Checkingthecondition();
        }

        private void button2_14_Click(object sender, EventArgs e)
        {
            proverka1(1, 13);
            Checkingthecondition();
        }

        private void button2_15_Click(object sender, EventArgs e)
        {
            proverka1(1, 14);
            Checkingthecondition();
        }

        private void button2_16_Click(object sender, EventArgs e)
        {
            proverka1(1, 15);
            Checkingthecondition();
        }

        private void button3_1_Click(object sender, EventArgs e)
        {
            proverka1(2, 0);
            Checkingthecondition();
        }

        private void button3_2_Click(object sender, EventArgs e)
        {
            proverka1(2, 1);
            Checkingthecondition();
        }

        private void button3_3_Click(object sender, EventArgs e)
        {
            proverka1(2, 2);
            Checkingthecondition();
        }

        private void button3_4_Click(object sender, EventArgs e)
        {
            proverka1(2, 3);
            Checkingthecondition();
        }

        private void button3_5_Click(object sender, EventArgs e)
        {
            proverka1(2, 4);
            Checkingthecondition();
        }

        private void button3_6_Click(object sender, EventArgs e)
        {
            proverka1(2, 5);
            Checkingthecondition();
        }

        private void button3_7_Click(object sender, EventArgs e)
        {
            proverka1(2, 6);
            Checkingthecondition();
        }

        private void button3_8_Click(object sender, EventArgs e)
        {
            proverka1(2, 7);
            Checkingthecondition();
        }

        private void button3_9_Click(object sender, EventArgs e)
        {
            proverka1(2, 8);
            Checkingthecondition();
        }

        private void button3_10_Click(object sender, EventArgs e)
        {
            proverka1(2, 9);
            Checkingthecondition();
        }

        private void button3_11_Click(object sender, EventArgs e)
        {
            proverka1(2, 10);
            Checkingthecondition();
        }

        private void button3_12_Click(object sender, EventArgs e)
        {
            proverka1(2, 11);
            Checkingthecondition();
        }

        private void button3_13_Click(object sender, EventArgs e)
        {
            proverka1(2, 12);
            Checkingthecondition();
        }

        private void button3_14_Click(object sender, EventArgs e)
        {
            proverka1(2, 13);
            Checkingthecondition();
        }

        private void button3_15_Click(object sender, EventArgs e)
        {
            proverka1(2, 14);
            Checkingthecondition();
        }

        private void button3_16_Click(object sender, EventArgs e)
        {
            proverka1(2, 15);
            Checkingthecondition();
        }

        private void button4_1_Click(object sender, EventArgs e)
        {
            proverka1(3, 0);
            Checkingthecondition();
        }

        private void button4_2_Click(object sender, EventArgs e)
        {
            proverka1(3, 1);
            Checkingthecondition();
        }

        private void button4_3_Click(object sender, EventArgs e)
        {
            proverka1(3, 2);
            Checkingthecondition();
        }

        private void button4_4_Click(object sender, EventArgs e)
        {
            proverka1(3, 3);
            Checkingthecondition();
        }

        private void button4_5_Click(object sender, EventArgs e)
        {
            proverka1(3, 4);
            Checkingthecondition();
        }

        private void button4_6_Click(object sender, EventArgs e)
        {
            proverka1(3, 5);
            Checkingthecondition();
        }

        private void button4_7_Click(object sender, EventArgs e)
        {
            proverka1(3, 6);
            Checkingthecondition();
        }

        private void button4_8_Click(object sender, EventArgs e)
        {
            proverka1(3, 7);
            Checkingthecondition();
        }

        private void button4_9_Click(object sender, EventArgs e)
        {
            proverka1(3, 8);
            Checkingthecondition();
        }

        private void button4_10_Click(object sender, EventArgs e)
        {
            proverka1(3, 9);
            Checkingthecondition();
        }

        private void button4_11_Click(object sender, EventArgs e)
        {
            proverka1(3, 10);
            Checkingthecondition();
        }

        private void button4_12_Click(object sender, EventArgs e)
        {
            proverka1(3, 11);
            Checkingthecondition();
        }

        private void button4_13_Click(object sender, EventArgs e)
        {
            proverka1(3, 12);
            Checkingthecondition();
        }

        private void button4_14_Click(object sender, EventArgs e)
        {
            proverka1(3, 13);
            Checkingthecondition();
        }

        private void button4_15_Click(object sender, EventArgs e)
        {
            proverka1(3, 14);
            Checkingthecondition();
        }

        private void button4_16_Click(object sender, EventArgs e)
        {
            proverka1(3, 15);
            Checkingthecondition();
        }

        private void button5_1_Click(object sender, EventArgs e)
        {
            proverka1(4, 0);
            Checkingthecondition();
        }

        private void button5_2_Click(object sender, EventArgs e)
        {
            proverka1(4, 1);
            Checkingthecondition();
        }

        private void button5_3_Click(object sender, EventArgs e)
        {
            proverka1(4, 2);
            Checkingthecondition();
        }

        private void button5_4_Click(object sender, EventArgs e)
        {
            proverka1(4, 3);
            Checkingthecondition();
        }

        private void button5_5_Click(object sender, EventArgs e)
        {
            proverka1(4, 4);
            Checkingthecondition();
        }

        private void button5_6_Click(object sender, EventArgs e)
        {
            proverka1(4, 5);
            Checkingthecondition();
        }

        private void button5_7_Click(object sender, EventArgs e)
        {
            proverka1(4, 6);
            Checkingthecondition();
        }

        private void button5_8_Click(object sender, EventArgs e)
        {
            proverka1(4, 7);
            Checkingthecondition();
        }

        private void button5_9_Click(object sender, EventArgs e)
        {
            proverka1(4, 8);
            Checkingthecondition();
        }

        private void button5_10_Click(object sender, EventArgs e)
        {
            proverka1(4, 9);
            Checkingthecondition();
        }

        private void button5_11_Click(object sender, EventArgs e)
        {
            proverka1(4, 10);
            Checkingthecondition();
        }

        private void button5_12_Click(object sender, EventArgs e)
        {
            proverka1(4, 11);
            Checkingthecondition();
        }

        private void button5_13_Click(object sender, EventArgs e)
        {
            proverka1(4, 12);
            Checkingthecondition();
        }

        private void button5_14_Click(object sender, EventArgs e)
        {
            proverka1(4, 13);
            Checkingthecondition();
        }

        private void button5_15_Click(object sender, EventArgs e)
        {
            proverka1(4, 14);
            Checkingthecondition();
        }

        private void button5_16_Click(object sender, EventArgs e)
        {
            proverka1(4, 15);
            Checkingthecondition();
        }

        private void button6_1_Click(object sender, EventArgs e)
        {
            proverka1(5, 0);
            Checkingthecondition();
        }

        private void button6_2_Click(object sender, EventArgs e)
        {
            proverka1(5, 1);
            Checkingthecondition();
        }

        private void button6_3_Click(object sender, EventArgs e)
        {
            proverka1(5, 2);
            Checkingthecondition();
        }

        private void button6_4_Click(object sender, EventArgs e)
        {
            proverka1(5, 3);
            Checkingthecondition();
        }

        private void button6_5_Click(object sender, EventArgs e)
        {
            proverka1(5, 4);
            Checkingthecondition();
        }

        private void button6_6_Click(object sender, EventArgs e)
        {
            proverka1(5, 5);
            Checkingthecondition();
        }

        private void button6_7_Click(object sender, EventArgs e)
        {
            proverka1(5, 6);
            Checkingthecondition();
        }

        private void button6_8_Click(object sender, EventArgs e)
        {
            proverka1(5, 7);
            Checkingthecondition();
        }

        private void button6_9_Click(object sender, EventArgs e)
        {
            proverka1(5, 8);
            Checkingthecondition();
        }

        private void button6_10_Click(object sender, EventArgs e)
        {
            proverka1(5, 9);
            Checkingthecondition();
        }

        private void button6_11_Click(object sender, EventArgs e)
        {
            proverka1(5, 10);
            Checkingthecondition();
        }

        private void button6_12_Click(object sender, EventArgs e)
        {
            proverka1(5, 11);
            Checkingthecondition();
        }

        private void button6_13_Click(object sender, EventArgs e)
        {
            proverka1(5, 12);
            Checkingthecondition();
        }

        private void button6_14_Click(object sender, EventArgs e)
        {
            proverka1(5, 13);
            Checkingthecondition();
        }

        private void button6_15_Click(object sender, EventArgs e)
        {
            proverka1(5, 14);
            Checkingthecondition();
        }

        private void button6_16_Click(object sender, EventArgs e)
        {
            proverka1(5, 15);
            Checkingthecondition();
        }

        private void button7_1_Click(object sender, EventArgs e)
        {
            proverka1(6, 0);
            Checkingthecondition();
        }

        private void button7_2_Click(object sender, EventArgs e)
        {
            proverka1(6, 1);
            Checkingthecondition();
        }

        private void button7_3_Click(object sender, EventArgs e)
        {
            proverka1(6, 2);
            Checkingthecondition();
        }

        private void button7_4_Click(object sender, EventArgs e)
        {
            proverka1(6, 3);
            Checkingthecondition();
        }

        private void button7_5_Click(object sender, EventArgs e)
        {
            proverka1(6, 4);
            Checkingthecondition();
        }

        private void button7_6_Click(object sender, EventArgs e)
        {
            proverka1(6, 5);
            Checkingthecondition();
        }

        private void button7_7_Click(object sender, EventArgs e)
        {
            proverka1(6, 6);
            Checkingthecondition();
        }

        private void button7_8_Click(object sender, EventArgs e)
        {
            proverka1(6, 7);
            Checkingthecondition();
        }

        private void button7_9_Click(object sender, EventArgs e)
        {
            proverka1(6, 8);
            Checkingthecondition();
        }

        private void button7_10_Click(object sender, EventArgs e)
        {
            proverka1(6, 9);
            Checkingthecondition();
        }

        private void button7_11_Click(object sender, EventArgs e)
        {
            proverka1(6, 10);
            Checkingthecondition();
        }

        private void button7_12_Click(object sender, EventArgs e)
        {
            proverka1(6, 11);
            Checkingthecondition();
        }

        private void button7_13_Click(object sender, EventArgs e)
        {
            proverka1(6, 12);
            Checkingthecondition();
        }

        private void button7_14_Click(object sender, EventArgs e)
        {
            proverka1(6, 13);
            Checkingthecondition();
        }

        private void button7_15_Click(object sender, EventArgs e)
        {
            proverka1(6, 14);
            Checkingthecondition();
        }

        private void button7_16_Click(object sender, EventArgs e)
        {
            proverka1(6, 15);
            Checkingthecondition();
        }

        private void button8_1_Click(object sender, EventArgs e)
        {
            proverka1(7, 0);
            Checkingthecondition();
        }

        private void button8_2_Click(object sender, EventArgs e)
        {
            proverka1(7, 1);
            Checkingthecondition();
        }

        private void button8_3_Click(object sender, EventArgs e)
        {
            proverka1(7, 2);
            Checkingthecondition();
        }

        private void button8_4_Click(object sender, EventArgs e)
        {
            proverka1(7, 3);
            Checkingthecondition();
        }

        private void button8_5_Click(object sender, EventArgs e)
        {
            proverka1(7, 4);
            Checkingthecondition();
        }

        private void button8_6_Click(object sender, EventArgs e)
        {
            proverka1(7, 5);
            Checkingthecondition();
        }

        private void button8_7_Click(object sender, EventArgs e)
        {
            proverka1(7, 6);
            Checkingthecondition();
        }

        private void button8_8_Click(object sender, EventArgs e)
        {
            proverka1(7, 7);
            Checkingthecondition();
        }

        private void button8_9_Click(object sender, EventArgs e)
        {
            proverka1(7, 8);
            Checkingthecondition();
        }

        private void button8_10_Click(object sender, EventArgs e)
        {
            proverka1(7, 9);
            Checkingthecondition();
        }

        private void button8_11_Click(object sender, EventArgs e)
        {
            proverka1(7, 10);
            Checkingthecondition();
        }

        private void button8_12_Click(object sender, EventArgs e)
        {
            proverka1(7, 11);
            Checkingthecondition();
        }

        private void button8_13_Click(object sender, EventArgs e)
        {
            proverka1(7, 12);
            Checkingthecondition();
        }

        private void button8_14_Click(object sender, EventArgs e)
        {
            proverka1(7, 13);
            Checkingthecondition();
        }

        private void button8_15_Click(object sender, EventArgs e)
        {
            proverka1(7, 14);
            Checkingthecondition();
        }

        private void button8_16_Click(object sender, EventArgs e)
        {
            proverka1(7, 15);
            Checkingthecondition();
        }

        private void button9_1_Click(object sender, EventArgs e)
        {
            proverka1(8, 0);
            Checkingthecondition();
        }

        private void button9_2_Click(object sender, EventArgs e)
        {
            proverka1(8, 1);
            Checkingthecondition();
        }

        private void button9_3_Click(object sender, EventArgs e)
        {
            proverka1(8, 2);
            Checkingthecondition();
        }

        private void button9_4_Click(object sender, EventArgs e)
        {
            proverka1(8, 3);
            Checkingthecondition();
        }

        private void button9_5_Click(object sender, EventArgs e)
        {
            proverka1(8, 4);
            Checkingthecondition();
        }

        private void button9_6_Click(object sender, EventArgs e)
        {
            proverka1(8, 5);
            Checkingthecondition();
        }

        private void button9_7_Click(object sender, EventArgs e)
        {
            proverka1(8, 6);
            Checkingthecondition();
        }

        private void button9_8_Click(object sender, EventArgs e)
        {
            proverka1(8, 7);
            Checkingthecondition();
        }

        private void button9_9_Click(object sender, EventArgs e)
        {
            proverka1(8, 8);
            Checkingthecondition();
        }

        private void button9_10_Click(object sender, EventArgs e)
        {
            proverka1(8, 9);
            Checkingthecondition();
        }

        private void button9_11_Click(object sender, EventArgs e)
        {
            proverka1(8, 10);
            Checkingthecondition();
        }

        private void button9_12_Click(object sender, EventArgs e)
        {
            proverka1(8, 11);
            Checkingthecondition();
        }

        private void button9_13_Click(object sender, EventArgs e)
        {
            proverka1(8, 12);
            Checkingthecondition();
        }

        private void button9_14_Click(object sender, EventArgs e)
        {
            proverka1(8, 13);
            Checkingthecondition();
        }

        private void button9_15_Click(object sender, EventArgs e)
        {
            proverka1(8, 14);
            Checkingthecondition();
        }

        private void button9_16_Click(object sender, EventArgs e)
        {
            proverka1(8, 15);
            Checkingthecondition();
        }

        private void button10_1_Click(object sender, EventArgs e)
        {
            proverka1(9, 0);
            Checkingthecondition();
        }

        private void button10_2_Click(object sender, EventArgs e)
        {
            proverka1(9, 1);
            Checkingthecondition();
        }

        private void button10_3_Click(object sender, EventArgs e)
        {
            proverka1(9, 2);
            Checkingthecondition();
        }

        private void button10_4_Click(object sender, EventArgs e)
        {
            proverka1(9, 3);
            Checkingthecondition();
        }

        private void button10_5_Click(object sender, EventArgs e)
        {
            proverka1(9, 4);
            Checkingthecondition();
        }

        private void button10_6_Click(object sender, EventArgs e)
        {
            proverka1(9, 5);
            Checkingthecondition();
        }

        private void button10_7_Click(object sender, EventArgs e)
        {
            proverka1(9, 6);
            Checkingthecondition();
        }

        private void button10_8_Click(object sender, EventArgs e)
        {
            proverka1(9, 7);
            Checkingthecondition();
        }

        private void button10_9_Click(object sender, EventArgs e)
        {
            proverka1(9, 8);
            Checkingthecondition();
        }

        private void button10_10_Click(object sender, EventArgs e)
        {
            proverka1(9, 9);
            Checkingthecondition();
        }

        private void button10_11_Click(object sender, EventArgs e)
        {
            proverka1(9, 10);
            Checkingthecondition();
        }

        private void button10_12_Click(object sender, EventArgs e)
        {
            proverka1(9, 11);
            Checkingthecondition();
        }

        private void button10_13_Click(object sender, EventArgs e)
        {
            proverka1(9, 12);
            Checkingthecondition();
        }

        private void button10_14_Click(object sender, EventArgs e)
        {
            proverka1(9, 13);
            Checkingthecondition();
        }

        private void button10_15_Click(object sender, EventArgs e)
        {
            proverka1(9, 14);
            Checkingthecondition();
        }

        private void button10_16_Click(object sender, EventArgs e)
        {
            proverka1(9, 15);
            Checkingthecondition();
        }

        private void button11_1_Click(object sender, EventArgs e)
        {
            proverka1(10, 0);
            Checkingthecondition();
        }

        private void button11_2_Click(object sender, EventArgs e)
        {
            proverka1(10, 1);
            Checkingthecondition();
        }

        private void button11_3_Click(object sender, EventArgs e)
        {
            proverka1(10, 2);
            Checkingthecondition();
        }

        private void button11_4_Click(object sender, EventArgs e)
        {
            proverka1(10, 3);
            Checkingthecondition();
        }

        private void button11_5_Click(object sender, EventArgs e)
        {
            proverka1(10, 4);
            Checkingthecondition();
        }

        private void button11_6_Click(object sender, EventArgs e)
        {
            proverka1(10, 5);
            Checkingthecondition();
        }

        private void button11_7_Click(object sender, EventArgs e)
        {
            proverka1(10, 6);
            Checkingthecondition();
        }

        private void button11_8_Click(object sender, EventArgs e)
        {
            proverka1(10, 7);
            Checkingthecondition();
        }

        private void button11_9_Click(object sender, EventArgs e)
        {
            proverka1(10, 8);
            Checkingthecondition();
        }

        private void button11_10_Click(object sender, EventArgs e)
        {
            proverka1(10, 9);
            Checkingthecondition();
        }

        private void button11_11_Click(object sender, EventArgs e)
        {
            proverka1(10, 10);
            Checkingthecondition();
        }

        private void button11_12_Click(object sender, EventArgs e)
        {
            proverka1(10, 11);
            Checkingthecondition();
        }

        private void button11_13_Click(object sender, EventArgs e)
        {
            proverka1(10, 12);
            Checkingthecondition();
        }

        private void button11_14_Click(object sender, EventArgs e)
        {
            proverka1(10, 13);
            Checkingthecondition();
        }

        private void button11_15_Click(object sender, EventArgs e)
        {
            proverka1(10, 14);
            Checkingthecondition();
        }

        private void button11_16_Click(object sender, EventArgs e)
        {
            proverka1(10, 15);
            Checkingthecondition();
        }

        private void button12_1_Click(object sender, EventArgs e)
        {
            proverka1(11, 0);
            Checkingthecondition();
        }

        private void button12_2_Click(object sender, EventArgs e)
        {
            proverka1(11, 1);
            Checkingthecondition();
        }

        private void button12_3_Click(object sender, EventArgs e)
        {
            proverka1(11, 2);
            Checkingthecondition();
        }

        private void button12_4_Click(object sender, EventArgs e)
        {
            proverka1(11, 3);
            Checkingthecondition();
        }

        private void button12_5_Click(object sender, EventArgs e)
        {
            proverka1(11, 4);
            Checkingthecondition();
        }

        private void button12_6_Click(object sender, EventArgs e)
        {
            proverka1(11, 5);
            Checkingthecondition();
        }

        private void button12_7_Click(object sender, EventArgs e)
        {
            proverka1(11, 6);
            Checkingthecondition();
        }

        private void button12_8_Click(object sender, EventArgs e)
        {
            proverka1(11, 7);
            Checkingthecondition();
        }

        private void button12_9_Click(object sender, EventArgs e)
        {
            proverka1(11, 8);
            Checkingthecondition();
        }

        private void button12_10_Click(object sender, EventArgs e)
        {
            proverka1(11, 9);
            Checkingthecondition();
        }

        private void button12_11_Click(object sender, EventArgs e)
        {
            proverka1(11, 10);
            Checkingthecondition();
        }

        private void button12_12_Click(object sender, EventArgs e)
        {
            proverka1(11, 11);
            Checkingthecondition();
        }

        private void button12_13_Click(object sender, EventArgs e)
        {
            proverka1(11, 12);
            Checkingthecondition();
        }

        private void button12_14_Click(object sender, EventArgs e)
        {
            proverka1(11, 13);
            Checkingthecondition();
        }

        private void button12_15_Click(object sender, EventArgs e)
        {
            proverka1(11, 14);
            Checkingthecondition();
        }

        private void button12_16_Click(object sender, EventArgs e)
        {
            proverka1(11, 15);
            Checkingthecondition();
        }

        private void button13_1_Click(object sender, EventArgs e)
        {
            proverka1(12, 0);
            Checkingthecondition();
        }

        private void button13_2_Click(object sender, EventArgs e)
        {
            proverka1(12, 1);
            Checkingthecondition();
        }

        private void button13_3_Click(object sender, EventArgs e)
        {
            proverka1(12, 2);
            Checkingthecondition();
        }

        private void button13_4_Click(object sender, EventArgs e)
        {
            proverka1(12, 3);
            Checkingthecondition();
        }

        private void button13_5_Click(object sender, EventArgs e)
        {
            proverka1(12, 4);
            Checkingthecondition();
        }

        private void button13_6_Click(object sender, EventArgs e)
        {
            proverka1(12, 5);
            Checkingthecondition();
        }

        private void button13_7_Click(object sender, EventArgs e)
        {
            proverka1(12, 6);
            Checkingthecondition();
        }

        private void button13_8_Click(object sender, EventArgs e)
        {
            proverka1(12, 7);
            Checkingthecondition();
        }

        private void button13_9_Click(object sender, EventArgs e)
        {
            proverka1(12, 8);
            Checkingthecondition();
        }

        private void button13_10_Click(object sender, EventArgs e)
        {
            proverka1(12, 9);
            Checkingthecondition();
        }

        private void button13_11_Click(object sender, EventArgs e)
        {
            proverka1(12, 10);
            Checkingthecondition();
        }

        private void button13_12_Click(object sender, EventArgs e)
        {
            proverka1(12, 11);
            Checkingthecondition();
        }

        private void button13_13_Click(object sender, EventArgs e)
        {
            proverka1(12, 12);
            Checkingthecondition();
        }

        private void button13_14_Click(object sender, EventArgs e)
        {
            proverka1(12, 13);
            Checkingthecondition();
        }

        private void button13_15_Click(object sender, EventArgs e)
        {
            proverka1(12, 14);
            Checkingthecondition();
        }

        private void button13_16_Click(object sender, EventArgs e)
        {
            proverka1(12, 15);
            Checkingthecondition();
        }

        private void button14_1_Click(object sender, EventArgs e)
        {
            proverka1(13, 0);
            Checkingthecondition();
        }

        private void button14_2_Click(object sender, EventArgs e)
        {
            proverka1(13, 1);
            Checkingthecondition();
        }

        private void button14_3_Click(object sender, EventArgs e)
        {
            proverka1(13, 2);
            Checkingthecondition();
        }

        private void button14_4_Click(object sender, EventArgs e)
        {
            proverka1(13, 3);
            Checkingthecondition();
        }

        private void button14_5_Click(object sender, EventArgs e)
        {
            proverka1(13, 4);
            Checkingthecondition();
        }

        private void button14_6_Click(object sender, EventArgs e)
        {
            proverka1(13, 5);
            Checkingthecondition();
        }

        private void button14_7_Click(object sender, EventArgs e)
        {
            proverka1(13, 6);
            Checkingthecondition();
        }

        private void button14_8_Click(object sender, EventArgs e)
        {
            proverka1(13, 7);
            Checkingthecondition();
        }

        private void button14_9_Click(object sender, EventArgs e)
        {
            proverka1(13, 8);
            Checkingthecondition();
        }

        private void button14_10_Click(object sender, EventArgs e)
        {
            proverka1(13, 9);
            Checkingthecondition();
        }

        private void button14_11_Click(object sender, EventArgs e)
        {
            proverka1(13, 10);
            Checkingthecondition();
        }

        private void button14_12_Click(object sender, EventArgs e)
        {
            proverka1(13, 11);
            Checkingthecondition();
        }

        private void button14_13_Click(object sender, EventArgs e)
        {
            proverka1(13, 12);
            Checkingthecondition();
        }

        private void button14_14_Click(object sender, EventArgs e)
        {
            proverka1(13, 13);
            Checkingthecondition();
        }

        private void button14_15_Click(object sender, EventArgs e)
        {
            proverka1(13, 14);
            Checkingthecondition();
        }

        private void button14_16_Click(object sender, EventArgs e)
        {
            proverka1(13, 15);
            Checkingthecondition();
        }

        private void button15_1_Click(object sender, EventArgs e)
        {
            proverka1(14, 0);
            Checkingthecondition();
        }

        private void button15_2_Click(object sender, EventArgs e)
        {
            proverka1(14, 1);
            Checkingthecondition();
        }

        private void button15_3_Click(object sender, EventArgs e)
        {
            proverka1(14, 2);
            Checkingthecondition();
        }

        private void button15_4_Click(object sender, EventArgs e)
        {
            proverka1(14, 3);
            Checkingthecondition();
        }

        private void button15_5_Click(object sender, EventArgs e)
        {
            proverka1(14, 4);
            Checkingthecondition();
        }

        private void button15_6_Click(object sender, EventArgs e)
        {
            proverka1(14, 5);
            Checkingthecondition();
        }

        private void button15_7_Click(object sender, EventArgs e)
        {
            proverka1(14, 6);
            Checkingthecondition();
        }

        private void button15_8_Click(object sender, EventArgs e)
        {
            proverka1(14, 7);
            Checkingthecondition();
        }

        private void button15_9_Click(object sender, EventArgs e)
        {
            proverka1(14, 8);
            Checkingthecondition();
        }

        private void button15_10_Click(object sender, EventArgs e)
        {
            proverka1(14, 9);
            Checkingthecondition();
        }

        private void button15_11_Click(object sender, EventArgs e)
        {
            proverka1(14, 10);
            Checkingthecondition();
        }

        private void button15_12_Click(object sender, EventArgs e)
        {
            proverka1(14, 11);
            Checkingthecondition();
        }

        private void button15_13_Click(object sender, EventArgs e)
        {
            proverka1(14, 12);
            Checkingthecondition();
        }

        private void button15_14_Click(object sender, EventArgs e)
        {
            proverka1(14, 13);
            Checkingthecondition();
        }

        private void button15_15_Click(object sender, EventArgs e)
        {
            proverka1(14, 14);
            Checkingthecondition();
        }

        private void button15_16_Click(object sender, EventArgs e)
        {
            proverka1(14, 15);
            Checkingthecondition();
        }

        private void button16_1_Click(object sender, EventArgs e)
        {
            proverka1(15, 0);
            Checkingthecondition();
        }

        private void button16_2_Click(object sender, EventArgs e)
        {
            proverka1(15, 1);
            Checkingthecondition();
        }

        private void button16_3_Click(object sender, EventArgs e)
        {
            proverka1(15, 2);
            Checkingthecondition();
        }

        private void button16_4_Click(object sender, EventArgs e)
        {
            proverka1(15, 3);
            Checkingthecondition();
        }

        private void button16_5_Click(object sender, EventArgs e)
        {
            proverka1(15, 4);
            Checkingthecondition();
        }

        private void button16_6_Click(object sender, EventArgs e)
        {
            proverka1(15, 5);
            Checkingthecondition();
        }

        private void button16_7_Click(object sender, EventArgs e)
        {
            proverka1(15, 6);
            Checkingthecondition();
        }

        private void button16_8_Click(object sender, EventArgs e)
        {
            proverka1(15, 7);
            Checkingthecondition();
        }

        private void button16_9_Click(object sender, EventArgs e)
        {
            proverka1(15, 8);
            Checkingthecondition();
        }

        private void button16_10_Click(object sender, EventArgs e)
        {
            proverka1(15, 9);
            Checkingthecondition();
        }

        private void button16_11_Click(object sender, EventArgs e)
        {
            proverka1(15, 10);
            Checkingthecondition();
        }

        private void button16_12_Click(object sender, EventArgs e)
        {
            proverka1(15, 11);
            Checkingthecondition();
        }

        private void button16_13_Click(object sender, EventArgs e)
        {
            proverka1(15, 12);
            Checkingthecondition();
        }

        private void button16_14_Click(object sender, EventArgs e)
        {
            proverka1(15, 13);
            Checkingthecondition();
        }

        private void button16_15_Click(object sender, EventArgs e)
        {
            proverka1(15, 14);
            Checkingthecondition();
        }

        private void button16_16_Click(object sender, EventArgs e)
        {
            proverka1(15, 15);
            Checkingthecondition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        { 
            if (isButtonClicked)
            {
                button2.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\flag1.png");
                isButtonClicked = false;
            }
            else
            {
                button2.BackgroundImage = Image.FromFile(@"C:\Users\askry\source\repos\саперянварь\resources\flag.png");
                isButtonClicked = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

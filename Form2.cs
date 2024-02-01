using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace саперянварь
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        public void authorization()
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            string password2 = Password2TextBox.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            if (password != password2)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка");
                return;
            }
            string databasePath = @"C:\Users\askry\source\repos\саперянварь\resources\database.txt";

            // Проверяем, существует ли файл базы данных
            if (File.Exists(databasePath))
            {
                // Считываем все строки из файла
                string[] lines = File.ReadAllLines(databasePath);

                // Проверяем каждую строку на наличие записи с таким логином
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    string existingLogin = parts[0];

                    // Если найдена запись с таким логином, отказываем в регистрации
                    if (existingLogin == login)
                    {
                        MessageBox.Show("Пользователь с таким логином уже зарегистрирован!", "Ошибка");
                        return;
                    }
                }
            }

            // Если файл не существует или не найдено записей с таким логином, выполняем регистрацию

            using (StreamWriter writer = new StreamWriter(databasePath, true))
            {
                writer.WriteLine($"{login}:{password}");
            }

            LoginTextBox.Text = "";
            PasswordTextBox.Text = "";

            MessageBox.Show("Регистрация успешна!", "Успех");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authorization();
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

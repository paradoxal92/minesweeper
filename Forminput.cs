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

namespace саперянварь
{
    public partial class Forminput : Form
    {
        public Forminput()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            string databasePath = @"C:\Users\askry\source\repos\саперянварь\resources\database.txt";

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }
            // Проверяем, существует ли файл базы данных
            if (File.Exists(databasePath))
            {
                // Считываем все строки из файла
                string[] lines = File.ReadAllLines(databasePath);

                // Проверяем каждую строку на наличие записи с таким логином и паролем
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    string existingLogin = parts[0];
                    string existingPassword = parts[1];

                    // Если найдена запись с таким логином и паролем, запускаем Form1 и закрываем текущую форму
                    if (existingLogin == login && existingPassword == password)
                    {
                        Form1 form1 = new Form1(); // Создаем экземпляр Form2
                        form1.Show(); // Отображаем форму Form2
                        this.Visible = false;
                        return;
                    }
                }
            }

            // Если файл не существует или не найдено записей с таким логином и паролем, выводим сообщение об ошибке
            MessageBox.Show("Неправильный логин или пароль!", "Ошибка");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Создаем экземпляр Form2
            form2.Show(); // Отображаем форму Form2
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderColor = Color.Blue; // Изменяем цвет границы кнопки на синий
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderColor = SystemColors.Control; // Возвращаем цвет границы кнопки в изначальное состояние
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderColor = Color.Blue; // Изменяем цвет границы кнопки на синий
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderColor = SystemColors.Control; // Возвращаем цвет границы кнопки в изначальное состояние
        }

        private void Forminput_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

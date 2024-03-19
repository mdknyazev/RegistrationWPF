using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registration
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Model1Container db;
        public RegistrationWindow()
        {
            InitializeComponent();
            db = new Model1Container();
        }
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "" || lastname.Text == "" || firstname.Text == "" || middlename.Text == "")
            {
                MessageBox.Show("Ошибка пустые поля");
                return;
            }
            if (db.Users.Select(item => item.Login + " " + item.Password).Contains(login.Text + " " + password.Password))
            {
                MessageBox.Show("Такой логин существует в системе");
                return;
            }
            User newUser = new User()
            {
                Login = login.Text,
                Password = password.Password,
                LastName = lastname.Text,
                FirstName = firstname.Text,
                MiddleName = middlename.Text
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрированны");
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }
    }
}

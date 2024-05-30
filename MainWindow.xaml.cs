using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF18._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool supportText = true;
        public MainWindow()
        {
            InitializeComponent();

            for (byte i = 2; i <= 5; i++) 
                ocenki.Items.Add(i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (students.SelectedItem != null)
            {
                Zachet.Items.Add(students.SelectedItem.ToString());
                students.Items.Remove(students.SelectedItem);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (students.SelectedItem != null)
            {
                neattestovannie.Items.Add(students.SelectedItem.ToString());
                students.Items.Remove(students.SelectedItem);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (newst.Text != "")
            {
                students.Items.Add(newst.Text);
                newst.Text = "";
            }
        }

        private void Zachet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string name = Zachet.SelectedItem.ToString();
            int last = Zachet.SelectedItem.ToString().Length - 1;
            if (Convert.ToString(name[last]) == "2" || Convert.ToString(name[last]) == "3" || Convert.ToString(name[last]) == "4" || Convert.ToString(name[last]) == "5")
            {
                name = name.Remove(name.Length - 1);
                name = name.Remove(name.Length - 2);
            }
            students.Items.Add(name);
            Zachet.Items.Remove(Zachet.SelectedItem);
        }

        private void neattestovannie_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            students.Items.Add(neattestovannie.SelectedItem.ToString());
            neattestovannie.Items.Remove(neattestovannie.SelectedItem);
        }

        private void ocenki_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(Zachet.SelectedItem != null | 
                ocenki.SelectedItem != null &&
                Zachet.SelectedItem != null) 
            {
                string name = Zachet.SelectedItem.ToString();
                string number = ocenki.SelectedItem.ToString();

                int last = Zachet.SelectedItem.ToString().Length - 1;
                if (Convert.ToString(name[last]) == "2" || 
                    Convert.ToString(name[last]) == "3" || 
                    Convert.ToString(name[last]) == "4" || 
                    Convert.ToString(name[last]) == "5")
                {
                    name = name.Remove(name.Length - 1);
                    name = name.Remove(name.Length - 2);
                }

                Zachet.Items.Add($"{name} {number}");
                Zachet.Items.Remove(Zachet.SelectedItem);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) => RemoveItems(new ListBox[] { students, Zachet, neattestovannie });

        private void RemoveItems(ListBox[] listBox)
        {
            foreach (ListBox item in listBox)
            {
                var count = item.Items.Count - 1;
                while (count > 0)
                {
                    item.Items.Remove(item.Items[count]);
                    count--;
                }
            }
        }

        private void ClearBox(object sender, MouseEventArgs e)
        {
            if (supportText)
            {
                newst.Text = "";
                newst.Foreground = new SolidColorBrush(Colors.Black);
                supportText = false;
            }
        }
    }
}

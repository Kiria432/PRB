using System;
using System.IO;
using System.Windows;
using CoffeeShop.Infrastructyre;

namespace CoffeeShop
{
    public partial class MainWindow : Window
    {
        private readonly CoffeeShopService _coffeeShop;
        private readonly StringWriter _outputWriter;

        public MainWindow()
        {
            InitializeComponent();
            _coffeeShop = new CoffeeShopService();
            _outputWriter = new StringWriter();
            Console.SetOut(_outputWriter);
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (coffeeComboBox.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                string coffeeType = selectedItem.Content.ToString();
                _outputWriter.GetStringBuilder().Clear();

                try
                {
                    var coffee = _coffeeShop.OrderCoffee(coffeeType);
                    processTextBox.Text = _outputWriter.ToString();

                    MessageBox.Show($"Ваш {coffee.Name} готов!",
                                  "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
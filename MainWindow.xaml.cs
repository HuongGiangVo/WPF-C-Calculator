﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseCalculator
{
    public enum SelectedOperator
    {
        Addition,
        Sustraction,
        Multiplication,
        Division
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class SimpleMath
    {
        public static double Add(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }

        public static double Minus(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }
        public static double Multiple(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }
        public static double Divide(double numberOne, double numberTwo)
        {
            return numberOne / numberTwo;
        }
    }
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            lblResult.Content = "0";
        }
        // Event handler for all number buttons
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == btnZero)
                selectedValue = 0;
            if (sender == btnOne)
                selectedValue = 1;
            if (sender == btnTwo)
                selectedValue = 2;
            if (sender == btnThree)
                selectedValue = 3;
            if (sender == btnFour)
                selectedValue = 4;
            if (sender == btnFive)
                selectedValue = 5;
            if (sender == btnSix)
                selectedValue = 6;
            if (sender == btnSeven)
                selectedValue = 7;
            if (sender == btnEight)
                selectedValue = 8;
            if (sender == btnNine)
                selectedValue = 9;
            lblResult.Content = lblResult.Content.ToString() == "0" ? lblResult.Content = $"{selectedValue}" : lblResult.Content = $"{lblResult.Content}{selectedValue}";
        }

        private void btnAc_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnNegative_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = lastNumber * (-1) : lblResult.Content;
        }

        private void btnPercentage_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = lastNumber / (100) : lblResult.Content;
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!lblResult.Content.ToString().Contains("."))
                lblResult.Content = $"{lblResult.Content}.";
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = SimpleMath.Minus(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiple(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                lblResult.Content = result.ToString();
            }
        }

        //Event handler for all operator buttons
        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = "0";
            }

            if (sender == btnMultiple)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDivide)
                selectedOperator = SelectedOperator.Division;
            if (sender == btnPlus)
                selectedOperator = SelectedOperator.Addition;
            if (sender == btnMinus)
                selectedOperator = SelectedOperator.Sustraction;

        }
    }
}

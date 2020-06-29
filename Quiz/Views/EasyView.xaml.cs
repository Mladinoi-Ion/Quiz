﻿using Quiz.Models;
using Quiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz.Views
{
    /// <summary>
    /// Interaction logic for EasyView.xaml
    /// </summary>
    public partial class EasyView : Window
    {
        public EasyView()
        {
            InitializeComponent();
            DataContext = new EasyViewModel();
        }
    }
}

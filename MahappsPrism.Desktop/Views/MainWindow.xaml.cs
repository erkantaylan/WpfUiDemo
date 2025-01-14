﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Common;
using Common.Models;
using MahappsPrism.Desktop.ViewModels;
using Modules.DatabaseModule;
using Prism.Events;

namespace MahappsPrism.Desktop.Views;

public partial class MainWindow
{
    public MainWindow(IEventAggregator ea, TodoContext context)
    {
        InitializeComponent();
        ea.GetEvent<Events.LoginEvent>().Subscribe(OnLogin);
        
    }

    private void OnLogin(LoginModel obj)
    {
        WindowState = WindowState.Maximized;
    }

    //Uygulama açılıp, ekranda gözüktükten sonra ilk bu method çağrılır
    protected override void OnContentRendered(EventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm)
        {
            return;
        }

        vm.Start();
    }
}
﻿namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class UsersView : UserControl
{
    private readonly IUsersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IUsersViewModel>();

    public UsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}
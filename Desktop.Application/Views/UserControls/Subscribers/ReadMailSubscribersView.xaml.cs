﻿namespace Desktop.Presentation.Views.UserControls.Subscribers;

sealed partial class ReadMailSubscribersView : UserControl
{
    private readonly IReadMailSubscribersViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IReadMailSubscribersViewModel>();

    public ReadMailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}
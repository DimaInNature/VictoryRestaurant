﻿namespace Desktop.Presentation.Views.UserControls.Messages;

sealed partial class ReadContactMessagesView : UserControl
{
    private readonly IReadContactMessagesViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IReadContactMessagesViewModel>();

    public ReadContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}
﻿namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.MailSubscribers;

sealed partial class DeleteMailSubscribersView : UserControl
{
    private readonly DeleteMailSubscribersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<DeleteMailSubscribersViewModel>();

    public DeleteMailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}
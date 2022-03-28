﻿namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class DeleteBookingsView : UserControl
{
    private readonly IDeleteBookingsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteBookingsViewModel>();

    public DeleteBookingsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}
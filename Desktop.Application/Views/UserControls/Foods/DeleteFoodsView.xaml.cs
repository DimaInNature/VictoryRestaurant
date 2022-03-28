﻿namespace Desktop.Presentation.Views.UserControls.Foods;

public partial class DeleteFoodsView : UserControl
{
    private readonly IDeleteFoodsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteFoodsViewModel>();

    public DeleteFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}
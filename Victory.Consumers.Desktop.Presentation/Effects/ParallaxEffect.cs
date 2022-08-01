namespace Victory.Consumers.Desktop.Presentation.Effects;

public class ParallaxEffect : Behavior<FrameworkElement>
{
    #region Dependencies

    public static readonly DependencyProperty UseParallaxProperty =
        DependencyProperty.RegisterAttached(
            name: "UseParallax",
            propertyType: typeof(bool),
            ownerType: typeof(ParallaxEffect),
            defaultMetadata: new PropertyMetadata(false));

    public static readonly DependencyProperty ParentProperty =
        DependencyProperty.RegisterAttached(
            name: "Parent",
            propertyType: typeof(UIElement),
            ownerType: typeof(ParallaxEffect),
            defaultMetadata: new PropertyMetadata(null));

    public static readonly DependencyProperty IsBackgroundProperty =
        DependencyProperty.RegisterAttached(
            name: "IsBackground",
            propertyType: typeof(bool),
            ownerType: typeof(ParallaxEffect),
            defaultMetadata: new PropertyMetadata(false));

    public static bool GetUseParallax(DependencyObject obj) =>
        (bool)obj.GetValue(dp: UseParallaxProperty);

    public static void SetUseParallax(DependencyObject obj, bool value) =>
        obj.SetValue(dp: UseParallaxProperty, value);

    public static bool GetIsBackground(DependencyObject obj) =>
        (bool)obj.GetValue(dp: IsBackgroundProperty);

    public static void SetIsBackground(DependencyObject obj, bool value) =>
        obj.SetValue(dp: IsBackgroundProperty, value);

    public static UIElement GetParent(DependencyObject obj) =>
        (UIElement)obj.GetValue(dp: ParentProperty);

    public static void SetParent(DependencyObject obj, UIElement value) =>
        obj.SetValue(dp: ParentProperty, value);

    public static readonly DependencyProperty XOffsetProperty =
        DependencyProperty.RegisterAttached(
            name: "XOffset",
            propertyType: typeof(int),
            ownerType: typeof(ParallaxEffect),
            defaultMetadata: new PropertyMetadata(120));

    public static readonly DependencyProperty YOffsetProperty =
        DependencyProperty.RegisterAttached(
            name: "YOffset",
            propertyType: typeof(int),
            ownerType: typeof(ParallaxEffect),
            defaultMetadata: new PropertyMetadata(120));

    public static int GetXOffset(DependencyObject obj) =>
        (int)obj.GetValue(dp: XOffsetProperty);

    public static void SetXOffset(DependencyObject obj, int value) =>
        obj.SetValue(dp: XOffsetProperty, value);

    public static int GetYOffset(DependencyObject obj) =>
        (int)obj.GetValue(dp: YOffsetProperty);

    public static void SetYOffset(DependencyObject obj, int value) =>
        obj.SetValue(dp: YOffsetProperty, value);

    #endregion

    protected override void OnAttached()
    {
        if (GetIsBackground(obj: AssociatedObject) is false)
        {
            AssociatedObject.MouseMove += MouseMoveHandler;

            return;
        }

        GetParent(AssociatedObject).MouseMove += MouseMoveHandler;
    }

    protected override void OnDetaching()
    {
        if (GetIsBackground(obj: AssociatedObject) is false)
        {
            AssociatedObject.MouseMove -= MouseMoveHandler;

            return;
        }

        GetParent(AssociatedObject).MouseMove -= MouseMoveHandler;
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e)
    {
        Point mousePosition = e.GetPosition(relativeTo: AssociatedObject);

        var (xoffset, yoffset) = (GetXOffset(obj: AssociatedObject), GetYOffset(obj: AssociatedObject));

        var (newX, newY) = (AssociatedObject.ActualHeight - (mousePosition.X / xoffset) - AssociatedObject.ActualHeight, AssociatedObject.ActualWidth - (mousePosition.Y / yoffset) - AssociatedObject.ActualWidth);

        if (AssociatedObject.RenderTransform is not TranslateTransform)
        {
            AssociatedObject.RenderTransform = new TranslateTransform(newX, newY);

            return;
        }

        TranslateTransform transform = (TranslateTransform)AssociatedObject.RenderTransform;

        if (xoffset > 0) transform.X = newX;

        if (yoffset > 0) transform.Y = newY;
    }
}
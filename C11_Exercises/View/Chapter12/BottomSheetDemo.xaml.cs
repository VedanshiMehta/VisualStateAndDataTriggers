namespace C11_Exercises.View.Chapter12;

public partial class BottomSheetDemo : ContentPage
{
    public BottomSheetDemo()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            var w = ex.InnerException;
            Console.WriteLine(w);

        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
       bottomSheet.ShowAsync();
    }

    private void HideBottomSheet_Clicked(object sender, EventArgs e)
    {
        bottomSheet.HideAsync();
    }
}
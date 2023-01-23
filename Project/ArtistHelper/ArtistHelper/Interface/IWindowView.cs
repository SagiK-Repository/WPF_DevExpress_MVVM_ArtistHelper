using System.Windows;

public interface IWindowView
{
    void Show();

    void Close();

    Visibility Visibility { get; set; }
}

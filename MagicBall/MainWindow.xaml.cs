using System.Windows;
using System.Windows.Input;
using Lib;

namespace MagicBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        Ball _ball = new Ball();

        public MainWindow()
        {
            InitializeComponent();
            Box.KeyDown+=Box_KeyDown;
            _ball.SendMessage += _ball_SendMessage;
            MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.KeyDown += MainWindow_KeyDown;
            //Box.Focusable = true;
            //Keyboard.Focus(Box);
            Box.Focus();
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        void _ball_SendMessage(string obj)
        {
            AnswerBlock.Text = obj;
        }

        void Box_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        if (e.Key == Key.Return)
            {
            _ball.PutString(Box.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

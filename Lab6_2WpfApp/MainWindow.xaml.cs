using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class WetherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private int temperature;
        private string wind;
        private int speed;
        private string precip;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string Wind
        {
            get => (string)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public int Speed
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string Precip
        {
            get => (string)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public WetherControl(int temperature, string wind, int speed, string precip)
        {
            this.Temperature = temperature;
            this.Wind = wind;
            this.Speed = speed;
            this.Precip = precip;
        }
        static WetherControl()
        {
            TemperatureProperty = DependencyProperty.Register(

                nameof(Temperature),
                typeof(int),
                typeof(WetherControl),
                new FrameworkPropertyMetadata(
                    20,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperture)),
                new ValidateValueCallback(ValidateTemperature));
        }
        private static object CoerceTemperture(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t <= 50 && t >= -50)
            {
                return t;
            }
            else
            {
                return null;
            }
        }
        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t <= 50 && t >= -50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

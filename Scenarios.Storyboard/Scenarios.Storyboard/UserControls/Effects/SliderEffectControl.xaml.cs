using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Effects
{
    /// <summary>
    /// Interaction logic for SliderEffect.xaml
    /// </summary>
    public partial class SliderEffectControl : UserControl
    {
        public static readonly DependencyProperty EffectNameProperty =
            DependencyProperty.Register("EffectName",
            typeof(string),
            typeof(SliderEffectControl));

        public static readonly DependencyProperty EffectVisualProperty =
            DependencyProperty.Register("EffectVisual",
            typeof(object),
            typeof(SliderEffectControl));

        public static readonly DependencyProperty EffectValueProperty =
            DependencyProperty.Register("EffectValue",
            typeof(int),
            typeof(SliderEffectControl));

        public SliderEffectControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The name of the slider effect being toggled by the SliderEffectControl.
        /// </summary>
        public string EffectName
        {
            get => (string)GetValue(EffectNameProperty);

            set => SetValue(EffectNameProperty, value);
        }

        /// <summary>
        /// The current value of the effect.
        /// </summary>
        public int EffectValue
        {
            get => (int)GetValue(EffectValueProperty);

            set => SetValue(EffectValueProperty, value);
        }

        /// <summary>
        /// A visual indicator identifying the type of effect being handled.
        /// </summary>
        public object EffectVisual
        {
            get => GetValue(EffectVisualProperty);

            set => SetValue(EffectVisualProperty, value);
        }
    }
}

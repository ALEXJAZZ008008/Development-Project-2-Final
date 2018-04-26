using System.Windows;
using System.Windows.Controls;

namespace Scenarios.Storyboard.UserControls.Effects
{
    /// <summary>
    /// Interaction logic for BooleanEffect.xaml
    /// </summary>
    public partial class BooleanEffectControl : UserControl
    {
        public static readonly DependencyProperty EffectNameProperty =
            DependencyProperty.Register("EffectName",
                                        typeof(string),
                                        typeof(BooleanEffectControl));

        public static readonly DependencyProperty EffectVisualProperty =
            DependencyProperty.Register("EffectVisual",
                                typeof(object),
                                typeof(BooleanEffectControl));

        public static readonly DependencyProperty EffectIsEnabledProperty =
          DependencyProperty.Register("EffectIsEnabled",
                        typeof(bool),
                        typeof(BooleanEffectControl));


        public BooleanEffectControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The name of the effect being toggled by the BooleanEffectControl.
        /// </summary>
        public string EffectName
        {
            get => (string)GetValue(EffectNameProperty);

            set => SetValue(EffectNameProperty, value);
        }

        /// <summary>
        /// The current state of the effect being enabled or not. 
        /// </summary>
        public bool EffectIsEnabled
        {
            get => (bool)GetValue(EffectIsEnabledProperty);

            set => SetValue(EffectIsEnabledProperty, value);
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

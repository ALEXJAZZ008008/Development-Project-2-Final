using Scenarios.Core;
using Scenarios.Storyboard.Adapters;
using Scenarios.Storyboard.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class ScenarioEffectOptionsViewModel: PropertyChangedNotifier
    {
        private readonly IFireArcUtility _fireArc;

        private bool _fireEnabled;
        private bool _smokeEnabled;
        private bool _emergencyLightingEnabled;
        private bool _extinguisherPlumeEnabled;

        private int _emergencyLightingIntensity = 100;

        private ScenarioViewModel _parentScenario;

        private ICollection<float> _fireArcs;
        private ICollection<float> _smokeArcs;

        public ScenarioEffectOptionsViewModel(ScenarioViewModel parentScenario, 
            IFireArcUtility fireArc)
        {
            _fireArc = fireArc;

            FireArcs = new List<float>();
            SmokeArcs = new List<float>();

            _parentScenario = parentScenario ?? 
                throw new ArgumentNullException(nameof(parentScenario));

            SetFireArcsCommand = new DelegateCommand(SetFireArcs);
        }

        /// <summary>
        /// Indicates that fire effects are enabled for this individual
        /// scenario.
        /// </summary>
        public bool FireIsEnabled
        {
            get => _fireEnabled;

            set
            {
                _fireEnabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Indicates that smoke effects are enabled for this individual
        /// scenario.
        /// </summary>
        public bool SmokeIsEnabled
        {
            get => _smokeEnabled;

            set
            {
                _smokeEnabled = value;

                OnPropertyChanged();
            }
        }
        
        public IEnumerable<float> FireArcs
        {
            get => _fireArcs;

            set
            {
                _fireArcs = (ICollection<float>)value;

                OnPropertyChanged();
            }
        }

        public IEnumerable<float> SmokeArcs
        {
            get => _smokeArcs;

            set
            {
                _smokeArcs = (ICollection<float>)value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EmergencyLightingIsEnabled
        {
            get => _emergencyLightingEnabled;

            set
            {
                _emergencyLightingEnabled = value;

                OnPropertyChanged();
            }
        }

        public bool FireExtinguisherPlumeIsEnabled
        {
            get => _extinguisherPlumeEnabled;

            set
            {
                _extinguisherPlumeEnabled = value;
                OnPropertyChanged();
            }
        }

        public int EmergencyLightingIntensity
        {
            get => _emergencyLightingIntensity;

            set
            {
                _emergencyLightingIntensity = value;
                OnPropertyChanged();
            }
        }

        public ScenarioViewModel ParentScenario
        {
            get => _parentScenario;

            set
            {
                _parentScenario = value;
                OnPropertyChanged();
            }
        }
        

        public ICommand SetFireArcsCommand { get; }

        private void SetFireArcs(object parameter)
        {
            try
            {
                List<List<float>> arcs =
                _fireArc.GetFireArcs(ScenarioViewModelToScenarioAdapter.Convert(ParentScenario));

                //_fireArc.GetFireArcs(ScenarioViewModelToScenarioAdapter.Convert(ParentScenario), ParentScenario.Storyboard.OutputPath.Replace("\\", "/"));

                FireArcs = arcs[0];

                SmokeArcs = arcs[1];
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Unable to get positioning" + Environment.NewLine + $"Exception: {exc.Message}");
            }
        }
    }
}

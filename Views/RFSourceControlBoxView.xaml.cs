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

namespace RFSourceControllerApp.Views
{
    /// <summary>
    /// Interaction logic for RFSourceControlBoxView.xaml
    /// </summary>
    public partial class RFSourceControlBoxView : UserControl
    {
        public RFSourceControlBoxView()
        {
            InitializeComponent();
            //Bind the switch in here
            Binding xBinding = new Binding();
            xBinding.Path = new PropertyPath("isCWChecked");
            xBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(CWToggleSwitch.CheckBoxSwitch, CheckBox.IsCheckedProperty, xBinding);


            Binding xBinding_Freq = new Binding();
            xBinding_Freq.Path = new PropertyPath("ButtonCommand");
            BindingOperations.SetBinding(FrequencySweepView.SetButton, Button.CommandProperty, xBinding_Freq);

            Binding xBinding_Power = new Binding();
            xBinding_Power.Path = new PropertyPath("ButtonCommand");
            BindingOperations.SetBinding(PowerSweepView.SetButton, Button.CommandProperty, xBinding_Power);

            Binding xBinding_PowerFreq = new Binding();
            xBinding_PowerFreq.Path = new PropertyPath("ButtonCommand");
            BindingOperations.SetBinding(PowerFreqSweepView.SetButton, Button.CommandProperty, xBinding_PowerFreq);

            Binding xBinding_CyclicMode = new Binding();
            xBinding_CyclicMode.Path = new PropertyPath("isCyclicMode");
            xBinding_CyclicMode.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(PowerFreqSweepView.CyclicModeSwitch.CheckBoxSwitch, CheckBox.IsCheckedProperty, xBinding_CyclicMode);
            BindingOperations.SetBinding(FrequencySweepView.CyclicModeSwitch.CheckBoxSwitch, CheckBox.IsCheckedProperty, xBinding_CyclicMode);
            BindingOperations.SetBinding(PowerSweepView.CyclicModeSwitch.CheckBoxSwitch, CheckBox.IsCheckedProperty, xBinding_CyclicMode);
        }
    }
}

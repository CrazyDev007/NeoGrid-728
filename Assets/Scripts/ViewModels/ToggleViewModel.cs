using Models;
using Views;

namespace ViewModels
{
    public class ToggleViewModel
    {
        private ToggleModel _toggleModel;
        private ToggleView _toggleView;

        public ToggleViewModel(ToggleModel toggleModel, ToggleView toggleView)
        {
            _toggleModel = toggleModel;
            _toggleView = toggleView;
            //
            toggleView.SetToggleAction(OnToggleChanged);
        }

        private void OnToggleChanged()
        {
            _toggleModel.Toggle();
        }
    }
}
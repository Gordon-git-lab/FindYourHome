using FindYourHome.Models;

namespace FindYourHome.ViewModels
{
    public class HouseDetailViewModel : BaseViewModel
    {
        private House house;
        public House House { get => house; set => SetProperty(ref house, value); }

        public HouseDetailViewModel(House h)
        {
            House = h;
        }
    }
}

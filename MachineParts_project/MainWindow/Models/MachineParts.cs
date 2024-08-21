using System.ComponentModel;
using System.Windows.Media.Media3D;
namespace Examen.Models
{
    internal class MachineParts : INotifyPropertyChanged
    {
        // Vaiables ----------------------------------------------------------------------------------------------------------------------------
        // Private
        private string _name;
        private string _category;
        private string _description;
        private string _volume;
        private string _price;
        // Public
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public string Volume
        {
            get => _volume;
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                    OnPropertyChanged(nameof(Volume));
                }
            }
        }
        public string Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        // Constructor -------------------------------------------------------------------------------------------------------------------------
        // Methodes ----------------------------------------------------------------------------------------------------------------------------
        public async Task<bool> AssignPartValues(string[] args, string Categorie)
        {

            // Assign values
            await Task.Delay(1000);
            Name = args[0];
            Category = "Cube";
            Description = args[1];
            Volume = args[2];
            Price = args[3];


            return true;
        }

        public async Task<bool> UpdateProcessPartValues(int delaytime)
        {
            await Task.Delay(delaytime);
            return true;
        }
        public double GetVolume()
        {
            int Length = 0;
            int Width = 0;
            int Height = 0;
            return Length * Width * Height;
        }
        public override string ToString()
        {
            return $"Part Details: Name: {Name}, Category: {Category}, Description: {Description}, Volume: {Volume}, Price: {Price}";
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

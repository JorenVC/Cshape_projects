using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Windows.Input;

namespace Examen_JorenVanCalster.Models
{
    internal class Animals : INotifyPropertyChanged
    {
        // Vaiables ----------------------------------------------------------------------------------------------------------------------------
        // Private
        private string _name;
        private string _weight;
        private string _specie;
        private string _category;
        private int _hungryPercentage;
        private string _age;
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
        public string Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
        public string Specie
        {
            get => _specie;
            set
            {
                if (_specie != value)
                {
                    _specie = value;
                    OnPropertyChanged(nameof(Specie));
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
        public int HungryPercentage
        {
            get => _hungryPercentage;
            set
            {
                if (_hungryPercentage != value)
                {
                    _hungryPercentage = value;
                    OnPropertyChanged(nameof(HungryPercentage));
                }
            }
        }
        public string Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public event EventHandler<string> HungryNotification;
        public event PropertyChangedEventHandler PropertyChanged;
        // Constructor -------------------------------------------------------------------------------------------------------------------------
        // Methodes ----------------------------------------------------------------------------------------------------------------------------

        public bool AssignAnimal(string name, string weight, string specie, string category = "", string age ="-1")
        {
            Name = name;
            Weight = weight ;
            Specie = specie;
            Category = category;
            HungryPercentage = 100;
            Age = age;

            return true;
        }
        public override string ToString()
        {
            if (Specie == "Human")
            {
                return $"{Specie} - Employee - {Name} - {Weight} kg - {Age}";
            }
            else 
            {
                return $"Animal - {Specie} - {Category} - {Name} - {Weight} kg - {HungryPercentage}%";
            }
        }
        public void MessageHungerAbove80()
        {
            if(HungryPercentage > 80)
            {
                HungryNotification?.Invoke(this, Name);
            }

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


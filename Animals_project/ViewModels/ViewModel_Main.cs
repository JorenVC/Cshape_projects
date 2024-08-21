using Examen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen_JorenVanCalster.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;

namespace Examen_JorenVanCalster.ViewModels 
{

    internal class ViewModel_Main : ViewModelBase
    {
        // Vaiables ----------------------------------------------------------------------------------------------------------------------------
        // Private
        private string _inputName;
        private string _inputWeight;
        private string _inputAge;
        private string _infoLabel;
        private string _inputSearch;
        private bool _savingNotification;
        private Animals _selectionChanged;

        // Public
        public Animals Animal;
        public string InputName
        {
            get => _inputName;
            set
            {
                if (_inputName != value)
                {
                    _inputName = value;
                    OnPropertyChanged(nameof(InputName));
                }
            }
        }
        public string InputWeight
        {
            get => _inputWeight;
            set
            {
                if (_inputWeight != value)
                {
                    _inputWeight = value;
                    OnPropertyChanged(nameof(InputWeight));
                }
            }
        }
        public string InputAge
        {
            get => _inputAge;
            set
            {
                if (_inputAge != value)
                {
                    _inputAge = value;
                    OnPropertyChanged(nameof(InputAge));
                }
            }
        }
        public string InfoLabel
        {
            get => _infoLabel;
            set
            {
                if (_infoLabel != value)
                {
                    _infoLabel = value;
                    OnPropertyChanged(nameof(InfoLabel));
                }
            }
        }
        public string InputSearch
        {
            get => _inputSearch;
            set
            {
                if (_inputSearch != value)
                {
                    _inputSearch = value;
                    OnPropertyChanged(nameof(InputSearch));
                }
            }
        }
        public bool SavingNotification
        {
            get => _savingNotification;
            set
            {
                if (_savingNotification != value)
                {
                    _savingNotification = value;
                    OnPropertyChanged(nameof(SavingNotification));
                }
            }
        }
        public event EventHandler<bool> ESavingNotification;
        public Animals SelectionChanged
        {
            get => _selectionChanged;
            set
            {
                if (_selectionChanged != value)
                {
                    _selectionChanged = value;
                    OnPropertyChanged(nameof(SelectionChanged));
                    ShowInfo();
                }
            }
        }
        public ObservableCollection<Animals> FullListOfAnimals { get; set; }
        public ObservableCollection<Animals> ShowedListOfAnimals { get; set; }
        // Button Commands
        public ICommand MyButtonAddShark{ get; }
        public ICommand MyButtonAddClownfish { get; }
        public ICommand MyButtonAddBat { get; }
        public ICommand MyButtonAddLion { get; }
        public ICommand MyButtonAddEmployee { get; }
        public ICommand MyButtonCalculateTotalWeight { get; }
        public ICommand MyButtonShowAllButton { get; }
        public ICommand MyButtonShowAnimalsOver10kg { get; }
        public ICommand MyButtonShowAnimalsOver20kg { get; }
        public ICommand MyButtonShowAnimalsUnder50kg { get; }
        public ICommand MyButtonShowHungryAnimal80 { get; }
        public ICommand MyButtonSearchButton { get; }
        public ICommand MyButtonOrderAscButton { get; }
        public ICommand MyButtonOrderDescButton { get; }
        public ICommand MyButtonSaveButton { get; }
        // Constructor -------------------------------------------------------------------------------------------------------------------------
        public ViewModel_Main()
        {
            FullListOfAnimals = new ObservableCollection<Animals>();
            ShowedListOfAnimals = new ObservableCollection<Animals>();

            MyButtonAddShark = new RelayCommand(AddShark);
            MyButtonAddClownfish = new RelayCommand(AddClownfish);
            MyButtonAddBat = new RelayCommand(AddBat);
            MyButtonAddLion = new RelayCommand(AddLion);
            MyButtonAddEmployee = new RelayCommand(AddEmployee);

            MyButtonCalculateTotalWeight = new RelayCommand(CalculateTotalWeight);
            MyButtonShowAllButton = new RelayCommand(ShowAll);
            MyButtonShowAnimalsOver10kg = new RelayCommand(ShowAnimalsOver10kg);
            MyButtonShowAnimalsOver20kg = new RelayCommand(ShowAnimalsOver20kg);
            MyButtonShowAnimalsUnder50kg = new RelayCommand(ShowAnimalsUnder50kg);
            MyButtonShowHungryAnimal80 = new RelayCommand(ShowHungryAnimal80);
            MyButtonSearchButton = new RelayCommand(SearchName);

            MyButtonOrderAscButton = new RelayCommand(OrderAscList);
            MyButtonOrderDescButton = new RelayCommand(OrderDescList);

            MyButtonSaveButton = new RelayCommand(SaveToTXTFile);
            InfoLabel = "Animal/Human - Specie - Name - Weight - ...";
        }
        // Methodes ----------------------------------------------------------------------------------------------------------------------------
        public void AddShark()
        {
            try
            {
                if(InputName != null && InputWeight!= null)
                {
                    // Make new animal class
                    Animal = new Animals();

                    //Check for unique name
                    bool duplicate = SearchForNames(InputName);
                    if (!duplicate)
                    {
                        // Assign
                        bool status = Animal.AssignAnimal(InputName, InputWeight, "Shark", category: "Fish");

                        if (status)
                        {
                            // Add animal to the lists 
                            FullListOfAnimals.Add(Animal);
                            ShowedListOfAnimals.Add(Animal);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Give another name!", "Show Message duplicated name", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Give the Name and Weight of the animal", "Show Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("Could not add a shark!", "Show Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void AddClownfish()
        {
            try
            {
                if (InputName != null && InputWeight != null)
                {
                    // Make new animal class
                    Animal = new Animals();

                    //Check for unique name
                    bool duplicate = SearchForNames(InputName);
                    if (!duplicate)
                    {
                        // Assign
                        bool status = Animal.AssignAnimal(InputName, InputWeight, "Clownfish", category: "Fish");

                        if (status)
                        {
                            // Add animal to the lists 
                            FullListOfAnimals.Add(Animal);
                            ShowedListOfAnimals.Add(Animal);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Give another name!", "Show Message duplicated name", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Give the Name and Weight of the animal", "Show Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("Could not add a Clownfish!", "Show Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void AddBat()
        {
            try
            {
                if (InputName != null && InputWeight != null)
                {
                    // Make new animal class
                    Animal = new Animals();

                    //Check for unique name
                    bool duplicate = SearchForNames(InputName);
                    if (!duplicate)
                    {
                        // Assign
                        bool status = Animal.AssignAnimal(InputName, InputWeight, "Bat", category: "Mammal");

                        if (status)
                        {
                            // Add animal to the lists 
                            FullListOfAnimals.Add(Animal);
                            ShowedListOfAnimals.Add(Animal);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Give another name!", "Show Message duplicated name", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Give the Name and Weight of the animal", "Show Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("Could not add a Bat!", "Show Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void AddLion()
        {
            try
            {
                if (InputName != null && InputWeight != null)
                {
                    // Make new animal class
                    Animal = new Animals();

                    //Check for unique name
                    bool duplicate = SearchForNames(InputName);
                    if (!duplicate)
                    {
                        // Assign
                        bool status = Animal.AssignAnimal(InputName, InputWeight, "Lion", category:"Mammal");

                        if (status)
                        {
                            // Add animal to the lists 
                            FullListOfAnimals.Add(Animal);
                            ShowedListOfAnimals.Add(Animal);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Give another name!", "Show Message duplicated name", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Give the Name and Weight of the animal", "Show Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("Could not add a Lion!", "Show Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void AddEmployee()
        {
            try
            {
                if (InputName != null && InputWeight != null && InputAge != null)
                {
                    // Make new animal class
                    Animal = new Animals();
                    //Check for unique name
                    bool duplicate = SearchForNames(InputName);
                    if (!duplicate)
                    {
                        // Assign
                        bool status = Animal.AssignAnimal(InputName, InputWeight, "Human", age:InputAge);

                        if (status)
                        {
                            // Add animal to the lists 
                            FullListOfAnimals.Add(Animal);
                            ShowedListOfAnimals.Add(Animal);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Give another name!", "Show Message duplicated name", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Give the Name, Weight and Age of the Employee", "Show Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("Could not add an Employee!", "Show Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void ShowInfo()
        {
            try
            {
                if (SelectionChanged != null)
                {
                    var info = SelectionChanged.ToString();
                    InfoLabel = info;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't show info", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void CalculateTotalWeight()
        {
            try
            {
                double totalVolume = FullListOfAnimals.Sum(part => Int32.Parse(part.Weight));
                MessageBox.Show($"The total weight: {totalVolume}", "Calculate total weight");
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't Calculate total weight", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void ShowAll()
        {
            try
            {
                ShowedListOfAnimals.Clear();
                foreach (var animal in FullListOfAnimals)
                {
                    ShowedListOfAnimals.Add(animal);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't show all", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void ShowAnimalsOver10kg()
        {
            try
            {
                // Filter the collection to only include items with Weight > 10
                var filtered = FullListOfAnimals.Where(item => Int32.Parse(item.Weight) > 10 && item.Specie != "Human").ToList();

                ShowedListOfAnimals.Clear();
                foreach (var animal in filtered)
                {
                    ShowedListOfAnimals.Add(animal);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't show animals over 10 kg", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void ShowAnimalsOver20kg()
        {
            try
            {
                // Filter the collection to only include items with Weight > 20
                var filtered = FullListOfAnimals.Where(item => Int32.Parse(item.Weight) > 20 && item.Specie != "Human").ToList();

                ShowedListOfAnimals.Clear();
                foreach (var animal in filtered)
                {
                    ShowedListOfAnimals.Add(animal);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't show animals over 20 kg", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void ShowAnimalsUnder50kg()
        {
            try
            {
                // Filter the collection to only include items with Weight < 50
                var filtered = FullListOfAnimals.Where(item => Int32.Parse(item.Weight) < 50 && item.Specie != "Human").ToList();

                ShowedListOfAnimals.Clear();
                foreach (var animal in filtered)
                {
                    ShowedListOfAnimals.Add(animal);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't show animals under 50kg", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void ShowHungryAnimal80()
        {
            try
            {
                // Filter the collection to only include items with hunger > 80
                var filtered = FullListOfAnimals.Where(item => item.HungryPercentage > 80 && item.Specie != "Human").ToList();

                ShowedListOfAnimals.Clear();
                foreach (var animal in filtered)
                {
                    ShowedListOfAnimals.Add(animal);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't show hungry animals", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void SearchName()
        {
            try
            {
                string temp = InputSearch;
                if (!string.IsNullOrEmpty(temp))
                {
                    // Filter the collection to only include items with the search value in the name
                    var filtered = FullListOfAnimals.Where(animal => animal.Name.Equals(temp)).ToList();

                    ShowedListOfAnimals.Clear();
                    foreach (var animal1 in filtered)
                    {
                        ShowedListOfAnimals.Add(animal1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't search name", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }
        public void OrderAscList()
        {
            try
            {
                // Sort by volume and update the collection in place
                var sorted = ShowedListOfAnimals.OrderBy(item => Int32.Parse(item.Weight)).ToList();

                for (int i = 0; i < sorted.Count; i++)
                {
                    var currentIndex = ShowedListOfAnimals.IndexOf(sorted[i]);
                    if (currentIndex != i)
                    {
                        ShowedListOfAnimals.Move(currentIndex, i);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't order list ascending", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void OrderDescList()
        {
            try
            {
                // Sort by volume and update the collection in place
                var sorted = ShowedListOfAnimals.OrderByDescending(item => Int32.Parse(item.Weight)).ToList();

                for (int i = 0; i < sorted.Count; i++)
                {
                    var currentIndex = ShowedListOfAnimals.IndexOf(sorted[i]);
                    if (currentIndex != i)
                    {
                        ShowedListOfAnimals.Move(currentIndex, i);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"Can't order descending list", "Show error notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void MessageHungerAbove80(object sender, string name)
        {
            MessageBox.Show($"{name} is hungry", "Show Hungy notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void SaveToTXTFile()
        {
            try
            {
                // invoke stop adding
                ESavingNotification?.Invoke(this, false);
                // Path to the file
                string filePath = "C:\\Users\\vbtan\\Desktop\\aug_examen\\Examen_JorenVanCalster\\SavedPartsFile.txt";

                // Convert the list of parts to a list of strings
                var linesToWrite = FullListOfAnimals.Select(part => part.ToString()).ToList();

                File.WriteAllLines(filePath, linesToWrite);
                ESavingNotification?.Invoke(this, true);
                MessageBox.Show("Data is saved!", "Show Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("Data is NOT saved!", "Show Error Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        // extra methodes
        public bool SearchForNames(string searchedName)
        {
            // Filter the collection to only include items with a p in the name
            var filtered = FullListOfAnimals.Where(animal => animal.Name.Equals(searchedName)).ToList();
            if (filtered.Count > 0) 
            {
                return true;
            }
            else { return false; }
        }
    }

}

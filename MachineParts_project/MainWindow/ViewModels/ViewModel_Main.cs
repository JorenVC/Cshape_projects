using Examen.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Net.Http;
using System.IO;
using System.Windows;

namespace Examen.ViewModels
{
    internal class ViewModel_Main : ViewModelBase
    {
        // Vaiables ----------------------------------------------------------------------------------------------------------------------------
        // Private
        private readonly ApiService _apiService = new ApiService();
        private string apiPostUrl = "https://localhost:5555/"; // Adjust the URL if needed
        private string _inputVars;
        private string _inputSearch;
        private string _currentAct;
        private MachineParts _selectionChanged;

        // Public
        public MachineParts machinePart;
        public string InputVars
        {
            get => _inputVars;
            set
            {
                if (_inputVars != value)
                {
                    _inputVars = value;
                    OnPropertyChanged(nameof(InputVars));
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
        public string CurrentAct
        {
            get => _currentAct;
            set
            {
                if (_currentAct != value)
                {
                    _currentAct = value;
                    OnPropertyChanged(nameof(CurrentAct));
                }
            }
        }
        public MachineParts SelectionChanged
        {
            get => _selectionChanged;
            set
            {
                if (_selectionChanged != value)
                {
                    _selectionChanged = value;
                    OnPropertyChanged(nameof(SelectionChanged));
                }
            }
        }
        public ObservableCollection<MachineParts> FullListOfMachineParts { get; set; }
        public ObservableCollection<MachineParts> ShowedListOfMachineParts { get; set; }

        // Button Commands
        public ICommand MyButtonAddCubeButton { get; }
        public ICommand MyButtonAddSphereButton { get; }
        public ICommand MyButtonAddCilinderButton { get; }
        public ICommand MyButtonShowInfoButton { get; }
        public ICommand MyButtonCalculatePriceButton { get; }
        public ICommand MyButtonCalculateTotalVolumeButton { get; }
        public ICommand MyButtonOrderAscButton { get; }
        public ICommand MyButtonOrderDescButton { get; }
        public ICommand MyButtonShowAllButton { get; }
        public ICommand MyButtonVolumeOver1000Button { get; }
        public ICommand MyButtonVolumeUnder800Button { get; }
        public ICommand MyButtonNameContainsJButton { get; }
        public ICommand MyButtonNameContainsPButton { get; }
        public ICommand MyButtonCubeOver1000Button { get; }
        public ICommand MyButtonSearchButton { get; }
        public ICommand MyButtonUploadButton { get; }
        public ICommand MyButtonSaveButton { get; }

        
        // Constructor -------------------------------------------------------------------------------------------------------------------------
        public ViewModel_Main()
        {
            // Initialize list and the command and bind it to a method
            FullListOfMachineParts = new ObservableCollection<MachineParts>
            {
                new MachineParts { Name="testj", Category="Cube", Description = "cube j", Volume = "1111" , Price="2"},
                new MachineParts { Name="test", Category="Sphere", Description = "Sphere ", Volume = "700" , Price="2"},
                new MachineParts { Name="testj", Category="Cilinder", Description = "Cilinder j", Volume = "2000" , Price="2"},
                new MachineParts { Name="test", Category="Cilinder", Description = "Cilinder ", Volume = "801" , Price="2"},
                new MachineParts { Name="testp", Category="Cube", Description = "cubep", Volume = "2" , Price="2"},
            };
            ShowedListOfMachineParts = new ObservableCollection<MachineParts>           
            {
                new MachineParts { Name="testj", Category="Cube", Description = "cube j", Volume = "1111" , Price="2"},
                new MachineParts { Name="test", Category="Sphere", Description = "Sphere ", Volume = "700" , Price="2"},
                new MachineParts { Name="testj", Category="Cilinder", Description = "Cilinder j", Volume = "2000" , Price="2"},
                new MachineParts { Name="test", Category="Cilinder", Description = "Cilinder ", Volume = "801" , Price="2"},
                new MachineParts { Name="test", Category="Cube", Description = "cube", Volume = "2" , Price="2"},
            };

            MyButtonAddCubeButton = new RelayCommand(AddCube);
            MyButtonAddSphereButton = new RelayCommand(AddSphere);
            MyButtonAddCilinderButton = new RelayCommand(AddCilinder);

            MyButtonShowInfoButton = new RelayCommand(ShowInfo);
            MyButtonCalculatePriceButton = new RelayCommand(CalculatePrice);
            MyButtonCalculateTotalVolumeButton = new RelayCommand(CalculateTotalVolume);

            MyButtonOrderAscButton = new RelayCommand(OrderAscList);
            MyButtonOrderDescButton = new RelayCommand(OrderDescList);

            MyButtonShowAllButton = new RelayCommand(ShowAll);
            MyButtonVolumeOver1000Button = new RelayCommand(ShowVolumeOver1000);
            MyButtonVolumeUnder800Button = new RelayCommand(ShowVolumeUnder800);
            MyButtonNameContainsJButton = new RelayCommand(ShowNameContainsJ);
            MyButtonNameContainsPButton = new RelayCommand(ShowNameContainsP);
            MyButtonCubeOver1000Button = new RelayCommand(ShowCubeOver1000);

            MyButtonSearchButton = new RelayCommand(SearchPart);

            MyButtonUploadButton = new RelayCommand(UploadPartList);
            MyButtonSaveButton = new RelayCommand(SavePartList);
            
        }

        // Methodes ----------------------------------------------------------------------------------------------------------------------------
        public async void AddCube()
        {
            // Get all details from input
            if(InputVars != null)
            {
                string[] args = InputVars.Split(',');
                if (args.Length == 4)
                {
                // Make new machine part
                machinePart = new MachineParts();

                // Assign
                CurrentAct = "Assigning...";
                var statusAssigning = await machinePart.AssignPartValues(args, "Cube");

                // Update
                CurrentAct = "Updating...";
                var statusUpdating = await machinePart.UpdateProcessPartValues(1000);

                // Processing
                CurrentAct = "Processing...";
                var statusProcessing = await machinePart.UpdateProcessPartValues(1000);

                CurrentAct = "Cube has been made!";

                    // Add Cube to the ListOfMachineParts 
                    FullListOfMachineParts.Add(machinePart);
                    ShowedListOfMachineParts.Add(machinePart);
                }
                else
                {
                    CurrentAct = "Wrong Amount of arguments: (Name, Description, Volume, Price)";
                }
            }
            else
            {
                CurrentAct = "Wrong Amount of arguments: (Name, Description, Volume, Price)";
            }
        }
        public async void AddSphere()
        {
            // Get all details from input
            if (InputVars != null)
            {
                string[] args = InputVars.Split(',');
                if (args.Length == 4)
                {
                    // Make new machine part
                    machinePart = new MachineParts();

                    // Assign
                    CurrentAct = "Assigning...";
                    var statusAssigning = await machinePart.AssignPartValues(args, "Sphere");

                    // Update
                    CurrentAct = "Updating...";
                    var statusUpdating = await machinePart.UpdateProcessPartValues(1000);

                    // Processing
                    CurrentAct = "Processing...";
                    var statusProcessing = await machinePart.UpdateProcessPartValues(1000);

                    CurrentAct = "Cube has been made!";

                    // Add Cube to the ListOfMachineParts 
                    FullListOfMachineParts.Add(machinePart);
                    ShowedListOfMachineParts.Add(machinePart);
                }
                else
                {
                    CurrentAct = "Wrong Amount of arguments: (Name, Description, Volume, Price)";
                }
            }
            else
            {
                CurrentAct = "Wrong Amount of arguments: (Name, Description, Volume, Price)";
            }
        }
        public async void AddCilinder()
        {
            // Get all details from input
            if (InputVars != null)
            {
                string[] args = InputVars.Split(',');
                if (args.Length == 4)
                {
                    // Make new machine part
                    machinePart = new MachineParts();

                    // Assign
                    CurrentAct = "Assigning...";
                    var statusAssigning = await machinePart.AssignPartValues(args, "Cilinder");

                    // Update
                    CurrentAct = "Updating...";
                    var statusUpdating = await machinePart.UpdateProcessPartValues(1000);

                    // Processing
                    CurrentAct = "Processing...";
                    var statusProcessing = await machinePart.UpdateProcessPartValues(1000);

                    CurrentAct = "Cube has been made!";

                    // Add Cube to the ListOfMachineParts 
                    FullListOfMachineParts.Add(machinePart);
                    ShowedListOfMachineParts.Add(machinePart);
                }
                else
                {
                    CurrentAct = "Wrong Amount of arguments: (Name, Description, Volume, Price)";
                }
            }
            else
            {
                CurrentAct = "Wrong Amount of arguments: (Name, Description, Volume, Price)";
            }
        }
        public void ShowInfo() 
        {
            if(SelectionChanged != null)
            {
                var test = SelectionChanged.ToString();
                MessageBox.Show(test, "Show Info of a part", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        public void CalculatePrice()
        {
            double totalVolume = FullListOfMachineParts.Sum(part => double.Parse(part.Price));
            MessageBox.Show($"The total price: {totalVolume}", "Calculate total price");
        }
        public void CalculateTotalVolume()
        {
            double totalVolume = FullListOfMachineParts.Sum(part => double.Parse(part.Volume));
            MessageBox.Show($"The total Volume: {totalVolume}", "Calculate total volume");
        }
        public void OrderAscList()
        {
            // Sort by volume and update the collection in place
            var sorted = ShowedListOfMachineParts.OrderBy(part => Int32.Parse(part.Volume)).ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                var currentIndex = ShowedListOfMachineParts.IndexOf(sorted[i]);
                if (currentIndex != i)
                {
                    ShowedListOfMachineParts.Move(currentIndex, i);
                }
            }
        }
        public void OrderDescList()
        {
            // Sort by volume and update the collection in place
            var sorted = ShowedListOfMachineParts.OrderByDescending(part => Int32.Parse(part.Volume)).ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                var currentIndex = ShowedListOfMachineParts.IndexOf(sorted[i]);
                if (currentIndex != i)
                {
                    ShowedListOfMachineParts.Move(currentIndex, i);
                }
            }
        }
        public void ShowAll()
        {
            ShowedListOfMachineParts.Clear();
            foreach (var part in FullListOfMachineParts)
            {
                ShowedListOfMachineParts.Add(part);
            }
        }
        public void ShowVolumeOver1000() 
        {
            // Filter the collection to only include items with Volume > 1000
            var filtered = FullListOfMachineParts.Where(part => Int32.Parse(part.Volume) > 1000).ToList();

            ShowedListOfMachineParts.Clear();
            foreach (var part in filtered)
            {
                ShowedListOfMachineParts.Add(part);
            }
        }
        public void ShowVolumeUnder800()
        {
            // Filter the collection to only include items with Volume < 800
            var filtered = FullListOfMachineParts.Where(part => Int32.Parse(part.Volume) < 800).ToList();

            ShowedListOfMachineParts.Clear();
            foreach (var part in filtered)
            {
                ShowedListOfMachineParts.Add(part);
            }
        }
        public void ShowNameContainsJ()
        {
            // Filter the collection to only include items with a j in the name
            var filtered = FullListOfMachineParts.Where(part => part.Name.Contains("j", StringComparison.OrdinalIgnoreCase)).ToList();

            ShowedListOfMachineParts.Clear();
            foreach (var part in filtered)
            {
                ShowedListOfMachineParts.Add(part);
            }
        }
        public void ShowNameContainsP()
        {
            // Filter the collection to only include items with a p in the name
            var filtered = FullListOfMachineParts.Where(part => part.Name.Contains("p", StringComparison.OrdinalIgnoreCase)).ToList();

            ShowedListOfMachineParts.Clear();
            foreach (var part in filtered)
            {
                ShowedListOfMachineParts.Add(part);
            }
        }
        public void ShowCubeOver1000()
        {
            // Filter the collection to only include items with Volume > 1000 and Category = cube
            var filtered = FullListOfMachineParts.Where(part => part.Category == "Cube" && Int32.Parse(part.Volume) > 1000).ToList();

            ShowedListOfMachineParts.Clear();
            foreach (var part in filtered)
            {
                ShowedListOfMachineParts.Add(part);
            }
        }
        public void SearchPart()
        {
            string temp = InputSearch;
            if (!string.IsNullOrEmpty(temp))
            {
                // Filter the collection to only include items with the search value in the name
                var filtered = FullListOfMachineParts.Where(part => part.Name.Contains(temp, StringComparison.OrdinalIgnoreCase)).ToList();

                ShowedListOfMachineParts.Clear();
                foreach (var part1 in filtered)
                {
                    ShowedListOfMachineParts.Add(part1);
                }
            }
        }
        public async void UploadPartList()
        {
            foreach (var part in FullListOfMachineParts)
            {
                var data = new
                {
                    name = part.Name,
                    category = part.Category,
                    description = part.Description,
                    volume = part.Volume,
                    price = part.Price,
                };

                try
                {
                    bool success = await _apiService.PostDataAsync(apiPostUrl, data);
                    if (success)
                    {
                        CurrentAct = "Your part uploaded.";
                    }
                    else
                    {
                        CurrentAct = "Something went wrong!";
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine($"An error occurred: {httpEx.Message}");
                    CurrentAct = "Something went wrong!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    CurrentAct = "Something went wrong!";
                }
            }
        }
        public void SavePartList()
        {
            try
            {
                // Path to the file
                string filePath = "C:\\Users\\vbtan\\Desktop\\ExamenNovember\\MainWindow\\SavedPartsFile.txt";

                // Convert the list of parts to a list of strings
                var linesToWrite = FullListOfMachineParts.Select(part => part.ToString()).ToList();

                File.WriteAllLines(filePath, linesToWrite);

                CurrentAct = $"List of {FullListOfMachineParts.Count()} parts has been saved to the file.";
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"An error occurred: {httpEx.Message}");
                CurrentAct = "Something went wrong!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                CurrentAct = "Something went wrong!";
            }
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialDesignCustomEffect.ViewModels
{
    public class ListBoxCombinationViewModel : BindableBase
    {
        public List<string> Fruits { get; }

        private string _selectedFruit;
        public string SelectedFruit
        {
            get { return _selectedFruit; }
            set { SetProperty(ref _selectedFruit, value); }
        }

        public ListBoxCombinationViewModel()
        {
            Fruits = new List<string>()
            {
                "Apple",
                "Banana",
                "Grape",
                "Lemon",
                "Orange"
            };
        }
    }
}

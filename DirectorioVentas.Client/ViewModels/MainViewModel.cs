using DirectorioVentas.Client.Models;
using DirectorioVentas.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace DirectorioVentas.Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient = new();

        public ObservableCollection<Persona> Personas { get; set; } = new();

        private Persona _nuevaPersona = new();
        public Persona NuevaPersona
        {
            get => _nuevaPersona;
            set { _nuevaPersona = value; OnPropertyChanged(); }
        }

        public ICommand CargarCommand { get; }
        public ICommand GuardarCommand { get; }

        public MainViewModel()
        {
            CargarCommand = new RelayCommand(async _ => await CargarAsync());
            GuardarCommand = new RelayCommand(async _ => await GuardarAsync());
        }

        private async Task CargarAsync()
        {
            Personas.Clear();
            var lista = await _apiClient.GetPersonasAsync();
            foreach (var p in lista) Personas.Add(p);
        }

        private async Task GuardarAsync()
        {
            if (string.IsNullOrWhiteSpace(NuevaPersona.Nombre) ||
                string.IsNullOrWhiteSpace(NuevaPersona.ApellidoPaterno) ||
                string.IsNullOrWhiteSpace(NuevaPersona.Identificacion))
            {
                MessageBox.Show("Los campos Nombre, Apellido Paterno e Identificación son obligatorios.");
                return;
            }

            var ok = await _apiClient.AddPersonaAsync(NuevaPersona);
            if (ok)
            {
                MessageBox.Show("Persona registrada con éxito.");
                await CargarAsync();
                NuevaPersona = new Persona();
            }
            else
            {
                MessageBox.Show("Error al registrar la persona.");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

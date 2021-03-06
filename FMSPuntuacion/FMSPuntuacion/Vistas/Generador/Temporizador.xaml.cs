﻿using Android.Content.PM;
using Android.Runtime;
using FMSPuntuacion.Controls;
using FMSPuntuacion.Models;
using FMSPuntuacion.Models.Base;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using Xamarin.Essentials;

namespace FMSPuntuacion.Vistas.Generador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Temporizador : ContentPage
	{
        public Command OnCheckedChanged { get; set; }
        public bool flagy;
        public System.IO.Stream audioStream;
        public int conu = 0;
        public bool Flagy
        {
            get
            {
                return flagy;
            }

            set
            {
                flagy = value;
            }
        }
        public Temporizador()
		{
			InitializeComponent ();
           
            BindingContext = new MyCountDownModel();       
            //RadioBtn.ItemsSource = new[]
            //{
            //    "5 Segundos", "10 Segundos"
            //};

            //RadioBtn.IsEnabled = false;
            
            // OnCheckedChanged = new Command(OnCheckBoxChanged);
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as BaseModel;
            
            
            //await vm?.LoadAsync();
        }

        protected override async void OnDisappearing()
        {
           // adInterstitial.showAd();
            base.OnDisappearing();
            var vm = BindingContext as BaseModel;
            await vm?.UnloadAsync();
        }

        //private void Seleccionar(object sender, int e)
        //{
        //    var radio = sender as CustomRadioButton;
        //    if (radio == null || radio.Id == -1)
        //    {
        //        return;
        //    }
        //}

        public void CambioBandera(object sender, EventArgs e)
        {

            //if (palabras.Checked)
            //{
            //    RadioBtn.IsEnabled = true;
            //    RadioBtn.Items[0].Checked = true;
            //}       
            //else
            //{
            //    RadioBtn.IsEnabled = false;
            //    RadioBtn.Items[0].Checked = false;
            //    RadioBtn.Items[1].Checked = false;
            //}
                
            // objCountDown.Restart();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {          
            try
            {
                var status = await CheckPermiso();
                if (status != PermissionStatus.Granted)
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso", "Sin permiso de lectura no se reproducirá la instrumental", "OK");
                }

                FileData file = await CrossFilePicker.Current.PickFile();
                // FileData fileData = await CrossFilePicker.Current.PickFile();
                // string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);
                if (file != null)
                {
                    lbl.Text = file.FileName;             
                    audioStream = new MemoryStream(file.DataArray);
                    conu = 0;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Asegurate de dar permisos de lectura a la App", "OK");
            }


        }     

        private void play(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            if (conu == 0)
            {   try
                {
                    MemoryStream stream = new MemoryStream();
                    player.Load(audioStream);
                    conu++;
                }catch (NullReferenceException )
                {
                    Application.Current.MainPage.DisplayAlert("Alerta", "No se ha cargado ningún archivo", "OK");
                }
                catch (Exception ex)
                {
                    Application.Current.MainPage.DisplayAlert("Alerta", "Tipo de archivo no reconocido, debe de ser un audio", "OK");
                }          
                
            }        
            player.Play();
        }

        private void pausa(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Pause();
        }

        private void stop(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Stop();
        }

        public async Task<PermissionStatus> CheckPermiso()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
            }


            return status;
        }

        async Task RequestPermission()
        {
            var res = await Plugin.Permissions.CrossPermissions.Current.CheckPermissionStatusAsync(
                Plugin.Permissions.Abstractions.Permission.Storage);
            if (res == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                return;
            else
            {
                await Plugin.Permissions.CrossPermissions.Current.RequestPermissionsAsync(
               Plugin.Permissions.Abstractions.Permission.Storage);
            }
        }



    }
}
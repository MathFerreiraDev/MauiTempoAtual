using System.Diagnostics;

namespace MauiTempoAtual
{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource _cancelTokenSource;
        bool _isCheckingLocation;

        string? cidade;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_getLoaction_Clicked(object sender, EventArgs e)
        {
            try
            {
                _cancelTokenSource = new CancellationTokenSource();

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                Location? location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    lbl_latitude.Text = location.Latitude.ToString();
                    lbl_longitude.Text = location.Longitude.ToString();

                    Debug.WriteLine("----------------------------------------");
                    Debug.WriteLine(location);
                    Debug.WriteLine("----------------------------------------");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                //Handle not supported on device exception
                await DisplayAlert("Erro: Dispositivo nao suporta", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fnsEx)
            {
                await DisplayAlert("Erro: Localizacao Desabilitada", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Erro: Permissao", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro: ", ex.Message, "OK");
            }
        }

        private void btn_placemark_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_getReport_Clicked(object sender, EventArgs e)
        {

        }
    }

}

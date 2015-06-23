﻿/*
    Copyright(c) Microsoft Open Technologies, Inc. All rights reserved.

    The MIT License(MIT)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files(the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions :

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using System;
using System.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IoTCoreDefaultApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OOBEWelcome : Page
    {
        private LanguageManager languageManager;
        private DispatcherTimer timer;
        private DispatcherTimer countdown;


        public OOBEWelcome()
        {
            this.InitializeComponent();

            Unloaded += MainPage_Unloaded;

            SetupLanguages();
            UpdateBoardInfo();
            UpdateNetworkInfo();

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Start();

            countdown = new DispatcherTimer();
            countdown.Tick += countdown_Tick;
            countdown.Interval = TimeSpan.FromMilliseconds(100);
        }

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            countdown.Stop();
        }

        private async void countdown_Tick(object sender, object e)
        {
            var value = DefaultLanguageProgress.Value + DefaultLanguageProgress.SmallChange * 5;
            DefaultLanguageProgress.Value = value;
            if (value >= DefaultLanguageProgress.Maximum)
            {
                countdown.Stop();
                await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    NavigationUtils.NavigateToScreen(typeof(MainPage));
                });
            }
        }

        private void timer_Tick(object sender, object e)
        {
            timer.Stop();
            ChooseDefaultLanguage.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
            countdown.Start();
        }

        private void SetupLanguages()
        {
            languageManager = new LanguageManager();

            LanguagesListBox.ItemsSource = languageManager.LanguageDisplayNames;
            LanguagesListBox.SelectedItem = LanguageManager.GetCurrentLanguageDisplayName();
        }

        private bool SetPreferences()
        {
            var selectedLanguage = LanguagesListBox.SelectedItem as string;
            return languageManager.UpdateLanguage(selectedLanguage);
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            countdown.Stop();
            ChooseDefaultLanguage.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;
        }

        private async void NextButton_Clicked(object sender, RoutedEventArgs e)
        {
            var wifiAvailable = NetworkPresenter.WifiIsAvailable();
            SetPreferences();
            Type nextScreen;

            try
            {
                nextScreen = (await wifiAvailable) ? typeof(OOBENetwork) : typeof(MainPage);
            }
            catch (Exception)
            {
                nextScreen = typeof(MainPage);
            }

            await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                NavigationUtils.NavigateToScreen(nextScreen);
            });
        }

        private void LanguagesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!SetPreferences())
            {
                // just exit if the language has not changed
                return;
            }

            // reload
            if (this.Frame != null)
            {
                Type type = this.Frame.CurrentSourcePageType;
                try
                {
                    this.Frame.Navigate(type);
                    this.Frame.BackStack.Remove(this.Frame.BackStack[this.Frame.BackStack.Count - 1]);
                }
                catch
                {
                }
            }
        }

        private void UpdateBoardInfo()
        {
            ulong version = 0;
            if (!ulong.TryParse(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamilyVersion, out version))
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                OSVersion.Text = loader.GetString("OSVersionNotAvailable");
            }
            else
            {
                OSVersion.Text = String.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}",
                    (version & 0xFFFF000000000000) >> 48,
                    (version & 0x0000FFFF00000000) >> 32,
                    (version & 0x00000000FFFF0000) >> 16,
                    version & 0x000000000000FFFF);
            }
        }

        private void UpdateNetworkInfo()
        {
            this.DeviceName.Text = DeviceInfoPresenter.GetDeviceName();
            this.IPAddress1.Text = NetworkPresenter.GetCurrentIpv4Address();
        }

    }
}

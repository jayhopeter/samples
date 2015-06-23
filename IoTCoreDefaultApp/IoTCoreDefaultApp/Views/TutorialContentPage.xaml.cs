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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media.Imaging;

namespace IoTCoreDefaultApp
{
    public sealed partial class TutorialContentPage : Page
    {
        private DispatcherTimer timer;
        private string docName;

        public TutorialContentPage()
        {
            this.InitializeComponent();

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigated += RootFrame_Navigated;

            UpdateDateTime();

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Start();
        }

        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            docName = e.Parameter as string;
            if (docName != null)
            {
                LoadDocument(docName);
                NextButton.Visibility = (NavigationUtils.IsNextTutorialButtonVisible(docName) ? Visibility.Visible : Visibility.Collapsed);
            }
        }

        private void LoadDocument(string docname)
        {
            var resourceMap = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap;
            var resourceContext = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView();
            var keys = resourceMap.Keys.Where(s => { return s.StartsWith("Resources/Tutorial/" + docname + "/"); }).OrderBy(s => s).ToArray();

            TutorialRichText.Blocks.Clear();
            foreach (var key in keys)
            {
                var split = key.Split('/');
                if (split.Length == 0)
                {
                    continue;
                }
                var blockType = split.Last();
                var value = resourceMap[key].Resolve(resourceContext).ValueAsString;
                var par = new Paragraph();
                switch (blockType)
                {
                    case "title":
                        par.FontSize = 28;
                        par.Inlines.Add(new Run { Text = value });
                        break;
                    case "subtitle":
                        par.FontSize = 11;
                        par.Inlines.Add(new Run { Text = value });
                        break;
                    case "h1":
                        par.FontSize = 16;
                        par.Inlines.Add(new Run { Text = value });
                        break;
                    case "p":
                        par.FontSize = 11;
                        par.Inlines.Add(new Run { Text = value });
                        break;
                    case "ul":
                        par.FontSize = 11;
                        value = "\u27a4 " + value;
                        par.Inlines.Add(new Run { Text = value });
                        break;
                    case "image":
                        try
                        {
                            var imageSource = new BitmapImage(new Uri("ms-appx:///" + value));
                            var size = split[split.Length - 2];
                            if (size.Contains('x'))
                            {
                                var sizeSplit = size.Split('x');
                                var dx = int.Parse(sizeSplit[0]);
                                var dy = int.Parse(sizeSplit[1]);
                                par.Inlines.Add(new InlineUIContainer { Child = new Image { Source = imageSource, Width = dx, Height = dy } });
                            }
                            else
                            {
                                par.Inlines.Add(new InlineUIContainer { Child = new Image { Source = imageSource } });
                            }
                        }
                        catch (Exception)
                        {
                            // just ignore this entry if anything goes wrong...
                        }
                        break;
                }
                TutorialRichText.Blocks.Add(par);
            }
        }

        private void timer_Tick(object sender, object e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            var t = DateTime.Now;
            this.CurrentTime.Text = t.ToString("t", CultureInfo.CurrentCulture);
        }

        private void ShutdownButton_Clicked(object sender, RoutedEventArgs e)
        {
            ShutdownDropdown.IsOpen = true;
        }

        private void ShutdownDropdown_Opened(object sender, object e)
        {
            var w = ShutdownListView.ActualWidth;
            if (w == 0)
            {
                // trick to recalculate the size of the dropdown
                ShutdownDropdown.IsOpen = false;
                ShutdownDropdown.IsOpen = true;
            }
            var offset = -(ShutdownListView.ActualWidth - ShutdownButton.ActualWidth);
            ShutdownDropdown.HorizontalOffset = offset;
        }


        private void ShutdownHelper(ShutdownKind kind)
        {
            ShutdownManager.BeginShutdown(kind, TimeSpan.FromSeconds(0.5));
        }

        private void ShutdownListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as FrameworkElement;
            if (item == null)
            {
                return;
            }
            switch (item.Name)
            {
                case "ShutdownOption":
                    ShutdownHelper(ShutdownKind.Shutdown);
                    break;
                case "RestartOption":
                    ShutdownHelper(ShutdownKind.Restart);
                    break;
            }
        }

        private void SettingsButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationUtils.NavigateToScreen(typeof(Settings));
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationUtils.GoBack();
        }

        private void DeviceInfo_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationUtils.NavigateToScreen(typeof(MainPage));
        }

        private void NextButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationUtils.NavigateToNextTutorialFrom(docName);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ApplicationSettings;

// 設定フライアウトの項目テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=273769 を参照してください

namespace CompatibilityChecker
{
  public sealed partial class AppExplain : SettingsFlyout
  {
    public AppExplain()
    {
      this.InitializeComponent();
    }
  }
}

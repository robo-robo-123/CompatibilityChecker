using System;
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

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace CompatibilityChecker_UWP.View
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public ViewModels.MainPageViewModel ViewModel { get; } = new ViewModels.MainPageViewModel();
    string cc;
    string sl;
    string md;
    string times;

    string no;
    string fir;
    string wa;
    string el;
    string gra;
    string ic;
    string fi;
    string po;
    string gro;
    string fl;
    string ps;
    string bu;
    string ro;
    string gh;
    string dr;
    string da;
    string st;
    string fa;
    public MainPage()
    {
      this.InitializeComponent();
          var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();
      no = resourceLoader.GetString("no");
      fir = resourceLoader.GetString("fir");
      wa = resourceLoader.GetString("wa");
      el = resourceLoader.GetString("el");
      gra = resourceLoader.GetString("gra");
      ic = resourceLoader.GetString("ic");
      fi = resourceLoader.GetString("fi");
      po = resourceLoader.GetString("po");
      gro = resourceLoader.GetString("gro");
      fl = resourceLoader.GetString("fl");
      ps = resourceLoader.GetString("ps");
      bu = resourceLoader.GetString("bu");
      ro = resourceLoader.GetString("ro");
      gh = resourceLoader.GetString("gh");
      dr = resourceLoader.GetString("dr");
      da = resourceLoader.GetString("da");
      st = resourceLoader.GetString("st");
      fa = resourceLoader.GetString("fa");

      //DefenseBox1();
      Box(this.defenseBox1);
      Box(this.defenseBox2);
      Box(this.attackTechBox);
      Box(this.attackBox1);
      Box(this.attackBox2);

      defenseBox1.SelectedIndex = 1;
       defenseBox2.SelectedIndex = 0;
       attackTechBox.SelectedIndex = 1;
       attackBox1.SelectedIndex = 1;
       attackBox2.SelectedIndex = 0;
    }

    private void Box(ComboBox box)
    {
      box.Items.Add("---");
      box.Items.Add(no);
      box.Items.Add(fir);
      box.Items.Add(wa);
      box.Items.Add(el);
      box.Items.Add(gra);
      box.Items.Add(ic);
      box.Items.Add(fi);
      box.Items.Add(po);
      box.Items.Add(gro);
      box.Items.Add(fl);
      box.Items.Add(ps);
      box.Items.Add(bu);
      box.Items.Add(ro);
      box.Items.Add(gh);
      box.Items.Add(dr);
      box.Items.Add(da);
      box.Items.Add(st);
      box.Items.Add(fa);
    }

    private void ResetButton_Tapped(object sender, TappedRoutedEventArgs e)
    {

      defenseBox1.SelectedIndex = 1;
      defenseBox2.SelectedIndex = 0;
      attackTechBox.SelectedIndex = 0;
      attackBox1.SelectedIndex = 1;
      attackBox2.SelectedIndex = 0;
      ViewModel.Clear();
      //CheckButton.IsEnabled = true;
      //bumButton.IsChecked = false;
    }

  }
}

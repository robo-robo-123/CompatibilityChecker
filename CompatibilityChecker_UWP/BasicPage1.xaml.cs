using CompatibilityChecker.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.Storage;

// 基本ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234237 を参照してください

namespace CompatibilityChecker
{
  /// <summary>
  /// 多くのアプリケーションに共通の特性を指定する基本ページ。
  /// </summary>
  public sealed partial class BasicPage1 : Page
  {

    private NavigationHelper navigationHelper;
    private ObservableDictionary defaultViewModel = new ObservableDictionary();

    List<string> datas;
    List<ResultMemo> memo;
    ObservableCollection<ResultMemo> memo2;

    string cc;
    string sl;

    /// <summary>
    /// これは厳密に型指定されたビュー モデルに変更できます。
    /// </summary>
    public ObservableDictionary DefaultViewModel
    {
      get { return this.defaultViewModel; }
    }

    /// <summary>
    /// NavigationHelper は、ナビゲーションおよびプロセス継続時間管理を
    /// 支援するために、各ページで使用します。
    /// </summary>
    public NavigationHelper NavigationHelper
    {
      get { return this.navigationHelper; }
    }


    public BasicPage1()
    {
      this.InitializeComponent();
      this.navigationHelper = new NavigationHelper(this);
      this.navigationHelper.LoadState += navigationHelper_LoadState;
      this.navigationHelper.SaveState += navigationHelper_SaveState;
      datas = new List<string>();
      memo = new List<ResultMemo>();
      memo2 = new ObservableCollection<ResultMemo>();

      var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();

      cc = resourceLoader.GetString("CompatibilityCheck");
      sl = resourceLoader.GetString("SavedList");
//      
      this.SizeChanged += VerticalHubPage_SizeChanged;
      PageSelectBox(); pageSelectBox.SelectedIndex = 1;
    }


    void VerticalHubPage_SizeChanged(object sender, SizeChangedEventArgs e)
    {


      /*if (e.NewSize.Width >= 800 && e.NewSize.Width < 1000)
      {
        checkGrid.HorizontalAlignment = HorizontalAlignment.Right;
        VisualStateManager.GoToState(this, "ContentRegion", true);
        RowDefinition def = new RowDefinition();
        def.Height = new GridLength(140, GridUnitType.Pixel);
        this.defaultNavigation.RowDefinitions[0] = def;
      }

      else */if (e.NewSize.Width < 850)
      {
        VisualStateManager.GoToState(this, "MinicontentRegion", true);
        /*
                          adGrid1.Width = 160;

                          defenseBox1.Width = 125;
                          attackBox1.Width = 125;*/
        checkGrid.HorizontalAlignment = HorizontalAlignment.Center;
                          checkGrid.Width = 300;
                    //      checkPanel.Width = 300;

                          RowDefinition def = new RowDefinition();
                          def.Height = new GridLength(70, GridUnitType.Pixel);
                          this.defaultNavigation.RowDefinitions[0] = def;

      }
      else
      {
        VisualStateManager.GoToState(this, "ContentRegion", true);


        /*
              adGrid1.Width = 320;
              checkGrid.Width = gridpreviousWidth;
              defenseBox1.Width = difencepreviousWidth;
              attackBox1.Width = attackpreviousHeight;*/
        checkGrid.HorizontalAlignment = HorizontalAlignment.Center;
        checkGrid.Width = 400;
    //    checkPanel.Width = 400;
        RowDefinition def = new RowDefinition();
        def.Height = new GridLength(140, GridUnitType.Pixel);
        this.defaultNavigation.RowDefinitions[0] = def;

      }

    } 

    private void PageSelectBox()
    {
      pageSelectBox.Items.Add(cc);
      pageSelectBox.Items.Add(sl);
    }

/*    async public void populateDatas()
    {
//      List<string> datas = new List<string>();
      String filePath = "StoreData.csv";
      // write file
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
      try
      {
        StorageFile file = await localFolder.GetFileAsync(filePath);
        IList<String> strList = await FileIO.ReadLinesAsync(file);
        foreach (String str in strList)
        {
                    string[] msg1 = str.Split('-');
          //          string msg2 = string.Join("\n", msg1);
          datas.Add(str);

        }

      }
      catch (Exception ex)
      {
        // ファイル無し
//        datas.Add("null");
      }
    }*/


    /// <summary>
    /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
    /// 再作成する場合は、保存状態も指定されます。
    /// </summary>
    /// <param name="sender">
    /// イベントのソース (通常、<see cref="NavigationHelper"/>)>
    /// </param>
    /// <param name="e">このページが最初に要求されたときに
    /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたナビゲーション パラメーターと、
    /// 前のセッションでこのページによって保存された状態の辞書を提供する
    /// セッション。ページに初めてアクセスするとき、状態は null になります。</param>
    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
//      var ListView1 = new ListView();




//        test.Text = e.NavigationParameter.ToString();

//      datas = new List<string>();
      var p1 = new LastviewDataStore(ref datas);
//      var p2 = new MemoStore(ref memo);
      try
      {
      if (datas.Count != 0)
      { 

      for (int i = 0; i < datas.Count; i++)
      {
        string msg;
        msg = datas[i];

        string[] msg1 = msg.Split('\t');
        //                    string msg2 = string.Join("\n", msg1);
        memo.Add(new ResultMemo
        {
          MemoName = msg1[0],
          defence1 = int.Parse(msg1[1]),
          defence2 = int.Parse(msg1[2]),
          attackTech = int.Parse(msg1[3]),
          attack1 = int.Parse(msg1[4]),
          attack2 = int.Parse(msg1[5]),
          date = msg1[6]
        });

        memo2.Add(new ResultMemo
        {
          MemoName = msg1[0],
          defence1 = int.Parse(msg1[1]),
          defence2 = int.Parse(msg1[2]),
          attackTech = int.Parse(msg1[3]),
          attack1 = int.Parse(msg1[4]),
          attack2 = int.Parse(msg1[5]),
          date = msg1[6]
        });

      }

}
      }
      catch (Exception ex)
      { }


//      var p2 = new MemoStore(memo);



//      populateDatas();
//      this.ListView1.DataContext = datas;

//      this.ListView1.ItemsSource = datas;

      this.ListView1.ItemsSource = memo2;
//            ListView1.ItemsSource = datas;
//      StackPanel1.Children.Add(ListView1);
//      test.Text = (string)datas[3];
//      cvs1.Source = datas;
//      ListView1.ItemsSource = datas;
//      ListView1.Items.EnsureVisible;

    }

    /// <summary>
    /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
    /// このページに関連付けられた状態を保存します。値は、
    /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
    /// </summary>
    /// <param name="sender">イベントのソース (通常、<see cref="NavigationHelper"/>)</param>
    /// <param name="e">シリアル化可能な状態で作成される空のディクショナリを提供するイベント データ
    ///。</param>
    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
    }

    #region NavigationHelper の登録

    /// このセクションに示したメソッドは、NavigationHelper がページの
    /// ナビゲーション メソッドに応答できるようにするためにのみ使用します。
    /// 
    /// ページ固有のロジックは、
    /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
    /// および <see cref="GridCS.Common.NavigationHelper.SaveState"/> のイベント ハンドラーに配置する必要があります。
    /// LoadState メソッドでは、前のセッションで保存されたページの状態に加え、
    /// ナビゲーション パラメーターを使用できます。

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedFrom(e);
    }

    #endregion

    private void ListViewItem_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {

    }

    private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ListView1_ItemClick(object sender, ItemClickEventArgs e)
    {

    }

    private void checkButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      int index = ListView1.SelectedIndex;
//      test.Text = datas[index];

      try { 
      this.Frame.Navigate(typeof(ItemDetailPage), datas[index]);
}
      catch (Exception ex) { }
    }

    async private void deleteButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      Flyout.ShowAttachedFlyout(sender as FrameworkElement);
    }


    private void pageSelectBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
      if ((string)pageSelectBox.SelectedItem == cc)
        this.Frame.Navigate(typeof(ItemDetailPage));
    }

    async private void deleteOkButton_Click(object sender, RoutedEventArgs e)
    {



//      var s1 = new PopulateDatas();
//      s1.populateDatas();

        /*
        for (int i =0;i<datas.Count;i++)
        {
          if(datas[i] == ListView1.SelectedIndex)


        }

//          foreach (int num in ListView1.SelectedIndex)

/*        foreach (String str in strList)
        {

          if(str == )

          datas.Add(str);
//          memo.Add(str);
        }*/



/*      for ( int i = 0; i< datas.Count ; i++)
      {
        for (int j=0; j < stItems.Count; j++)
        {

          if (stItems[j] != datas[i])
        {

        }
        }
      }*/
            String filePath = "StoreData.txt";
      // write file


      StorageFolder localFolder = ApplicationData.Current.LocalFolder;


            StorageFile file = await localFolder.CreateFileAsync(filePath,
          CreationCollisionOption.ReplaceExisting);

            datas.Clear();
            var p1 = new LastviewDataStore(datas);
            memo.Clear();
            var p2 = new MemoStore(memo);

        this.Frame.Navigate(typeof(BasicPage1));
    }

    private void deleteCancelButton_Click(object sender, RoutedEventArgs e)
    {
      this.Flyout2.Hide();
    }

    async private void deleteButton_Tapped_1(object sender, TappedRoutedEventArgs e)
    {
      int index = ListView1.SelectedIndex;
      //        testBlock.Text = (string)ListView1.SelectedItem;

      List<string> stItems = new List<string>();
      List<ResultMemo> items = new List<ResultMemo>();
      foreach (ResultMemo item in ListView1.SelectedItems)
      {
        items.Add(item);
        //Flavors.Remove(item);
      }
      //      foreach (string item in ListView1.SelectedItems)
      //      {
      //        stItems.Add(item);
      //Flavors.Remove(item);
      //      }
      foreach (ResultMemo item in items)
      {
        memo2.Remove(item);
      }

      String filePath = "StoreData.txt";

      StorageFolder localFolder = ApplicationData.Current.LocalFolder;

      //            List<string> datas2 = new List<string>();
      //      List<ResultMemo> memo = new List<ResultMemo>();
      //      ObservableCollection<ResultMemo> memo2 = new ObservableCollection<ResultMemo>();

      try
      {
        StorageFile file = await localFolder.CreateFileAsync(filePath, CreationCollisionOption.ReplaceExisting);
        //        StorageFile file = await localFolder.CreateFileAsync(filePath, CreationCollisionOption.OpenIfExists);
        //        IList<String> strList = await FileIO.ReadLinesAsync(file);


        datas.RemoveAt(index);
        //        testBlock.Text = datas[index];
        foreach (String str in datas)
        {
          await FileIO.AppendTextAsync(file, str + '\n');
          //          testBlock.Text += str;
        }
      }

      catch (Exception ex)
      {

      }

      var p1 = new LastviewDataStore(datas);

    }

  }
}

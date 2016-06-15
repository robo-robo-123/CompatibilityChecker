using CompatibilityChecker.Common;
//using CompatibilityChecker.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
using Windows.ApplicationModel.DataTransfer;

// アイテム詳細ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234232 を参照してください

namespace CompatibilityChecker
{
    /// <summary>
    /// グループ内の単一のアイテムの詳細を表示するページ。
    /// </summary>
    public sealed partial class ItemDetailPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        List<Affinity> normal;
      List<Affinity> fire;
        List<Affinity> water;// = new List<Affinity>();
        List<Affinity> electric;// = new List<Affinity>();
        List<Affinity> grass;// = new List<Affinity>();
        List<Affinity> ice;// = new List<Affinity>();
        List<Affinity> fighting;// = new List<Affinity>();
        List<Affinity> poison;// = new List<Affinity>();
        List<Affinity> ground;// = new List<Affinity>();
        List<Affinity> flying;// = new List<Affinity>();
        List<Affinity> psychic;// = new List<Affinity>();
        List<Affinity> bug;// = new List<Affinity>();
        List<Affinity> rock;// = new List<Affinity>();
        List<Affinity> ghost;// = new List<Affinity>();
        List<Affinity> dragon;// = new List<Affinity>();
        List<Affinity> dark;// = new List<Affinity>();
        List<Affinity> steel;// = new List<Affinity>();
        List<Affinity> fairy;// = new List<Affinity>();*/




/*
            string no = "ノーマル";
      string fir = "ほのお";
      string wa = "みず";
      string el = "でんき";
      string gra = "くさ";
      string ic = "こおり";
      string fi = "かくとう";
      string po = "どく";
      string gro = "じめん";
      string fl = "ひこう";
      string ps = "エスパー";
      string bu = "むし";
      string ro = "いわ";
      string gh = "ゴースト";
      string dr = "ドラゴン";
      string da = "あく";
      string st = "はがね";
      string fa = "フェアリー";
*/

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





      double difencepreviousWidth;
      double attackpreviousHeight;
      double gridpreviousWidth;
      string Sresult;


      double result;
      int flag;
      string data;

      List<string> datas;
      ObservableCollection<string> memo;
      
      
        /// <summary>
        /// NavigationHelper は、ナビゲーションおよびプロセス継続時間管理を
        /// 支援するために、各ページで使用します。
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// これは厳密に型指定されたビュー モデルに変更できます。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public ItemDetailPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
          this.SizeChanged += VerticalHubPage_SizeChanged;

          var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();

          cc = resourceLoader.GetString("CompatibilityCheck");
          sl = resourceLoader.GetString("SavedList");
          md = resourceLoader.GetString("MemoData");
          times = resourceLoader.GetString("times");

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


/*
          no = "ノーマル";
          fir = "ほのお";
          wa = "みず";
          el = "でんき";
          gra = "くさ";
          ic = "こおり";
          fi = "かくとう";
          po = "どく";
          gro = "じめん";
          fl = "ひこう";
          ps = "エスパー";
          bu = "むし";
          ro = "いわ";
          gh = "ゴースト";
          dr = "ドラゴン";
          da = "あく";
          st = "はがね";
          fa = "フェアリー";
          */


          PageSelectBox(); pageSelectBox.SelectedIndex = 0;

            DefenseBox1(); defenseBox1.SelectedIndex = 0;
            DefenseBox2(); defenseBox2.SelectedIndex = 0;
            AttackTechBox(); attackTechBox.SelectedIndex = 0;
            AttackBox1(); attackBox1.SelectedIndex = 0;
            AttackBox2(); attackBox2.SelectedIndex = 0;

            normal = new List<Affinity>();
          fire = new List<Affinity>();
            water = new List<Affinity>();
            electric = new List<Affinity>();
          grass = new List<Affinity>();
          ice = new List<Affinity>();
          fighting = new List<Affinity>();
          poison = new List<Affinity>();
          ground = new List<Affinity>();
          flying = new List<Affinity>();
          psychic = new List<Affinity>();
          bug = new List<Affinity>();
          rock = new List<Affinity>();
          ghost = new List<Affinity>();
          dragon = new List<Affinity>();
          dark = new List<Affinity>();
          steel = new List<Affinity>();
          fairy = new List<Affinity>();






          Normal();
          Fire();
          Water();
          Electric();
          Grass();
          Ice();
          Fighting();
          Poison();
          Ground();
          Flying();
          Psychic();
          Bug();
          Rock();
          Ghost();
          Dragon();
          Dark();
          Steel();
          Fairy();

//            var P1 = new Type();
          result = 1;
          flag = 1;
//            P1.Normal();


          datas = new List<string>();
          memo = new ObservableCollection<string>();



        }





/*
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
          // 共有イベントの利用
          DataTransferManager.GetForCurrentView().DataRequested += OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender,
                               DataRequestedEventArgs args)
        {
          // DataPackageの取得
          DataPackage data = args.Request.Data;

          // アプリ名、タイトル、説明の設定
          data.Properties.ApplicationName = "タイプ相性チェッカー";
          data.Properties.Title = "相性の結果を表示します";
          data.Properties.Description = "結果を送信します";
          // 共有テキストの設定
          data.SetText("こんにちは\nメール本文です");
        }
      */

      
        void VerticalHubPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {


          if(e.NewSize.Width >= 770 && e.NewSize.Width < 1000)
          {
            checkGrid.HorizontalAlignment = HorizontalAlignment.Right;

            VisualStateManager.GoToState(this, "ContentRegion", true);
            RowDefinition def = new RowDefinition();
            def.Height = new GridLength(140, GridUnitType.Pixel);
            this.defaultNavigation.RowDefinitions[0] = def;
          }
          
          else if (e.NewSize.Width < 770) 
                {
                  VisualStateManager.GoToState(this, "MinicontentRegion", true);
/*
                  adGrid1.Width = 160;
                  checkGrid.Width = 300;
                  defenseBox1.Width = 125;
                  attackBox1.Width = 125;*/

                  checkGrid.HorizontalAlignment = HorizontalAlignment.Center;

                  int size = 24;

                 // defendBlock1.FontSize = size;
                  andBlock.FontSize = size;
                  //attackBlock.FontSize = size;
                  //attackTechBlock.FontSize = size;
                  andBlock1.FontSize = size;
                  andBlock2.FontSize = size;
                  resultBlock.FontSize = size;
                  ResultBox.FontSize = size;
                  vsBlock.FontSize = size;

                  RowDefinition def = new RowDefinition();
                  def.Height = new GridLength(70, GridUnitType.Pixel);
                  this.defaultNavigation.RowDefinitions[0] = def;

                 } 
                else 
                {
                  VisualStateManager.GoToState(this, "ContentRegion", true);

                  int size = 36;

                //  defendBlock1.FontSize = size;
                  andBlock.FontSize = size;
                  //attackBlock.FontSize = size;
                 // attackTechBlock.FontSize = size;
                  andBlock1.FontSize = size;
                  andBlock2.FontSize = size;
                  resultBlock.FontSize = size;
                  ResultBox.FontSize = size;
                  vsBlock.FontSize = size;
            /*
                  adGrid1.Width = 320;
                  checkGrid.Width = gridpreviousWidth;
                  defenseBox1.Width = difencepreviousWidth;
                  attackBox1.Width = attackpreviousHeight;*/
                  RowDefinition def = new RowDefinition();
                  def.Height = new GridLength(140, GridUnitType.Pixel);
                  this.defaultNavigation.RowDefinitions[0] = def;

                  checkGrid.HorizontalAlignment = HorizontalAlignment.Center;


                } 

            } 


      private void PageSelectBox()
        {
          pageSelectBox.Items.Add(cc);
          pageSelectBox.Items.Add(sl);
        }

      private void DefenseBox1()
        {

            defenseBox1.Items.Add(no);
            defenseBox1.Items.Add(fir);
            defenseBox1.Items.Add(wa);
            defenseBox1.Items.Add(el);
            defenseBox1.Items.Add(gra);
            defenseBox1.Items.Add(ic);
            defenseBox1.Items.Add(fi);
            defenseBox1.Items.Add(po);
            defenseBox1.Items.Add(gro);
            defenseBox1.Items.Add(fl);
            defenseBox1.Items.Add(ps);
            defenseBox1.Items.Add(bu);
            defenseBox1.Items.Add(ro);
            defenseBox1.Items.Add(gh);
            defenseBox1.Items.Add(dr);
            defenseBox1.Items.Add(da);
            defenseBox1.Items.Add(st);
            defenseBox1.Items.Add(fa);

        }

      private void DefenseBox2()
      {

        defenseBox2.Items.Add("---");
        defenseBox2.Items.Add(no);
        defenseBox2.Items.Add(fir);
        defenseBox2.Items.Add(wa);
        defenseBox2.Items.Add(el);
        defenseBox2.Items.Add(gra);
        defenseBox2.Items.Add(ic);
        defenseBox2.Items.Add(fi);
        defenseBox2.Items.Add(po);
        defenseBox2.Items.Add(gro);
        defenseBox2.Items.Add(fl);
        defenseBox2.Items.Add(ps);
        defenseBox2.Items.Add(bu);
        defenseBox2.Items.Add(ro);
        defenseBox2.Items.Add(gh);
        defenseBox2.Items.Add(dr);
        defenseBox2.Items.Add(da);
        defenseBox2.Items.Add(st);
        defenseBox2.Items.Add(fa);
/*
        defenseBox2.Items.Add("ノーマル");
        defenseBox2.Items.Add("ほのお");
        defenseBox2.Items.Add("みず");
        defenseBox2.Items.Add("でんき");
        defenseBox2.Items.Add("くさ");
        defenseBox2.Items.Add("こおり");
        defenseBox2.Items.Add("かくとう");
        defenseBox2.Items.Add("どく");
        defenseBox2.Items.Add("じめん");
        defenseBox2.Items.Add("ひこう");
        defenseBox2.Items.Add("エスパー");
        defenseBox2.Items.Add("むし");
        defenseBox2.Items.Add("いわ");
        defenseBox2.Items.Add("ゴースト");
        defenseBox2.Items.Add("ドラゴン");
        defenseBox2.Items.Add("あく");
        defenseBox2.Items.Add("はがね");
        defenseBox2.Items.Add("フェアリー");
*/
      }

      private void AttackTechBox()
      {

        attackTechBox.Items.Add(no);
        attackTechBox.Items.Add(fir);
        attackTechBox.Items.Add(wa);
        attackTechBox.Items.Add(el);
        attackTechBox.Items.Add(gra);
        attackTechBox.Items.Add(ic);
        attackTechBox.Items.Add(fi);
        attackTechBox.Items.Add(po);
        attackTechBox.Items.Add(gro);
        attackTechBox.Items.Add(fl);
        attackTechBox.Items.Add(ps);
        attackTechBox.Items.Add(bu);
        attackTechBox.Items.Add(ro);
        attackTechBox.Items.Add(gh);
        attackTechBox.Items.Add(dr);
        attackTechBox.Items.Add(da);
        attackTechBox.Items.Add(st);
        attackTechBox.Items.Add(fa);
        /*
        attackTechBox.Items.Add("ほのお");
        attackTechBox.Items.Add("みず");
        attackTechBox.Items.Add("でんき");
        attackTechBox.Items.Add("くさ");
        attackTechBox.Items.Add("こおり");
        attackTechBox.Items.Add("かくとう");
        attackTechBox.Items.Add("どく");
        attackTechBox.Items.Add("じめん");
        attackTechBox.Items.Add("ひこう");
        attackTechBox.Items.Add("エスパー");
        attackTechBox.Items.Add("むし");
        attackTechBox.Items.Add("いわ");
        attackTechBox.Items.Add("ゴースト");
        attackTechBox.Items.Add("ドラゴン");
        attackTechBox.Items.Add("あく");
        attackTechBox.Items.Add("はがね");
        attackTechBox.Items.Add("フェアリー");
      */
      }

      private void AttackBox1()
      {
        attackBox1.Items.Add("---");
        attackBox1.Items.Add(no);
        attackBox1.Items.Add(fir);
        attackBox1.Items.Add(wa);
        attackBox1.Items.Add(el);
        attackBox1.Items.Add(gra);
        attackBox1.Items.Add(ic);
        attackBox1.Items.Add(fi);
        attackBox1.Items.Add(po);
        attackBox1.Items.Add(gro);
        attackBox1.Items.Add(fl);
        attackBox1.Items.Add(ps);
        attackBox1.Items.Add(bu);
        attackBox1.Items.Add(ro);
        attackBox1.Items.Add(gh);
        attackBox1.Items.Add(dr);
        attackBox1.Items.Add(da);
        attackBox1.Items.Add(st);
        attackBox1.Items.Add(fa);

/*
        attackBox1.Items.Add("ノーマル");
        attackBox1.Items.Add("ほのお");
        attackBox1.Items.Add("みず");
        attackBox1.Items.Add("でんき");
        attackBox1.Items.Add("くさ");
        attackBox1.Items.Add("こおり");
        attackBox1.Items.Add("かくとう");
        attackBox1.Items.Add("どく");
        attackBox1.Items.Add("じめん");
        attackBox1.Items.Add("ひこう");
        attackBox1.Items.Add("エスパー");
        attackBox1.Items.Add("むし");
        attackBox1.Items.Add("いわ");
        attackBox1.Items.Add("ゴースト");
        attackBox1.Items.Add("ドラゴン");
        attackBox1.Items.Add("あく");
        attackBox1.Items.Add("はがね");
        attackBox1.Items.Add("フェアリー");
*/
      }

      private void AttackBox2()
      {
        attackBox2.Items.Add("---");
        attackBox2.Items.Add(no);
        attackBox2.Items.Add(fir);
        attackBox2.Items.Add(wa);
        attackBox2.Items.Add(el);
        attackBox2.Items.Add(gra);
        attackBox2.Items.Add(ic);
        attackBox2.Items.Add(fi);
        attackBox2.Items.Add(po);
        attackBox2.Items.Add(gro);
        attackBox2.Items.Add(fl);
        attackBox2.Items.Add(ps);
        attackBox2.Items.Add(bu);
        attackBox2.Items.Add(ro);
        attackBox2.Items.Add(gh);
        attackBox2.Items.Add(dr);
        attackBox2.Items.Add(da);
        attackBox2.Items.Add(st);
        attackBox2.Items.Add(fa);

        /*
        attackBox2.Items.Add("ノーマル");
        attackBox2.Items.Add("ほのお");
        attackBox2.Items.Add("みず");
        attackBox2.Items.Add("でんき");
        attackBox2.Items.Add("くさ");
        attackBox2.Items.Add("こおり");
        attackBox2.Items.Add("かくとう");
        attackBox2.Items.Add("どく");
        attackBox2.Items.Add("じめん");
        attackBox2.Items.Add("ひこう");
        attackBox2.Items.Add("エスパー");
        attackBox2.Items.Add("むし");
        attackBox2.Items.Add("いわ");
        attackBox2.Items.Add("ゴースト");
        attackBox2.Items.Add("ドラゴン");
        attackBox2.Items.Add("あく");
        attackBox2.Items.Add("はがね");
        attackBox2.Items.Add("フェアリー");
        */
      }



      public void Normal()
      {

        normal.Add(new Affinity { Good = null, Bad = ro, Invaild = gh });
        normal.Add(new Affinity { Good = null, Bad = st, Invaild = null });
      }

      public void Fire()
    {
        fire.Add(new Affinity { Good = gra, Bad = fir, Invaild = null });
        fire.Add(new Affinity { Good = ic, Bad = wa, Invaild = null });
        fire.Add(new Affinity { Good = bu, Bad = ro, Invaild = null });
        fire.Add(new Affinity { Good = st, Bad = dr, Invaild = null });

    }



      public void Check()
      {

        CheckType(normal, no);
        CheckType(fire, fir);
        CheckType(water, wa);
        CheckType(electric,el);
        CheckType(grass,gra);
        CheckType(ice,ic);
        CheckType(fighting,fi);
        CheckType(poison,po);
        CheckType(ground,gro);
        CheckType(flying,fl);
        CheckType(psychic,ps);
        CheckType(bug,bu);
        CheckType(rock,ro);
        CheckType(ghost,gh);
        CheckType(dragon,dr);
        CheckType(dark,da);
        CheckType(steel,st);
        CheckType(fairy,fa);

      }

      public void CheckType(List<Affinity> Type, string type)
      {

        if ((string)attackTechBox.SelectedItem == type)
        {

          if ((string)attackBox1.SelectedItem == (string)attackTechBox.SelectedItem || (string)attackBox2.SelectedItem == (string)attackTechBox.SelectedItem)
          {
            result *= 1.5;

            for (int i = 0; i < Type.Count; i++)
            {

              if ((string)defenseBox1.SelectedItem == Type[i].Good)
              {
                result *= 2;
              }
              else result *= 1;

              if ((string)defenseBox2.SelectedItem == Type[i].Good && (string)defenseBox1.SelectedItem != Type[i].Good)
              {
                result *= 2;
              }
              else result *= 1;


              if ((string)defenseBox1.SelectedItem == Type[i].Bad)
              {
                result /= 2;
              }
              else result *= 1;

              if ((string)defenseBox2.SelectedItem == Type[i].Bad && (string)defenseBox1.SelectedItem != Type[i].Bad)
              {
                result /= 2;
              }
              else result *= 1;

              if ((string)defenseBox1.SelectedItem == Type[i].Invaild || (string)defenseBox2.SelectedItem == Type[i].Invaild)
              {
                result *= 0;
              }

            }


          }
          else
          {
            result *= 1;

            for (int i = 0; i < Type.Count; i++)
            {

              if ((string)defenseBox1.SelectedItem == Type[i].Good)
              {
                result *= 2;
              }
              else result *= 1;

              if ((string)defenseBox2.SelectedItem == Type[i].Good && (string)defenseBox1.SelectedItem != Type[i].Good)
              {
                result *= 2;
              }
              else result *= 1;


              if ((string)defenseBox1.SelectedItem == Type[i].Bad)
              {
                result /= 2;
              }
              else result *= 1;

              if ((string)defenseBox2.SelectedItem == Type[i].Bad && (string)defenseBox1.SelectedItem != Type[i].Bad)
              {
                result /= 2;
              }
              else result *= 1;

              if ((string)defenseBox1.SelectedItem == Type[i].Invaild || (string)defenseBox2.SelectedItem == Type[i].Invaild)
              {
                result *= 0;
              }

            }
          }
        }

      }

    public void Water()
    {
      water.Add(new Affinity { Good = fir, Bad = wa, Invaild = null });
      water.Add(new Affinity { Good = gro, Bad = gra, Invaild = null });
      water.Add(new Affinity { Good = ro, Bad = dr, Invaild = null });
    }

    public void Electric()
    {
      electric.Add(new Affinity { Good = wa, Bad = el, Invaild = gro });
      electric.Add(new Affinity { Good = fl, Bad = gra, Invaild = null });
      electric.Add(new Affinity { Good = null, Bad = dr, Invaild = null });
    }

    public void Grass()
    {
      grass.Add(new Affinity { Good = wa, Bad = fir, Invaild = null });
      grass.Add(new Affinity { Good = gro, Bad = gra, Invaild = null });
      grass.Add(new Affinity { Good = ro, Bad = po, Invaild = null });
      grass.Add(new Affinity { Good = null, Bad = fl, Invaild = null });
      grass.Add(new Affinity { Good = null, Bad = bu, Invaild = null });
      grass.Add(new Affinity { Good = null, Bad = dr, Invaild = null });
      grass.Add(new Affinity { Good = null, Bad = st, Invaild = null });
    }

    public void Ice()
    {
      ice.Add(new Affinity { Good = gra, Bad = fir, Invaild = null });
      ice.Add(new Affinity { Good = gro, Bad = wa, Invaild = null });
      ice.Add(new Affinity { Good = dr, Bad = ic, Invaild = null });
      ice.Add(new Affinity { Good = fl, Bad = st, Invaild = null });

    }

    public void Fighting()
    {
      fighting.Add(new Affinity { Good = no, Bad = po, Invaild = gh });
      fighting.Add(new Affinity { Good = ic, Bad = fl, Invaild = null });
      fighting.Add(new Affinity { Good = ro, Bad = bu, Invaild = null });
      fighting.Add(new Affinity { Good = da, Bad = ps, Invaild = null });
      fighting.Add(new Affinity { Good = st, Bad = fa, Invaild = null });
    }

    public void Poison()
    {
      poison.Add(new Affinity { Good = gra, Bad = po, Invaild = st });
      poison.Add(new Affinity { Good = fa, Bad = gro, Invaild = null });
      poison.Add(new Affinity { Good = null, Bad = ro, Invaild = null });
      poison.Add(new Affinity { Good = null, Bad = gh, Invaild = null });
    }

    public void Ground()
    {
      ground.Add(new Affinity { Good = fir, Bad = gra, Invaild = fl });
      ground.Add(new Affinity { Good = el, Bad = bu, Invaild = null });
      ground.Add(new Affinity { Good = po, Bad = null, Invaild = null });
      ground.Add(new Affinity { Good = ro, Bad = null, Invaild = null });
      ground.Add(new Affinity { Good = st, Bad = null, Invaild = null });
    }

    public void Flying()
    {
      flying.Add(new Affinity { Good = gra, Bad = el, Invaild = null });
      flying.Add(new Affinity { Good = fi, Bad = ro, Invaild = null });
      flying.Add(new Affinity { Good = bu, Bad = st, Invaild = null });
    }

    public void Psychic()
    {
      psychic.Add(new Affinity { Good = fi, Bad = ps, Invaild = null });
      psychic.Add(new Affinity { Good = po, Bad = st, Invaild = null });
    }

    public void Bug()
    {
      bug.Add(new Affinity { Good = gra, Bad = fir, Invaild = null });
      bug.Add(new Affinity { Good = ps, Bad = fi, Invaild = null });
      bug.Add(new Affinity { Good = da, Bad = po, Invaild = null });
      bug.Add(new Affinity { Good = null, Bad = fl, Invaild = null });
      bug.Add(new Affinity { Good = null, Bad = gh, Invaild = null });
      bug.Add(new Affinity { Good = null, Bad = st, Invaild = null });
      bug.Add(new Affinity { Good = null, Bad = fa, Invaild = null });
    }

    public void Rock()
    {
      rock.Add(new Affinity { Good = fir, Bad = fi, Invaild = null });
      rock.Add(new Affinity { Good = ic, Bad = gro, Invaild = null });
      rock.Add(new Affinity { Good = fl, Bad = st, Invaild = null });
      rock.Add(new Affinity { Good = bu, Bad = null, Invaild = null });
    }

    public void Ghost()
    {
      ghost.Add(new Affinity { Good = ps, Bad = da, Invaild = no });
      ghost.Add(new Affinity { Good = gh, Bad = null, Invaild = null });
    }

    public void Dragon()
    {
      dragon.Add(new Affinity { Good = dr, Bad = st, Invaild = fa });
    }

    public void Dark()
    {
      dark.Add(new Affinity { Good = ps, Bad = fi, Invaild = null });
      dark.Add(new Affinity { Good = gh, Bad = da, Invaild = null });
      dark.Add(new Affinity { Good = null, Bad = fa, Invaild = null });
    }

    public void Steel()
    {
      steel.Add(new Affinity { Good = fir, Bad = ic, Invaild = null });
      steel.Add(new Affinity { Good = el, Bad = ro, Invaild = null });
      steel.Add(new Affinity { Good = wa, Bad = fa, Invaild = null });
      steel.Add(new Affinity { Good = st, Bad = null, Invaild = null });
    }

    public void Fairy()
    {
      fairy.Add(new Affinity { Good = fi, Bad = fir, Invaild = null });
      fairy.Add(new Affinity { Good = dr, Bad = po, Invaild = null });
      fairy.Add(new Affinity { Good = da, Bad = st, Invaild = null });
    }


        /// <summary>
        /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
        /// 再作成する場合は、保存状態も指定されます。
        /// </summary>
        /// <param name="sender">
        /// イベントのソース (通常、<see cref="NavigationHelper"/>)
        /// </param>
        /// <param name="e">このページが最初に要求されたときに
        /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたナビゲーション パラメーターと、
        /// 前のセッションでこのページによって保存された状態の辞書を提供する
        /// イベント データ。ページに初めてアクセスするとき、状態は null になります。</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
          
            // TODO: 問題のドメインでサンプル データを置き換えるのに適したデータ モデルを作成します
           // var item = await SampleDataSource.GetItemAsync((String)e.NavigationParameter);
           // this.DefaultViewModel["Item"] = item;

            var p1 = new LastviewDataStore(ref datas);
            //      populateDatas();
            cvs1.Source = datas;

            try {
              if (e.NavigationParameter != null)
              {
                ResultBox.Text = e.NavigationParameter.ToString();

                string[] res = e.NavigationParameter.ToString().Split('\t');

                defenseBox1.SelectedIndex = int.Parse(res[1]);
                defenseBox2.SelectedIndex = int.Parse(res[2]);
                attackTechBox.SelectedIndex = int.Parse(res[3]);
                attackBox1.SelectedIndex = int.Parse(res[4]);
                attackBox2.SelectedIndex = int.Parse(res[5]);
                Check();
                //          string kekka = (string)defenseBox1.SelectedItem;
                string Sresult = result.ToString() + times;
                ResultBox.Text = Sresult;
                flag = 0;
              }
//              else ResultBox.Text = "???倍";
}
            catch (Exception ex) { }

//            previousWidth = adGrid1.Width;
//            previousHeight = adGrid1.Height;
//            previousMargin = adGrid1.Margin;
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


//          Normal();
          difencepreviousWidth = defenseBox1.Width;
          attackpreviousHeight = attackBox1.Width;
          gridpreviousWidth = checkGrid.Width;
          RegisterForShare();
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void CheckButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
          Check();
          if (bumButton.IsChecked == true) result /=  2;

//          string kekka = (string)defenseBox1.SelectedItem;
          Sresult = result.ToString() + times;
            ResultBox.Text = Sresult;
            CheckButton.IsEnabled = false;
//          string Result;

/*          if(result == 1)
          {
            Sresult = "等倍(×1)";
          }
          else if(result == 2)
          {
            Sresult = "こうかはばつぐん(×2）";
          }
          else if (result == 4)
          {
            Sresult = "こうかはばつぐん(×2）";
          }*/
          /*
          if (flag == 1)
          {

            flag = 0;
          }
          else if (flag == 0)
          {
//            ResultBox.Text = "";
          }
           * */
        }

        private void ResetButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
          result = 1;
          flag = 1;
           defenseBox1.SelectedIndex = 0;
           defenseBox2.SelectedIndex = 0;
           attackTechBox.SelectedIndex = 0;
           attackBox1.SelectedIndex = 0;
           attackBox2.SelectedIndex = 0;
           ResultBox.Text = "";
           CheckButton.IsEnabled = true;
           bumButton.IsChecked = false;
        }

        async private void storeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

          Flyout.ShowAttachedFlyout(sender as FrameworkElement);
/*          */

        }

        private void pageSelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          var s1 = new PopulateDatas();
          s1.populateDatas();

          if ((string)pageSelectBox.SelectedItem == sl)
          this.Frame.Navigate(typeof(BasicPage1),data);
        }

        private void favoriteCancelButton_Click(object sender, RoutedEventArgs e)
        {
          this.Flyout1.Hide();
        }

        async private void favoriteOkButton_Click(object sender, RoutedEventArgs e)
        {

          string comment = this.commentText.Text.Trim();
          if (comment.Length == 0)
            comment = md;

          //ローカルデータ
          String filePath = "StoreData.txt";
          // write file
          StorageFolder localFolder = ApplicationData.Current.LocalFolder;
          StorageFile file = await localFolder.CreateFileAsync(filePath,
              CreationCollisionOption.OpenIfExists);
//          data = "sampleData/" + (string)attackBox1.SelectedIndex + "/" + (string)attackBox2.SelectedIndex + "/" +
//            (string)attackTechBox.SelectedIndex + "/" + (string)defenseBox1.SelectedIndex + "/" + (string)defenseBox2.SelectedIndex + "\n";
          data = comment + "\t" + defenseBox1.SelectedIndex + "\t" + defenseBox2.SelectedIndex + "\t" + attackTechBox.SelectedIndex + "\t"
              + attackBox1.SelectedIndex + "\t" + attackBox2.SelectedIndex + "\t" + DateTime.Now + "\n";
          await FileIO.AppendTextAsync(file, data);

          //ローミングデータ
          /*StorageFolder roamingFolder = ApplicationData.Current.LocalFolder;
          StorageFile sampleFile = await roamingFolder.CreateFileAsync(filePath,
            CreationCollisionOption.OpenIfExists);
          await FileIO.AppendTextAsync(sampleFile, data);
          */
          var s1 = new PopulateDatas();
          s1.populateDatas();
          this.Flyout1.Hide();
        }

        private void RegisterForShare()
        {
          DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
          dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.ShareTextHandler);
        }

        private void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
          var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();

          string cr = resourceLoader.GetString("checkresult");
          string rs = resourceLoader.GetString("resultsend");
          string of = resourceLoader.GetString("Offence");
          string de = resourceLoader.GetString("Defence");
          string ay1 = resourceLoader.GetString("affinityresult1");
          string ay2 = resourceLoader.GetString("affinityresult2");
          string And = resourceLoader.GetString("_And");


          DataRequest request = e.Request;
//          request.Data.Properties.ApplicationName = "タイプ相性チェッカー";
          request.Data.Properties.Title = cr;
          request.Data.Properties.Description = rs;
          request.Data.SetText(of + ":[ " + (string)defenseBox1.SelectedItem + " & " + (string)defenseBox2.SelectedItem + " ]" + " VS "+ de +":[ " + (string)attackTechBox.SelectedItem
            + And +" ( " + (string)attackBox1.SelectedItem + " & " + (string)attackBox2.SelectedItem + " ) ] " + ay2  + Sresult
            + "  \n #タイプ相性チェッカー_for_XY #pokemon ");
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

//http://apps.microsoft.com/webpdp/app/4598cebe-5510-440a-856b-fb83e4756c19
    }
}
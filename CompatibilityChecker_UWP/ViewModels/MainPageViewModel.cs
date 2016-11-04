using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CompatibilityChecker_UWP.ViewModels
{
  public class MainPageViewModel : Common.BindableBase
  {
    private Models.MainPageModel Model { get; } = Models.MainPageModel.Instance;


    public MainPageViewModel()
    {
      this.Model.PropertyChanged += this.MainPageViewModel_PropatyChanged;
      //this.TweetInfos = new ReadOnlyObservableCollection<TweetInfo>(this.Model.TweetInfoManager.TweetInfos);
      //this.TweetInfos = this.Model.TweetInfoManager.getTweetInfos();
    }

    private void MainPageViewModel_PropatyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged(e.PropertyName);
    }


    public string DefenseBox1
    {
      get { return this.Model.DefenseBox1; }
      set { this.Model.DefenseBox1 = value; }
    }

    public string DefenseBox2
    {
      get { return this.Model.DefenseBox2; }
      set { this.Model.DefenseBox2 = value; }
    }

    public string ResultBlock
    {
      get { return this.Model.ResultBlock; }
      set { this.Model.ResultBlock = value; }
    }

    public string AttackBox1
    {
      get { return this.Model.AttackBox1; }
      set { this.Model.AttackBox1 = value; }
    }


    public string AttackBox2
    {
      get { return this.Model.AttackBox2; }
      set { this.Model.AttackBox2 = value; }
    }

    public string AttackTechBox
    {
      get { return this.Model.AttackTechBox; }
      set { this.Model.AttackTechBox = value; }
    }

    public bool BumToggle
    {
      get { return this.Model.BumToggle; }
      set { this.Model.BumToggle = value; }
    }

    public string resultBlock()
    {
      return this.Model.ResultBlock;
    }

    public void Check()
    {
      this.Model.Check();
    }

    public void Clear()
    {
      this.Model.Clear();
    }


  }
}

using CompatibilityChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CompatibilityChecker_UWP.Models
{
  public class MainPageModel : Common.BindableBase
  {


    string cc; string sl; string md; string times; double result = 1;

    string no; string fir; string wa; string el; string gra; string ic;
    string fi; string po; string gro; string fl; string ps; string bu;
    string ro; string gh; string dr; string da; string st; string fa;

    public static MainPageModel Instance { get; } = new MainPageModel();

    public CompatibilityManager ComboBoxManager { get; } = new CompatibilityManager();

    public List<Affinity> normal { get; set; } = new List<Affinity>();
    public List<Affinity> fire = new List<Affinity>();

    public List<Affinity> water = new List<Affinity>();
    public List<Affinity> electric = new List<Affinity>();
    public List<Affinity> grass = new List<Affinity>();
    public List<Affinity> ice = new List<Affinity>();
    public List<Affinity> fighting = new List<Affinity>();
    public List<Affinity> poison = new List<Affinity>();
    public List<Affinity> ground = new List<Affinity>();
    public List<Affinity> flying = new List<Affinity>();
    public List<Affinity> psychic = new List<Affinity>();
    public List<Affinity> bug = new List<Affinity>();
    public List<Affinity> rock = new List<Affinity>();
    public List<Affinity> ghost = new List<Affinity>();
    public List<Affinity> dragon = new List<Affinity>();
    public List<Affinity> dark = new List<Affinity>();
    public List<Affinity> steel = new List<Affinity>();
    public List<Affinity> fairy = new List<Affinity>();

    public MainPageModel()
    {
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
      
    }

    private string defenseBox1;
    public string DefenseBox1
    {
      get { return this.defenseBox1; }
      set { this.SetProperty(ref this.defenseBox1, value); }
    }

    private string defenseBox2;
    public string DefenseBox2
    {
      get { return this.defenseBox2; }
      set { this.SetProperty(ref this.defenseBox2, value); }
    }

    private string attackTechBox;
    public string AttackTechBox
    {
      get { return this.attackTechBox; }
      set { this.SetProperty(ref this.attackTechBox, value); }
    }

    private string attackBox1;
    public string AttackBox1
    {
      get { return this.attackBox1; }
      set { this.SetProperty(ref this.attackBox1, value); }
    }

    private string attackBox2;
    public string AttackBox2
    {
      get { return this.attackBox2; }
      set { this.SetProperty(ref this.attackBox2, value); }
    }

    private string resultBlock;
    public string ResultBlock
    {
      get { return this.resultBlock; }
      set { this.SetProperty(ref this.resultBlock, value); }
    }

    private bool bumToggle;
    public bool BumToggle
    {
      get { return this.bumToggle; }
      set { this.SetProperty(ref this.bumToggle, value); }
    }

    public void Check()
    {
      //this.ResultBlock = this.DefenseBox1 + this.DefenseBox2 + this.AttackTechBox + this.AttackBox1 + this.AttackBox2;
      result = 1;
      CheckType(normal, no);
      CheckType(fire, fir);
      CheckType(water, wa);
      CheckType(electric, el);
      CheckType(grass, gra);
      CheckType(ice, ic);
      CheckType(fighting, fi);
      CheckType(poison, po);
      CheckType(ground, gro);
      CheckType(flying, fl);
      CheckType(psychic, ps);
      CheckType(bug, bu);
      CheckType(rock, ro);
      CheckType(ghost, gh);
      CheckType(dragon, dr);
      CheckType(dark, da);
      CheckType(steel, st);
      CheckType(fairy, fa);


      if (BumToggle == true) result /= 2;

      this.ResultBlock = result.ToString();
    }


    public void Clear()
    {
      this.ResultBlock = "";
    }

    public void CheckType(List<Affinity> Type, string type)
    {

      if (AttackBox1 == type)
      {

        if (AttackBox1 == AttackTechBox || AttackBox2 == AttackTechBox)
        {
          result *= 1.5;

          for (int i = 0; i < Type.Count; i++)
          {

            if (DefenseBox1 == Type[i].Good)
            {
              result *= 2;
            }
            else result *= 1;

            if (DefenseBox2 == Type[i].Good && DefenseBox1 != Type[i].Good)
            {
              result *= 2;
            }
            else result *= 1;


            if (DefenseBox1 == Type[i].Bad)
            {
              result /= 2;
            }
            else result *= 1;

            if (DefenseBox2 == Type[i].Bad && DefenseBox1 != Type[i].Bad)
            {
              result /= 2;
            }
            else result *= 1;

            if (DefenseBox1 == Type[i].Invaild || DefenseBox2 == Type[i].Invaild)
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

            if (DefenseBox1 == Type[i].Good)
            {
              result *= 2;
            }
            else result *= 1;

            if (DefenseBox2 == Type[i].Good && DefenseBox1 != Type[i].Good)
            {
              result *= 2;
            }
            else result *= 1;


            if (DefenseBox1 == Type[i].Bad)
            {
              result /= 2;
            }
            else result *= 1;

            if (DefenseBox2 == Type[i].Bad && DefenseBox1 != Type[i].Bad)
            {
              result /= 2;
            }
            else result *= 1;

            if (DefenseBox1 == Type[i].Invaild || DefenseBox2 == Type[i].Invaild)
            {
              result *= 0;
            }

          }
        }
      }

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


  }




  public class CompatibilityManager : Common.BindableBase
  {

    string cc; string sl; string md; string times;

    string no; string fir; string wa; string el; string gra; string ic;
    string fi; string po; string gro; string fl; string ps; string bu;
    string ro; string gh; string dr; string da; string st; string fa;

    public CompatibilityManager()
    {
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
    }

    private string defenseBox1;
    public string DefenseBox1
    {
      get { return this.defenseBox1; }
      set { this.SetProperty(ref this.defenseBox1, value); }
    }

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

  }

  public class ComboBoxManager : Common.BindableBase
  {
    string cc;  string sl;  string md;  string times;

    string no;  string fir; string wa;  string el;  string gra; string ic;
    string fi;  string po;  string gro; string fl;  string ps;  string bu;
    string ro;  string gh;  string dr;  string da;  string st;  string fa;

    public ComboBoxManager()
    {
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

      //setDefenseBox1();
    }


    public ComboBox DefenseBox1 { get; set; }

    public ComboBox defenseBox2 { get; set; }

    public void setDefenseBox1()
    {
      DefenseBox1.ItemsSource = new string[] { };
      /*
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
      */
    }


    /*= new ComboBox()
  {
    new ComboBox {"aaaa","aaaa" }

  };*/


  }



}

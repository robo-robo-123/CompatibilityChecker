using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompatibilityChecker
{
  public class Affinity
  {
    private string good;

    public string Good
    {
      get { return good; }
      set { good = value; }
    }

    private string bad;

    public string Bad
    {
      get { return bad; }
      set { bad = value; }
    }

    private string invaild;

    public string Invaild
    {
      get { return invaild; }
      set { invaild = value; }
    }

  }

}

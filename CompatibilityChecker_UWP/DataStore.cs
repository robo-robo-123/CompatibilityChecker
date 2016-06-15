using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Collections.ObjectModel;

namespace CompatibilityChecker
{
  class DataStore
  {
  }

  class LastviewDataStore
  {
    static List<string> stock;
    public LastviewDataStore(List<string> LastView)
    {
      stock = LastView;
    }
    public LastviewDataStore(ref List<string> LastView)
    {
      LastView = stock;
    }
  }

  class MemoStore
  {
//      ObservableCollection<string> memo = new ObservableCollection<string>();
    List<ResultMemo> memo = new List<ResultMemo>();
    public MemoStore(List<ResultMemo> LastView)
    {
      memo = LastView;
    }
    public MemoStore(ref List<ResultMemo> LastView)
    {
      LastView = memo;
    }
  }




  class PopulateDatas
  {
    async public void populateDatas()
    {
      List<string> datas = new List<string>();
      List<ResultMemo> memo = new List<ResultMemo>();
      ObservableCollection<ResultMemo> memo2 = new ObservableCollection<ResultMemo>();
      String filePath = "StoreData.txt";
      // write file
      StorageFolder localFolder = ApplicationData.Current.LocalFolder;
      try
      {
        StorageFile file = await localFolder.GetFileAsync(filePath);
        IList<String> strList = await FileIO.ReadLinesAsync(file);
        foreach (String str in strList)
        {
          string msg = str;

          datas.Add(str);


//          memo.Add(str);
        }

        
/*        for(int i=0; i<datas.Count; i++)
        {
          string msg ;
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


        }*/

        var p1 = new LastviewDataStore(datas);
//        var p2 = new MemoStore(memo);
      }
      catch (Exception ex)
      {
        // ファイル無し
//        datas.Add("null");
        var p1 = new LastviewDataStore(datas);
      }
    }

  }

}

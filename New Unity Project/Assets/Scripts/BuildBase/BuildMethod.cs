using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface BuildMethod
{
    Dictionary<string, int> listRes { get; set; }

    int price { get; set; }
    string nameBuild { get; }

    public bool Build(Dictionary<string, int> listPlr, int gold);
}
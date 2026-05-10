using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _26_0510LINQ常用扩展方法
{
     class Dog
    {
        public string NickName;

        public int Age;

        public override string ToString()
        {
            return $"xName={NickName},Age={Age}";
        }
    }
}

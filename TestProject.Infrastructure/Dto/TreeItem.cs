using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Infrastructure
{

    /// <summary>
    /// 树结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}

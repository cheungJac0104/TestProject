using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject.Infrastructure
{
    public static class ListHelper
    {

        /// <summary>
        /// 把list 转为tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="collection">操作对象</param>
        /// <param name="idSelector">id 对象</param>
        /// <param name="parentIdSelector">父级id对象</param>
        /// <param name="rootId"></param>
        /// <returns></returns>
        public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
        this IEnumerable<T> collection,
        Func<T, K> idSelector,
        Func<T, K> parentIdSelector,
        K rootId = default(K))
        {

            //var root = collection.Where(u =>
            // {
            //     var selector = parentIdSelector(u);
            //     return (rootId == null && selector.Equals("0"))
            //     || (rootId != null && rootId.Equals(selector));
            // });

            foreach (var c in collection.Where(u =>
            {
                var selector = parentIdSelector(u);
                return (rootId == null && selector.Equals("0"))
                || (rootId != null && rootId.Equals(selector));
            }))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = collection.GenerateTree(idSelector, parentIdSelector, idSelector(c))
                };
            }
        }
    }
}

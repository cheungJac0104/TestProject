using System.Data;
using System.Dynamic;

namespace TestProject.Helper
{
    public static class DataTableExtensions
    {
        public static List<dynamic> ToDynamicList(this DataTable dt)
        {
            var _dynamicDataTable = new List<dynamic>();
            //Loop Row
            int _rowIndex = 1;
            foreach (DataRow _row in dt.Rows)
            {
                dynamic _obj = new ExpandoObject();
                _dynamicDataTable.Add(_obj);

                var _dicHeader = (IDictionary<string, object>)_obj;
                _dicHeader["rowIndex"] = _rowIndex;

                //Loop Column
                foreach (DataColumn column in dt.Columns)
                { 
                    var _dic = (IDictionary<string, object>)_obj;
                    Console.WriteLine(column.DataType);
                    _dic[column.ColumnName] = _row[column];
                }

                _rowIndex++;

            }
            return _dynamicDataTable;
        }
 

    }




}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpdateDataWithDynamicLinq.Common.Extensions;
using UpdateDataWithDynamicLinq.DB;

namespace UpdateDataWithDynamicLinq.Common
{
    public class TestClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableClassNameSpace">exmple:"MyProject.Models.EntityModels"</param>
        /// <param name="Column"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void UpdateRecord(string table, string tableClassNameSpace, string Column, int key, string value)
        {

            var tableName = table;
            //var tableClassNameSpace = "MyProject.Models.EntityModels";

            using (var dbContext = new MyContext())
            {
                var tableClassName = $"{tableClassNameSpace}.{tableName}";
                Type dynamicTableType = Type.GetType(tableClassName);
                var dynamicTable = DBContextExtensions.Set(dbContext, dynamicTableType);      // DbSet

                var records = dynamicTable
                     .AsQueryable().Where("Id==@0  ", key)
                     .ToDynamicList()
                     .FirstOrDefault();
                PropertyInfo propertyInfo = records.GetType().GetProperty(Column);

                propertyInfo.SetValue(records, value, null);

                dbContext.SaveChanges();
            }



        }

        

    }
}

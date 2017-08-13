using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShopEntity.Handler
{
    public struct JqGridResult
    {
        public int page;
        public int total;
        public int records;
        public JqGridRow[] rows;
    }
    public struct JqGridRow
    {
        public int id;
        public string[] cell;
    }
}
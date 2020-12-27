using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class HANGHOA
    {
        shopeeDB db = null;
        public HANGHOA()
        {
            db = new shopeeDB();
        }

        public List<Menu> ListByMAHANGHOA(int groupID)
        {
            return db.Menus.ToList();
        }
    }
}

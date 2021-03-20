using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_Shop.Controller
{
    public interface IMenu:IEnumerable<MenuItem>
    {
        public void Show();
    }
    
}

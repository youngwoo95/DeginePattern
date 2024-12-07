using DesignPattern.DesignPatterns.MVC.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DesignPatterns.MVC.Views
{
    public interface IMainView
    {
        int Id { get; set; }
        string Name { get; set; }
        string Sex { get; set; }
        int Age { get; set; }

        IEnumerable ItemSource { get; set; }

        void SetController(MainController controller);
    }
}

using DesignPattern.DesignPatterns.Models;
using DesignPattern.DesignPatterns.MVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DesignPatterns.MVC.Controllers
{
    public class MainController
    {
        private readonly IMainView _view;
        private readonly IPersonRepository _personrepository;

        private Person GetPersonFromView()
        {
            return new Person
            {
                Id = _view.Id,
                Name = _view.Name,
                Sex = _view.Sex,
                Age = _view.Age
            };
        }

        private bool IsValidSave(Person person)
        {
            if (person.Id <= 0)
                return false;

            if(String.IsNullOrEmpty(person.Name))
                return false;

            if(String.IsNullOrEmpty(person.Sex))
                return false;
            
            if (person.Age <= 0)
                return false;

            return true;
        }

        private void LoadPerson(Person? person = null)
        {
            _view.Id = person?.Id ?? 0;
            _view.Name = person?.Name ?? "";
            _view.Sex = person?.Sex ?? "";
            _view.Age = person?.Age ?? 0;
        }



        public MainController(IMainView view, IPersonRepository personrepository)
        {
            this._view = view;
            this._personrepository = personrepository;
            this._view.SetController(this);
        }
     
        public bool Save()
        {
            Person person = GetPersonFromView();
            if(!IsValidSave(person))
            {
                return false;
            }
         
            return _personrepository.SaveOne(person);
        }

        public void Cancel()
        {
            LoadPerson();
        }

        public void Display()
        {
            _view.ItemSource = _personrepository.GetAll()!;
        }

        public bool Delete()
        {
            return _personrepository.DeleteOne(_view.Id);
        }

        internal void LoadPerson(object dataContext)
        {
            LoadPerson(dataContext as Person);
        }
    }
}

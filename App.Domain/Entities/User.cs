using System;
using APPTESTE.App.Shared.Entity;
using Flunt.Validations;

namespace APPTESTE.App.Domain.Entities
{
    public class User : Entity
    {
        public User(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
            Active = true;

            AddNotifications(new Contract()
                .IsBetween(UserName.Length,5,50,"UserName","O Nome de usuario precisa ter entre 5 e 50 caractéres")
                .IsBetween(PassWord.Length,8,60,"PassWord","A senha precisar ter no minimo 8 e no maximo 60 caracteres")
            );
        }

        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public bool Active { get; private set; }
    }
}
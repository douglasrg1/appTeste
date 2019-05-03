using System;
using App.Shared.Entity;
using App.Shared.Utils.EncriptyString;
using Flunt.Validations;

namespace App.Domain.Entities
{
    public class User : Entity
    {
        protected User()
        {
            
        }
        public User(string userName, string passWord)
        {
            UserName = userName;
            PassWord = EncriptPassword.EncriptPasswordMd5(passWord);
            Active = true;

            AddNotifications(new Contract()
                .IsBetween(UserName.Length,5,50,"UserName","O Nome de usuario precisa ter entre 5 e 50 caractéres")
                .IsBetween(passWord.Length,8,60,"PassWord","A senha precisar ter no minimo 8 e no maximo 60 caracteres")
            );
        }

        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public bool Active { get; private set; }


        public bool Activate()=> Active = true;

        public bool Descativate()=> Active = false;

    }
}
using System;
using App.Domain.Commands;
using App.Domain.Commands.CustomerCommands;
using App.Domain.Entities;
using App.Domain.Repositories;
using App.Domain.Services;
using App.Domain.ValueObjects;
using App.Shared.Commands;
using Flunt.Notifications;

namespace App.Domain.Handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailSerice;
        public CustomerCommandHandler(ICustomerRepository customerRepository,IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailSerice = emailService;
        }
        public ICommandResult Handler(RegisterCustomerCommand command)
        {
            if(_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Cpf","O cpf já está cadastrado na nossa base de dados");
                return null;
            }

            //gerar VOS
            var name = new Name(command.FirstName,command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var user = new User(command.Username,command.Password);

            //gerar entidade
            var customer = new Customer(name,document,DateTime.Now,email,user);

            //adicionando as notificaçoes
            
            AddNotifications(customer.Notifications);

            //persistir no banco

            if(Invalid)
                return new CommandResult(false,"Os seguites campos não estão preenchidos corretamente",
                    Notifications);

            
            _customerRepository.Save(customer);

            //enviar email boas vindas
            _emailSerice.Send(customer.ToString(),email.Address,"email boas vindas","bem vindo ao sistema");

            //retorna dados para o usuario
            return new CommandResult(true,"Dados adicionado com sucesso",
                new {Nome = customer.Name.ToString(), Id = customer.Id});


            
        }
    }
}
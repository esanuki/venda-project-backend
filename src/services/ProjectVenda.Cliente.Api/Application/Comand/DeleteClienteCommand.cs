using ProjectVenda.Core.DomainObjects;
using System;

namespace ProjectVenda.Cliente.Api.Application.Comand
{
    public class DeleteClienteCommand : Command
    {
        public Guid Id { get; set; }

        public DeleteClienteCommand(Guid id)
        {
            Id = id;
        }
    }
}

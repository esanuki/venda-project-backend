using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Produto.Api.Application.Queries.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProjectVenda.Produto.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoController : MainController
    {
        private readonly IProdutoQueries _produtoQueries;

        public ProdutoController(
            INotificator notificator, 
            IProdutoQueries produtoQueries) : base(notificator)
        {
            _produtoQueries = produtoQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _produtoQueries.GetAll();

            if (result is null) AddError("Nenhum resultado encontrado");

            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _produtoQueries.GetById(id);

            if (result is null) AddError("Nenhum resultado encontrado");

            return CustomResponse(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MediatR;
using api.Domain.Entity;
using api.Repository;
using api.Domain.Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Util;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository _repository;

        public CharactersController(IMediator mediator, IRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
 
        [HttpPost("favorite/{id}")]
        public async Task<ActionResult> CharactersAddFav(int id)
        {
            try
            {
                var response = await _mediator.Send(new CharactersAddCommand(){Id = id});
                return Ok(response);
            }
            catch (ArgumentException err)
            {
                return StatusCode(400, new DefaultResponse(err.Message, 400));
            }
            catch (Exception err)
            {
                Console.WriteLine($"ERRO {err.Message}");
                return StatusCode(500, new DefaultResponse("Erro interno. Tente novamente.", 500));
            }
        }

        [HttpDelete("favorite/{id}")]
        public async Task<ActionResult> CharactersDeleteFav(int id)
        {
            try
            {
                var response = await _mediator.Send(new CharactersDeleteFavCommand(){Id = id});
                return Ok(response);
            }
            catch (ArgumentException err)
            {
                return StatusCode(400, new DefaultResponse(err.Message, 400));
            }
            catch (Exception err)
            {
                Console.WriteLine($"ERRO {err.Message}");
                return StatusCode(500, new DefaultResponse("Erro interno. Tente novamente."));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> CharactersDelete(int id)
        {
            try
            {
                var response = await _mediator.Send(new CharactersDeleteCommand(){Id = id});
                return Ok(response);
            }
            catch (ArgumentException err)
            {
                return StatusCode(400, new DefaultResponse(err.Message, 400));
            }
            catch (Exception err)
            {
                Console.WriteLine($"ERRO {err.Message}");
                return StatusCode(500, new DefaultResponse("Erro interno. Tente novamente.", 500));
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> Characters(int offSet, string? orderBy = "", string? nameStartsWith = "", int limit = 20)
        {
            CharacterFilter filter;

            try
            {
                filter = new CharacterFilter()
                {
                    OrderBy = orderBy!,
                    NameStartsWith = nameStartsWith!,
                    OffSet = offSet,
                    Limit = limit
                };

                var response = await _repository.GetAll(filter);
                return Ok(response);
            }
            catch (ArgumentException err)
            {
                return StatusCode(400, new DefaultResponse(err.Message, 400));
            }
            catch (Exception err)
            {
                Console.WriteLine($"ERRO {err.Message}");
                return StatusCode(500, new DefaultResponse("Erro interno. Tente novamente.", 500));
            }
        }
    }
}
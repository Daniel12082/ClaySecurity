using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ClienteController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get11()
        {
            var Clientes = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(Clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (Cliente == null)
                return NotFound(new ApiResponse(404, "El Cliente solicitado no existe."));

            return _mapper.Map<ClienteDto>(Cliente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
        {
            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();
            if (Cliente == null)
                return BadRequest(new ApiResponse(400));

            ClienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new { id = ClienteDto.Id }, ClienteDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto ClienteDto)
        {
            if (ClienteDto == null)
                return NotFound(new ApiResponse(404, "El Cliente solicitado no existe."));

            var ClienteBd = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (ClienteBd == null)
                return NotFound(new ApiResponse(404, "El Cliente solicitado no existe."));

            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Update(Cliente);
            await _unitOfWork.SaveAsync();
            return ClienteDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (Cliente == null)
                return NotFound(new ApiResponse(404, "El Cliente solicitado no existe."));

            _unitOfWork.Clientes.Delete(Cliente);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
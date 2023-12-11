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
    public class TipoPersonaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get11()
        {
            var TipoPersonas = await _unitOfWork.TipoPersonas.GetAllAsync();
            return _mapper.Map<List<TipoPersonaDto>>(TipoPersonas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Get(int id)
        {
            var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
            if (TipoPersona == null)
                return NotFound(new ApiResponse(404, "El TipoPersona solicitado no existe."));

            return _mapper.Map<TipoPersonaDto>(TipoPersona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TipoPersonas.Add(TipoPersona);
            await _unitOfWork.SaveAsync();
            if (TipoPersona == null)
                return BadRequest(new ApiResponse(400));

            TipoPersonaDto.Id = TipoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto TipoPersonaDto)
        {
            if (TipoPersonaDto == null)
                return NotFound(new ApiResponse(404, "El TipoPersona solicitado no existe."));

            var TipoPersonaBd = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
            if (TipoPersonaBd == null)
                return NotFound(new ApiResponse(404, "El TipoPersona solicitado no existe."));

            var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TipoPersonas.Update(TipoPersona);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
            if (TipoPersona == null)
                return NotFound(new ApiResponse(404, "El TipoPersona solicitado no existe."));

            _unitOfWork.TipoPersonas.Delete(TipoPersona);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
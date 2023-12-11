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
    public class TipoContactoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoContactoDto>>> Get11()
        {
            var TipoContactos = await _unitOfWork.TipoContactos.GetAllAsync();
            return _mapper.Map<List<TipoContactoDto>>(TipoContactos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoContactoDto>> Get(int id)
        {
            var TipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
            if (TipoContacto == null)
                return NotFound(new ApiResponse(404, "El TipoContacto solicitado no existe."));

            return _mapper.Map<TipoContactoDto>(TipoContacto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContacto>> Post(TipoContactoDto TipoContactoDto)
        {
            var TipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);
            _unitOfWork.TipoContactos.Add(TipoContacto);
            await _unitOfWork.SaveAsync();
            if (TipoContacto == null)
                return BadRequest(new ApiResponse(400));

            TipoContactoDto.Id = TipoContacto.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoContactoDto.Id }, TipoContactoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody] TipoContactoDto TipoContactoDto)
        {
            if (TipoContactoDto == null)
                return NotFound(new ApiResponse(404, "El TipoContacto solicitado no existe."));

            var TipoContactoBd = await _unitOfWork.TipoContactos.GetByIdAsync(id);
            if (TipoContactoBd == null)
                return NotFound(new ApiResponse(404, "El TipoContacto solicitado no existe."));

            var TipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);
            _unitOfWork.TipoContactos.Update(TipoContacto);
            await _unitOfWork.SaveAsync();
            return TipoContactoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
            if (TipoContacto == null)
                return NotFound(new ApiResponse(404, "El TipoContacto solicitado no existe."));

            _unitOfWork.TipoContactos.Delete(TipoContacto);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
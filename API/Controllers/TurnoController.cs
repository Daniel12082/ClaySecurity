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
    public class TurnoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> Get11()
        {
            var Turnos = await _unitOfWork.Turnos.GetAllAsync();
            return _mapper.Map<List<TurnoDto>>(Turnos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TurnoDto>> Get(int id)
        {
            var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (Turno == null)
                return NotFound(new ApiResponse(404, "El Turno solicitado no existe."));

            return _mapper.Map<TurnoDto>(Turno);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Turno>> Post(TurnoDto TurnoDto)
        {
            var Turno = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Add(Turno);
            await _unitOfWork.SaveAsync();
            if (Turno == null)
                return BadRequest(new ApiResponse(400));

            TurnoDto.Id = Turno.Id;
            return CreatedAtAction(nameof(Post), new { id = TurnoDto.Id }, TurnoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody] TurnoDto TurnoDto)
        {
            if (TurnoDto == null)
                return NotFound(new ApiResponse(404, "El Turno solicitado no existe."));

            var TurnoBd = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (TurnoBd == null)
                return NotFound(new ApiResponse(404, "El Turno solicitado no existe."));

            var Turno = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Update(Turno);
            await _unitOfWork.SaveAsync();
            return TurnoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            if (Turno == null)
                return NotFound(new ApiResponse(404, "El Turno solicitado no existe."));

            _unitOfWork.Turnos.Delete(Turno);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
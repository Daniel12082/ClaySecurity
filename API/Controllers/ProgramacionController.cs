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
    public class ProgramacionController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get11()
        {
            var Programacions = await _unitOfWork.Programacions.GetAllAsync();
            return _mapper.Map<List<ProgramacionDto>>(Programacions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProgramacionDto>> Get(int id)
        {
            var Programacion = await _unitOfWork.Programacions.GetByIdAsync(id);
            if (Programacion == null)
                return NotFound(new ApiResponse(404, "El Programacion solicitado no existe."));

            return _mapper.Map<ProgramacionDto>(Programacion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Programacion>> Post(ProgramacionDto ProgramacionDto)
        {
            var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programacions.Add(Programacion);
            await _unitOfWork.SaveAsync();
            if (Programacion == null)
                return BadRequest(new ApiResponse(400));

            ProgramacionDto.Id = Programacion.Id;
            return CreatedAtAction(nameof(Post), new { id = ProgramacionDto.Id }, ProgramacionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody] ProgramacionDto ProgramacionDto)
        {
            if (ProgramacionDto == null)
                return NotFound(new ApiResponse(404, "El Programacion solicitado no existe."));

            var ProgramacionBd = await _unitOfWork.Programacions.GetByIdAsync(id);
            if (ProgramacionBd == null)
                return NotFound(new ApiResponse(404, "El Programacion solicitado no existe."));

            var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programacions.Update(Programacion);
            await _unitOfWork.SaveAsync();
            return ProgramacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Programacion = await _unitOfWork.Programacions.GetByIdAsync(id);
            if (Programacion == null)
                return NotFound(new ApiResponse(404, "El Programacion solicitado no existe."));

            _unitOfWork.Programacions.Delete(Programacion);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
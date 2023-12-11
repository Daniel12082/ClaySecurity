using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpleadoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get11()
        {
            var Empleados = await _unitOfWork.Empleado.GetAllAsync();
            return _mapper.Map<List<EmpleadoDto>>(Empleados);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Get(int id)
        {
            var Empleado = await _unitOfWork.Empleado.GetByIdAsync(id);
            if (Empleado == null)
                return NotFound(new ApiResponse(404, "El Empleado solicitado no existe."));

            return _mapper.Map<EmpleadoDto>(Empleado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
        {
            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleado.Add(Empleado);
            await _unitOfWork.SaveAsync();
            if (Empleado == null)
                return BadRequest(new ApiResponse(400));

            EmpleadoDto.Id = Empleado.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, EmpleadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto EmpleadoDto)
        {
            if (EmpleadoDto == null)
                return NotFound(new ApiResponse(404, "El Empleado solicitado no existe."));

            var EmpleadoBd = await _unitOfWork.Empleado.GetByIdAsync(id);
            if (EmpleadoBd == null)
                return NotFound(new ApiResponse(404, "El Empleado solicitado no existe."));

            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleado.Update(Empleado);
            await _unitOfWork.SaveAsync();
            return EmpleadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Empleado = await _unitOfWork.Empleado.GetByIdAsync(id);
            if (Empleado == null)
                return NotFound(new ApiResponse(404, "El Empleado solicitado no existe."));

            _unitOfWork.Empleado.Delete(Empleado);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
        [HttpGet("GetAllEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAllEmpleado()
        {
            var Empleado = await _unitOfWork.Empleado.GetAllEmpleados();
            return _mapper.Map<List<EmpleadoDto>>(Empleado);
        }
        [HttpGet("GetEmpleadoVigilant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetEmpleadoVigilant()
        {
            var Empleado = await _unitOfWork.Empleado.GetEmpleadosVigilant();
            return _mapper.Map<List<EmpleadoDto>>(Empleado);
        }
    }
}
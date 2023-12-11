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
    public class PersonaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get11()
        {
            var Personas = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(Personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (Persona == null)
                return NotFound(new ApiResponse(404, "El Persona solicitado no existe."));

            return _mapper.Map<PersonaDto>(Persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
        {
            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Add(Persona);
            await _unitOfWork.SaveAsync();
            if (Persona == null)
                return BadRequest(new ApiResponse(400));

            PersonaDto.Id = Persona.Id;
            return CreatedAtAction(nameof(Post), new { id = PersonaDto.Id }, PersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto PersonaDto)
        {
            if (PersonaDto == null)
                return NotFound(new ApiResponse(404, "El Persona solicitado no existe."));

            var PersonaBd = await _unitOfWork.Personas.GetByIdAsync(id);
            if (PersonaBd == null)
                return NotFound(new ApiResponse(404, "El Persona solicitado no existe."));

            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Update(Persona);
            await _unitOfWork.SaveAsync();
            return PersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (Persona == null)
                return NotFound(new ApiResponse(404, "El Persona solicitado no existe."));

            _unitOfWork.Personas.Delete(Persona);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
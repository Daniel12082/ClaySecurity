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
    public class DirPersonaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DirPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DirPersonaDto>>> Get11()
        {
            var DirPersonas = await _unitOfWork.DirPersonas.GetAllAsync();
            return _mapper.Map<List<DirPersonaDto>>(DirPersonas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DirPersonaDto>> Get(int id)
        {
            var DirPersona = await _unitOfWork.DirPersonas.GetByIdAsync(id);
            if (DirPersona == null)
                return NotFound(new ApiResponse(404, "El DirPersona solicitado no existe."));

            return _mapper.Map<DirPersonaDto>(DirPersona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DirPersona>> Post(DirPersonaDto DirPersonaDto)
        {
            var DirPersona = _mapper.Map<DirPersona>(DirPersonaDto);
            _unitOfWork.DirPersonas.Add(DirPersona);
            await _unitOfWork.SaveAsync();
            if (DirPersona == null)
                return BadRequest(new ApiResponse(400));

            DirPersonaDto.Id = DirPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = DirPersonaDto.Id }, DirPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DirPersonaDto>> Put(int id, [FromBody] DirPersonaDto DirPersonaDto)
        {
            if (DirPersonaDto == null)
                return NotFound(new ApiResponse(404, "El DirPersona solicitado no existe."));

            var DirPersonaBd = await _unitOfWork.DirPersonas.GetByIdAsync(id);
            if (DirPersonaBd == null)
                return NotFound(new ApiResponse(404, "El DirPersona solicitado no existe."));

            var DirPersona = _mapper.Map<DirPersona>(DirPersonaDto);
            _unitOfWork.DirPersonas.Update(DirPersona);
            await _unitOfWork.SaveAsync();
            return DirPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DirPersona = await _unitOfWork.DirPersonas.GetByIdAsync(id);
            if (DirPersona == null)
                return NotFound(new ApiResponse(404, "El DirPersona solicitado no existe."));

            _unitOfWork.DirPersonas.Delete(DirPersona);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
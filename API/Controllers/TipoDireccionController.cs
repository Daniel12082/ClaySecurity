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
    public class TipoDireccionController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoDireccionDto>>> Get11()
        {
            var TipoDireccions = await _unitOfWork.TipoDireccions.GetAllAsync();
            return _mapper.Map<List<TipoDireccionDto>>(TipoDireccions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDireccionDto>> Get(int id)
        {
            var TipoDireccion = await _unitOfWork.TipoDireccions.GetByIdAsync(id);
            if (TipoDireccion == null)
                return NotFound(new ApiResponse(404, "El TipoDireccion solicitado no existe."));

            return _mapper.Map<TipoDireccionDto>(TipoDireccion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDireccion>> Post(TipoDireccionDto TipoDireccionDto)
        {
            var TipoDireccion = _mapper.Map<TipoDireccion>(TipoDireccionDto);
            _unitOfWork.TipoDireccions.Add(TipoDireccion);
            await _unitOfWork.SaveAsync();
            if (TipoDireccion == null)
                return BadRequest(new ApiResponse(400));

            TipoDireccionDto.Id = TipoDireccion.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoDireccionDto.Id }, TipoDireccionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDireccionDto>> Put(int id, [FromBody] TipoDireccionDto TipoDireccionDto)
        {
            if (TipoDireccionDto == null)
                return NotFound(new ApiResponse(404, "El TipoDireccion solicitado no existe."));

            var TipoDireccionBd = await _unitOfWork.TipoDireccions.GetByIdAsync(id);
            if (TipoDireccionBd == null)
                return NotFound(new ApiResponse(404, "El TipoDireccion solicitado no existe."));

            var TipoDireccion = _mapper.Map<TipoDireccion>(TipoDireccionDto);
            _unitOfWork.TipoDireccions.Update(TipoDireccion);
            await _unitOfWork.SaveAsync();
            return TipoDireccionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoDireccion = await _unitOfWork.TipoDireccions.GetByIdAsync(id);
            if (TipoDireccion == null)
                return NotFound(new ApiResponse(404, "El TipoDireccion solicitado no existe."));

            _unitOfWork.TipoDireccions.Delete(TipoDireccion);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
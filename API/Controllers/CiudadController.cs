using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CiudadController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get11()
        {
            var Ciudads = await _unitOfWork.Ciudads.GetAllAsync();
            return _mapper.Map<List<CiudadDto>>(Ciudads);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var Ciudad = await _unitOfWork.Ciudads.GetByIdAsync(id);
            if (Ciudad == null)
                return NotFound(new ApiResponse(404, "El Ciudad solicitado no existe."));

            return _mapper.Map<CiudadDto>(Ciudad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ciudad>> Post(CiudadDto CiudadDto)
        {
            var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
            _unitOfWork.Ciudads.Add(Ciudad);
            await _unitOfWork.SaveAsync();
            if (Ciudad == null)
                return BadRequest(new ApiResponse(400));

            CiudadDto.Id = Ciudad.Id;
            return CreatedAtAction(nameof(Post), new { id = CiudadDto.Id }, CiudadDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto CiudadDto)
        {
            if (CiudadDto == null)
                return NotFound(new ApiResponse(404, "El Ciudad solicitado no existe."));

            var CiudadBd = await _unitOfWork.Ciudads.GetByIdAsync(id);
            if (CiudadBd == null)
                return NotFound(new ApiResponse(404, "El Ciudad solicitado no existe."));

            var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
            _unitOfWork.Ciudads.Update(Ciudad);
            await _unitOfWork.SaveAsync();
            return CiudadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Ciudad = await _unitOfWork.Ciudads.GetByIdAsync(id);
            if (Ciudad == null)
                return NotFound(new ApiResponse(404, "El Ciudad solicitado no existe."));

            _unitOfWork.Ciudads.Delete(Ciudad);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
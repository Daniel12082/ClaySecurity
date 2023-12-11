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
    public class CategoriaPerController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaPerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaPerDto>>> Get11()
        {
            var CategoriaPers = await _unitOfWork.CategoriaPers.GetAllAsync();
            return _mapper.Map<List<CategoriaPerDto>>(CategoriaPers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaPerDto>> Get(int id)
        {
            var CategoriaPer = await _unitOfWork.CategoriaPers.GetByIdAsync(id);
            if (CategoriaPer == null)
                return NotFound(new ApiResponse(404, $"El CategoriaPer solicitado no existe."));

            return _mapper.Map<CategoriaPerDto>(CategoriaPer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPer>> Post(CategoriaPerDto CategoriaPerDto)
        {
            var CategoriaPer = _mapper.Map<CategoriaPer>(CategoriaPerDto);
            _unitOfWork.CategoriaPers.Add(CategoriaPer);
            await _unitOfWork.SaveAsync();
            if (CategoriaPer == null)
                return BadRequest(new ApiResponse(400));

            CategoriaPerDto.Id = CategoriaPer.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaPerDto.Id }, CategoriaPerDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPerDto>> Put(int id, [FromBody] CategoriaPerDto CategoriaPerDto)
        {
            if (CategoriaPerDto == null)
                return NotFound(new ApiResponse(404, $"El CategoriaPer solicitado no existe."));

            var CategoriaPerBd = await _unitOfWork.CategoriaPers.GetByIdAsync(id);
            if (CategoriaPerBd == null)
                return NotFound(new ApiResponse(404, $"El CategoriaPer solicitado no existe."));

            var CategoriaPer = _mapper.Map<CategoriaPer>(CategoriaPerDto);
            _unitOfWork.CategoriaPers.Update(CategoriaPer);
            await _unitOfWork.SaveAsync();
            return CategoriaPerDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var CategoriaPer = await _unitOfWork.CategoriaPers.GetByIdAsync(id);
            if (CategoriaPer == null)
                return NotFound(new ApiResponse(404, $"El CategoriaPer solicitado no existe."));

            _unitOfWork.CategoriaPers.Delete(CategoriaPer);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
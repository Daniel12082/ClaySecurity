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
    public class ContratoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContratoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContratoDto>>> Get11()
        {
            var Contratos = await _unitOfWork.Contratos.GetAllAsync();
            return _mapper.Map<List<ContratoDto>>(Contratos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Get(int id)
        {
            var Contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
            if (Contrato == null)
                return NotFound(new ApiResponse(404, "El Contrato solicitado no existe."));

            return _mapper.Map<ContratoDto>(Contrato);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contrato>> Post(ContratoDto ContratoDto)
        {
            var Contrato = _mapper.Map<Contrato>(ContratoDto);
            _unitOfWork.Contratos.Add(Contrato);
            await _unitOfWork.SaveAsync();
            if (Contrato == null)
                return BadRequest(new ApiResponse(400));

            ContratoDto.Id = Contrato.Id;
            return CreatedAtAction(nameof(Post), new { id = ContratoDto.Id }, ContratoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody] ContratoDto ContratoDto)
        {
            if (ContratoDto == null)
                return NotFound(new ApiResponse(404, "El Contrato solicitado no existe."));

            var ContratoBd = await _unitOfWork.Contratos.GetByIdAsync(id);
            if (ContratoBd == null)
                return NotFound(new ApiResponse(404, "El Contrato solicitado no existe."));

            var Contrato = _mapper.Map<Contrato>(ContratoDto);
            _unitOfWork.Contratos.Update(Contrato);
            await _unitOfWork.SaveAsync();
            return ContratoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
            if (Contrato == null)
                return NotFound(new ApiResponse(404, "El Contrato solicitado no existe."));

            _unitOfWork.Contratos.Delete(Contrato);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
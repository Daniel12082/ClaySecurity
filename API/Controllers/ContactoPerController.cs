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
    public class ContactoPerController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoPerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoPerDto>>> Get11()
        {
            var ContactoPers = await _unitOfWork.ContactoPers.GetAllAsync();
            return _mapper.Map<List<ContactoPerDto>>(ContactoPers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPerDto>> Get(int id)
        {
            var ContactoPer = await _unitOfWork.ContactoPers.GetByIdAsync(id);
            if (ContactoPer == null)
                return NotFound(new ApiResponse(404, "El ContactoPer solicitado no existe."));

            return _mapper.Map<ContactoPerDto>(ContactoPer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPer>> Post(ContactoPerDto ContactoPerDto)
        {
            var ContactoPer = _mapper.Map<ContactoPer>(ContactoPerDto);
            _unitOfWork.ContactoPers.Add(ContactoPer);
            await _unitOfWork.SaveAsync();
            if (ContactoPer == null)
                return BadRequest(new ApiResponse(400));

            ContactoPerDto.Id = ContactoPer.Id;
            return CreatedAtAction(nameof(Post), new { id = ContactoPerDto.Id }, ContactoPerDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPerDto>> Put(int id, [FromBody] ContactoPerDto ContactoPerDto)
        {
            if (ContactoPerDto == null)
                return NotFound(new ApiResponse(404, "El ContactoPer solicitado no existe."));

            var ContactoPerBd = await _unitOfWork.ContactoPers.GetByIdAsync(id);
            if (ContactoPerBd == null)
                return NotFound(new ApiResponse(404, "El ContactoPer solicitado no existe."));

            var ContactoPer = _mapper.Map<ContactoPer>(ContactoPerDto);
            _unitOfWork.ContactoPers.Update(ContactoPer);
            await _unitOfWork.SaveAsync();
            return ContactoPerDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ContactoPer = await _unitOfWork.ContactoPers.GetByIdAsync(id);
            if (ContactoPer == null)
                return NotFound(new ApiResponse(404, "El ContactoPer solicitado no existe."));

            _unitOfWork.ContactoPers.Delete(ContactoPer);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
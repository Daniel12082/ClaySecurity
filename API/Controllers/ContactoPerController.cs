using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ContactoPerController: ApiBaseController
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
        public async Task<ActionResult<IEnumerable<ContactoPer>>> Get()
        {
            var entidades = await _unitOfWork.ContactoPers.GetAllAsync();
            return _mapper.Map<List<ContactoPer>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPerDto>> Get(int id)
        {
            var entidad = await _unitOfWork.ContactoPers.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactoPerDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPer>> Post(ContactoPerDto ContactoPerDto)
        {
            var entidad = _mapper.Map<ContactoPer>(ContactoPerDto);
            this._unitOfWork.ContactoPers.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ContactoPerDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ContactoPerDto.Id}, ContactoPerDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPerDto>> Put(int id, [FromBody] ContactoPerDto ContactoPerDto)
        {
            if(ContactoPerDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<ContactoPer>(ContactoPerDto);
            _unitOfWork.ContactoPers.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ContactoPerDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.ContactoPers.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactoPers.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }

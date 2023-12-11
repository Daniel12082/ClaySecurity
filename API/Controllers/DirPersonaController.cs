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
public class DirPersonaController: ApiBaseController
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
        public async Task<ActionResult<IEnumerable<DirPersona>>> Get()
        {
            var entidades = await _unitOfWork.DirPersonas.GetAllAsync();
            return _mapper.Map<List<DirPersona>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DirPersonaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.DirPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<DirPersonaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DirPersona>> Post(DirPersonaDto DirPersonaDto)
        {
            var entidad = _mapper.Map<DirPersona>(DirPersonaDto);
            this._unitOfWork.DirPersonas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            DirPersonaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = DirPersonaDto.Id}, DirPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DirPersonaDto>> Put(int id, [FromBody] DirPersonaDto DirPersonaDto)
        {
            if(DirPersonaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<DirPersona>(DirPersonaDto);
            _unitOfWork.DirPersonas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return DirPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.DirPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.DirPersonas.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }

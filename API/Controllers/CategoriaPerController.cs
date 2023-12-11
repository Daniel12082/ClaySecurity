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
public class CategoriaPerController: ApiBaseController
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
        public async Task<ActionResult<IEnumerable<CategoriaPer>>> Get()
        {
            var entidades = await _unitOfWork.CategoriaPers.GetAllAsync();
            return _mapper.Map<List<CategoriaPer>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaPerDto>> Get(int id)
        {
            var entidad = await _unitOfWork.CategoriaPers.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoriaPerDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPer>> Post(CategoriaPerDto CategoriaPerDto)
        {
            var entidad = _mapper.Map<CategoriaPer>(CategoriaPerDto);
            this._unitOfWork.CategoriaPers.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            CategoriaPerDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = CategoriaPerDto.Id}, CategoriaPerDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaPerDto>> Put(int id, [FromBody] CategoriaPerDto CategoriaPerDto)
        {
            if(CategoriaPerDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<CategoriaPer>(CategoriaPerDto);
            _unitOfWork.CategoriaPers.Update(entidades);
            await _unitOfWork.SaveAsync();
            return CategoriaPerDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.CategoriaPers.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoriaPers.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }

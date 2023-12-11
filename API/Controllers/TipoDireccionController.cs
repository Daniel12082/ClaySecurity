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
public class TipoDireccionController: ApiBaseController
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
        public async Task<ActionResult<IEnumerable<TipoDireccion>>> Get()
        {
            var entidades = await _unitOfWork.TipoDireccions.GetAllAsync();
            return _mapper.Map<List<TipoDireccion>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDireccionDto>> Get(int id)
        {
            var entidad = await _unitOfWork.TipoDireccions.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoDireccionDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDireccion>> Post(TipoDireccionDto TipoDireccionDto)
        {
            var entidad = _mapper.Map<TipoDireccion>(TipoDireccionDto);
            this._unitOfWork.TipoDireccions.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            TipoDireccionDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoDireccionDto.Id}, TipoDireccionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDireccionDto>> Put(int id, [FromBody] TipoDireccionDto TipoDireccionDto)
        {
            if(TipoDireccionDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<TipoDireccion>(TipoDireccionDto);
            _unitOfWork.TipoDireccions.Update(entidades);
            await _unitOfWork.SaveAsync();
            return TipoDireccionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.TipoDireccions.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.TipoDireccions.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }

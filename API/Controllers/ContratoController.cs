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
public class ContratoController: ApiBaseController
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
        public async Task<ActionResult<IEnumerable<Contrato>>> Get()
        {
            var entidades = await _unitOfWork.Contratos.GetAllAsync();
            return _mapper.Map<List<Contrato>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Contratos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContratoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contrato>> Post(ContratoDto ContratoDto)
        {
            var entidad = _mapper.Map<Contrato>(ContratoDto);
            this._unitOfWork.Contratos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ContratoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ContratoDto.Id}, ContratoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody] ContratoDto ContratoDto)
        {
            if(ContratoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Contrato>(ContratoDto);
            _unitOfWork.Contratos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ContratoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Contratos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Contratos.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }

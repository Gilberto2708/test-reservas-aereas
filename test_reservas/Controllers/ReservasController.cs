using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using test_reservas.Data;
using test_reservas.Models;
using test_reservas.Models.DTO;
using test_reservas.Repository.IRepository;

namespace test_reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : Controller
    {


        private readonly IReservaRepository reservaRepository;
        private readonly IMapper mapper;

        public ReservasController(IReservaRepository reservaRepository, IMapper mapper)
        {
            this.reservaRepository = reservaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllReserva()
        {
            var reservas = reservaRepository.GetAllReserva();
            return Ok(mapper.Map<List<ReservaDTO>>(reservas));
        }

        [HttpGet("{id}", Name = "GetReserva")]
        public IActionResult GetReserva(int id)
        {
            var reserva = reservaRepository.GetReserva(id);
            if (reserva == null) return NotFound();
            return Ok(mapper.Map<ReservaDTO>(reserva));
        }

         [HttpGet("{origen?}/{destino?}/{tipo_pasajero?}/{hora_salida?}/{hora_llegada?}/{numero_vuelo?}")]
         public IActionResult GetAllFilterReserva(string origen, string destino, string tipo_pasajero, string hora_salida, string hora__llegada, string numero_vuelo)
        {         
            var reservas = reservaRepository.GetAllReserva(origen,destino, tipo_pasajero, hora_salida, hora__llegada, numero_vuelo);
            return Ok(mapper.Map<List<ReservaDTO>>(reservas));
        }

        [HttpPost]
        public IActionResult CreateReservar([FromBody] ReservaDTO reservaDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (reservaRepository.ReservaNumeroVueloExists(reservaDTO.Numero_Vuelo))
            {
                ModelState.AddModelError(string.Empty, $"Ya existe una reservación con ese numero de vuelo {reservaDTO.Numero_Vuelo}");
                return StatusCode(404, ModelState);

            }
            var reserva = mapper.Map<Reserva>(reservaDTO);

            if (!reservaRepository.CreateReserva(reserva))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar reservar el vuelo");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetReserva", new { id = reserva.Id }, reserva);

        }

        [HttpPut]
        public IActionResult UpdateReserva(int id, [FromBody] ReservaDTO reservaDTO)
        {
            if (id != reservaDTO.Id) return BadRequest(ModelState);
            var reservar = mapper.Map<Reserva>(reservaDTO);
            if (!reservaRepository.UpdateReserva(reservar))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar actualizar el vuelo");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReserva(int id)
        {
            if (!reservaRepository.ReservaExists(id)) return NotFound();

            var reserva = reservaRepository.GetReserva(id);
            if (!reservaRepository.DeleteReserva(reserva))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar eliminar el vuelo");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}

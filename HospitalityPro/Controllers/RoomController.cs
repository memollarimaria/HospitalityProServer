﻿using Domain.Contracts;
using DTO.RoomDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalityPro.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomDomain _roomDomain;

        public RoomController(IRoomDomain roomDomain)
        {
            _roomDomain = roomDomain;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromForm] CreateRoomDTO createRoomDTO)
        {
            if (createRoomDTO == null) { return NotFound(); }
            await _roomDomain.AddRoomAsync(createRoomDTO);
            return NoContent();
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RoomDTO>))]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomDomain.GetAllRoomAsync();
            if (rooms == null) { return NotFound(); }
            return Ok(rooms);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(RoomDTO))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var room = await _roomDomain.GetRoomByIdAsync(id);
            if (room == null) { return NotFound(); }
            return Ok(room);
        }
        [HttpGet]
        public IActionResult GetRoomPhotos()
        {
            var rooms = _roomDomain.GetRoomPhotos();
            if (rooms == null) { return NotFound(); }
            return Ok(rooms);
        }
    }
}

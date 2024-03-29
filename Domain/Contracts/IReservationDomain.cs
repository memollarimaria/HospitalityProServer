﻿using DTO.ReservationsDTOS;
using DTO.RoomDTOs;
using Entities.Models;
using DTO.SearchParametersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.ReservationServiceDTOs;

namespace Domain.Contracts
{
	public interface IReservationDomain
	{
		Task AddReservationAsync(CreateReservationDTO reservationDto);
		Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
		Task<ReservationDTO> GetReservationByIdAsync(Guid id);
		Task DeleteReservation(Guid reservationId);
		Task AddExtraService(Guid ReservationID,Guid serviceId);
        IEnumerable<ReservationDTO> GetReservationsOfUser();
		IEnumerable<ReservationDTO> ReservationsWithRoomService();
    }
}

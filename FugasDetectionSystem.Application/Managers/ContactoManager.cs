using FugasDetectionSystem.Application.DTOs;
using FugasDetectionSystem.Common;
using FugasDetectionSystem.Common.Models;
using FugasDetectionSystem.Domain.Entities;
using FugasDetectionSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Application.Managers
{
    public class ContactoManager
    {
        private readonly IContactoRepository _contactoRepository;
        private readonly IOrigenRepository _origenRepository;
        private readonly IHorarioTentativoRepository _horarioTentativoRepository;

        public ContactoManager(IContactoRepository contactoRepository, IOrigenRepository origenRepository, IHorarioTentativoRepository horarioTentativoRepository)
        {
            _contactoRepository = contactoRepository;
            _origenRepository = origenRepository;
            _horarioTentativoRepository = horarioTentativoRepository;
        }

        public async Task<Result<IEnumerable<ContactoDto>>> GetContactosAsync()
        {
            try
            {
                var contactos = await _contactoRepository.GetAllAsync();
                var contactoDtos = contactos.Select(c => new ContactoDto
                {
                    ContactoId = c.ContactoId,
                    OrigenId = c.OrigenId,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    CorreoElectronico = c.CorreoElectronico,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion,
                    CoordenadasMaps = c.CoordenadasMaps,
                    FechaTentativaVisita = c.FechaTentativaVisita,
                    HorarioTentativoId = c.HorarioTentativoId
                }).ToList();

                return Result<IEnumerable<ContactoDto>>.Success(contactoDtos);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<ContactoDto>>.Failure($"An error occurred while getting contactos: {ex.Message}");
            }
        }

        public async Task<Result> AddContactoAsync(ContactoNewUpdateDto contactoDto)
        {
            try
            {
                var contacto = new Contacto
                {
                    OrigenId = contactoDto.OrigenId,
                    Nombre = contactoDto.Nombre,
                    Apellido = contactoDto.Apellido,
                    CorreoElectronico = contactoDto.CorreoElectronico,
                    Telefono = contactoDto.Telefono,
                    Direccion = contactoDto.Direccion,
                    CoordenadasMaps = contactoDto.CoordenadasMaps,
                    FechaTentativaVisita = contactoDto.FechaTentativaVisita,
                    HorarioTentativoId = contactoDto.HorarioTentativoId
                };

                await _contactoRepository.AddAsync(contacto);
                return Result.Success("Contacto added successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"An error occurred while adding the contacto: {ex.Message}");
            }
        }

        public async Task<Result> UpdateContactoAsync(int id, ContactoNewUpdateDto contactoDto)
        {
            try
            {
                var contacto = await _contactoRepository.GetByIdAsync(id);
                if (contacto == null)
                {
                    return Result.Failure("Contacto not found.");
                }

                contacto.OrigenId = contactoDto.OrigenId;
                contacto.Nombre = contactoDto.Nombre;
                contacto.Apellido = contactoDto.Apellido;
                contacto.CorreoElectronico = contactoDto.CorreoElectronico;
                contacto.Telefono = contactoDto.Telefono;
                contacto.Direccion = contactoDto.Direccion;
                contacto.CoordenadasMaps = contactoDto.CoordenadasMaps;
                contacto.FechaTentativaVisita = contactoDto.FechaTentativaVisita;
                contacto.HorarioTentativoId = contactoDto.HorarioTentativoId;

                await _contactoRepository.UpdateAsync(contacto);
                return Result.Success("Contacto updated successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure($"An error occurred while updating the contacto: {ex.Message}");
            }
        }
    }
}

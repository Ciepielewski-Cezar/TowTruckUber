using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowTruckUberAPI.Models.Dtos
{
    public record UserDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Username { get; init; }
        public string Latitude { get; init; }
        public string Longitude { get; init; }
    }
}

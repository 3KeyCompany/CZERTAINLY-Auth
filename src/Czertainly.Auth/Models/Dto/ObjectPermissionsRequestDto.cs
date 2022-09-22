﻿using Czertainly.Auth.Common.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace Czertainly.Auth.Models.Dto
{
    public record ObjectPermissionsRequestDto
    {
        [Required]
        public Guid Uuid { get; set; }

        public List<string>? Allow { get; init; }

        public List<string>? Deny { get; init; }

    }
}

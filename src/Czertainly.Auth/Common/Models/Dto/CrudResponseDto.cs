﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Czertainly.Auth.Common.Models.Dto
{
    public record CrudResponseDto : ICrudResponseDto
    {
        [Required]
        [JsonPropertyOrder(-1)]
        public Guid Uuid { get; init;  }
    }
}

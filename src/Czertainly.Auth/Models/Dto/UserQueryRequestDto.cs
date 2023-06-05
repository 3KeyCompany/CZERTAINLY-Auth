﻿using Czertainly.Auth.Common.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Czertainly.Auth.Models.Dto
{
    public record UserQueryRequestDto : QueryRequestDto
    {
        [JsonPropertyName("group")]
        public string? Group { get; init; }

    }
}

﻿namespace LevvaCoins.Application.UseCases.Users.Dtos
{
    public class CreateUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }

    }
}

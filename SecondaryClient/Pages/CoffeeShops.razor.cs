﻿using API.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SecondaryClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SecondaryClient.Pages
{
    public partial class CoffeeShops
    {
        private List<CoffeeShopModel> Shops = new();
        [Inject] private HttpClient httpClient { get; set; }
        [Inject] private IConfiguration Config { get; set; }
        [Inject] private ITokenService TokenService { get; set; }
        protected override async Task OnInitializedAsync()
        {

            var tokenResponse = await TokenService.GetToken("CoffeeAPI.read");
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            var result = await httpClient.GetAsync(Config["apiUrl"] + "/api/CoffeeShop");

            if (result.IsSuccessStatusCode)
            {
                Shops = await result.Content.ReadFromJsonAsync<List<CoffeeShopModel>>();
            }
        }
    }
}

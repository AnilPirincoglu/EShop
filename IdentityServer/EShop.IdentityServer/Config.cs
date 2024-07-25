// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){ Scopes = { "CatalogFullPermisson","CatalogReadPermisson" }},
           new ApiResource("ResourceDiscount"){ Scopes = { "DiscountFullPermisson" }},
           new ApiResource("RessourceOrder"){ Scopes = { "OrderFullPermisson" }},
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
               new IdentityResources.OpenId(),
               new IdentityResources.Email(),
               new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
             new ApiScope("CatalogFullPermisson","Full authority for catalog operations"),
             new ApiScope("CatalogReadPermisson","Reading authority for catalog operations"),
             new ApiScope("DiscountFullPermisson","Full authority for discount operations"),
             new ApiScope("OrderFullPermisson","Full authority for order operations"),
             new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client()
            {
                ClientId = "EShopVisitorId",
                ClientName = "EShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("eshopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermisson" }
            },

            //Manager
            new Client()
            {
                ClientId = "EShopManagerId",
                ClientName = "EShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("eshopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermisson" }
            },

            //Admin
            new Client()
            {
                ClientId = "EShopAdminId",
                ClientName = "EShop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("eshopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermisson","DiscountFullPermisson","OrderFullPermisson"
                    ,IdentityServerConstants.LocalApi.ScopeName
                    ,IdentityServerConstants.StandardScopes.Email
                    ,IdentityServerConstants.StandardScopes.OpenId
                    ,IdentityServerConstants.StandardScopes.Profile
                    },
                AccessTokenLifetime=600
            }
        };
    }
}
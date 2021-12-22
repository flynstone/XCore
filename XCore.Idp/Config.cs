// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace XCore.Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "User roles", new List<string>{"role"})
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("xcoreapi.scope", "X-Core Api Scope")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("xcoreapi", "X-Core Api")
                {
                    Scopes = { "xcoreapi.scope" },
                    UserClaims = new List<string>{ "role" }
                }
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "XCoreClient",
                    ClientId = "xcoreclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{"https://localhost:5060/signin-oidc"},
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "xcoreapi.scope"
                    },
                    ClientSecrets = { new Secret("$ecret_P@swword-36915-13475".Sha512()) },
                    RequirePkce = true,
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5060/signout-callback-oidc" },
                    RequireConsent = true
                }
            };
    }
}
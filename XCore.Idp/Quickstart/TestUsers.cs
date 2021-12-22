// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "3a7ddbf0-c236-404f-9179-57bb40787968",
                    Username = "flynstone",
                    Password = "Password12!",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Julien"),
                        new Claim("family_name", "Lacroix"),
                        new Claim("address", "369 Fake Street"),
                        new Claim("role", "Admin")
                    }
                },
                new TestUser
                {
                    SubjectId = "db00101c-d899-4142-8879-be8aa8059317",
                    Username = "guest",
                    Password = "Guest_012",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Guest"),
                        new Claim("family_name", "User"),
                        new Claim("address", "963 Test Street"),
                        new Claim("role", "Visitor")
                    }
                }
            };
        
    }
}
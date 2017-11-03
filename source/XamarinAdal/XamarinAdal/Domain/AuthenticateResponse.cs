﻿using System;
namespace XamarinAdal.Domain
{
    public class AuthenticateResponse
    {
        public Profile Profile { get; set; } = new Profile();
        public string AuthHeader { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenType { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public bool ExtendedLifetimeToken { get; set; }
        public string IdToken { get; set; }
        public string TenantId { get; set; }
    }
}
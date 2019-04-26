using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudinaryHelp.Helper
{
    public class CloudinaryHelper
    {
        private readonly Account account;
        public CloudinaryHelper(string CloudName, string ApiKey, string ApiSecret)
        {
            account = new Account(CloudName, ApiKey, ApiSecret);
        }

        public Cloudinary GetCloudinaryClient()
        {
            return new Cloudinary(account);
        }
    }
}

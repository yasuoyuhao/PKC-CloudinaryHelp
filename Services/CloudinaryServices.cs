using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CloudinaryHelp.Helper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CloudinaryHelp.Services
{
    public class CloudinaryServices
    {
        private readonly CloudinaryHelper helper;
        private readonly IConfiguration configuration;

        public CloudinaryServices(IConfiguration configuration)
        {
            this.configuration = configuration;
            string CloudName = this.configuration["CloudinarySetting:CloudName"];
            string ApiKey = this.configuration["CloudinarySetting:ApiKey"];
            string ApiSecret = this.configuration["CloudinarySetting:ApiSecret"];

            helper = new CloudinaryHelper(CloudName, ApiKey, ApiSecret);
        }

        public ImageUploadResult UpdateImage(string fileName, Stream stream, List<string> tags = null)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
            };

            var tagsString = "";

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    if (tags.FirstOrDefault() == tag)
                    {
                        tagsString += $"{tag}";
                    }
                    else
                    {

                        tagsString += $", {tag}";
                    }
                }
            }

            if (!string.IsNullOrEmpty(tagsString))
            {
                uploadParams.Tags = tagsString;
            }

            Cloudinary client = helper.GetCloudinaryClient();
            ImageUploadResult uploadResult = client.Upload(uploadParams);

            return uploadResult;
        }
    }
}

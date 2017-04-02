using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoUpload.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
        }


        public IndexViewModel(string imageUrl)
        {
            ImageDataUrl = imageUrl;
        }

        public string ImageDataUrl { get; set; }
        public string Image2DataUrl { get; set; }


        public CropInformation CropInformation
        {
            get
            {
                var cropData = new CropInformation();
                if (string.IsNullOrEmpty(ImageDataUrl))
                {
                    // No Image
                }
                else
                {
                    if (ImageDataUrl.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Existing Profile Image
                        cropData = new CropInformation();
                    }
                    else
                    {
                        // New Profile Image
                        var dataOnly = System.Text.RegularExpressions.Regex.Replace(ImageDataUrl, "data:image\\/(\\w*);base64,", "");
                        cropData.Bytes = Convert.FromBase64String(dataOnly);
                    }
                }

                return cropData;
            }
        }
    }
}

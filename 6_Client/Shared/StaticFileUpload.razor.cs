using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace illegible.Client.Shared
{
    public partial class StaticFileUpload
    {
        private ElementReference _input;
        [Parameter]
        public string ImgUrl { get; set; }
        [Parameter]
        public EventCallback<string> OnChange { get; set; }
        [Inject]
        public IFileReaderService FileReaderService { get; set; }

        private async Task HandleSelected()
        {
            foreach (var file in await FileReaderService.CreateReference(_input).EnumerateFilesAsync())
            {
                if (file != null)
                {
                    var fileInfo = await file.ReadFileInfoAsync();
                    using (var ms = await file.CreateMemoryStreamAsync(4 * 1024))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(ms.Length)), "image", fileInfo.Name);
                        ImgUrl = await _httpRequestHandler.UploadStaticImage(content, "HandleStaticFile/UploadStaticFile");
                        await OnChange.InvokeAsync(ImgUrl);
                    }
                }
            }
        }
    }
}

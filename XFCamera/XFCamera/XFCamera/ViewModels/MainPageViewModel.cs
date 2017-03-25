using Plugin.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;

namespace XFCamera.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)     
        #endregion
        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region Title      
        private string _Title = "多奇數位創意有限公司";
        public string Title { get { return this._Title; } set { this.SetProperty(ref this._Title, value); } }
        #endregion

        #region MyImageSource    
        private ImageSource _ImageSource;
        public ImageSource MyImageSource
        {
            get { return this._ImageSource; }
            set { this.SetProperty(ref this._ImageSource, value); }
        }
        #endregion

        #region RemoteImageURL      
        private string _RemoteImageURL = "";        /// <summary>        /// RemoteImageURL        /// </summary>   
        public string RemoteImageURL
        {
            get { return this._RemoteImageURL; }
            set { this.SetProperty(ref this._RemoteImageURL, value); }
        }
        #endregion

        #endregion

        public DelegateCommand 拍照Command { get; set; }
        public readonly IPageDialogService _dialogService;


        public MainPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService; 拍照Command = new DelegateCommand(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await _dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions { Directory = "Sample", Name = "Sample555.jpg", });

                if (file == null) return;

                MyImageSource = ImageSource.FromStream(() => { var stream = file.GetStream(); return stream; });


                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {                        // 取得這個圖片檔案的完整路徑                    
                        var path = file.Path;                        // 取得這個檔案的最終檔案名稱         
                        var filename = Path.GetFileName(path);
                        // 開啟這個圖片檔案，並且讀取其內容      
                        using (var fs = file.GetStream())
                        {
                            var streamContent = new StreamContent(fs); streamContent.Headers.Add("Content-Type", "application/octet-stream"); streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + Path.GetFileName(path) + "\""); content.Add(streamContent, "file", filename);
                            // 上傳到遠端伺服器上        
                            HttpResponseMessage message = await client.PostAsync("http://xamarindoggy.azurewebsites.net/api/UploadImage", content); var input = message.Content.ReadAsStringAsync();
                            // 更新頁面上的 Image 控制項，顯示出剛剛上傳的圖片內容              
                            // 這個 RemoteImageURL 屬性綁訂到 View 上的 Image 物件               
                            RemoteImageURL = $"http://xamarindoggy.azurewebsites.net/uploads/{filename}";
                        }
                    }
                }


            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }
        public void OnNavigatedTo(NavigationParameters parameters) { }
    }
}

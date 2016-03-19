using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.Web.Http;

namespace Relaycommand
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand TestCommand { get; set; }
        public ICommand ManipulationCommand { get; set; }
        public ICommand GetImageCommand { get; set; }
        public EventHandler UIStoryboard { get; set; }
        private string imguri;

        //public string imguri { get { }; set; } = "ms-appx:///Assets/StoreLogo.png";
        public int elvalue
        {
            get; set;
        }

        public string Imguri
        {
            get
            {
                return imguri;
            }

            set
            {
                imguri = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Imguri"));
            }
        }

        public MainViewModel()
        {
            // TestCommand = new RelayCommand();
            TestCommand = new RelayCommand(para =>
           {
               //await new MessageDialog("你好世界" + para + elvalue).ShowAsync();
               if (UIStoryboard != null)
               {
                   UIStoryboard.Invoke(this, new EventArgs());
               }
           });
            ManipulationCommand = new RelayCommand(async para =>
              {

                  Point p = (Point)para;
                  if (p != null)
                      await new MessageDialog("你好" + p.X + "|" + p.Y).ShowAsync();

              });
            GetImageCommand = new RelayCommand(async para =>
              {
                  string uri = "https://pic4.zhimg.com/6b84ba24b698381d87d831cb01b201bb_m.png";
                  await DownloadAndScale("a.png", uri, new Size(100, 100));
                  //var files = ApplicationData.Current.LocalFolder.GetFileAsync("a.png");
                  this.Imguri = new Uri("ms-appdata:///local/a.png").ToString();
                  //await DownloadImage(uri);
              });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async Task DownloadAndScale(string outfileName, string downloadUriString, Size scaleSize)
        {
            try
            {
                Uri downLoadingUri = new Uri(downloadUriString);//创建uri对象
                HttpClient client = new HttpClient();//实例化httpclient对象
                using (var response = await client.GetAsync(downLoadingUri))
                {
                    //var buffer = await response.Content.ReadAsStreamAsync();
                    var buffer = await response.Content.ReadAsBufferAsync();//从返回的数据中读取buffer
                    var memoryStream = new InMemoryRandomAccessStream();
                    await memoryStream.WriteAsync(buffer);//将buffer写入memorystream
                    await memoryStream.FlushAsync();//刷新
                    var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(memoryStream);//解密文件流
                    //确定图片大小
                    var bt = new Windows.Graphics.Imaging.BitmapTransform();
                    bt.ScaledWidth = (uint)scaleSize.Width;
                    bt.ScaledHeight = (uint)scaleSize.Height;
                    //得到像素数值
                    var pixelProvider = await decoder.GetPixelDataAsync(
                        decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, bt,
                        ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.ColorManageToSRgb);


                    //下面保存图片
                    // Now that we have the pixel data, get the destination file
                    var localFolder = ApplicationData.Current.LocalFolder;
                    //var resultsFolder = await localFolder.CreateFolderAsync("Results", CreationCollisionOption.OpenIfExists);
                    var scaledFile = await localFolder.CreateFileAsync(outfileName, CreationCollisionOption.ReplaceExisting);
                    using (var scaledFileStream = await scaledFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var encoder = await BitmapEncoder.CreateAsync(
                            BitmapEncoder.JpegEncoderId, scaledFileStream);
                        var pixels = pixelProvider.DetachPixelData();
                        encoder.SetPixelData(
                            decoder.BitmapPixelFormat,
                            decoder.BitmapAlphaMode,
                            (uint)scaleSize.Width,
                            (uint)scaleSize.Height,
                            decoder.DpiX,
                            decoder.DpiY,
                            pixels
                            );
                        await encoder.FlushAsync();
                    }

                }
                await new MessageDialog("succeed").ShowAsync();
            }
            catch (Exception) { Debug.WriteLine("工具，图片异常"); }
        }


        private async Task<SoftwareBitmap> DownloadImage(string url)
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage resp = await hc.GetAsync(new Uri(url));
                resp.EnsureSuccessStatusCode();
                IInputStream inputStream = await resp.Content.ReadAsInputStreamAsync();
                IRandomAccessStream memStream = new InMemoryRandomAccessStream();
                await RandomAccessStream.CopyAsync(inputStream, memStream);
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(memStream);
                SoftwareBitmap softBmp = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                return softBmp;
                await new MessageDialog("succeed").ShowAsync();

            }
            catch (Exception ex)
            {
                await new MessageDialog("failed").ShowAsync();

                return null;
            }
        }
    }
}

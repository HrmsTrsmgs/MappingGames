using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Marimo.MappingGames.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

        WriteableBitmap _元画像 = null;
        public WriteableBitmap 元画像
        {
            get => _元画像;
            set => SetProperty(ref _元画像, value);
        }

        public ObservableCollection<ImageSource> 分割された画像 { get; } = new ObservableCollection<ImageSource>();

        ICommand _画像を取り込むCommand;
        public ICommand 画像を取り込むCommand
        {
            get
            {
                if (_画像を取り込むCommand == null)
                {
                    _画像を取り込むCommand = new DelegateCommand<object>(
                        async param =>
                        {
                            var c = Clipboard.GetContent();

                            var b = await c.GetBitmapAsync();

                            var stream = await b.OpenReadAsync();
                            stream.AsStreamForWrite();
                            var writeable = new WriteableBitmap(1, 1);
                            await writeable.SetSourceAsync(stream);

                            元画像 = writeable;
                        });
                }

                return _画像を取り込むCommand;
            }
        }
        ICommand _画像を分割するCommand;
        public ICommand 画像を分割するCommand
        {
            get
            {
                if (_画像を分割するCommand == null)
                {
                    _画像を分割するCommand = new DelegateCommand<object>(
                        param =>
                        {

                            var blockWidth = 32;
                            var blockHeight = 32;

                            var buffer = new byte[blockWidth * blockHeight * 4];
                            元画像.PixelBuffer.ToArray();
                            var a = 元画像.PixelBuffer.ToArray();
                            for (var offsetWidth = 14; offsetWidth < 元画像.PixelWidth - blockWidth; offsetWidth += blockWidth)
                            {
                                for (var offsetHeight = 90; offsetHeight < 元画像.PixelHeight - blockHeight; offsetHeight += blockHeight)
                                {
                                    for (int i = 0; i < blockHeight; i++)
                                    {

                                        Array.Copy(
                                            a,
                                            (offsetWidth + (i + offsetHeight) * 元画像.PixelWidth) * 4,
                                            buffer,
                                            i * blockWidth * 4,
                                            blockWidth * 4);
                                    }
                                    var block = new WriteableBitmap(blockWidth, blockHeight);
                                    buffer.CopyTo(block.PixelBuffer);
                                    分割された画像.Add(block);
                                }
                            }
                        });
                }

                return _画像を分割するCommand;
            }
        }

        
    }
}

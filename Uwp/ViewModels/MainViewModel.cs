using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
        int _元画像倍率パーセント = 100;
        public int 元画像倍率パーセント
        {
            get => _元画像倍率パーセント;
            set
            {
                SetProperty(ref _元画像倍率パーセント, value);
                RaisePropertyChanged(nameof(画像サイズ));
                RaisePropertyChanged(nameof(分割領域表示の左上));
                RaisePropertyChanged(nameof(分割領域表示のサイズ));
                RaisePropertyChanged(nameof(格子));
            }
        }

        int _分割サイズ幅 = 48;

        public int 分割サイズ幅
        {
            get => _分割サイズ幅;
            set
            {
                SetProperty(ref _分割サイズ幅, value);
                RaisePropertyChanged(nameof(格子));
            }
        }
        int _分割サイズ高さ = 48;

        public int 分割サイズ高さ
        {
            get => _分割サイズ高さ;
            set
            {
                SetProperty(ref _分割サイズ高さ, value);
                RaisePropertyChanged(nameof(格子));
            }
        }

        WriteableBitmap _元画像 = null;
        public WriteableBitmap 元画像
        {
            get => _元画像;
            set => SetProperty(ref _元画像, value);
        }

        Size _元画像サイズ = new Size();
        public Size 元画像サイズ
        {
            get => _元画像サイズ;
            set
            {
                SetProperty(ref _元画像サイズ, value);
                RaisePropertyChanged(nameof(画像サイズ));
                RaisePropertyChanged(nameof(分割領域表示の左上));
                RaisePropertyChanged(nameof(分割領域表示のサイズ));
                RaisePropertyChanged(nameof(格子));
            }
        }
        public Size 画像サイズ
        {
            get => new Size(元画像サイズ.Width * 元画像倍率パーセント / 100, 元画像サイズ.Height * 元画像倍率パーセント / 100);
        }

        int _分割領域の上限;

        public int 分割領域の上限
        {
            get => _分割領域の上限;
            set
            {
                SetProperty(ref _分割領域の上限, value);
                RaisePropertyChanged(nameof(分割領域のサイズ));
                RaisePropertyChanged(nameof(分割領域表示の左上));
                RaisePropertyChanged(nameof(分割領域表示のサイズ));
                RaisePropertyChanged(nameof(格子));

            }
        }

        int _分割領域の下限;

        public int 分割領域の下限
        {
            get => _分割領域の下限;
            set
            {
                SetProperty(ref _分割領域の下限, value);
                RaisePropertyChanged(nameof(分割領域のサイズ));
                RaisePropertyChanged(nameof(分割領域表示の左上));
                RaisePropertyChanged(nameof(分割領域表示のサイズ));
                RaisePropertyChanged(nameof(格子));
            }
        }

        int _分割領域の左限;

        public int 分割領域の左限
        {
            get => _分割領域の左限;
            set
            {
                SetProperty(ref _分割領域の左限, value);
                RaisePropertyChanged(nameof(分割領域のサイズ));
                RaisePropertyChanged(nameof(分割領域表示の左上));
                RaisePropertyChanged(nameof(分割領域表示のサイズ));
                RaisePropertyChanged(nameof(格子));
            }
        }

        int _分割領域の右限;

        public int 分割領域の右限
        {
            get => _分割領域の右限;
            set
            {
                SetProperty(ref _分割領域の右限, value);
                RaisePropertyChanged(nameof(分割領域のサイズ));
                RaisePropertyChanged(nameof(分割領域表示の左上));
                RaisePropertyChanged(nameof(分割領域表示のサイズ));
                RaisePropertyChanged(nameof(格子));
            }
        }

        public class LineViewModel : ViewModelBase
        {
            public LineViewModel(int x1, int y1, int x2, int y2)
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
            }

            public int X1 { get; }
            public int Y1 { get; }
            public int X2 { get; }
            public int Y2 { get; }
        }

        public IEnumerable<LineViewModel> 格子
        {
            get
            {
                if (元画像 == null) yield break;
                for (var offsetWidth = 0; offsetWidth < 分割領域のサイズ.Width; offsetWidth += 分割サイズ幅)
                {
                    yield return new LineViewModel(
                        分割領域表示の左上.X + offsetWidth * 元画像倍率パーセント / 100,
                        分割領域表示の左上.Y + 0 * 元画像倍率パーセント / 100,
                        分割領域表示の左上.X + offsetWidth * 元画像倍率パーセント / 100,
                        分割領域表示の左上.Y + 分割領域のサイズ.Height * 元画像倍率パーセント / 100);
                }
                for (var offsetHeight = 0; offsetHeight < 分割領域のサイズ.Height; offsetHeight += 分割サイズ高さ)
                {
                    yield return new LineViewModel(
                        分割領域表示の左上.X + 0 * 元画像倍率パーセント / 100,
                        分割領域表示の左上.Y + offsetHeight * 元画像倍率パーセント / 100,
                        分割領域表示の左上.X + 分割領域のサイズ.Width * 元画像倍率パーセント / 100,
                        分割領域表示の左上.Y + offsetHeight * 元画像倍率パーセント / 100);
                }
            }
        }

        public Size 分割領域のサイズ =>
            new Size(分割領域の右限 - 分割領域の左限, 分割領域の下限 - 分割領域の上限);

        public Point 分割領域表示の左上 =>
            new Point(
                分割領域の左限 * 元画像倍率パーセント / 100,
                分割領域の上限 * 元画像倍率パーセント / 100);

        public Size 分割領域表示のサイズ =>
            new Size(
                (分割領域の右限 - 分割領域の左限) * 元画像倍率パーセント / 100,
                (分割領域の下限 - 分割領域の上限) * 元画像倍率パーセント / 100);

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
                            元画像サイズ = new Size(writeable.PixelWidth, writeable.PixelHeight);
                            分割領域の上限 = 0;
                            分割領域の下限 = 元画像サイズ.Height;
                            分割領域の左限 = 0;
                            分割領域の右限 = 元画像サイズ.Width;
                            分割領域の上限 = 93;
                            分割領域の下限 = 617;
                            分割領域の左限 = 25;
                            分割領域の右限 = 553;
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
                            分割された画像.Clear();
                            var buffer = new byte[分割サイズ幅 * 分割サイズ高さ * 4];
                            元画像.PixelBuffer.ToArray();
                            var a = 元画像.PixelBuffer.ToArray();
                            for (var offsetWidth = 分割領域の左限; offsetWidth < 分割領域のサイズ.Width - 分割サイズ幅; offsetWidth += 分割サイズ幅)
                            {
                                for (var offsetHeight = 分割領域の上限; offsetHeight < 分割領域のサイズ.Height - 分割サイズ高さ; offsetHeight += 分割サイズ高さ)
                                {
                                    for (int i = 0; i < 分割サイズ高さ; i++)
                                    {

                                        Array.Copy(
                                            a,
                                            (offsetWidth + (i + offsetHeight) * 元画像.PixelWidth) * 4,
                                            buffer,
                                            i * 分割サイズ幅 * 4,
                                            分割サイズ幅 * 4);
                                    }
                                    var block = new WriteableBitmap(分割サイズ幅, 分割サイズ高さ);
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

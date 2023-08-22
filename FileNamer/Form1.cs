using System.Globalization;

namespace FileNamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles("E:\\");

            var numbers = new List<string>();
            for(int i=1;i<= files.Count();i++)
            {
                numbers.Add(i.ToString().PadLeft(3, '0'));
            }

            numbers.Shuffle();


            var nn = 0;
            foreach (var file in files)
            {
                var f=new FileInfo(file);

                var fn = f.Name;
                var a = fn.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var t=int.TryParse(a[0], out var b);
                if(t)
                {
                    var ll = a.ToList();
                    ll.RemoveAt(0);
                    fn = String.Join('_', ll); 
                }

                fn = fn.Replace("[YT2mp3.info] - ", "")
                  .Replace("y2mate.com - ", "")
                  .Replace(" VDownloader", "")
                  .Replace(" (Official Video)", "")
                  .Replace(" (Official Music Video)", "")
                  .Replace(" (Lyrics)", "")
                  .Replace("[TubeRipper.com]", "")
                  .Replace(" -  Lyrics", "")
                  .Replace("(320kbps)", "")
                  .Replace("(Lyrics - Lyric Video)", "")
                  .Replace(" (official video)", "")
                  .Replace(" - Original", "")
                  .Replace("(Lyrics version)", "")
                  .Replace("(TikTok)", "")
                  .Replace("(1)", "")
                  .Replace(" [Official Music", "")
                  .Replace(" (Official Audio)", "")
                  .Replace(" (Sözleri_Lyrics)","")
                  .Replace("_Music Video","");



                //var prefix = nn.ToString().PadLeft(3, '0');
                var prefix = numbers[nn];



                f.MoveTo(f.DirectoryName + "\\" + prefix + "_" + fn);
                if(f.Extension==".mp4")
                {
                    f.MoveTo(f.FullName.Replace(".mp4", ".mp3"));
                }

                nn++;
            }

        }
    }
}
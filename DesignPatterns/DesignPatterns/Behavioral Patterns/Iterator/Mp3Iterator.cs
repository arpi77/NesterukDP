using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral_Patterns.Iterator
{
    public static class Program2
    {
        public static void Main(string[] args)
        {
            var mp3Iterator = new Mp3Iterator(@"c:\");
            foreach (var mp3 in mp3Iterator
                .Where(m => m.Name.Contains("zene"))
                .Where(m => m.Directory.Parent.Name.Contains("eloado")))
            {
                // play the song
            }
        }
    }

    public class Mp3Iterator : IEnumerable<FileInfo>
    {
        private readonly string _startingPath;

        public Mp3Iterator(string startingPath)
        {
            _startingPath = startingPath;
        }

        public IEnumerator<FileInfo> GetEnumerator()
        {
            var files = Directory.GetFiles(_startingPath, "*.mp3", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                yield return new FileInfo(file);
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
